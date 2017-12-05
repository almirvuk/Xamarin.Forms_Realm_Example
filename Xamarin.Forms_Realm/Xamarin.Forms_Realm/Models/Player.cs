using Realms;
using System;

namespace Xamarin.Forms_Realm.Models {

    public class Player : RealmObject {

        [PrimaryKey]
        public string PlayerId { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }
        public int JerseyNumber { get; set; }
        public string Position { get; set; }

        public Team Team { get; set; }
    }
}
