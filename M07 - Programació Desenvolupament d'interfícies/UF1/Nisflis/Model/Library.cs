using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Model
{
    public class Library
    {
        public Library()
        {
            InitializeMovieCollection();
        }

        private ObservableCollection<Movie> MovieCollection = new ObservableCollection<Movie>();

        private void InitializeMovieCollection()
        {
            MovieCollection.Add(new Movie("Avengers: Infinity War",2, "Assets/avengersinfinitywarPS.jpg", 10.99m, "The Avengers and their allies must be willing to sacrifice all in an attempt to defeat the powerful Thanos before his blitz of devastation and ruin puts an end to the universe.", "Assets/avengersinfinitywarCI.jpg"));
            MovieCollection.Add(new Movie("Black Panther",2, "Assets/blackpantherPS.jpg", 9.99m, "T'Challa, the King of Wakanda, rises to the throne in the isolated, technologically advanced African nation, but his claim is challenged by a vengeful outsider who was a childhood victim of T'Challa's father's mistake.", "Assets/blackpantherCI.jpg"));
            MovieCollection.Add(new Movie("Spider-Man: Homecoming", 3, "Assets/spidermanhomecomingPS.jpg", 8.99m, "Peter Parker balances his life as an ordinary high school student in Queens with his superhero alter", "Assets/spidermanhomecomingCI.jpg"));
            MovieCollection.Add(new Movie("Spider-man: No Way Home", 3, "Assets/spidermannowayhomePS.jpg", 12.99m, "Peter Parker's world has changed a lot since the events of Avengers: Endgame (2019). and with everyone asking who's that new hero? Peter is asking the same question, as he's willing to forget the adventure he was longing to have with his friends, just to be a normal high school student again.", "Assets/spidermannowayhomeCi.jpg"));
            MovieCollection.Add(new Movie("The Avengers", 2, "Assets/theavengersPS.jpg", 11.99m, "Earth's mightiest heroes must come together and learn to fight as a team if they are going to stop the mischievous Loki and his alien army from enslaving humanity.", "Assets/theavengersCI.jpg"));
            MovieCollection.Add(new Movie("The Dark Knight", 4, "Assets/thedarkknightPS.jpg", 10.99m, "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", "Assets/thedarkknightCI.jpg"));
            MovieCollection.Add(new Movie("The Dark Knight Rises", 5, "Assets/thedarkknightrisesPS.jpg", 9.99m, "Eight years after the Joker's reign of anarchy, Batman, with the help of the enigmatic Catwoman, is forced from his exile to save Gotham City from the brutal guerra.", "Assets/thedarkknightrisesCI.jpg"));
            MovieCollection.Add(new Movie("Guardians of the Galaxy", 4, "Assets/guardiansofthegalaxyPS.jpg", 8.99m, "A group of intergalactic criminals must pull together to stop a fanatical warrior", "Assets/guardiansofthegalaxyCI.jpg"));
            MovieCollection.Add(new Movie("Guardians of the Galaxy Vol. 2", 4, "Assets/guardiansofthegalaxyvol2PS.jpg", 12.99m, "The Guardians struggle to keep together as a team while dealing with their personal family issues, notably Star-Lord's encounter with his father the ambitious celestial being Ego.", "Assets/guardiansofthegalaxyvol2CI.jpg"));
            MovieCollection.Add(new Movie("Captain America: The Winter Soldier", 4, "Assets/captainamericathewintersoldierPS.jpg", 11.99m, "As Steve Rogers struggles to embrace his role in the modern world, he teams up with a fellow Avenger and S.H.I.E.L.D agent, Black Widow, to battle a new threat from history: an assassin known as the Winter Soldier.", "Assets/captainamericathewintersoldierCI.jpg"));
        }

        public ObservableCollection<Movie> GetMovies
        {
            get { return MovieCollection; }
        }

        public void AddMovie(Movie movie)
        {
            if (movie != null)
            {
                MovieCollection.Add(movie); 
            }
        }

    }
}
