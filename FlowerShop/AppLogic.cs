using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.IO;

namespace FlowerShop
{
    public class ExcelReport
    {
        Microsoft.Office.Interop.Excel.Application xlApp;
        Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
        Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
        string Query;
        DataTable DataTable;
        string path;
        SqlDataAdapter DataAdapter;
        SqlConnection SqlConnection;
        public SqlCommand sqlCommand;
        public ExcelReport()
        {
            xlApp = new Microsoft.Office.Interop.Excel.Application();
            path = Path.Combine(Environment.CurrentDirectory, "Excel.xlsx");
            xlWorkBook = xlApp.Workbooks.Open(path, 0, true, 5, "", "",
                true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "/t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            SqlConnection = new SqlConnection(AppLogic.ConnectionString);
            sqlCommand = new SqlCommand(Query, SqlConnection);
            DataAdapter = new SqlDataAdapter(sqlCommand);
        }

        public void EntriesAmount(DataGridView dataGridView1)
        {
            xlApp.Cells[1, 1] = "Номер документа";
            xlApp.Cells[1, 2] = "Дата";
            xlApp.Cells[1, 3] = "Цветок";
            xlApp.Cells[1, 4] = "Контрагент";
            xlApp.Cells[1, 5] = "Цена за штуку";
            xlApp.Cells[1, 6] = "Кол-во";
            xlApp.Cells[1, 7] = "Сумма";
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        xlApp.Cells[i + 3, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                        (xlWorkSheet.Cells[i + 3, j + 1] as Microsoft.Office.Interop.Excel.Range).Font.Bold = false;
                        (xlWorkSheet.Cells[i + 3, j + 1] as Microsoft.Office.Interop.Excel.Range).Font.Size = 13;
                        (xlWorkSheet.Cells[i + 3, j + 1] as Microsoft.Office.Interop.Excel.Range).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                        (xlApp.Cells[dataGridView1.Rows.Count + 2, i + 1] as Microsoft.Office.Interop.Excel.Range).EntireColumn.AutoFit();
                        xlApp.Visible = true;
                        xlApp.UserControl = true;
                    }
                }
                xlApp.Cells[dataGridView1.Rows.Count + 2, 2] = $"Кол-во записей : {dataGridView1.Rows.Count-1}";
                SqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void WithSummary(DataGridView dataGridView1)
        {
            Query = "select Number  as 'Номер документа'," +
            "Date as 'Дата'," +
            "Flowers.Title as 'Цветок'," +
            "Counteragents.Title as 'Контрагент'," +
            "Provisions.Price as 'Цена за штуку'," +
            "Quantity as 'Кол-во'," +
            "Sum as 'Сумма' from Provisions " +
            "inner join Flowers on FlowerID = Flowers.Id " +
            "inner join Counteragents on AgentID = Counteragents.Id";
            SqlConnection.Open();
            DataTable = new DataTable();
            sqlCommand = new SqlCommand(Query, SqlConnection);
            DataAdapter = new SqlDataAdapter(sqlCommand);
            DataAdapter.Fill(DataTable);
            dataGridView1.DataSource = DataTable;
            xlApp.Cells[1, 2] = "Номер документа";
            xlApp.Cells[1, 3] = "Дата";
            xlApp.Cells[1, 4] = "Цветок";
            xlApp.Cells[1, 5] = "Контрагент";
            xlApp.Cells[1, 6] = "Цена за штуку";
            xlApp.Cells[1, 7] = "Кол-во";
            xlApp.Cells[1, 8] = "Сумма";
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                     
                        xlApp.Cells[i + 3, j + 2] = dataGridView1.Rows[i].Cells[j].Value;
                        (xlWorkSheet.Cells[i + 3, j + 2] as Microsoft.Office.Interop.Excel.Range).Font.Bold = false;
                        (xlWorkSheet.Cells[i + 3, j + 2] as Microsoft.Office.Interop.Excel.Range).Font.Size = 13;
                        (xlWorkSheet.Cells[i + 3, j + 2] as Microsoft.Office.Interop.Excel.Range).HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                        (xlApp.Cells[dataGridView1.Rows.Count + 2, i + 1] as Microsoft.Office.Interop.Excel.Range).EntireColumn.AutoFit();
                        xlApp.Visible = true;
                        xlApp.UserControl = true;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SqlConnection.Close();
        }
    
        public void GroupBy()
        {

        }
    }
    public static class AppLogic
    {

        internal static string ConnectionString = $@"Server=(LocalDB)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName={Environment.CurrentDirectory}\Database1.mdf";
        public static SqlConnection SqlConnection;
        public static SqlCommand SqlCommand = null;
        private static string Query = null;

        private static DataTable DataTable = null;
        private static SqlDataAdapter DataAdapter;
        public static void RegisterEntry()
        {
            Query = "exec RegisterEntry";
            SqlConnection = new SqlConnection(ConnectionString);
            SqlCommand = new SqlCommand(Query, SqlConnection);
            SqlConnection.Open();
            SqlCommand.ExecuteNonQuery();
            SqlConnection.Close();
            MessageBox.Show("Вход произведен. Процедура регистрации посещения сработала");
        }
        public static void ShowFlowersTable(DataGridView dgv)
        {
            Query = "select Flowers.ID, Flowers.Title, Sort,"+
"FreshDegrees.Title as 'FreshDegree', FlowerTypes.Title as 'FlowerType',"+
"Price from Flowers "+
"inner join FreshDegrees on FreshID = FreshDegrees.Id "+
"inner join FlowerTypes on TypeID = FlowerTypes.id";
            DataTable = new DataTable();
            try
            {            
                SqlConnection = new SqlConnection(ConnectionString);
                SqlCommand = new SqlCommand(Query, SqlConnection);
                SqlConnection.Open();
                DataAdapter = new SqlDataAdapter(SqlCommand);
                DataAdapter.Fill(DataTable);
                dgv.DataSource = DataTable;
                SqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void ShowCounteragentsTable(DataGridView dgv)
        {
            Query = "select * from Counteragents";
            DataTable = new DataTable();
            try
            {
                SqlConnection = new SqlConnection(ConnectionString);
                SqlCommand = new SqlCommand(Query, SqlConnection);
                SqlConnection.Open();
                DataAdapter = new SqlDataAdapter(SqlCommand);
                DataAdapter.Fill(DataTable);
                dgv.DataSource = DataTable;
                SqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void ShowProvisionsTable(DataGridView dgv)
        {
            Query = "select Number  as 'Номер документа'," +
          "Date as 'Дата'," +
          "Flowers.Title as 'Цветок'," +
          "Counteragents.Title as 'Контрагент'," +
          "Provisions.Price as 'Цена за штуку'," +
          "Quantity as 'Кол-во'," +
          "Sum as 'Сумма' from Provisions " +
          "inner join Flowers on FlowerID = Flowers.Id " +
          "inner join Counteragents on AgentID = Counteragents.Id";
            DataTable = new DataTable();
            try
            {
                SqlConnection = new SqlConnection(ConnectionString);
                SqlCommand = new SqlCommand(Query, SqlConnection);
                SqlConnection.Open();
                DataAdapter = new SqlDataAdapter(SqlCommand);
                DataAdapter.Fill(DataTable);
                dgv.DataSource = DataTable;
                SqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void ShowOrdersTable(DataGridView dgv)
        {
            DataTable = new DataTable();
            Query = "select * from Orders";
            try
            {
                SqlConnection = new SqlConnection(ConnectionString);
                SqlCommand = new SqlCommand(Query, SqlConnection);
                SqlConnection.Open();
                DataAdapter = new SqlDataAdapter(SqlCommand);
                DataAdapter.Fill(DataTable);
                dgv.DataSource = DataTable;
                SqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static List<FlowerEntity> FlowersList;
        public static void FillFlowersList()
        {
            FlowersList = new List<FlowerEntity>();
            Query = "select * from Flowers";
            SqlConnection = new SqlConnection(ConnectionString);
            SqlCommand = new SqlCommand(Query, SqlConnection);
            SqlConnection.Open();
            SqlDataReader reader =  SqlCommand.ExecuteReader();
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    FlowerEntity entity = new FlowerEntity();
                    entity.ID = reader.GetInt32(0);
                    entity.Title = reader.GetString(1);
                    entity.Price = (double)reader.GetDecimal(5);
                    FlowersList.Add(entity);
                }
            }
            SqlConnection.Close();
        }


        public static List<CounteragentEntity> CounteragentsList;
        public static void FillCounteragentsList()
        {
            CounteragentsList = new List<CounteragentEntity>();
            Query = "select * from Counteragents";
                SqlConnection = new SqlConnection(ConnectionString);
                SqlCommand = new SqlCommand(Query, SqlConnection);
                SqlConnection.Open();
                SqlDataReader reader =  SqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        CounteragentEntity entity = new CounteragentEntity();
                        entity.ID = reader.GetInt32(0);
                        entity.Title = reader.GetString(1);
                        CounteragentsList.Add(entity);
                    }
                }
                SqlConnection.Close();
        }

        public static List<FlowerTypeEntity> FlowerTypesList;
        public static void FillFlowerTypesList()
        {
            FlowerTypesList = new List<FlowerTypeEntity>();
            Query = "select * from FlowerTypes";
            SqlConnection = new SqlConnection(ConnectionString);
            SqlCommand = new SqlCommand(Query, SqlConnection);
            SqlConnection.Open();
            SqlDataReader reader =  SqlCommand.ExecuteReader();
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    FlowerTypeEntity entity = new FlowerTypeEntity();
                    entity.ID = reader.GetInt32(0);
                    entity.Title = reader.GetString(1);
                    FlowerTypesList.Add(entity);
                }
            }
            SqlConnection.Close();
        }
        public static List<FreshDegreeEntity> FreshDegreesList;
        public static void FillFreshDegreesList()
        {
            FreshDegreesList = new List<FreshDegreeEntity>();
            Query = "select * from FreshDegrees";
            SqlConnection = new SqlConnection(ConnectionString);
            SqlCommand = new SqlCommand(Query, SqlConnection);
            SqlConnection.Open();
            SqlDataReader reader =  SqlCommand.ExecuteReader();
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    FreshDegreeEntity entity = new FreshDegreeEntity();
                    entity.ID = reader.GetInt32(0);
                    entity.Title = reader.GetString(1);
                    FreshDegreesList.Add(entity);
                }
            }
            SqlConnection.Close();
        }

        public static List<BouquetMaterialEntity> BouquetMaterialsList;
        public static void FillBouquetMaterialsList()
        {
            BouquetMaterialsList = new List<BouquetMaterialEntity>();
            Query = "select * from BouquetMaterials";
            SqlConnection = new SqlConnection(ConnectionString);
            SqlCommand = new SqlCommand(Query, SqlConnection);
            SqlConnection.Open();
            SqlDataReader reader = SqlCommand.ExecuteReader();
            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    BouquetMaterialEntity entity = new BouquetMaterialEntity();
                    entity.ID = reader.GetInt32(0);
                    entity.Title = reader.GetString(1);
                    entity.Price = (double)reader.GetDecimal(2);
                    BouquetMaterialsList.Add(entity);
                   
                }
            }
            SqlConnection.Close();
        }
        public static class FlowerEntityActions
        {
            public static void Delete(int id)
            {
                Query = $"delete from Flowers where Id={id}";
                SqlCommand = new SqlCommand(Query, SqlConnection);
                try
                {
                    SqlConnection.Open();               
                    SqlCommand.ExecuteNonQuery();
                    SqlConnection.Close();
                    MessageBox.Show("Запись удалена");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); SqlConnection.Close();
                }
            }
            public static void Insert(FlowerEntity entity)
            {
                Query = $"insert into Flowers values " +
                      $"('{entity.Title}','{entity.Sort}',{entity.FreshID},{entity.TypeID},{entity.Price})";
                SqlCommand = new SqlCommand(Query, SqlConnection);
                try
                {
                    SqlConnection.Open();
                    SqlCommand.ExecuteNonQuery();
                    SqlConnection.Close();
                    MessageBox.Show("Запись добавлена");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); SqlConnection.Close();
                }
            }
            public static void Update(FlowerEntity entity)
            {
                Query = $"update Flowers set" +
                          $"('{entity.Title}','{entity.Sort}',{entity.FreshID},{entity.TypeID},{entity.Price})" +
                          $"where Id = {entity.ID}";
                SqlCommand = new SqlCommand(Query, SqlConnection);
                try
                {
                    SqlConnection.Open();                  
                    SqlCommand.ExecuteNonQuery();
                    SqlConnection.Close();
                    MessageBox.Show("Запись обновлена");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); SqlConnection.Close();
                }
            }
        }
        public static class CounteragentEntityActions
        {
           
            public static void Delete(int id)
            {
                Query = $"delete from Counteragents where Id={id}";
                SqlCommand = new SqlCommand(Query, SqlConnection);
                try
                {
                    SqlConnection.Open();     
                    SqlCommand.ExecuteNonQuery();
                    SqlConnection.Close();
                    MessageBox.Show("Запись удалена");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); SqlConnection.Close();
                }
            }
            public static void Insert(CounteragentEntity entity)
            {
                Query = $"insert into Counteragents values ('{entity.Title}')";
                SqlCommand = new SqlCommand(Query, SqlConnection);
                try
                {
                    SqlConnection.Open();
                    SqlCommand.ExecuteNonQuery();
                    SqlConnection.Close();
                    MessageBox.Show("Запись добавлена");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); SqlConnection.Close();
                }
            }
            public static void Update(CounteragentEntity entity)
            {
                Query = $"update Counteragents set ('{entity.Title}') where Id = {entity.ID}";
                SqlCommand = new SqlCommand(Query, SqlConnection);
                try
                {
                    SqlConnection.Open();
                    SqlCommand.ExecuteNonQuery();
                    SqlConnection.Close();
                    MessageBox.Show("Запись обновлена");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); SqlConnection.Close();
                }
            }
        }
        public static class ProvisionEntityActions
        {
            public static void Insert(ProvisionEntity entity)
            {           
                Query = $"insert into Provisions values " +
    $"({entity.DocNumber},'{entity.Date.ToString("yyyy-MM-dd")}',{entity.CounteragentID},{entity.FlowerID},@price,{entity.Quantity})";
                SqlCommand = new SqlCommand(Query, SqlConnection);
                SqlCommand.Parameters.Add(new SqlParameter
                {
                    SqlDbType = SqlDbType.Money,
                    ParameterName = "@price",         
                    Value = entity.Price
                });
                try
                {
                    SqlConnection.Open();
                    SqlCommand.ExecuteNonQuery();
                    SqlConnection.Close();
                    MessageBox.Show("Поставка зарегистрирована");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); SqlConnection.Close();
                }
            }
        }

     
        public static class SortActions
        {
            public static void ByAgent(int AgentID,DataGridView dgv)
            {
                SqlConnection = new SqlConnection(ConnectionString);
                DataTable = new DataTable();
                Query = $"select * from provisions where agentID = {AgentID}";
                SqlCommand = new SqlCommand(Query, SqlConnection);
                SqlConnection.Open();            
                DataAdapter = new SqlDataAdapter(SqlCommand);
                DataAdapter.Fill(DataTable);
                dgv.DataSource = DataTable;
                SqlConnection.Close();
            }
            public static void ByPeriod(DateTime from, DateTime to, DataGridView dgv)
            {
                SqlConnection = new SqlConnection(ConnectionString);
                DataTable = new DataTable();
                Query = $"select * from provisions where date between '{from.Date}' and '{to.Date}'";
                SqlCommand = new SqlCommand(Query, SqlConnection);
                SqlConnection.Open();
                DataAdapter = new SqlDataAdapter(SqlCommand);
                DataAdapter.Fill(DataTable);
                dgv.DataSource = DataTable;
                SqlConnection.Close();
            }
            public static int BouquetQuantity()
            {
                SqlConnection = new SqlConnection(ConnectionString);
                int count = 0;
                Query = $"select count(*) from orders where bouquetID is not null";
                SqlCommand = new SqlCommand(Query, SqlConnection);
                SqlConnection.Open();
                count = (int)SqlCommand.ExecuteScalar();
                SqlConnection.Close();
                return count;
            }
            public static void ByDate(DateTime date, DataGridView dgv)
            {
                SqlConnection = new SqlConnection(ConnectionString);
                DataTable = new DataTable();
                Query = $"select * from provisions where date = '{date.Date}'";
                SqlCommand = new SqlCommand(Query, SqlConnection);
                SqlConnection.Open();
                DataAdapter = new SqlDataAdapter(SqlCommand);
                DataAdapter.Fill(DataTable);
                dgv.DataSource = DataTable;
                SqlConnection.Close();
            }
            public static void BySum(double sum, DataGridView dgv)
            {
                SqlConnection = new SqlConnection(ConnectionString);
                DataTable = new DataTable();
                Query = $"select * from provisions where sum > {sum}";
                SqlCommand = new SqlCommand(Query, SqlConnection);
                SqlConnection.Open();
                DataAdapter = new SqlDataAdapter(SqlCommand);
                DataAdapter.Fill(DataTable);
                dgv.DataSource = DataTable;
                SqlConnection.Close();
            }
        }
    }




    
}
