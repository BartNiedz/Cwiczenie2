using WolneLekturyCwiczenia.Models.SQL.Table;

namespace WolneLekturyCwiczenia.Models.SQL
{
    public interface ISQL
    {
        void SaveTestowa(Testowa model);
        void CreateClick(Clicks model);
        void CreateCategory(Category model);
        void CreateEpoch(Epoch model);
        void CreateAudio(Audio model);
        void CreateFormularz(Formularz model);
        List<Category> GetCategory();
        List<Epoch> GetEpochsDB();
        List<Audio> GetAudioDB();
        List<Audio> GetAudioJS();
        List<Formularz> GetFormularz();
        Audio GetDetails(int AudioId);
        void EditCategory(Category model);
        Category Get2Category(int categoryId);
        Epoch Get2Epoch(int epochId);
        Audio Get2Audio(int audioId);
        void EditEpoch(Epoch model);
        void EditAudio(Audio model);
    }
}
