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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProduct : ContentPage
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                if (namep.Text != null && descp.Text != null && pricep.Text != null && imagep.Text != null)
                {
                    string title = namep.Text;
                    string desc = descp.Text;
                    string image = imagep.Text;
                    int price = Convert.ToInt32(pricep.Text);
                    Product product = new Product();
                    product.Name = title;
                    product.Description = desc;
                    product.Price = price;
                    product.Photo = image;

                    App.dbContext.SaveProduct(product);
                    await Navigation.PushAsync(new AboutPage());
                }
                else
                {
                    DependencyService.Get<INotificationService>().ShowNotification("", "Введите все данные");
                }
            }
            catch (Exception ex)
            {

            }
            
          
            
        }
    }
}