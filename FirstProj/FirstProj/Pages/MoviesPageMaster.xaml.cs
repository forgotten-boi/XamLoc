using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstProj
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviesPageMaster : ContentPage
    {
        public ListView ListView;

        public MoviesPageMaster()
        {
            InitializeComponent();


            BindingContext = new MoviesPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MoviesPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MoviesPageMenuItem> MenuItems { get; set; }
            
            public MoviesPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<MoviesPageMenuItem>(new[]
                {
                    new MoviesPageMenuItem { Id = 0, Title = "Page 1" },
                    new MoviesPageMenuItem { Id = 1, Title = "Page 2" },
                    new MoviesPageMenuItem { Id = 2, Title = "Page 3" },
                    new MoviesPageMenuItem { Id = 3, Title = "Page 4" },
                    new MoviesPageMenuItem { Id = 4, Title = "Page 5" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}