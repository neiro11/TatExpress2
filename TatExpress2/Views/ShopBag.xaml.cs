using Android.Content;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TatExpress2.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static TatExpress2.Views.AboutPage;

namespace TatExpress2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShopBag : ContentPage
	{
		public ShopBag ()
		{
			InitializeComponent ();
        }

        protected override void OnAppearing()
        {
            if (Class1.auth != null)
            {
                int userId = Class1.auth.Id;
                var query = from cart in App.dbContext.GetShoppping_cart()
                            join cartProd in App.dbContext.GetShop_cart_prod() on cart.Id equals cartProd.id_shop_cart
                            join product in App.dbContext.GetProducts() on cartProd.id_prod equals product.id
                            where cart.User_id == userId
                            select new
                            {
                                product.Photo,
                                product.Name,
                                Price = product.Price.ToString("N0") + " P",
                                product.id,
                                cartProd.count
                            };

                ProductCollection.ItemsSource = query.ToList();
                int itemCount = (ProductCollection.ItemsSource as IList)?.Count ?? 0; //кол-во элементов в shop_bag
                countprod.Text = (itemCount).ToString();
                
                int totalPrice = (int)query.Sum(p => Convert.ToInt32(Regex.Replace(p.Price, "[^0-9]", "")) * p.count);
                // Update the itog_price label content
                itog_price.Text = totalPrice.ToString("N0") + " P";
                itog_price1.Text = totalPrice.ToString("N0") + " P";
            }
            else
            {
                DependencyService.Get<INotificationService>().ShowNotification("", "Авторизируйтесь");


            }
          
        }

        private void count_TextChanged(object sender, TextChangedEventArgs e)
        {
            //try
            //{
            //    //string newText = e.NewTextValue;
            //    //if (newText != "" && newText != "1" && newText != "0")
            //    //{
            //    //    int itemCount = (ProductCollection.ItemsSource as IList)?.Count ?? 0; //кол-во элементов
            //    //    CustomEntry entry = (CustomEntry)sender;
            //    //    string productId = (string)entry.BindingContext;

            //    //    string a = productId;

            //    //    string price_it = itog_price.Text.ToString();
            //    //    string p = price_it.Substring(0, price_it.Length - 2);
            //    //    p = new string(p.Where(c => !Char.IsWhiteSpace(c)).ToArray());
            //    //    p = Convert.ToString(Convert.ToInt32(p) * Convert.ToInt32(newText)); // изменение суммы корзины
            //    //    itog_price.Text = p.ToString() + " P";
            //    //    itog_price1.Text = p.ToString() + " P";

            //    //    countprod.Text = (itemCount + Convert.ToInt32(newText) - 1).ToString();

            //    //    //var shop_cart_prod = App.dbContext.GetShop_cart_prod().FirstOrDefault(sc => sc.id_prod == Convert.ToInt32(productId));
            //    //    //if(shop_cart_prod != null)
            //    //    //{
            //    //    //    shop_cart_prod.count = Convert.ToInt32(newText);
            //    //    //    App.dbContext.SaveShop_cart_prod(shop_cart_prod);
            //    //    //}
            //    //}
                
            //}
            //catch(Exception ex)
            //{

            //}
        }

     

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                int itemCount = (ProductCollection.ItemsSource as IList)?.Count ?? 0;
                Order order = new Order();
                    Class1.order = order;
                    order.Date_create = Convert.ToString(DateTime.Now);
                    order.User_id = Class1.auth.Id;
                    order.Count = itemCount;
                    string price_it = itog_price.Text.ToString();
                    string p = price_it.Substring(0, price_it.Length - 2);
                    p = new string(p.Where(c => !Char.IsWhiteSpace(c)).ToArray());
                    order.Price = Convert.ToInt32(p);
                    order.Status_id = 1;

                    // Add the Order object to the database
                    App.dbContext.AddOrder(order);

                foreach (var item in ProductCollection.ItemsSource)
                {

                    // Получение Id и Count у продукта
                    var productId = (int)item.GetType().GetProperty("id").GetValue(item);
                    Product product = App.dbContext.GetProducts().FirstOrDefault(cp => cp.id == productId);
                    int productQuantity = (int)item.GetType().GetProperty("count").GetValue(item);
                    product.Count = Convert.ToInt32(product.Count) - productQuantity;
                    // Создание нового Prod_order
                   

                    // Создание нового Prod_order
                    Prod_order prodOrder = new Prod_order
                    {
                        id_prod = productId,
                        id_order = order.id,
                        Count = productQuantity,
                        
                    };
                    App.dbContext.SaveProduct(product);
                    // Добавление Prod_order в БД
                    App.dbContext.AddProd_order(prodOrder);
                    App.dbContext.SaveProd_order(prodOrder);
                }
                int userId = Class1.auth.Id;

                // Retrieve the shopping cart record for the current user
                var shoppingCart = App.dbContext.GetShoppping_cart().FirstOrDefault(sc => sc.User_id == userId);

                if (shoppingCart != null)
                {
                    // Retrieve all the shop_cart_prod records for the shopping cart
                    
                    var cartProducts = App.dbContext.GetShop_cart_prod().Where(cp => cp.id_shop_cart == shoppingCart.Id).ToList();

                    // Delete all the shop_cart_prod records
                    foreach (var cartProduct in cartProducts)
                    {
                        App.dbContext.RemoveShop_cart_prod(cartProduct);
                    }
                   

                    // Save the changes to the database
                }
                App.dbContext.SaveShoppping_cart(shoppingCart);
                await Navigation.PushAsync(new Pay_page());
            }
            catch (Exception ex)
            {

            }
        }
    }
}