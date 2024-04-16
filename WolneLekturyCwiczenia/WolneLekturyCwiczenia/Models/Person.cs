using System.Net.Cache;

namespace WolneLekturyCwiczenia.Models
{
    public class Person
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string adress { get; set; }
        public int code { get; set; }
        public DateTime date_of_birth { get; set; }
        public string city { get; set; }

        public Person(string _name, string _surname, DateTime _date_of_birth)
        {
            name = _name;
            surname = _surname;
            date_of_birth = _date_of_birth;
        }
        
        public DateTime Age() 
        {
            return date_of_birth;
        }


        public string Name()
        {
            return string.Format("{0} {1}", name, surname);
        }
        public string Surname()
        {
            return surname;
        }
    }
}
