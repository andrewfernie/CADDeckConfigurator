namespace CADDeckConfig
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.communicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.HWButtonsTab = new System.Windows.Forms.TabPage();
            this.cadProgramConfigUserControl = new CADProgramConfigUserControl.CADProgramConfigUserControl();
            this.MenuTab = new System.Windows.Forms.TabPage();
            this.buttonMenuUserControl = new ButtonMenuUserControl.ButtonMenuUserControl();
            this.GeneralTab = new System.Windows.Forms.TabPage();
            this.generalConfigUserControl = new GeneralUserControl.GeneralConfigUserControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.WiFiTab = new System.Windows.Forms.TabPage();
            this.wiFiConfigUserControl = new WiFiUserControl.WiFiConfigUserControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            this.HWButtonsTab.SuspendLayout();
            this.MenuTab.SuspendLayout();
            this.GeneralTab.SuspendLayout();
            this.WiFiTab.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.communicationToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(991, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // communicationToolStripMenuItem
            // 
            this.communicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem,
            this.parametersToolStripMenuItem});
            this.communicationToolStripMenuItem.Name = "communicationToolStripMenuItem";
            this.communicationToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.communicationToolStripMenuItem.Text = "Communication";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            // 
            // parametersToolStripMenuItem
            // 
            this.parametersToolStripMenuItem.Name = "parametersToolStripMenuItem";
            this.parametersToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.parametersToolStripMenuItem.Text = "Parameters";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // HWButtonsTab
            // 
            this.HWButtonsTab.Controls.Add(this.cadProgramConfigUserControl);
            this.HWButtonsTab.Location = new System.Drawing.Point(4, 22);
            this.HWButtonsTab.Name = "HWButtonsTab";
            this.HWButtonsTab.Size = new System.Drawing.Size(983, 699);
            this.HWButtonsTab.TabIndex = 3;
            this.HWButtonsTab.Text = "HW Buttons";
            this.HWButtonsTab.UseVisualStyleBackColor = true;
            // 
            // cadProgramConfigUserControl
            // 
            this.cadProgramConfigUserControl.AutoScroll = true;
            this.cadProgramConfigUserControl.Location = new System.Drawing.Point(0, 0);
            this.cadProgramConfigUserControl.Name = "cadProgramConfigUserControl";
            this.cadProgramConfigUserControl.Size = new System.Drawing.Size(987, 657);
            this.cadProgramConfigUserControl.TabIndex = 0;
            // 
            // MenuTab
            // 
            this.MenuTab.Controls.Add(this.buttonMenuUserControl);
            this.MenuTab.Location = new System.Drawing.Point(4, 22);
            this.MenuTab.Name = "MenuTab";
            this.MenuTab.Size = new System.Drawing.Size(983, 699);
            this.MenuTab.TabIndex = 2;
            this.MenuTab.Text = "Menu";
            this.MenuTab.UseVisualStyleBackColor = true;
            // 
            // buttonMenuUserControl
            // 
            this.buttonMenuUserControl.AutoScroll = true;
            this.buttonMenuUserControl.Location = new System.Drawing.Point(0, 0);
            this.buttonMenuUserControl.Name = "buttonMenuUserControl";
            this.buttonMenuUserControl.Size = new System.Drawing.Size(800, 747);
            this.buttonMenuUserControl.TabIndex = 0;
            // 
            // GeneralTab
            // 
            this.GeneralTab.Controls.Add(this.generalConfigUserControl);
            this.GeneralTab.Controls.Add(this.statusStrip1);
            this.GeneralTab.Location = new System.Drawing.Point(4, 22);
            this.GeneralTab.Name = "GeneralTab";
            this.GeneralTab.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralTab.Size = new System.Drawing.Size(983, 699);
            this.GeneralTab.TabIndex = 1;
            this.GeneralTab.Text = "General";
            this.GeneralTab.UseVisualStyleBackColor = true;
            // 
            // generalConfigUserControl
            // 
            this.generalConfigUserControl.Location = new System.Drawing.Point(0, 0);
            this.generalConfigUserControl.Name = "generalConfigUserControl";
            this.generalConfigUserControl.Size = new System.Drawing.Size(796, 394);
            this.generalConfigUserControl.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(3, 674);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(977, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // WiFiTab
            // 
            this.WiFiTab.AutoScroll = true;
            this.WiFiTab.Controls.Add(this.wiFiConfigUserControl);
            this.WiFiTab.Location = new System.Drawing.Point(4, 22);
            this.WiFiTab.Name = "WiFiTab";
            this.WiFiTab.Padding = new System.Windows.Forms.Padding(3);
            this.WiFiTab.Size = new System.Drawing.Size(983, 699);
            this.WiFiTab.TabIndex = 0;
            this.WiFiTab.Text = "WiFi";
            this.WiFiTab.UseVisualStyleBackColor = true;
            // 
            // wiFiConfigUserControl
            // 
            this.wiFiConfigUserControl.Location = new System.Drawing.Point(-4, 0);
            this.wiFiConfigUserControl.Name = "wiFiConfigUserControl";
            this.wiFiConfigUserControl.Size = new System.Drawing.Size(391, 272);
            this.wiFiConfigUserControl.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.WiFiTab);
            this.tabControl1.Controls.Add(this.GeneralTab);
            this.tabControl1.Controls.Add(this.MenuTab);
            this.tabControl1.Controls.Add(this.HWButtonsTab);
            this.tabControl1.Location = new System.Drawing.Point(0, 36);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(991, 725);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 765);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "CADDeck Configurator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.HWButtonsTab.ResumeLayout(false);
            this.MenuTab.ResumeLayout(false);
            this.GeneralTab.ResumeLayout(false);
            this.GeneralTab.PerformLayout();
            this.WiFiTab.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem communicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parametersToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage HWButtonsTab;
        private CADProgramConfigUserControl.CADProgramConfigUserControl cadProgramConfigUserControl;
        private System.Windows.Forms.TabPage MenuTab;
        private ButtonMenuUserControl.ButtonMenuUserControl buttonMenuUserControl;
        private System.Windows.Forms.TabPage GeneralTab;
        private GeneralUserControl.GeneralConfigUserControl generalConfigUserControl;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabPage WiFiTab;
        private WiFiUserControl.WiFiConfigUserControl wiFiConfigUserControl;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

