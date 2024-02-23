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
using DataAccessObject;
using DataAccessObject.Repository;
using System;


namespace FlowerManagementApp
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

        public ICustomerRepo customerRepo { get; set; }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string userName = txtUserName.Text;
                string password = txtPassword.Password.ToString();
                if (userName == "" || password == "")
                {
                    MessageBoxResult dg = MessageBox.Show("Please Enter UserName and Password", "Login", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    customerRepo = new CustomerRepo();
                    if (customerRepo.checkAdminLogin(userName, password) != null)
                    {
                        MessageBoxResult dg = MessageBox.Show("Login Successfully", "Login", MessageBoxButton.OK, MessageBoxImage.Information);
                        var window = new AdminManagement();
                        this.Hide();
                        window.Owner = this;
                        window.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        customerRepo.CheckLogin(userName, password);
                        MessageBoxResult dg = MessageBox.Show("Login Successfully", "Login", MessageBoxButton.OK, MessageBoxImage.Information);
                        var window = new ProfileManagement();
                        this.Hide();
                        window.Owner = this;
                        window.ShowDialog();
                        this.Close();
                    }
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
