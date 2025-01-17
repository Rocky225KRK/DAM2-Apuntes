using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid.Model
{
    public class Team
    {

        public static List<Team> teams;
        public static List<Team> GetListOfTeams()
        {
            if (teams == null)
            {
                teams = new List<Team>();
                teams.Add(new Team("Avengers", "ms-appx:///Assets/images/avengers.jpg"));
                teams.Add(new Team("X-Men", "ms-appx:///Assets/images/x-logo.jpg"));
                teams.Add(GetEmptyTeam());
            }
            return teams;
        }
        public static Team GetEmptyTeam()
        {
            return new Team("No team", "ms-appx:///Assets/images/empty_team.png");
        }


        private String name;
        private String urlPhoto;

        public Team(string name, string urlPhoto)
        {
            this.Name = name;
            this.UrlPhoto = urlPhoto;
        }

        public string Name { get => name; set => name = value; }
        public string UrlPhoto { get => urlPhoto; set => urlPhoto = value; }
        public List<Hero> Heroes
        {
            get
            {
                return Hero.GetListOfHeroes().FindAll(h => h.Team == this);
            }
        }
    }
}
