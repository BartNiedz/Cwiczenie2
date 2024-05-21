namespace WolneLekturyCwiczenia.Models
{
    public class ProstokatBC
    {
       public int x { get; set; } 
       public int y { get; set; }

        public int Pole()
        {
            return x * y;
        }
        public int Obwod()
        {
            return 2 * x + 2 * y;
        }
    }
}