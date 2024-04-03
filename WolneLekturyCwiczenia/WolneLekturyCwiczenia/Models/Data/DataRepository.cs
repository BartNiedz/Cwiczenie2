using Newtonsoft.Json;


namespace WolneLekturyCwiczenia.Models.Data
{
    public class DataRepository : IDataRepository
    {
        public async Task<List<Categories>> GetCategories()
        {
            string url = "https://wolnelektury.pl/api/genres/?format=json";

            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(url);
            var data = JsonConvert.DeserializeObject<List<Categories>>(response);

            return data;
        }

        public async Task<List<Audiobooks>> GetAudiobooks()
        {
            string url = "https://wolnelektury.pl/api/audiobooks/?format=json";

            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(url);
            var data = JsonConvert.DeserializeObject<List<Audiobooks>>(response);

            return data;
        }

        public async Task<List<Epochs>> GetEpochs()
        {
            string url = "https://wolnelektury.pl/api/epochs/?format=json";

            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(url);
            var data = JsonConvert.DeserializeObject<List<Epochs>>(response);

            return data;
        }
    }
}
