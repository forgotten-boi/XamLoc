using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstProj
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GreetPage : ContentPage
	{
		private int _index = 0;
		private string[] _quoteArray = {"GOod Morning", "Good Afternoon", "Good Evening", "GoodNight"};

		
		public GreetPage ()
		{
			InitializeComponent ();
//			Slider.Value = 0.2;
			currentQuote.Text = _quoteArray[_index];
		}
       
		
		private void Button_OnClicked(object sender, EventArgs e)
		{
			_index++;
			if (_index >= _quoteArray.Length)
				_index = 0;

			currentQuote.Text = _quoteArray[_index];
		}

        private void ImageSlider_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ImageSlider());
        }

        private void ListPage_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new ListPage());
            Navigation.PushAsync(new ListApi());
        }

        private void MainPage_Clicked(object sender, EventArgs e)
        {
            //DisplayAlert("Warning","MainPage is under construction", "OK");
            Navigation.PushAsync(new MainPage());
        }

        private void InstaPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InstaPage());
        }
    }
}