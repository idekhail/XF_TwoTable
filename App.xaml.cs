using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF_Mid2_Lab1
{
    public partial class App : Application
    {

        static AddressOperations db;

        // Create the database connection as a singleton.
        public static AddressOperations AddressSQLite
        {
            get
            {
                if (db == null)
                {
                    db = new AddressOperations(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Mid3DB7.db3"));
                }
                return db;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
