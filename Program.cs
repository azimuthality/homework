using System;

namespace LR01_Fractions
{

    class Fractions
    {
        int numerator ;
        int denominator ;
        public Fractions(int x, int y)
        {
            this.numerator = x;
            this.denominator = y;
        }
        public Fractions(int x)
        {
            this.numerator = x;
            this.denominator = 1;
        }
        public Fractions(int x, int y, int z)
        {
            this.numerator = y * z + x;
            this.denominator = y;
        }
        public double Division()
        {
            return (double)(numerator) / denominator;
        }
        public static Fractions operator +(Fractions x, Fractions y)
        {
            return new Fractions(x.numerator * y.denominator + y.numerator * x.denominator, x.numerator * y.denominator);
        }
        public static Fractions operator -(Fractions x, Fractions y)
        {
            return new Fractions(x.numerator * y.denominator - y.numerator * x.denominator, x.denominator * y.denominator);
        }
        public static Fractions operator *(Fractions x, Fractions y)
        {
            return new Fractions(x.numerator * y.numerator, x.denominator * x.denominator);
        }
        public static Fractions operator /(Fractions x, Fractions y)
        {
            return new Fractions(x.numerator * y.denominator, x.denominator * y.numerator);
        }
        public string Receiving()
        {
            if (numerator * denominator >= 0)
            {
                return "+";
            }
            else
            {
                return "-";
            }
        }
        public int this[int index]
        {
            get { return (index == 0) ? numerator : denominator; }
        }
        public delegate void Delegat(Fractions a, int b);
        public event Delegat MyEventNumerator;
        public event Delegat MyEventDenominator;
        public int Numerator
        {
            get { return numerator; }
            set { MyEventNumerator(this, value); numerator = value; }
        }
        public int Denominator
        {
            get { return denominator; }
            set { MyEventDenominator(this, value); denominator = value; }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Fractions fractions1 = new Fractions(-1, 2);
            Fractions fractions2 = new Fractions(3, 4, 7);
            Console.WriteLine(fractions1.Receiving());
            fractions1.MyEventNumerator += NMetod;
            fractions1.MyEventDenominator += DMetod;
            fractions1.Numerator = 15;
            fractions1.Denominator = 110;
            Fractions drobe3 = new Fractions(10);
            
            Console.WriteLine("+: " + (fractions1 + fractions2)[0] + "/" + (fractions1 + fractions2)[1]);
            Console.WriteLine("-: " + (fractions1 - fractions2)[0] + "/" + (fractions1 - fractions2)[1]);
            Console.WriteLine("*: " + (fractions1 * fractions2)[0] + "/" + (fractions1 * fractions2)[1]);
            Console.WriteLine("/: " + (fractions1 / fractions2)[0] + "/" + (fractions1 / fractions2)[1]);
            Console.WriteLine(fractions2.Division());
            Console.WriteLine(fractions1[0] + "/" + fractions1[1]);
            Console.WriteLine(fractions1.Numerator + "/" + fractions1.Denominator);
            Console.ReadKey();
        }
        public static void NMetod(Fractions a, int b)
        {
            Console.WriteLine("изменился числитель");
        }
        public static void DMetod(Fractions a, int b)
        {
            Console.WriteLine("изменился знаменатель");
        }
    }
    }

