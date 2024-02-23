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
    /// Interaction logic for FlowerManagement.xaml
    /// </summary>
    public partial class FlowerManagement : Window
    {
        private bool flag = true;
        public IFlowerBouquetRepo flowerRepo = new FlowerBouquetRepo();
        public ICategoryRepo categoryRepo = new CategoryRepo();
        public ISupplierRepo supplierRepo = new SupplierRepo();
        public IEnumerable<FlowerBouquet> FlowerBouquets { get; set; }
        public IEnumerable<int> categories { get; set; }
        public IEnumerable<int> suppliers { get; set; }

        public FlowerManagement()
        {
            InitializeComponent();
            loadFlower();
            loadCategory();
            loadSupplier(); 
        }

        private void loadFlower()
        {
            FlowerBouquets = flowerRepo.GetFlowerBouquets();
            lvFlowerBouquetList.ItemsSource = FlowerBouquets;
        }

        private void loadSearchFlower(string name)
        {
            FlowerBouquets = flowerRepo.SearchFlower(name);
            lvFlowerBouquetList.ItemsSource = FlowerBouquets;
        }
         private void loadSupplier()
        {
            suppliers = supplierRepo.GetSupplierID();
            cbSupplierID.ItemsSource = suppliers;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void clearInfor()
        {
            txtFlowerBouquetID.Clear();
            txtFlowerBouquetName.Clear();
            txtDescription.Clear();
            txtStatus.Clear();
            txtUnitPrice.Clear();
            txtUnitsInStock.Clear();
            cbCategory.SelectedItem = null;
            cbSupplierID.SelectedItem = null;
        }

        private void loadCategory()
        {
            categories = categoryRepo.GetCategoryID();
            cbCategory.ItemsSource = categories;
        }

        private void lvFlowerBouquetList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            flag = false;
            if (lvFlowerBouquetList.SelectedIndex == -1)
            {
                return;
            }

            FlowerBouquet? acc = lvFlowerBouquetList.SelectedItem as FlowerBouquet;
            txtFlowerBouquetID.Text = acc.FlowerBouquetId.ToString();
            cbCategory.SelectedIndex = acc.CategoryId - 1;
            txtFlowerBouquetName.Text=acc.FlowerBouquetName;
            txtDescription.Text = acc.Description;
            txtUnitPrice.Text = acc.UnitPrice.ToString();
            txtUnitsInStock.Text = acc.UnitsInStock.ToString();
            txtStatus.Text = acc.FlowerBouquetStatus.ToString();
            cbSupplierID.SelectedIndex = acc.CategoryId - 1;
            btnDelete.IsEnabled = true;
            btnUpdate.IsEnabled = true;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            var window = new FlowerCreatePopUp();
            window.Owner = this;
            window.ShowDialog();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var window = new FlowerUpdatePopUp(txtFlowerBouquetID.Text, cbCategory.Text, txtFlowerBouquetName.Text, txtDescription.Text, 
                txtUnitPrice.Text, txtUnitsInStock.Text, txtStatus.Text,cbSupplierID.Text);
            window.Owner = this;
            window.ShowDialog();
        }

        

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to delete", "Confirmation Window", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    int id = Int32.Parse(txtFlowerBouquetID.Text);
                    FlowerBouquet _flower = flowerRepo.GetFlowerBouquetbyId(id);
                    flowerRepo.RemoveFlower(_flower);
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
                    string id = txtFlowerBouquetID.Text;
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
            loadFlower();
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

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            clearInfor();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text.Trim().Length == 0)
            {
                loadFlower();
            }
            else
            {
                loadSearchFlower(txtSearch.Text);
            }
        }
    }
}
