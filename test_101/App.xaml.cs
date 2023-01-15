using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace test_101
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();

            MainPage =new FlyoutMainPage();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

