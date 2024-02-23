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
    /// Interaction logic for OrderDetailManagement.xaml
    /// </summary>
    public partial class OrderDetailManagement : Window
    {
        private int _orderId;
        private bool flag = true;
        public IEnumerable<OrderDetail> orderdetails { get; set; }
        public IOrderDetailRepo detailRepo = new OrderDetailRepo();
        public OrderDetailManagement(int orderId)
        {
            InitializeComponent();
            txtOrderId.Text = _orderId.ToString();
            loadOrderDetail();
        }

        private void loadOrderDetail()
        {
            int orderId = Int32.Parse(txtOrderId.Text);
            lvOrderDetailList.ItemsSource = orderdetails;
        }

        private void clearinfo()
        {
            txtFlowerBouquetID.Clear();
            txtUnitPrice.Clear();
            txtQuantity.Clear();
            txtDiscount.Clear();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OrderDetail od = new OrderDetail();
                od.FlowerBouquetId = Int32.Parse(txtFlowerBouquetID.Text);
                od.UnitPrice = Decimal.Parse(txtUnitPrice.Text);
                od.Quantity = Int32.Parse(txtQuantity.Text);
                od.Discount = Double.Parse(txtDiscount.Text);
              
                detailRepo = new OrderDetailRepo();
                detailRepo.AddNewOrderDetail(od);
                MessageBox.Show("Add Succesfully", "Thông báo");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            clearinfo();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void lvOrderDetailList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            flag = false;
            if (lvOrderDetailList.SelectedIndex == -1)
            {
                return;
            }

            OrderDetail? acc = lvOrderDetailList.SelectedItem as OrderDetail;
            txtOrderId.Text = acc.OrderId.ToString();
            txtFlowerBouquetID.Text = acc.FlowerBouquetId.ToString();
            txtUnitPrice.Text = acc.UnitPrice.ToString();
            txtQuantity.Text = acc.Quantity.ToString();
            txtDiscount.Text = acc.Discount.ToString();
            btnDelete.IsEnabled = true;
            btnUpdate.IsEnabled = true;
        }
    }
}
