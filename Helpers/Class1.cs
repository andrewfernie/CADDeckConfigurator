using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Helpers
{
    public static class ColorHelpers
    {
        public static Color ConvertFromHexRGB(string hex_color_string)
        {
            int[] color_int = { 0, 0, 0 };
            string color_string = hex_color_string;
            color_int[0] = Convert.ToInt32(color_string.Substring(1, 2), 16);
            color_int[1] = Convert.ToInt32(color_string.Substring(3, 2), 16);
            color_int[2] = Convert.ToInt32(color_string.Substring(5, 2), 16);
            return Color.FromArgb(color_int[0], color_int[1], color_int[2]);
        }
    }
}