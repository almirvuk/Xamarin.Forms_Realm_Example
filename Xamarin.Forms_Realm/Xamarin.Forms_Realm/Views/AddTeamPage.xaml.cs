using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms_Realm.ViewModels;

namespace Xamarin.Forms_Realm.Views {

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTeamPage : ContentPage {

        public AddTeamPage() {
            InitializeComponent();
        }

        protected override void OnAppearing() {

            BindingContext = new AddTeamViewModel();
            base.OnAppearing();
        }
    }
}