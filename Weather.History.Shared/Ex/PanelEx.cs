using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.History.Pages
{
    internal static class PanelEx
    {
        private static Panel FindPanel(this Page page)
        {
            var children = Enumerable.Range(0, VisualTreeHelper.GetChildrenCount(page)).Select(i => VisualTreeHelper.GetChild(page, i));

            return children.FirstOrDefault(child => child is Panel) as Panel;
        }

        internal static void EasyTeachingTip(this Page page, string title, string subTitle, string closeButton = null)
        {
            if (page.FindPanel() is Panel panel)
            {
                var tip = new TeachingTip
                {
                    Title = title,
                    Subtitle = subTitle,
                    CloseButtonContent = closeButton,
                    PreferredPlacement = TeachingTipPlacementMode.Auto,
                    PlacementMargin = new Thickness(20D),
                    IsLightDismissEnabled = true,
                    IsOpen = true,
                    Tag = panel
                };

                tip.Closed += OnTipClosed;

                panel.Children.Add(tip);
            }
        }

        private static void OnTipClosed(TeachingTip sender, TeachingTipClosedEventArgs args)
        {
            var panel = sender.Tag as Panel;

            panel.Children.Remove(sender);
        }
    }
}
