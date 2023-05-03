﻿using EldenBingo.Net.DataContainers;
using EldenBingoCommon;

namespace EldenBingo.UI
{
    public partial class CreateLobbyForm : Form
    {
        private readonly Client _client;

        public CreateLobbyForm(Client client, bool create)
        {
            InitializeComponent();
            _client = client;
            if (!create)
                Text = "Join Lobby";

            if(create && client != null)
            {
                client.IncomingData += client_IncomingData;
            }
            initTeamComboBox();
            loadSettings();
            
        }

        public string Nickname
        {
            get { return _nicknameTextBox.Text; }
            set { _nicknameTextBox.Text = value; }
        }

        public int Team
        {
            get { return _teamComboBox.SelectedIndex - 1; }
            set { _teamComboBox.SelectedIndex = (int)value + 1; }
        }


        public string RoomName
        {
            get { return _roomNameTextBox.Text; }
            set { _roomNameTextBox.Text = value; }
        }

        public string AdminPassword
        {
            get { return _adminPasswordTextBox.Text; }
            set { _adminPasswordTextBox.Text = value; }
        }

        private void client_IncomingData(object? sender, ObjectEventArgs e)
        {
            if(e.Object is AvailableRoomNameData d && RoomName == string.Empty)
            {
                RoomName = d.Name;
            }
        }

        private void initTeamComboBox()
        {
            for (int i = -1; i < NetConstants.TeamColors.Length; ++i)
            {
                _teamComboBox.Items.Add(NetConstants.GetTeamName(i));
            }
            _teamComboBox.SelectedIndex = 0;
            _teamComboBox.SelectedIndexChanged += (o, e) => setPanelColor();
        }

        private void setPanelColor()
        {
            _colorPanel.BackColor = NetConstants.GetTeamColor(Team);
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
            Properties.Settings.Default.Save();
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

        private void CreateLobbyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _client.IncomingData -= client_IncomingData;
        }

        private void _createButton_Click(object sender, EventArgs e)
        {
            if(validate())
            {
                DialogResult = DialogResult.OK;
                saveSettings();
                Close();
            }
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
