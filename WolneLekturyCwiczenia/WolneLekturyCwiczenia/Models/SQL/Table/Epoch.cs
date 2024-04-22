using NPoco;

namespace WolneLekturyCwiczenia.Models.SQL.Table
{
    [TableName("Epoch")]
    [PrimaryKey("EpochId", AutoIncrement = true)]
    public class Epoch
    {
        public int EpochId { get; set; }
        public string Url { get; set; }
        public string Href { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}
