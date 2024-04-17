using NPoco;
using MySqlConnector;

namespace WolneLekturyCwiczenia.Models.SQL
{
    public partial class SQLProvider : ISQL
    {
        private static string ConnectionString { get; set; }

        public SQLProvider()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            var connectionConfig = builder.Build();

            ConnectionString = connectionConfig.GetConnectionString("DefaultConnection");
        }

        private IDatabase GetDatabase()
        {
            return new Database(ConnectionString, DatabaseType.MySQL, MySqlConnectorFactory.Instance);
        }
    }
}
