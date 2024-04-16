namespace WolneLekturyCwiczenia.Models
{
    public class Asd
    {
        public int a { get; set; }
        public int b { get; set; }

        public Asd(int pierwszaliczba, int drugaliczba)
        {
            a= pierwszaliczba;
            b= drugaliczba;
        }

        public int Add()
        {
            return a + b;
        }
        public int Multiply()
        {
            return a * b;
        }
        public double Divide()
        {
            return (double)a / (double)b;
        }
    }

}
