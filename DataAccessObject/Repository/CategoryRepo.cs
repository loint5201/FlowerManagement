using BussinessObject.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Repository
{
    public class CategoryRepo : ICategoryRepo
    {

        public List<Category> GetAllCategory() => CategoryManagement.Instance.GetAllCategory();


        public IEnumerable<int> GetCategoryID() => CategoryManagement.Instance.GetCategoryID();
    }
}
