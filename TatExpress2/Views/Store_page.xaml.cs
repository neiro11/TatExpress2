using Android.Content;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TatExpress2.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static TatExpress2.Views.AboutPage;

namespace TatExpress2.Views
{

    public partial class Store_page : ContentPage
    {
        public Store_page()
        {
            InitializeComponent();
            
        }

        protected override void OnAppearing()
        {
            store_name.Text = Class1.store.Name;
            desc.Text = Class1.store.Description;
            photo_store.Source = Class1.store.Logo.ToString();
            int storeId = Class1.store.id;
            var query = from p in App.dbContext.GetProducts()
                        where p.Store_id == storeId
                        select new
                        {
                            p.Name,
                            p.Price,
                            p.Photo
                        };
            ProductCollection.ItemsSource = query.ToList();
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Product_page());
        }

        //Описание товара
        private  void TapGestureRecognizer_Tapped(object sender, EventArgs e)
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