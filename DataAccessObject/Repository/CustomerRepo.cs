using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Repository
{
    public class CustomerRepo : ICustomerRepo
    {
        public bool CheckLogin(string mail, string password) => CustomerManagement.Instance.CheckLogin(mail, password);

        public Customer checkAdminLogin(string mail, string password) => CustomerManagement.Instance.checkAdminLogin(mail, password);

        public IEnumerable<Customer> GetCustomerAccounts() => CustomerManagement.Instance.GetCustomerAccounts();

        public void AddNewCus(Customer cus) => CustomerManagement.Instance.AddNewCus(cus);

        public void UpdateCustomer(Customer cus) => CustomerManagement.Instance.UpdateCustomer(cus);

        public void DeleteCustomer(int cusID) => CustomerManagement.Instance.DeleteCustomer(cusID);

        public List<Customer> SearchCustomer(string name) => CustomerManagement.Instance.SearchCustomer(name);

        public List<Customer> GetAllCustomer() => CustomerManagement.Instance.GetAllCustomer();

        public IEnumerable<int> GetCustomerID() => CustomerManagement.Instance.GetCustomerID();
    }
}
