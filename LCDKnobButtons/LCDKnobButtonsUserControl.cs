using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Helpers;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace LCDKnobButtons
{
    public partial class LCDKnobButtonsUserControl : UserControl
    {
        String project_folder;
        String file_name = "\\config\\cadparams.json";
        
        CJSONCADParams json_structure;
        JsonNode json_document_node;
        JsonObject json_document_object;
        
        int current_program = 0;
        int number_of_programs = 0;
        bool data_changed = false;

        const int HWBUTTON_MAX = 10;
        const int LCDKNOBBUTTON_MAX = 6;

        int activeButtonNumber = -1;

        bool keyCapture = false;

        public LCDKnobButtonsUserControl()
        {
            InitializeComponent();

        }
        
        public void LoadJsonFile(string projectFolder, string fileName)
        {
            project_folder = projectFolder;
            file_name = fileName;
            
            string json_string = File.ReadAllText(project_folder + file_name);
            json_structure = JsonSerializer.Deserialize<CJSONCADParams>(json_string);
            json_document_node = JsonNode.Parse(json_string);
            json_document_object = json_document_node.AsObject();

            data_changed = false;

            number_of_programs = json_structure.programs.Length;

            for (int i = 0; i < number_of_programs; i++)
            {
                cbCADProgram.Items.Add(json_structure.programs[i].name);
            }

            current_program = json_structure.current_program;

            cbCADProgram.SelectedIndex = current_program;

            // Check for missing buttons and create them as needed.
            const int num_buttons = 11;
            for (int i = 0; i < number_of_programs; i++)
            {
                if (json_structure.programs[i].buttons == null)
                {
                    var btns = new Button[num_buttons];
                    for (int j = 0; j < num_buttons; j++)
                    {
                        var btn = new Button();
                        btn.name = "B" + j.ToString();
                        btn.description = "B" + j.ToString();
                        btn.actionarray = new string[3] { "0", "0", "0" };
                        btn.valuearray = new string[3] { "0", "0", "0" }; ;

                        btns[j] = btn;

                    }
                    json_structure.programs[i].buttons = btns;
                }

            }
            // Check for missing LCDKnob buttons and create them as needed.
            const int num_lcd_buttons = 7;
            for (int i = 0; i < number_of_programs; i++)
            {
                if (json_structure.programs[i].lcdknob_buttons == null)
                {
                    var lcdbtns = new Lcdknob_Buttons[num_lcd_buttons];
                    for (int j = 0; j < num_lcd_buttons; j++)
                    {
                        var lcdbtn = new Lcdknob_Buttons();
                        lcdbtn.name = "B" + j.ToString();
                        lcdbtn.description = "B" + j.ToString();
                        lcdbtn.actionarray = new string[3] { "0", "0", "0" };
                        lcdbtn.valuearray = new string[3] { "0", "0", "0" }; ;

                        lcdbtns[j] = lcdbtn;

                    }
                    json_structure.programs[i].lcdknob_buttons = lcdbtns;
                }
            }
            
            activeButtonNumber = 1;
            string buttonName = "btnButton" + activeButtonNumber.ToString("00");
            System.Windows.Forms.Button pButton = (System.Windows.Forms.Button)this.Controls.Find(buttonName, true).FirstOrDefault();
            pButton.BackColor = SystemColors.Highlight;
            SetButtonParameters(current_program, activeButtonNumber);

        }

 
        public void InitializeAction(System.Windows.Forms.ComboBox cbActionCombo, string action)
        {
            cbActionCombo.Items.Clear();

            int number_of_actions = ActionHelpers.GetNumberOfActions();

            for (int i = 0; i < number_of_actions; i++)
            {
                cbActionCombo.Items.Add(ActionHelpers.GetAction(i));
            }
            cbActionCombo.SelectedIndex = Convert.ToInt32(action);
        }

        public void InitializeValue(System.Windows.Forms.ComboBox cbActionCombo, System.Windows.Forms.ComboBox cbValueCombo, string value)
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
        private void bSave_Click(object sender, EventArgs e)
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
                if (MessageBox.Show("Data has been modified. Are you sure you want to cancel?", "",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LoadJsonFile(project_folder, file_name);
                }
            }
        }
        private void cbCADProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            current_program = cbCADProgram.SelectedIndex;
            int newButtonNumber = 1;
            SetButtonParameters(current_program, newButtonNumber);
        }

        private void AdjustWidthComboBox_DropDown(object sender, EventArgs e)
        {
            var senderComboBox = (System.Windows.Forms.ComboBox)sender;
            int width = senderComboBox.DropDownWidth;
            Graphics g = senderComboBox.CreateGraphics();
            Font font = senderComboBox.Font;

            int vertScrollBarWidth = (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
                    ? SystemInformation.VerticalScrollBarWidth : 0;

            var itemsList = senderComboBox.Items.Cast<object>().Select(item => item.ToString());

            foreach (string s in itemsList)
            {
                int newWidth = (int)g.MeasureString(s, font).Width + vertScrollBarWidth;

                if (width < newWidth)
                {
                    width = newWidth;
                }
            }

            senderComboBox.DropDownWidth = width;
        }
        
        private void SetButtonParameters(int program, int button)
        {
            SetButtonHighlight(button);
            activeButtonNumber = button;

            tbButtonName.Text = json_document_node["programs"][program]["lcdknob_buttons"][activeButtonNumber]["name"].ToString();
            tbButtonDescription.Text = json_document_node["programs"][program]["lcdknob_buttons"][activeButtonNumber]["description"].ToString();

            InitializeAction(cbButtonAction0, json_document_node["programs"][program]["lcdknob_buttons"][button]["actionarray"][0].ToString());
            InitializeAction(cbButtonAction1, json_document_node["programs"][program]["lcdknob_buttons"][button]["actionarray"][1].ToString());
            InitializeAction(cbButtonAction2, json_document_node["programs"][program]["lcdknob_buttons"][button]["actionarray"][2].ToString());

            InitializeValue(cbButtonAction0, cbButtonValue0, json_document_node["programs"][program]["lcdknob_buttons"][button]["valuearray"][0].ToString());
            InitializeValue(cbButtonAction1, cbButtonValue1, json_document_node["programs"][program]["lcdknob_buttons"][button]["valuearray"][1].ToString());
            InitializeValue(cbButtonAction2, cbButtonValue2, json_document_node["programs"][program]["lcdknob_buttons"][button]["valuearray"][2].ToString());

        }

        private void SetButtonHighlight(int button)
        {
            if (activeButtonNumber != -1)
            {
                string buttonName = "btnButton" + activeButtonNumber.ToString("00");
                System.Windows.Forms.Button btnButton = (System.Windows.Forms.Button)this.Controls.Find(buttonName, true).FirstOrDefault();
                btnButton.BackColor = SystemColors.Control;
            }
            string newButtonName = "btnButton" + button.ToString("00");
            System.Windows.Forms.Button btnNewButton = (System.Windows.Forms.Button)this.Controls.Find(newButtonName, true).FirstOrDefault();
            btnNewButton.BackColor = SystemColors.Highlight;
        }
        private void btnButtonNN_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button pButton = sender as System.Windows.Forms.Button;

            int newActiveButton = Int32.Parse(pButton.Name.Substring(9, 2));
            SetButtonParameters(current_program, newActiveButton);
        }
        
        private void tbButtonName_Leave(object sender, EventArgs e)
        {
            json_document_node["programs"][current_program]["lcdknob_buttons"][activeButtonNumber]["name"] = tbButtonName.Text;
            data_changed = true;
        }
        private void tbButtonDescription_Leave(object sender, EventArgs e)
        {
            json_document_node["programs"][current_program]["lcdknob_buttons"][activeButtonNumber]["description"] = tbButtonDescription.Text;
            data_changed = true;
        }
        
        private void cbButtonAction0_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cBox = sender as System.Windows.Forms.ComboBox;

            if (json_document_node["programs"][current_program]["lcdknob_buttons"][activeButtonNumber]["actionarray"][0].ToString() != cBox.SelectedIndex.ToString())
            {
                json_document_node["programs"][current_program]["lcdknob_buttons"][activeButtonNumber]["actionarray"][0] = cBox.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cBox, cbButtonValue0, "0");
            }
        }

        private void cbButtonValue0_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["programs"][current_program]["lcdknob_buttons"][activeButtonNumber]["valuearray"][0] = ActionHelpers.GetValue(cbButtonAction0.SelectedIndex, cbButtonValue0.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButtonAction1_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cBox = sender as System.Windows.Forms.ComboBox;

            if (json_document_node["programs"][current_program]["lcdknob_buttons"][activeButtonNumber]["actionarray"][1].ToString() != cBox.SelectedIndex.ToString())
            {
                json_document_node["programs"][current_program]["lcdknob_buttons"][activeButtonNumber]["actionarray"][1] = cBox.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cBox, cbButtonValue1, "0");
            }
        }

        private void cbButtonValue1_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["programs"][current_program]["lcdknob_buttons"][activeButtonNumber]["valuearray"][1] = ActionHelpers.GetValue(cbButtonAction1.SelectedIndex, cbButtonValue1.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButtonAction2_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cBox = sender as System.Windows.Forms.ComboBox;

            if (json_document_node["programs"][current_program]["lcdknob_buttons"][activeButtonNumber]["actionarray"][2].ToString() != cBox.SelectedIndex.ToString())
            {
                json_document_node["programs"][current_program]["lcdknob_buttons"][activeButtonNumber]["actionarray"][2] = cBox.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cBox, cbButtonValue2, "0");
            }
        }

        private void cbButtonValue2_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["programs"][current_program]["lcdknob_buttons"][activeButtonNumber]["valuearray"][2] = ActionHelpers.GetValue(cbButtonAction2.SelectedIndex, cbButtonValue2.SelectedIndex, 1);
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

                    cbButtonAction0.SelectedIndex = actionsAndValues.action0;
                    cbButtonValue0.SelectedIndex = actionsAndValues.value0;
                    json_document_node["programs"][current_program]["lcdknob_buttons"][activeButtonNumber]["actionarray"][0] = cbButtonAction0.SelectedIndex.ToString();
                    json_document_node["programs"][current_program]["lcdknob_buttons"][activeButtonNumber]["valuearray"][0] = ActionHelpers.GetValue(cbButtonAction0.SelectedIndex, cbButtonValue0.SelectedIndex, 1);

                    cbButtonAction1.SelectedIndex = actionsAndValues.action1;
                    cbButtonValue1.SelectedIndex = actionsAndValues.value1;
                    json_document_node["programs"][current_program]["lcdknob_buttons"][activeButtonNumber]["actionarray"][1] = cbButtonAction1.SelectedIndex.ToString();
                    json_document_node["programs"][current_program]["lcdknob_buttons"][activeButtonNumber]["valuearray"][1] = ActionHelpers.GetValue(cbButtonAction1.SelectedIndex, cbButtonValue1.SelectedIndex, 1);

                    pbCaptureKeystroke.BackColor = SystemColors.Control;
                    keyCapture = false;

                    data_changed = true;
                }
            }
        }
    }
}
