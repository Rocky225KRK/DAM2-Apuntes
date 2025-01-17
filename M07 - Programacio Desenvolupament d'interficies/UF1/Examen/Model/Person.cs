using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tilinder.Model;

namespace Tilinder.Model
{
    public class Person:INotifyCollectionChanged
    {
        public string Name { get; set; }
        public Uri Photo { get; set; } // Store the image URI
        public double Weight { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public Gender Gender { get; set; } // Explicitly store the gender of the person
        public Gender Preference { get; set; } // Partner preference (Male, Female, or Both)
        public ObservableCollection<Person> OldCouples { get; set; } = new ObservableCollection<Person>();

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        // Initialize with some demo data
        private static ObservableCollection<Person> People;


        public Person()
        {
            OldCouples = new ObservableCollection<Person>();
        }

        public static ObservableCollection<Person> GetPeople()
        {
            if (People == null)
            {
                People = new ObservableCollection<Person>() {
                new Person { Name = "John", Photo = new Uri("https://randomuser.me/api/portraits/men/33.jpg"), Weight = 80, Age = 28, Description = "Loves the outdoors.", Gender = Gender.Male, Preference = Gender.Female    },
                new Person { Name = "Mike", Photo = new Uri("https://randomuser.me/api/portraits/men/34.jpg"), Weight = 75, Age = 30, Description = "Guitar enthusiast.", Gender = Gender.Male, Preference = Gender.Male},
                new Person { Name = "David", Photo = new Uri("https://randomuser.me/api/portraits/men/35.jpg"), Weight = 82, Age = 34, Description = "Enjoys traveling.", Gender = Gender.Male, Preference = Gender.Female },
                new Person { Name = "Alice", Photo = new Uri("https://randomuser.me/api/portraits/women/85.jpg"), Weight = 55, Age = 25, Description = "Loves painting.", Gender = Gender.Female, Preference = Gender.Male },
                new Person { Name = "Eve", Photo = new Uri("https://randomuser.me/api/portraits/women/24.jpg"), Weight = 60, Age = 27, Description = "Yoga fan.", Gender = Gender.Female, Preference = Gender.Other },
                new Person { Name = "Sarah", Photo = new Uri("https://randomuser.me/api/portraits/women/37.jpg"), Weight = 58, Age = 29, Description = "Cooking and reading books.", Gender = Gender.Female, Preference = Gender.Male },

                // A couple of examples for people preferring both genders
                new Person { Name = "Alex", Photo = new Uri("https://randomuser.me/api/portraits/men/36.jpg"), Weight = 70, Age = 26, Description = "Loves movies and gaming.", Gender = Gender.Male, Preference = Gender.Other },
                new Person { Name = "Jordan", Photo = new Uri("https://randomuser.me/api/portraits/women/50.jpg"), Weight = 65, Age = 32, Description = "Artist and photographer.", Gender = Gender.Female, Preference = Gender.Other }
            };
            }

            return People;

        }
    }
}
