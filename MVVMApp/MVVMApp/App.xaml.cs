using System;
using System.IO;
using MVVMApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMApp
{
    public partial class App : Application
    {
        public static string FolderPath { get; private set; } 
        public App()
        {
            InitializeComponent();
            FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)); 
            MainPage = new NavigationPage(new ITCompaniesListPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
