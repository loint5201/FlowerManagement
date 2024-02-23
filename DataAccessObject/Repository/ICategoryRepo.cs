using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Repository
{
    public interface ICategoryRepo
    {
        List<Category> GetAllCategory();

        IEnumerable<int> GetCategoryID();
    }
}
