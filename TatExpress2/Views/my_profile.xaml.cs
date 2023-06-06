using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatExpress2.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static TatExpress2.Views.AboutPage;

namespace TatExpress2.Views
{
    
    public partial class My_profile : ContentPage
    {
        public My_profile()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {

            User user = App.dbContext.GetUsers().FirstOrDefault(s => s.Id == Class1.auth.Id);
            if (user.Name != null && user.Name != "null")
            {
                name.Text = user.Name;
            }
            else
            {
                name.Text = "Имя";
            }
            if (user.Surname != null)
            {
                surname.Text = user.Surname;
            }
            else
            {
                surname.Text = "";
            }
            if (user.Email != null)
            {
                email.Text = user.Email;
            }

            if (user.Photo != null)
            {
                photo.Source = user.Photo.ToString();
            }


            try
            {
                if (user.Telephone != null)
                {
                    telephone.Text = user.Telephone;
                    photourl.Text = user.Photo.ToString();
                }
            }
            catch{ }

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            User user = App.dbContext.GetUsers().FirstOrDefault(s => s.Id == Class1.auth.Id);

            user.Name = name.Text.ToString();
            user.Email = email.Text.ToString();
            user.Telephone = telephone.Text.ToString();
            user.Photo = photourl.Text.ToString();
            user.Surname = surname.Text.ToString();
            App.dbContext.SaveUser(user);
            DependencyService.Get<INotificationService>().ShowNotification("", "Успешно сохранено");
            await Navigation.PushAsync(new AccountReg());
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}