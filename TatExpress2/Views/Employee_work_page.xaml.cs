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
    public partial class Employee_work_page : ContentPage
    {
        public Employee_work_page()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            if (Class1.order != null)
            {
                var query = from Order in App.dbContext.GetOrder()
                            join prod_order in App.dbContext.GetProd_order() on Order.id equals prod_order.id_order
                            join product in App.dbContext.GetProducts() on prod_order.id_prod equals product.id
                            where Order.id == Class1.order.id
                            group new { product, prod_order } by product.id into grouped
                            select new
                            {
                                Photo = grouped.First().product.Photo,
                                Name = grouped.First().product.Name,
                                Price = grouped.First().product.Price.ToString("N0") + " P",
                                id = grouped.Key,
                                Count = grouped.First().prod_order.Count

                            };

                ProductCollection.ItemsSource = query.ToList();

                int itemCount = (ProductCollection.ItemsSource as IList)?.Count ?? 0;
                countprod.Text = (itemCount).ToString();

                int totalPrice = (int)query.Sum(p => Convert.ToInt32(Regex.Replace(p.Price, "[^0-9]", "")) * p.Count / 2);
                // Update the itog_price label content
                itog_price.Text = totalPrice.ToString("N0") + " P";
                itog_price1.Text = totalPrice.ToString("N0") + " P";
            }
           

        }


    

     

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Order order = Class1.order;
            order.Status_id = 5;
            App.dbContext.SaveOrder(order);
            await Navigation.PushAsync(new employee_page());
        }
    }
}