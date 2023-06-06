using Android.Content;
using Java.Lang;
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
    public partial class favotites : ContentPage
    {
        public favotites()
        {
            InitializeComponent();
            
            
        }

        protected override void OnAppearing()
        {
            
            if (Class1.auth != null)
            {


                int userId = Class1.auth.Id;
                var query = from desire in App.dbContext.GetDesire()
                            join desireProd in App.dbContext.GetDesire_prod() on desire.id equals desireProd.id_desire
                            join product in App.dbContext.GetProducts() on desireProd.id_prod equals product.id
                            where desire.User_id == userId
                            select new
                            {
                                product.id,
                                product.Name,
                                product.Price,
                                product.Count,
                                product.Description,
                                product.Mass,
                                product.Width,
                                product.Height,
                                product.Photo,
                                product.Store_id
                            };

                ProductCollection.ItemsSource = query.ToList();
            }
            else
            {
                DependencyService.Get<INotificationService>().ShowNotification("", "Авторизируйтесь");


            }
          
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Product_page());
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }


        //Добавление в корзину
        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {

        }
    }
}