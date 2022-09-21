using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Lieferschein.Helper
{
    public class GlobalSettings
    {
        public GlobalSettings(bool isMock)
        {
            IsMock = isMock;
        }
        public bool IsMock { get; set; }
        public UserInfoModel UserInfo { get; set; }
    }
}
