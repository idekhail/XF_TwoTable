using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF_Mid2_Lab1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        public AddPage()
        {
            InitializeComponent();
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(HomeNumber.Text)) && (!string.IsNullOrEmpty(City.Text)))
            {
                var address = new Address1()
                {
                    HomeNumber = HomeNumber.Text,
                    City = City.Text,
                };
                await App.AddressSQLite.SaveAddressAsync(address);
            }
            else
                await DisplayAlert("Error", "Feilds are empty", "Ok");

            if (!string.IsNullOrEmpty(Name.Text))
            {
                var address = App.AddressSQLite.GetAddressAsync(HomeNumber.Text);

                var person = new Person1()
                {
                    Name = Name.Text,
                    AId = address.Id,
                };
                await App.AddressSQLite.SavePersonAsync(person);
                await DisplayAlert("PID", person.Id+"     " + person.AId + "", "Ok");

                await Navigation.PopAsync();

            }
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}