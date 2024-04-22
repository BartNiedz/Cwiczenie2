using NPoco;
using MySqlConnector;
using WolneLekturyCwiczenia.Models.SQL.Table;

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

        public void CreateClick(Clicks model)
        {
            IDatabase db = GetDatabase();

            db.Insert(model);
        }
        public void CreateCategory(Category model)
        {
            IDatabase db = GetDatabase();

            db.Save(model);
        }
        public void CreateEpoch(Epoch model)
        {
            IDatabase db = GetDatabase();

            db.Save(model);
        }
        public void CreateAudio(Audio model)
        {
            IDatabase db = GetDatabase();

            db.Save(model);
        }
        public void CreateFormularz(Formularz model)
        {
            IDatabase db = GetDatabase();

            db.Save(model);
        }
    }
}
