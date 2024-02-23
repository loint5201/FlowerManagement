using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using BussinessObject;
using BussinessObject.Models;
using DataAccessObject.Repository;
using Microsoft.Extensions.Configuration;

namespace DataAccessObject
{
    public class CustomerManagement
    {
        private CustomerManagement() { }
        private static CustomerManagement instance = null;
        private static readonly object instanceLock = new object();
        public static CustomerManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CustomerManagement();
                    }
                    return instance;
                }
            }
        }

        public bool CheckLogin(string userName, string password)
        {
            bool result = false;
            FUFlowerBouquetManagementContext DbContext = new FUFlowerBouquetManagementContext();
            var member = DbContext.Customers
                    .Where(b => b.Email == userName)
                    .FirstOrDefault();
            if (member == null)
            {
                throw new Exception("User name does not existed!");
            }
            else
            {
                if (member.Password != password)
                {
                    throw new Exception("Password does not correct!");
                }
                else { result = true; }
            }
            return result;
        }



        public Customer checkAdminLogin(string email, string password)
        {
            var c = new FUFlowerBouquetManagementContext();
            Customer admin = c.GetAdminAccount();
            if (email == admin.Email && password == admin.Password)
            {
                return admin;
            }
            else
            {
                return null;
            }
        }

        public List<Customer> GetCustomerAccounts()
        {
            List<Customer> list = new List<Customer>();
            try
            {
                FUFlowerBouquetManagementContext DbContext = new FUFlowerBouquetManagementContext();
                list = DbContext.Customers.ToList();

            }
            catch (Exception)
            {
                throw new Exception("Get list customers unsuccessfully");
            }
            return list;
        }

        public void AddNewCus(Customer cus)
        {
            try
            {
                FUFlowerBouquetManagementContext DbContext = new FUFlowerBouquetManagementContext();
                DbContext.Customers.Add(cus);
                DbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Add a new customers unsuccessfully ");
            }
        }

        public void UpdateCustomer(Customer cus)
        {
            try
            {
                FUFlowerBouquetManagementContext DbContext = new FUFlowerBouquetManagementContext();
                DbContext.Entry<Customer>(cus).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                DbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Update a customer unsuccessfully");
            }
        }

        public void DeleteCustomer(int cusID)
        {
            try
            {
                FUFlowerBouquetManagementContext DbContext = new FUFlowerBouquetManagementContext();
                Customer? mem = DbContext.Customers.
                    SingleOrDefault(mem => mem.CustomerId == cusID);
                DbContext.Customers.Remove(mem);
                DbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Delete a customer unsuccessfully");
            }
        }

        public List<Customer> SearchCustomer(string name)
        {
            try
            {
                var c = new FUFlowerBouquetManagementContext();
                List<Customer> customers = c.Customers.Where(c => c.CustomerName.Contains(name)).ToList();
                return customers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        public List<Customer> GetAllCustomer()
        {
            List<Customer> cus;
            try
            {
                var c = new FUFlowerBouquetManagementContext();
                cus = c.Customers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cus;
        }

        public IEnumerable<int> GetCustomerID()
        {
            CustomerRepo repo = new CustomerRepo();
            try
            {
                var categories = repo.GetAllCustomer().ToList().Select(c => c.CustomerId);
                return categories;

            }
            catch (Exception)
            {
                throw new Exception("Get list cusID unsuccessfully");
            }
        }
    }
}
