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
    public partial class ControlPage : ContentPage
    {
        Address1 address; Person1 person;
        public ControlPage(Address1 address)
        {
            InitializeComponent();
            this.address = address;
            EditPerson();
        }

        public async void EditPerson()
        {
            this.person = await App.AddressSQLite.GetPersonAsync(address.Id); 
            
            Id.Text = address.Id + "";
            Name.Text = person.Name;
            HomeNumber.Text = address.HomeNumber;
            City.Text = address.City;
        }

        private async void Update_Clicked(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(Name.Text)) && (!string.IsNullOrEmpty(HomeNumber.Text)) && (!string.IsNullOrEmpty(City.Text)))
            {

                person.Name = Name.Text;
                address.HomeNumber = HomeNumber.Text;
                address.City = City.Text;

                await App.AddressSQLite.SaveAddressAsync(address);
                await App.AddressSQLite.SavePersonAsync(person);

                await Navigation.PushAsync(new InfoPage(this.address));
            }
            else
                await DisplayAlert("Error", "Feilds are empty", "Ok");
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            await App.AddressSQLite.DeletePersonAsync(this.person);
        }
        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InfoPage(this.address));
        }
    }
}
