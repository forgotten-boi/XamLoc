using FirstProj.Models;
using FirstProj.Services;
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
	public partial class Movies : ContentPage
    {
        private MovieService _service = new MovieService();
        private BindableProperty IsSearchingProperty = BindableProperty.Create("IsSearching", typeof(bool), typeof(Movies), false);
        public bool IsSearching
        {
            get { return (bool)GetValue(IsSearchingProperty); }
            set { SetValue(IsSearchingProperty, value); }
        }
        public Movies ()
		{
            BindingContext = this;
			InitializeComponent ();
		}

        async void OnTextChanged(Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (e.NewTextValue == null || e.NewTextValue.Length < MovieService.MinSearchLength)
                return;
            await FindMoviesAsync(actor: e.NewTextValue);
        }

        private async Task FindMoviesAsync(string actor)
        {
            try
            {
                IsSearching = true;

                var movies = await _service.FindMoviesByActor(actor);
                moviesListView.ItemsSource = movies;
                moviesListView.IsVisible = movies.Any();
                notFound.IsVisible = !moviesListView.IsVisible;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Could not retrieve the list of movies.", "OK");
            }
            finally
            {
                IsSearching = false;
            }
        }

        async void OnMovieSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var movie = e.SelectedItem as Movie;

            moviesListView.SelectedItem = null;

            await Navigation.PushAsync(new MoviesDetail(movie));
        }
    }
}