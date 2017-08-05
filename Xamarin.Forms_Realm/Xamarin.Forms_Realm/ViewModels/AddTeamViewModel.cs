using Realms;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms_Realm.Models;

namespace Xamarin.Forms_Realm.ViewModels {

    public class AddTeamViewModel : BaseViewModel{

        private string title;
        public string Title {
            get { return title; }
            set { title = value;
                OnPropertyChanged("Title");
            }
        }

        private string manager;
        public string Manager {
            get { return manager; }
            set { manager = value;
                OnPropertyChanged("Manager");
            }
        }

        private string city;
        public string City {
            get { return city; }
            set { city = value;
                OnPropertyChanged("City");
            }
        }

        private string stadiumName;
        public string StadiumName {
            get { return stadiumName; }
            set { stadiumName = value;
                OnPropertyChanged("StadiumName");
            }
        }

        public ICommand SaveTeamCommand { get; private set; }

        public AddTeamViewModel() {

            SaveTeamCommand = new Command(SaveTeam);
        }

        async void SaveTeam() {

            Realm context = Realm.GetInstance();

            context.Write(() =>  {

                context.Add<Team>(new Team() { City = City, StadiumName = StadiumName, Title = Title, Manager = Manager });
            });

            /* 
            *   Also you can use it like this
            *   using (var transaction = context.BeginWrite()) {
            *       context.Add<Team>(new Team() { City = City, StadiumName = StadiumName, Title = Title, Manager = Manager });
            *       transaction.Commit();
            *   }
            */

            // After adding new entry to database close this page
            await Application.Current.MainPage.Navigation.PopAsync();
        }

    }
}
