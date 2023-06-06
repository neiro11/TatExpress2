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
	public partial class Orders_page : ContentPage
	{
		public Orders_page ()
		{
			InitializeComponent ();
            
          
           
        }

        protected override void OnAppearing()
        {
            if (Class1.auth == null)
            {
                DependencyService.Get<INotificationService>().ShowNotification("", "Пожалуйста авторизируйтесь");
            }
            else
            {
                int userId = Class1.auth.Id;
                var query = from order in App.dbContext.GetOrder()
                            join status in App.dbContext.GetStatus() on order.Status_id equals status.id

                            where order.User_id == userId
                            select new
                            {
                                order.id,
                                order.Price,
                                status.Name,
                                order.Count,
                                order.Date_create
                            };
                OrderCollection.ItemsSource = query.ToList();
            }

        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}