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
    public partial class InfoPage : ContentPage
    {
        Address1 address;  Person1 person;
        public InfoPage(Address1 address)
        {
            InitializeComponent();
            this.address = address;
            Logout.Clicked  += (s, e) => Navigation.PushAsync(new MainPage());
            Control.Clicked += (s, e) => Navigation.PushAsync(new ControlPage(address));

            Display();
          //  var person = App.AddressSQLite.GetPersonAsync(address.Id);

            
        }

        public  void Display()
        {
            person =  App.AddressSQLite.GetPersonAsync(address.Id).Result;
            Show.Text = $"{address.Id}\t{person.Name}\t{address.HomeNumber}\t{address.City}";
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            HN.Focus();
        }

        private async void AllPeople_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HN.Text) && (!string.IsNullOrEmpty(City.Text)))
            {
                string data = "";
                var addressPeople = await App.AddressSQLite.GetAllPeopleAddressAsync(HN.Text, City.Text);
                if (addressPeople != null)
                {
                    foreach (var a in addressPeople)
                    {
                        var p = await App.AddressSQLite.GetPersonAsync(a.Id);
                        data += a.Id + "\t" + p.Name + "\t" + a.HomeNumber + "\t" + a.City + "\n";

                    }
                    Show.Text = data;
                }
                else
                    await DisplayAlert("Error", "Address is null", "Ok");
            }
            else
                await DisplayAlert("Error", "HomeNumber or City is empty", "Ok");
        }

        private async void AllAddress_Clicked(object sender, EventArgs e)
        {
           
            string data = "";
            var addressPeople = await App.AddressSQLite.GetAllAddressAsync();
            if (addressPeople != null)
            {
                foreach (var a in addressPeople)
                {
                    var p = await App.AddressSQLite.GetPersonAsync(a.Id);
                    data += a.Id + "\t" + p.Name + "\t" + a.HomeNumber + "\t" + a.City + "\n";

                }
                Show.Text = data;
            }
            else
                await DisplayAlert("Error", "Address is null", "Ok");
                      
        }     
    }
}