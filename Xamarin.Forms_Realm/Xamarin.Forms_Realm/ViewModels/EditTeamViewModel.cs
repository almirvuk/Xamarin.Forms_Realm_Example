using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms_Realm.Models;

namespace Xamarin.Forms_Realm.ViewModels {

    class EditTeamViewModel : BaseViewModel {

        private string title;
        public string Title {
            get { return title; }
            set {
                title = value;
                OnPropertyChanged();
            }
        }

        private string manager;
        public string Manager {
            get { return manager; }
            set {
                manager = value;
                OnPropertyChanged();
            }
        }

        private string city;
        public string City {
            get { return city; }
            set {
                city = value;
                OnPropertyChanged();
            }
        }

        private string stadiumName;
        public string StadiumName {
            get { return stadiumName; }
            set {
                stadiumName = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveTeamCommand { get; private set; }

        private string _teamId;

        public EditTeamViewModel(string teamId) {

            Realm context = Realm.GetInstance();

            var team = context.Find<Team>(teamId);
            _teamId = team.TeamId;

            Title = team.Title;
            Manager = team.Manager;
            StadiumName = team.StadiumName;
            City = team.City;

            SaveTeamCommand = new Command(SaveTeam);
        }

        async void  SaveTeam() {

            Realm context = Realm.GetInstance();

            var team = context.Find<Team>(_teamId);

            context.Write(() => {

                team.Title = Title;
                team.Manager = Manager;
                team.StadiumName = StadiumName;
                team.City = City;

                context.Add<Team>(team, update: true);
            });

            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
