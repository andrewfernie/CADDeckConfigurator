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
        public static Color HexRGBToColor(String hex_color_string)
        {
            int[] color_int = { 0, 0, 0 };
            String color_string = hex_color_string;
            color_int[0] = Convert.ToInt32(color_string.Substring(1, 2), 16);
            color_int[1] = Convert.ToInt32(color_string.Substring(3, 2), 16);
            color_int[2] = Convert.ToInt32(color_string.Substring(5, 2), 16);
            return Color.FromArgb(color_int[0], color_int[1], color_int[2]);
        }

        public static string ColorToHexRGB(Color color)
        {
            string hex_color_string;
            hex_color_string = String.Format("#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B);
            return hex_color_string;
        }
    }
}
