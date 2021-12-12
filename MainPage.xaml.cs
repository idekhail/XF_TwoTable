using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XF_Mid2_Lab1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Add.Clicked += (s, e) => Navigation.PushAsync(new AddPage());
            Close.Clicked += (s, e) => Environment.Exit(0);

        }

        private async void Go_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HomeNumber.Text) && (!string.IsNullOrEmpty(City.Text)))
            {
                var address = await App.AddressSQLite.GetAddressAsync(HomeNumber.Text, City.Text);
                if (address != null)
                {
                    await Navigation.PushAsync(new InfoPage(address));
                   
                }
                else
                    await DisplayAlert("Error", "Address is null", "Ok");
            }
            else
                await DisplayAlert("Error", "HomeNumber or City is empty", "Ok");
        }

        protected  override async void OnAppearing()
        {
            base.OnAppearing();
            HomeNumber.Focus();
        }     
    }
}