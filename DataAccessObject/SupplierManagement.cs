using BussinessObject.Models;
using DataAccessObject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class SupplierManagement
    {
        private SupplierManagement() { }
        private static SupplierManagement instance = null;
        private static readonly object instanceLock = new object();
        public static SupplierManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new SupplierManagement();
                    }
                    return instance;
                }
            }
        }


        public List<Supplier> GetAllSupplier()
        {
            List<Supplier> categories;
            try
            {
                var c = new FUFlowerBouquetManagementContext();
                categories = c.Suppliers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return categories;
        }


        public IEnumerable<int> GetSupplierID()
        {
            SupplierRepo repo = new SupplierRepo();
            try
            {
                var categories = repo.GetAllSupplier().ToList().Select(c => c.SupplierId);
                return categories;

            }
            catch (Exception)
            {
                throw new Exception("Get list suppliersId unsuccessfully");
            }
        }
    }
}
