
using System;
using Xamarin.Forms;

using Xamarin.Forms.PlatformConfiguration;

namespace FirstProj
{
    public partial class ImageSlider : ContentPage
    {
        private int _currentImageId = 1;
        
        public ImageSlider()
        {
            InitializeComponent();
            _currentImageId = 1;
            LoadImage();

        }

        public void LoadImage()
        {
            image.Source = new UriImageSource
            {
                Uri = new Uri($"http://lorempixel.com/1920/1080/city/{_currentImageId}"),
                CachingEnabled = false
            };

        }
       

        private void Previous_OnClicked(object sender, EventArgs e)
        {
            _currentImageId--;
            if (_currentImageId == 0)
                _currentImageId = 10;

            LoadImage();
        }

        private void Next_OnClicked(object sender, EventArgs e)
        {
            _currentImageId++;
            if (_currentImageId == 11)
                _currentImageId = 1;

            LoadImage();
        }

        private void NextPage_Clicked(object sender, EventArgs e)
        {
            var page = new NavigationPage(new ListPage());
            Navigation.PushAsync(page);
        }
        protected override bool OnBackButtonPressed()
        {
            DisplayAlert("Warning", "You are trapped", "Cancel");
            return false;
        }

    }
}
