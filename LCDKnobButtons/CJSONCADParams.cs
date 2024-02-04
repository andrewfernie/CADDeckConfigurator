using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCDKnobButtons
{

    public class CJSONCADParams
    {
        public int version { get; set; }
        public float joy_scale_x { get; set; }
        public float joy_scale_y { get; set; }
        public float joy_deadzone { get; set; }
        public int joy_sensitivity { get; set; }
        public float zoom_scale { get; set; }
        public float zoom_deadzone { get; set; }
        public int zoom_sensitivity { get; set; }
        public float rotate_scale { get; set; }
        public float rotate_deadzone { get; set; }
        public int rotate_sensitivity { get; set; }
        public int mouse_sensitivity { get; set; }
        public int current_program { get; set; }
        public bool spacemouse_enable { get; set; }
        public CADProgram[] programs { get; set; }
    }

    public class CADProgram
    {
        public string name { get; set; }
        public string logo { get; set; }
        public int default_joystick_mode { get; set; }
        public Button[] buttons { get; set; }
        public Lcdknob_Buttons[] lcdknob_buttons { get; set; }
    }

    public class Button
    {
        public string name { get; set; }
        public string description { get; set; }
        public string[] actionarray { get; set; }
        public string[] valuearray { get; set; }
    }

    public class Lcdknob_Buttons
    {
        public string name { get; set; }
        public string description { get; set; }
        public string[] actionarray { get; set; }
        public string[] valuearray { get; set; }
    }

}
