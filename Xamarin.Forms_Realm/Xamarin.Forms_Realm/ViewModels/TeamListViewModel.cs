using Realms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms_Realm.Models;
using Xamarin.Forms_Realm.Views;

namespace Xamarin.Forms_Realm.ViewModels {

    public class TeamListViewModel : BaseViewModel{

        private ObservableCollection<Team> allTeams;
        public ObservableCollection<Team> AllTeams {
            get { return allTeams; }
            set { allTeams = value;
            }
        }

        public ICommand AddTeamCommand { get; private set; }

        public TeamListViewModel() {

            var myConfig = new RealmConfiguration("Primary.realm");

            // Realm context = Realm.GetInstance(myConfig);
            Realm context = Realm.GetInstance();

            // Realm.DeleteRealm(myConfig);
            // var freshRealm = Realm.GetInstance(myConfig);

            var allTeams = context.All<Team>();

            AllTeams = new ObservableCollection<Team>(allTeams);

            AddTeamCommand = new Command(async ()=> await Application.Current.MainPage.Navigation.PushAsync(new AddTeamPage()));
        }
    }
}
