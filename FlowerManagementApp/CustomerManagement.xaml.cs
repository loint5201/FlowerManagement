using BussinessObject.Models;
using DataAccessObject.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    /// Interaction logic for CustomerManagement.xaml
    /// </summary>
    public partial class CustomerManagement : Window
    {
        public ICustomerRepo customerRepo = new CustomerRepo();
        public IEnumerable<Customer> Customers { get; set; }
        private bool flag = true;
        public CustomerManagement()
        {
            InitializeComponent();
            loadCustomer();
        }

        private void loadCustomer()
        {
            Customers = customerRepo.GetCustomerAccounts();
            lvCusList.ItemsSource = Customers;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void loadSearchCustomer(string name)
        {
            Customers = customerRepo.SearchCustomer(name);
            lvCusList.ItemsSource = Customers;

        }

        private void lvCusList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            flag = false;
            if (lvCusList.SelectedIndex == -1)
            {
                return;
            }

            Customer? acc = lvCusList.SelectedItem as Customer;
            txtEmail.Text = acc.Email;
            txtFullName.Text = acc.CustomerName;
            txtPassword.Text = acc.Password;
            txtCusID.Text = acc.CustomerId.ToString();
            txtCity.Text = acc.City;
            txtCountry.Text = acc.Country;
            dpBirthday.Text = acc.Birthday.ToString();
            btnDelete.IsEnabled = true;
            btnUpdate.IsEnabled = true;
        }

        private void clearInfor()
        {
            txtEmail.Clear();
            txtFullName.Clear();
            txtPassword.Clear();
            txtCusID.Clear();
            txtCity.Clear();
            txtCountry.Clear();
            dpBirthday.Text = "";
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            var window = new CustomerCreatePopUp();
            window.Owner = this;
            window.ShowDialog();
        }

        public void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var window = new CustomerUpdatePopUp(txtCusID.Text,txtFullName.Text,txtEmail.Text,txtPassword.Text,txtCity.Text,txtCountry.Text,dpBirthday.Text);
            window.Owner = this;
            window.ShowDialog();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            clearInfor();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to delete", "Confirmation Window", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    int id = Int32.Parse(txtCusID.Text);
                    customerRepo.DeleteCustomer(id);
                    loadCustomer();
                    clearInfor();
                    MessageBox.Show("Delete succesfully", "Thông báo");
                    loadCustomer(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Delete a customer");
                }
            }
            else if (result == MessageBoxResult.No)
            {
                try
                {
                    string id = txtCusID.Text;
                    loadCustomer();
                    clearInfor();
                    loadCustomer();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Delete a customer");
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var windowCus = new AdminManagement();
            this.Hide();
            windowCus.Owner = this;
            windowCus.ShowDialog();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnReload_Click(object sender, RoutedEventArgs e)
        {
            loadCustomer();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            clearInfor();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if(txtSearch.Text.Trim().Length == 0)
            {
                loadCustomer() ;
            }
            else
            {
                loadSearchCustomer(txtSearch.Text);
            }
        }
    }
}
