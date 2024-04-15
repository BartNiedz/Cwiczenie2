namespace WolneLekturyCwiczenia.Models.Data
{
    public interface IDataRepository
    {
        Task<List<Categories>> GetCategories();
        Task<List<Audiobooks>> GetAudiobooks();
        Task<List<Epochs>> GetEpochs();
        Task<Nasa> GetNasa();
        Task<Mars> GetMars();
    }
}
