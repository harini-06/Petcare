using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace animal_care
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ObservableCollection <Customer> _customers;
        public static ObservableCollection<treatment> _treatments;
        public static ObservableCollection<treatment> _cart;
        public static int TotalAmount=0;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // var customers = new ObservableCollection<Customer> {new Customer{customer_name = "Harini", phone_number = 12345, pet_name = "lily" },
            //new Customer { customer_name = "ben", phone_number = 56789, pet_name = "bno" },
            //new Customer { customer_name = "Bina", phone_number = 90099, pet_name = "vox" } };
            //MyStorage.WriteXml<ObservableCollection <Customer>>(customers, "CustomerDetails.xml");
            _customers = MyStorage.ReadXML<ObservableCollection<Customer>>("CustomerDetails.xml");
            var treatments = new ObservableCollection<treatment> {new treatment{treatment_Name = "Face wash", Amount_in_euros = 10},
               new treatment {treatment_Name = "Body wash", Amount_in_euros = 10 },
                new treatment {treatment_Name = "Acupuncture", Amount_in_euros=15},
               new treatment {treatment_Name = "Massage", Amount_in_euros=15 } ,
              new treatment {treatment_Name="bubble bath",Amount_in_euros=15},
              new treatment {treatment_Name="Face+Body",Amount_in_euros=15},
               new treatment{treatment_Name="Bubble bath+Massage",Amount_in_euros=25} };
            MyStorage.WriteXml<ObservableCollection <treatment>>(treatments, "treatment.xml");
            _treatments = MyStorage.ReadXML<ObservableCollection<treatment>>("treatment.xml");
            _cart = new ObservableCollection<treatment>();
        }

    }
}
