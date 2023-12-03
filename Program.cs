
using Microsoft.Data.SqlClient;
using Stationary_Company;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DatabaseManager database = new DatabaseManager(@"Data Source=DESKTOP-OF66R01\SQLEXPRESS;Initial Catalog=StationeryCompany;Integrated Security=True;TrustServerCertificate=True");
            if (database.OpenConnection())
            {
                Console.WriteLine("Database connected");
            }
            else
            {
                Console.WriteLine("Database connection error");
            }
            //database.ShowStationary("GetStationery");
            //database.ShowString("GetTypes");
            //database.ShowString("GetManagers");
            //database.ShowStationary("GetMaxAmountStationary");
            //database.ShowStationary("GetMinAmountStationary");
            //database.ShowStationary("GetMinPriceStationary");
            //database.ShowStationary("GetMaxPriceStationary");
            //database.ShowStationary("GetStationaryByType","@type", "Pens");
            //database.ShowSellings("GetStationaryByManager", "@man", "John Doe");
            //database.ShowSellings("GetStationaryByFirma", "@firma", "XYZ Ltd.");
            //database.ShowSellings("RecentSellings");
            //database.ShowStringInt("AverageAmountOfEveryType");
            //database.InsertManager(4, "John Vouage");
            //database.UpdateManager(4, "John");
            //database.DeleteManager(4);
            //database.ShowStringInt("GetTopManagerByAmount");
            //database.ShowStringDecimal("GetTopManagerByMoney");
            //database.ShowStringDecimal("GetTopManagerByMoneyOnTime","@startDate",new DateOnly(2023,1,1), "@endDate", new DateOnly(2023, 6, 1));
            //database.ShowStringDecimal("GetTopMoneyFirma");
            //database.ShowStringInt("GetTopStationaryBySellingsCount");
            //database.ShowStringDecimal("GetTopStationaryByMoney");
            //database.ShowStringInt("GetTopStationaryByAmount");
            database.ShowString("GetStationaryThatDontGettingBought", "@days", 30);
        }
    }
}
