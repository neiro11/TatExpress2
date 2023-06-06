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

    public partial class Store_page_vender : ContentPage
    {
        public Store_page_vender()
        {
            InitializeComponent();
            
        }

        protected override void OnAppearing()
        {
            Class1.store = null;
            Store store =  App.dbContext.GetStore().FirstOrDefault(s => s.id_vender == Class1.vender.id);
            if (store != null)
            {
                

                Class1.store = store;
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
            else
            {
                update.Text = "Создать магазин";
            }
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registration());
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

        //добавление товара
        private async void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            if (Class1.store != null)
            {
                await Navigation.PushAsync(new AddProduct_page());
            }
            else
            {
                DependencyService.Get<INotificationService>().ShowNotification("", "У вас нет магазина");
            }
        }
        //изменение данных
        private void Button_Clicked_1(object sender, EventArgs e)
        {

            if (Class1.store != null)
            {

                Store store = App.dbContext.GetStore().FirstOrDefault(s => s.id_vender == Class1.store.id);
                if (name.Text != null)
                {
                    store.Name = name.Text;
                }
                else
                {
                    store.Name = Class1.store.Name;
                }
                if (logo.Text != null)
                {
                    store.Logo = logo.Text;
                }
                else {
                    store.Logo = Class1.store.Logo;
                }
                if (description.Text != null)
                {
                    store.Description = description.Text;
                }
                else
                {
                    store.Description = Class1.store.Description;
                }
                    App.dbContext.SaveStore(store);
                    DependencyService.Get<INotificationService>().ShowNotification("", "Данные изменены");
               
                OnAppearing();
            }
            else
            {
                if (name.Text != null && logo.Text != null && description.Text != null)
                {
                    Store store = new Store();
                    store.Name = name.Text;
                    store.Logo = logo.Text;
                    store.Description = description.Text;
                    store.id_vender = Class1.vender.id;
                    App.dbContext.AddStore(store);
                    DependencyService.Get<INotificationService>().ShowNotification("", "Магазин создан");
                }
                else
                {
                    DependencyService.Get<INotificationService>().ShowNotification("", "Введите все данные");
                }
                OnAppearing();
            }
        }
    }
}