using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

using Weather.History.Abstract;
using Weather.History.Dialog;
using Windows.Security.Authentication.Web.Core;
using Weather.History.Pages;
using System.Diagnostics;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Weather.History
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        readonly IProductService _appServcice;

        public MainPage()
        {
            //Log4.Debug($"Current Working Directory : {SetCwd()}");

            var proc = Process.GetCurrentProcess();
            var hwnd = proc.MainWindowHandle;

           // _appServcice = new AppServiceHost(hwnd);
           // _appServcice.Start();

            InitializeComponent();
        }


        private static string SetCwd()
        {
            var exe = typeof(MainPage).Assembly.Location;
            var cwd = Path.GetDirectoryName(exe);

            Directory.SetCurrentDirectory(cwd);

            return cwd;
        }

        private void OnNavigate(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
               // contentFrame.Navigate(typeof(SettingsPage));
            }
            else
            {
                if (args.SelectedItem as NavigationViewItem is var navigateTo)
                {
                    var ns = $"{typeof(MainPage).Namespace}.Pages";
                    var targetPage = navigateTo.Tag as string;
                    var targetType = Type.GetType($"{ns}.{targetPage}");

                    if (targetType is not null)
                    {
                       //contentFrame.Navigate(targetType);
                    }
                }
            }
        }

        private void ShowLog(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                var proc = new ProcessStartInfo
                {
                   // FileName = Log4.LogFilename,
                    WindowStyle = ProcessWindowStyle.Maximized,
                    UseShellExecute = true
                };

                Process.Start(proc);
            }
            catch (Exception ex)
            {
                //Log4.Error(ex);
            }
        }

        private async void ShowAccounts(object sender, TappedRoutedEventArgs e)
        {
            //var msaProvider = await WebAuthenticationCoreManager.FindAccountProviderAsync("https://login.microsoft.com", "consumers");

            //https://docs.microsoft.com/en-us/windows/uwp/security/web-account-manager

            var dialog = new MicrosoftAccountDialog
            {
              //  XamlRoot = (sender as NavigationViewItem).XamlRoot
            };

            var result = await dialog.ShowAsync();
        }
    }
}
