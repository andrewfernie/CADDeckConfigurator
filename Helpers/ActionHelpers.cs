using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Helpers
{
    public static class ActionHelpers
    {
        static string[,] donothing_values_0 = {
            { "--", "0" }};

        static string[,] delay_values_1 = {
            { "100ms", "100" }, { "200ms", "200" }, { "500ms", "500" }, { "1000ms", "1000" } };

        static string[,] arrows_and_tab_values_2 = {
            { "--", "0" },{ "UP Arrow", "1" },{ "DOWN Arrow", "2" },{ "LEFT Arrow", "3" },{ "RIGHT Arrow", "4" },
            { "Backspace", "5" },{ "TAB", "6" },{ "Return", "7" },{ "Page Up", "8" },{ "Page Down", "9" },
            { "Delete", "10" },{ "PrintScreen", "11" },{ "ESC", "12" },{ "HOME", "13" },{ "END", "14" }};

        static string[,] mediakey_values_3 ={
            { "Mute", "1" },{ "Volume Down", "2" },{ "Volume Up", "3" },{ "Play/Pause", "4" },{ "Stop", "5" },
            { "Next", "6" },{ "Previous", "7" },{ "WWW Home", "8" },{ "File Browser", "9" },{ "Calculator", "10" },
            { "WWW Bookmarks", "11" },{ "WWW Search", "12" },{ "WWW Stop", "13" },{ "WWW Back", "14" },
            { "Cons Control", "15" },{ "Email App", "16" }};

        static string[,] letter_values_4 ={
            { "-space-", " " },{ "a", "a" },{ "b", "b" },{ "c", "c" },{ "d", "d" },{ "e", "e" },
            { "f", "f" },{ "g", "g" },{ "h", "h" },{ "i", "i" },{ "j", "j" },{ "k", "k" },{ "l", "l" },
            { "m", "m" },{ "n", "n" },{ "o", "o" },{ "p", "p" },{ "q", "q" },{ "r", "r" },{ "s", "s" },
            { "t", "t" },{ "u", "u" },{ "v", "v" },{ "w", "w" },{ "x", "x" },{ "y", "y" },{ "z", "z" }};

        static string[,] option_key_values_5 ={
            { "Left CTRL", "1" },{ "Left Shift", "2" },{ "Left ALT", "3" },{ "Left GUI", "4" },
            { "Right CTRL", "5" },{ "Right Shift", "6" },{ "Right ALT", "7" },{ "Right GUI", "8" },
            { "Release All", "9" }};

        static string[,] functionkey_values_6 ={
            { "F1", "1" },{ "F2", "2" },{ "F3", "3" },{ "F4", "4" },{ "F5", "5" },{ "F6", "6" },{ "F7", "7" },
            { "F8", "8" },{ "F9", "9" },{ "F10", "10" },{ "F11", "11" },{ "F12", "12" },{ "F13", "13" },{ "F14", "14" },
            { "F15", "15" },{ "F16", "16" },{ "F17", "17" },{ "F18", "18" },{ "F19", "19" },{ "F20", "20" },{ "F21", "21" },
            { "F22", "22" },{ "F23", "23" },{ "F24", "24" }};

        static string[,] number_values_7 ={
            { "0", "0" },{ "1", "1" },{ "2", "2" },{ "3", "3" },{ "4", "4" },
            { "5", "5" },{ "6", "6" },{ "7", "7" },{ "8", "8" },{ "9", "9" }};

        static string[,] special_char_values_8 ={
            { ".", "." },{ ", ", ", " },{ "!", "!" },{ "?", "?" },{ "/", "/" },{ "+", "+" },{ "-", "-" },{ "&", "&" },
            { "^", "^" },{ "%", "%" },{ "*", "*" },{ "#", "#" },{ "$", "$" },{ "[", "[" },{ "]", "]" }};

        static string[,] combo_values_9 ={
            { "LEFT CTRL+SHIFT", "1" },{ "LEFT ALT+SHIFT", "2" },{ "LEFT GUI+SHIFT", "3" },{ "LEFT CTRL+GUI", "4" },
            { "LEFT ALT+GUI", "5" },{ "LEFT CTRL+ALT", "6" },{ "LEFT CTRL+ALT+GUI", "7" },{ "RIGHT CTRL+SHIFT", "8" },
            { "RIGHT ALT+SHIFT", "9" },{ "RIGHT GUI+SHIFT", "10" },{ "RIGHT CTRL+GUI", "11" },{ "RIGHT ALT+GUI", "12" },
            { "RIGHT CTRL+ALT", "13" },{ "RIGHT CTRL+ALT+GUI", "14" }};

        static string[,] helper_values_10 ={
            { "Helper 1", "1" },{ "Helper 2", "2" },{ "Helper 3", "3" },{ "Helper 4", "4" },{ "Helper 5", "5" },
            { "Helper 6", "6" },{ "Helper 7", "7" },{ "Helper 8", "8" },{ "Helper 9", "9" },{ "Helper 10", "10" },
            { "Helper 11", "11" }};

        static string[,] ftd_function_values_11 ={
            { "Config Mode", "1" }, { "Brightness Up", "2" }, { "Brightness Down", "3" },
            { "Enable/Disable Sleep", "4" }, { "Info Page", "5" }, { "Goto Menu 0 (Home)", "6" },
            { "Save General Config", "7" }, { "Enable USB Comms", "8" }, { "IO Monitor Page", "9" },
            { "Toggle GPIO Pin", "10" }, { "Set GPIO Pin Low", "11" }, { "Set GPIO Pin High", "12" },
            { "Button Info Page", "13" }, { "Spacemouse Enable", "14"}};

        static string[,] numpad_values_12 ={
            { "Numpad 0", "0" }, { "Numpad 1", "1" }, { "Numpad 2", "2" }, { "Numpad 3", "3" },
            { "Numpad 4", "4" }, { "Numpad 5", "5" }, { "Numpad 6", "6" }, { "Numpad 7", "7" },
            { "Numpad 8", "8" }, { "Numpad 9", "9" }, { "Numpad /", "10" }, { "Numpad *", "11" },
            { "Numpad -", "12" }, { "Numpad +", "13" }, { "Numpad RETURN", "14" }, { "Numpad .", "15" }};

        static string[,] useraction_values_13 ={
            { "Action 1", "1" }, { "Action 2", "2" }, { "Action 3", "3" }, { "Action 4", "4" },
            { "Action 5", "5" }, { "Action 6", "6" }, { "Action 7", "7" }};

        static string[,] gotopage_values_14 ={
            { "Page 0", "0" }, { "Page 1", "1" }, { "Page 2", "2" }, { "Page 3", "3" }, { "Page 4", "4" },
            { "Page 5", "5" }, { "Page 6", "6" }, { "Page 7", "7" }, { "Page 8", "8" }, { "Page 9", "9" }};

        static string[,] cadfunction_values_15 ={
            { "Set Program", "1" }, { "Joystick Zero", "2" }, { "Joystick Scale", "3" }, { "Zoom Scale", "4" },
            { "Rotate Scale", "5" }, { "Joystick Invert X", "6" }, { "Joystick Invert Y", "7" }, { "Zoom Invert", "8" },
            { "Rotate Invert", "9" }, { "Save Settings", "10" }, { "Mode Button", "15" },
            { "Set Mode Rotate", "16" }, { "Set Mode Move", "17" }};

        static string[,] cadprogram_values_16 ={
            { "Solidworks", "0" }, { "Fusion 360", "1" }, { "Blender", "2" },
            { "FreeCAD", "3" }, { "AC3D", "4" }};

        static string[,] mousebutton_values_17 ={
            { "Press Left Button", "1" }, { "Press Right Button", "2" }, { "Press Middle Button", "3" },
            { "Press Left and Middle Buttons", "4" }, { "Press Right and Middle Buttons", "5" }, { "Release Left Button", "6" },
            { "Release Right Button", "7" }, { "Release Middle Button", "8" }, { "Release Left and Middle Buttons", "9" },
            { "Release Right and Middle Buttons", "10" }, { "Release All Buttons", "11" }};

        static string[,] previouspage_values_18 ={
            { "No Action", "0" }};

        static string[,] default_joystick_mode_values_19 ={
            { "None", "0" }, { "Pan", "1" }, { "Rotate", "2" }, { "Zoom", "3" }, { "Mouse", "4" }};

        static string[,] spacemouse_button_values_20 ={
            { "Button 1", "1" }, { "Button 2", "2" }, { "Button 3", "3" }, { "Button 4", "4" },
            { "Button 5", "5" }, { "Button 6", "6" }, { "Button 7", "7" }, { "Button 8", "8" },
            { "Button 9", "9" }, { "Button 10", "10" }, { "Button 11", "11" }, { "Button 12", "12" },
            { "Button 13", "13" }, { "Button 14", "14" }, { "Button 15", "15" }};

        static string[,] action_option = {
            { "Do Nothing", "0" }, { "Delay", "1"}, { "Arrows and Tab", "2"}, { "Mediakey", "3" },
            { "Letters", "4" }, { "Option Keys", "5" }, { "Function Keys", "6" }, { "Numbers", "7" },
            { "Special Chars", "8" }, { "Combo", "9" }, { "Helper", "10" }, { "FTD Functions", "11" },
            { "Numpad", "12" }, { "User Actions", "13" }, { "Goto Page", "14" }, { "CAD Functions", "15" },
            { "CAD Programs", "16" }, { "Mouse Buttons", "17" }, { "Previous Page", "18" },
            { "Default Joystick Mode", "19" }, { "Spacemouse Buttons", "20" }};

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

        public class ActionsAndValues
        {
            public int action0;
            public int value0;
            public int action1;
            public int value1;
            public int action2;
            public int value2;
        }

        public static int GetNumberOfValues(int action_type)
        {
            int number_of_values = -1;
            switch (action_type)
            {
                case 0:
                    number_of_values = donothing_values_0.GetLength(0);
                    break;

                case 1:
                    number_of_values = delay_values_1.GetLength(0);
                    break;

                case 2:
                    number_of_values = arrows_and_tab_values_2.GetLength(0);
                    break;

                case 3:
                    number_of_values = mediakey_values_3.GetLength(0);
                    break;

                case 4:
                    number_of_values = letter_values_4.GetLength(0);
                    break;

                case 5:
                    number_of_values = option_key_values_5.GetLength(0);
                    break;

                case 6:
                    number_of_values = functionkey_values_6.GetLength(0);
                    break;

                case 7:
                    number_of_values = number_values_7.GetLength(0);
                    break;

                case 8:
                    number_of_values = special_char_values_8.GetLength(0);
                    break;

                case 9:
                    number_of_values = combo_values_9.GetLength(0);
                    break;

                case 10:
                    number_of_values = helper_values_10.GetLength(0);
                    break;

                case 11:
                    number_of_values = ftd_function_values_11.GetLength(0);
                    break;

                case 12:
                    number_of_values = numpad_values_12.GetLength(0);
                    break;

                case 13:
                    number_of_values = useraction_values_13.GetLength(0);
                    break;

                case 14:
                    number_of_values = gotopage_values_14.GetLength(0);
                    break;

                case 15:
                    number_of_values = cadfunction_values_15.GetLength(0);
                    break;

                case 16:
                    number_of_values = cadprogram_values_16.GetLength(0);
                    break;

                case 17:
                    number_of_values = mousebutton_values_17.GetLength(0);
                    break;

                case 18:
                    number_of_values = previouspage_values_18.GetLength(0);
                    break;

                case 19:
                    number_of_values = default_joystick_mode_values_19.GetLength(0);
                    break;

                case 20:
                    number_of_values = spacemouse_button_values_20.GetLength(0);
                    break;

                default:
                    break;
            }
            return number_of_values;
        }

        public static string GetValue(int action_type, int value_index, int display_or_value)
        {
            string value_string = "";

            switch (action_type)
            {
                case 0:
                    value_string = donothing_values_0[value_index, display_or_value];
                    break;

                case 1:
                    value_string = delay_values_1[value_index, display_or_value];
                    break;

                case 2:
                    value_string = arrows_and_tab_values_2[value_index, display_or_value];
                    break;

                case 3:
                    value_string = mediakey_values_3[value_index, display_or_value];
                    break;

                case 4:
                    value_string = letter_values_4[value_index, display_or_value];
                    break;

                case 5:
                    value_string = option_key_values_5[value_index, display_or_value];
                    break;

                case 6:
                    value_string = functionkey_values_6[value_index, display_or_value];
                    break;

                case 7:
                    value_string = number_values_7[value_index, display_or_value];
                    break;

                case 8:
                    value_string = special_char_values_8[value_index, display_or_value];
                    break;

                case 9:
                    value_string = combo_values_9[value_index, display_or_value];
                    break;

                case 10:
                    value_string = helper_values_10[value_index, display_or_value];
                    break;

                case 11:
                    value_string = ftd_function_values_11[value_index, display_or_value];
                    break;

                case 12:
                    value_string = numpad_values_12[value_index, display_or_value];
                    break;

                case 13:
                    value_string = useraction_values_13[value_index, display_or_value];
                    break;

                case 14:
                    value_string = gotopage_values_14[value_index, display_or_value];
                    break;

                case 15:
                    value_string = cadfunction_values_15[value_index, display_or_value];
                    break;

                case 16:
                    value_string = cadprogram_values_16[value_index, display_or_value];
                    break;

                case 17:
                    value_string = mousebutton_values_17[value_index, display_or_value];
                    break;

                case 18:
                    value_string = previouspage_values_18[value_index, display_or_value];
                    break;

                case 19:
                    value_string = default_joystick_mode_values_19[value_index, display_or_value];
                    break;

                case 20:
                    value_string = spacemouse_button_values_20[value_index, display_or_value];
                    break;

                default:
                    break;
            }
            return value_string;
        }

        public static int GetNumberOfActions()
        {
            int number_of_actions = -1;

            number_of_actions = action_option.GetLength(0);

            return number_of_actions;
        }

        public static string GetAction(int i)
        {
            return action_option[i, 0];
        }

        public static ActionsAndValues GetActionsAndValues(Keys thisKeyCode)
        {
            uint keyMask = 0;
            int actionHelper = 0;
            int valueHelper = 0;
            int valueKey = 0;
            int actionKey = 0;
            ActionsAndValues returnedActionsAndValues = new ActionsAndValues();

            KeyTypes keyType = KeyTypes.KeyTypeNone;
            // Determine whether the keystroke is a number from the top of the keyboard.
            // 0x30 - 0x39
            if (thisKeyCode >= Keys.D0 && thisKeyCode <= Keys.D9)
            {
                keyType = KeyTypes.KeyTypeNumber;
            }
            // Determine whether the keystroke is a letter key.
            // 0x41 - 0x5A
            else if (thisKeyCode >= Keys.A && thisKeyCode <= Keys.Z)
            {
                keyType = KeyTypes.KeyTypeLetter;
            }
            // Determine whether the keystroke is a Fn key.
            // 0x70 - 0x87
            else if (thisKeyCode >= Keys.F1 && thisKeyCode <= Keys.F24)
            {
                keyType = KeyTypes.KeyTypeFn;
            }
            // Determine whether the keystroke is a numpad key.
            // 0x60 - 0x6f
            else if (thisKeyCode >= Keys.NumPad0 && thisKeyCode <= Keys.Divide)
            {
                keyType = KeyTypes.KeyTypeNumpad;
            }
            // Determine whether the keystroke is a miscellaneous key.
            // 0x13 - 0x2f
            else if (thisKeyCode >= Keys.Pause && thisKeyCode <= Keys.Help)
            {
                keyType = KeyTypes.KeyTypeMisc;
            }
            // Determine whether the keystroke is a media or app key.
            // 0xa6 - 0xb7
            else if (thisKeyCode >= Keys.BrowserBack && thisKeyCode <= Keys.LaunchApplication2)
            {
                keyType = KeyTypes.KeyTypeMediaApp;
            }
            // Determine whether the keystroke is a miscellaneous key.
            // 0xba - 0xe2
            else if (thisKeyCode >= Keys.OemSemicolon && thisKeyCode <= Keys.OemBackslash)
            {
                keyType = KeyTypes.KeyTypeOem;
            }

            // Don't trigger if it was just a modifier (ctrl, alt, shift, gui) key. We need
            // to wait for a letter, number, fn, etc.
            if (keyType != KeyTypes.KeyTypeNone)
            {
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

                switch (keyType)
                {
                    case KeyTypes.KeyTypeNumber:
                        actionKey = 7;
                        // Mapped to 0-9
                        valueKey = thisKeyCode - Keys.D0;
                        break;

                    case KeyTypes.KeyTypeLetter:
                        actionKey = 4;
                        // mapped to a list that starts with a space character then a-z
                        valueKey = thisKeyCode - Keys.A + 1;
                        break;

                    case KeyTypes.KeyTypeFn:
                        actionKey = 6;
                        // Mapped to F1-F24
                        valueKey = thisKeyCode - Keys.F1;
                        break;

                    case KeyTypes.KeyTypeNumpad:
                        //  { "Numpad 0", "0" }, { "Numpad 1", "1" }, { "Numpad 2", "2" }, { "Numpad 3", "3" },
                        //  { "Numpad 4", "4" }, { "Numpad 5", "5" }, { "Numpad 6", "6" }, { "Numpad 7", "7" },
                        //  { "Numpad 8", "8" }, { "Numpad 9", "9" }, { "Numpad /", "10" }, { "Numpad *", "11" },
                        //  { "Numpad -", "12" }, { "Numpad +", "13" }, { "Numpad RETURN", "14" }, { "Numpad .", "15" }   
                        actionKey = 12;

                        if (thisKeyCode >= Keys.NumPad0 && thisKeyCode <= Keys.NumPad9)
                        {
                            valueKey = thisKeyCode - Keys.NumPad0;
                        }
                        else if (thisKeyCode == Keys.Divide)
                        {
                            valueKey = 10;
                        }
                        else if (thisKeyCode == Keys.Multiply)
                        {
                            valueKey = 11;
                        }
                        else if (thisKeyCode == Keys.Subtract)
                        {
                            valueKey = 12;
                        }
                        else if (thisKeyCode == Keys.Add)
                        {
                            valueKey = 13;
                        }
                        else if (thisKeyCode == Keys.Separator)  // Not sure what this one is.
                        {
                            valueKey = 0;
                        }
                        else if (thisKeyCode == Keys.Decimal)
                        {
                            valueKey = 15;
                        }
                        break;

                    case KeyTypes.KeyTypeOem:
                        //static string[,] special_char_valueKeys_8 ={
                        //{ ".", "." },{ ", ", ", " },{ "!", "!" },{ "?", "?" },{ "/", "/" },{ "+", "+" },{ "-", "-" },{ "&", "&" },
                        //{ "^", "^" },{ "%", "%" },{ "*", "*" },{ "#", "#" },{ "$", "$" },{ "[", "[" },{ "]", "]" }};
                        actionKey = 8;
                        switch (thisKeyCode)
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
                        switch (thisKeyCode)
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
                        switch (thisKeyCode)
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
                    switch (thisKeyCode)
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



            }
            
            if (actionHelper == 0)
            {
                returnedActionsAndValues.action0 = actionKey;
                returnedActionsAndValues.value0 = valueKey;

                returnedActionsAndValues.action1 = 0;
                returnedActionsAndValues.value1 = 0;

                returnedActionsAndValues.action2 = 0;
                returnedActionsAndValues.value2 = 0;
            }
            else
            {
                returnedActionsAndValues.action0 = actionHelper;
                returnedActionsAndValues.value0 = valueHelper;

                returnedActionsAndValues.action1 = actionKey;
                returnedActionsAndValues.value1 = valueKey;

                returnedActionsAndValues.action2 = 0;
                returnedActionsAndValues.value2 = 0;
            }

            return returnedActionsAndValues;
        }

    }
}
