using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class OrderManagement
    {
        private OrderManagement() { }
        private static OrderManagement instance = null;
        private static readonly object instanceLock = new object();
        public static OrderManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderManagement();
                    }
                    return instance;
                }
            }
        }

        public List<Order> GetOrders()
        {
            List<Order> list = new List<Order>();
            try
            {
                FUFlowerBouquetManagementContext DbContext = new FUFlowerBouquetManagementContext();
                list = DbContext.Orders.ToList();

            }
            catch (Exception)
            {
                throw new Exception("Get list Orders unsuccessfully");
            }
            return list;
        }

        public void AddNewOrder(Order od)
        {
            try
            {
                FUFlowerBouquetManagementContext DbContext = new FUFlowerBouquetManagementContext();
                DbContext.Orders.Add(od);
                DbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Add a new Orders unsuccessfully ");
            }
        }

        public Order GetOrderById(int id)
        {
            Order od = null;
            var c = new FUFlowerBouquetManagementContext();
            try
            {
                od = c.Orders.SingleOrDefault(c => c.OrderId == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return od;
        }

        public void UpdateOrder(Order od)
        {
            try
            {
                Order _od = GetOrderById(od.OrderId);
                if (_od != null)
                {
                    var c = new FUFlowerBouquetManagementContext();
                    c.Orders.Update(od);
                    c.SaveChanges();
                }
                else
                {
                    throw new Exception("The Order does not already Exist");
                }
            }
            catch (Exception)
            {
                throw new Exception("Update a Order unsuccessfully");
            }
        }

        public void RemoveOrder(Order od)
        {
            try
            {
                Order _od = GetOrderById(od.OrderId);
                if (od != null)
                {
                    var c = new FUFlowerBouquetManagementContext();
                    c.Orders.Remove(od);
                    c.SaveChanges();
                }
                else
                {
                    throw new Exception("The Order does not already Exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 
    }
}
