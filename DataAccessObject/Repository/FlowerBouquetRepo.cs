using BussinessObject.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Repository
{
    public class FlowerBouquetRepo : IFlowerBouquetRepo
    {

        public IEnumerable<FlowerBouquet> GetFlowerBouquets() => FlowerBouquetManagement.Instance.GetFlowerBouquets();

        public void AddNewFlower(FlowerBouquet fb) => FlowerBouquetManagement.Instance.AddNewFlower(fb);

        public void UpdateFlower(FlowerBouquet fb) =>FlowerBouquetManagement.Instance.UpdateFlower(fb);

        public FlowerBouquet GetFlowerBouquetbyId(int id) => FlowerBouquetManagement.Instance.GetFlowerBouquetById(id);

        public void RemoveFlower(FlowerBouquet fb) => FlowerBouquetManagement.Instance.RemoveFlower(fb);

        public List<FlowerBouquet> SearchFlower(string name) => FlowerBouquetManagement.Instance.SearchFlower(name);
    }
}
