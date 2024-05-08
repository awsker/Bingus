namespace Bingus.UI
{
    public partial class SettingsDialog : Form
    {
        private const float fontSize = 12f;

        private Keys _outOfFocusKey;
        private bool _rebindingKey = false;

        public SettingsDialog()
        {
            InitializeComponent();
            initControls();
        }

        private void _colorPanel_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = _colorPanel.BackColor;
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                _colorPanel.BackColor = colorDialog1.Color;
            }
        }

        private void _fontLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var dialog = new FontDialog();
                dialog.FontMustExist = true;
                dialog.Font = _fontLinkLabel.Font;
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    _fontLinkLabel.Font = dialog.Font;
                    _fontLinkLabel.Text = _fontLinkLabel.Font.FontFamily.Name;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _okButton_Click(object sender, EventArgs e)
        {
            if (saveSettings())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void initControls()
        {
            _bingoNoMaxSizeRadioButton.Checked = !Properties.Settings.Default.BingoBoardMaximumSize;
            _bingoCustomMaxSizeRadioButton.Checked = Properties.Settings.Default.BingoBoardMaximumSize;

            _bingoMaxXTextBox.Text = Properties.Settings.Default.BingoMaxSizeX.ToString();
            _bingoMaxYTextBox.Text = Properties.Settings.Default.BingoMaxSizeY.ToString();

            _fontLinkLabel.Font = MainForm.GetFontFromSettings(_fontLinkLabel.Font, fontSize);
            _fontLinkLabel.Text = _fontLinkLabel.Font.FontFamily.Name;

            _outOfFocusKey = (Keys)Properties.Settings.Default.ClickHotkey;

            _hostServerCheckBox.Checked = Properties.Settings.Default.HostServerOnLaunch;
            _portTextBox.Text = Properties.Settings.Default.Port.ToString();

            _bingoCustomMaxSizeRadioButton.CheckedChanged += (_, _) => updateMaxSizeEnable();

            _clickIncrementsCountCheckbox.Checked = Properties.Settings.Default.ClickIncrementsCountedSquares;

            _soundCheckBox.Checked = Properties.Settings.Default.PlaySounds;
            _volumeTrackBar.Value = Convert.ToInt32(Properties.Settings.Default.SoundVolume / 10f);

            _colorPanel.BackColor = Properties.Settings.Default.ControlBackColor;
            _alwaysOnTopCheckbox.Checked = Properties.Settings.Default.AlwaysOnTop;

            updateMaxSizeEnable();
            updateOutOfFocusText();
        }

        private void updateMaxSizeEnable()
        {
            _bingoMaxXTextBox.Enabled = _bingoCustomMaxSizeRadioButton.Checked;
            _bingoMaxYTextBox.Enabled = _bingoCustomMaxSizeRadioButton.Checked;
        }

        private bool saveSettings()
        {
            Properties.Settings.Default.BingoBoardMaximumSize = _bingoCustomMaxSizeRadioButton.Checked;
            if (int.TryParse(_bingoMaxXTextBox.Text, out var x))
            {
                Properties.Settings.Default.BingoMaxSizeX = x;
            }
            else
            {
                //Invalid x size
                return false;
            }
            if (int.TryParse(_bingoMaxYTextBox.Text, out var y))
            {
                Properties.Settings.Default.BingoMaxSizeY = y;
            }
            else
            {
                //Invalid y size
                return false;
            }

            Properties.Settings.Default.ControlBackColor = _colorPanel.BackColor;

            Properties.Settings.Default.BingoFont = _fontLinkLabel.Font.FontFamily.Name;
            Properties.Settings.Default.BingoFontStyle = (int)_fontLinkLabel.Font.Style;
            Properties.Settings.Default.BingoFontSize = _fontLinkLabel.Font.Size;

            Properties.Settings.Default.HostServerOnLaunch = _hostServerCheckBox.Checked;
            if (int.TryParse(_portTextBox.Text, out int port))
            {
                Properties.Settings.Default.Port = port;
            }
            else
            {
                //Invalid port
                return false;
            }

            Properties.Settings.Default.ClickIncrementsCountedSquares = _clickIncrementsCountCheckbox.Checked;

            Properties.Settings.Default.PlaySounds = _soundCheckBox.Checked;
            Properties.Settings.Default.SoundVolume = Math.Clamp(_volumeTrackBar.Value * 10, 0, 100);

            Properties.Settings.Default.ClickHotkey = (int)_outOfFocusKey;

            Properties.Settings.Default.AlwaysOnTop = _alwaysOnTopCheckbox.Checked;

            Properties.Settings.Default.Save();
            return true;
        }

        private void _outOfFocusClickTextBox_Enter(object sender, EventArgs e)
        {
            _rebindingKey = true;
            updateOutOfFocusText();
        }

        private void _outOfFocusClickTextBox_Leave(object sender, EventArgs e)
        {
            _rebindingKey = false;
            updateOutOfFocusText();
        }

        private void _outOfFocusClickTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (_rebindingKey)
            {
                _outOfFocusKey = e.KeyCode == Keys.Escape ? Keys.None : e.KeyCode;
                _rebindingKey = false;
                updateOutOfFocusText();
                label11.Focus();
            }
        }

        private void updateOutOfFocusText()
        {
            if (_rebindingKey)
            {
                _outOfFocusClickTextBox.Text = "Press a key...";
            }
            else
            {
                _outOfFocusClickTextBox.Text = _outOfFocusKey.ToString().ToUpper();
            }
        }


    }
}