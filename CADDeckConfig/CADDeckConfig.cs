using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.IO;
using System.Windows.Forms;

namespace CADDeckConfig
{
    public partial class MainForm : Form
    {
        string project_folder = "";

        const int NUM_MENU_FILES = 10;

        public MainForm()
        {
            InitializeComponent();
        }

   
        private void Form1_Load(object sender, EventArgs e)
        {
            string message = "";
            project_folder = Properties.Settings.Default.project_folder;
            message = CheckFolderStructure(project_folder);
            if (message == "")
            {
                this.KeyPreview = true;
                LoadData();
            }
            else
            {
                MessageBox.Show("Invalid project folder structure\n" + message);
            }
        }

        private void LoadData()
        {
            this.Text = "CADDeck Configurator - " + project_folder;
            
            string wifi_fileName = "\\config\\wificonfig.json";
            this.wiFiConfigUserControl.LoadJsonFile(project_folder, wifi_fileName);

            // Load the general paramneters json file
            string general_fileName = "\\config\\general.json";
            this.generalConfigUserControl.LoadJsonFile(project_folder, general_fileName);

            this.softButtonUserControl.SetProjectFolder(project_folder);
            this.softButtonUserControl.DisplayMenuNumber(0);

        }
        private string CheckFolderStructure(string folder)
        {

            string message = "";

            if (!Directory.Exists(folder))
            {
                message += "\nFolder " + folder + " missing.";
            }
            else
            {
                if (!Directory.Exists(folder + "\\config"))
                {
                    message += "\nFolder " + folder + "\\config missing.";
                }

                if (!Directory.Exists(folder + "\\logos"))
                {
                    message += "\nFolder " + folder + "\\logos missing.";
                }
                if (!File.Exists(folder + "\\config\\wificonfig.json"))
                {
                    message += "\nFile \\config\\wificonfig.json missing.";
                }
                if (!File.Exists(folder + "\\config\\general.json"))
                {
                    message += "\nFile \\config\\general.json missing.";
                }
                if (!File.Exists(folder + "\\config\\cadparams.json"))
                {
                    message += "\nFile \\config\\cadparams.json missing.";
                }

                for (int i = 0; i < NUM_MENU_FILES; i++)
                {
                    if (!File.Exists(folder + "\\config\\menu" + i.ToString() + ".json"))
                    {
                        message += "\nFile \\config\\menu" + i.ToString() + ".json missing.";
                    }

                }
            }

            return message;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog cofd = new CommonOpenFileDialog();
            cofd.IsFolderPicker = true;
            if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string folder = cofd.FileName;
                string message = "";
                message = CheckFolderStructure(folder);
                if ( message == "")
                {
                    project_folder = folder;
                    Properties.Settings.Default.project_folder = project_folder;
                    Properties.Settings.Default.Save();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Invalid project folder structure\n" + message);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close?", "CADDeckConfig", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.Show();
        }

        private void LCDButtonsTab_Enter(object sender, EventArgs e)
        {
            string cadparams_fileName = "\\config\\cadparams.json";
            this.lcdKnobButtonsUserControl.LoadJsonFile(project_folder, cadparams_fileName);
        }

        private void HWButtonsTab_Enter(object sender, EventArgs e)
        {
            string cadparams_fileName = "\\config\\cadparams.json";
            this.cadProgramConfigUserControl.LoadJsonFile(project_folder, cadparams_fileName);
        }
    }
}

