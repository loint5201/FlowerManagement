using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Repository
{
    public interface IFlowerBouquetRepo
    {
        IEnumerable<FlowerBouquet> GetFlowerBouquets();
        void AddNewFlower(FlowerBouquet fb);
        void UpdateFlower(FlowerBouquet fb);
        FlowerBouquet GetFlowerBouquetbyId(int id);
        void RemoveFlower(FlowerBouquet fb);
        List<FlowerBouquet> SearchFlower(string name);

    }
}
