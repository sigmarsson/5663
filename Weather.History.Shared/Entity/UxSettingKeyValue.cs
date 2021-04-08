using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.History.UI.Entity
{
    internal class UxSettingKeyValue
    {
        public UxSettingKeyValue(string caption)
        {
            Caption = caption;
        }

        public string Caption { get; set; }



        public int SelectedIndex { get; set; }
    }
}
