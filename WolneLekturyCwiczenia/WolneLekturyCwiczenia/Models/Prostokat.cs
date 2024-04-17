

namespace WolneLekturyCwiczenia.Models
{
    public class Prostokat
    {
        public int a {  get; set; }
        public int b { get; set; }
        public Prostokat(int _a, int _b)
        {
            a = _a;
            b = _b;
        }
        public int PP()
        {
            return a * b;
        }
        public int Obw()
        { 
            return 2 * a + 2 * b;
        }
        public int Longer()
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }

        }
    }
}
