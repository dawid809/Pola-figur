using System;

namespace KalkulatorPolFigur
{
    // Głównym celem projektu jest obliczanie pól różnych figur płaskich.

    public enum TypFigury
    {
        Kwadrat,
        Prostokat,
        Trojkat_Rownoramienny,
        Rownoleglobok,
        Trapez_Rownoramienny,
        Romb,
        Kolo
    }

    public interface IFigura
    {
        double Pole { get; }
        double Obwod { get; }
    }

    public class Kwadrat : IFigura
    {
        public double Dlugosc { get; }

        public Kwadrat(double dlugosc)
        {
            Dlugosc = (double)dlugosc;
        }

        public double Pole => Math.Pow(Dlugosc, 2);
        public double Obwod => 4 * Dlugosc;
        public override string ToString()
        {
            return $"Figura {TypFigury.Kwadrat} o obwodzie {Obwod} oraz polu powierzchi wynoszącym {Pole} jednostek kwadratowych.";
        }
    }

    public class Prostokat : IFigura
    {
        public double DlugoscA { get; }
        public double DlugoscB { get; }

        public Prostokat(double dlugoscA, double dlugoscB)
        {
            DlugoscA = dlugoscA;
            DlugoscB = dlugoscB;
        }

        public double Pole => DlugoscA * DlugoscB;
        public double Obwod => 2 * DlugoscA + 2 * DlugoscB;
        public override string ToString()
        {
            return $"{TypFigury.Prostokat} o obwodzie {Obwod} oraz polu powierzchi wynoszącym {Pole} jednostek kwadratowych.";
        }
    }

    public class Trojkat : IFigura
    {
        double Dlugosc { get; }
        double Wysokosc { get; }

        public Trojkat(double dlugosc, double wysokosc)
        {
            Dlugosc = dlugosc;
            Wysokosc = wysokosc;
        }

        public double Pole => (Dlugosc * Wysokosc) / 2;
        public double Obwod => 2 * Math.Sqrt(Math.Pow((Dlugosc / 2), 2) + Math.Pow(Wysokosc, 2)) + Dlugosc;
        public override string ToString()
        {
            return $"{TypFigury.Trojkat_Rownoramienny} o obwodzie {Obwod} oraz polu powierzchi wynoszącym {Pole} jednostek kwadratowych.";
        }
    }

    public class Rownoleglobok : IFigura
    {
        double Dlugosc { get; }
        double Wysokosc { get; }

        public Rownoleglobok(double dlugosc, double wysokosc)
        {
            Dlugosc = dlugosc;
            Wysokosc = wysokosc;
        }

        public double Pole => Dlugosc * Wysokosc;
        public double Obwod => 2 * Dlugosc + 2 * Wysokosc;
        public override string ToString()
        {
            return $"{TypFigury.Rownoleglobok} o obwodzie {Obwod} oraz polu powierzchi wynoszącym {Pole} jednostek kwadratowych.";
        }
    }

    public class Trapez : IFigura
    {
        public double DlugoscA { get; }
        public double DlugoscB { get; }
        public double Wysokosc { get; }

        public Trapez(double dlugoscA, double dlugoscB, double wysokosc)
        {
            DlugoscA = dlugoscA;
            DlugoscB = dlugoscB;
            Wysokosc = wysokosc;
        }

        public double Pole => ((DlugoscA + DlugoscB) * Wysokosc) / 2;
        public double Obwod => 2 * Math.Sqrt(Math.Pow((DlugoscA - DlugoscB) / 2, 2) + Math.Pow(Wysokosc, 2)) + DlugoscA + DlugoscB;
        public override string ToString()
        {
            return $"{TypFigury.Trapez_Rownoramienny} o obwodzie {Obwod} oraz polu powierzchi wynoszącym {Pole} jednostek kwadratowych.";
        }
    }

    public class Romb : IFigura
    {
        public double Dlugosc { get; }
        public double Wysokosc { get; }

        public Romb(double dlugosc, double wysokosc)
        {
            Dlugosc = dlugosc;
            Wysokosc = wysokosc;
        }

        public double Pole => Dlugosc * Wysokosc;
        public double Obwod => 4 * Dlugosc;
        public override string ToString()
        {
            return $"{TypFigury.Romb} o obwodzie {Obwod} oraz polu powierzchi wynoszącym {Pole} jednostek kwadratowych.";
        }
    }

    public class Kolo : IFigura
    {
        double Promien { get; }

        public Kolo(double promien)
        {
            Promien = promien;
        }

        public double Pole => Math.Pow((Math.PI * Promien), 2);
        public double Obwod => 2 * Math.PI * Promien;
        public override string ToString()
        {
            return $"{TypFigury.Kolo} o obwodzie {Obwod} oraz polu powierzchi wynoszącym {Pole} jednostek kwadratowych.";
        }
    }
    //Fabryka
    public class FabrykaFigur
    {
        public IFigura StworzFigure(string nazwaFigury, double dlugoscOrPromien)
        {
            switch (nazwaFigury)
            {
                case "kwadrat":
                    return new Kwadrat(dlugoscOrPromien);
                case "kolo":
                    return new Kolo(dlugoscOrPromien);
                default:
                    throw new ArgumentException("Nie ma takiej figury w kalkulatorze");
            }
        }

        public IFigura StworzFigure(string nazwaFigury, double dlugoscBokuA, double wysokosc)
        {
            switch (nazwaFigury)
            {
                case "prostokat":
                    return new Prostokat(dlugoscBokuA, wysokosc);
                case "trojkat":
                    return new Trojkat(dlugoscBokuA, wysokosc);
                case "rownoleglobok":
                    return new Rownoleglobok(dlugoscBokuA, wysokosc);
                case "romb":
                    return new Romb(dlugoscBokuA, wysokosc);
                default:
                    throw new ArgumentException("Nie ma takiej figury w kalkulatorze");
            }
        }

        public IFigura StworzFigure(string nazwaFigury, double dlugoscBokuA, double dlugoscBokuB, double wysokosc)
        {
            switch (nazwaFigury)
            {
                case "trapez":
                    return new Trapez(dlugoscBokuA, dlugoscBokuB, wysokosc);
                default:
                    throw new ArgumentException("Nie ma takiej figury w kalkulatorze");
            }
        }
    }

    //Wzorzec adapter - trochę wymuszony.
    class AdapterFigura
    {
        IFigura figura;
        public AdapterFigura(IFigura figura)
        {
            this.figura = figura;
        }
        public double Area() => figura.Pole;
        public double Perimeter() => figura.Obwod;
        public string AreaAndPerimeter()
        {
            return $"{figura.GetType().Name} Perimeter = {figura.Obwod} : Area = {figura.Pole} square units.";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Tworzenie obiektow poprzez fabrykę : nazwy figur podajemy z małych liter oraz bez polskich znaków.
            //Trojkąt oraz trapez są równoramienne.

            FabrykaFigur fabrykaFigur = new FabrykaFigur();

            IFigura figura1 = fabrykaFigur.StworzFigure("trojkat", 6, 4);
            Console.WriteLine(figura1.ToString());

            AdapterFigura adapter = new AdapterFigura(figura1);
            adapter.Area();
            Console.WriteLine(adapter.AreaAndPerimeter());
        }
    }
}

