using LocPeek.Views.Main.Views;
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
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void MapClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MapPage());
        }

        async void FriendsClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new FriendsPage());
        }

        async void MessagesClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MessagesPage());
        }

        async void OptionClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new OptionsPage());
        }
    }
}