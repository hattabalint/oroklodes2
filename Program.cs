using System;
using System.Collections.Generic;
using System.IO;

public abstract class Allat
{
    public static int MaxKor = 10;
    private static int KovId = 1;
    public int Id { get; private set; }
    public string Neve { get; private set; }
    public int szuletesiEv { get; private set; }
    public int SzepsegPontok { get; set; }
    public int ViselkedesPontok { get; set; }

    protected Allat(string neve, int szuletesiEv)
    {
        Id = KovId++;
        Neve = neve;
        szuletesiEv = szuletesiEv;
    }

    public int Kor => DateTime.Now.Year - szuletesiEv;

    public abstract int Eredmeny();

    public override string ToString()
    {
        
    }
}

    public class Kutya : Allat
    {
        public int kapcsPont { get; set; }

        public Kutya(string Nev, int szulEv, int viselkedesPontok) : base(Nev, szulEv)
        {
            ViselkedesPontok = viselkedesPontok;
        }

        public override int Eredmeny()
        {
            if (kapcsPont == 0)
                return 0;

            int korsz = MaxKor - Kor;
            if (Kor > MaxKor)
                return 0;

            return korsz * SzepsegPontok + Kor * SzepsegPontok + kapcsPont;
        }
    }

    public class Macska : Allat
    {
        public bool HasCarrier { get; set; }

        public Macska(string Neve, int birthYear, bool hasCarrier) : base(Neve, birthYear)
        {
            HasCarrier = hasCarrier;
        }

        public override int Eredmeny()
        {
            if (!HasCarrier)
                return 0;

            int ageFactor = MaxKor - Kor;
            if (Kor > MaxKor)
                return 0;

            return ageFactor * SzepsegPontok + Kor * SzepsegPontok;
        }
    }

    class Program
    {
        static void Main()
        {
            List<Allat> allatok = new List<Allat>();

            // adatok fajlbol beolvasas
            string[] lines = File.ReadAllLines("allatok.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                if (parts[0] == "Dog")
                {
                    allatok.Add(new Kutya(parts[1], int.Parse(parts[2]), int.Parse(parts[5]))
                    {
                        SzepsegPontok = int.Parse(parts[3]),
                        ViselkedesPontok = int.Parse(parts[4])
                    });
                }
                else if (parts[0] == "Cat")
                {
                    allatok.Add(new Macska(parts[1], int.Parse(parts[2]), bool.Parse(parts[5]))
                    {
                        SzepsegPontok = int.Parse(parts[3]),
                        ViselkedesPontok = int.Parse(parts[4])
                    });
                }
            }

            // regisztracio utan az adatok kiirasa
            Console.WriteLine("regisztracio utan:");
            foreach (Allat Allat in allatok)
            {
                Console.WriteLine(allatok);
            }

            // Verseny lerendezése (pontszamok kiszamitasa)
            Console.WriteLine("\n verseny utan::");
            foreach (Allat Allat in allatok)
            {
                Console.WriteLine(allatok);
            }
        }
    }
}
