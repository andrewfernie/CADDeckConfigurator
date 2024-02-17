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
using System.Text.Json.Nodes;

namespace CADProgramConfigUserControl
{
    public partial class CADProgramConfigUserControl : UserControl
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

        int activeButtonNumber = -1;

        bool keyCapture = false;

        const uint KeyMaskCtrl = 0x0001;
        const uint KeyMaskShift = 0x0002;
        const uint KeyMaskAlt = 0x0004;
        const uint KeyMaskGui = 0x0008;
        const uint KeyMaskLeftCtrl = 0x0010;
        const uint KeyMaskLeftShift = 0x0020;
        const uint KeyMaskLeftAlt = 0x0040;
        const uint KeyMaskLeftGui = 0x0080;
        const uint KeyMaskRightCtrl = 0x0100;
        const uint KeyMaskRightShift = 0x0200;
        const uint KeyMaskRightAlt = 0x0400;
        const uint KeyMaskRightGui = 0x0800;

        const uint KeyLeftCtrlShift = KeyMaskLeftCtrl | KeyMaskLeftShift;
        const uint KeyLeftAltShift = KeyMaskLeftAlt | KeyMaskLeftShift;
        const uint KeyLeftGuiShift = KeyMaskLeftGui | KeyMaskLeftShift;
        const uint KeyLeftCtrlGui = KeyMaskLeftCtrl | KeyMaskLeftGui;
        const uint KeyLeftAltGui = KeyMaskLeftAlt | KeyMaskLeftGui;
        const uint KeyLeftCtrlAlt = KeyMaskLeftCtrl | KeyMaskLeftAlt;
        const uint KeyLeftCtrlAltGui = KeyMaskLeftCtrl | KeyMaskLeftAlt | KeyMaskLeftGui;
        const uint KeyRightCtrlShift = KeyMaskRightCtrl | KeyMaskRightShift;
        const uint KeyRightAltShift = KeyMaskRightAlt | KeyMaskRightShift;
        const uint KeyRightGuiShift = KeyMaskRightGui | KeyMaskRightShift;
        const uint KeyRightCtrlGui = KeyMaskRightCtrl | KeyMaskRightGui;
        const uint KeyRightAltGui = KeyMaskRightAlt | KeyMaskRightGui;
        const uint KeyRightCtrlAlt = KeyMaskRightCtrl | KeyMaskRightAlt;
        const uint KeyRightCtrlAltGui = KeyMaskRightCtrl | KeyMaskRightAlt | KeyMaskRightGui;

        enum KeyTypes
        {
            KeyTypeNone = 0,
            KeyTypeNumber,
            KeyTypeLetter,
            KeyTypeFn,
            KeyTypeNumpad,
            KeyTypeOem,
            KeyTypeMediaApp,
            KeyTypeMisc
        }
        
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
            activeButtonNumber = 1;
            string buttonName = "btnButton" + activeButtonNumber.ToString("00");
            System.Windows.Forms.Button pButton = (System.Windows.Forms.Button)this.Controls.Find(buttonName, true).FirstOrDefault();
            pButton.BackColor = SystemColors.Highlight;
            SetButtonParameters(current_program, activeButtonNumber);

            InitializeMiscControls();

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
        private void SetButtonParameters(int program, int button)
        {
            SetButtonHighlight(button);
            activeButtonNumber = button;
            
            tbButtonName.Text = json_document_node["programs"][program]["buttons"][activeButtonNumber]["name"].ToString();

            InitializeAction(cbButtonAction0, json_document_node["programs"][program]["buttons"][button]["actionarray"][0].ToString());
            InitializeAction(cbButtonAction1, json_document_node["programs"][program]["buttons"][button]["actionarray"][1].ToString());
            InitializeAction(cbButtonAction2, json_document_node["programs"][program]["buttons"][button]["actionarray"][2].ToString());

            InitializeValue(cbButtonAction0, cbButtonValue0, json_document_node["programs"][program]["buttons"][button]["valuearray"][0].ToString());
            InitializeValue(cbButtonAction1, cbButtonValue1, json_document_node["programs"][program]["buttons"][button]["valuearray"][1].ToString());
            InitializeValue(cbButtonAction2, cbButtonValue2, json_document_node["programs"][program]["buttons"][button]["valuearray"][2].ToString());

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
            json_document_node["programs"][current_program]["buttons"][activeButtonNumber]["description"] = tbButtonName.Text;
            data_changed = true;
        }

        private void cbButtonAction0_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cBox = sender as System.Windows.Forms.ComboBox;

            if (json_document_node["programs"][current_program]["buttons"][activeButtonNumber]["actionarray"][0].ToString() != cBox.SelectedIndex.ToString())
            {
                json_document_node["programs"][current_program]["buttons"][activeButtonNumber]["actionarray"][0] = cBox.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cBox, cbButtonValue0, "0");
            }
        }

        private void cbButtonValue0_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["programs"][current_program]["buttons"][activeButtonNumber]["valuearray"][0] = ActionHelpers.GetValue(cbButtonAction0.SelectedIndex, cbButtonValue0.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButtonAction1_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cBox = sender as System.Windows.Forms.ComboBox;

            if (json_document_node["programs"][current_program]["buttons"][activeButtonNumber]["actionarray"][1].ToString() != cBox.SelectedIndex.ToString())
            {
                json_document_node["programs"][current_program]["buttons"][activeButtonNumber]["actionarray"][1] = cBox.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cBox, cbButtonValue1, "0");
            }
        }

        private void cbButtonValue1_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["programs"][current_program]["buttons"][activeButtonNumber]["valuearray"][1] = ActionHelpers.GetValue(cbButtonAction1.SelectedIndex, cbButtonValue1.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButtonAction2_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cBox = sender as System.Windows.Forms.ComboBox;

            if (json_document_node["programs"][current_program]["buttons"][activeButtonNumber]["actionarray"][2].ToString() != cBox.SelectedIndex.ToString())
            {
                json_document_node["programs"][current_program]["buttons"][activeButtonNumber]["actionarray"][2] = cBox.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cBox, cbButtonValue2, "0");
            }
        }

        private void cbButtonValue2_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["programs"][current_program]["buttons"][activeButtonNumber]["valuearray"][2] = ActionHelpers.GetValue(cbButtonAction2.SelectedIndex, cbButtonValue2.SelectedIndex, 1);
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

            uint keyMask = 0;

            if (keyCapture)
            {
                KeyTypes keyType = KeyTypes.KeyTypeNone;
                // Determine whether the keystroke is a number from the top of the keyboard.
                // 0x30 - 0x39
                if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
                {
                    keyType = KeyTypes.KeyTypeNumber;
                }
                // Determine whether the keystroke is a letter key.
                // 0x41 - 0x5A
                else if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
                {
                    keyType = KeyTypes.KeyTypeLetter;
                }
                // Determine whether the keystroke is a Fn key.
                // 0x70 - 0x87
                else if (e.KeyCode >= Keys.F1 && e.KeyCode <= Keys.F24)
                {
                    keyType = KeyTypes.KeyTypeFn;
                }
                // Determine whether the keystroke is a numpad key.
                // 0x60 - 0x6f
                else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.Divide)
                {
                    keyType = KeyTypes.KeyTypeNumpad;
                }
                // Determine whether the keystroke is a miscellaneous key.
                // 0x13 - 0x2f
                else if (e.KeyCode >= Keys.Pause && e.KeyCode <= Keys.Help)
                {
                    keyType = KeyTypes.KeyTypeMisc;
                }
                // Determine whether the keystroke is a media or app key.
                // 0xa6 - 0xb7
                else if (e.KeyCode >= Keys.BrowserBack && e.KeyCode <= Keys.LaunchApplication2)
                {
                    keyType = KeyTypes.KeyTypeMediaApp;
                }
                // Determine whether the keystroke is a miscellaneous key.
                // 0xba - 0xe2
                else if (e.KeyCode >= Keys.OemSemicolon && e.KeyCode <= Keys.OemBackslash)
                {
                    keyType = KeyTypes.KeyTypeOem;
                }

                // Don't trigger if it was just a modifier (ctrl, alt, shift, gui) key. We need
                // to wait for a letter, number, fn, etc.
                if (keyType != KeyTypes.KeyTypeNone)
                {
                    pbCaptureKeystroke.BackColor = SystemColors.Control;
                    keyCapture = false;

                    // Check for each modifier key
                    if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                    {
                        keyMask = keyMask | KeyMaskShift;
                    }
                    if ((Control.ModifierKeys & Keys.LShiftKey) == Keys.LShiftKey)
                    {
                        keyMask = keyMask | KeyMaskLeftShift;
                    }
                    if ((Control.ModifierKeys & Keys.RShiftKey) == Keys.RShiftKey)
                    {
                        keyMask = keyMask | KeyMaskRightShift;
                    }
                    if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                    {
                        keyMask = keyMask | KeyMaskCtrl;
                    }
                    if ((Control.ModifierKeys & Keys.LControlKey) == Keys.LControlKey)
                    {
                        keyMask = keyMask | KeyMaskLeftCtrl;
                    }
                    if ((Control.ModifierKeys & Keys.RControlKey) == Keys.RControlKey)
                    {
                        keyMask = keyMask | KeyMaskRightCtrl;
                    }
                    if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
                    {
                        keyMask = keyMask | KeyMaskAlt;
                    }
                    if ((Control.ModifierKeys & Keys.LMenu) == Keys.LMenu)
                    {
                        keyMask = keyMask | KeyMaskLeftAlt;
                    }
                    if ((Control.ModifierKeys & Keys.RMenu) == Keys.RMenu)
                    {
                        keyMask = keyMask | KeyMaskRightAlt;
                    }
                    if ((Control.ModifierKeys & Keys.LWin) == Keys.LWin)
                    {
                        keyMask = keyMask | KeyMaskLeftGui;
                    }

                    if ((Control.ModifierKeys & Keys.RWin) == Keys.RWin)
                    {
                        keyMask = keyMask | KeyMaskRightGui;
                    }

                    //        static string[,] action_option = {
                    //{ "Do Nothing", "0" }, { "Delay", "1"}, { "Arrows and Tab", "2"}, { "Mediakey", "3" },
                    //{ "Letters", "4" }, { "Option Keys", "5" }, { "Function Keys", "6" }, { "Numbers", "7" },
                    //{ "Special Chars", "8" }, { "Combo", "9" }, { "Helper", "10" }, { "FTD Functions", "11" },
                    //{ "Numpad", "12" }, { "User Actions", "13" }, { "Goto Page", "14" }, { "CAD Functions", "15" },
                    //{ "CAD Programs", "16" }, { "Mouse Buttons", "17" }, { "Previous Page", "18" },
                    //{ "Default Joystick Mode", "19" }, { "Spacemouse Buttons", "20" }};


                    // Identify which action and valueHelper corresponds to one, or a combination of,
                    // modifier keys.
                    int actionHelper = 0;
                    int valueHelper = 0;
                    switch (keyMask)
                    {
                        //        static string[,] option_key_values_5 ={
                        //{ "Left CTRL", "1" },{ "Left Shift", "2" },{ "Left ALT", "3" },{ "Left GUI", "4" },
                        //{ "Right CTRL", "5" },{ "Right Shift", "6" },{ "Right ALT", "7" },{ "Right GUI", "8" },
                        //{ "Release All", "9" }};

                        case KeyMaskCtrl:
                            actionHelper = 5;
                            valueHelper = 0;
                            break;
                        case KeyMaskLeftCtrl:
                            actionHelper = 5;
                            valueHelper = 0;
                            break;
                        case KeyMaskShift:
                            actionHelper = 5;
                            valueHelper = 1;
                            break;
                        case KeyMaskLeftShift:
                            actionHelper = 5;
                            valueHelper = 1;
                            break;
                        case KeyMaskAlt:
                            actionHelper = 5;
                            valueHelper = 2;
                            break;
                        case KeyMaskLeftAlt:
                            actionHelper = 5;
                            valueHelper = 2;
                            break;
                        case KeyMaskLeftGui:
                            actionHelper = 5;
                            valueHelper = 3;
                            break;
                        case KeyMaskRightCtrl:
                            actionHelper = 5;
                            valueHelper = 4;
                            break;
                        case KeyMaskRightShift:
                            actionHelper = 5;
                            valueHelper = 5;
                            break;
                        case KeyMaskRightAlt:
                            actionHelper = 5;
                            valueHelper = 6;
                            break;
                        case KeyMaskRightGui:
                            actionHelper = 5;
                            valueHelper = 7;
                            break;
                        //        static string[,] combo_values_9 ={
                        //{ "LEFT CTRL+SHIFT", "1" },{ "LEFT ALT+SHIFT", "2" },{ "LEFT GUI+SHIFT", "3" },{ "LEFT CTRL+GUI", "4" },
                        //{ "LEFT ALT+GUI", "5" },{ "LEFT CTRL+ALT", "6" },{ "LEFT CTRL+ALT+GUI", "7" },{ "RIGHT CTRL+SHIFT", "8" },
                        //{ "RIGHT ALT+SHIFT", "9" },{ "RIGHT GUI+SHIFT", "10" },{ "RIGHT CTRL+GUI", "11" },{ "RIGHT ALT+GUI", "12" },
                        //{ "RIGHT CTRL+ALT", "13" },{ "RIGHT CTRL+ALT+GUI", "14" }};
                        case KeyMaskCtrl | KeyMaskShift:
                            actionHelper = 9;
                            valueHelper = 0;
                            break;
                        case KeyMaskLeftCtrl | KeyMaskLeftShift:
                            actionHelper = 9;
                            valueHelper = 0;
                            break;
                        case KeyMaskAlt | KeyMaskShift:
                            actionHelper = 9;
                            valueHelper = 1;
                            break;
                        case KeyMaskLeftAlt | KeyMaskLeftShift:
                            actionHelper = 9;
                            valueHelper = 1;
                            break;
                        case KeyMaskLeftGui | KeyMaskLeftShift:
                            actionHelper = 9;
                            valueHelper = 2;
                            break;
                        case KeyMaskLeftGui | KeyMaskShift:
                            actionHelper = 9;
                            valueHelper = 2;
                            break;
                        case KeyMaskCtrl | KeyMaskLeftGui:
                            actionHelper = 9;
                            valueHelper = 3;
                            break;
                        case KeyMaskLeftCtrl | KeyMaskLeftGui:
                            actionHelper = 9;
                            valueHelper = 3;
                            break;
                        case KeyMaskAlt | KeyMaskLeftGui:
                            actionHelper = 9;
                            valueHelper = 4;
                            break;
                        case KeyMaskLeftAlt | KeyMaskLeftGui:
                            actionHelper = 9;
                            valueHelper = 4;
                            break;
                        case KeyMaskLeftCtrl | KeyMaskLeftAlt:
                            actionHelper = 9;
                            valueHelper = 5;
                            break;
                        case KeyMaskCtrl | KeyMaskAlt:
                            actionHelper = 9;
                            valueHelper = 5;
                            break;
                        case KeyMaskCtrl | KeyMaskAlt | KeyMaskLeftGui:
                            actionHelper = 9;
                            valueHelper = 6;
                            break;
                        case KeyMaskLeftCtrl | KeyMaskLeftAlt | KeyMaskLeftGui:
                            actionHelper = 9;
                            valueHelper = 6;
                            break;
                        case KeyMaskRightCtrl | KeyMaskRightShift:
                            actionHelper = 9;
                            valueHelper = 7;
                            break;
                        case KeyMaskRightAlt | KeyMaskRightShift:
                            actionHelper = 9;
                            valueHelper = 8;
                            break;
                        case KeyMaskRightGui | KeyMaskShift:
                            actionHelper = 9;
                            valueHelper = 9;
                            break;
                        case KeyMaskRightGui | KeyMaskRightShift:
                            actionHelper = 9;
                            valueHelper = 9;
                            break;
                        case KeyMaskCtrl | KeyMaskRightGui:
                            actionHelper = 9;
                            valueHelper = 10;
                            break;
                        case KeyMaskRightCtrl | KeyMaskRightGui:
                            actionHelper = 9;
                            valueHelper = 10;
                            break;
                        case KeyMaskAlt | KeyMaskRightGui:
                            actionHelper = 9;
                            valueHelper = 11;
                            break;
                        case KeyMaskRightAlt | KeyMaskRightGui:
                            actionHelper = 9;
                            valueHelper = 11;
                            break;
                        case KeyMaskRightCtrl | KeyMaskRightAlt:
                            actionHelper = 9;
                            valueHelper = 12;
                            break;
                        case KeyMaskCtrl | KeyMaskAlt | KeyMaskRightGui:
                            actionHelper = 9;
                            valueHelper = 13;
                            break;
                        case KeyMaskRightCtrl | KeyMaskRightAlt | KeyMaskRightGui:
                            actionHelper = 9;
                            valueHelper = 13;
                            break;

                        default:

                            break;
                    }

                    int valueKey = 0;
                    int actionKey = 0;
                    switch (keyType)
                    {
                        case KeyTypes.KeyTypeNumber:
                            actionKey = 7;
                            // Mapped to 0-9
                            valueKey = e.KeyCode - Keys.D0;
                            break;

                        case KeyTypes.KeyTypeLetter:
                            actionKey = 4;
                            // mapped to a list that starts with a space character then a-z
                            valueKey = e.KeyCode - Keys.A + 1;
                            break;

                        case KeyTypes.KeyTypeFn:
                            actionKey = 6;
                            // Mapped to F1-F24
                            valueKey = e.KeyCode - Keys.F1;
                            break;

                        case KeyTypes.KeyTypeNumpad:
                            //  { "Numpad 0", "0" }, { "Numpad 1", "1" }, { "Numpad 2", "2" }, { "Numpad 3", "3" },
                            //  { "Numpad 4", "4" }, { "Numpad 5", "5" }, { "Numpad 6", "6" }, { "Numpad 7", "7" },
                            //  { "Numpad 8", "8" }, { "Numpad 9", "9" }, { "Numpad /", "10" }, { "Numpad *", "11" },
                            //  { "Numpad -", "12" }, { "Numpad +", "13" }, { "Numpad RETURN", "14" }, { "Numpad .", "15" }   
                            actionKey = 12;

                            if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
                            {
                                valueKey = e.KeyCode - Keys.NumPad0;
                            }
                            else if (e.KeyCode == Keys.Divide)
                            {
                                valueKey = 10;
                            }
                            else if (e.KeyCode == Keys.Multiply)
                            {
                                valueKey = 11;
                            }
                            else if (e.KeyCode == Keys.Subtract)
                            {
                                valueKey = 12;
                            }
                            else if (e.KeyCode == Keys.Add)
                            {
                                valueKey = 13;
                            }
                            else if (e.KeyCode == Keys.Separator)  // Not sure what this one is.
                            {
                                valueKey = 0;
                            }
                            else if (e.KeyCode == Keys.Decimal)
                            {
                                valueKey = 15;
                            }
                            break;

                        case KeyTypes.KeyTypeOem:
                            //static string[,] special_char_valueKeys_8 ={
                            //{ ".", "." },{ ", ", ", " },{ "!", "!" },{ "?", "?" },{ "/", "/" },{ "+", "+" },{ "-", "-" },{ "&", "&" },
                            //{ "^", "^" },{ "%", "%" },{ "*", "*" },{ "#", "#" },{ "$", "$" },{ "[", "[" },{ "]", "]" }};
                            actionKey = 8;
                            switch (e.KeyCode)
                            {
                                case Keys.OemPeriod:
                                    valueKey = 0;
                                    break;

                                case Keys.Oemcomma:
                                    valueKey = 1;
                                    break;

                                //case Keys.Oem???  
                                // Exclamation mark can only be a "Shift 1"?
                                //    valueKey = 2
                                //    break;

                                case Keys.OemQuestion:
                                    valueKey = 3;
                                    break;

                                //case Keys.Oem????
                                // Slash character
                                //    valueKey = 4;
                                //    break;

                                case Keys.Oemplus:
                                    valueKey = 5;
                                    break;

                                case Keys.OemMinus:
                                    valueKey = 6;
                                    break;

                                //case Keys.Oem????
                                // "&" only as shift 7?
                                //    valueKey = 7;
                                //    break;

                                //case Keys.OemQuestion?????
                                // "^" only as shift 6?
                                //    valueKey = 8;
                                //    break;

                                //case Keys.Oem????:
                                // "%" only as shift 5?
                                //    valueKey = 9;
                                //    break;

                                //case Keys.Oem????:
                                // "*" only as shift 8?
                                //    valueKey = 10;
                                //    break;

                                //case Keys.Oem????:
                                // "#" only as shift 7?
                                //    valueKey = 11;
                                //    break;

                                //case Keys.Oem????:
                                // "$" only as shift 4?
                                //    valueKey = 12;
                                //    break;

                                case Keys.OemOpenBrackets:
                                    valueKey = 13;
                                    break;

                                case Keys.OemCloseBrackets:
                                    valueKey = 14;
                                    break;


                                default:
                                    break;
                            }
                            break;

                        case KeyTypes.KeyTypeMediaApp:
                            // static string[,] mediakey_valueKeys_3 ={
                            //{ "Mute", "1" },{ "Volume Down", "2" },{ "Volume Up", "3" },{ "Play/Pause", "4" },{ "Stop", "5" },
                            //{ "Next", "6" },{ "Previous", "7" },{ "WWW Home", "8" },{ "File Browser", "9" },{ "Calculator", "10" },
                            //{ "WWW Bookmarks", "11" },{ "WWW Search", "12" },{ "WWW Stop", "13" },{ "WWW Back", "14" },
                            //{ "Cons Control", "15" },{ "Email App", "16" }};
                            actionKey = 3;
                            switch (e.KeyCode)
                            {
                                case Keys.VolumeMute:
                                    valueKey = 0;
                                    break;

                                case Keys.VolumeDown:
                                    valueKey = 1;
                                    break;

                                case Keys.VolumeUp:
                                    valueKey = 2;
                                    break;

                                case Keys.MediaPlayPause:
                                    valueKey = 3;
                                    break;

                                case Keys.MediaStop:
                                    valueKey = 4;
                                    break;

                                case Keys.MediaNextTrack:
                                    valueKey = 5;
                                    break;

                                case Keys.MediaPreviousTrack:
                                    valueKey = 6;
                                    break;

                                case Keys.BrowserHome:
                                    valueKey = 7;
                                    break;

                                //case Keys.Filebrower???:
                                //    valueKey = 8;
                                //    break;

                                //case Keys.Calculator???:
                                //    valueKey = 9;
                                //    break;

                                case Keys.BrowserFavorites:
                                    valueKey = 10;
                                    break;

                                case Keys.BrowserSearch:
                                    valueKey = 11;
                                    break;

                                case Keys.BrowserStop:
                                    valueKey = 12;
                                    break;

                                case Keys.BrowserBack:
                                    valueKey = 13;
                                    break;

                                case Keys.LaunchApplication1:
                                    valueKey = 14;
                                    break;

                                case Keys.LaunchMail:
                                    valueKey = 15;
                                    break;

                                default:
                                    break;
                            }
                            break;



                        case KeyTypes.KeyTypeMisc:
                            //static string[,] arrows_and_tab_valueKeys_2 = {
                            //{ "--", "0" },{ "UP Arrow", "1" },{ "DOWN Arrow", "2" },{ "LEFT Arrow", "3" },{ "RIGHT Arrow", "4" },
                            //{ "Backspace", "5" },{ "TAB", "6" },{ "Return", "7" },{ "Page Up", "8" },{ "Page Down", "9" },
                            //{ "Delete", "10" },{ "PrintScreen", "11" },{ "ESC", "12" },{ "HOME", "13" },{ "END", "14" }};
                            actionKey = 2;
                            switch (e.KeyCode)
                            {
                                case Keys.Up:
                                    valueKey = 1;
                                    break;

                                case Keys.Down:
                                    valueKey = 2;
                                    break;

                                case Keys.Left:
                                    valueKey = 3;
                                    break;

                                case Keys.Right:
                                    valueKey = 4;
                                    break;

                                case Keys.Back:
                                    valueKey = 5;
                                    break;

                                case Keys.Tab:
                                    valueKey = 6;
                                    break;

                                case Keys.Return:
                                    valueKey = 7;
                                    break;

                                case Keys.PageUp:
                                    valueKey = 8;
                                    break;

                                case Keys.PageDown:
                                    valueKey = 9;
                                    break;

                                case Keys.Delete:
                                    valueKey = 10;
                                    break;

                                case Keys.PrintScreen:
                                    valueKey = 11;
                                    break;

                                case Keys.Escape:
                                    valueKey = 12;
                                    break;

                                case Keys.Home:
                                    valueKey = 13;
                                    break;

                                case Keys.End:
                                    valueKey = 14;
                                    break;

                                default:
                                    valueKey = 0;
                                    break;
                            }
                            break;

                        default:
                            break;
                    }

                    // Handle special shift cases
                    //static string[,] special_char_valueKeys_8 ={
                    //{ ".", "." },{ ", ", ", " },{ "!", "!" },{ "?", "?" },{ "/", "/" },{ "+", "+" },{ "-", "-" },{ "&", "&" },
                    //{ "^", "^" },{ "%", "%" },{ "*", "*" },{ "#", "#" },{ "$", "$" },{ "[", "[" },{ "]", "]" }};
                    if ((actionHelper == 5) && (valueHelper == 1))
                    {

                        switch (e.KeyCode)
                        {

                            // "!" = Shift-1
                            case Keys.D1:
                                actionKey = 8;
                                valueKey = 2;
                                actionHelper = 0;
                                break;

                            // "/" = Shift-?
                            case Keys.OemQuestion:
                                actionKey = 8;
                                valueKey = 4;
                                actionHelper = 0;
                                break;

                            // "&" = Shift-7
                            case Keys.D7:
                                actionKey = 8;
                                valueKey = 7;
                                actionHelper = 0;
                                break;

                            // "^" = Shift-6
                            case Keys.D6:
                                actionKey = 8;
                                valueKey = 8;
                                actionHelper = 0;
                                break;

                            // "%" = Shift-5
                            case Keys.D5:
                                actionKey = 8;
                                valueKey = 9;
                                actionHelper = 0;
                                break;

                            // "*" = Shift-8
                            case Keys.D8:
                                actionKey = 8;
                                valueKey = 10;
                                actionHelper = 0;
                                break;

                            // "#" = Shift-3
                            case Keys.D3:
                                actionKey = 8;
                                valueKey = 11;
                                actionHelper = 0;
                                break;

                            // "$" = Shift-4
                            case Keys.D4:
                                actionKey = 8;
                                valueKey = 12;
                                actionHelper = 0;
                                break;

                            default:
                                break;

                        }
                    }


                    if (actionHelper == 0)
                    {
                        cbButtonAction0.SelectedIndex = actionKey;
                        cbButtonValue0.SelectedIndex = valueKey;
                        json_document_node["programs"][current_program]["buttons"][activeButtonNumber]["actionarray"][0] = cbButtonAction0.SelectedIndex.ToString();
                        json_document_node["programs"][current_program]["buttons"][activeButtonNumber]["valuearray"][0] = ActionHelpers.GetValue(cbButtonAction0.SelectedIndex, cbButtonValue0.SelectedIndex, 1);

                        data_changed = true;
                    }
                    else
                    {
                        cbButtonAction0.SelectedIndex = actionHelper;
                        cbButtonValue0.SelectedIndex = valueHelper;
                        json_document_node["programs"][current_program]["buttons"][activeButtonNumber]["actionarray"][0] = cbButtonAction0.SelectedIndex.ToString();
                        json_document_node["programs"][current_program]["buttons"][activeButtonNumber]["valuearray"][0] = ActionHelpers.GetValue(cbButtonAction0.SelectedIndex, cbButtonValue0.SelectedIndex, 1);

                        cbButtonAction1.SelectedIndex = actionKey;
                        cbButtonValue1.SelectedIndex = valueKey;
                        json_document_node["programs"][current_program]["buttons"][activeButtonNumber]["actionarray"][1] = cbButtonAction1.SelectedIndex.ToString();
                        json_document_node["programs"][current_program]["buttons"][activeButtonNumber]["valuearray"][1] = ActionHelpers.GetValue(cbButtonAction1.SelectedIndex, cbButtonValue1.SelectedIndex, 1);

                        data_changed = true;
                    }
                }
            }
        }
    }
}
