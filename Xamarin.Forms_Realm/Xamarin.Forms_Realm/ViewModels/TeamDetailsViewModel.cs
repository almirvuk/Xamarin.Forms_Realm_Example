using Realms;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms_Realm.Models;
using Xamarin.Forms_Realm.Views;

namespace Xamarin.Forms_Realm.ViewModels {

    public class TeamDetailsViewModel : BaseViewModel {

        private string title;
        public string Title {
            get { return title; }
            set {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        private string manager;
        public string Manager {
            get { return manager; }
            set {
                manager = value;
                OnPropertyChanged("Manager");
            }
        }

        private string city;
        public string City {
            get { return city; }
            set {
                city = value;
                OnPropertyChanged("City");
            }
        }

        private string stadiumName;
        public string StadiumName {
            get { return stadiumName; }
            set {
                stadiumName = value;
                OnPropertyChanged("StadiumName");
            }
        }

        private ObservableCollection<Player> players;
        public ObservableCollection<Player> Players {
            get { return players; }
            set { players = value; }
        }

        public ICommand AddPlayerCommand { get; private set; }
        public ICommand EditTeamCommand { get; private set; }
        public ICommand DeleteTeamCommand { get; private set; }

        private string _teamId;

        public TeamDetailsViewModel(string teamId) {

            _teamId = teamId;

            Realm context = Realm.GetInstance();

            var team = context.Find<Team>(teamId);

            // Using LINQ
            // var team = from t in context.All<Team>() where t.TeamId == teamId select t;
            // var team2 = context.All<Team>().Where(t => t.TeamId == teamId).FirstOrDefault();

            // Setting property values from team object
            // that we get from database
            Title = team.Title;
            City = team.City;
            StadiumName = team.StadiumName;
            Manager = team.Manager;

            // You can not do like this:
            // Players = new ObservableCollection<Player>(context.All<Player>().Where(p => p.Team.TeamId == _teamId));
            
            // Querying by nested RealmObjects attributes is not currently supported:
            Players = new ObservableCollection<Player>(context.All<Player>().Where(p => p.Team == team));

            // Commands for toolbar items
            AddPlayerCommand = new Command(async () => await Application.Current.MainPage.Navigation.PushAsync(new AddPlayerPage(team.TeamId)));
            EditTeamCommand = new Command(async () => await Application.Current.MainPage.Navigation.PushAsync(new EditTeamPage(team.TeamId)));
            DeleteTeamCommand = new Command(DeleteTeam);
        }

        void DeleteTeam() {

            Realm context = Realm.GetInstance();
            var team = context.Find<Team>(_teamId);

            context.Write(() => {
                context.Remove(team);
            });

            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
