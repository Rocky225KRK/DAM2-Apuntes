using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid.Model
{
    public class Hero
    {

        public static List<Hero> heroes;
        public static List<Hero> GetListOfHeroes()
        {
            if (heroes == null)
            {
                heroes = new List<Hero>();
                heroes.Add(new Hero("Ironman", true, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus dictum felis sit amet commodo pharetra. In vitae malesuada odio, eu convallis justo. Nullam eget pretium leo. Suspendisse id sem metus. ", "ms-appx:///Assets/images/ironman.png", Team.GetListOfTeams()[0]));
                heroes.Add(new Hero("Captain America", true, "Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nulla ac purus nec tortor feugiat lacinia. Pellentesque libero nulla, feugiat quis pulvinar quis, pellentesque vel ligula. Nam varius ornare nulla, porttitor volutpat lectus elementum vitae. ", "ms-appx:///Assets/images/cap.png", Team.GetListOfTeams()[0]));
                heroes.Add(new Hero("Thor", true, " Ut et magna porta, fermentum nisi id, porta tellus. Vivamus et sagittis ipsum. Maecenas sit amet pellentesque arcu. Mauris tempor pharetra quam, ut efficitur nunc maximus ac. ", "ms-appx:///Assets/images/thor.png", Team.GetListOfTeams()[0]));
                heroes.Add(new Hero("Vision", true, "Praesent sit amet est hendrerit, rhoncus metus in, rutrum ipsum. Integer condimentum enim sollicitudin erat elementum sollicitudin. Sed hendrerit ligula finibus accumsan egestas. Mauris aliquet bibendum aliquam. ", "ms-appx:///Assets/images/vision.png", Team.GetListOfTeams()[0]));
                heroes.Add(new Hero("Black Panther", true, "Pellentesque ultrices enim nisl, sit amet laoreet ex condimentum eget. In venenatis sit amet tellus in congue. Duis nec luctus tellus, nec sollicitudin nulla. ", "ms-appx:///Assets/images/blackp.png", Team.GetListOfTeams()[2]));
                heroes.Add(new Hero("Black Widow", false, "Cras sit amet augue sed risus pharetra elementum placerat vitae eros. Suspendisse non magna mattis, tincidunt ante sed, laoreet sem. Phasellus elementum eu libero ut fringilla. Ut viverra risus ligula. Nullam luctus arcu sed volutpat placerat", "ms-appx:///Assets/images/bw.png", Team.GetListOfTeams()[0]));
                heroes.Add(new Hero("Colossus", true, "Nullam pellentesque lectus sed ornare scelerisque. ", "ms-appx:///Assets/images/coloso.png", Team.GetListOfTeams()[1]));
                heroes.Add(new Hero("Beast", true, "Integer accumsan in ante a pretium. Donec at felis vitae augue rhoncus convallis. ", "ms-appx:///Assets/images/beast.png", Team.GetListOfTeams()[1]));
                heroes.Add(new Hero("Storm", false, "Pellentesque eu libero et velit bibendum aliquam sed ac velit. Cras at arcu et lorem vehicula gravida. Sed enim est, scelerisque quis lorem a, dignissim molestie velit. Nulla dapibus iaculis diam eget sagittis. Integer ac turpis nulla. ", "ms-appx:///Assets/images/storm.png", Team.GetListOfTeams()[1]));
            }
            return heroes;
        }
            
        private String name;
        private String desc;
        private String urlPhoto;
        private Team team;
        private bool sex;

        public Hero(string name, bool sex, string desc, string urlPhoto, Team team)
        {
            this.Name = name;
            this.Sex = sex;
            this.Desc = desc;
            this.UrlPhoto = urlPhoto;
            this.Team = team;
        }
        public Hero(string name, string desc, string urlPhoto)
        {
            this.Name = name;
            this.Sex = Sex;
            this.Desc = desc;
            this.UrlPhoto = urlPhoto;
            this.Team = Team.GetEmptyTeam();

        }



        public string Name { get => name; set => name = value; }
        public string Desc { get => desc; set => desc = value; }
        public string UrlPhoto { get => urlPhoto; set => urlPhoto = value; }
        public Team Team { get => team; set => team = value; }
        public bool Sex { get => sex; set => sex = value; }
        /// <summary>
        /// Propietat "composta" per fer proves amb la graella.
        /// </summary>
        public List<string> AlterEgos { get
            {
                return new List<string>() {"Paco", "The butano man", "XXXX" };
            }
        }
        public string SexIcon
        {
            get
            {
                return Sex ? "♂" : "♀";
            }
        }

        public bool EsDona
        {
            get
            {
                return !Sex;
            }
        }

        public List<Team> Teams
        {
            get
            {
                return Team.GetListOfTeams();
            }
        }

    }
}
