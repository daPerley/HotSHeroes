using System.IO;

namespace HotsHeroes.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            string fileName = "hots_db.sqlite";
            string fileLocation = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            string fullPath = Path.Combine(fileLocation, fileName);

            LoadApplication(new HotsHeroes.App(fullPath));
        }
    }
}
