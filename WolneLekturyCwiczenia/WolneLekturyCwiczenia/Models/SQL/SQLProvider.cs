using NPoco;
using MySqlConnector;
using WolneLekturyCwiczenia.Models.SQL.Table;
using System.Collections.Generic;
using System.Net;

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

            List<Category> category = db.Fetch<Category>("Select * from Category");

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


        public int GetElementCount()
        {
            IDatabase db = GetDatabase();

            int elementCount = db.Fetch<int>("Select count(*) from Audio").FirstOrDefault();

            return elementCount;
        }
        public int GetEpochElementCount()
        {
            IDatabase db = GetDatabase();

            int elementCount = db.Fetch<int>("Select count(*) from Epoch").FirstOrDefault();

            return elementCount;
        }
        public int GetCategoryElementCount()
        {
            IDatabase db = GetDatabase();

            int elementCount = db.Fetch<int>("Select count(*) from Category").FirstOrDefault();

            return elementCount;
        }
        public List<Audio> GetAudioJS(int limit, int page)
        {
            IDatabase db = GetDatabase();

            int offset = limit * (page - 1);

            //  List<Audio> audio = db.FetchMultiple<Audio,int>("call defaultdb.GetAudiobooks(5, 100, 'test');", new { @l = limit, @o = offset });

            List<Audio> audio = db.Fetch<Audio>("Select * from Audio order by Title asc Limit @l offset @o", new { @l = limit, @o = offset });

            return audio;
        }

        public FiltrAudio GetAudioSP(int pLimit, int pPage, string pSearch)
        {
            
            IDatabase db = GetDatabase();
            FiltrAudio audio = new FiltrAudio();

            var ret = db.FetchMultiple<Audio, int>("call defaultdb.GetAudiobooks(@l, @o, @s);", new { @l = pLimit, @o = pPage, @s = pSearch });

            audio.Audios = ret.Item1;
            audio.AudioCount = ret.Item2.FirstOrDefault();
            
            return audio; 
        }
        public List<Epoch> GetEpochJS(int limit, int page)
        {
            IDatabase db = GetDatabase();
            int offset = limit * (page - 1);
            List<Epoch> epoch = db.Fetch<Epoch>("Select * from Epoch order by Name asc limit @l offset @o", new { @l = limit, @o = offset });
            return epoch;
        }
        public List<Category> GetCategoryJS(int limit, int page)
        {
            IDatabase db = GetDatabase();
            int offset = limit * (page - 1);
            List<Category> category = db.Fetch<Category>("Select * from Category order by Name asc limit @l offset @o", new { @l = limit, @o = offset });
            return category;
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
