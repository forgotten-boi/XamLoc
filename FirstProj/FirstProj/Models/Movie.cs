using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstProj.Models
{
    public class Movie
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("original_title")]
        public string Title { get;set;}

        [JsonProperty("budget")]
        public int ReleaseYear { get; set; }

        [JsonProperty("poster_path")]
        public string Poster
        {
            get; set;
            //get
            //{

            //    return "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_SY150_CR0,0,101,150_.jpg";
            //}
            //set
            //{
            //    if (value != null)
            //        Poster = value;
            //}
        }

        [JsonProperty("popularity")]
        public float Rating { get; set; }

        [JsonProperty("overview")]
        public string Summary { get; set; }
    }
}
