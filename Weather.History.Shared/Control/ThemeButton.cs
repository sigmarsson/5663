using Microsoft.UI.Xaml.Controls.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.History.UI.Control
{
    internal class ThemeButton : ToggleButton
    {
        protected override void OnToggle()
        {
            if (IsChecked.HasValue && IsChecked.Value)
            {
                return;
            }

            base.OnToggle();
        }
    }
}
