using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms_Realm.Models;
using Xamarin.Forms_Realm.ViewModels;

namespace Xamarin.Forms_Realm.Views {

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeamDetailsPage : ContentPage {

        private string _teamId;

        public TeamDetailsPage(string teamId) {
            InitializeComponent();
            _teamId = teamId;
        }

        protected override void OnAppearing() {

            BindingContext = new TeamDetailsViewModel(_teamId);
            base.OnAppearing();
        }

        private void OnPlayerTapped(object sender, ItemTappedEventArgs e) {

            if (e.Item != null) {

                var player = (Player)e.Item;

                Navigation.PushAsync(new EditPlayerPage(player.PlayerId));
            }
        }
    }
}