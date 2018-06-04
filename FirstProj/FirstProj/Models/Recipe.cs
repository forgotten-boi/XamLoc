using SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FirstProj
{
    //[Table("Recipies")]
	public class Recipe  : INotifyPropertyChanged
	{
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey,AutoIncrement] //,Column("RecipeID")
        public int Id { get; set; }
        [MaxLength(255)]
		private string _name  { get; set; }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value)
                    return;
                //if (string.IsNullOrEmpty(_name) || !_name.Equals(value))
                //{
                _name = value;
                //}
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(propertyName)));
        }
    }
}