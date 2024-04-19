using NPoco;

namespace WolneLekturyCwiczenia.Models.SQL.Table
{
    [TableName("testowa")]
    [PrimaryKey("Id", AutoIncrement = true)]
    public class Testowa
    {
        public int Id { get; set; }
        public string Message { get; set; }

    }
}
