using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatExpress2.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static TatExpress2.Views.AboutPage;
using System.Text.RegularExpressions;

namespace TatExpress2.Views
{
    
    public partial class AddProduct_page : ContentPage
    {
        public AddProduct_page()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {

           

        }
        static bool IsNumeric(string input)
        {
            Regex regex = new Regex("^[0-9]+$");

            return regex.IsMatch(input);
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            Product product = new Product();
            if (Name.Text != "" && Price.Text != "" && Width.Text != "" && Height.Text != "" && Count.Text != "" && description.Text != "" && photourl.Text != "" && Width.Text != "")
            {
                product.Name = Name.Text;
                if (IsNumeric(Price.Text) && IsNumeric(Width.Text) && IsNumeric(Height.Text) && IsNumeric(Count.Text))
                {
                    product.Price = Convert.ToInt32(Price.Text);
                    product.Width = Width.Text;
                    product.Height = Height.Text;
                    product.Count = Convert.ToInt32(Count.Text);
                    product.Description = description.Text;
                    product.Photo = photourl.Text;
                    product.Store_id = Class1.vender.id;
                }
                else
                {
                    DependencyService.Get<INotificationService>().ShowNotification("", "Проверьте все данные");
                }
                    
                App.dbContext.AddProduct(product);
                DependencyService.Get<INotificationService>().ShowNotification("", "Успешно добавлено");
                await Navigation.PushAsync(new Store_page_vender());
            }
            else
            {
                DependencyService.Get<INotificationService>().ShowNotification("", "Введите все данные");
            }
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}