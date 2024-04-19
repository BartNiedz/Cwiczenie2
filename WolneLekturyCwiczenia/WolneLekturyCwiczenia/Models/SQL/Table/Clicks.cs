using NPoco;

namespace WolneLekturyCwiczenia.Models.SQL.Table
{
    [TableName("Clicks")]
    [PrimaryKey("ClickId", AutoIncrement = true)]
    public class Clicks
    {
        public int ClickId { get; set; }
        
        public DateTime ClickDate { get; set; }
        public string AudiobookId { get; set; }
        public string Browser { get; set; }


    }
}
