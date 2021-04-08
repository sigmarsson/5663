using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Weather.History.UI.Entity;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace Weather.History.Dialog
{
    public sealed partial class MicrosoftAccountDialog : ContentDialog
    {
        public MicrosoftAccountDialog()
        {
            this.InitializeComponent();

            Accounts = new[]
            {
                new MicrosoftAccount
                {
                    Email = "x.y@microsoft.com",
                    AccountType = "Microsoft account"
                }
            };
        }

        public IEnumerable<MicrosoftAccount> Accounts { get; set; }

        private void OnSignOut(object sender, RoutedEventArgs e)
        {
            var email = (sender as HyperlinkButton).Tag as string;

            // sign out email.
        }
    }
}
