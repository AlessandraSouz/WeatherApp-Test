using Weather.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new FavoriteCites()) { BarBackgroundColor = Color.FromHex("#17456F"), BarTextColor = Color.FromHex("#FAFAFA"), BackgroundColor = Color.FromHex("#CDD7E1") };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}