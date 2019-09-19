using System.Threading.Tasks;
using Xamarin.Forms;

namespace Weather.Utils
{
    public class NavigationUtil
    {
        private static readonly INavigation Navigation = App.Current.MainPage.Navigation;
        public static async Task PushAsync(Page page) => await Navigation.PushAsync(page);
        public static async Task PopAsync() => await Navigation.PopAsync();
        public static void RemovePage(Page page) => Navigation.RemovePage(page);
        public static void InsertPageBefore(Page page, Page before) => Navigation.InsertPageBefore(page, before);
    }
}