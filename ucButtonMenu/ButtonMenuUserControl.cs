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
using Helpers;
using System.Text.Json;
using ButtonMenuUserControl;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.Json.Nodes;
using System.Xml.Linq;

namespace ButtonMenuUserControl
{
    public partial class ButtonMenuUserControl : UserControl
    {
        String project_folder;
        String file_name_with_path;
        String this_file;
        CJSONMenu json_structure;
        JsonNode json_document_node;
        JsonObject json_document_object;

        bool data_changed = false;


        public ButtonMenuUserControl()
        {
            InitializeComponent();
        }

        public void DisplayMenuNumber(int v)
        {
            cbMenuSelect.SelectedIndex = v;
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
            data_changed = false;

            InitializeLogos();
            InitializeLatchBox();
            InitializeLatchLogos();
            InitializeText();
            InitializeActions();
            InitializeValues();
        }
        private void bLocalSave_Click(object sender, EventArgs e)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json_structure_string = JsonSerializer.Serialize(json_document_object, options);
            File.WriteAllText(file_name_with_path + "_new", json_structure_string);
            data_changed = false;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            if (data_changed)
            {
                if (MessageBox.Show("Data has been modified. Are you sure you want to cancel?", "Infomate", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DisplayMenu(this_file);
                }
            }
        }
        public void InitializeLogos()
        {
            tbButton11Logo.Text = json_document_node["button11"]["logo"].ToString();
            tbButton12Logo.Text = json_document_node["button12"]["logo"].ToString();
            tbButton13Logo.Text = json_document_node["button13"]["logo"].ToString();
            tbButton14Logo.Text = json_document_node["button14"]["logo"].ToString();
            tbButton21Logo.Text = json_document_node["button21"]["logo"].ToString();
            tbButton22Logo.Text = json_document_node["button22"]["logo"].ToString();
            tbButton23Logo.Text = json_document_node["button23"]["logo"].ToString();
            tbButton24Logo.Text = json_document_node["button24"]["logo"].ToString();
            tbButton31Logo.Text = json_document_node["button31"]["logo"].ToString();
            tbButton32Logo.Text = json_document_node["button32"]["logo"].ToString();
            tbButton33Logo.Text = json_document_node["button33"]["logo"].ToString();
            tbButton34Logo.Text = json_document_node["button34"]["logo"].ToString();

        }
        public void InitializeLatchBox()
        {
            cbButton11Latch.Checked = ((bool)json_document_node["button11"]["latch"].AsValue());
            cbButton12Latch.Checked = ((bool)json_document_node["button12"]["latch"].AsValue());
            cbButton13Latch.Checked = ((bool)json_document_node["button13"]["latch"].AsValue());
            cbButton14Latch.Checked = ((bool)json_document_node["button14"]["latch"].AsValue());

            cbButton21Latch.Checked = ((bool)json_document_node["button21"]["latch"].AsValue());
            cbButton22Latch.Checked = ((bool)json_document_node["button22"]["latch"].AsValue());
            cbButton23Latch.Checked = ((bool)json_document_node["button23"]["latch"].AsValue());
            cbButton24Latch.Checked = ((bool)json_document_node["button24"]["latch"].AsValue());

            cbButton31Latch.Checked = ((bool)json_document_node["button31"]["latch"].AsValue());
            cbButton32Latch.Checked = ((bool)json_document_node["button32"]["latch"].AsValue());
            cbButton33Latch.Checked = ((bool)json_document_node["button33"]["latch"].AsValue());
            cbButton34Latch.Checked = ((bool)json_document_node["button34"]["latch"].AsValue());

        }

        public void InitializeLatchLogos()
        {
            tbButton11LatchLogo.Text = json_document_node["button11"]["latchlogo"].ToString();
            tbButton12LatchLogo.Text = json_document_node["button12"]["latchlogo"].ToString();
            tbButton13LatchLogo.Text = json_document_node["button13"]["latchlogo"].ToString();
            tbButton14LatchLogo.Text = json_document_node["button14"]["latchlogo"].ToString();
            tbButton21LatchLogo.Text = json_document_node["button21"]["latchlogo"].ToString();
            tbButton22LatchLogo.Text = json_document_node["button22"]["latchlogo"].ToString();
            tbButton23LatchLogo.Text = json_document_node["button23"]["latchlogo"].ToString();
            tbButton24LatchLogo.Text = json_document_node["button24"]["latchlogo"].ToString();
            tbButton31LatchLogo.Text = json_document_node["button31"]["latchlogo"].ToString();
            tbButton32LatchLogo.Text = json_document_node["button32"]["latchlogo"].ToString();
            tbButton33LatchLogo.Text = json_document_node["button33"]["latchlogo"].ToString();
            tbButton34LatchLogo.Text = json_document_node["button34"]["latchlogo"].ToString();
        }

        public void InitializeText()
        {
            string buttonText = "";

            if (json_document_object.ContainsKey("button11"))
            {
                if (json_document_object["button11"].AsObject().ContainsKey("buttontext"))
                {
                    buttonText = json_document_node["button11"]["buttontext"].ToString();

                }
            }
            tbButton11Text.Text = buttonText;

            buttonText = "";
            if (json_document_object.ContainsKey("button12"))
            {
                if (json_document_object["button12"].AsObject().ContainsKey("buttontext"))
                {
                    buttonText = json_document_node["button12"]["buttontext"].ToString();

                }
            }
            tbButton12Text.Text = buttonText;

            buttonText = "";
            if (json_document_object.ContainsKey("button13"))
            {
                if (json_document_object["button13"].AsObject().ContainsKey("buttontext"))
                {
                    buttonText = json_document_node["button13"]["buttontext"].ToString();

                }
            }
            tbButton13Text.Text = buttonText;

            buttonText = "";
            if (json_document_object.ContainsKey("button14"))
            {
                if (json_document_object["button14"].AsObject().ContainsKey("buttontext"))
                {
                    buttonText = json_document_node["button14"]["buttontext"].ToString();

                }
            }
            tbButton14Text.Text = buttonText;

            buttonText = "";

            if (json_document_object.ContainsKey("button21"))
            {
                if (json_document_object["button21"].AsObject().ContainsKey("buttontext"))
                {
                    buttonText = json_document_node["button21"]["buttontext"].ToString();

                }
            }
            tbButton21Text.Text = buttonText;

            buttonText = "";
            if (json_document_object.ContainsKey("button22"))
            {
                if (json_document_object["button22"].AsObject().ContainsKey("buttontext"))
                {
                    buttonText = json_document_node["button22"]["buttontext"].ToString();

                }
            }
            tbButton22Text.Text = buttonText;

            buttonText = "";
            if (json_document_object.ContainsKey("button23"))
            {
                if (json_document_object["button23"].AsObject().ContainsKey("buttontext"))
                {
                    buttonText = json_document_node["button23"]["buttontext"].ToString();

                }
            }
            tbButton23Text.Text = buttonText;

            buttonText = "";
            if (json_document_object.ContainsKey("button24"))
            {
                if (json_document_object["button24"].AsObject().ContainsKey("buttontext"))
                {
                    buttonText = json_document_node["button24"]["buttontext"].ToString();

                }
            }
            tbButton24Text.Text = buttonText;

            buttonText = "";

            if (json_document_object.ContainsKey("button31"))
            {
                if (json_document_object["button31"].AsObject().ContainsKey("buttontext"))
                {
                    buttonText = json_document_node["button31"]["buttontext"].ToString();

                }
            }
            tbButton31Text.Text = buttonText;

            buttonText = "";
            if (json_document_object.ContainsKey("button32"))
            {
                if (json_document_object["button32"].AsObject().ContainsKey("buttontext"))
                {
                    buttonText = json_document_node["button32"]["buttontext"].ToString();

                }
            }
            tbButton32Text.Text = buttonText;

            buttonText = "";
            if (json_document_object.ContainsKey("button33"))
            {
                if (json_document_object["button33"].AsObject().ContainsKey("buttontext"))
                {
                    buttonText = json_document_node["button33"]["buttontext"].ToString();

                }
            }
            tbButton33Text.Text = buttonText;

            buttonText = "";
            if (json_document_object.ContainsKey("button34"))
            {
                if (json_document_object["button34"].AsObject().ContainsKey("buttontext"))
                {
                    buttonText = json_document_node["button34"]["buttontext"].ToString();

                }
            }
            tbButton34Text.Text = buttonText;

        }
        public void InitializeActions()
        {
            InitializeAction(cbButton11Action0, json_document_node["button11"]["actionarray"][0].ToString());
            InitializeAction(cbButton11Action1, json_document_node["button11"]["actionarray"][1].ToString());
            InitializeAction(cbButton11Action2, json_document_node["button11"]["actionarray"][2].ToString());

            InitializeAction(cbButton12Action0, json_document_node["button12"]["actionarray"][0].ToString());
            InitializeAction(cbButton12Action1, json_document_node["button12"]["actionarray"][1].ToString());
            InitializeAction(cbButton12Action2, json_document_node["button12"]["actionarray"][2].ToString());

            InitializeAction(cbButton13Action0, json_document_node["button13"]["actionarray"][0].ToString());
            InitializeAction(cbButton13Action1, json_document_node["button13"]["actionarray"][1].ToString());
            InitializeAction(cbButton13Action2, json_document_node["button13"]["actionarray"][2].ToString());

            InitializeAction(cbButton14Action0, json_document_node["button14"]["actionarray"][0].ToString());
            InitializeAction(cbButton14Action1, json_document_node["button14"]["actionarray"][1].ToString());
            InitializeAction(cbButton14Action2, json_document_node["button14"]["actionarray"][2].ToString());

            InitializeAction(cbButton21Action0, json_document_node["button21"]["actionarray"][0].ToString());
            InitializeAction(cbButton21Action1, json_document_node["button21"]["actionarray"][1].ToString());
            InitializeAction(cbButton21Action2, json_document_node["button21"]["actionarray"][2].ToString());

            InitializeAction(cbButton22Action0, json_document_node["button22"]["actionarray"][0].ToString());
            InitializeAction(cbButton22Action1, json_document_node["button22"]["actionarray"][1].ToString());
            InitializeAction(cbButton22Action2, json_document_node["button22"]["actionarray"][2].ToString());

            InitializeAction(cbButton23Action0, json_document_node["button23"]["actionarray"][0].ToString());
            InitializeAction(cbButton23Action1, json_document_node["button23"]["actionarray"][1].ToString());
            InitializeAction(cbButton23Action2, json_document_node["button23"]["actionarray"][2].ToString());

            InitializeAction(cbButton24Action0, json_document_node["button24"]["actionarray"][0].ToString());
            InitializeAction(cbButton24Action1, json_document_node["button24"]["actionarray"][1].ToString());
            InitializeAction(cbButton24Action2, json_document_node["button24"]["actionarray"][2].ToString());

            InitializeAction(cbButton31Action0, json_document_node["button31"]["actionarray"][0].ToString());
            InitializeAction(cbButton31Action1, json_document_node["button31"]["actionarray"][1].ToString());
            InitializeAction(cbButton31Action2, json_document_node["button31"]["actionarray"][2].ToString());

            InitializeAction(cbButton32Action0, json_document_node["button32"]["actionarray"][0].ToString());
            InitializeAction(cbButton32Action1, json_document_node["button32"]["actionarray"][1].ToString());
            InitializeAction(cbButton32Action2, json_document_node["button32"]["actionarray"][2].ToString());

            InitializeAction(cbButton33Action0, json_document_node["button33"]["actionarray"][0].ToString());
            InitializeAction(cbButton33Action1, json_document_node["button33"]["actionarray"][1].ToString());
            InitializeAction(cbButton33Action2, json_document_node["button33"]["actionarray"][2].ToString());

            InitializeAction(cbButton34Action0, json_document_node["button34"]["actionarray"][0].ToString());
            InitializeAction(cbButton34Action1, json_document_node["button34"]["actionarray"][1].ToString());
            InitializeAction(cbButton34Action2, json_document_node["button34"]["actionarray"][2].ToString());

        }
        public void InitializeValues()
        {
            InitializeValue(cbButton11Action0, cbButton11Value0, json_document_node["button11"]["valuearray"][0].ToString());
            InitializeValue(cbButton11Action1, cbButton11Value1, json_document_node["button11"]["valuearray"][1].ToString());
            InitializeValue(cbButton11Action2, cbButton11Value2, json_document_node["button11"]["valuearray"][2].ToString());

            InitializeValue(cbButton12Action0, cbButton12Value0, json_document_node["button12"]["valuearray"][0].ToString());
            InitializeValue(cbButton12Action1, cbButton12Value1, json_document_node["button12"]["valuearray"][1].ToString());
            InitializeValue(cbButton12Action2, cbButton12Value2, json_document_node["button12"]["valuearray"][2].ToString());

            InitializeValue(cbButton13Action0, cbButton13Value0, json_document_node["button13"]["valuearray"][0].ToString());
            InitializeValue(cbButton13Action1, cbButton13Value1, json_document_node["button13"]["valuearray"][1].ToString());
            InitializeValue(cbButton13Action2, cbButton13Value2, json_document_node["button13"]["valuearray"][2].ToString());

            InitializeValue(cbButton14Action0, cbButton14Value0, json_document_node["button14"]["valuearray"][0].ToString());
            InitializeValue(cbButton14Action1, cbButton14Value1, json_document_node["button14"]["valuearray"][1].ToString());
            InitializeValue(cbButton14Action2, cbButton14Value2, json_document_node["button14"]["valuearray"][2].ToString());

            InitializeValue(cbButton21Action0, cbButton21Value0, json_document_node["button21"]["valuearray"][0].ToString());
            InitializeValue(cbButton21Action1, cbButton21Value1, json_document_node["button21"]["valuearray"][1].ToString());
            InitializeValue(cbButton21Action2, cbButton21Value2, json_document_node["button21"]["valuearray"][2].ToString());

            InitializeValue(cbButton22Action0, cbButton22Value0, json_document_node["button22"]["valuearray"][0].ToString());
            InitializeValue(cbButton22Action1, cbButton22Value1, json_document_node["button22"]["valuearray"][1].ToString());
            InitializeValue(cbButton22Action2, cbButton22Value2, json_document_node["button22"]["valuearray"][2].ToString());

            InitializeValue(cbButton23Action0, cbButton23Value0, json_document_node["button23"]["valuearray"][0].ToString());
            InitializeValue(cbButton23Action1, cbButton23Value1, json_document_node["button23"]["valuearray"][1].ToString());
            InitializeValue(cbButton23Action2, cbButton23Value2, json_document_node["button23"]["valuearray"][2].ToString());

            InitializeValue(cbButton24Action0, cbButton24Value0, json_document_node["button24"]["valuearray"][0].ToString());
            InitializeValue(cbButton24Action1, cbButton24Value1, json_document_node["button24"]["valuearray"][1].ToString());
            InitializeValue(cbButton24Action2, cbButton24Value2, json_document_node["button24"]["valuearray"][2].ToString());

            InitializeValue(cbButton31Action0, cbButton31Value0, json_document_node["button31"]["valuearray"][0].ToString());
            InitializeValue(cbButton31Action1, cbButton31Value1, json_document_node["button31"]["valuearray"][1].ToString());
            InitializeValue(cbButton31Action2, cbButton31Value2, json_document_node["button31"]["valuearray"][2].ToString());

            InitializeValue(cbButton32Action0, cbButton32Value0, json_document_node["button32"]["valuearray"][0].ToString());
            InitializeValue(cbButton32Action1, cbButton32Value1, json_document_node["button32"]["valuearray"][1].ToString());
            InitializeValue(cbButton32Action2, cbButton32Value2, json_document_node["button32"]["valuearray"][2].ToString());

            InitializeValue(cbButton33Action0, cbButton33Value0, json_document_node["button33"]["valuearray"][0].ToString());
            InitializeValue(cbButton33Action1, cbButton33Value1, json_document_node["button33"]["valuearray"][1].ToString());
            InitializeValue(cbButton33Action2, cbButton33Value2, json_document_node["button33"]["valuearray"][2].ToString());

            InitializeValue(cbButton34Action0, cbButton34Value0, json_document_node["button34"]["valuearray"][0].ToString());
            InitializeValue(cbButton34Action1, cbButton34Value1, json_document_node["button34"]["valuearray"][1].ToString());
            InitializeValue(cbButton34Action2, cbButton34Value2, json_document_node["button34"]["valuearray"][2].ToString());
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


        public void SetProjectFolder(String folder)
        {
            project_folder = folder;
        }
        private void cbButton11Action0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button11"]["actionarray"][0].ToString() != cbButton11Action0.SelectedIndex.ToString())
            {
                json_document_node["button11"]["actionarray"][0] = cbButton11Action0.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton11Action0, cbButton11Value0, "0");
            }
        }

        private void cbButton11Action1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button11"]["actionarray"][1].ToString() != cbButton11Action1.SelectedIndex.ToString())
            {
                json_document_node["button11"]["actionarray"][1] = cbButton11Action1.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton11Action1, cbButton11Value1, "0");
            }
        }

        private void cbButton11Action2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button11"]["actionarray"][2].ToString() != cbButton11Action2.SelectedIndex.ToString())
            {
                json_document_node["button11"]["actionarray"][2] = cbButton11Action2.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton11Action2, cbButton11Value2, "0");
            }
        }

        private void cbButton12Action0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button12"]["actionarray"][0].ToString() != cbButton12Action0.SelectedIndex.ToString())
            {
                json_document_node["button12"]["actionarray"][0] = cbButton12Action0.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton12Action0, cbButton12Value0, "0");
            }
        }

        private void cbButton12Action1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button12"]["actionarray"][1].ToString() != cbButton12Action1.SelectedIndex.ToString())
            {
                json_document_node["button12"]["actionarray"][1] = cbButton12Action1.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton12Action1, cbButton12Value1, "0");
            }
        }

        private void cbButton12Action2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button12"]["actionarray"][2].ToString() != cbButton12Action2.SelectedIndex.ToString())
            {
                json_document_node["button12"]["actionarray"][2] = cbButton12Action2.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton12Action2, cbButton12Value2, "0");
            }
        }

        private void cbButton13Action0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button13"]["actionarray"][0].ToString() != cbButton13Action0.SelectedIndex.ToString())
            {
                json_document_node["button13"]["actionarray"][0] = cbButton13Action0.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton13Action0, cbButton13Value0, "0");
            }
        }

        private void cbButton13Action1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button13"]["actionarray"][1].ToString() != cbButton13Action1.SelectedIndex.ToString())
            {
                json_document_node["button13"]["actionarray"][1] = cbButton13Action1.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton13Action1, cbButton13Value1, "0");
            }
        }

        private void cbButton13Action2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button13"]["actionarray"][2].ToString() != cbButton13Action2.SelectedIndex.ToString())
            {
                json_document_node["button13"]["actionarray"][2] = cbButton13Action2.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton13Action2, cbButton13Value2, "0");
            }
        }

        private void cbButton14Action0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button14"]["actionarray"][0].ToString() != cbButton14Action0.SelectedIndex.ToString())
            {
                json_document_node["button14"]["actionarray"][0] = cbButton14Action0.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton14Action0, cbButton14Value0, "0");
            }
        }

        private void cbButton14Action1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button14"]["actionarray"][1].ToString() != cbButton14Action1.SelectedIndex.ToString())
            {
                json_document_node["button14"]["actionarray"][1] = cbButton14Action1.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton14Action1, cbButton14Value1, "0");
            }
        }

        private void cbButton14Action2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button14"]["actionarray"][2].ToString() != cbButton14Action2.SelectedIndex.ToString())
            {
                json_document_node["button14"]["actionarray"][2] = cbButton14Action2.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton14Action2, cbButton14Value2, "0");
            }
        }

        private void cbButton11Value0_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button11"]["valuearray"][0] = ActionHelpers.GetValue(cbButton11Action0.SelectedIndex, cbButton11Value0.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButton11Value1_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button11"]["valuearray"][1] = ActionHelpers.GetValue(cbButton11Action1.SelectedIndex, cbButton11Value1.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButton11Value2_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button11"]["valuearray"][2] = ActionHelpers.GetValue(cbButton11Action2.SelectedIndex, cbButton11Value2.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButton12Value0_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button12"]["valuearray"][0] = ActionHelpers.GetValue(cbButton12Action0.SelectedIndex, cbButton12Value0.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButton12Value1_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button12"]["valuearray"][1] = ActionHelpers.GetValue(cbButton12Action1.SelectedIndex, cbButton12Value1.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButton12Value2_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button12"]["valuearray"][2] = ActionHelpers.GetValue(cbButton12Action2.SelectedIndex, cbButton12Value2.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButton13Value0_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button13"]["valuearray"][0] = ActionHelpers.GetValue(cbButton13Action0.SelectedIndex, cbButton13Value0.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButton13Value1_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button13"]["valuearray"][1] = ActionHelpers.GetValue(cbButton13Action1.SelectedIndex, cbButton13Value1.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButton13Value2_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button13"]["valuearray"][2] = ActionHelpers.GetValue(cbButton13Action2.SelectedIndex, cbButton13Value2.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButton14Value0_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button14"]["valuearray"][0] = ActionHelpers.GetValue(cbButton14Action0.SelectedIndex, cbButton14Value0.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButton14Value1_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button14"]["valuearray"][1] = ActionHelpers.GetValue(cbButton14Action1.SelectedIndex, cbButton14Value1.SelectedIndex, 1);
            data_changed = true;
        }
        private void cbButton14Value2_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button14"]["valuearray"][2] = ActionHelpers.GetValue(cbButton14Action2.SelectedIndex, cbButton14Value2.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButton21Action0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button21"]["actionarray"][0].ToString() != cbButton21Action0.SelectedIndex.ToString())
            {
                json_document_node["button21"]["actionarray"][0] = cbButton21Action0.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton21Action0, cbButton21Value0, "0");
            }
        }

        private void cbButton21Action1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button21"]["actionarray"][1].ToString() != cbButton21Action1.SelectedIndex.ToString())
            {
                json_document_node["button21"]["actionarray"][1] = cbButton21Action1.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton21Action1, cbButton21Value1, "0");
            }
        }

        private void cbButton21Action2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button21"]["actionarray"][2].ToString() != cbButton21Action2.SelectedIndex.ToString())
            {
                json_document_node["button21"]["actionarray"][2] = cbButton21Action2.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton21Action2, cbButton21Value2, "0");
            }
        }

        private void cbButton22Action0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button22"]["actionarray"][0].ToString() != cbButton22Action0.SelectedIndex.ToString())
            {
                json_document_node["button22"]["actionarray"][0] = cbButton22Action0.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton22Action0, cbButton22Value0, "0");
            }
        }

        private void cbButton22Action1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button22"]["actionarray"][1].ToString() != cbButton22Action1.SelectedIndex.ToString())
            {
                json_document_node["button22"]["actionarray"][1] = cbButton22Action1.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton22Action1, cbButton22Value1, "0");
            }
        }

        private void cbButton22Action2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button22"]["actionarray"][2].ToString() != cbButton22Action2.SelectedIndex.ToString())
            {
                json_document_node["button22"]["actionarray"][2] = cbButton22Action2.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton22Action2, cbButton22Value2, "0");
            }
        }

        private void cbButton23Action0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button23"]["actionarray"][0].ToString() != cbButton23Action0.SelectedIndex.ToString())
            {
                json_document_node["button23"]["actionarray"][0] = cbButton23Action0.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton23Action0, cbButton23Value0, "0");
            }
        }

        private void cbButton23Action1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button23"]["actionarray"][1].ToString() != cbButton23Action1.SelectedIndex.ToString())
            {
                json_document_node["button23"]["actionarray"][1] = cbButton23Action1.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton23Action1, cbButton23Value1, "0");
            }
        }

        private void cbButton23Action2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button23"]["actionarray"][2].ToString() != cbButton23Action2.SelectedIndex.ToString())
            {
                json_document_node["button23"]["actionarray"][2] = cbButton23Action2.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton23Action2, cbButton23Value2, "0");
            }
        }

        private void cbButton24Action0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button24"]["actionarray"][0].ToString() != cbButton24Action0.SelectedIndex.ToString())
            {
                json_document_node["button24"]["actionarray"][0] = cbButton24Action0.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton24Action0, cbButton24Value0, "0");
            }
        }

        private void cbButton24Action1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button24"]["actionarray"][1].ToString() != cbButton24Action1.SelectedIndex.ToString())
            {
                json_document_node["button24"]["actionarray"][1] = cbButton24Action1.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton24Action1, cbButton24Value1, "0");
            }
        }

        private void cbButton24Action2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button24"]["actionarray"][2].ToString() != cbButton24Action2.SelectedIndex.ToString())
            {
                json_document_node["button24"]["actionarray"][2] = cbButton24Action2.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton24Action2, cbButton24Value2, "0");
            }
        }

        private void cbButton21Value0_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button21"]["valuearray"][0] = ActionHelpers.GetValue(cbButton21Action0.SelectedIndex, cbButton21Value0.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButton21Value1_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button21"]["valuearray"][1] = ActionHelpers.GetValue(cbButton21Action1.SelectedIndex, cbButton21Value1.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButton21Value2_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button21"]["valuearray"][2] = ActionHelpers.GetValue(cbButton21Action2.SelectedIndex, cbButton21Value2.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButton22Value0_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button22"]["valuearray"][0] = ActionHelpers.GetValue(cbButton22Action0.SelectedIndex, cbButton22Value0.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButton22Value1_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button22"]["valuearray"][1] = ActionHelpers.GetValue(cbButton22Action1.SelectedIndex, cbButton22Value1.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButton22Value2_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button22"]["valuearray"][2] = ActionHelpers.GetValue(cbButton22Action2.SelectedIndex, cbButton22Value2.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButton23Value0_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button23"]["valuearray"][0] = ActionHelpers.GetValue(cbButton23Action0.SelectedIndex, cbButton23Value0.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButton23Value1_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button23"]["valuearray"][1] = ActionHelpers.GetValue(cbButton23Action1.SelectedIndex, cbButton23Value1.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButton23Value2_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button23"]["valuearray"][2] = ActionHelpers.GetValue(cbButton23Action2.SelectedIndex, cbButton23Value2.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButton24Value0_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button24"]["valuearray"][0] = ActionHelpers.GetValue(cbButton24Action0.SelectedIndex, cbButton24Value0.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButton24Value1_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button24"]["valuearray"][1] = ActionHelpers.GetValue(cbButton24Action1.SelectedIndex, cbButton24Value1.SelectedIndex, 1);
            data_changed = true;
        }
        private void cbButton24Value2_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button24"]["valuearray"][2] = ActionHelpers.GetValue(cbButton24Action2.SelectedIndex, cbButton24Value2.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButton31Action0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button31"]["actionarray"][0].ToString() != cbButton31Action0.SelectedIndex.ToString())
            {
                json_document_node["button31"]["actionarray"][0] = cbButton31Action0.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton31Action0, cbButton31Value0, "0");
            }
        }

        private void cbButton31Action1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button31"]["actionarray"][1].ToString() != cbButton31Action1.SelectedIndex.ToString())
            {
                json_document_node["button31"]["actionarray"][1] = cbButton31Action1.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton31Action1, cbButton31Value1, "0");
            }
        }

        private void cbButton31Action2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button31"]["actionarray"][2].ToString() != cbButton31Action2.SelectedIndex.ToString())
            {
                json_document_node["button31"]["actionarray"][2] = cbButton31Action2.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton31Action2, cbButton31Value2, "0");
            }
        }

        private void cbButton32Action0_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (json_document_node["button32"]["actionarray"][0].ToString() != cbButton32Action0.SelectedIndex.ToString())
            {
                json_document_node["button32"]["actionarray"][0] = cbButton32Action0.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton32Action0, cbButton32Value0, "0");
            }
        }

        private void cbButton32Action1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button32"]["actionarray"][1].ToString() != cbButton32Action1.SelectedIndex.ToString())
            {
                json_document_node["button32"]["actionarray"][1] = cbButton32Action1.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton32Action1, cbButton32Value1, "0");
            }
        }

        private void cbButton32Action2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button32"]["actionarray"][2].ToString() != cbButton32Action2.SelectedIndex.ToString())
            {
                json_document_node["button32"]["actionarray"][2] = cbButton32Action2.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton32Action2, cbButton32Value2, "0");
            }
        }

        private void cbButton33Action0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button33"]["actionarray"][0].ToString() != cbButton33Action0.SelectedIndex.ToString())
            {
                json_document_node["button33"]["actionarray"][0] = cbButton33Action0.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton33Action0, cbButton33Value0, "0");
            }
        }

        private void cbButton33Action1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button33"]["actionarray"][1].ToString() != cbButton33Action1.SelectedIndex.ToString())
            {
                json_document_node["button33"]["actionarray"][1] = cbButton33Action1.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton33Action1, cbButton33Value1, "0");
            }
        }

        private void cbButton33Action2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button33"]["actionarray"][2].ToString() != cbButton33Action2.SelectedIndex.ToString())
            {
                json_document_node["button33"]["actionarray"][2] = cbButton33Action2.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton33Action2, cbButton33Value2, "0");
            }
        }

        private void cbButton34Action0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button34"]["actionarray"][0].ToString() != cbButton34Action0.SelectedIndex.ToString())
            {
                json_document_node["button34"]["actionarray"][0] = cbButton34Action0.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton34Action0, cbButton34Value0, "0");
            }
        }

        private void cbButton34Action1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button34"]["actionarray"][1].ToString() != cbButton34Action1.SelectedIndex.ToString())
            {
                json_document_node["button34"]["actionarray"][1] = cbButton34Action1.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton34Action1, cbButton34Value1, "0");
            }
        }

        private void cbButton34Action2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (json_document_node["button34"]["actionarray"][2].ToString() != cbButton34Action2.SelectedIndex.ToString())
            {
                json_document_node["button34"]["actionarray"][2] = cbButton34Action2.SelectedIndex.ToString();
                data_changed = true;
                InitializeValue(cbButton34Action2, cbButton34Value2, "0");
            }
        }

        private void cbButton31Value0_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button31"]["valuearray"][0] = ActionHelpers.GetValue(cbButton31Action0.SelectedIndex, cbButton31Value0.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButton31Value1_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button31"]["valuearray"][1] = ActionHelpers.GetValue(cbButton31Action1.SelectedIndex, cbButton31Value1.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButton31Value2_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button31"]["valuearray"][2] = ActionHelpers.GetValue(cbButton31Action2.SelectedIndex, cbButton31Value2.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButton32Value0_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button32"]["valuearray"][0] = ActionHelpers.GetValue(cbButton32Action0.SelectedIndex, cbButton32Value0.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButton32Value1_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button32"]["valuearray"][1] = ActionHelpers.GetValue(cbButton32Action1.SelectedIndex, cbButton32Value1.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButton32Value2_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button32"]["valuearray"][2] = ActionHelpers.GetValue(cbButton32Action2.SelectedIndex, cbButton32Value2.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButton33Value0_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button33"]["valuearray"][0] = ActionHelpers.GetValue(cbButton33Action0.SelectedIndex, cbButton33Value0.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButton33Value1_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button33"]["valuearray"][1] = ActionHelpers.GetValue(cbButton33Action1.SelectedIndex, cbButton33Value1.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButton33Value2_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button33"]["valuearray"][2] = ActionHelpers.GetValue(cbButton33Action2.SelectedIndex, cbButton33Value2.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButton34Value0_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button34"]["valuearray"][0] = ActionHelpers.GetValue(cbButton34Action0.SelectedIndex, cbButton34Value0.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbButton34Value1_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button34"]["valuearray"][1] = ActionHelpers.GetValue(cbButton34Action1.SelectedIndex, cbButton34Value1.SelectedIndex, 1);
            data_changed = true;
        }
        private void cbButton34Value2_SelectedIndexChanged(object sender, EventArgs e)
        {
            json_document_node["button34"]["valuearray"][2] = ActionHelpers.GetValue(cbButton34Action2.SelectedIndex, cbButton34Value2.SelectedIndex, 1);
            data_changed = true;
        }

        private void cbMenuSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayMenuNumber(cbMenuSelect.SelectedIndex);
            tbMenuName.Text = json_structure.menuname;
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

        private void tbMenuName_Leave(object sender, EventArgs e)
        {
            json_structure.menuname = tbMenuName.Text;
            data_changed = true;
        }

        private void tbButtonLogo_DoubleClick(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox box = sender as System.Windows.Forms.TextBox;
            
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
                box.Text = openFileDialog1.SafeFileName;

                // the textbox name is of the form "tbButtonNNLogo" and we need to get "buttonNN"
                string thisButtonName = box.Name.Substring(2, 8).ToLower();
                JsonObject buttonObject = json_document_object[thisButtonName].AsObject();
                buttonObject["logo"] = box.Text;

                data_changed = true;
            }
        }
        
        private void tbButtonLatchLogo_DoubleClick(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox box = sender as System.Windows.Forms.TextBox;
            
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
                string field_name_string= "$\"ButtonXX latchlogo after: {json_structure?.";
                field_name_string += "button12";
                field_name_string += ".latchlogo}\"";

                box.Text = openFileDialog1.SafeFileName;

                // the textbox name is of the form "tbButtonNNLatchLogo" and we need to get "buttonNN"
                string thisButtonName = box.Name.Substring(2, 8).ToLower();
                JsonObject buttonObject = json_document_node[thisButtonName].AsObject();
                buttonObject["latchlogo"] = box.Text;
                data_changed = true;
            }
        }


        private void tbButton11Text_Leave(object sender, EventArgs e)
        {
            json_document_node["button11"]["buttontext"] = tbButton11Text.Text;
            data_changed = true;
        }

        private void cbButton11Latch_CheckedChanged(object sender, EventArgs e)
        {
            json_document_node["button11"]["latch"] = cbButton11Latch.Checked;
            data_changed = true;
        }
 
        private void tbButton12Text_Leave(object sender, EventArgs e)
        {
            json_document_node["button12"]["buttontext"] = tbButton12Text.Text;
            data_changed = true;
        }

  
        private void cbButton12Latch_CheckedChanged(object sender, EventArgs e)
        {
            json_document_node["button12"]["latch"] = cbButton12Latch.Checked;
            data_changed = true;
        }
   

        private void tbButton13Text_Leave(object sender, EventArgs e)
        {
            json_document_node["button13"]["buttontext"] = tbButton13Text.Text;
            data_changed = true;
        }

  
        private void cbButton13Latch_CheckedChanged(object sender, EventArgs e)
        {
            json_document_node["button13"]["latch"] = cbButton13Latch.Checked;
            data_changed = true;
        }
      

        private void tbButton14Text_Leave(object sender, EventArgs e)
        {
            json_document_node["button14"]["buttontext"] = tbButton14Text.Text;
            data_changed = true;
        }

   
        private void cbButton14Latch_CheckedChanged(object sender, EventArgs e)
        {
            json_document_node["button14"]["latch"] = cbButton14Latch.Checked;
            data_changed = true;
        }
      

        private void tbButton21Text_Leave(object sender, EventArgs e)
        {
            json_document_node["button21"]["buttontext"] = tbButton21Text.Text;
            data_changed = true;
        }

     
        private void cbButton21Latch_CheckedChanged(object sender, EventArgs e)
        {
            json_document_node["button21"]["latch"] = cbButton21Latch.Checked;
            data_changed = true;
        }
      

        private void tbButton22Text_Leave(object sender, EventArgs e)
        {
            json_document_node["button22"]["buttontext"] = tbButton22Text.Text;
            data_changed = true;
        }

            private void cbButton22Latch_CheckedChanged(object sender, EventArgs e)
        {
            json_document_node["button22"]["latch"] = cbButton22Latch.Checked;
            data_changed = true;
        }
  
        private void tbButton23Text_Leave(object sender, EventArgs e)
        {
            json_document_node["button23"]["buttontext"] = tbButton23Text.Text;
            data_changed = true;
        }

      
        private void cbButton23Latch_CheckedChanged(object sender, EventArgs e)
        {
            json_document_node["button23"]["latch"] = cbButton23Latch.Checked;
            data_changed = true;
        }
    
        private void tbButton24Text_Leave(object sender, EventArgs e)
        {
            json_document_node["button24"]["buttontext"] = tbButton24Text.Text;
            data_changed = true;
        }

    
        private void cbButton24Latch_CheckedChanged(object sender, EventArgs e)
        {
            json_document_node["button24"]["latch"] = cbButton24Latch.Checked;
            data_changed = true;
        }
      
        private void tbButton31Text_Leave(object sender, EventArgs e)
        {
            json_document_node["button31"]["buttontext"] = tbButton31Text.Text;
            data_changed = true;
        }

      
        private void cbButton31Latch_CheckedChanged(object sender, EventArgs e)
        {
            json_document_node["button31"]["latch"] = cbButton31Latch.Checked;
            data_changed = true;
        }
      

        private void tbButton32Text_Leave(object sender, EventArgs e)
        {
            json_document_node["button32"]["buttontext"] = tbButton32Text.Text;
            data_changed = true;
        }

    
        private void cbButton32Latch_CheckedChanged(object sender, EventArgs e)
        {
            json_document_node["button32"]["latch"] = cbButton32Latch.Checked;
            data_changed = true;
        }
    
        private void tbButton33Text_Leave(object sender, EventArgs e)
        {
            json_document_node["button33"]["buttontext"] = tbButton33Text.Text;
            data_changed = true;
        }

       
        private void cbButton33Latch_CheckedChanged(object sender, EventArgs e)
        {
            json_document_node["button33"]["latch"] = cbButton33Latch.Checked;
            data_changed = true;
        }
      

        private void tbButton34Text_Leave(object sender, EventArgs e)
        {
            json_document_node["button34"]["buttontext"] = tbButton34Text.Text;
            data_changed = true;
        }

     
        private void cbButton34Latch_CheckedChanged(object sender, EventArgs e)
        {
            json_document_node["button34"]["latch"] = cbButton34Latch.Checked;
            data_changed = true;
        }
         }

}
