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

    public class AddPlayerViewModel : BaseViewModel {

        private string teamName;
        public string TeamName {
            get { return teamName; }
            set {
                teamName = value;
                OnPropertyChanged("TeamName");
            }
        }

        private string name;
        public string Name {
            get { return name; }
            set {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string position;
        public string Position {
            get { return position; }
            set {
                position = value;
                OnPropertyChanged("Position");
            }
        }

        private string jerseyNumber;
        public string JerseyNumber {
            get { return jerseyNumber; }
            set {
                jerseyNumber = value;
                OnPropertyChanged("JerseyNumber");
            }
        }

        public ICommand SavePlayerCommand { get; private set; }

        private string _teamId;
        private Realm context;

        public AddPlayerViewModel(string teamId) {

            _teamId = teamId;
            context = Realm.GetInstance();

            var team = context.All<Team>().Where(t => t.TeamId == teamId).FirstOrDefault();

            TeamName = team.Title;

            SavePlayerCommand = new Command(SavePlayer);
        }

        void SavePlayer() {

            var team = context.All<Team>().Where(t => t.TeamId == _teamId).FirstOrDefault();

            context.Write(() => {

                context.Add<Player>(new Player() {
                    JerseyNumber = Int32.Parse(JerseyNumber),
                    Name = Name,
                    Position = Position,
                    Team = team
                });
            });

            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
