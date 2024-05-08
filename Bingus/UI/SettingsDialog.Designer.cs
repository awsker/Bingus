namespace Bingus.UI
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
            groupBox7 = new GroupBox();
            label8 = new Label();
            _fontLinkLabel = new LinkLabel();
            _clickIncrementsCountCheckbox = new CheckBox();
            label11 = new Label();
            _outOfFocusClickTextBox = new TextBox();
            groupBox2 = new GroupBox();
            label4 = new Label();
            _bingoMaxXTextBox = new TextBox();
            _bingoNoMaxSizeRadioButton = new RadioButton();
            _bingoCustomMaxSizeRadioButton = new RadioButton();
            label3 = new Label();
            _bingoMaxYTextBox = new TextBox();
            tabPage1 = new TabPage();
            groupBox5 = new GroupBox();
            _hostServerCheckBox = new CheckBox();
            label9 = new Label();
            _portTextBox = new TextBox();
            groupBox8 = new GroupBox();
            _soundCheckBox = new CheckBox();
            _volumeTrackBar = new TrackBar();
            label10 = new Label();
            groupBox3 = new GroupBox();
            label5 = new Label();
            _colorPanel = new Panel();
            _alwaysOnTopCheckbox = new CheckBox();
            tabControl1 = new TabControl();
            panel1.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox2.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_volumeTrackBar).BeginInit();
            groupBox3.SuspendLayout();
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
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Controls.Add(groupBox7);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(513, 348);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Bingo Board";
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
            groupBox7.TabIndex = 12;
            groupBox7.TabStop = false;
            groupBox7.Text = "Appearance";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(8, 23);
            label8.Name = "label8";
            label8.Size = new Size(80, 15);
            label8.TabIndex = 17;
            label8.Text = "Font and Size:";
            // 
            // _fontLinkLabel
            // 
            _fontLinkLabel.AutoSize = true;
            _fontLinkLabel.Font = new Font("Lucida Sans Unicode", 12F, FontStyle.Regular, GraphicsUnit.Point);
            _fontLinkLabel.Location = new Point(8, 43);
            _fontLinkLabel.Name = "_fontLinkLabel";
            _fontLinkLabel.Size = new Size(90, 20);
            _fontLinkLabel.TabIndex = 13;
            _fontLinkLabel.TabStop = true;
            _fontLinkLabel.Text = "FontName";
            _fontLinkLabel.LinkClicked += _fontLinkLabel_LinkClicked;
            // 
            // _clickIncrementsCountCheckbox
            // 
            _clickIncrementsCountCheckbox.Location = new Point(9, 71);
            _clickIncrementsCountCheckbox.Name = "_clickIncrementsCountCheckbox";
            _clickIncrementsCountCheckbox.Size = new Size(219, 54);
            _clickIncrementsCountCheckbox.TabIndex = 14;
            _clickIncrementsCountCheckbox.Text = "Clicking on \"Counted\" square increments the counter instead of marking the square";
            _clickIncrementsCountCheckbox.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(9, 134);
            label11.Name = "label11";
            label11.Size = new Size(186, 15);
            label11.TabIndex = 20;
            label11.Text = "Out-of-focus click key (Keyboard)";
            // 
            // _outOfFocusClickTextBox
            // 
            _outOfFocusClickTextBox.Location = new Point(9, 160);
            _outOfFocusClickTextBox.Name = "_outOfFocusClickTextBox";
            _outOfFocusClickTextBox.ReadOnly = true;
            _outOfFocusClickTextBox.Size = new Size(105, 23);
            _outOfFocusClickTextBox.TabIndex = 15;
            _outOfFocusClickTextBox.Enter += _outOfFocusClickTextBox_Enter;
            _outOfFocusClickTextBox.KeyDown += _outOfFocusClickTextBox_KeyDown;
            _outOfFocusClickTextBox.Leave += _outOfFocusClickTextBox_Leave;
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
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Bingo Board Max Size";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 75);
            label4.Name = "label4";
            label4.Size = new Size(17, 15);
            label4.TabIndex = 7;
            label4.Text = "X:";
            // 
            // _bingoMaxXTextBox
            // 
            _bingoMaxXTextBox.Location = new Point(30, 72);
            _bingoMaxXTextBox.Name = "_bingoMaxXTextBox";
            _bingoMaxXTextBox.Size = new Size(54, 23);
            _bingoMaxXTextBox.TabIndex = 10;
            // 
            // _bingoNoMaxSizeRadioButton
            // 
            _bingoNoMaxSizeRadioButton.AutoSize = true;
            _bingoNoMaxSizeRadioButton.Location = new Point(9, 22);
            _bingoNoMaxSizeRadioButton.Name = "_bingoNoMaxSizeRadioButton";
            _bingoNoMaxSizeRadioButton.Size = new Size(122, 19);
            _bingoNoMaxSizeRadioButton.TabIndex = 8;
            _bingoNoMaxSizeRadioButton.TabStop = true;
            _bingoNoMaxSizeRadioButton.Text = "No Maximum Size";
            _bingoNoMaxSizeRadioButton.UseVisualStyleBackColor = true;
            // 
            // _bingoCustomMaxSizeRadioButton
            // 
            _bingoCustomMaxSizeRadioButton.AutoSize = true;
            _bingoCustomMaxSizeRadioButton.Location = new Point(9, 46);
            _bingoCustomMaxSizeRadioButton.Name = "_bingoCustomMaxSizeRadioButton";
            _bingoCustomMaxSizeRadioButton.Size = new Size(116, 19);
            _bingoCustomMaxSizeRadioButton.TabIndex = 9;
            _bingoCustomMaxSizeRadioButton.TabStop = true;
            _bingoCustomMaxSizeRadioButton.Text = "Custom Max Size";
            _bingoCustomMaxSizeRadioButton.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(94, 75);
            label3.Name = "label3";
            label3.Size = new Size(17, 15);
            label3.TabIndex = 11;
            label3.Text = "Y:";
            // 
            // _bingoMaxYTextBox
            // 
            _bingoMaxYTextBox.Location = new Point(117, 72);
            _bingoMaxYTextBox.Name = "_bingoMaxYTextBox";
            _bingoMaxYTextBox.Size = new Size(54, 23);
            _bingoMaxYTextBox.TabIndex = 11;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = SystemColors.Control;
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
            // groupBox5
            // 
            groupBox5.Controls.Add(_portTextBox);
            groupBox5.Controls.Add(label9);
            groupBox5.Controls.Add(_hostServerCheckBox);
            groupBox5.Location = new Point(8, 229);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(240, 98);
            groupBox5.TabIndex = 27;
            groupBox5.TabStop = false;
            groupBox5.Text = "Server Hosting";
            // 
            // _hostServerCheckBox
            // 
            _hostServerCheckBox.AutoSize = true;
            _hostServerCheckBox.Location = new Point(12, 28);
            _hostServerCheckBox.Name = "_hostServerCheckBox";
            _hostServerCheckBox.Size = new Size(184, 19);
            _hostServerCheckBox.TabIndex = 28;
            _hostServerCheckBox.Text = "Host a bingo server on launch";
            _hostServerCheckBox.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 62);
            label9.Name = "label9";
            label9.Size = new Size(32, 15);
            label9.TabIndex = 27;
            label9.Text = "Port:";
            // 
            // _portTextBox
            // 
            _portTextBox.Location = new Point(50, 59);
            _portTextBox.Name = "_portTextBox";
            _portTextBox.Size = new Size(61, 23);
            _portTextBox.TabIndex = 29;
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(label10);
            groupBox8.Controls.Add(_volumeTrackBar);
            groupBox8.Controls.Add(_soundCheckBox);
            groupBox8.Location = new Point(8, 102);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(240, 121);
            groupBox8.TabIndex = 4;
            groupBox8.TabStop = false;
            groupBox8.Text = "Sounds";
            // 
            // _soundCheckBox
            // 
            _soundCheckBox.AutoSize = true;
            _soundCheckBox.Location = new Point(12, 25);
            _soundCheckBox.Name = "_soundCheckBox";
            _soundCheckBox.Size = new Size(128, 19);
            _soundCheckBox.TabIndex = 5;
            _soundCheckBox.Text = "Enable alert sounds";
            _soundCheckBox.UseVisualStyleBackColor = true;
            // 
            // _volumeTrackBar
            // 
            _volumeTrackBar.AutoSize = false;
            _volumeTrackBar.Location = new Point(6, 73);
            _volumeTrackBar.Name = "_volumeTrackBar";
            _volumeTrackBar.Size = new Size(228, 35);
            _volumeTrackBar.TabIndex = 6;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 52);
            label10.Name = "label10";
            label10.Size = new Size(47, 15);
            label10.TabIndex = 31;
            label10.Text = "Volume";
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
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 26);
            label5.Name = "label5";
            label5.Size = new Size(153, 15);
            label5.TabIndex = 2;
            label5.Text = "Window Background Color:";
            // 
            // _colorPanel
            // 
            _colorPanel.BorderStyle = BorderStyle.FixedSingle;
            _colorPanel.Location = new Point(168, 22);
            _colorPanel.Name = "_colorPanel";
            _colorPanel.Size = new Size(25, 25);
            _colorPanel.TabIndex = 35;
            _colorPanel.Click += _colorPanel_Click;
            // 
            // _alwaysOnTopCheckbox
            // 
            _alwaysOnTopCheckbox.AutoSize = true;
            _alwaysOnTopCheckbox.Location = new Point(12, 58);
            _alwaysOnTopCheckbox.Name = "_alwaysOnTopCheckbox";
            _alwaysOnTopCheckbox.Size = new Size(102, 19);
            _alwaysOnTopCheckbox.TabIndex = 3;
            _alwaysOnTopCheckbox.Text = "Always on Top";
            _alwaysOnTopCheckbox.UseVisualStyleBackColor = true;
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
            panel1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            tabPage1.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_volumeTrackBar).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
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
    }
}