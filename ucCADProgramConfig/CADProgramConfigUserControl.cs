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
using Helpers;
using System.Collections;

namespace CADProgramConfigUserControl
{
    public partial class CADProgramConfigUserControl : UserControl
    {
        String project_folder;
        String file_name = "\\config\\cadparams.json";
        CJSONCADParams json_structure;
        int current_program = 0;
        int number_of_programs = 0;
        bool data_changed = false;

        int button_type = 0;
        int button_offset = 0;

        const int HWBUTTON_MAX = 10;
        const int LCDKNOBBUTTON_MAX = 6;

        public CADProgramConfigUserControl()
        {
            InitializeComponent();

        }
        public void LoadJsonFile(string projectFolder, string fileName)
        {
            project_folder = projectFolder;
            file_name = fileName;

            string json_string = File.ReadAllText(project_folder + file_name);
            json_structure = JsonSerializer.Deserialize<CJSONCADParams>(json_string);

            data_changed = false;

            number_of_programs = json_structure.programs.Length;

            for (int i = 0; i < number_of_programs; i++)
            {
                cbCADProgram.Items.Add(json_structure.programs[i].name);
            }

            current_program = json_structure.current_program;

            cbCADProgram.SelectedIndex = current_program;

            // Check for missing buttons and create them as needed.
            const int num_buttons =11;
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

            rbHW_0to3.Select();
            SetLabels(0, 0);

            InitializeText();
            InitializeActions();
            InitializeValues();
            InitializeMiscControls();

        }
        public void InitializeText()
        {
            if (button_type == 0)
            {
                if ((button_offset + 0) <= HWBUTTON_MAX)
                {
                    tbButton0Text.Text = json_structure.programs[current_program].buttons[button_offset + 0].description;
                }
                if ((button_offset + 1) <= HWBUTTON_MAX)
                {
                    tbButton1Text.Text = json_structure.programs[current_program].buttons[button_offset + 1].description;
                }
                if ((button_offset + 2) <= HWBUTTON_MAX)
                {
                    tbButton2Text.Text = json_structure.programs[current_program].buttons[button_offset + 2].description;
                }
                if ((button_offset + 3) <= HWBUTTON_MAX)
                {
                    tbButton3Text.Text = json_structure.programs[current_program].buttons[button_offset + 3].description;
                }
            }
            else if (button_type == 1)
            {
                if ((button_offset + 0) <= LCDKNOBBUTTON_MAX)
                {
                    tbButton0Text.Text = json_structure.programs[current_program].lcdknob_buttons[button_offset + 0].description;
                }
                if ((button_offset + 1) <= LCDKNOBBUTTON_MAX)
                {
                    tbButton1Text.Text = json_structure.programs[current_program].lcdknob_buttons[button_offset + 1].description;
                }
                if ((button_offset + 2) <= LCDKNOBBUTTON_MAX)
                {
                    tbButton2Text.Text = json_structure.programs[current_program].lcdknob_buttons[button_offset + 2].description;
                }
                if ((button_offset + 3) <= LCDKNOBBUTTON_MAX)
                {
                    tbButton3Text.Text = json_structure.programs[current_program].lcdknob_buttons[button_offset + 3].description;
                }
            }
        }

        private void InitializeMiscControls()
        {
            tbScaleX.Text = json_structure.joy_scale_x.ToString();
            tbScaleY.Text = json_structure.joy_scale_y.ToString();
            tbScaleRotate.Text = json_structure.rotate_scale.ToString();
            tbScaleZoom.Text = json_structure.zoom_scale.ToString();
            tbXYDeadzone.Text = json_structure.joy_deadzone.ToString();
            tbRotateDeadzone.Text = json_structure.rotate_deadzone.ToString();
            tbZoomDeadzone.Text = json_structure.zoom_deadzone.ToString();
            tbXYSensitivity.Text = json_structure.joy_sensitivity.ToString();
            tbRotateSensitivity.Text = json_structure.rotate_sensitivity.ToString();
            tbZoomSensitivity.Text = json_structure.zoom_sensitivity.ToString();
            tbMouseSensitivity.Text = json_structure.mouse_sensitivity.ToString();
            cbSpacemouseEnable.Checked = json_structure.spacemouse_enable;

            for (int i = 0; i < number_of_programs; i++)
            {
                cbStartupProgram.Items.Add(json_structure.programs[i].name);
            }
            cbStartupProgram.SelectedIndex = current_program;
        }

        public void InitializeActions()
        {
            if (button_type == 0)
            {
                if ((button_offset + 0) <= HWBUTTON_MAX)
                {
                    InitializeAction(cbButton0Action0, json_structure.programs[current_program].buttons[0 + button_offset].actionarray[0]);
                    InitializeAction(cbButton0Action1, json_structure.programs[current_program].buttons[0 + button_offset].actionarray[1]);
                    InitializeAction(cbButton0Action2, json_structure.programs[current_program].buttons[0 + button_offset].actionarray[2]);
                }

                if ((button_offset + 1) <= HWBUTTON_MAX)
                {
                    InitializeAction(cbButton1Action0, json_structure.programs[current_program].buttons[1 + button_offset].actionarray[0]);
                    InitializeAction(cbButton1Action1, json_structure.programs[current_program].buttons[1 + button_offset].actionarray[1]);
                    InitializeAction(cbButton1Action2, json_structure.programs[current_program].buttons[1 + button_offset].actionarray[2]);
                }

                if ((button_offset + 2) <= HWBUTTON_MAX)
                {
                    InitializeAction(cbButton2Action0, json_structure.programs[current_program].buttons[2 + button_offset].actionarray[0]);
                    InitializeAction(cbButton2Action1, json_structure.programs[current_program].buttons[2 + button_offset].actionarray[1]);
                    InitializeAction(cbButton2Action2, json_structure.programs[current_program].buttons[2 + button_offset].actionarray[2]);
                }

                if ((button_offset + 3) <= HWBUTTON_MAX)
                {
                    InitializeAction(cbButton3Action0, json_structure.programs[current_program].buttons[3 + button_offset].actionarray[0]);
                    InitializeAction(cbButton3Action1, json_structure.programs[current_program].buttons[3 + button_offset].actionarray[1]);
                    InitializeAction(cbButton3Action2, json_structure.programs[current_program].buttons[3 + button_offset].actionarray[2]);
                }
            }
            else if (button_type == 1)
            {
                if ((button_offset + 0) <= LCDKNOBBUTTON_MAX)
                {
                    InitializeAction(cbButton0Action0, json_structure.programs[current_program].lcdknob_buttons[0 + button_offset].actionarray[0]);
                    InitializeAction(cbButton0Action1, json_structure.programs[current_program].lcdknob_buttons[0 + button_offset].actionarray[1]);
                    InitializeAction(cbButton0Action2, json_structure.programs[current_program].lcdknob_buttons[0 + button_offset].actionarray[2]);
                }

                if ((button_offset + 1) <= LCDKNOBBUTTON_MAX)
                {
                    InitializeAction(cbButton1Action0, json_structure.programs[current_program].lcdknob_buttons[1 + button_offset].actionarray[0]);
                    InitializeAction(cbButton1Action1, json_structure.programs[current_program].lcdknob_buttons[1 + button_offset].actionarray[1]);
                    InitializeAction(cbButton1Action2, json_structure.programs[current_program].lcdknob_buttons[1 + button_offset].actionarray[2]);
                }

                if ((button_offset + 2) <= LCDKNOBBUTTON_MAX)
                {
                    InitializeAction(cbButton2Action0, json_structure.programs[current_program].lcdknob_buttons[2 + button_offset].actionarray[0]);
                    InitializeAction(cbButton2Action1, json_structure.programs[current_program].lcdknob_buttons[2 + button_offset].actionarray[1]);
                    InitializeAction(cbButton2Action2, json_structure.programs[current_program].lcdknob_buttons[2 + button_offset].actionarray[2]);
                }

                if ((button_offset + 3) <= LCDKNOBBUTTON_MAX)
                {
                    InitializeAction(cbButton3Action0, json_structure.programs[current_program].lcdknob_buttons[3 + button_offset].actionarray[0]);
                    InitializeAction(cbButton3Action1, json_structure.programs[current_program].lcdknob_buttons[3 + button_offset].actionarray[1]);
                    InitializeAction(cbButton3Action2, json_structure.programs[current_program].lcdknob_buttons[3 + button_offset].actionarray[2]);
                }
            }
        }
        public void InitializeValues()
        {
            if (button_type == 0)
            {
                if ((button_offset + 0) <= HWBUTTON_MAX)
                {
                    InitializeValue(cbButton0Action0, cbButton0Value0, json_structure.programs[current_program].buttons[button_offset + 0].valuearray[0]);
                    InitializeValue(cbButton0Action1, cbButton0Value1, json_structure.programs[current_program].buttons[button_offset + 0].valuearray[1]);
                    InitializeValue(cbButton0Action2, cbButton0Value2, json_structure.programs[current_program].buttons[button_offset + 0].valuearray[2]);
                }

                if ((button_offset + 1) <= HWBUTTON_MAX)
                {
                    InitializeValue(cbButton1Action0, cbButton1Value0, json_structure.programs[current_program].buttons[button_offset + 1].valuearray[0]);
                    InitializeValue(cbButton1Action1, cbButton1Value1, json_structure.programs[current_program].buttons[button_offset + 1].valuearray[1]);
                    InitializeValue(cbButton1Action2, cbButton1Value2, json_structure.programs[current_program].buttons[button_offset + 1].valuearray[2]);
                }

                if ((button_offset + 2) <= HWBUTTON_MAX)
                {
                    InitializeValue(cbButton2Action0, cbButton2Value0, json_structure.programs[current_program].buttons[button_offset + 2].valuearray[0]);
                    InitializeValue(cbButton2Action1, cbButton2Value1, json_structure.programs[current_program].buttons[button_offset + 2].valuearray[1]);
                    InitializeValue(cbButton2Action2, cbButton2Value2, json_structure.programs[current_program].buttons[button_offset + 2].valuearray[2]);
                }

                if ((button_offset + 3) <= HWBUTTON_MAX)
                {
                    InitializeValue(cbButton3Action0, cbButton3Value0, json_structure.programs[current_program].buttons[button_offset + 3].valuearray[0]);
                    InitializeValue(cbButton3Action1, cbButton3Value1, json_structure.programs[current_program].buttons[button_offset + 3].valuearray[1]);
                    InitializeValue(cbButton3Action2, cbButton3Value2, json_structure.programs[current_program].buttons[button_offset + 3].valuearray[2]);
                }
            }
            else if (button_type == 1)
            {
                if ((button_offset + 0) <= LCDKNOBBUTTON_MAX)
                {
                    InitializeValue(cbButton0Action0, cbButton0Value0, json_structure.programs[current_program].lcdknob_buttons[button_offset + 0].valuearray[0]);
                    InitializeValue(cbButton0Action1, cbButton0Value1, json_structure.programs[current_program].lcdknob_buttons[button_offset + 0].valuearray[1]);
                    InitializeValue(cbButton0Action2, cbButton0Value2, json_structure.programs[current_program].lcdknob_buttons[button_offset + 0].valuearray[2]);
                }

                if ((button_offset + 1) <= LCDKNOBBUTTON_MAX)
                {
                    InitializeValue(cbButton1Action0, cbButton1Value0, json_structure.programs[current_program].lcdknob_buttons[button_offset + 1].valuearray[0]);
                    InitializeValue(cbButton1Action1, cbButton1Value1, json_structure.programs[current_program].lcdknob_buttons[button_offset + 1].valuearray[1]);
                    InitializeValue(cbButton1Action2, cbButton1Value2, json_structure.programs[current_program].lcdknob_buttons[button_offset + 1].valuearray[2]);
                }

                if ((button_offset + 2) <= LCDKNOBBUTTON_MAX)
                {
                    InitializeValue(cbButton2Action0, cbButton2Value0, json_structure.programs[current_program].lcdknob_buttons[button_offset + 2].valuearray[0]);
                    InitializeValue(cbButton2Action1, cbButton2Value1, json_structure.programs[current_program].lcdknob_buttons[button_offset + 2].valuearray[1]);
                    InitializeValue(cbButton2Action2, cbButton2Value2, json_structure.programs[current_program].lcdknob_buttons[button_offset + 2].valuearray[2]);
                }

                if ((button_offset + 3) <= LCDKNOBBUTTON_MAX)
                {
                    InitializeValue(cbButton3Action0, cbButton3Value0, json_structure.programs[current_program].lcdknob_buttons[button_offset + 3].valuearray[0]);
                    InitializeValue(cbButton3Action1, cbButton3Value1, json_structure.programs[current_program].lcdknob_buttons[button_offset + 3].valuearray[1]);
                    InitializeValue(cbButton3Action2, cbButton3Value2, json_structure.programs[current_program].lcdknob_buttons[button_offset + 3].valuearray[2]);
                }
            }
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
        private void cbCADProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            current_program = cbCADProgram.SelectedIndex;
            InitializeText();
            InitializeActions();
            InitializeValues();
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

        private string GetAction(int buttonNumber, int actionIndex)
        {

            string value = "";
            if (button_type == 0)
            {
                value = json_structure.programs[current_program].buttons[buttonNumber].actionarray[actionIndex];
            }
            else if (button_type == 1)
            {
                value = json_structure.programs[current_program].lcdknob_buttons[buttonNumber].actionarray[actionIndex];
            }
            else
            {
                value = "";
            }

            return value;

        }

        private void SetAction(int buttonNumber, int actionIndex, string value)
        {

            if (button_type == 0)
            {
                json_structure.programs[current_program].buttons[buttonNumber].actionarray[actionIndex] = value;
                data_changed = true;
            }
            else if (button_type == 1)
            {
                json_structure.programs[current_program].lcdknob_buttons[buttonNumber].actionarray[actionIndex] = value;
                data_changed = true;
            }

        }

        private void SetValue(int buttonNumber, int valueIndex, string value)
        {

            if (button_type == 0)
            {
                json_structure.programs[current_program].buttons[buttonNumber].valuearray[valueIndex] = value;
                data_changed = true;
            }
            else if (button_type == 1)
            {
                json_structure.programs[current_program].lcdknob_buttons[buttonNumber].valuearray[valueIndex] = value;
                data_changed = true;
            }

        }

        private void cbButton0Action0_SelectedIndexChanged(object sender, EventArgs e)
        {

            string value = GetAction(button_offset + 0, 0);

            if (value != cbButton0Action0.SelectedIndex.ToString())
            {
                SetAction(button_offset + 0, 0, cbButton0Action0.SelectedIndex.ToString());
                InitializeValue(cbButton0Action0, cbButton0Value0, "0");
            }
        }
        private void cbButton0Action1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = GetAction(button_offset + 0, 1);

            if (value != cbButton0Action1.SelectedIndex.ToString())
            {
                SetAction(button_offset + 0, 1, cbButton0Action1.SelectedIndex.ToString());
                InitializeValue(cbButton0Action1, cbButton0Value1, "0");
            }
        }
        private void cbButton0Action2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = GetAction(button_offset + 0, 2);

            if (value != cbButton0Action2.SelectedIndex.ToString())
            {
                SetAction(button_offset + 0, 2, cbButton0Action2.SelectedIndex.ToString());
                InitializeValue(cbButton0Action2, cbButton0Value2, "0");
            }
        }
        private void cbButton1Action0_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = GetAction(button_offset + 1, 0);

            if (value != cbButton1Action0.SelectedIndex.ToString())
            {
                SetAction(button_offset + 1, 0, cbButton1Action0.SelectedIndex.ToString());
                InitializeValue(cbButton1Action0, cbButton1Value0, "0");
            }
        }
        private void cbButton1Action1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = GetAction(button_offset + 1, 1);

            if (value != cbButton1Action1.SelectedIndex.ToString())
            {
                SetAction(button_offset + 1, 1, cbButton1Action1.SelectedIndex.ToString());
                InitializeValue(cbButton1Action1, cbButton1Value1, "0");
            }
        }

        private void cbButton1Action2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = GetAction(button_offset + 1, 2);

            if (value != cbButton1Action2.SelectedIndex.ToString())
            {
                SetAction(button_offset + 1, 2, cbButton1Action2.SelectedIndex.ToString());
                InitializeValue(cbButton1Action2, cbButton1Value2, "0");
            }
        }

        private void cbButton2Action0_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = GetAction(button_offset + 2, 0);

            if (value != cbButton2Action0.SelectedIndex.ToString())
            {
                SetAction(button_offset + 2, 0, cbButton2Action0.SelectedIndex.ToString());
                InitializeValue(cbButton2Action0, cbButton2Value0, "0");
            }
        }

        private void cbButton2Action1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = GetAction(button_offset + 2, 1);

            if (value != cbButton2Action1.SelectedIndex.ToString())
            {
                SetAction(button_offset + 2, 1, cbButton2Action1.SelectedIndex.ToString());
                InitializeValue(cbButton2Action1, cbButton2Value1, "0");
            }
        }

        private void cbButton2Action2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = GetAction(button_offset + 2, 2);

            if (value != cbButton2Action2.SelectedIndex.ToString())
            {
                SetAction(button_offset + 2, 2, cbButton2Action2.SelectedIndex.ToString());
                InitializeValue(cbButton2Action2, cbButton2Value2, "0");
            }
        }

        private void cbButton3Action0_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = GetAction(button_offset + 3, 0);

            if (value != cbButton3Action0.SelectedIndex.ToString())
            {
                SetAction(button_offset + 3, 0, cbButton3Action0.SelectedIndex.ToString());
                InitializeValue(cbButton3Action0, cbButton3Value0, "0");
            }
        }

        private void cbButton3Action1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = GetAction(button_offset + 3, 1);

            if (value != cbButton3Action1.SelectedIndex.ToString())
            {
                SetAction(button_offset + 3, 1, cbButton3Action1.SelectedIndex.ToString());
                InitializeValue(cbButton3Action1, cbButton3Value1, "0");
            }
        }

        private void cbButton3Action2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = GetAction(button_offset + 3, 2);

            if (value != cbButton3Action2.SelectedIndex.ToString())
            {
                SetAction(button_offset + 3, 2, cbButton3Action2.SelectedIndex.ToString());
                InitializeValue(cbButton3Action2, cbButton3Value2, "0");
            }
        }

        private void cbButton0Value0_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetValue(button_offset + 0, 0, ActionHelpers.GetValue(cbButton0Action0.SelectedIndex, cbButton0Value0.SelectedIndex, 1));
        }

        private void cbButton0Value1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetValue(button_offset + 0, 1, ActionHelpers.GetValue(cbButton0Action1.SelectedIndex, cbButton0Value1.SelectedIndex, 1));
        }

        private void cbButton0Value2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetValue(button_offset + 0, 2, ActionHelpers.GetValue(cbButton0Action2.SelectedIndex, cbButton0Value2.SelectedIndex, 1));
        }
        private void cbButton1Value0_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetValue(button_offset + 1, 0, ActionHelpers.GetValue(cbButton1Action0.SelectedIndex, cbButton1Value0.SelectedIndex, 1));
        }

        private void cbButton1Value1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetValue(button_offset + 1, 1, ActionHelpers.GetValue(cbButton1Action1.SelectedIndex, cbButton1Value1.SelectedIndex, 1));
        }

        private void cbButton1Value2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetValue(button_offset + 1, 2, ActionHelpers.GetValue(cbButton1Action2.SelectedIndex, cbButton1Value2.SelectedIndex, 1));
        }

        private void cbButton2Value0_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetValue(button_offset + 2, 0, ActionHelpers.GetValue(cbButton2Action0.SelectedIndex, cbButton2Value0.SelectedIndex, 1));
        }

        private void cbButton2Value1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetValue(button_offset + 2, 1, ActionHelpers.GetValue(cbButton2Action1.SelectedIndex, cbButton2Value1.SelectedIndex, 1));
        }

        private void cbButton2Value2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetValue(button_offset + 2, 2, ActionHelpers.GetValue(cbButton2Action2.SelectedIndex, cbButton2Value2.SelectedIndex, 1));
        }

        private void cbButton3Value0_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetValue(button_offset + 3, 0, ActionHelpers.GetValue(cbButton3Action0.SelectedIndex, cbButton3Value0.SelectedIndex, 1));
        }

        private void cbButton3Value1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetValue(button_offset + 3, 1, ActionHelpers.GetValue(cbButton3Action1.SelectedIndex, cbButton3Value1.SelectedIndex, 1));
        }

        private void cbButton3Value2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetValue(button_offset + 3, 2, ActionHelpers.GetValue(cbButton3Action2.SelectedIndex, cbButton3Value2.SelectedIndex, 1));
        }

        private void SetLabels(int type, int offset)
        {
            if (type == 0)
            {
                gbButton0.Text = "HW Button " + offset;
                gbButton1.Text = "HW Button " + (offset + 1);
                gbButton2.Text = "HW Button " + (offset + 2);

                if (offset + 3 <= 10)
                {
                    gbButton3.Visible = true;
                    gbButton3.Text = "HW Button " + (offset + 3);
                }
                else
                {
                    gbButton3.Visible = false;
                }
            }
            else if (type == 1)
            {
                gbButton0.Text = "LCD Knob " + offset;
                gbButton1.Text = "LCD Knob " + (offset + 1);
                gbButton2.Text = "LCD Knob " + (offset + 2);
                if (offset + 3 <= 6)
                {
                    gbButton3.Visible = true;
                    gbButton3.Text = "LCD Knob " + (offset + 3);
                }
                else
                {
                    gbButton3.Visible = false;
                }
            }
        }

        private void rbButtonSelect_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb == null)
            {
                MessageBox.Show("Sender is not a RadioButton");
                return;
            }


            if (rbHW_0to3.Checked)
            {
                button_type = 0;
                button_offset = 0;
                SetLabels(button_type, button_offset);
            }
            else if (rbHW_4to7.Checked)
            {
                button_type = 0;
                button_offset = 4;
                SetLabels(button_type, button_offset);
            }
            else if (rbHW_8to10.Checked)
            {
                button_type = 0;
                button_offset = 8;
                SetLabels(button_type, button_offset);
            }
            else if (rbLCDKnob_0to3.Checked)
            {
                button_type = 1;
                button_offset = 0;
                SetLabels(button_type, button_offset);
            }
            else if (rbLCDKnob_4to6.Checked)
            {
                button_type = 1;
                button_offset = 4;
                SetLabels(button_type, button_offset);
            }
            InitializeText();
            InitializeActions();
            InitializeValues();
        }

        private void tbScaleX_Leave(object sender, EventArgs e)
        {
            json_structure.joy_scale_x = (float)Convert.ToDouble(tbScaleX.Text);
            data_changed = true;

        }

        private void tbScaleY_Leave(object sender, EventArgs e)
        {
            json_structure.joy_scale_y = (float)Convert.ToDouble(tbScaleY.Text);
            data_changed = true;

        }

        private void tbScaleRotate_Leave(object sender, EventArgs e)
        {
            json_structure.rotate_scale = (float)Convert.ToDouble(tbScaleRotate.Text);
            data_changed = true;

        }

        private void tbScaleZoom_Leave(object sender, EventArgs e)
        {
            json_structure.zoom_scale = (float)Convert.ToDouble(tbScaleZoom.Text);
            data_changed = true;

        }

        private void tbRotateDeadzone_Leave(object sender, EventArgs e)
        {
            json_structure.rotate_deadzone = (float)Convert.ToDouble(tbRotateDeadzone.Text);
            data_changed = true;

        }

        private void tbZoomDeadzone_Leave(object sender, EventArgs e)
        {
            json_structure.zoom_deadzone = (float)Convert.ToDouble(tbZoomDeadzone.Text);
            data_changed = true;

        }

        private void tbXYSensitivity_Leave(object sender, EventArgs e)
        {
            json_structure.joy_sensitivity = Int32.Parse(tbXYSensitivity.Text);
            data_changed = true;

        }

        private void tbXYDeadzone_Leave(object sender, EventArgs e)
        {
            json_structure.joy_deadzone = (float)Convert.ToDouble(tbXYDeadzone.Text);
            data_changed = true;

        }

        private void tbRotateSensitivity_Leave(object sender, EventArgs e)
        {
            json_structure.rotate_sensitivity = Int32.Parse(tbRotateSensitivity.Text);
            data_changed = true;
        }

        private void tbZoomSensitivity_Leave(object sender, EventArgs e)
        {
            json_structure.zoom_sensitivity = Int32.Parse(tbZoomSensitivity.Text);
            data_changed = true;

        }

        private void tbMouseSensitivity_Leave(object sender, EventArgs e)
        {
            json_structure.mouse_sensitivity = Int32.Parse(tbMouseSensitivity.Text);
            data_changed = true;

        }

        private void cbSpacemouseEnable_CheckedChanged(object sender, EventArgs e)
        {
            json_structure.spacemouse_enable = cbSpacemouseEnable.Checked;
            data_changed = true;

        }

        private void cbStartupProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_structure.current_program = cbStartupProgram.SelectedIndex;
            data_changed = true;

        }

        private void tbButton0Text_Leave(object sender, EventArgs e)
        {
            if (button_type == 0)
            {
                json_structure.programs[current_program].buttons[button_offset + 0].description = tbButton0Text.Text;
                data_changed = true;

            }
            else if (button_type == 1)
            {
                json_structure.programs[current_program].lcdknob_buttons[button_offset + 0].description = tbButton0Text.Text;
                data_changed = true;

            }
        }

        private void tbButton1Text_TextChanged(object sender, EventArgs e)
        {
            if (button_type == 0)
            {
                json_structure.programs[current_program].buttons[button_offset + 1].description = tbButton1Text.Text;
                data_changed = true;
            }
            else if (button_type == 1)
            {
                json_structure.programs[current_program].lcdknob_buttons[button_offset + 1].description = tbButton1Text.Text;
                data_changed = true;
            }
        }

        private void tbButton2Text_TextChanged(object sender, EventArgs e)
        {
            if (button_type == 0)
            {
                json_structure.programs[current_program].buttons[button_offset + 2].description = tbButton2Text.Text;
                data_changed = true;
            }
            else if (button_type == 1)
            {
                json_structure.programs[current_program].lcdknob_buttons[button_offset + 2].description = tbButton2Text.Text;
                data_changed = true;
            }
        }

        private void tbButton3Text_TextChanged(object sender, EventArgs e)
        {
            if (button_type == 0)
            {
                json_structure.programs[current_program].buttons[button_offset + 3].description = tbButton3Text.Text;
                data_changed = true;
            }
            else if (button_type == 1)
            {
                json_structure.programs[current_program].lcdknob_buttons[button_offset + 3].description = tbButton3Text.Text;
                data_changed = true;
            }
        }
    }
}
