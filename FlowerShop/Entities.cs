using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop
{
    public class FlowerEntity
    {
        public int ID { get; set; }
        public int TypeID { get; set; }
        public int FreshID { get; set; }
        public string Title { get; set; }
        public string Sort { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }



    public class CounteragentEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public override string ToString()
        {
            return Title;
        }
    }

    public class FlowerTypeEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public override string ToString()
        {
            return Title;
        }
    }
    public class FreshDegreeEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public override string ToString()
        {
            return Title;
        }
    }
    public class BouquetMaterialEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public override string ToString()
        {
            return Title;
        }
    }
    public class ProvisionEntity
    {
        public int DocNumber { get; set; }
        public DateTime Date { get; set; }
        public int CounteragentID { get; set; }
        public int FlowerID { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Sum { get; set; }
    }


    public class OrderEntity
    {
        public int DocNumber { get; set; }
        public DateTime Date { get; set; }
        public int? FlowerID { get; set; }
        public int? BouquetMaterialID { get; set; }
        public double Price { get; set; }
        public int? Quantity { get; set; }
    }
}
