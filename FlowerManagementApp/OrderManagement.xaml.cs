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
    /// Interaction logic for OrderManagement.xaml
    /// </summary>
    public partial class OrderManagement : Window
    {
        private bool flag = true;
        public IEnumerable<Order> orders { get; set; }
        public IEnumerable<Customer> customer { get; set; }
        public IOrderRepo orderRepo = new OrderRepo();
        public IOrderDetailRepo detailRepo = new OrderDetailRepo();
        public ICustomerRepo customerRepo = new CustomerRepo();
        public OrderManagement()
        {
            InitializeComponent();
            cbCustomerId.SelectedIndex = 0;
            btnDetail.IsEnabled = false;
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;
            loadOrder();
        }
            
        private void loadOrder()
        {
            orders = orderRepo.GetOrders();
            lvOrderList.ItemsSource = orders;
        }

        private void loadCustomer()
        {
            //customer = customerRepo.GetCustomerID();
            cbCustomerId.ItemsSource = customer;
        }

        private void lvOrderList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            flag = false;
            if (lvOrderList.SelectedIndex == -1)
            {
                return;
            }

            Order? acc = lvOrderList.SelectedItem as Order;
            txtOrderId.Text = acc.OrderId.ToString();
            cbCustomerId.Text= acc.CustomerId.ToString();
            dtOrderDate.Text = acc.OrderDate.ToString();
            dtShippedDate.Text = acc.ShippedDate.ToString();
            txtTotal.Text = acc.Total.ToString();
            txtOrderStatus.Text = acc.OrderStatus;  
            btnDelete.IsEnabled = true;
            btnUpdate.IsEnabled = true;
            btnDetail.IsEnabled = true;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order od = new Order();
                if (txtOrderId.Text.Length < 0 || cbCustomerId.Text.Length < 0 )
                {
                    throw new Exception("Not Blank");
                }

                int orderId = Int32.Parse(txtOrderId.Text);
                od.CustomerId = cbCustomerId.SelectedIndex + 1;
                od.OrderDate = DateTime.Parse(dtOrderDate.Text.ToString());
                od.ShippedDate = DateTime.Parse(dtShippedDate.Text.ToString());
                od.Total = Decimal.Parse(txtTotal.Text);
                od.OrderStatus = txtOrderStatus.Text;
                orderRepo = new OrderRepo();
                orderRepo.AddNewOrder(od);
                MessageBox.Show("Add Succesfully", "Thông báo");
                var window = new OrderDetailManagement(orderId);
                window.Owner = this;
                window.ShowDialog();              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order od = new Order();
                if (txtOrderId.Text.Length < 0 || cbCustomerId.Text.Length < 0)
                {
                    throw new Exception("Not Blank");
                }

                od.OrderId = Int32.Parse(txtOrderId.Text);
                od.CustomerId = cbCustomerId.SelectedIndex + 1;
                od.OrderDate = DateTime.Parse(dtOrderDate.Text.ToString());
                od.ShippedDate = DateTime.Parse(dtShippedDate.Text.ToString());
                od.Total = Decimal.Parse(txtTotal.Text);
                od.OrderStatus = txtOrderStatus.Text;
                orderRepo = new OrderRepo();
                orderRepo.UpdateOrder(od);
                MessageBox.Show("Update Succesfully", "Thông báo");
                //var window = new OrderDetailManagement();
                //this.Hide();
                //window.Owner = this;
                //window.ShowDialog();
               // this.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }
        

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to delete", "Confirmation Window", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    int id = Int32.Parse(txtOrderId.Text);
                    Order od = orderRepo.GetOrderById(id);
                    orderRepo.RemoveOrder(od);
                    //OrderDetail detail = detailRepo.GetOrderDetailById(id);
                    //detailRepo.RemoveOrderDetail(detail);
                    clearInfor();
                    MessageBox.Show("Delete succesfully", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Delete a flowerbouquet");
                }
            }
            else if (result == MessageBoxResult.No)
            {
                try
                {
                    string id = txtOrderId.Text;
                    clearInfor();
                    btnDelete.IsEnabled = false;
                    btnUpdate.IsEnabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Delete a flowerbouquet");
                }
            }
        }

        private void btnReload_Click(object sender, RoutedEventArgs e)
        {
            loadOrder();
        }

        private void clearInfor()
        {
            txtOrderId.Clear();
            cbCustomerId.SelectedItem = null;
            dtOrderDate.Text = "";
            dtShippedDate.Text = "";
            txtTotal.Clear();
            txtOrderStatus.Clear();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
           clearInfor();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var window = new AdminManagement();
            this.Hide();
            window.Owner = this;
            window.ShowDialog();

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnDetail_Click(object sender, RoutedEventArgs e)
        {
            int orderId = Int32.Parse(txtOrderId.Text);
            var orderIsExisted = orderRepo.GetOrderById(orderId);
            if (txtOrderId.Text.Trim().Length < 0)
            {
                MessageBox.Show("OrderId can not be blank !!!");
                return;
            }
            if (orderIsExisted == null)
            {
                MessageBox.Show("Order is not existed!!!");
                return;
            }
            else
            {
                var window = new OrderDetailManagement(orderId);
                window.Owner = this;
                window.ShowDialog();
                loadOrder();
                return;
            }
        }

        
    }
}
