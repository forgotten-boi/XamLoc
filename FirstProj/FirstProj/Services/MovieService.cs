using FirstProj.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FirstProj.Services
{
    public class MovieService
    {
        public static readonly int MinSearchLength = 5;

        //private const string Url = "http://www.omdbapi.com/?i=tt3896198&apikey=b70b5fbf";
        private const string Url = "https://api.themoviedb.org/3/movie/550?api_key=8f138e0cdaaada9ad9016ad8f8ff8c5f";
        private const string ImageBaseUrl = "https://image.tmdb.org/t/p/w500/";

        private HttpClient _client = new HttpClient();

        public async Task<IEnumerable<Movie>> FindMoviesByActor(string actor) //OMDB api searching by title
        {
           
            try
            {
                if (actor.Length < MinSearchLength)
                    return Enumerable.Empty<Movie>();

                var response = await _client.GetAsync($"{Url}");
               
                //var response = await _client.GetAsync($"{Url}?actor={actor}");

                if (response.StatusCode == HttpStatusCode.NotFound)
                    return Enumerable.Empty<Movie>();

                var content = await response.Content.ReadAsStringAsync();
                //var movieList = JsonConvert.DeserializeObject<List<Movie>>(content);
                var movie= JsonConvert.DeserializeObject<Movie>(content);
                //if(movies?.Count>0)
                //{
                //    movies.ForEach(m =>
                //    {
                //        m.Poster = ImageBaseUrl + m.Poster;
                //    });

                //}
                movie.Poster = ImageBaseUrl + movie.Poster;
                return new List<Movie>
                {
                    movie
                };
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public async Task<Movie> GetMovie(string title)
        {
            var response = await _client.GetAsync($"{Url}?title={title}");

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Movie>(content);
        }
    }
}
