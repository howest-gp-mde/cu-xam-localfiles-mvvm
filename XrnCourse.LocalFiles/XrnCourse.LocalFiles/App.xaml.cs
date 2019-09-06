using FreshMvvm;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XrnCourse.LocalFiles.ViewModels;

namespace XrnCourse.LocalFiles
{
    public partial class App : Application
    {
        public App()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Constants.SynfusionLicenseKey);

            InitializeComponent();

            MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<MainViewModel>());
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
