using BussinessObject.Models;
using DataAccessObject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class CategoryManagement
    {
        private CategoryManagement() { }
        private static CategoryManagement instance = null;
        private static readonly object instanceLock = new object();
        public static CategoryManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CategoryManagement();
                    }
                    return instance;
                }
            }
        }


        public List<Category> GetAllCategory()
        {
            List<Category> categories;
            try
            {
                var c = new FUFlowerBouquetManagementContext();
                categories = c.Categories.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return categories;
        }

        public IEnumerable<int> GetCategoryID()
        {
            CategoryRepo repo = new CategoryRepo();
            try
            {
                var categories = repo.GetAllCategory().ToList().Select(c => c.CategoryId);
                return categories;

            }
            catch (Exception)
            {
                throw new Exception("Get list categoriesID unsuccessfully");
            }
        }
    }
}
