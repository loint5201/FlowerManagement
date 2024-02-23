using BussinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataAccessObject
{
    public class FlowerBouquetManagement
    {
        private FlowerBouquetManagement() { }
        private static FlowerBouquetManagement instance = null;
        private static readonly object instanceLock = new object();
        public static FlowerBouquetManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new FlowerBouquetManagement();
                    }
                    return instance;
                }
            }
        }


        public List<FlowerBouquet> GetFlowerBouquets()
        {
            List<FlowerBouquet> list = new List<FlowerBouquet>();
            try
            {
                FUFlowerBouquetManagementContext DbContext = new FUFlowerBouquetManagementContext();
                list = DbContext.FlowerBouquets.ToList();

            }
            catch (Exception)
            {
                throw new Exception("Get list flowerbouquets unsuccessfully");
            }
            return list;
        }


        public void AddNewFlower(FlowerBouquet fb)
        {
            try
            {
                FUFlowerBouquetManagementContext DbContext = new FUFlowerBouquetManagementContext();
                DbContext.FlowerBouquets.Add(fb);
                DbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Add a new flowerbouquets unsuccessfully ");
            }
        }

        public FlowerBouquet GetFlowerBouquetById(int id)
        {
            FlowerBouquet flowerBouquet = null;
            var c = new FUFlowerBouquetManagementContext();
            try
            {
                flowerBouquet = c.FlowerBouquets.SingleOrDefault(c => c.FlowerBouquetId == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return flowerBouquet;
        }

        public OrderDetail GetOrderDetailById(int id)
        {
            OrderDetail orderDetail = null;
            var c = new FUFlowerBouquetManagementContext();
            try
            {
                orderDetail = c.OrderDetails.SingleOrDefault(c => c.FlowerBouquetId == id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetail;
        }

        public void UpdateFlower(FlowerBouquet fb)
        {
            try
            {
                FlowerBouquet _flowerbouquet = GetFlowerBouquetById(fb.FlowerBouquetId);
                if (_flowerbouquet != null)
                {
                    var c = new FUFlowerBouquetManagementContext();
                    c.FlowerBouquets.Update(fb);
                    c.SaveChanges();
                }
                else
                {
                    throw new Exception("The StaffAccount does not already Exist");
                }
            }
            catch (Exception)
            {
                throw new Exception("Update a flowerbouquet unsuccessfully");
            }
        }

        public void RemoveFlower(FlowerBouquet fb)
        {
            try
            {
                using (var dbContext = new FUFlowerBouquetManagementContext())
                {
                    FlowerBouquet flowerBouquet = dbContext.FlowerBouquets.FirstOrDefault(f => f.FlowerBouquetId == fb.FlowerBouquetId);
                    if (flowerBouquet != null)
                    {
                        OrderDetail orderDetail = dbContext.OrderDetails.FirstOrDefault(od => od.FlowerBouquetId == fb.FlowerBouquetId);
                        if (orderDetail != null)
                        {
                            flowerBouquet.FlowerBouquetStatus = 0; // Change the status of the flower bouquet
                        }
                        else
                        {
                            dbContext.FlowerBouquets.Remove(flowerBouquet); // Remove the flower bouquet from the database
                            dbContext.SaveChanges();
                        }
                        dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<FlowerBouquet> SearchFlower(string name)
        {
            try
            {
                var c = new FUFlowerBouquetManagementContext();
                List<FlowerBouquet> flowerBouquets = c.FlowerBouquets.Where(c => c.FlowerBouquetName.Contains(name)).ToList();
                return flowerBouquets;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

