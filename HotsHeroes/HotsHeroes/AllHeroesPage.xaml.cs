using HotsHeroes.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HotsHeroes
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AllHeroesPage : ContentPage
	{
		public AllHeroesPage ()
		{
			InitializeComponent ();

            favoritesListView.ItemsSource = GetAllHeroes();
        }

        private List<Hero> GetAllHeroes()
        {
            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(App._apiPath).Result;

            if (response.IsSuccessStatusCode)
            {
                var heroes = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<IEnumerable<Hero>>(heroes).ToList();

                return result;
            }
            else
            {
                return new List<Hero>() { new Hero { PrimaryName = "No found", Group = "No favorites found" } };
            }
        }
    }
}