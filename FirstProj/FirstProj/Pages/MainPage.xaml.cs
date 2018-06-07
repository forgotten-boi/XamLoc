using FirstProj;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FirstProj
{
    public partial class MainPage : ContentPage
	{
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<Recipe> _recipes;
       
        public MainPage()
		{
			InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
          
		}
        protected override async void OnAppearing()
        {
           await _connection.CreateTableAsync<Recipe>();
           var recipies = await _connection.Table<Recipe>()?.OrderByDescending(p => p.Name)?.ToListAsync();
            _recipes = new ObservableCollection<Recipe>(recipies);
            recipesListView.ItemsSource = _recipes;
            base.OnAppearing();
        }

        async void OnAdd(object sender, System.EventArgs e)
		{
            var recipie = new Recipe {Name = "Recipe "  + DateTime.Now.Ticks }; 
            await _connection.InsertAsync(recipie);
            _recipes.Add(recipie);

		}

		async void OnUpdate(object sender, System.EventArgs e)
		{
            if (_recipes?.Count > 0)
            {
                var recipie = _recipes[0];
                recipie.Name += " Updated";
                await _connection.UpdateAsync(recipie);
                recipesListView.ItemsSource = _recipes;
                //_recipes[0] = recipie;
            }
        }

        async void OnDelete(object sender, System.EventArgs e)
        {
            if (_recipes?.Count > 0)
            {
                var recipie = _recipes[0];
                await _connection.DeleteAsync(recipie);
                _recipes.Remove(recipie);
            }
        }
	}
}