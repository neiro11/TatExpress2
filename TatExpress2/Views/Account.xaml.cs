using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TatExpress2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Account : ContentPage
    {
        public Account()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registration());
        }

        //⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
        //⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⠿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
        //⡿⠛⠋⠉⣉⣀⣀⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣄⣀⣉⠉⠙⠛⢿
        //⣿⣾⠛⠋⠉⠉⠁⢀⡀⠄⠄⠹⠟⠁⠄⢀⣀⠄⠉⠉⠙⠛⢷⣿
        //⣿⣿⣷⣤⣠⣾⣿⣿⣷⠄⠄⠄⠄⠄⠄⣸⣿⣿⣷⣦⣤⣶⣿⣿
        //⣿⣿⣿⣿⣿⣿⣿⣿⣿⡀⠄⠄⠄⠄⠄⣿⣿⣿⣿⣿⣿⣿⣿⣿
        //⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠄⠄⠄⠄⢰⣿⣿⣿⣿⣿⣿⣿⣿⣿
        //⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⠄⠄⠄⠄⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿
        //⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡀⠄⠄⠄⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
        //⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠄⠄⢰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
        //⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠄⠄⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
        //⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡆⢀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
        //⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣇⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
        //⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
        //⡿⠿⠿⠿⣿⡿⠿⠿⠿⣿⡿⠿⠿⢿⣿⢿⣿⣿⣿⣿⠿⠿⠿⣿
        //⣷⣦⢰⣶⣿⡷⠤⠤⢾⣿⡇⠶⠶⢾⣿⢸⣿⣿⣿⣿⠶⠶⠶⣿
        //⣿⣿⢸⣿⣿⣷⣶⣶⣾⣿⣷⣶⣶⢸⣿⠸⣿⣿⣿⣿⢠⣶⡄⣿
        //⣿⣿⣼⣿⣿⣷⣤⣤⣼⣿⣧⣤⣤⣼⣿⣦⣤⣴⣿⣿⣼⣿⣧⣿
        //⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
    }
}