using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FirstProj.Models
{
	// ObservableCollection instead of List as
	// this is the object that will be binded to the ListView to. So, Once a search 
	// a Search from SearchGroup is removed, ListView will be notified. 
	public class SearchGroup : ObservableCollection<Search>
	{
		public string Title { get; set; }

		public SearchGroup(string title, IEnumerable<Search> searches = null) 
			: base(searches)
		{
			Title = title;
		}
	}
}
