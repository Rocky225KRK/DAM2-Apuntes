using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioDequips.Model
{
    public class Equip:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private long id;
        private string nom;
        private string urlLogo;
        private string desc;
        private DateTime dataCreacio;
        private Conferencia conf;

        OC<Jugador> jugador = new OC<Jugador>();
        Persona coach;

        public Equip(long id, string nom, string urlLogo, string desc, Conferencia conf, DateTime dataCreacio)
        {
            Id = id;
            Nom = nom;
            UrlLogo = urlLogo;
            Desc = desc;
            DataCreacio = dataCreacio;
            Conf = conf;
        }

        public long Id { get => id; set => id = value; }
        public string Nom { get => nom;
            set {
                nom = value;

                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Nom)));
            }}
        public string UrlLogo { get => urlLogo; set => urlLogo = value; }
        public string Desc { get => desc; set => desc = value; }
        public DateTime DataCreacio { get => dataCreacio; set => dataCreacio = value; }
        public OC<Jugador> Jugador { get => jugador; set => jugador = value; }
        public Persona Coach { get => coach; set => coach = value; }
        public Conferencia Conf { get => conf; set => conf = value; }

        private static OC<Equip> llistaEquips;

        public Boolean Add(Jugador nouJugador)
        {
            if (this.Jugador.Contains(nouJugador))
            {
                return false;
            }

            this.Jugador.Add(nouJugador);

            return true;
        }

        public static OC<Equip> getLlistaEquips()
        {
            if(llistaEquips == null)
            {
                llistaEquips = new OC<Equip>();

                Equip e1 = new Equip(1, "Timberwolves", "https://a.espncdn.com/combiner/i?img=/i/teamlogos/nba/500/min.png", "The Minnesota Timberwolves are an American professional basketball team based in Minneapolis. The Timberwolves compete in the National Basketball Association (NBA) as a member of the league's Western Conference Northwest Division.[8] Founded in 1989, the team is owned by Glen Taylor who also owns the WNBA's Minnesota Lynx.[9] The Timberwolves play their home games at Target Center, their home since 1990.[10]Like most expansion teams, the Timberwolves struggled in their early years, but after the acquisition of Kevin Garnett in the 1995 NBA draft, the team qualified for the playoffs in eight consecutive seasons from 1997 to 2004.Despite losing in the first round in their first seven attempts, the Timberwolves won their first division championship in 2004 and advanced to the Western Conference Finals that same season.Garnett was also named the NBA Most Valuable Player for that season.[11] The team then went into rebuilding mode for more than a decade after missing the postseason in 2005, and trading Garnett to the Boston Celtics in 2007.[12] Garnett returned to the Timberwolves in a February 2015 trade and finished his career there, retiring in the 2016 offseason.The Timberwolves ended a 14 - year playoff drought when they returned to the postseason in 2018.", Conferencia.WEST, DateTime.Now);
                e1.Add(new Jugador(1,"Beasley", "Malik", "USA", "https://a.espncdn.com/combiner/i?img=/i/headshots/nba/players/full/3907822.png&h=80&w=110&scale=crop", 5));
                e1.Add(new Jugador(2, "Beverly", "Patrick", "ESP", "https://a.espncdn.com/combiner/i?img=/i/headshots/nba/players/full/3964.png&h=80&w=110&scale=crop", 2));
                e1.Add(new Jugador(3, "Leandro", "Bolmaro", "ESP", "https://a.espncdn.com/combiner/i?img=/i/headshots/nba/players/full/4683025.png&h=80&w=110&scale=crop", 9));
                e1.Add(new Jugador(4, "Anthony", "Edwards", "ESP", "https://a.espncdn.com/combiner/i?img=/i/headshots/nba/players/full/4594268.png&h=80&w=110&scale=crop", 1));

                e1.coach = new Persona(2, "Chris", "Finch", "USA", "https://chorus.stimg.co/22321661/08_1012324552_Finch1216.jpg");

                llistaEquips.Add(e1);

                Equip e2 = new Equip(3, "Sant Antonio Spurs", "https://upload.wikimedia.org/wikipedia/en/thumb/a/a2/San_Antonio_Spurs.svg/1200px-San_Antonio_Spurs.svg.png", $"The San Antonio Spurs are an American professional basketball team based in San Antonio. The Spurs compete in the National Basketball Association (NBA) as a member of the league's Western Conference Southwest Division. The team plays its home games at the AT&T Center in San Antonio.The Spurs are one of four former American Basketball Association(ABA) teams to remain intact in the NBA after the 1976 ABA–NBA merger[8][9] and are the only former ABA team to have won an NBA championship.[10] The franchise has won NBA championships in 1999, 2003, 2005, 2007, and 2014.[11] As of the 2019–20 season, the Spurs had the highest winning percentage among active NBA franchises.[12] As of May 2017, the Spurs had the best winning percentage of any franchise in the major professional sports leagues in the United States and Canada over the previous three decades.[13] From 1999–2000 to 2016–17, the Spurs won 50 games each season,[14] setting a record of 18 consecutive 50 - win seasons.[15] In the 2018–19 season, the Spurs matched an NBA record for most consecutive playoff appearances with 22.[16] The team's recent success has coincided with the tenure of current head coach Gregg Popovich[11][17] and with the playing careers of Spurs icons David Robinson (1989–2003) and Tim Duncan (1997–2016).", Conferencia.WEST, DateTime.Now);
 
                 e2.Add(new Jugador(10, "Amino", "Al-Farouq", "USA", "https://a.espncdn.com/combiner/i?img=/i/headshots/nba/players/full/4248.png&h=80&w=110&scale=crop", 5));
                e2.Add(new Jugador(20, "Bates-Diop", "Keita", "ESP", "https://a.espncdn.com/combiner/i?img=/i/headshots/nba/players/full/3136779.png&h=80&w=110&scale=crop", 31));
                e2.Add(new Jugador(30, "Collins", "Zach", "ESP", "https://a.espncdn.com/combiner/i?img=/i/headshots/nba/players/full/4066650.png&h=80&w=110&scale=crop", 33));
                e2.Add(new Jugador(40, "Drew", "Eubanks", "ESP", "https://a.espncdn.com/combiner/i?img=/i/headshots/nba/players/full/3914285.png&h=80&w=110&scale=crop", 14));

                e2.coach = new Persona(2, "Eubanks", "Drew", "USA", "https://www.nba.com/resources/static/team/v2/spurs/Schad/img/Spurs/Coaches/Pop.png");

                llistaEquips.Add(e2);


                Equip e3 = new Equip(3, "Miami Heat", "https://1000marcas.net/wp-content/uploads/2020/03/emblem-Miami-Heat.jpg", $"The Miami Heat are an American professional basketball team based in Miami. The Heat compete in the National Basketball Association (NBA) as a member of the league's Eastern Conference Southeast Division. The club plays its home games at FTX Arena, and has won three NBA championships.The franchise began play in the 1988–89 season as an expansion team.After a period of mediocrity, the Heat gained relevance during the 1990s following the appointment of former head coach Pat Riley as team president.Riley constructed the trades of Alonzo Mourning and Tim Hardaway, which propelled the team into playoff contention.Mourning and Hardaway led the Heat to four division titles, prior to their departures in 2001 and 2002, respectively.The team also experienced success after drafting Dwyane Wade in 2003.", Conferencia.EAST, DateTime.Now);

                e3.Add(new Jugador(11, "Adebayo", "Bam", "USA", "https://a.espncdn.com/combiner/i?img=/i/headshots/nba/players/full/4066261.png&h=80&w=110&scale=crop", 5));
                e3.Add(new Jugador(21, "Butler", "Jimmy", "USA", "https://a.espncdn.com/combiner/i?img=/i/headshots/nba/players/full/6430.png&h=80&w=110&scale=crop", 5));
                e3.Add(new Jugador(31, "Dedmon", "Dewayne", "USA", "https://a.espncdn.com/combiner/i?img=/i/headshots/nba/players/full/2580913.png&h=80&w=110&scale=crop", 5));
                e3.Add(new Jugador(41, "Garret", "Marcus", "USA", "https://a.espncdn.com/combiner/i?img=/i/headshots/nba/players/full/4277892.png&h=80&w=110&scale=crop", 5));

                e3.coach = new Persona(3, "Spoelstra", "Erik", "USA", "https://cdn.vox-cdn.com/thumbor/-_iYo39S_TuNz6XM9oPP-EgnMW8=/0x0:568x379/1200x800/filters:focal(0x0:568x379)/cdn.vox-cdn.com/uploads/chorus_image/image/20511165/gyi0061831298.0.jpg");

                llistaEquips.Add(e3);
            }
            return llistaEquips;
        }

        internal bool findText(string text)
        {
            return this.Nom.ToLower().Contains(text.ToLower()) ||
                this.Desc.ToLower().Contains(text.ToLower());
        }
    }
}
