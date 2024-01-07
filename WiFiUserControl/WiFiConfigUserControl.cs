using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace WiFiUserControl
{
    public partial class WiFiConfigUserControl: UserControl
    {
        String project_folder="";
        String file_name= "\\config\\wificonfig.json"; 
        CJSONWiFi json_structure;
        bool data_changed = false;
        
        public WiFiConfigUserControl()
        {
            InitializeComponent();
        }

        public void LoadJsonFile(string projectFolder, string fileName)
        {
            project_folder = projectFolder;
            file_name=fileName;

            string json_string = File.ReadAllText(project_folder+file_name);
            json_structure = JsonSerializer.Deserialize<CJSONWiFi>(json_string);

            tbSSID.Text = json_structure.ssid;
            tbPassword.Text = json_structure.password;
            cbMode.Text = json_structure.wifimode;
            tbHostName.Text = json_structure.wifihostname;
            tbAttempts.Text = json_structure.attempts.ToString();
            tbAttemptDelay.Text = json_structure.attemptdelay.ToString();
            data_changed = false;
        }
         private void bSave_Click(object sender, EventArgs e)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json_structure_string = JsonSerializer.Serialize(json_structure, options);
            File.WriteAllText(project_folder + file_name + "_new", json_structure_string);
            data_changed = false;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            if (data_changed)
            {
                if (MessageBox.Show("Data has been modified. Are you sure you want to cancel?", "Infomate",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LoadJsonFile(project_folder, file_name);
                }
            }
        }

        private void tbAttempts_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbAttemptDelay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbSSID_Leave(object sender, EventArgs e)
        {
            json_structure.ssid = tbSSID.Text;
            data_changed = true;
        }

        private void tbPassword_Leave(object sender, EventArgs e)
        {
            json_structure.password = tbPassword.Text;
            data_changed = true;
        }
        
        private void cbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_structure.wifimode = cbMode.Text;
            data_changed = true;
        }

        private void tbHostName_Leave(object sender, EventArgs e)
        {
            json_structure.wifihostname = tbHostName.Text;
            data_changed = true;
        }

        private void tbAttempts_Leave(object sender, EventArgs e)
        {
            data_changed = true;
            json_structure.attempts = Int32.Parse(tbAttempts.Text);
        }

        private void tbAttemptDelay_Leave(object sender, EventArgs e)
        {
            json_structure.attemptdelay= Int32.Parse(tbAttemptDelay.Text);
            data_changed = true;
        }

    }
}