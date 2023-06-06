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
    
    public partial class vender_prof : ContentPage
    {
        public vender_prof()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {

            Vender vender = App.dbContext.GetVender().FirstOrDefault(s => s.id == Class1.vender.id);
            if (vender.name != null && vender.name != "null")
            {
                name.Text = vender.name;
            }
            else
            {
                name.Text = "Имя";
            }
            if (vender.surname != null)
            {
                surname.Text = vender.surname;
            }
            else
            {
                surname.Text = "";
            }
            if (vender.Email != null)
            {
                email.Text = vender.Email;
            }
            if(vender.Adress != null)
            {
                addres.Text = vender.Adress;
            }
            if(vender.КПП != null)
            {
                kpp.Text = vender.КПП;
            }
            if(vender.patronymic != null)
                patronymic.Text = vender.patronymic;
            if (vender.ОГРНИП != null)
                ogrnip.Text = vender.ОГРНИП.ToString();
            if (vender.Форма_регистрации != null)
                reg_form.Text = vender.Форма_регистрации;
            if (vender.БИК != null)
                bik.Text = vender.БИК.ToString();
            if (vender.Расчетный_счет != null)
                rasch_chet.Text = vender.Расчетный_счет;

            try
            {
                if (vender.Telephone != null)
                {
                    telephone.Text = vender.Telephone;
                }
            }
            catch{ }

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Vender user = App.dbContext.GetVender().FirstOrDefault(s => s.id == Class1.vender.id);

            user.name = name.Text.ToString();
            user.Email = email.Text.ToString();
            user.Telephone = telephone.Text.ToString();
            user.surname = surname.Text.ToString();
            user.Adress = addres.Text.ToString();
            user.КПП = kpp.Text.ToString();
            user.БИК = bik.Text.ToString();
            user.Расчетный_счет = rasch_chet.Text.ToString();
            user.ОГРНИП = ogrnip.Text.ToString();
            user.Форма_регистрации = reg_form.Text.ToString();
            user.patronymic = patronymic.Text.ToString();
            App.dbContext.SaveVender(user);
            DependencyService.Get<INotificationService>().ShowNotification("", "Успешно сохранено");
            
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Store_page_vender());
        }
    }
}