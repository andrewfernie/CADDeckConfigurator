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

namespace ucGeneral
{
    public partial class ucGeneral : UserControl
    {
        CJSONGeneral json_general;

        public ucGeneral()
        {
            InitializeComponent();
        }

        private void bSave_Click(object sender, EventArgs e)
        {

        }

        private void bCancel_Click(object sender, EventArgs e)
        {

        }

        public void SendJSONString(string jsonString)
        {
            json_general = JsonSerializer.Deserialize<CJSONGeneral>(jsonString);

            tbMenuColorSample.BackColor = ConvertFromHexRGB(json_general.menubuttoncolor);

        }

        private void tbMenuColorSample_DoubleClick(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            tbMenuColorSample.BackColor = colorDialog1.Color;
        }

        private void tbFunctionColorSample_Click(object sender, EventArgs e)
        {

        }

        private void tbLatchColorSample_Click(object sender, EventArgs e)
        {

        }

        private void tbBackgroundColorSample_Click(object sender, EventArgs e)
        {

        }
    }

}
