using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace FlowerShop
{
    public static class OrderModel
    {
        private static string query = null;
        public static Dictionary<FlowerEntity,int> basket = new Dictionary<FlowerEntity, int>();

        public static bool CreateBouquet = false;
        public static BouquetMaterialEntity BouquetMaterial = null;
        public static FlowerEntity SelectedFlower = null;
        public static int DocNumber;
        public static int Quantity;
        public static void ClearBasket()
        {
            basket.Clear();
        }
        public static void BasketAddItem(FlowerEntity flower,int quantity)
        {
            try
            {
                if (CreateBouquet == true)
                    basket.Add(flower, quantity);
            } 
            catch 
            {
                
            }
        }

        public static void CreateOrder()
        {
            AppLogic.SqlConnection.Open();
            if (CreateBouquet == true)
            {
                AppLogic.SqlConnection = new SqlConnection(AppLogic.ConnectionString);

            
                foreach (var obj in basket)
                {
                    if (basket.Count > 0)
                    {
                        query = $"insert into orders(Number,FlowerID,Price,Quantity,Date) values({DocNumber},{obj.Key.ID}," +
                            $"{obj.Key.Price * obj.Value},{obj.Value},'{DateTime.Now.Date.ToString("yyyy-MM-dd")}')";
                        AppLogic.SqlCommand = new SqlCommand(query, AppLogic.SqlConnection);
                        AppLogic.SqlCommand.ExecuteNonQuery();
                    }
                }
  
                query = $"insert into orders(Number,BouquetID,Price,Quantity,Date) values " +
                    $"({DocNumber},{BouquetMaterial.ID},{BouquetMaterial.Price},1,'{DateTime.Now.Date.ToString("yyyy-MM-dd")}') ";
                AppLogic.SqlCommand = new SqlCommand(query, AppLogic.SqlConnection);
                AppLogic.SqlCommand.ExecuteNonQuery();
                MessageBox.Show("Букет создан");
            }
            else
            {
                if (SelectedFlower != null)
                {
                    query = $"insert into orders(Number,FlowerID,Price,Quantity,Date) values({DocNumber}," +
                        $"{SelectedFlower.ID},{SelectedFlower.Price},{Quantity},'{DateTime.Now.Date.ToString("yyyy-MM-dd")}')";
                    AppLogic.SqlCommand = new SqlCommand(query, AppLogic.SqlConnection);
                    AppLogic.SqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Заказ создан");
                }
            }
            AppLogic.SqlConnection.Close();

        }
    }
}
