using Android.Content;
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
    public partial class Product_page : ContentPage
    {
        public Product_page()
        {
            InitializeComponent();
            Product product = Class1.product;
            img.Source = product.Photo;
            cost.Text = product.Price.ToString();
            namep.Text = product.Name.ToString();
            count.Text = product.Count.ToString();
            desc.Text = product.Description.ToString();
            Store store = App.dbContext.GetStore().FirstOrDefault(s => s.id == product.Store_id);
            logo_store.Source = store.Logo;
            name_store.Text = store.Name.ToString();
            Class1.store = store;
        }



        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            if (Class1.auth != null)
            {
                int id_user = Class1.auth.Id;
                Desire desire = App.dbContext.GetDesire().FirstOrDefault(s => s.User_id == id_user);

                //добавление избранного если ее не было
                if (desire == null)
                {
                    desire = new Desire();
                    desire.User_id = id_user;
                    App.dbContext.AddDesire(desire);
                    App.dbContext.SaveDesire(desire);
                }
                //добавление товара в избранное
                Desire_prod Shop_cart_Prod1 = App.dbContext.GetDesire_prod().FirstOrDefault(s => s.id_prod == Class1.product.id && s.id_desire == desire.id);
                if (Shop_cart_Prod1 == null)
                {
                    Desire_prod desire_Prod = new Desire_prod
                    {
                        id_prod = Class1.product.id,
                        id_desire = desire.id,


                    };
                    App.dbContext.AddDesire_prod(desire_Prod);
                }
                //Если товар уже есть в избранных у этого пользователя 
                else
                {
                    DependencyService.Get<INotificationService>().ShowNotification("", "У вас уже есть этот товар в избранных");

                }
                App.dbContext.SaveDesire(desire);
                DependencyService.Get<INotificationService>().ShowNotification("", "Товар добавлен в избранные");
            }
            else
            {
                DependencyService.Get<INotificationService>().ShowNotification("", "Пожалуйста авторизируйтесь");
            }
        }

        private async void Voiti_Clicked(object sender, EventArgs e)
        {
            if (Class1.auth != null)
            {
                int id_user = Class1.auth.Id;
                Shoppping_cart shoppping_Cart = App.dbContext.GetShoppping_cart().FirstOrDefault(s => s.User_id == id_user);

                //добавление корзины если ее не было
                if (shoppping_Cart == null)
                {
                    shoppping_Cart = new Shoppping_cart
                    {
                        User_id = id_user
                    };
                    App.dbContext.AddShoppping_cart(shoppping_Cart);
                    //App.dbContext.SaveShoppping_cart(shoppping_Cart);
                }
                //добавление товара в корзину
                Shop_cart_Prod Shop_cart_Prod1 = App.dbContext.GetShop_cart_prod().FirstOrDefault(s => s.id_prod == Class1.product.id && s.id_shop_cart == shoppping_Cart.Id);
                if (Shop_cart_Prod1 == null)
                {
                    Shop_cart_Prod shop_Cart_Prod = new Shop_cart_Prod
                    {
                        id_prod = Class1.product.id,
                        id_shop_cart = shoppping_Cart.Id,
                        count = 1

                    };
                    App.dbContext.AddShop_cart_prod(shop_Cart_Prod);
                   

                }
                //Если товар уже есть в корзине у этого пользователя 
                else
                {

                    Shop_cart_Prod1.count += 1;
                    App.dbContext.SaveShop_cart_prod(Shop_cart_Prod1);
                }
                DependencyService.Get<INotificationService>().ShowNotification("", "Товар добавлен");
                await Navigation.PushAsync(new AboutPage());
            }
            else
            {
                DependencyService.Get<INotificationService>().ShowNotification("", "Авторизируйтесь");
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Store_page());
        }
    }
}