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
    public partial class TeamsListPage : ContentPage {

        public TeamsListPage() {
            InitializeComponent();
        }

        protected override void OnAppearing() {
            BindingContext = new TeamListViewModel();
        }

        private async void TeamTapped(object sender, ItemTappedEventArgs e) {

            if (e.Item != null) {
                var team = (Team)e.Item;
                await Navigation.PushAsync(new TeamDetailsPage(team.TeamId));
            }
        }
    }
}