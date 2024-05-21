using NPoco;
using WolneLekturyCwiczenia.Models.SQL.Table;

namespace WolneLekturyCwiczenia.Models
{

    public class FiltrAudio
    {
       public int AudioCount { get; set; }
       public List<Audio> Audios { get; set; }

       
    }
}
