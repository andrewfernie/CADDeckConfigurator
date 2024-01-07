using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiFiUserControl
{
    public class CJSONWiFi
    {
        public string ssid { get; set; }
        public string password { get; set; }
        public string wifimode { get; set; }
        public string wifihostname { get; set; }
        public int attempts { get; set; }
        public int attemptdelay { get; set; }
    }
}


