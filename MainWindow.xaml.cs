using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace animal_care
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Lbx_customers.ItemsSource = App._customers;
            Lbx_treatment.ItemsSource = App._treatments;
            Lbx_treatmenttab.ItemsSource = App._cart;

        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            var cust = new Customer{ customer_name = "to be edited", pet_name = "to be edited" };
            App._customers.Add(cust);
            Lbx_customers.ScrollIntoView(cust);
            Lbx_customers.SelectedItem = cust;

        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            var cust = Lbx_customers.SelectedItem as Customer;
            if (cust == null)
            {
                MessageBox.Show("Please select item to be deleted!", "Hint");
                return;

            }
            App._customers.Remove(cust);
        }
        private void Tbx_Filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (App._customers == null) return;
            var filter = (sender as TextBox).Text.ToLower();
            if (filter == null) return;
            var result = from c in App._customers where c.customer_name.ToLower().Contains(filter) || c.customer_name.ToLower().Contains(filter) select c;
            Lbx_customers.ItemsSource = result;
        }
        private void Tbx_treatmentFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (App._treatments == null) return;
            var filter = (sender as TextBox).Text.ToLower();
            if (filter == null) return;
            var result = from t in App._treatments
                         where (t.treatment_Name.ToLower().Contains(filter))
                         select t;
            Lbx_treatment.ItemsSource = result;
        }
        List<treatment> itmsLst = new List<treatment>();


       
        private void Btn_Deltrmt_Click(object sender, RoutedEventArgs e)
        {
            //Lbx_treatmenttab.Items.Clear();
            App._cart.Clear();
        }

        private void Btn_Book_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Booking Sucessful");
            return;
        }

        private void Btn_AddToList_Click(object sender, RoutedEventArgs e)
        {
            var item = Lbx_treatment.SelectedItem as treatment;
            App._cart.Add(item);
            App.TotalAmount = App.TotalAmount + item.Amount_in_euros;
            Tbx_Sum.Text = App.TotalAmount.ToString();

            //Lbx_treatmenttab.Items.Add(Lbx_treatment.SelectedItem);
            //int i = 0;
            //i = Lbx_treatment.SelectedIndex;
            //Lbx_treatment.Items.Remove(i);

        }


        

      
    }
}
