using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Data.SqlClient;

namespace InventorySystem.Pages.Siam
{
    public class IndexSiamModel : PageModel
    {
		public List<StockInfo> listStocks = new List<StockInfo>();
		public void OnGet()
        {
            try
            {
                String connectionString = "Server = tcp:inventorysystem12345.database.windows.net,1433; Initial Catalog = Inventory12345; Persist Security Info = False; User ID = AdminSlay; Password =@AdminSla_y0; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM stocks WHERE storeid=2";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StockInfo stockInfo = new StockInfo();
                                stockInfo.itemid = "" + reader.GetInt32(0);
                                stockInfo.item = reader.GetString(1);
                                stockInfo.supplier = reader.GetString(3);
                                stockInfo.amount = reader.GetString(4);
                                stockInfo.create_at = reader.GetString(5).ToString();

                                listStocks.Add(stockInfo);


                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString);

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
    