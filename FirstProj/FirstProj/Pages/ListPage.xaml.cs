using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FirstProj.Models;
using FirstProj.Services;
using System.Collections.Generic;
using System.Net.Http;

namespace FirstProj
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        private SearchService _searchService;
        private List<SearchGroup> _searchGroups;

        public ObservableCollection<string> Items { get; set; }

        public ListPage()
        {
            InitializeComponent();
            _searchService = new SearchService();
            PopulateListView(_searchService.GetRecentSearches());

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        private void PopulateListView(IEnumerable<Search> searches)
        {
            _searchGroups = new List<SearchGroup>
            {
                new SearchGroup("Recent Searches", searches)
            };

            listView.ItemsSource = _searchGroups;
        }
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        protected override bool OnBackButtonPressed()
        {
            var path = DisplayAlert("Title", "This is the last page. Return", "GreetPage", "MainPage").Result;
            if (path.Equals(true))
            {
                Navigation.PushAsync(new InstaPage());
            }
            else
            {
                Navigation.PushAsync(new GreetPage());
            }
            return true;
        }

        private void listView_Refreshing(object sender, EventArgs e)
        {
            PopulateListView(_searchService.GetRecentSearches(searchBar.Text));

            listView.EndRefresh();

        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var search = e.SelectedItem as Search;
            DisplayAlert("Selected", search.Location, "OK");
        }

        private void OnSearchTextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            PopulateListView(_searchService.GetRecentSearches(e.NewTextValue));
        }

        private void OnDeleteClicked(object sender, System.EventArgs e)
        {
            var search = (sender as MenuItem).CommandParameter as Search;         
            _searchGroups[0].Remove(search);

            _searchService.DeleteSearch(search.Id);
        }
    }
}
