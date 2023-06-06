using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TatExpress2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            pass.IsPassword = false;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registration());
        }

        private async void ImageButton_Clicked_1(object sender, EventArgs e)
        {

            await Navigation.PopAsync();

        }
        public bool a = false;
        private async void Button_Clicked(object sender, EventArgs e)
        {

            Login(email.Text, pass.Text);
        }
        public async void Login(string email, string pass)
        {
            // Пользователь
            var user = App.dbContext.GetUsers().FirstOrDefault(u => u.Email == email && u.Password == pass);
            if (user != null)
            {
                Class1.auth = null;
                Class1.auth = user;
                await Navigation.PushAsync(new AccountReg());
                a = true;
            }
            //Продавец
            var vender = App.dbContext.GetVender().FirstOrDefault(u => u.Email == email && u.Password == pass);
            if (vender != null)
            {
                Class1.vender = null;
                Class1.vender = vender;
                await Navigation.PushAsync(new vender_prof());
                a= true;
            }
            //Владелец ПВЗ
            var pp_owner = App.dbContext.GetPP_owner().FirstOrDefault(u => u.Email == email && u.Password == pass);
            if (pp_owner != null)
            {
                Class1.pp_Owner = null;
                Class1.pp_Owner = pp_owner;
                await Navigation.PushAsync(new pp_owner());
                a=true;
            }
            //Сотрудник
            var employe = App.dbContext.GetEmployee().FirstOrDefault(u => u.Email == email && u.Password == pass);
            if (employe != null)
            {
                Class1.employee = null;
                Class1.employee = employe;
                await Navigation.PushAsync(new employee_page());
                a = true;
            }
        }
        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new vender_reg());
        }
    }
}
