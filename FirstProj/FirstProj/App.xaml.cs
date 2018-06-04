using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace FirstProj
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            

            MainPage = new NavigationPage(new FirstProj.GreetPage());

            //MainPage.BackgroundColor = Color.Red;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    MainPage.BackgroundColor = Color.Red;
                    break;
                case Device.Android:
                    break;

            }

            //MainPage = new FirstProj.ImageSlider();
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
