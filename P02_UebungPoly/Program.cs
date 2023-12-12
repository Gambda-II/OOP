namespace P02_UebungPoly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Aufgabe:
             * Zum üben der Polymorphie erstellen Sie eine Anwendung die die Verwaltung bei einer 
             * Fahrzeugvermietung ermöglicht.
             * Sie sollen ein Paar Klassen für die Fahrzeuge erstellen, dabei sollen Sie Vererbung nutzen.
             * Wenn Sie wollen, können Sie auch Interfaces nutzen.
             *
             * In der Main Methode sollen Sie dann, ein paar Fahrzeuge aus den verschiedenen Klassen erstellen 
             * und diese in einer Sammlung zusammen fassen.
             * 
             * Über die Sammlung soll dann eine Schleife laufen, die alle Fahrzeuge ausgibt.
             * Außerdem soll mindestens ein PatternMatching verwendet werden, um eine besondere Eigenschaft
             * einer Klasse auszugeben.
             */

            Fahrzeug[] fahrzeuge = new Fahrzeug[]
            {
                new Anhaenger()
                {
                    ID = 1,
                    Bezeichnung = "Kleiner Schlepper",
                    BenoetigterFuehrerschein = "N/A",
                    Geschlossen = false,
                    Nutzlast = 200,
                    Volumen = 1,
                    Besonderheit = "N/A",
                    Pauschale = 15
                },
                new Anhaenger()
                {
                    ID = 2,
                    Bezeichnung = "Großer Schlepper",
                    BenoetigterFuehrerschein = "BE/CE",
                    Geschlossen = true,
                    Nutzlast = 1000,
                    Volumen = 10,
                    Besonderheit = "N/A",
                    Pauschale = 35
                },
                new FirmenPKW()
                {
                    ID = 3,
                    Bezeichnung = "Vertriebler Mobil",
                    BenoetigterFuehrerschein = "B",
                    Hersteller = "VW",
                    Modell = "Golf",
                    Verbrauch = 7.5,
                    FirmenID = 1,
                    Pauschale = 20
                },
                new FirmenPKW()
                {
                    ID = 4,
                    Bezeichnung = "Firmen Party Bus",
                    BenoetigterFuehrerschein = "B",
                    Hersteller = "MB",
                    Modell = "Vito",
                    Verbrauch = 10.25,
                    FirmenID = 2,
                    Pauschale = 25
                },
                new PrivatPKW()
                {
                    ID = 5,
                    Bezeichnung = "Familienkutsche",
                    BenoetigterFuehrerschein = "B",
                    Hersteller = "VW",
                    Modell = "Touran",
                    Verbrauch = 8.5,
                    KmStand = 100000,
                    Pauschale = 10
                },
                new PrivatPKW()
                {
                    ID = 6,
                    Bezeichnung = "Sportwagen",
                    BenoetigterFuehrerschein = "B",
                    Hersteller = "Porsche",
                    Modell = "911",
                    Verbrauch = 12.5,
                    KmStand = 50000,
                    Pauschale = 50
                },
                new Transporter()
                {
                    ID = 7,
                    Bezeichnung = "Kleiner LKW",
                    BenoetigterFuehrerschein = "C",
                    Hersteller = "MB",
                    Modell = "Sprinter",
                    Verbrauch = 12.5,
                    Groesse = "Sprinter",
                    KmStand = 100000
                },
                new Transporter()
                {
                    ID = 8,
                    Bezeichnung = "Großer LKW",
                    BenoetigterFuehrerschein = "C",
                    Hersteller = "MB",
                    Modell = "Actros",
                    Verbrauch = 20.5,
                    Groesse = "7,5t",
                    KmStand = 50000
                },
                new Motorrad()
                {
                    ID = 9,
                    Bezeichnung = "Batcicle",
                    BenoetigterFuehrerschein = "A",
                    Hersteller = "Wayne Enterprises",
                    Modell = "Batcicle",
                    Verbrauch = 0.5,
                    KmStand = 1000,
                    Pauschale = 100
                },
                new Motorrad()
                {
                    ID = 10,
                    Bezeichnung = "Akira's Bike",
                    BenoetigterFuehrerschein = "A",
                    Hersteller = "Kaneda",
                    Modell = "Akira's Bike",
                    Verbrauch = 10.5,
                    KmStand = 10000,
                    Pauschale = 100
                }
            };

            foreach (var item in fahrzeuge)
            {
                decimal preis = -2;
                switch (item)
                {
                    case Anhaenger a:
                        {
                            Console.WriteLine($"Anhänger: {a.Bezeichnung}");
                            Console.WriteLine($"Bitte Start und Ende angeben: (dd.MM.YY HH:mm - dd.MM.YY HH:mm)");
                            string[] zeiten = Console.ReadLine().Split('-');
                            a.Start = DateTime.Parse(zeiten[0]);
                            a.Ende = DateTime.Parse(zeiten[1]);

                            preis = a.PreisBerechnung();

                            break;
                        }
                    case FirmenPKW f:
                        {
                            Console.WriteLine($"Firmen PKW: {f.Bezeichnung}");

                            preis = f.PreisBerechnung();

                            break;
                        }
                    case PrivatPKW p:
                        {
                            Console.WriteLine($"Privat PKW: {p.Bezeichnung}");

                            Console.WriteLine($"Bitte Start und Ende angeben: (dd.MM.YY HH:mm - dd.MM.YY HH:mm)");
                            string[] zeiten = Console.ReadLine().Split('-');
                            p.Start = DateTime.Parse(zeiten[0]);
                            p.Ende = DateTime.Parse(zeiten[1]);

                            Console.WriteLine($"Bitte den neuen KmStand angeben:");
                            p.KmStandNeu = Double.Parse(Console.ReadLine());

                            preis = p.PreisBerechnung();

                            break;
                        }
                    case Transporter t:
                        {
                            Console.WriteLine($"Transporter: {t.Bezeichnung}");

                            Console.WriteLine($"Bitte Start und Ende angeben: (dd.MM.YY HH:mm - dd.MM.YY HH:mm)");
                            string[] zeiten = Console.ReadLine().Split('-');
                            t.Start = DateTime.Parse(zeiten[0]);
                            t.Ende = DateTime.Parse(zeiten[1]);

                            Console.WriteLine($"Bitte den neuen KmStand angeben:");
                            t.KmStandNeu = Double.Parse(Console.ReadLine());

                            preis = t.PreisBerechnung();

                        break;
                        }
                    case Motorrad m:
                        {
                            Console.WriteLine($"Motorrad: {m.Bezeichnung}");
                            Console.WriteLine("Bitte den neuen KmStand angeben:");
                            m.KmStandNeu = Double.Parse(Console.ReadLine());

                            preis = m.PreisBerechnung();

                            break;
                        }
                }
                Console.WriteLine($"Preis: {preis}");

            }
        }
    }
}
