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

    public class EditPlayerViewModel : BaseViewModel {

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

        private string _playerId;

        public EditPlayerViewModel(string playerId) {

            Realm context = Realm.GetInstance();

            var player = context.Find<Player>(playerId);

            _playerId = player.PlayerId;

            TeamName = player.Team.Title;

            Name = player.Name;
            Position = player.Position;
            JerseyNumber = player.JerseyNumber.ToString();

            SavePlayerCommand = new Command(SavePlayer);
        }

        void SavePlayer() {

            Realm context = Realm.GetInstance();

            var player = context.Find<Player>(_playerId);

            context.Write(() => {

                player.Position = Position;
                player.Name = Name;
                player.JerseyNumber = Int32.Parse(JerseyNumber);

                context.Add<Player>(player, update: true);
            });

            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
