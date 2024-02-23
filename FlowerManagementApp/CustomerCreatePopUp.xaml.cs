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
    /// Interaction logic for CustomerCreatePopUp.xaml
    /// </summary>
    public partial class CustomerCreatePopUp : Window
    {
        public ICustomerRepo customerRepo = new CustomerRepo();
        public CustomerCreatePopUp()
        {
            InitializeComponent();
        }

        

        private void btnAdd_Click(object sender, RoutedEventArgs e)
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
                    cus.CustomerId = Int32.Parse(txtCusID.Text);
                    cus.CustomerName = txtFullName.Text;
                    cus.Email = txtEmail.Text;
                    cus.Password = txtPassword.Text;
                    cus.City = txtCity.Text;
                    cus.Country = txtCountry.Text;
                    cus.Birthday = DateTime.Parse(dpBirthday.Text.ToString());

                    customerRepo = new CustomerRepo();
                    customerRepo.AddNewCus(cus);
                    MessageBox.Show("Add Succesfully", "Thông báo");
                    this.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
