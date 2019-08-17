using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes
{
    public partial class App : Application
    {
        public static string FolderPath { get; private set; }

        public App()
        {
            InitializeComponent();

#if DEBUG
            HotReloader.Current.Run(this);
#endif
            FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            MainPage = new NavigationPage(new SplashPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
