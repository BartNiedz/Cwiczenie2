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
            List<Category> category = db.Fetch<Category>("select Name.* from Category where Name isActive = 1");

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

        public List<Category> GetCategory()
        {
            IDatabase db = GetDatabase();

            List<Category> category =  db.Fetch<Category>("Select * from Category");
            
            return category;
        }
        public Category Get2Category(int categoryId)
        {
            IDatabase db = GetDatabase();
            Category category2 = db.FirstOrDefault<Category>("Select * from Category where CategoryId = @cId", new { @cId = categoryId });
            return category2;
        }
        public List<Epoch> GetEpochsDB()
        {
            IDatabase db = GetDatabase();

            List<Epoch> epoch = db.Fetch<Epoch>("Select * from Epoch");

            return epoch;
        }
        public List<Audio> GetAudioDB()
        {
            IDatabase db = GetDatabase();

            List<Audio> audio = db.Fetch<Audio>("Select * from Audio");

            return audio;
        }

    }
}
