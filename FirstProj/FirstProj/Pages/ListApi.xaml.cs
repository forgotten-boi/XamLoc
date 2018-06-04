using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstProj
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListApi : ContentPage
	{
        private const string Url = "https://jsonplaceholder.typicode.com/posts";
        private HttpClient _httpClient = new HttpClient();
        private ObservableCollection<Post> _posts;
        public ListApi ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            var content = await _httpClient.GetStringAsync(Url);
            var posts = JsonConvert.DeserializeObject<List<Post>>(content);
            _posts = new ObservableCollection<Post>(posts);
            listView.ItemsSource = _posts;

            base.OnAppearing();
        }

        private void OnDeleteClicked(object sender, System.EventArgs e)
        {
            var post = (sender as MenuItem).CommandParameter as Post;
         
        }

        async void OnAdd(Object sender, System.EventArgs e)
        {
            var post = new Post { Title = "Title " + DateTime.Now.Ticks };
            _posts.Insert(0, post);

            var content = JsonConvert.SerializeObject(post);
            await _httpClient.PostAsync(Url, new StringContent(content));

        }

        async void OnUpdate(Object sender, System.EventArgs e)
        {
            var post = _posts[0];
            post.Title += " UPDATED";
            var content = JsonConvert.SerializeObject(post);
            await _httpClient.PutAsync(Url + '/' + post.Id, new StringContent(content));
        }
        async void OnDelete(Object sender, System.EventArgs e)
        {
            var post = _posts[0];
            _posts.Remove(post);
            await _httpClient.DeleteAsync(Url + '/' + post.Id);
        }
      
    }
}