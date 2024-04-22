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
    }
}
