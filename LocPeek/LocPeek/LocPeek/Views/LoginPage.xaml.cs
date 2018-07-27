using LocPeek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocPeek.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            Init();
		}

        void Init()
        {
            BackgroundColor = Color.Black;
            LoginIcon.HeightRequest = 200;
            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => SignInProcedure(s, e);
        }

        async void SignInProcedure(object sender, EventArgs e) {
            var user = new User(Entry_Username.Text, Entry_Password.Text);
            if (user.CheckInformation())
            {
                //await DisplayAlert("Login", "Login Succes", "Ok");
                await Navigation.PushModalAsync(new MainPage());
            }
            else
            {
               await DisplayAlert("Login", "Login Error", "Ok");
            }
        }
	}
}