namespace GeneralUserControl
{
    partial class GeneralConfigUserControl
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tbMenuColorSample = new System.Windows.Forms.TextBox();
            this.tbFunctionColorSample = new System.Windows.Forms.TextBox();
            this.tbLatchColorSample = new System.Windows.Forms.TextBox();
            this.tbBackgroundColorSample = new System.Windows.Forms.TextBox();
            this.bCancel = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.cbEnableSleep = new System.Windows.Forms.CheckBox();
            this.cbEnableUSBComms = new System.Windows.Forms.CheckBox();
            this.cbEnableBeep = new System.Windows.Forms.CheckBox();
            this.tbSleepTimer = new System.Windows.Forms.TextBox();
            this.tbModifier1 = new System.Windows.Forms.TextBox();
            this.tbModifier2 = new System.Windows.Forms.TextBox();
            this.tbModifier3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbButtonLightPinMode = new System.Windows.Forms.TextBox();
            this.tbHelperDelay = new System.Windows.Forms.TextBox();
            this.tbStartupMenu = new System.Windows.Forms.TextBox();
            this.tbButtonLightPin = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Menu Button Color";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Function Button Color";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Latch Color";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Background Color";
            // 
            // tbMenuColorSample
            // 
            this.tbMenuColorSample.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbMenuColorSample.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbMenuColorSample.Location = new System.Drawing.Point(136, 62);
            this.tbMenuColorSample.Name = "tbMenuColorSample";
            this.tbMenuColorSample.ReadOnly = true;
            this.tbMenuColorSample.Size = new System.Drawing.Size(35, 13);
            this.tbMenuColorSample.TabIndex = 8;
            this.tbMenuColorSample.DoubleClick += new System.EventHandler(this.tbMenuColorSample_DoubleClick);
            // 
            // tbFunctionColorSample
            // 
            this.tbFunctionColorSample.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbFunctionColorSample.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbFunctionColorSample.Location = new System.Drawing.Point(136, 87);
            this.tbFunctionColorSample.Name = "tbFunctionColorSample";
            this.tbFunctionColorSample.ReadOnly = true;
            this.tbFunctionColorSample.Size = new System.Drawing.Size(35, 13);
            this.tbFunctionColorSample.TabIndex = 9;
            this.tbFunctionColorSample.Click += new System.EventHandler(this.tbFunctionColorSample_Click);
            // 
            // tbLatchColorSample
            // 
            this.tbLatchColorSample.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbLatchColorSample.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbLatchColorSample.Location = new System.Drawing.Point(136, 112);
            this.tbLatchColorSample.Name = "tbLatchColorSample";
            this.tbLatchColorSample.ReadOnly = true;
            this.tbLatchColorSample.Size = new System.Drawing.Size(35, 13);
            this.tbLatchColorSample.TabIndex = 10;
            this.tbLatchColorSample.Click += new System.EventHandler(this.tbLatchColorSample_Click);
            // 
            // tbBackgroundColorSample
            // 
            this.tbBackgroundColorSample.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbBackgroundColorSample.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbBackgroundColorSample.Location = new System.Drawing.Point(136, 137);
            this.tbBackgroundColorSample.Name = "tbBackgroundColorSample";
            this.tbBackgroundColorSample.ReadOnly = true;
            this.tbBackgroundColorSample.Size = new System.Drawing.Size(35, 13);
            this.tbBackgroundColorSample.TabIndex = 11;
            this.tbBackgroundColorSample.Click += new System.EventHandler(this.tbBackgroundColorSample_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(400, 14);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 17;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(319, 14);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 16;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // cbEnableSleep
            // 
            this.cbEnableSleep.AutoSize = true;
            this.cbEnableSleep.Location = new System.Drawing.Point(17, 161);
            this.cbEnableSleep.Name = "cbEnableSleep";
            this.cbEnableSleep.Size = new System.Drawing.Size(89, 17);
            this.cbEnableSleep.TabIndex = 19;
            this.cbEnableSleep.Text = "Enable Sleep";
            this.cbEnableSleep.UseVisualStyleBackColor = true;
            this.cbEnableSleep.CheckedChanged += new System.EventHandler(this.cbEnableSleep_CheckedChanged);
            // 
            // cbEnableUSBComms
            // 
            this.cbEnableUSBComms.AutoSize = true;
            this.cbEnableUSBComms.Location = new System.Drawing.Point(17, 186);
            this.cbEnableUSBComms.Name = "cbEnableUSBComms";
            this.cbEnableUSBComms.Size = new System.Drawing.Size(121, 17);
            this.cbEnableUSBComms.TabIndex = 20;
            this.cbEnableUSBComms.Text = "Enable USB Comms";
            this.cbEnableUSBComms.UseVisualStyleBackColor = true;
            this.cbEnableUSBComms.CheckedChanged += new System.EventHandler(this.cbEnableUSBComms_CheckedChanged);
            // 
            // cbEnableBeep
            // 
            this.cbEnableBeep.AutoSize = true;
            this.cbEnableBeep.Location = new System.Drawing.Point(17, 211);
            this.cbEnableBeep.Name = "cbEnableBeep";
            this.cbEnableBeep.Size = new System.Drawing.Size(87, 17);
            this.cbEnableBeep.TabIndex = 21;
            this.cbEnableBeep.Text = "Enable Beep";
            this.cbEnableBeep.UseVisualStyleBackColor = true;
            this.cbEnableBeep.CheckedChanged += new System.EventHandler(this.cbEnableBeep_CheckedChanged);
            // 
            // tbSleepTimer
            // 
            this.tbSleepTimer.Location = new System.Drawing.Point(375, 54);
            this.tbSleepTimer.Name = "tbSleepTimer";
            this.tbSleepTimer.Size = new System.Drawing.Size(100, 20);
            this.tbSleepTimer.TabIndex = 22;
            this.tbSleepTimer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSleepTimer_KeyPress);
            this.tbSleepTimer.Leave += new System.EventHandler(this.tbSleepTimer_Leave);
            // 
            // tbModifier1
            // 
            this.tbModifier1.Location = new System.Drawing.Point(375, 79);
            this.tbModifier1.Name = "tbModifier1";
            this.tbModifier1.Size = new System.Drawing.Size(100, 20);
            this.tbModifier1.TabIndex = 23;
            this.tbModifier1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbModifier1_KeyPress);
            this.tbModifier1.Leave += new System.EventHandler(this.tbModifier1_Leave);
            // 
            // tbModifier2
            // 
            this.tbModifier2.Location = new System.Drawing.Point(375, 105);
            this.tbModifier2.Name = "tbModifier2";
            this.tbModifier2.Size = new System.Drawing.Size(100, 20);
            this.tbModifier2.TabIndex = 24;
            this.tbModifier2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbModifier2_KeyPress);
            this.tbModifier2.Leave += new System.EventHandler(this.tbModifier2_Leave);
            // 
            // tbModifier3
            // 
            this.tbModifier3.Location = new System.Drawing.Point(375, 130);
            this.tbModifier3.Name = "tbModifier3";
            this.tbModifier3.Size = new System.Drawing.Size(100, 20);
            this.tbModifier3.TabIndex = 25;
            this.tbModifier3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbModifier3_KeyPress);
            this.tbModifier3.Leave += new System.EventHandler(this.tbModifier3_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(261, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Sleep Timer";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(261, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Modifier 1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(261, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Modifier 2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(261, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Modifier 3";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(261, 161);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Helper Delay";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(261, 186);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Startup Menu";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(261, 211);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "Button Light Pin";
            // 
            // tbButtonLightPinMode
            // 
            this.tbButtonLightPinMode.Location = new System.Drawing.Point(375, 229);
            this.tbButtonLightPinMode.Name = "tbButtonLightPinMode";
            this.tbButtonLightPinMode.Size = new System.Drawing.Size(100, 20);
            this.tbButtonLightPinMode.TabIndex = 37;
            this.tbButtonLightPinMode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbButtonLightPinMode_KeyPress);
            this.tbButtonLightPinMode.Leave += new System.EventHandler(this.tbButtonLightPinMode_Leave);
            // 
            // tbHelperDelay
            // 
            this.tbHelperDelay.Location = new System.Drawing.Point(375, 154);
            this.tbHelperDelay.Name = "tbHelperDelay";
            this.tbHelperDelay.Size = new System.Drawing.Size(100, 20);
            this.tbHelperDelay.TabIndex = 34;
            this.tbHelperDelay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbHelperDelay_KeyPress);
            this.tbHelperDelay.Leave += new System.EventHandler(this.tbHelperDelay_Leave);
            // 
            // tbStartupMenu
            // 
            this.tbStartupMenu.Location = new System.Drawing.Point(375, 179);
            this.tbStartupMenu.Name = "tbStartupMenu";
            this.tbStartupMenu.Size = new System.Drawing.Size(100, 20);
            this.tbStartupMenu.TabIndex = 35;
            this.tbStartupMenu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbStartupMenu_KeyPress);
            this.tbStartupMenu.Leave += new System.EventHandler(this.tbStartupMenu_Leave);
            // 
            // tbButtonLightPin
            // 
            this.tbButtonLightPin.Location = new System.Drawing.Point(375, 204);
            this.tbButtonLightPin.Name = "tbButtonLightPin";
            this.tbButtonLightPin.Size = new System.Drawing.Size(100, 20);
            this.tbButtonLightPin.TabIndex = 36;
            this.tbButtonLightPin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbButtonLightPin_KeyPress);
            this.tbButtonLightPin.Leave += new System.EventHandler(this.tbButtonLightPin_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(261, 236);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 13);
            this.label13.TabIndex = 33;
            this.label13.Text = "Button Light Pin Mode";
            // 
            // GeneralConfigUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbButtonLightPin);
            this.Controls.Add(this.tbStartupMenu);
            this.Controls.Add(this.tbHelperDelay);
            this.Controls.Add(this.tbButtonLightPinMode);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbModifier3);
            this.Controls.Add(this.tbModifier2);
            this.Controls.Add(this.tbModifier1);
            this.Controls.Add(this.tbSleepTimer);
            this.Controls.Add(this.cbEnableBeep);
            this.Controls.Add(this.cbEnableUSBComms);
            this.Controls.Add(this.cbEnableSleep);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.tbBackgroundColorSample);
            this.Controls.Add(this.tbLatchColorSample);
            this.Controls.Add(this.tbFunctionColorSample);
            this.Controls.Add(this.tbMenuColorSample);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "GeneralConfigUserControl";
            this.Size = new System.Drawing.Size(507, 291);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TextBox tbMenuColorSample;
        private System.Windows.Forms.TextBox tbFunctionColorSample;
        private System.Windows.Forms.TextBox tbLatchColorSample;
        private System.Windows.Forms.TextBox tbBackgroundColorSample;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.CheckBox cbEnableSleep;
        private System.Windows.Forms.CheckBox cbEnableUSBComms;
        private System.Windows.Forms.CheckBox cbEnableBeep;
        private System.Windows.Forms.TextBox tbSleepTimer;
        private System.Windows.Forms.TextBox tbModifier1;
        private System.Windows.Forms.TextBox tbModifier2;
        private System.Windows.Forms.TextBox tbModifier3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbButtonLightPinMode;
        private System.Windows.Forms.TextBox tbHelperDelay;
        private System.Windows.Forms.TextBox tbStartupMenu;
        private System.Windows.Forms.TextBox tbButtonLightPin;
    }
}
