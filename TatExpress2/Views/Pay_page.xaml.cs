using Android.Content;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
    public partial class Pay_page : ContentPage
    {
        public Pay_page()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadProducts();
            Order order = Class1.order;
            itog_price.Text = order.Price.ToString() + "₽";
            itog_price1.Text = order.Price.ToString() + "₽";
            countprod.Text = order.Count.ToString();
        }
        void LoadProducts()
        {

            // Retrieve products from the database

            var pick_Point = App.dbContext.GetPick_point();
            // Clear any existing items in the Picker
            ProductPicker.Items.Clear();

            // Add the retrieved products to the Picker
            foreach (var pick in pick_Point)
            {
                ProductPicker.Items.Add(pick.Street);
            }
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
      
            var selectedProductName = ProductPicker.SelectedItem as string;
            if (selectedProductName != null)
            {
                Pick_point pick_Point = App.dbContext.GetPick_point().FirstOrDefault(s => s.Street == selectedProductName);
                if (number.Text != null && cvv.Text != null && month != null && year != null)
                {
                    if (pick_Point != null)
                    {
                        PP_order pp_order = new PP_order();
                        {
                            pp_order.id_pp = pick_Point.id;
                            pp_order.Order_id = Class1.order.id;

                        };
                        App.dbContext.AddPP_order(pp_order);
                        Order order = App.dbContext.GetOrder().FirstOrDefault(s => s.id == Class1.order.id);

                        order.Status_id = 2;
                        App.dbContext.SaveOrder(order);
                        Class1.order = null;
                        await Navigation.PushAsync(new AboutPage());

                    }
                }
                else
                {
                    DependencyService.Get<INotificationService>().ShowNotification("", "Введите данные");
                }
            }
            else
            {
                DependencyService.Get<INotificationService>().ShowNotification("", "Введите данные");
            }
        }
    }
}