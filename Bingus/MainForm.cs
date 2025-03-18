using Bingus.Net;
using Bingus.Properties;
using Bingus.Settings;
using Bingus.Sfx;
using Bingus.UI;
using Bingus.Util;
using BingusServer;
using Neto.Shared;
using System.Diagnostics;
using System.Reflection;

namespace Bingus
{
    public partial class MainForm : Form
    {
        private static object _connectLock = new object();
        private readonly Client _client;
        private Server? _server = null;
        private string _lastRoom = string.Empty;
        private string _lastAdminPass = string.Empty;
        private SoundLibrary _sounds;
        private bool _autoReconnect;
        private bool _connecting = false;
        private RawInputHandler _rawInput;
        private bool _hasCheckedUpdates;

        public MainForm()
        {
            InitializeComponent();
            Icon = Resources.icon;

            _sounds = new SoundLibrary();
            _sounds.SetAudioDevice(Properties.Settings.Default.OutputDevice);
            _rawInput = new RawInputHandler(Handle);

            if (Properties.Settings.Default.MainWindowSizeX > 0 && Properties.Settings.Default.MainWindowSizeY > 0)
            {
                var prev = AutoScaleMode;
                AutoScaleMode = AutoScaleMode.None;
                Width = Properties.Settings.Default.MainWindowSizeX;
                Height = Properties.Settings.Default.MainWindowSizeY;
                AutoScaleMode = prev;
            }

            FormClosing += async (o, e) =>
            {
                _autoReconnect = false;
                _sounds.Dispose();
                _client?.Disconnect();
                Properties.Settings.Default.Save();
                //Stop server and serialize rooms
                if (_server != null)
                    await _server.Stop();
            };
            _client = new Client();
            _client.PacketDelayMs = Properties.Settings.Default.DelayMatchEvents;
            addClientListeners(_client);
            listenToSettingsChanged();
            SizeChanged += mainForm_SizeChanged;
            LocationChanged += mainForm_LocationChanged;
            Instance = this;

            addVersionToTitle();
        }

        public static MainForm? Instance { get; private set; }

        public RawInputHandler RawInput => _rawInput;

        public SoundLibrary SoundPlayer => _sounds;

        private bool FormReady => !Disposing && !IsDisposed && IsHandleCreated;

        public static Font GetFontFromSettings(Font defaultFont, float size, float defaultSize = 12f)
        {
            var ffName = Properties.Settings.Default.BingoFont;
            var scale = Properties.Settings.Default.BingoFontSize / defaultSize;
            if (!string.IsNullOrWhiteSpace(ffName))
            {
                try
                {
                    Font? font;
                    var ff2 = new FontFamily(ffName);
                    font = new Font(ff2, size * scale, (FontStyle)Properties.Settings.Default.BingoFontStyle);
                    if (font.Name == ffName)
                        return font;
                }
                catch (ArgumentException)
                {
                    //Font was not found
                }
            }
            return defaultFont;
        }

        public static MainForm? GetMainForm(Control control)
        {
            Control parent = control;
            while (parent.Parent != null)
            {
                parent = parent.Parent;
            }
            return parent as MainForm;
        }

        public void PrintToConsole(string text, Color color, bool timestamp = true)
        {
            _consoleControl.PrintToConsole(text, color, timestamp);
        }

        protected override void WndProc(ref Message m)
        {
            if (_rawInput != null)
            {
                _rawInput.ProcessRawInput(m);
            }
            base.WndProc(ref m);
        }

        private void addVersionToTitle()
        {
            var v = getCleanVersionString();
            if (v != null)
            {
                Text += " " + v;
            }
        }

        private string getCleanVersionString()
        {
            Version? version = Assembly.GetExecutingAssembly().GetName().Version;
            if (version == null)
                return string.Empty;

            string v = $"v{version.Major}.{version.Minor}";
            if (version.Build > 0)
                v += $".{version.Build}";

            return v;
        }

        private async void _connectButton_Click(object sender, EventArgs e)
        {
            lock (_connectLock)
            {
                if (_connecting)
                {
                    _consoleControl.PrintToConsole("Already connecting...", Color.Red);
                    return;
                }
            }
            var form = new ConnectForm();
            form.TopMost = true;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                await connect(form.Address, form.Port);
            }
        }

        private async Task connect(string address, int port)
        {
            lock (_connectLock)
            {
                if (_connecting)
                    return;

                _connecting = true;
            }
            try
            {
                var connectRetries = 500;
                while (_connecting && connectRetries > 0)
                {
                    try
                    {
                        ConnectionResult connectResult = await initClientAsync(address, port);
                        if (connectResult == ConnectionResult.Connected)
                        {
                            if (_autoReconnect && !string.IsNullOrEmpty(_lastRoom))
                            {
                                await _client.JoinRoom(
                                _lastRoom,
                                _lastAdminPass,
                                Properties.Settings.Default.Nickname,
                                Properties.Settings.Default.Team);
                            }
                            //Set the flag to automatically reconnect. This will be set to false if a disconnect is triggered manually or by kick
                            _autoReconnect = true;
                            return; //Successfully connected, so we return immediately
                        }
                    }
                    catch
                    {
                        //Try again
                    }
                    --connectRetries;
                    await Task.Delay(2000);
                }
            }
            finally
            {
                _connecting = false;
                updateButtonAvailability();
            }
        }

        private async void _createLobbyButton_Click(object sender, EventArgs e)
        {
            if (_client?.IsConnected != true)
                return;

            var form = new CreateLobbyForm(_client, true);
            form.TopMost = true;
            _ = _client.RequestRoomName();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                _lastRoom = form.RoomName.Trim();
                _lastAdminPass = form.AdminPassword;
                await _client.CreateRoom(
                    _lastRoom,
                    _lastAdminPass,
                    form.Nickname,
                    form.Team,
                    GameSettingsHelper.ReadFromSettings(Properties.Settings.Default));
            }
        }

        private async void _disconnectButton_Click(object sender, EventArgs e)
        {
            if (_client?.IsConnected != true && !_connecting)
                return;

            var res = MessageBox.Show(this, "Disconnect from server?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                _connecting = false;
                _autoReconnect = false;
                if (_client?.IsConnected == true)
                    await _client.Disconnect();
                updateButtonAvailability();
            }
        }

        private async void _joinLobbyButton_Click(object sender, EventArgs e)
        {
            if (_client?.IsConnected != true)
                return;

            var form = new CreateLobbyForm(_client, false);
            form.TopMost = true;
            form.RoomName = _lastRoom;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                _lastRoom = form.RoomName.Trim();
                _lastAdminPass = form.AdminPassword;
                await _client.JoinRoom(
                    _lastRoom,
                    form.AdminPassword,
                    form.Nickname,
                    form.Team);
            }
        }

        private async void _leaveRoomButton_Click(object sender, EventArgs e)
        {
            if (_client?.IsConnected != true)
                return;

            var res = MessageBox.Show(this, "Leave current lobby?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                await _client.LeaveRoom();
                updateButtonAvailability();
            }
        }

        private async void _changeTeamButton_Click(object sender, EventArgs e)
        {
            if (_client.LocalUser == null)
                return;

            var form = new ChangeTeamForm();
            form.TopMost = true;

            var teamBefore = _client.LocalUser.Team;
            form.Team = teamBefore;

            if (form.ShowDialog(this) == DialogResult.OK && form.Team != teamBefore)
            {
                await _client.SendPacketToServer(new Packet(new ClientRequestTeamChange(form.Team)));
            }
        }

        private void _settingsButton_Click(object sender, EventArgs e)
        {
            var settingsDialog = new SettingsDialog();
            settingsDialog.TopMost = true;
            settingsDialog.ShowDialog(this);
        }

        private void addClientListeners(Client? client)
        {
            if (client == null)
                return;

            client.Connected += client_Connected;
            client.Disconnected += client_Disconnected;
            client.Kicked += client_Kicked;
            client.OnStatus += client_OnStatus;
            client.OnError += client_OnError;
            client.OnRoomChanged += client_RoomChanged;

            client.AddListener<ServerJoinRoomAccepted>(joinRoomAccepted);
            client.AddListener<ServerJoinRoomDenied>(joinRoomDenied);
            client.AddListener<ServerUserChecked>(userCheckedSquare);
            client.AddListener<ServerBingoAchievedUpdate>(bingoAchieved);
            client.AddListener<ServerBroadcastMessage>(onServerMessage);
        }

        private void onServerMessage(ClientModel? model, ServerBroadcastMessage message)
        {
            _consoleControl.PrintToConsole("Server: " + message.Message, Color.Orange);
        }

        private void client_Connected(object? sender, EventArgs e)
        {
            updateButtonAvailability();
        }

        private async void client_Disconnected(object? sender, StringEventArgs e)
        {
            if (!FormReady)
                return;
            BeginInvoke(hideLobbyTab);
            updateButtonAvailability();
            _consoleControl.PrintToConsole(e.Message, Color.Red);
            updateStatusString();
            if (_autoReconnect && !string.IsNullOrWhiteSpace(Properties.Settings.Default.ServerAddress))
            {
                await connect(Properties.Settings.Default.ServerAddress, Properties.Settings.Default.Port);
            }
        }

        private void client_Kicked(object? sender, StringEventArgs e)
        {
            _consoleControl.PrintToConsole(e.Message, Color.Red);
            _autoReconnect = false; //So we don't reconnect automatically after kick
            _connecting = false;
        }

        private void joinRoomAccepted(ClientModel? _, ServerJoinRoomAccepted joinRoomAcceptedArgs)
        {
            updateButtonAvailability();
        }

        private void joinRoomDenied(ClientModel? _, ServerJoinRoomDenied joinRoomDeniedArgs)
        {
            updateButtonAvailability();
        }

        private void userCheckedSquare(ClientModel? _, ServerUserChecked userCheckedSquareArgs)
        {
            if (!Properties.Settings.Default.PlaySounds)
                return;
            //Only play sound if the team checking is now present in the square
            if (userCheckedSquareArgs.TeamsChecked.Contains(userCheckedSquareArgs.Team))
            {
                if (userCheckedSquareArgs.Team == _client?.LocalUser?.Team)
                    _sounds.PlaySound(SoundType.SquareClaimedOwn);
                else
                    _sounds.PlaySound(SoundType.SquareClaimedOther);
            }
        }

        private void bingoAchieved(ClientModel? model, ServerBingoAchievedUpdate update)
        {
            if (Properties.Settings.Default.PlaySounds)
            {
                _sounds.PlaySound(SoundType.Bingo);
            }
        }

        private void showLobbyTab()
        {
            void update()
            {
                if (!tabControl1.TabPages.Contains(_lobbyPage))
                    tabControl1.TabPages.Add(_lobbyPage);
                tabControl1.SelectedIndex = 1;
            }
            if (InvokeRequired)
            {
                BeginInvoke(update);
                return;
            }
            update();
        }

        private void hideLobbyTab()
        {
            void update()
            {
                tabControl1.TabPages.Remove(_lobbyPage);
                tabControl1.SelectedIndex = 0;
            }
            if (InvokeRequired)
            {
                BeginInvoke(update);
                return;
            }
            update();
        }

        private void updateStatusString()
        {
            if (_client == null)
                return;
            void update()
            {
                _clientStatusTextBox.Text = _client.GetConnectionStatusString();
            };
            if (InvokeRequired)
            {
                BeginInvoke(update);
                return;
            }
            update();
        }

        private void client_RoomChanged(object? sender, RoomChangedEventArgs e)
        {
            if (_client == null)
                return;

            void update()
            {
                if (_client.Room != null && _lobbyPage.Parent == null)
                {
                    showLobbyTab();
                }
                if (_client.Room == null && _lobbyPage.Parent != null)
                {
                    hideLobbyTab();
                }
                _clientStatusTextBox.Text = _client.GetConnectionStatusString();
            }
            if (InvokeRequired)
            {
                BeginInvoke(update);
                return;
            }
            update();
        }

        private void client_OnStatus(object? sender, StringEventArgs e)
        {
            if (FormReady)
            {
                _consoleControl.PrintToConsole(e.Message, Color.LightBlue);
                updateStatusString();
            }
        }

        private void client_OnError(object? sender, StringEventArgs e)
        {
            if (FormReady)
            {
                _consoleControl.PrintToConsole(e.Message, Color.Red);
                updateStatusString();
            }
        }

        private void default_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Properties.Settings.Default.ControlBackColor))
            {
                BackColor = Properties.Settings.Default.ControlBackColor;
                _consoleControl.BackColor = Properties.Settings.Default.ControlBackColor;
                _lobbyControl.BackColor = Properties.Settings.Default.ControlBackColor;
            }
            if (e.PropertyName == nameof(Properties.Settings.Default.HostServerOnLaunch))
            {
                if (_server == null && Properties.Settings.Default.HostServerOnLaunch)
                    hostServer();
            }
            if (e.PropertyName == nameof(Properties.Settings.Default.AlwaysOnTop))
            {
                TopMost = Properties.Settings.Default.AlwaysOnTop;
            }
            if (e.PropertyName == nameof(Properties.Settings.Default.DelayMatchEvents) && _client != null)
            {
                _client.PacketDelayMs = Properties.Settings.Default.DelayMatchEvents;
            }
            if (e.PropertyName == nameof(Properties.Settings.Default.OutputDevice))
            {
                _sounds.SetAudioDevice(Properties.Settings.Default.OutputDevice);
            }
            if (e.PropertyName == nameof(Properties.Settings.Default.CheckForUpdates))
            {
                //If user just enabled "check for updates", do a little check
                if (!_hasCheckedUpdates && Properties.Settings.Default.CheckForUpdates)
                    checkForUpdates();
            }
        }

        private void hostServer()
        {
            if (_server == null)
            {
                string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string appSpecificFolder = Path.Combine(appDataFolder, Application.ProductName);

                if (!Directory.Exists(appSpecificFolder))
                {
                    Directory.CreateDirectory(appSpecificFolder);
                }
                string jsonFile = Path.Combine(appSpecificFolder, "serverData.json");
                _server = new Server(Properties.Settings.Default.Port, jsonFile);
                _server.OnStatus += server_OnStatus;
                _server.OnError += server_OnError;
                _server.Host();
            }
        }

        private async Task<ConnectionResult> initClientAsync(string address, int port)
        {
            if (_client.IsConnected == true)
                await _client.Disconnect();
            updateButtonAvailability();

            var ipendpoint = Neto.Client.NetoClient.EndPointFromAddress(address, port, out string error);
            if (ipendpoint == null)
            {
                MessageBox.Show(this, error, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return ConnectionResult.Denied;
            }
            else
            {
                var connectResult = await _client.Connect(address, port);
                updateButtonAvailability();
                return connectResult;
            }
        }

        private void listenToSettingsChanged()
        {
            Properties.Settings.Default.PropertyChanged += default_PropertyChanged;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.MainWindowPositionX > -99 && Properties.Settings.Default.MainWindowPositionY > -99)
            {
                Location = new Point(Properties.Settings.Default.MainWindowPositionX, Properties.Settings.Default.MainWindowPositionY);
            }

            if (Properties.Settings.Default.MainWindowMaximized)
            {
                WindowState = FormWindowState.Maximized;
            }

            if (Properties.Settings.Default.HostServerOnLaunch)
            {
                hostServer();
            }

            var c = Properties.Settings.Default.ControlBackColor;

            _consoleControl.BackColor = c;
            _lobbyControl.BackColor = c;
            _lobbyControl.HandleCreated += _lobbyControl_HandleCreated;
            //Select (and initialize) the lobby control
            tabControl1.SelectedIndex = 1;

            updateButtonAvailability();

            //Set the initial status of the status text box
            updateStatusString();

            if (Properties.Settings.Default.AutoConnect && !string.IsNullOrWhiteSpace(Properties.Settings.Default.ServerAddress))
            {
                await connect(Properties.Settings.Default.ServerAddress, Properties.Settings.Default.Port);
            }
            TopMost = Properties.Settings.Default.AlwaysOnTop;

            if (Properties.Settings.Default.CheckForUpdates)
            {
                checkForUpdates();
            }
        }

        private void _lobbyControl_HandleCreated(object? sender, EventArgs e)
        {
            //Make sure the lobby control has been visible once, so it's controls are initialized
            tabControl1.TabPages.Remove(_lobbyPage);
            tabControl1.SelectedIndex = 0;
            _lobbyControl.HandleCreated -= _lobbyControl_HandleCreated;
            _lobbyControl.Client = _client;
        }

        private void mainForm_SizeChanged(object? sender, EventArgs e)
        {
            Properties.Settings.Default.MainWindowMaximized = WindowState == FormWindowState.Maximized;
            if (WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.MainWindowSizeX = Width;
                Properties.Settings.Default.MainWindowSizeY = Height;
            }
        }

        private void mainForm_LocationChanged(object? sender, EventArgs e)
        {
            //We don't care to save the position when window is maximized. Only save window mode positions in normal mode
            if (WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.MainWindowPositionX = Location.X;
                Properties.Settings.Default.MainWindowPositionY = Location.Y;
            }
        }

        private void removeClientListeners(Client? client)
        {
            if (client == null)
                return;

            client.Connected -= client_Connected;
            client.Disconnected -= client_Disconnected;
            client.OnRoomChanged -= client_RoomChanged;
            client.RemoveListener<ServerJoinRoomAccepted>(joinRoomAccepted);
            client.RemoveListener<ServerJoinRoomDenied>(joinRoomDenied);
        }

        private void server_OnStatus(object? sender, StringEventArgs e)
        {
            _consoleControl.PrintToConsole(e.Message, Color.Orange);
        }

        private void server_OnError(object? sender, StringEventArgs e)
        {
            _consoleControl.PrintToConsole(e.Message, Color.Red);
        }

        private async void checkForUpdates()
        {
            _hasCheckedUpdates = true;
            var v = Assembly.GetExecutingAssembly().GetName().Version;
            var updater = new GitHubVersionChecker(v);
            var newerVersion = await updater.CheckForNewerVersionAsync();
            if (newerVersion.HasValue)
            {
                if (MessageBox.Show($"Version {newerVersion.Value.Tag_Name} of Bingus is now available! Open download page?", $"{Application.ProductName} - Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    openBrowser(newerVersion.Value.Html_Url);
                }
            }
        }

        private void openBrowser(string url)
        {
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void updateButtonAvailability()
        {
            if (!FormReady)
                return;
            BeginInvoke(new Action(() =>
            {
                bool connected = _client?.IsConnected == true;
                var connectingOrConnected = _connecting || connected;
                _connectButton.Visible = !connectingOrConnected;
                _disconnectButton.Visible = connectingOrConnected;

                toolStripSeparator1.Visible = !connected;

                bool inRoom = _client?.Room != null;
                _createLobbyButton.Visible = !inRoom;
                _joinLobbyButton.Visible = !inRoom;
                _leaveRoomButton.Visible = inRoom;
                _changeTeamButton.Visible = inRoom;

                _createLobbyButton.Enabled = connected;
                _joinLobbyButton.Enabled = connected;
                _leaveRoomButton.Enabled = connected;
                _changeTeamButton.Enabled = connected;
            }));
        }
    }
}