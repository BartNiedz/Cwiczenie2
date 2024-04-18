namespace WolneLekturyCwiczenia.Models
{
    public class Klient
    {
        public string Name { get; set; }    
        public string Surname { get; set; }
        public int Phone_number { get; set; }
        public int Account_number { get; set; }
    }

    public class BankAccount
    {
        public int Account_number { get; set; }
        public int Bank_name { get;set; }
    }
}
