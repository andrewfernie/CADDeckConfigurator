using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using SoftButtonUserControl;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.Json.Nodes;
using System.Xml.Linq;
using System.Windows.Forms;
using Helpers;
using System.Security.Cryptography.X509Certificates;

namespace SoftButtonUserControl
{
    public partial class SoftButtonUserControl : UserControl
    {
        String project_folder;
        String file_name_with_path;
        String this_file;
        CJSONMenu json_structure;
        JsonNode json_document_node;
        JsonObject json_document_object;

        bool data_changed = false;
        bool displayLogo = true;

        string activePictureBoxName = "";

        int currentMenuIndex = 0;

        bool keyCapture = false;


        public SoftButtonUserControl()
        {
            InitializeComponent();
        }

        public void SetProjectFolder(String folder)
        {
            project_folder = folder;
        }

        public void DisplayMenuNumber(int v)
        {
            cbMenuSelect.SelectedIndex = v;
            currentMenuIndex = v;
            string fileName = "menu" + v.ToString();
            DisplayMenu(fileName);
        }
        public void DisplayMenu(string file)
        {
            this_file = file;
            file_name_with_path = project_folder + "\\config\\" + file + ".json";
            string json_structure_string = File.ReadAllText(file_name_with_path);
            json_structure = JsonSerializer.Deserialize<CJSONMenu>(json_structure_string);
            json_document_node = JsonNode.Parse(json_structure_string);
            json_document_object = json_document_node.AsObject();

            rbLogoTypeLogo.Checked = true;

            InitializeLogos();

            activePictureBoxName = "pbButton11";
            PictureBox pBox = (PictureBox)this.Controls.Find(activePictureBoxName, true).FirstOrDefault();
            pBox.BackColor = SystemColors.Highlight;
            SetButtonParameters("button11");

            data_changed = false;
        }

        private string GetLogoFileName(string button, string defaultLogo)
        {
            string name = "";

            if (json_document_object.ContainsKey(button))
            {
                if (json_document_object[button].AsObject().ContainsKey("logo"))
                {
                    name = json_document_node[button]["logo"].ToString();
                }
            }
            if (name == "")
            {
                name = defaultLogo;
            }

            return name;
        }

        private string GetLatchLogoFileName(string button, string defaultLogo)
        {
            string name = "";

            if (json_document_object.ContainsKey(button))
            {
                if (json_document_object[button].AsObject().ContainsKey("latchlogo"))
                {
                    name = json_document_node[button]["latchlogo"].ToString();
                }
            }
            if (name == "")
            {
                name = defaultLogo;
            }

            return name;
        }
        private string GetButtonText(string button)
        {
            string buttonText = "";

            if (json_document_object.ContainsKey(button))
            {
                if (json_document_object[button].AsObject().ContainsKey("buttontext"))
                {
                    buttonText = json_document_node[button]["buttontext"].ToString();
                }
            }

            return buttonText;
        }

        private System.Drawing.Image LoadButtonImage(string button, string defaultImage, bool latch)
        {
            string logoFileName = "";
            System.Drawing.Image thisImage;
            try
            {
                if (!latch)
                {
                    logoFileName = GetLogoFileName(button, defaultImage);
                }
                else
                {
                    logoFileName = GetLatchLogoFileName(button, defaultImage);
                }
                thisImage = Image.FromFile(project_folder + "\\logos\\" + logoFileName);
            }
            catch (Exception e)
            {
                if (!latch)
                {
                    MessageBox.Show(e.Message + " Logo " + logoFileName + " not found. Will load " + defaultImage);
                }
                else
                {

                    MessageBox.Show(e.Message + " Latchlogo " + logoFileName + " not found. Will load " + defaultImage);
                }
                thisImage = Image.FromFile(project_folder + "\\logos\\" + defaultImage);
            }

            return thisImage;

        }

        public void InitializeLogos()
        {

            pbButton11.Image = LoadButtonImage("button11", "blank.png", false);
            pbButton12.Image = LoadButtonImage("button12", "blank.png", false);
            pbButton13.Image = LoadButtonImage("button13", "blank.png", false);
            pbButton14.Image = LoadButtonImage("button14", "blank.png", false);

            pbButton21.Image = LoadButtonImage("button21", "blank.png", false);
            pbButton22.Image = LoadButtonImage("button22", "blank.png", false);
            pbButton23.Image = LoadButtonImage("button23", "blank.png", false);
            pbButton24.Image = LoadButtonImage("button24", "blank.png", false);

            pbButton31.Image = LoadButtonImage("button31", "blank.png", false);
            pbButton32.Image = LoadButtonImage("button32", "blank.png", false);
            pbButton33.Image = LoadButtonImage("button33", "blank.png", false);
            pbButton34.Image = LoadButtonImage("button34", "blank.png", false);

        }

        public void InitializeLatchLogos()
        {
            pbButton11.Image = LoadButtonImage("button11", "blank.png", true);
            pbButton12.Image = LoadButtonImage("button12", "blank.png", true);
            pbButton13.Image = LoadButtonImage("button13", "blank.png", true);
            pbButton14.Image = LoadButtonImage("button14", "blank.png", true);

            pbButton21.Image = LoadButtonImage("button21", "blank.png", true);
            pbButton22.Image = LoadButtonImage("button22", "blank.png", true);
            pbButton23.Image = LoadButtonImage("button23", "blank.png", true);
            pbButton24.Image = LoadButtonImage("button24", "blank.png", true);

            pbButton31.Image = LoadButtonImage("button31", "blank.png", true);
            pbButton32.Image = LoadButtonImage("button32", "blank.png", true);
            pbButton33.Image = LoadButtonImage("button33", "blank.png", true);
            pbButton34.Image = LoadButtonImage("button34", "blank.png", true);
        }

        private void InitializeAction(System.Windows.Forms.ComboBox cbActionCombo, string action)
        {
            cbActionCombo.Items.Clear();

            int number_of_actions = ActionHelpers.GetNumberOfActions();

            for (int i = 0; i < number_of_actions; i++)
            {
                cbActionCombo.Items.Add(ActionHelpers.GetAction(i));
            }
            cbActionCombo.SelectedIndex = Convert.ToInt32(action);
        }

        private void InitializeValue(System.Windows.Forms.ComboBox cbActionCombo, System.Windows.Forms.ComboBox cbValueCombo, string value)
        {
            cbValueCombo.Items.Clear();
            int value_index = 0;

            int number_of_values = ActionHelpers.GetNumberOfValues(cbActionCombo.SelectedIndex);

            for (int i = 0; i < number_of_values; i++)
            {
                cbValueCombo.Items.Add(ActionHelpers.GetValue(cbActionCombo.SelectedIndex, i, 0));
                if (ActionHelpers.GetValue(cbActionCombo.SelectedIndex, i, 1) == value)
                {
                    value_index = i;
                }
            }
            cbValueCombo.SelectedIndex = Convert.ToInt32(value_index);
        }

        private void SetButtonParameters(string button)
        {

            tbButtonName.Text = json_document_node[button]["buttontext"].ToString();
            tbButtonLogo.Text = json_document_node[button]["logo"].ToString();
            tbButtonLatchLogo.Text = json_document_node[button]["latchlogo"].ToString();
            cbButtonLatch.Checked = ((bool)json_document_node[button]["latch"].AsValue());

            InitializeAction(cbButtonAction0, json_document_node[button]["actionarray"][0].ToString());
            InitializeAction(cbButtonAction1, json_document_node[button]["actionarray"][1].ToString());
            InitializeAction(cbButtonAction2, json_document_node[button]["actionarray"][2].ToString());

            InitializeValue(cbButtonAction0, cbButtonValue0, json_document_node[button]["valuearray"][0].ToString());
            InitializeValue(cbButtonAction1, cbButtonValue1, json_document_node[button]["valuearray"][1].ToString());
            InitializeValue(cbButtonAction2, cbButtonValue2, json_document_node[button]["valuearray"][2].ToString());
        }

        private void tbButtonNN_Leave(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox tBox = sender as System.Windows.Forms.TextBox;

            // the textbox name is of the form "tbButtonNNLogo" and we need to get "buttonNN"
            string thisButtonName = tBox.Name.Substring(2, 8).ToLower();
            json_document_node[thisButtonName]["buttontext"] = tBox.Text;
            data_changed = true;
        }

        private void pbButtonNN_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.PictureBox pBox = sender as System.Windows.Forms.PictureBox;

            if (activePictureBoxName != "")
            {
                PictureBox pbBox = (PictureBox)this.Controls.Find(activePictureBoxName, true).FirstOrDefault();
                pbBox.BackColor = SystemColors.Control;
            }

            activePictureBoxName = pBox.Name;
            pBox.BackColor = SystemColors.Highlight;

            string thisButtonName = pBox.Name.Substring(2, 8).ToLower();

            SetButtonParameters(thisButtonName);
        }

        private void pbButtonNN_DoubleClick(object sender, EventArgs e)
        {
            System.Windows.Forms.PictureBox pBox = sender as System.Windows.Forms.PictureBox;

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = project_folder + "logos\\",
                Title = "Select Logo File",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "png",
                Filter = "png files (*.png)|*.png|bmp files (*.bmp)|*.bmp",
                FilterIndex = 1,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string logoFileName = openFileDialog1.SafeFileName;

                // the textbox name is of the form "tbButtonNNLogo" and we need to get "buttonNN"
                string thisButtonName = pBox.Name.Substring(2, 8).ToLower();
                JsonObject buttonObject = json_document_object[thisButtonName].AsObject();
                displayLogo = rbLogoTypeLogo.Checked;

                if (displayLogo)
                {
                    buttonObject["logo"] = logoFileName;
                    System.Windows.Forms.TextBox tBox = (System.Windows.Forms.TextBox)this.Controls.Find("tbButtonLogo", true).FirstOrDefault();
                    tBox.Text = logoFileName;
                }
                else
                {
                    buttonObject["latchlogo"] = logoFileName;
                    System.Windows.Forms.TextBox tBox = (System.Windows.Forms.TextBox)this.Controls.Find("tbButtonLatchLogo", true).FirstOrDefault();
                    tBox.Text = logoFileName;
                }
                pBox.Image = Image.FromFile(project_folder + "\\logos\\" + logoFileName);

                data_changed = true;
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json_structure_string = JsonSerializer.Serialize(json_document_object, options);

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
                if (MessageBox.Show("Data has been modified. Are you sure you want to cancel?", "",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DisplayMenu(this_file);
                }
            }
        }

        private void cbMenuSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (data_changed)
            {
                if (cbMenuSelect.SelectedIndex != currentMenuIndex)
                {
                    if (MessageBox.Show("Data has been modified. Are you sure you want to change menu?", "",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DisplayMenuNumber(cbMenuSelect.SelectedIndex);
                        tbMenuName.Text = json_structure.menuname;
                        currentMenuIndex = cbMenuSelect.SelectedIndex;
                    }
                    else
                    {
                        cbMenuSelect.SelectedIndex = currentMenuIndex;
                    }
                }
            }
            else
            {
                DisplayMenuNumber(cbMenuSelect.SelectedIndex);
                tbMenuName.Text = json_structure.menuname;
                currentMenuIndex = cbMenuSelect.SelectedIndex;
            }
        }

        private void tbMenuName_Leave(object sender, EventArgs e)
        {
            json_structure.menuname = tbMenuName.Text;
            data_changed = true;
        }




        private void rbLogoType_Click(object sender, EventArgs e)
        {
            displayLogo = rbLogoTypeLogo.Checked;

            if (displayLogo)
            {
                InitializeLogos();
            }
            else
            {
                InitializeLatchLogos();
            }
        }

        private void tbButtonLogo_DoubleClick(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox tBox = sender as System.Windows.Forms.TextBox;

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = project_folder + "logos\\",
                Title = "Select Logo File",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "png",
                Filter = "png files (*.png)|*.png|bmp files (*.bmp)|*.bmp",
                FilterIndex = 1,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string logoFileName = openFileDialog1.SafeFileName;

                string thisButtonName = activePictureBoxName.Substring(2, 8).ToLower();
                JsonObject buttonObject = json_document_object[thisButtonName].AsObject();
                buttonObject["logo"] = logoFileName;

                tBox.Text = logoFileName;

                bool displayLogo = rbLogoTypeLogo.Checked;

                if (displayLogo)
                {
                    PictureBox pBox = (PictureBox)this.Controls.Find("pb" + activePictureBoxName.Substring(2, 8), true).FirstOrDefault();

                    pBox.Image = Image.FromFile(project_folder + "\\logos\\" + logoFileName);
                }

                data_changed = true;
            }
        }

        private void tbButtonLatchLogo_DoubleClick(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox tBox = sender as System.Windows.Forms.TextBox;

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = project_folder + "logos\\",
                Title = "Select Latch Logo File",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "png",
                Filter = "png files (*.png)|*.png|bmp files (*.bmp)|*.bmp",
                FilterIndex = 1,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string logoFileName = openFileDialog1.SafeFileName;

                string thisButtonName = activePictureBoxName.Substring(2, 8).ToLower();
                JsonObject buttonObject = json_document_object[thisButtonName].AsObject();
                buttonObject["latchlogo"] = logoFileName;

                tBox.Text = logoFileName;

                bool displayLogo = rbLogoTypeLogo.Checked;

                if (!displayLogo)
                {
                    PictureBox pBox = (PictureBox)this.Controls.Find("pb" + activePictureBoxName.Substring(2, 8), true).FirstOrDefault();

                    pBox.Image = Image.FromFile(project_folder + "\\logos\\" + logoFileName);
                }

                data_changed = true;
            }
        }

        private void cbButtonAction0_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cBox = sender as System.Windows.Forms.ComboBox;
            string thisButtonName = activePictureBoxName.Substring(2, 8).ToLower();

            if (json_document_node[thisButtonName]["actionarray"][0].ToString() != cBox.SelectedIndex.ToString())
            {
                json_document_node[thisButtonName]["actionarray"][0] = cBox.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cBox, cbButtonValue0, "0");
            }
        }

        private void cbButtonAction1_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cBox = sender as System.Windows.Forms.ComboBox;
            string thisButtonName = activePictureBoxName.Substring(2, 8).ToLower();

            if (json_document_node[thisButtonName]["actionarray"][1].ToString() != cBox.SelectedIndex.ToString())
            {
                json_document_node[thisButtonName]["actionarray"][1] = cBox.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cBox, cbButtonValue1, "0");
            }
        }

        private void cbButtonAction2_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cBox = sender as System.Windows.Forms.ComboBox;
            string thisButtonName = activePictureBoxName.Substring(2, 8).ToLower();

            if (json_document_node[thisButtonName]["actionarray"][2].ToString() != cBox.SelectedIndex.ToString())
            {
                json_document_node[thisButtonName]["actionarray"][2] = cBox.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cBox, cbButtonValue2, "0");
            }
        }

        private void cbButtonValue0_SelectedIndexChanged(object sender, EventArgs e)
        {
            string thisButtonName = activePictureBoxName.Substring(2, 8).ToLower();
            json_document_node[thisButtonName]["valuearray"][0] = ActionHelpers.GetValue(cbButtonAction0.SelectedIndex, cbButtonValue0.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButtonValue1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string thisButtonName = activePictureBoxName.Substring(2, 8).ToLower();
            json_document_node[thisButtonName]["valuearray"][1] = ActionHelpers.GetValue(cbButtonAction1.SelectedIndex, cbButtonValue1.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButtonValue2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string thisButtonName = activePictureBoxName.Substring(2, 8).ToLower();
            json_document_node[thisButtonName]["valuearray"][2] = ActionHelpers.GetValue(cbButtonAction2.SelectedIndex, cbButtonValue2.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButtonLatch_CheckedChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.CheckBox cBox = sender as System.Windows.Forms.CheckBox;
            string thisButtonName = activePictureBoxName.Substring(2, 8).ToLower();
            json_document_node[thisButtonName]["latch"] = cBox.Checked;
            data_changed = true;
        }

        private void pbCaptureKeystroke_Click(object sender, EventArgs e)
        {
            keyCapture = !keyCapture;

            if (keyCapture)
            {
                pbCaptureKeystroke.BackColor = SystemColors.Highlight;
            }
            else
            {
                pbCaptureKeystroke.BackColor = SystemColors.Control;
            }

        }

        private void pbCaptureKeystroke_KeyDown(object sender, KeyEventArgs e)
        {

            Keys thisKeyCode = e.KeyCode;

            if (keyCapture)
            {

                ActionHelpers.ActionsAndValues actionsAndValues = ActionHelpers.GetActionsAndValues(thisKeyCode);

                if (actionsAndValues.action0 != 0)
                {
                    string thisButtonName = activePictureBoxName.Substring(2, 8).ToLower();

                    cbButtonAction0.SelectedIndex = actionsAndValues.action0;
                    cbButtonValue0.SelectedIndex = actionsAndValues.value0;
                    json_document_node[thisButtonName]["actionarray"][0] = cbButtonAction0.SelectedIndex.ToString();
                    json_document_node[thisButtonName]["valuearray"][0] = ActionHelpers.GetValue(cbButtonAction0.SelectedIndex, cbButtonValue0.SelectedIndex, 1);

                    cbButtonAction1.SelectedIndex = actionsAndValues.action1;
                    cbButtonValue1.SelectedIndex = actionsAndValues.value1;
                    json_document_node[thisButtonName]["actionarray"][1] = cbButtonAction1.SelectedIndex.ToString();
                    json_document_node[thisButtonName]["valuearray"][1] = ActionHelpers.GetValue(cbButtonAction1.SelectedIndex, cbButtonValue1.SelectedIndex, 1);
                    
                    pbCaptureKeystroke.BackColor = SystemColors.Control;
                    keyCapture = false;
                    
                    data_changed = true;
                }
            }
        }



        private void tbButtonName_Leave(object sender, EventArgs e)
        {
            string thisButtonName = activePictureBoxName.Substring(2, 8).ToLower();
            json_document_node[thisButtonName]["buttontext"] = tbButtonName.Text;
            data_changed = true;
        }
    }
}


