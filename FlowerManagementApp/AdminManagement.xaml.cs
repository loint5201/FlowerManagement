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
using System.Windows.Shapes;

namespace FlowerManagementApp
{
    /// <summary>
    /// Interaction logic for AdminManagement.xaml
    /// </summary>
    public partial class AdminManagement : Window
    {
        public AdminManagement()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cmbOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btnChoose_Click(object sender, RoutedEventArgs e)
        {
            switch (cmbOption.Text)
            {
                case "Customer Management":
                    var windowCus = new CustomerManagement();
                    this.Hide();
                    windowCus.Owner = this;
                    windowCus.ShowDialog();                  
                    break;
                case "Flowers Management":
                    var windowFlower = new FlowerManagement();
                    this.Hide();
                    windowFlower.Owner = this;
                    windowFlower.ShowDialog();                  
                    break;
                case "Order Management":
                    var windowOrder = new OrderManagement();
                    this.Hide();
                    windowOrder.Owner = this;
                    windowOrder.ShowDialog();
                    break;

            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var windowCus = new MainWindow();
            this.Hide();
            windowCus.Owner = this;
            windowCus.ShowDialog();          
        }
    }
}
