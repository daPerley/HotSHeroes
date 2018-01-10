using HotsHeroes.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Xamarin.Forms;

namespace HotsHeroes
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            favoritesListView.ItemsSource = GetRandomHeroes(); 
        }

        private List<Hero> GetRandomHeroes()
        {
            //Replace with favs

            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(App._apiPath).Result;

            if (response.IsSuccessStatusCode)
            {
                var heroes = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<IEnumerable<Hero>>(heroes).ToList();

                Random rnd = new Random();
                var randomList = new List<Hero>();

                for (int i = 0; i < 3; i++)
                {
                    randomList.Add(result[rnd.Next(result.Count)]);
                }

                foreach (var hero in randomList)
                {
                    hero.ImageURL = @"http://media.blizzard.com/heroes/" + hero.ImageURL.Replace(".", "-").Replace("ú", "u").Replace("'", "").Replace("Cho", "chogall").Replace("Gall", "chogall").Replace("LiLi", "Li-Li").Replace("TheButcher", "The-Butcher").Replace("TheLostVikings", "the-lost-vikings") + "/bust.jpg";
                }

                return randomList;
            }
            else
            {
                return new List<Hero>() { new Hero { PrimaryName = "No found", Group = "No favorites found" } };
            }
        }

        private void Heroes_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AllHeroesPage());
        }
    }
}
