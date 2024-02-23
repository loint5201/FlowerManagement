using BuiKhoiNguyenRepo.Validation;
using BussinessObject.Models;
using DataAccessObject.Repository;
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
    /// Interaction logic for CustomerUpdatePopUp.xaml
    /// </summary>
    public partial class CustomerUpdatePopUp : Window
    {
        public ICustomerRepo customerRepo = new CustomerRepo();
        private string cusId, cusFullName, email, password, city, country, birthday;

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool flag = true;
                if (txtCusID.Text.Trim().Length == 0 || txtFullName.Text.Trim().Length == 0 || txtCountry.Text.Trim().Length == 0 ||
                       txtCity.Text.Trim().Length == 0 || txtEmail.Text.Trim().Length == 0 || txtPassword.Text.Trim().Length == 0 || dpBirthday.Text.Trim().Length == 0)
                {
                    MessageBox.Show("All fields can not be blank!!!");
                    flag = false;
                }
                bool validateEmail = ValidateForm.IsValidEmail(txtEmail.Text);
                if (validateEmail == false)
                {
                    MessageBox.Show("Email is wrong fromat abc@gmail.com");
                    flag = false;
                }

                bool emailIsStartWithNumber = ValidateForm.StartWithANumber(txtEmail.Text);
                if (emailIsStartWithNumber)
                {
                    MessageBox.Show("Email is wrong fromat abc@gmail.com");
                    flag = false;
                }
                

               

                

                bool validateBirthDate = ValidateForm.checkDate(dpBirthday.Text);
                if (validateBirthDate == false)
                {
                    MessageBox.Show("BirthDate is true format mm/dd/yyyy or m/dd/yyyy or m/d/yyyy m/dd/yyyy!!!");
                    flag = false;
                }
                if (flag)
                {
                    Customer cus = new Customer();

                    txtCusID.IsEnabled = true;
                    cus.CustomerId = Int32.Parse(txtCusID.Text);
                    cus.CustomerName = txtFullName.Text;
                    cus.Email = txtEmail.Text;
                    cus.Password = txtPassword.Text;
                    cus.City = txtCity.Text;
                    cus.Country = txtCountry.Text;
                    cus.Birthday = DateTime.Parse(dpBirthday.Text.ToString());

                    customerRepo = new CustomerRepo();
                    customerRepo.UpdateCustomer(cus);
                    MessageBox.Show("Update Succesfully", "Thông báo");
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        public CustomerUpdatePopUp()
        {
            InitializeComponent();
        }

        public CustomerUpdatePopUp(string _cusId, string _cusFullName, string _email, string _password, string _city,string _country, string _birthday)
        {
            InitializeComponent();
            cusId = _cusId;
            txtCusID.Text = _cusId;
            cusFullName = _cusFullName;
            txtFullName.Text = _cusFullName;
            email = _email;
            txtEmail.Text = _email;
            password = _password;
            txtPassword.Text = _password;
            city = _city;
            txtCity.Text = _city;
            country = _country;
            txtCountry.Text = _country;
            birthday = _birthday;
            dpBirthday.Text = _birthday;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
