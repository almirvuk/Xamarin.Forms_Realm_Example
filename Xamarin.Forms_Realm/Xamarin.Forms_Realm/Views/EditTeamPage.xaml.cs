using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms_Realm.ViewModels;

namespace Xamarin.Forms_Realm.Views {

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditTeamPage : ContentPage {

        private string _teamId;

        public EditTeamPage(string teamId) {
            InitializeComponent();

            _teamId = teamId;
        }

        protected override void OnAppearing() {

            BindingContext = new EditTeamViewModel(_teamId);
        }
    }
}