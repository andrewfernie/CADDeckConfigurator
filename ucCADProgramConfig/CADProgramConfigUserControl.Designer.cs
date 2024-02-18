using System.Windows.Forms;

namespace CADProgramConfigUserControl
{
    partial class CADProgramConfigUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CADProgramConfigUserControl));
            this.cbCADProgram = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbScaleX = new System.Windows.Forms.TextBox();
            this.tbScaleY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbScaleRotate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbScaleZoom = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbXYDeadzone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbRotateDeadzone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbZoomDeadzone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbXYSensitivity = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbRotateSensitivity = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbZoomSensitivity = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbMouseSensitivity = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cbSpacemouseEnable = new System.Windows.Forms.CheckBox();
            this.bCancel = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.cbStartupProgram = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnButton01 = new System.Windows.Forms.Button();
            this.btnButton02 = new System.Windows.Forms.Button();
            this.btnButton03 = new System.Windows.Forms.Button();
            this.btnButton04 = new System.Windows.Forms.Button();
            this.btnButton05 = new System.Windows.Forms.Button();
            this.btnButton10 = new System.Windows.Forms.Button();
            this.btnButton09 = new System.Windows.Forms.Button();
            this.btnButton08 = new System.Windows.Forms.Button();
            this.btnButton07 = new System.Windows.Forms.Button();
            this.btnButton06 = new System.Windows.Forms.Button();
            this.btnButton00 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.tbButtonName = new System.Windows.Forms.TextBox();
            this.pbCaptureKeystroke = new System.Windows.Forms.Button();
            this.lButton_2 = new System.Windows.Forms.Label();
            this.lButton_1 = new System.Windows.Forms.Label();
            this.lButton_0 = new System.Windows.Forms.Label();
            this.lButtonValue = new System.Windows.Forms.Label();
            this.lButtonAction = new System.Windows.Forms.Label();
            this.cbButtonValue0 = new System.Windows.Forms.ComboBox();
            this.cbButtonAction0 = new System.Windows.Forms.ComboBox();
            this.cbButtonValue1 = new System.Windows.Forms.ComboBox();
            this.cbButtonAction1 = new System.Windows.Forms.ComboBox();
            this.cbButtonValue2 = new System.Windows.Forms.ComboBox();
            this.cbButtonAction2 = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbButtonDescription = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbCADProgram
            // 
            this.cbCADProgram.FormattingEnabled = true;
            this.cbCADProgram.Location = new System.Drawing.Point(93, 25);
            this.cbCADProgram.Name = "cbCADProgram";
            this.cbCADProgram.Size = new System.Drawing.Size(121, 21);
            this.cbCADProgram.TabIndex = 5;
            this.cbCADProgram.SelectedIndexChanged += new System.EventHandler(this.cbCADProgram_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "CAD Program";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::CADProgramConfigUserControl.Properties.Resources.ButtonLayout10;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(254, 79);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 243);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "X Scale";
            // 
            // tbScaleX
            // 
            this.tbScaleX.Location = new System.Drawing.Point(90, 139);
            this.tbScaleX.Name = "tbScaleX";
            this.tbScaleX.Size = new System.Drawing.Size(100, 20);
            this.tbScaleX.TabIndex = 18;
            this.tbScaleX.Leave += new System.EventHandler(this.tbScaleX_Leave);
            // 
            // tbScaleY
            // 
            this.tbScaleY.Location = new System.Drawing.Point(89, 164);
            this.tbScaleY.Name = "tbScaleY";
            this.tbScaleY.Size = new System.Drawing.Size(100, 20);
            this.tbScaleY.TabIndex = 20;
            this.tbScaleY.Leave += new System.EventHandler(this.tbScaleY_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Y Scale";
            // 
            // tbScaleRotate
            // 
            this.tbScaleRotate.Location = new System.Drawing.Point(90, 239);
            this.tbScaleRotate.Name = "tbScaleRotate";
            this.tbScaleRotate.Size = new System.Drawing.Size(100, 20);
            this.tbScaleRotate.TabIndex = 22;
            this.tbScaleRotate.Leave += new System.EventHandler(this.tbScaleRotate_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Rotate Scale";
            // 
            // tbScaleZoom
            // 
            this.tbScaleZoom.Location = new System.Drawing.Point(90, 314);
            this.tbScaleZoom.Name = "tbScaleZoom";
            this.tbScaleZoom.Size = new System.Drawing.Size(100, 20);
            this.tbScaleZoom.TabIndex = 24;
            this.tbScaleZoom.Leave += new System.EventHandler(this.tbScaleZoom_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 320);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Zoom Scale";
            // 
            // tbXYDeadzone
            // 
            this.tbXYDeadzone.Location = new System.Drawing.Point(90, 189);
            this.tbXYDeadzone.Name = "tbXYDeadzone";
            this.tbXYDeadzone.Size = new System.Drawing.Size(100, 20);
            this.tbXYDeadzone.TabIndex = 26;
            this.tbXYDeadzone.Leave += new System.EventHandler(this.tbXYDeadzone_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "X-Y Deadzone";
            // 
            // tbRotateDeadzone
            // 
            this.tbRotateDeadzone.Location = new System.Drawing.Point(90, 264);
            this.tbRotateDeadzone.Name = "tbRotateDeadzone";
            this.tbRotateDeadzone.Size = new System.Drawing.Size(100, 20);
            this.tbRotateDeadzone.TabIndex = 28;
            this.tbRotateDeadzone.Leave += new System.EventHandler(this.tbRotateDeadzone_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 270);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Rotate Deadzone";
            // 
            // tbZoomDeadzone
            // 
            this.tbZoomDeadzone.Location = new System.Drawing.Point(90, 339);
            this.tbZoomDeadzone.Name = "tbZoomDeadzone";
            this.tbZoomDeadzone.Size = new System.Drawing.Size(100, 20);
            this.tbZoomDeadzone.TabIndex = 30;
            this.tbZoomDeadzone.Leave += new System.EventHandler(this.tbZoomDeadzone_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 345);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Zoom Deadzone";
            // 
            // tbXYSensitivity
            // 
            this.tbXYSensitivity.Location = new System.Drawing.Point(90, 214);
            this.tbXYSensitivity.Name = "tbXYSensitivity";
            this.tbXYSensitivity.Size = new System.Drawing.Size(100, 20);
            this.tbXYSensitivity.TabIndex = 32;
            this.tbXYSensitivity.Leave += new System.EventHandler(this.tbXYSensitivity_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 220);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "X-Y Sensitivity";
            // 
            // tbRotateSensitivity
            // 
            this.tbRotateSensitivity.Location = new System.Drawing.Point(90, 289);
            this.tbRotateSensitivity.Name = "tbRotateSensitivity";
            this.tbRotateSensitivity.Size = new System.Drawing.Size(100, 20);
            this.tbRotateSensitivity.TabIndex = 34;
            this.tbRotateSensitivity.Leave += new System.EventHandler(this.tbRotateSensitivity_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 295);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "Rotate Sensitivity";
            // 
            // tbZoomSensitivity
            // 
            this.tbZoomSensitivity.Location = new System.Drawing.Point(89, 364);
            this.tbZoomSensitivity.Name = "tbZoomSensitivity";
            this.tbZoomSensitivity.Size = new System.Drawing.Size(100, 20);
            this.tbZoomSensitivity.TabIndex = 36;
            this.tbZoomSensitivity.Leave += new System.EventHandler(this.tbZoomSensitivity_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(2, 370);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 13);
            this.label11.TabIndex = 35;
            this.label11.Text = "Zoom Sensitivity";
            // 
            // tbMouseSensitivity
            // 
            this.tbMouseSensitivity.Location = new System.Drawing.Point(89, 389);
            this.tbMouseSensitivity.Name = "tbMouseSensitivity";
            this.tbMouseSensitivity.Size = new System.Drawing.Size(100, 20);
            this.tbMouseSensitivity.TabIndex = 38;
            this.tbMouseSensitivity.Leave += new System.EventHandler(this.tbMouseSensitivity_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(2, 395);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 13);
            this.label12.TabIndex = 37;
            this.label12.Text = "Mouse Sensitivity";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(0, 120);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 13);
            this.label13.TabIndex = 39;
            this.label13.Text = "Startup Program";
            // 
            // cbSpacemouseEnable
            // 
            this.cbSpacemouseEnable.AutoSize = true;
            this.cbSpacemouseEnable.Location = new System.Drawing.Point(6, 445);
            this.cbSpacemouseEnable.Name = "cbSpacemouseEnable";
            this.cbSpacemouseEnable.Size = new System.Drawing.Size(124, 17);
            this.cbSpacemouseEnable.TabIndex = 41;
            this.cbSpacemouseEnable.Text = "Spacemouse Enable";
            this.cbSpacemouseEnable.UseVisualStyleBackColor = true;
            this.cbSpacemouseEnable.CheckedChanged += new System.EventHandler(this.cbSpacemouseEnable_CheckedChanged);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(455, 23);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 44;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(369, 23);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 43;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // cbStartupProgram
            // 
            this.cbStartupProgram.FormattingEnabled = true;
            this.cbStartupProgram.Location = new System.Drawing.Point(88, 114);
            this.cbStartupProgram.Name = "cbStartupProgram";
            this.cbStartupProgram.Size = new System.Drawing.Size(121, 21);
            this.cbStartupProgram.TabIndex = 45;
            this.cbStartupProgram.SelectedIndexChanged += new System.EventHandler(this.cbStartupProgram_SelectedIndexChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(254, 332);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(320, 173);
            this.pictureBox2.TabIndex = 46;
            this.pictureBox2.TabStop = false;
            // 
            // btnButton01
            // 
            this.btnButton01.Location = new System.Drawing.Point(290, 141);
            this.btnButton01.Name = "btnButton01";
            this.btnButton01.Size = new System.Drawing.Size(26, 24);
            this.btnButton01.TabIndex = 47;
            this.btnButton01.Text = "1";
            this.btnButton01.UseVisualStyleBackColor = true;
            this.btnButton01.Click += new System.EventHandler(this.btnButtonNN_Click);
            // 
            // btnButton02
            // 
            this.btnButton02.Location = new System.Drawing.Point(322, 141);
            this.btnButton02.Name = "btnButton02";
            this.btnButton02.Size = new System.Drawing.Size(26, 24);
            this.btnButton02.TabIndex = 48;
            this.btnButton02.Text = "2";
            this.btnButton02.UseVisualStyleBackColor = true;
            this.btnButton02.Click += new System.EventHandler(this.btnButtonNN_Click);
            // 
            // btnButton03
            // 
            this.btnButton03.Location = new System.Drawing.Point(290, 176);
            this.btnButton03.Name = "btnButton03";
            this.btnButton03.Size = new System.Drawing.Size(26, 24);
            this.btnButton03.TabIndex = 49;
            this.btnButton03.Text = "3";
            this.btnButton03.UseVisualStyleBackColor = true;
            this.btnButton03.Click += new System.EventHandler(this.btnButtonNN_Click);
            // 
            // btnButton04
            // 
            this.btnButton04.Location = new System.Drawing.Point(322, 176);
            this.btnButton04.Name = "btnButton04";
            this.btnButton04.Size = new System.Drawing.Size(26, 24);
            this.btnButton04.TabIndex = 50;
            this.btnButton04.Text = "4";
            this.btnButton04.UseVisualStyleBackColor = true;
            this.btnButton04.Click += new System.EventHandler(this.btnButtonNN_Click);
            // 
            // btnButton05
            // 
            this.btnButton05.Location = new System.Drawing.Point(322, 209);
            this.btnButton05.Name = "btnButton05";
            this.btnButton05.Size = new System.Drawing.Size(26, 24);
            this.btnButton05.TabIndex = 51;
            this.btnButton05.Text = "5";
            this.btnButton05.UseVisualStyleBackColor = true;
            this.btnButton05.Click += new System.EventHandler(this.btnButtonNN_Click);
            // 
            // btnButton10
            // 
            this.btnButton10.Location = new System.Drawing.Point(474, 209);
            this.btnButton10.Name = "btnButton10";
            this.btnButton10.Size = new System.Drawing.Size(30, 24);
            this.btnButton10.TabIndex = 56;
            this.btnButton10.Text = "10";
            this.btnButton10.UseVisualStyleBackColor = true;
            this.btnButton10.Click += new System.EventHandler(this.btnButtonNN_Click);
            // 
            // btnButton09
            // 
            this.btnButton09.Location = new System.Drawing.Point(510, 176);
            this.btnButton09.Name = "btnButton09";
            this.btnButton09.Size = new System.Drawing.Size(26, 24);
            this.btnButton09.TabIndex = 55;
            this.btnButton09.Text = "9";
            this.btnButton09.UseVisualStyleBackColor = true;
            this.btnButton09.Click += new System.EventHandler(this.btnButtonNN_Click);
            // 
            // btnButton08
            // 
            this.btnButton08.Location = new System.Drawing.Point(478, 176);
            this.btnButton08.Name = "btnButton08";
            this.btnButton08.Size = new System.Drawing.Size(26, 24);
            this.btnButton08.TabIndex = 54;
            this.btnButton08.Text = "8";
            this.btnButton08.UseVisualStyleBackColor = true;
            this.btnButton08.Click += new System.EventHandler(this.btnButtonNN_Click);
            // 
            // btnButton07
            // 
            this.btnButton07.Location = new System.Drawing.Point(510, 141);
            this.btnButton07.Name = "btnButton07";
            this.btnButton07.Size = new System.Drawing.Size(26, 24);
            this.btnButton07.TabIndex = 53;
            this.btnButton07.Text = "7";
            this.btnButton07.UseVisualStyleBackColor = true;
            this.btnButton07.Click += new System.EventHandler(this.btnButtonNN_Click);
            // 
            // btnButton06
            // 
            this.btnButton06.Location = new System.Drawing.Point(478, 141);
            this.btnButton06.Name = "btnButton06";
            this.btnButton06.Size = new System.Drawing.Size(26, 24);
            this.btnButton06.TabIndex = 52;
            this.btnButton06.Text = "6";
            this.btnButton06.UseVisualStyleBackColor = true;
            this.btnButton06.Click += new System.EventHandler(this.btnButtonNN_Click);
            // 
            // btnButton00
            // 
            this.btnButton00.Location = new System.Drawing.Point(399, 177);
            this.btnButton00.Name = "btnButton00";
            this.btnButton00.Size = new System.Drawing.Size(26, 24);
            this.btnButton00.TabIndex = 57;
            this.btnButton00.Text = "0";
            this.btnButton00.UseVisualStyleBackColor = true;
            this.btnButton00.Click += new System.EventHandler(this.btnButtonNN_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(36, 40);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 80;
            this.label14.Text = "Name";
            // 
            // tbButtonName
            // 
            this.tbButtonName.Location = new System.Drawing.Point(88, 35);
            this.tbButtonName.Multiline = true;
            this.tbButtonName.Name = "tbButtonName";
            this.tbButtonName.Size = new System.Drawing.Size(154, 21);
            this.tbButtonName.TabIndex = 79;
            this.tbButtonName.Leave += new System.EventHandler(this.tbButtonName_Leave);
            // 
            // pbCaptureKeystroke
            // 
            this.pbCaptureKeystroke.Location = new System.Drawing.Point(41, 214);
            this.pbCaptureKeystroke.Name = "pbCaptureKeystroke";
            this.pbCaptureKeystroke.Size = new System.Drawing.Size(201, 41);
            this.pbCaptureKeystroke.TabIndex = 78;
            this.pbCaptureKeystroke.Text = "Capture Keystroke";
            this.pbCaptureKeystroke.UseVisualStyleBackColor = true;
            this.pbCaptureKeystroke.Click += new System.EventHandler(this.pbCaptureKeystroke_Click);
            this.pbCaptureKeystroke.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pbCaptureKeystroke_KeyDown);
            // 
            // lButton_2
            // 
            this.lButton_2.AutoSize = true;
            this.lButton_2.Location = new System.Drawing.Point(22, 184);
            this.lButton_2.Name = "lButton_2";
            this.lButton_2.Size = new System.Drawing.Size(13, 13);
            this.lButton_2.TabIndex = 72;
            this.lButton_2.Text = "2";
            // 
            // lButton_1
            // 
            this.lButton_1.AutoSize = true;
            this.lButton_1.Location = new System.Drawing.Point(22, 157);
            this.lButton_1.Name = "lButton_1";
            this.lButton_1.Size = new System.Drawing.Size(13, 13);
            this.lButton_1.TabIndex = 73;
            this.lButton_1.Text = "1";
            // 
            // lButton_0
            // 
            this.lButton_0.AutoSize = true;
            this.lButton_0.Location = new System.Drawing.Point(22, 127);
            this.lButton_0.Name = "lButton_0";
            this.lButton_0.Size = new System.Drawing.Size(13, 13);
            this.lButton_0.TabIndex = 71;
            this.lButton_0.Text = "0";
            // 
            // lButtonValue
            // 
            this.lButtonValue.AutoSize = true;
            this.lButtonValue.Location = new System.Drawing.Point(172, 111);
            this.lButtonValue.Name = "lButtonValue";
            this.lButtonValue.Size = new System.Drawing.Size(34, 13);
            this.lButtonValue.TabIndex = 70;
            this.lButtonValue.Text = "Value";
            // 
            // lButtonAction
            // 
            this.lButtonAction.AutoSize = true;
            this.lButtonAction.Location = new System.Drawing.Point(64, 111);
            this.lButtonAction.Name = "lButtonAction";
            this.lButtonAction.Size = new System.Drawing.Size(37, 13);
            this.lButtonAction.TabIndex = 69;
            this.lButtonAction.Text = "Action";
            // 
            // cbButtonValue0
            // 
            this.cbButtonValue0.FormattingEnabled = true;
            this.cbButtonValue0.Location = new System.Drawing.Point(149, 127);
            this.cbButtonValue0.Name = "cbButtonValue0";
            this.cbButtonValue0.Size = new System.Drawing.Size(93, 21);
            this.cbButtonValue0.TabIndex = 66;
            this.cbButtonValue0.SelectedIndexChanged += new System.EventHandler(this.cbButtonValue0_SelectedIndexChanged);
            // 
            // cbButtonAction0
            // 
            this.cbButtonAction0.FormattingEnabled = true;
            this.cbButtonAction0.Location = new System.Drawing.Point(41, 127);
            this.cbButtonAction0.Name = "cbButtonAction0";
            this.cbButtonAction0.Size = new System.Drawing.Size(93, 21);
            this.cbButtonAction0.TabIndex = 63;
            this.cbButtonAction0.SelectedIndexChanged += new System.EventHandler(this.cbButtonAction0_SelectedIndexChanged);
            // 
            // cbButtonValue1
            // 
            this.cbButtonValue1.FormattingEnabled = true;
            this.cbButtonValue1.Location = new System.Drawing.Point(149, 154);
            this.cbButtonValue1.Name = "cbButtonValue1";
            this.cbButtonValue1.Size = new System.Drawing.Size(93, 21);
            this.cbButtonValue1.TabIndex = 67;
            this.cbButtonValue1.SelectedIndexChanged += new System.EventHandler(this.cbButtonValue1_SelectedIndexChanged);
            // 
            // cbButtonAction1
            // 
            this.cbButtonAction1.FormattingEnabled = true;
            this.cbButtonAction1.Location = new System.Drawing.Point(41, 154);
            this.cbButtonAction1.Name = "cbButtonAction1";
            this.cbButtonAction1.Size = new System.Drawing.Size(93, 21);
            this.cbButtonAction1.TabIndex = 64;
            this.cbButtonAction1.SelectedIndexChanged += new System.EventHandler(this.cbButtonAction1_SelectedIndexChanged);
            // 
            // cbButtonValue2
            // 
            this.cbButtonValue2.FormattingEnabled = true;
            this.cbButtonValue2.Location = new System.Drawing.Point(149, 181);
            this.cbButtonValue2.Name = "cbButtonValue2";
            this.cbButtonValue2.Size = new System.Drawing.Size(93, 21);
            this.cbButtonValue2.TabIndex = 68;
            this.cbButtonValue2.SelectedIndexChanged += new System.EventHandler(this.cbButtonValue2_SelectedIndexChanged);
            // 
            // cbButtonAction2
            // 
            this.cbButtonAction2.FormattingEnabled = true;
            this.cbButtonAction2.Location = new System.Drawing.Point(41, 181);
            this.cbButtonAction2.Name = "cbButtonAction2";
            this.cbButtonAction2.Size = new System.Drawing.Size(93, 21);
            this.cbButtonAction2.TabIndex = 65;
            this.cbButtonAction2.SelectedIndexChanged += new System.EventHandler(this.cbButtonAction2_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(22, 80);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 13);
            this.label15.TabIndex = 82;
            this.label15.Text = "Description";
            // 
            // tbButtonDescription
            // 
            this.tbButtonDescription.Location = new System.Drawing.Point(88, 77);
            this.tbButtonDescription.Multiline = true;
            this.tbButtonDescription.Name = "tbButtonDescription";
            this.tbButtonDescription.Size = new System.Drawing.Size(154, 21);
            this.tbButtonDescription.TabIndex = 81;
            this.tbButtonDescription.Leave += new System.EventHandler(this.tbButtonDescription_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.tbButtonDescription);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.tbButtonName);
            this.groupBox1.Controls.Add(this.pbCaptureKeystroke);
            this.groupBox1.Controls.Add(this.lButton_2);
            this.groupBox1.Controls.Add(this.lButton_1);
            this.groupBox1.Controls.Add(this.lButton_0);
            this.groupBox1.Controls.Add(this.lButtonValue);
            this.groupBox1.Controls.Add(this.lButtonAction);
            this.groupBox1.Controls.Add(this.cbButtonValue0);
            this.groupBox1.Controls.Add(this.cbButtonAction0);
            this.groupBox1.Controls.Add(this.cbButtonValue1);
            this.groupBox1.Controls.Add(this.cbButtonAction1);
            this.groupBox1.Controls.Add(this.cbButtonValue2);
            this.groupBox1.Controls.Add(this.cbButtonAction2);
            this.groupBox1.Location = new System.Drawing.Point(592, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 275);
            this.groupBox1.TabIndex = 83;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Button Definition";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(636, 449);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(162, 13);
            this.label16.TabIndex = 84;
            this.label16.Text = "Button 0 not used with LCDKnob";
            // 
            // CADProgramConfigUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label16);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnButton00);
            this.Controls.Add(this.btnButton10);
            this.Controls.Add(this.btnButton09);
            this.Controls.Add(this.btnButton08);
            this.Controls.Add(this.btnButton07);
            this.Controls.Add(this.btnButton06);
            this.Controls.Add(this.btnButton05);
            this.Controls.Add(this.btnButton04);
            this.Controls.Add(this.btnButton03);
            this.Controls.Add(this.btnButton02);
            this.Controls.Add(this.btnButton01);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.cbStartupProgram);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.cbSpacemouseEnable);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tbMouseSensitivity);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbZoomSensitivity);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbRotateSensitivity);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbXYSensitivity);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbZoomDeadzone);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbRotateDeadzone);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbXYDeadzone);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbScaleZoom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbScaleRotate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbScaleY);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbScaleX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbCADProgram);
            this.DoubleBuffered = true;
            this.Name = "CADProgramConfigUserControl";
            this.Size = new System.Drawing.Size(880, 546);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbCADProgram;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbScaleX;
        private System.Windows.Forms.TextBox tbScaleY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbScaleRotate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbScaleZoom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbXYDeadzone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbRotateDeadzone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbZoomDeadzone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbXYSensitivity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbRotateSensitivity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbZoomSensitivity;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbMouseSensitivity;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox cbSpacemouseEnable;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.ComboBox cbStartupProgram;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnButton01;
        private System.Windows.Forms.Button btnButton02;
        private System.Windows.Forms.Button btnButton03;
        private System.Windows.Forms.Button btnButton04;
        private System.Windows.Forms.Button btnButton05;
        private System.Windows.Forms.Button btnButton10;
        private System.Windows.Forms.Button btnButton09;
        private System.Windows.Forms.Button btnButton08;
        private System.Windows.Forms.Button btnButton07;
        private System.Windows.Forms.Button btnButton06;
        private System.Windows.Forms.Button btnButton00;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbButtonName;
        private System.Windows.Forms.Button pbCaptureKeystroke;
        private System.Windows.Forms.Label lButton_2;
        private System.Windows.Forms.Label lButton_1;
        private System.Windows.Forms.Label lButton_0;
        private System.Windows.Forms.Label lButtonValue;
        private System.Windows.Forms.Label lButtonAction;
        private System.Windows.Forms.ComboBox cbButtonValue0;
        private System.Windows.Forms.ComboBox cbButtonAction0;
        private System.Windows.Forms.ComboBox cbButtonValue1;
        private System.Windows.Forms.ComboBox cbButtonAction1;
        private System.Windows.Forms.ComboBox cbButtonValue2;
        private System.Windows.Forms.ComboBox cbButtonAction2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbButtonDescription;
        private GroupBox groupBox1;
        private Label label16;
    }
}
