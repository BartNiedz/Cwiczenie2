using Microsoft.Extensions.Diagnostics.HealthChecks;
using NPoco;

namespace WolneLekturyCwiczenia.Models.SQL.Table
{
    [TableName("Formularz")]
    [PrimaryKey("FormularzId", AutoIncrement = true)]
    public class Formularz
    {        
        public int FormularzId { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Textarea { get; set; }
        public List<Formularz> Formularz_ { get; set; }       
    }
}
