using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatExpress2.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TatExpress2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountReg : ContentPage
    {
        public AccountReg()
        {
            InitializeComponent();

        }
        protected override void OnAppearing()
        {
            User user = App.dbContext.GetUsers().FirstOrDefault(s => s.Id == Class1.auth.Id);

            name.Text = user.Name;
            if (user.Surname != null)
            {
                surname.Text = user.Surname;
            }
            else
            {
                surname.Text = "";
            }
            email.Text = user.Email;
            if (user.Photo != null)
            {
                photo.Source = user.Photo.ToString();
            }
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Account());
            Class1.auth = null;
        }

        //мой профиль
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new My_profile());
        }

        //пвз на карте
        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Maps());
        }

        //мои заказы
        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Orders_page());
        }
    }
}