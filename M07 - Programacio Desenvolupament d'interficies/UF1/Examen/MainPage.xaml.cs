using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Tilinder.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Examen
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<Person> matches;
        private List<Pair> pairs = new List<Pair>();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            grvPeople.ItemsSource = Person.GetPeople();

            btnMakeCouple.IsEnabled = false;
            btnSeparateCouple.IsEnabled = false;
        }

        private void btnMakeCouple_Click(object sender, RoutedEventArgs e)
        {
            if(grvPeople.SelectedItem is Person person1 && grvMatches.SelectedItem is Person person2)
            {
                pairs.Add(new Pair(person1, person2));
                Person.GetPeople().Remove(person1);
                Person.GetPeople().Remove(person2);

                grvCouples.ItemsSource = null;
                grvCouples.ItemsSource = pairs;
            }
        }

        private void btnSeparateCouple_Click(object sender, RoutedEventArgs e)
        {
            if(grvCouples.SelectedItem is Pair selected)
            {

                selected.PersonA.OldCouples.Add(selected.PersonB);
                selected.PersonB.OldCouples.Add(selected.PersonA);

                Person.GetPeople().Add(selected.PersonA);
                Person.GetPeople().Add(selected.PersonB);

                pairs.Remove(selected);

                grvCouples.ItemsSource = null;
                grvCouples.ItemsSource = pairs;
            }
        }

        private void grvPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            activateButton();
            matches = new List<Person>();
            if(grvPeople.SelectedItem is Person selected)
            {
                foreach(Person person in Person.GetPeople())
                {
                    if(personPreference(selected,person))
                    {
                        matches.Add(person);
                    }
                }
            }
            grvMatches.ItemsSource = null;
            grvMatches.ItemsSource = matches;
        }

        private void grvMatches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            activateButton();
        }

        private void grvCouples_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(grvCouples.SelectedItem is Pair)
            {
                btnSeparateCouple.IsEnabled = true;
            }
            else
            {
                btnSeparateCouple.IsEnabled = false;
            }
        }

        private void cboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grvPeople != null)
            {
                List<Person> filter = new List<Person>();
                Debug.WriteLine(cboFilter.SelectedIndex);
                grvPeople.ItemsSource = null;
                switch (cboFilter.SelectedIndex)
                {
                    case 0: grvPeople.ItemsSource = Person.GetPeople(); break;
                    case 1:
                        foreach (Person person in Person.GetPeople())
                        {
                            if (person.Age >= 18 && person.Age < 20) filter.Add(person);
                        }
                        grvPeople.ItemsSource = filter;
                        break;
                    case 2:
                        foreach (Person person in Person.GetPeople())
                        {
                            if (person.Age >= 20 && person.Age < 30) filter.Add(person);
                        }
                        grvPeople.ItemsSource = filter;
                        break;
                    case 3:
                        foreach (Person person in Person.GetPeople())
                        {
                            if (person.Age >= 30 && person.Age < 40) filter.Add(person);
                        }
                        grvPeople.ItemsSource = filter;
                        break;
                    case 4:
                        foreach (Person person in Person.GetPeople())
                        {
                            if (person.Age >= 40 && person.Age < 50) filter.Add(person);
                        }
                        grvPeople.ItemsSource = filter;
                        break;
                    case 5:
                        foreach (Person person in Person.GetPeople())
                        {
                            if (person.Age >= 50 && person.Age < 60) filter.Add(person);
                        }
                        grvPeople.ItemsSource = filter;
                        break;
                }
            }
        }

        private void activateButton()
        {
            if(grvPeople.SelectedItem is Person && grvMatches.SelectedItem is Person)
            {
                btnMakeCouple.IsEnabled = true;
            }
            else
            {
                btnMakeCouple.IsEnabled = false;
            }
        }

        private bool personPreference(Person person1, Person person2)
        {
            if (person1.Equals(person2)) return false;

            if (person1.Preference.Equals(person2.Gender))
            {
                if (person2.Preference.Equals(person1.Gender)) return true;
            }

            if (person1.Preference.Equals(Gender.Other) && person2.Preference.Equals(Gender.Other)) return true;

            return false;
        }
    }
}
