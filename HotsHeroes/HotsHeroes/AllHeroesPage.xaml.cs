using HotsHeroes.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HotsHeroes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllHeroesPage : ContentPage
    {
        private List<Hero> _heroes;

        public AllHeroesPage()
        {
            InitializeComponent();

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

                _heroes = result;

                return result;
            }
            else
            {
                return new List<Hero>() { new Hero { PrimaryName = "No found", Group = "No favorites found" } };
            }
        }

        private void Search_OnChange(object sender, TextChangedEventArgs e)
        {
            var keyword = searchBar.Text.ToLower();
            var searchResult = _heroes.Where(h => h.PrimaryName.ToLower().Contains(keyword));

            if (searchResult.Count() > 0)
                favoritesListView.ItemsSource = searchResult;
            else
                favoritesListView.ItemsSource = new List<Hero>() { new Hero { PrimaryName = "No found", Group = "No favorites found" } };
        }
    }
}