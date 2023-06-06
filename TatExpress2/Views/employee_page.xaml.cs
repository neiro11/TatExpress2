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
    
    public partial class employee_page : ContentPage
    {
        public employee_page()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {

            int employeeId = Class1.employee.id;
            var query = from order in App.dbContext.GetOrder()
                        join status in App.dbContext.GetStatus() on order.Status_id equals status.id
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

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Class1.order = null;
            Button button = (Button)sender;
            int orderId = (int)button.CommandParameter;
            Order order = App.dbContext.GetOrder().FirstOrDefault(s => s.id == orderId);
            if (order != null)
            {
                
                Class1.order = order;
                await Navigation.PushAsync(new Employee_work_page());
            }
        }

       
    }
}