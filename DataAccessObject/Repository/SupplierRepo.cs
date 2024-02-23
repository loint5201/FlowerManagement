using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Repository
{
    public class SupplierRepo : ISupplierRepo
    {

        public List<Supplier> GetAllSupplier() => SupplierManagement.Instance.GetAllSupplier();


        public IEnumerable<int> GetSupplierID() => SupplierManagement.Instance.GetSupplierID();
    }
}
