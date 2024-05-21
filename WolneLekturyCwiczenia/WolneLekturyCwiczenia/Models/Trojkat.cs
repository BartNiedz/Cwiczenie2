//using AspNetCore;

namespace WolneLekturyCwiczenia.Models
{
    public class Trojkat
    {
        int a {  get; set; }
        int b { get; set; }
        int h { get; set; }
        public Trojkat(int _a, int _b, int _h)
        {
            a= _a;
            b= _b;
            h= _h;
        }
        public int Pole()
        { 
            return (a*h)/2;
        }
        public int Obw()
        {
            return 2*b + a;
        }

    }
}
