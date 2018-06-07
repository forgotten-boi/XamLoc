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
	public partial class MoviesDetail : ContentPage
	{
        public Movie _movie { get; set; }
        public MovieService _movieService { get; set; }
        public MoviesDetail (Movie movie)
		{
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));
            _movie = movie;
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            //BindingContext = await _movieService.GetMovie(_movie.Title);
            BindingContext = _movie;
            base.OnAppearing();
        }
    }
}