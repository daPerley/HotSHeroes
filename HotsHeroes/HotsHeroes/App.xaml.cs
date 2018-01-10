using Xamarin.Forms;

namespace HotsHeroes
{
	public partial class App : Application
	{
        public static string _dbPath = string.Empty;
        public static string _apiPath = @"https://api.hotslogs.com/Public/Data/Heroes";

        public App ()
		{
			InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string dbPath)
        {
            InitializeComponent();

            _dbPath = dbPath;

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart ()
		{
		}

		protected override void OnSleep ()
		{
		}

		protected override void OnResume ()
		{
		}
	}
}
