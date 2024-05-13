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
        public void EditCategory(Category model)
        {
            IDatabase db = GetDatabase();
            db.Update(model);
        }
        public void EditEpoch(Epoch model)
        {
            IDatabase db = GetDatabase();
            db.Update(model);
        }
        public void EditAudio(Audio model)
        {
            IDatabase db = GetDatabase();
            db.Update(model);
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
        public Epoch Get2Epoch(int epochId)
        {
            IDatabase db = GetDatabase();
            Epoch epoch2 = db.FirstOrDefault<Epoch>("Select * from Epoch where EpochId = @eId", new { @eId = epochId });
            return epoch2;
        }
        public Audio Get2Audio(int audioId)
        {
            IDatabase db = GetDatabase();
            Audio audio2 = db.FirstOrDefault<Audio>("Select * from Audio where AudioId = @aId", new { @aId = audioId });
            return audio2;
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
        public List<Audio> GetAudioJS()
        {
            IDatabase db = GetDatabase();

            List<Audio> audio = db.Fetch<Audio>("Select * from Audio order by Title asc Limit 60 offset 10");

            return audio;
        }
        public List<Formularz> GetFormularz()
        {
            IDatabase db = GetDatabase();

            List<Formularz> formularz = db.Fetch<Formularz>("Select * from Formularz order by Date desc Limit 10");

            return formularz;
        }
        public Audio GetDetails(int AudioId)
        {
            IDatabase db = GetDatabase();
            Audio detail = db.FirstOrDefault<Audio>("Select * from Audio where AudioId = @aId", new { @aId = AudioId });
            return detail;
        }

    }
}
