using Android.Transitions;
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
	public partial class vender_reg : ContentPage
	{
		public vender_reg ()
		{
			InitializeComponent ();
		}

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync(); 
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //Пользователь
            var user = App.dbContext.GetUsers().FirstOrDefault(u => u.Email == email.Text);

            //Продавец
            var vender = App.dbContext.GetVender().FirstOrDefault(u => u.Email == email.Text);

            //Владелец ПВЗ
            var pp_owner = App.dbContext.GetPP_owner().FirstOrDefault(u => u.Email == email.Text);

            //Сотрудник
            var employe = App.dbContext.GetEmployee().FirstOrDefault(u => u.Email == email.Text);
            if (pass.Text == pass1.Text)
            {
                if (vender == null )
                    //&& vender == null && pp_owner == null && employe == null
                {
                    Vender user1 = new Vender();
                    user1.name = "null".ToString();
                    user1.Email = email.Text.ToString();
                    user1.Telephone = "null".ToString();
                    user1.Password = pass.Text.ToString();
                    App.dbContext.AddVender(user1);
                    DependencyService.Get<INotificationService>().ShowNotification("", "Успешная регистрация");
                    Class1.vender= user1;
                    await Navigation.PushAsync(new vender_prof());
                }
                else
                {
                    DependencyService.Get<INotificationService>().ShowNotification("", "Такой аккаунт уже существует");
                }
            }
            else
            {
                DependencyService.Get<INotificationService>().ShowNotification("", "Введите корректные данные");
            }
        }
    }
}