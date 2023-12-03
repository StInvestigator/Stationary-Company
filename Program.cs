
using Microsoft.Data.SqlClient;
using Stationary_Company;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DatabaseManager database = new DatabaseManager(@"Data Source=DESKTOP-OF66R01\\SQLEXPRESS;Initial Catalog=StationeryCompany;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        }
    }
}
