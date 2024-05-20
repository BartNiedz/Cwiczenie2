using NPoco;

namespace WolneLekturyCwiczenia.Models.SQL.Table
{
    [TableName("Audio")]
    [PrimaryKey("AudioId", AutoIncrement = true)]
    public class Audio
    {
        public int AudioId { get; set; }
        public string Kind { get; set; }
        public string Full_sort_key { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Cover_color { get; set; }
        public string Author { get; set; }
        public string Cover { get; set; }
        public string Epoch { get; set; }
        public string Href { get; set; }
        //public bool Has_audio { get; set; }
        public string Genre { get; set; }
        public string Simple_thumb { get; set; }
        public string Slug { get; set; }
        public string Cover_thumb { get; set; }
        //public object Liked { get; set; }
        
    }    
}
