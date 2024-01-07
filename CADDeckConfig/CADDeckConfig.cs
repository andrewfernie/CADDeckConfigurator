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
            project_folder = Properties.Settings.Default.project_folder;
            if (CheckFolderStructure(project_folder))
            {
                LoadData();
            }
         }

        private void LoadData()
        {
            string wifi_fileName = "\\config\\wificonfig.json";
            this.wiFiConfigUserControl.LoadJsonFile(project_folder, wifi_fileName);

            // Load the general paramneters json file
            string general_fileName = "\\config\\general.json";
            this.generalConfigUserControl.LoadJsonFile(project_folder, general_fileName);

            this.buttonMenuUserControl.SetProjectFolder(project_folder);
            this.buttonMenuUserControl.DisplayMenuNumber(0);

            string cadparams_fileName = "\\config\\cadparams.json";
            this.cadProgramConfigUserControl.LoadJsonFile(project_folder, cadparams_fileName);
        }
        private bool CheckFolderStructure(string folder)
        {
            bool folder_ok = true;

            if (!Directory.Exists(folder))
                folder_ok = false;
            else
            {
                if (!Directory.Exists(folder + "\\config"))
                    folder_ok = false;
                else if (!Directory.Exists(folder + "\\logos"))
                    folder_ok = false;
                else if (!File.Exists(folder + "\\config\\wificonfig.json"))
                    folder_ok = false;
                else if (!File.Exists(folder + "\\config\\general.json"))
                    folder_ok = false;
                else if (!File.Exists(folder + "\\config\\cadparams.json"))
                    folder_ok = false;
                else
                {
                    for (int i = 0; i < NUM_MENU_FILES; i++)
                    {
                        if (!File.Exists(folder + "\\config\\menu" + i.ToString() + ".json"))
                            folder_ok = false;
                    }
                }
            }

            return folder_ok;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog cofd = new CommonOpenFileDialog();
            cofd.IsFolderPicker = true;
            if(cofd.ShowDialog()== CommonFileDialogResult.Ok)
            {
                string folder = cofd.FileName;
                if (CheckFolderStructure(folder))
                {
                    project_folder = folder;
                    Properties.Settings.Default.project_folder = project_folder;
                    Properties.Settings.Default.Save();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Invalid project folder structure");
                }
            }
        }
  
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close?", "Infomate", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.Show();
        }
    }
}

