﻿using Bingus.Settings;
using BingusCommon;
using Neto.Shared;

namespace Bingus.UI
{
    public partial class CreateLobbyForm : Form
    {
        private readonly Client _client;
        private GameSettingsControl? _gameSettingsControl;

        private int _initWidth, _initHeight;

        public CreateLobbyForm(Client client, bool create)
        {
            InitializeComponent();
            _initWidth = Width;
            _initHeight = Height;
            _client = client;
            
            if (!create)
            {
                Text = "Join Lobby";
                _lobbySettingsButton.Visible = false;
                Height -= _lobbySettingsButton.Height;
            }

            if (create && client != null)
            {
                client.AddListener<ServerRoomNameSuggestion>(availableRoomNameData);
            }

            initTeamComboBox();
            loadSettings();
            if(create)
                updateSeedLabel();
        }

        private void updateSeedLabel()
        {
            if (_gameSettingsControl != null)
            {
                _seedLabel.Text = $"Seed: {_gameSettingsControl.CurrentSeed}";
                _seedLabel.Visible = _gameSettingsControl.CurrentSeed != 0;
            } 
            else
            {
                _seedLabel.Text = $"Seed: {Properties.Settings.Default.GS_RandomSeed}";
                _seedLabel.Visible = Properties.Settings.Default.GS_RandomSeed != 0;
            }
        }

        public string AdminPassword
        {
            get { return _adminPasswordTextBox.Text; }
            set { _adminPasswordTextBox.Text = value; }
        }

        public string Nickname
        {
            get { return _nicknameTextBox.Text; }
            set { _nicknameTextBox.Text = value; }
        }

        public string RoomName
        {
            get { return _roomNameTextBox.Text; }
            set { _roomNameTextBox.Text = value; }
        }

        public int Team
        {
            get { return _teamComboBox.SelectedIndex - 1; }
            set { _teamComboBox.SelectedIndex = (int)value + 1; }
        }

        private void availableRoomNameData(ClientModel? _, ServerRoomNameSuggestion roomNameData)
        {
            void update() { RoomName = roomNameData.RoomName; };
            if (InvokeRequired)
            {
                BeginInvoke(update);
                return;
            }
            update();
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void _createButton_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                DialogResult = DialogResult.OK;
                saveSettings();
                Close();
            }
        }

        private void CreateLobbyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _client.RemoveListener<ServerRoomNameSuggestion>(availableRoomNameData);
        }

        private void initTeamComboBox()
        {
            for (int i = -1; i < BingoConstants.TeamColors.Length; ++i)
            {
                _teamComboBox.Items.Add(BingoConstants.GetTeamName(i));
            }
            _teamComboBox.SelectedIndex = 0;
            _teamComboBox.SelectedIndexChanged += (o, e) => setPanelColor();
        }

        private void loadSettings()
        {
            Nickname = Properties.Settings.Default.Nickname;
            Team = Properties.Settings.Default.Team;
        }

        private void saveSettings()
        {
            Properties.Settings.Default.Nickname = Nickname;
            Properties.Settings.Default.Team = Team;
            saveGameSettings();
            Properties.Settings.Default.Save();
        }

        private void setPanelColor()
        {
            _colorPanel.BackColor = BingoConstants.GetTeamColor(Team);
        }

        private bool validate()
        {
            if (string.IsNullOrWhiteSpace(_roomNameTextBox.Text))
            {
                errorProvider1.SetError(_roomNameTextBox, "Room name not set");
                return false;
            }
            else
            {
                errorProvider1.SetError(_roomNameTextBox, null);
            }

            if (string.IsNullOrWhiteSpace(_nicknameTextBox.Text))
            {
                errorProvider1.SetError(_nicknameTextBox, "Nickname not set");
                return false;
            }
            else
            {
                errorProvider1.SetError(_nicknameTextBox, null);
            }
            return true;
        }

        private void _lobbySettingsButton_Click(object sender, EventArgs e)
        {
            if (_gameSettingsControl == null)
            {
                createGameSettingsControl();
                loadGameSettings();
            }
            else
            {
                _gameSettingsControl.Visible = !_gameSettingsControl.Visible;
            }

            if (_gameSettingsControl.Visible)
            {
                Width = _gameSettingsControl.Location.X + _gameSettingsControl.Width + 20;
                Height = Math.Max(_initHeight, _gameSettingsControl.Location.Y + _gameSettingsControl.Height);
                _lobbySettingsButton.Text = "Lobby Settings <<";
            }
            else
            {
                Width = _initWidth;
                Height = _initHeight;
                _lobbySettingsButton.Text = "Lobby Settings >>";
            }
        }

        private void createGameSettingsControl()
        {
            var control = new GameSettingsControl();
            control.Location = new Point(Width - 14, 4);
            control.SeedChanged += () => updateSeedLabel();
            Controls.Add(control);
            _gameSettingsControl = control;
        }

        private void loadGameSettings()
        {
            if (_gameSettingsControl != null)
            {
                _gameSettingsControl.Settings = GameSettingsHelper.ReadFromSettings(Properties.Settings.Default);
            }
        }

        private void saveGameSettings()
        {
            if (_gameSettingsControl != null)
            {
                var settings = _gameSettingsControl.Settings;
                GameSettingsHelper.SaveToSettings(settings, Properties.Settings.Default);
            }
        }
    }
}