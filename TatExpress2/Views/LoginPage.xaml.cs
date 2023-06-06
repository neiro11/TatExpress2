using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace TatExpress2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        public async void OpenWebLink(string url)
        {
            await Browser.OpenAsync(url, BrowserLaunchMode.SystemPreferred);
        }

        public async void Button_Clicked(object sender, EventArgs e)
        {
            Register page = new Register();
            await Navigation.PushModalAsync(page);
           
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
             OpenWebLink("https://www.vk.com");
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            DisplayAlert("Пожалуйста зарегистрируйтесь!", "Для получения истории заказов необходимо войти, либо зарегистрироваться.", "ОК");
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            DisplayAlert("Пожалуйста зарегистрируйтесь!", "Для получения истории заказов необходимо войти, либо зарегистрироваться.", "ОК");
        }
    }
}