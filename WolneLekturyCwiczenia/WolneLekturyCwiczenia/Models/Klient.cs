using System.Xml.Linq;

namespace WolneLekturyCwiczenia.Models
{
    public class Klient
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Phone_number { get; set; }
        public BankAccount Bank_Account { get; set; }


        public Klient(string name, string _surname, BankAccount account)
        {
            Name = name;
            Surname = _surname;
            Bank_Account = account;
        }

        public string BankName()
        { 
            return Bank_Account.Bank_name;
        }
       
    }

    public class BankAccount
    {
        public string Account_number { get; set; }
        public string Bank_name { get; set; }

    }

}
