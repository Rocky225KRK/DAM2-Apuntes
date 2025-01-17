using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace ExerciciDiccionaris
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/RomeoAndJuliet.txt"));
            using (var inputStream = await file.OpenReadAsync())
            using (var classicStream = inputStream.AsStreamForRead())
            using (var streamReader = new StreamReader(classicStream))
            {
                DateTime before = DateTime.Now;
                //List<String> list = new List<String>();
                Dictionary<String,Int32> dict= new Dictionary<String,Int32>();
                char[] separators = { ',', ' ', '.', ':', ';', '-', '!', '?', '\'' };
                while (streamReader.Peek() >= 0)
                {
                    String[] arrayStr = streamReader.ReadLine().ToLower().Split(separators,StringSplitOptions.RemoveEmptyEntries);
                    foreach (String str in arrayStr)
                    {
                        if (dict.ContainsKey(str))
                        {
                            dict[str]++;
                        }
                        else
                        {
                            dict[str] = 1;
                        }
                        //if (!list.Contains(str))
                        //{
                        //    list.Add(str);
                        //}
                    }
                }

                List<KeyValuePair<String, Int32>> list=dict.ToList();
                list.Sort((valor1,valor2)=>valor2.Value-valor1.Value);

                //Debug.WriteLine("Hi han " + list.Count + " paraules diferents");
                Debug.WriteLine("Hi han " + dict.Count + " paraules diferents");
                Debug.WriteLine("Top 10 paraules que més han sortit:");
                for (int i = 0; i < 10; i++)
                {
                    Debug.WriteLine("Nº "+(i+1)+":\n\t- Paraula: " + list[i].Key +"\n\t- Contador: " + list[i].Value);
                }

                DateTime after = DateTime.Now;

                TimeSpan t = after - before;
                double ms = t.TotalMilliseconds;
                Debug.WriteLine("Temps d'execució: " + ms);
            }
        }
    }
}