﻿namespace Bingus.UI
{
    partial class SettingsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _okButton = new Button();
            _cancelButton = new Button();
            colorDialog1 = new ColorDialog();
            panel1 = new Panel();
            tabPage2 = new TabPage();
            groupBox1 = new GroupBox();
            panel2 = new Panel();
            label2 = new Label();
            _delayMatchEventsTextBox = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            _bingoMaxYTextBox = new TextBox();
            label3 = new Label();
            _bingoCustomMaxSizeRadioButton = new RadioButton();
            _bingoNoMaxSizeRadioButton = new RadioButton();
            _bingoMaxXTextBox = new TextBox();
            label4 = new Label();
            groupBox7 = new GroupBox();
            _outOfFocusClickTextBox = new TextBox();
            label11 = new Label();
            _clickIncrementsCountCheckbox = new CheckBox();
            _fontLinkLabel = new LinkLabel();
            label8 = new Label();
            tabPage1 = new TabPage();
            groupBox4 = new GroupBox();
            _checkUpdatesCheckBox = new CheckBox();
            groupBox3 = new GroupBox();
            _alwaysOnTopCheckbox = new CheckBox();
            _colorPanel = new Panel();
            label5 = new Label();
            groupBox8 = new GroupBox();
            _testSoundButton = new Button();
            _soundOutputDeviceComboBox = new ComboBox();
            label6 = new Label();
            label10 = new Label();
            _volumeTrackBar = new TrackBar();
            _soundCheckBox = new CheckBox();
            groupBox5 = new GroupBox();
            _portTextBox = new TextBox();
            label9 = new Label();
            _hostServerCheckBox = new CheckBox();
            tabControl1 = new TabControl();
            panel1.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox7.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_volumeTrackBar).BeginInit();
            groupBox5.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // _okButton
            // 
            _okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _okButton.Location = new Point(361, 3);
            _okButton.Name = "_okButton";
            _okButton.Size = new Size(75, 23);
            _okButton.TabIndex = 12;
            _okButton.Text = "OK";
            _okButton.UseVisualStyleBackColor = true;
            _okButton.Click += _okButton_Click;
            // 
            // _cancelButton
            // 
            _cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _cancelButton.Location = new Point(442, 3);
            _cancelButton.Name = "_cancelButton";
            _cancelButton.Size = new Size(75, 23);
            _cancelButton.TabIndex = 13;
            _cancelButton.Text = "Cancel";
            _cancelButton.UseVisualStyleBackColor = true;
            _cancelButton.Click += _cancelButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(_okButton);
            panel1.Controls.Add(_cancelButton);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 376);
            panel1.Name = "panel1";
            panel1.Size = new Size(521, 29);
            panel1.TabIndex = 34;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = SystemColors.Control;
            tabPage2.Controls.Add(groupBox1);
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Controls.Add(groupBox7);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(513, 348);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Bingo Board";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(panel2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(254, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(240, 107);
            groupBox1.TabIndex = 31;
            groupBox1.TabStop = false;
            groupBox1.Text = "Spectator Settings";
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Controls.Add(_delayMatchEventsTextBox);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 74);
            panel2.Name = "panel2";
            panel2.Size = new Size(234, 30);
            panel2.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(90, 6);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 34;
            label2.Text = "milliseconds";
            // 
            // _delayMatchEventsTextBox
            // 
            _delayMatchEventsTextBox.Location = new Point(3, 3);
            _delayMatchEventsTextBox.MaximumSize = new Size(100, 0);
            _delayMatchEventsTextBox.Name = "_delayMatchEventsTextBox";
            _delayMatchEventsTextBox.Size = new Size(81, 23);
            _delayMatchEventsTextBox.TabIndex = 33;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(3, 19);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 3, 0, 0);
            label1.Size = new Size(234, 55);
            label1.TabIndex = 32;
            label1.Text = "When spectating, delay all match events (this includes square checks, counters, match status changes, timer etc.):";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(_bingoMaxYTextBox);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(_bingoCustomMaxSizeRadioButton);
            groupBox2.Controls.Add(_bingoNoMaxSizeRadioButton);
            groupBox2.Controls.Add(_bingoMaxXTextBox);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(8, 6);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(240, 107);
            groupBox2.TabIndex = 18;
            groupBox2.TabStop = false;
            groupBox2.Text = "Bingo Board Max Size";
            // 
            // _bingoMaxYTextBox
            // 
            _bingoMaxYTextBox.Location = new Point(117, 72);
            _bingoMaxYTextBox.Name = "_bingoMaxYTextBox";
            _bingoMaxYTextBox.Size = new Size(54, 23);
            _bingoMaxYTextBox.TabIndex = 24;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(94, 75);
            label3.Name = "label3";
            label3.Size = new Size(17, 15);
            label3.TabIndex = 23;
            label3.Text = "Y:";
            // 
            // _bingoCustomMaxSizeRadioButton
            // 
            _bingoCustomMaxSizeRadioButton.AutoSize = true;
            _bingoCustomMaxSizeRadioButton.Location = new Point(9, 46);
            _bingoCustomMaxSizeRadioButton.Name = "_bingoCustomMaxSizeRadioButton";
            _bingoCustomMaxSizeRadioButton.Size = new Size(116, 19);
            _bingoCustomMaxSizeRadioButton.TabIndex = 20;
            _bingoCustomMaxSizeRadioButton.TabStop = true;
            _bingoCustomMaxSizeRadioButton.Text = "Custom Max Size";
            _bingoCustomMaxSizeRadioButton.UseVisualStyleBackColor = false;
            // 
            // _bingoNoMaxSizeRadioButton
            // 
            _bingoNoMaxSizeRadioButton.AutoSize = true;
            _bingoNoMaxSizeRadioButton.Location = new Point(9, 22);
            _bingoNoMaxSizeRadioButton.Name = "_bingoNoMaxSizeRadioButton";
            _bingoNoMaxSizeRadioButton.Size = new Size(122, 19);
            _bingoNoMaxSizeRadioButton.TabIndex = 19;
            _bingoNoMaxSizeRadioButton.TabStop = true;
            _bingoNoMaxSizeRadioButton.Text = "No Maximum Size";
            _bingoNoMaxSizeRadioButton.UseVisualStyleBackColor = true;
            // 
            // _bingoMaxXTextBox
            // 
            _bingoMaxXTextBox.Location = new Point(30, 72);
            _bingoMaxXTextBox.Name = "_bingoMaxXTextBox";
            _bingoMaxXTextBox.Size = new Size(54, 23);
            _bingoMaxXTextBox.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 75);
            label4.Name = "label4";
            label4.Size = new Size(17, 15);
            label4.TabIndex = 21;
            label4.Text = "X:";
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(_outOfFocusClickTextBox);
            groupBox7.Controls.Add(label11);
            groupBox7.Controls.Add(_clickIncrementsCountCheckbox);
            groupBox7.Controls.Add(_fontLinkLabel);
            groupBox7.Controls.Add(label8);
            groupBox7.Location = new Point(8, 119);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(240, 195);
            groupBox7.TabIndex = 25;
            groupBox7.TabStop = false;
            groupBox7.Text = "Appearance";
            // 
            // _outOfFocusClickTextBox
            // 
            _outOfFocusClickTextBox.Location = new Point(9, 160);
            _outOfFocusClickTextBox.Name = "_outOfFocusClickTextBox";
            _outOfFocusClickTextBox.ReadOnly = true;
            _outOfFocusClickTextBox.Size = new Size(105, 23);
            _outOfFocusClickTextBox.TabIndex = 30;
            _outOfFocusClickTextBox.Enter += _outOfFocusClickTextBox_Enter;
            _outOfFocusClickTextBox.KeyDown += _outOfFocusClickTextBox_KeyDown;
            _outOfFocusClickTextBox.Leave += _outOfFocusClickTextBox_Leave;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(9, 134);
            label11.Name = "label11";
            label11.Size = new Size(186, 15);
            label11.TabIndex = 29;
            label11.Text = "Out-of-focus click key (Keyboard)";
            // 
            // _clickIncrementsCountCheckbox
            // 
            _clickIncrementsCountCheckbox.Location = new Point(9, 71);
            _clickIncrementsCountCheckbox.Name = "_clickIncrementsCountCheckbox";
            _clickIncrementsCountCheckbox.Size = new Size(219, 54);
            _clickIncrementsCountCheckbox.TabIndex = 28;
            _clickIncrementsCountCheckbox.Text = "Clicking on \"Counted\" square increments the counter instead of marking the square";
            _clickIncrementsCountCheckbox.UseVisualStyleBackColor = true;
            // 
            // _fontLinkLabel
            // 
            _fontLinkLabel.AutoSize = true;
            _fontLinkLabel.Font = new Font("Lucida Sans Unicode", 12F, FontStyle.Regular, GraphicsUnit.Point);
            _fontLinkLabel.Location = new Point(8, 43);
            _fontLinkLabel.Name = "_fontLinkLabel";
            _fontLinkLabel.Size = new Size(90, 20);
            _fontLinkLabel.TabIndex = 27;
            _fontLinkLabel.TabStop = true;
            _fontLinkLabel.Text = "FontName";
            _fontLinkLabel.LinkClicked += _fontLinkLabel_LinkClicked;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(8, 23);
            label8.Name = "label8";
            label8.Size = new Size(80, 15);
            label8.TabIndex = 26;
            label8.Text = "Font and Size:";
            // 
            // tabPage1
            // 
            tabPage1.BackColor = SystemColors.Control;
            tabPage1.Controls.Add(groupBox4);
            tabPage1.Controls.Add(groupBox3);
            tabPage1.Controls.Add(groupBox8);
            tabPage1.Controls.Add(groupBox5);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(513, 348);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "General";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(_checkUpdatesCheckBox);
            groupBox4.Location = new Point(254, 102);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(240, 59);
            groupBox4.TabIndex = 16;
            groupBox4.TabStop = false;
            groupBox4.Text = "Application Updates";
            // 
            // _checkUpdatesCheckBox
            // 
            _checkUpdatesCheckBox.AutoSize = true;
            _checkUpdatesCheckBox.Location = new Point(12, 26);
            _checkUpdatesCheckBox.Name = "_checkUpdatesCheckBox";
            _checkUpdatesCheckBox.Size = new Size(179, 19);
            _checkUpdatesCheckBox.TabIndex = 17;
            _checkUpdatesCheckBox.Text = "Check for updates on startup";
            _checkUpdatesCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(_alwaysOnTopCheckbox);
            groupBox3.Controls.Add(_colorPanel);
            groupBox3.Controls.Add(label5);
            groupBox3.Location = new Point(8, 6);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(240, 90);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "Appearance";
            // 
            // _alwaysOnTopCheckbox
            // 
            _alwaysOnTopCheckbox.AutoSize = true;
            _alwaysOnTopCheckbox.Location = new Point(12, 58);
            _alwaysOnTopCheckbox.Name = "_alwaysOnTopCheckbox";
            _alwaysOnTopCheckbox.Size = new Size(102, 19);
            _alwaysOnTopCheckbox.TabIndex = 4;
            _alwaysOnTopCheckbox.Text = "Always on Top";
            _alwaysOnTopCheckbox.UseVisualStyleBackColor = true;
            // 
            // _colorPanel
            // 
            _colorPanel.BorderStyle = BorderStyle.FixedSingle;
            _colorPanel.Location = new Point(168, 22);
            _colorPanel.Name = "_colorPanel";
            _colorPanel.Size = new Size(25, 25);
            _colorPanel.TabIndex = 3;
            _colorPanel.Click += _colorPanel_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 26);
            label5.Name = "label5";
            label5.Size = new Size(153, 15);
            label5.TabIndex = 2;
            label5.Text = "Window Background Color:";
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(_testSoundButton);
            groupBox8.Controls.Add(_soundOutputDeviceComboBox);
            groupBox8.Controls.Add(label6);
            groupBox8.Controls.Add(label10);
            groupBox8.Controls.Add(_volumeTrackBar);
            groupBox8.Controls.Add(_soundCheckBox);
            groupBox8.Location = new Point(8, 102);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(240, 198);
            groupBox8.TabIndex = 5;
            groupBox8.TabStop = false;
            groupBox8.Text = "Sounds";
            // 
            // _testSoundButton
            // 
            _testSoundButton.Location = new Point(7, 163);
            _testSoundButton.Name = "_testSoundButton";
            _testSoundButton.Size = new Size(107, 23);
            _testSoundButton.TabIndex = 11;
            _testSoundButton.Text = "Play Test Sfx";
            _testSoundButton.UseVisualStyleBackColor = true;
            _testSoundButton.Click += _testSoundButton_Click;
            // 
            // _soundOutputDeviceComboBox
            // 
            _soundOutputDeviceComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _soundOutputDeviceComboBox.FormattingEnabled = true;
            _soundOutputDeviceComboBox.Location = new Point(8, 132);
            _soundOutputDeviceComboBox.Name = "_soundOutputDeviceComboBox";
            _soundOutputDeviceComboBox.Size = new Size(225, 23);
            _soundOutputDeviceComboBox.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(9, 111);
            label6.Name = "label6";
            label6.Size = new Size(86, 15);
            label6.TabIndex = 9;
            label6.Text = "Output Device:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 52);
            label10.Name = "label10";
            label10.Size = new Size(47, 15);
            label10.TabIndex = 7;
            label10.Text = "Volume";
            // 
            // _volumeTrackBar
            // 
            _volumeTrackBar.AutoSize = false;
            _volumeTrackBar.Location = new Point(6, 73);
            _volumeTrackBar.Name = "_volumeTrackBar";
            _volumeTrackBar.Size = new Size(228, 35);
            _volumeTrackBar.TabIndex = 8;
            // 
            // _soundCheckBox
            // 
            _soundCheckBox.AutoSize = true;
            _soundCheckBox.Location = new Point(12, 25);
            _soundCheckBox.Name = "_soundCheckBox";
            _soundCheckBox.Size = new Size(128, 19);
            _soundCheckBox.TabIndex = 6;
            _soundCheckBox.Text = "Enable alert sounds";
            _soundCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(_portTextBox);
            groupBox5.Controls.Add(label9);
            groupBox5.Controls.Add(_hostServerCheckBox);
            groupBox5.Location = new Point(254, 6);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(240, 90);
            groupBox5.TabIndex = 12;
            groupBox5.TabStop = false;
            groupBox5.Text = "Server Hosting";
            // 
            // _portTextBox
            // 
            _portTextBox.Location = new Point(50, 55);
            _portTextBox.Name = "_portTextBox";
            _portTextBox.Size = new Size(61, 23);
            _portTextBox.TabIndex = 15;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 58);
            label9.Name = "label9";
            label9.Size = new Size(32, 15);
            label9.TabIndex = 14;
            label9.Text = "Port:";
            // 
            // _hostServerCheckBox
            // 
            _hostServerCheckBox.AutoSize = true;
            _hostServerCheckBox.Location = new Point(12, 28);
            _hostServerCheckBox.Name = "_hostServerCheckBox";
            _hostServerCheckBox.Size = new Size(184, 19);
            _hostServerCheckBox.TabIndex = 13;
            _hostServerCheckBox.Text = "Host a bingo server on launch";
            _hostServerCheckBox.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(521, 376);
            tabControl1.TabIndex = 34;
            // 
            // SettingsDialog
            // 
            AcceptButton = _okButton;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(521, 405);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            Load += SettingsDialog_Load;
            panel1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            tabPage1.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_volumeTrackBar).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button _okButton;
        private Button _cancelButton;
        private ColorDialog colorDialog1;
        private Panel panel1;
        private TabPage tabPage2;
        private GroupBox groupBox2;
        private TextBox _bingoMaxYTextBox;
        private Label label3;
        private RadioButton _bingoCustomMaxSizeRadioButton;
        private RadioButton _bingoNoMaxSizeRadioButton;
        private TextBox _bingoMaxXTextBox;
        private Label label4;
        private GroupBox groupBox7;
        private TextBox _outOfFocusClickTextBox;
        private Label label11;
        private CheckBox _clickIncrementsCountCheckbox;
        private LinkLabel _fontLinkLabel;
        private Label label8;
        private TabPage tabPage1;
        private GroupBox groupBox3;
        private CheckBox _alwaysOnTopCheckbox;
        private Panel _colorPanel;
        private Label label5;
        private GroupBox groupBox8;
        private Label label10;
        private TrackBar _volumeTrackBar;
        private CheckBox _soundCheckBox;
        private GroupBox groupBox5;
        private TextBox _portTextBox;
        private Label label9;
        private CheckBox _hostServerCheckBox;
        private TabControl tabControl1;
        private GroupBox groupBox1;
        private Label label1;
        private Panel panel2;
        private Label label2;
        private TextBox _delayMatchEventsTextBox;
        private GroupBox groupBox4;
        private CheckBox _checkUpdatesCheckBox;
        private Button _testSoundButton;
        private ComboBox _soundOutputDeviceComboBox;
        private Label label6;
    }
}