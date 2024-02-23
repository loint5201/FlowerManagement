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
    /// Interaction logic for FlowerCreatePopUp.xaml
    /// </summary>
    public partial class FlowerCreatePopUp : Window
    {
        public IFlowerBouquetRepo flowerBouquetRepo = new FlowerBouquetRepo();
        public ICategoryRepo categoryRepo = new CategoryRepo();
        public ISupplierRepo supplierRepo = new SupplierRepo();
        public IEnumerable<int> categories { get; set; }
        public IEnumerable<int> suppliers { get; set; }

        public FlowerCreatePopUp()
        {
            InitializeComponent();
            loadCategory();
            loadSupplier();
        }

        private void loadCategory()
        {
            categories = categoryRepo.GetCategoryID();
            cbCategory.ItemsSource = categories;
        }

        private void loadSupplier()
        {
            suppliers = supplierRepo.GetSupplierID();
            cbSupplierID.ItemsSource = suppliers;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool flag = true;
                bool validateFlowerId = ValidateForm.ContainOnlyNumber(txtFlowerBouquetID.Text);

                if (txtFlowerBouquetID.Text.Trim().Length == 0 || txtFlowerBouquetName.Text.Trim().Length == 0 || txtDescription.Text.Trim().Length == 0
                    || txtUnitPrice.Text.Trim().Length == 0 || txtUnitsInStock.Text.Trim().Length == 0 || txtStatus.Text.Trim().Length == 0)
                {
                    MessageBox.Show("All fields can not be blank!!!");
                    flag = false;
                }
                if (validateFlowerId == false)
                {
                    MessageBox.Show("FlowerId must be a number.");
                    flag = false;
                }

            

                bool valdiateflowerBouquetStatus = ValidateForm.ContainOnlyOneAndZero(txtStatus.Text);
                if (valdiateflowerBouquetStatus == false)
                {
                    MessageBox.Show("flowerBouquetStatus must be 1 or 0");
                    flag = false;
                }

                bool validateUnitInPrice = ValidateForm.ContainOnlyNumber(txtUnitPrice.Text);
                if (validateUnitInPrice == false)
                {
                    MessageBox.Show("UnitInPrice must be a number.");
                    flag = false;
                }

                bool validateFlowerUnitInStock = ValidateForm.ContainOnlyNumber(txtUnitsInStock.Text);
                if (validateFlowerUnitInStock == false)
                {
                    MessageBox.Show("UnitInStock must be a number");
                    flag = false;
                }

                if (flag)
                {
                    FlowerBouquet flowerBouquet = new FlowerBouquet();

                    flowerBouquet.FlowerBouquetId = Int32.Parse(txtFlowerBouquetID.Text);
                    flowerBouquet.CategoryId = cbCategory.SelectedIndex + 1;
                    flowerBouquet.SupplierId = cbSupplierID.SelectedIndex + 1;
                    flowerBouquet.FlowerBouquetName = txtFlowerBouquetName.Text;
                    flowerBouquet.Description = txtDescription.Text;
                    flowerBouquet.UnitPrice = Decimal.Parse(txtUnitPrice.Text);
                    flowerBouquet.UnitsInStock = Int32.Parse(txtUnitsInStock.Text);
                    flowerBouquet.FlowerBouquetStatus = Byte.Parse(txtStatus.Text);


                    flowerBouquetRepo = new FlowerBouquetRepo();
                    flowerBouquetRepo.AddNewFlower(flowerBouquet);
                    MessageBox.Show("Add Succesfully", "Thông báo");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification");
            }
           
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
