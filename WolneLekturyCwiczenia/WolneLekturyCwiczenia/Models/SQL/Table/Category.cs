using NPoco;

namespace WolneLekturyCwiczenia.Models.SQL.Table
{
    [TableName("Category")]
    [PrimaryKey("CategoryId", AutoIncrement = true)]
    public class Category
    {
        public int CategoryId { get; set; }
        public string Url { get; set; }
        public string Href { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}
