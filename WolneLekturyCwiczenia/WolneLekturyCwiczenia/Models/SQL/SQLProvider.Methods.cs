using NPoco;
using WolneLekturyCwiczenia.Models.SQL.Table;

namespace WolneLekturyCwiczenia.Models.SQL
{
    partial class SQLProvider
    {

        public void SaveTestowa(Testowa model)
        {
            using (IDatabase conection = GetDatabase())
            {
                conection.Save(model);
            }
        }
    }
}
