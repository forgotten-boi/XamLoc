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
	public partial class UserProfilePage : ContentPage
	{
        private UserService _userService = new UserService();
		public UserProfilePage (int userId)
		{
            InitializeComponent();

            BindingContext = _userService.GetUser(userId);
		}
	}
}