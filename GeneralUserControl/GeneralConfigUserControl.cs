using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Helpers;

namespace GeneralUserControl
{
    public partial class GeneralConfigUserControl : UserControl
    {
        String project_folder;
        String file_name= "\\config\\general.json";
        CJSONGeneral json_structure;
        bool data_changed = false;

        public GeneralConfigUserControl()
        {
            InitializeComponent();
        }
      
        public void LoadJsonFile(string projectFolder, string fileName)
        {
            project_folder = projectFolder;
            file_name = fileName;

            string json_string = File.ReadAllText(project_folder + file_name);
            json_structure = JsonSerializer.Deserialize<CJSONGeneral>(json_string);

            tbMenuColorSample.BackColor = ColorHelpers.HexRGBToColor(json_structure.menubuttoncolor);
            tbFunctionColorSample.BackColor = ColorHelpers.HexRGBToColor(json_structure.functionbuttoncolor);
            tbLatchColorSample.BackColor = ColorHelpers.HexRGBToColor(json_structure.latchcolor);
            tbBackgroundColorSample.BackColor = ColorHelpers.HexRGBToColor(json_structure.background);

            cbEnableSleep.Checked = json_structure.sleepenable;
            cbEnableUSBComms.Checked = json_structure.usbcommsenable;
            cbEnableBeep.Checked = json_structure.beep;

            tbSleepTimer.Text = json_structure.sleeptimer.ToString();
            tbModifier1.Text = json_structure.modifier1.ToString();
            tbModifier2.Text = json_structure.modifier2.ToString();
            tbModifier3.Text = json_structure.modifier3.ToString();
            tbHelperDelay.Text = json_structure.helperdelay.ToString();
            tbStartupMenu.Text = json_structure.startup_menu.ToString();
            tbButtonLightPin.Text = json_structure.gpio_pin.ToString();
            tbButtonLightPinMode.Text = json_structure.gpio_pin_mode.ToString();
            data_changed = false;

        }

        private void bLocalSave_Click(object sender, EventArgs e)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json_structure_string = JsonSerializer.Serialize(json_structure, options);

            string file_name_with_path = project_folder + file_name;
            string saved_file_name = file_name_with_path;

            int n = 0;
            while (File.Exists(saved_file_name))
            {
                string file_extension = Path.GetExtension(saved_file_name);
                saved_file_name = saved_file_name.Remove(saved_file_name.Length - file_extension.Length);
                if (saved_file_name.Contains('('))
                {
                    int underscoreIndex = saved_file_name.LastIndexOf("(");
                    saved_file_name = saved_file_name.Substring(0, underscoreIndex);
                }
                n += 1;
                saved_file_name = string.Format("{0}({1}){2}", saved_file_name, n, ".json");
            }

            if (File.Exists(file_name_with_path))
            {
                System.IO.File.Copy(file_name_with_path, saved_file_name);
            }

            File.WriteAllText(file_name_with_path, json_structure_string);

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

        private void tbMenuColorSample_DoubleClick(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            tbMenuColorSample.BackColor = colorDialog1.Color;
            json_structure.menubuttoncolor = ColorHelpers.ColorToHexRGB(colorDialog1.Color);
            data_changed = true;
        }

        private void tbFunctionColorSample_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            tbFunctionColorSample.BackColor = colorDialog1.Color;
            json_structure.functionbuttoncolor = ColorHelpers.ColorToHexRGB(colorDialog1.Color);
            data_changed = true;

        }

        private void tbLatchColorSample_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            tbLatchColorSample.BackColor = colorDialog1.Color;
            json_structure.latchcolor = ColorHelpers.ColorToHexRGB(colorDialog1.Color);
            data_changed = true;

        }

        private void tbBackgroundColorSample_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            tbBackgroundColorSample.BackColor = colorDialog1.Color;
            json_structure.background = ColorHelpers.ColorToHexRGB(colorDialog1.Color);
            data_changed = true;

        }

        private void tbSleepTimer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbModifier1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbModifier2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbModifier3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbHelperDelay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbStartupMenu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbButtonLightPin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbButtonLightPinMode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbSleepTimer_Leave(object sender, EventArgs e)
        {
            json_structure.sleeptimer = Int32.Parse(tbSleepTimer.Text);
            data_changed = true;

        }

        private void tbModifier1_Leave(object sender, EventArgs e)
        {
            json_structure.modifier1 = Int32.Parse(tbModifier1.Text);
            data_changed = true;

        }

        private void tbModifier2_Leave(object sender, EventArgs e)
        {
            json_structure.modifier2 = Int32.Parse(tbModifier2.Text);
            data_changed = true;

        }

        private void tbModifier3_Leave(object sender, EventArgs e)
        {
            json_structure.modifier3 = Int32.Parse(tbModifier3.Text);
            data_changed = true;

        }

        private void tbHelperDelay_Leave(object sender, EventArgs e)
        {
            json_structure.helperdelay = Int32.Parse(tbHelperDelay.Text);
            data_changed = true;
        }

        private void tbStartupMenu_Leave(object sender, EventArgs e)
        {
            json_structure.startup_menu = Int32.Parse(tbStartupMenu.Text);
            data_changed = true;
        }

        private void tbButtonLightPin_Leave(object sender, EventArgs e)
        {
            json_structure.gpio_pin = Int32.Parse(tbButtonLightPin.Text);
            data_changed = true;
        }

        private void tbButtonLightPinMode_Leave(object sender, EventArgs e)
        {
            json_structure.gpio_pin_mode = Int32.Parse(tbButtonLightPinMode.Text);
            data_changed = true;
        }

        private void cbEnableSleep_CheckedChanged(object sender, EventArgs e)
        {
            json_structure.sleepenable = cbEnableSleep.Checked;
            data_changed = true;
        }

        private void cbEnableUSBComms_CheckedChanged(object sender, EventArgs e)
        {
            json_structure.usbcommsenable = cbEnableUSBComms.Checked;
            data_changed = true;
        }

        private void cbEnableBeep_CheckedChanged(object sender, EventArgs e)
        {
            json_structure.beep = cbEnableBeep.Checked;
            data_changed = true;
        }

    }

}
