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
                OnPropertyChanged();
            }
        }

        private string manager;
        public string Manager {
            get { return manager; }
            set { manager = value;
                OnPropertyChanged();
            }
        }

        private string city;
        public string City {
            get { return city; }
            set { city = value;
                OnPropertyChanged();
            }
        }

        private string stadiumName;
        public string StadiumName {
            get { return stadiumName; }
            set { stadiumName = value;
                OnPropertyChanged();
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
            *   
            *       context.Add<Team>(new Team() { City = City, StadiumName = StadiumName, Title = Title, Manager = Manager });
            *       
            *       // Important to commit or 
            *       // it will automatically be rolled back
            *       transaction.Commit();
            *   }
            */

            // After adding new entry to database close this page
            await Application.Current.MainPage.Navigation.PopAsync();
        }

    }
}
