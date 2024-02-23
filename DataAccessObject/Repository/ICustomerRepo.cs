using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Repository
{
    public interface ICustomerRepo
    {
        bool CheckLogin(string mail, string password);
        Customer checkAdminLogin(string mail, string password);
        IEnumerable<Customer> GetCustomerAccounts();
        void AddNewCus(Customer cus);
        void UpdateCustomer(Customer cus);
        void DeleteCustomer(int cusID);
        List<Customer> SearchCustomer(string name);
        List<Customer> GetAllCustomer();
        IEnumerable<int> GetCustomerID();
    }
}
