using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace InventorySystem.Pages.Rangsit
{
    public class IndexRangsitModel : PageModel
    {
        public List<StockInfo> listStock = new List<StockInfo>();

        public void OnGet()
        {
            try
            {
                string connectionString = "Server=tcp:inventory436p.database.windows.net,1433;Initial Catalog=inventorysystem;Persist Security Info=False;User ID=pingpong1234;Password=AWM2HXm7;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "Select * From stock Where storeid=1";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StockInfo stockInfo = new StockInfo();
                                stockInfo.itemid = "" + reader.GetInt32(0);
                                stockInfo.item = reader.GetString(1);
                                stockInfo.storeid = reader.GetString(2);
                                stockInfo.supplier = reader.GetString(3);
                                stockInfo.amount = reader.GetString(4);
                                stockInfo.create_at = reader.GetDateTime(5).ToString();

                                listStock.Add(stockInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }

    public class StockInfo
    {
        public String itemid;
        public String item;
        public String storeid;
        public String supplier;
        public String amount;
        public String create_at;
    }
}