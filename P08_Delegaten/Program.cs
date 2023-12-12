using P08_Delegaten;

namespace P08_Delegate;

// Delegates sind ein wichtiges Grundkonzept aller Programmiersprachen. Es ist fundamental wie der Daten- und Kontrollfluss, tatsächlich ist es die Kombination aus beiden

// Delegates sind "Variablen", die keine Daten, sondern Logik beinhalten, indem sie auf eine Methode verweisen


//Definition eines Delegates
//Dieser "Tyo" kann jetzt verwendet werden um auf PASSENDE Methoden zu verweisen
// Die Signatur der Methode muss zum Delegate passen
// Signatur = Rückgabetyp + Anzahl Parameter und deren Typen
public delegate void AusgabeDelegate(string text);

internal class Program
{
    static void Main()
    {
        // Komplett manuell:
        /*
         * Bevor ein Delegate verwendet werden kann, muss dieser in der Struktur des Programms definiert werden.
         * Wir machen das hier in dieser Datei (siehe oben), normalerweise werden Delegates (wie Klassen) separat in einer anderen Datei (im gleichen Namespace?) gespeichert
         * Mit dem definierten Delegate können dann unsere Methoden schreiben (siehe unten)
         */

        AusgabeDelegate ausgabeMethode = NameIstWurscht;
        ausgabeMethode("Hallo vorwärts");
        ausgabeMethode = AndererWurschtName;
        ausgabeMethode("Hallo rückwärts");
        //        ausgabeMethode = DieHierGehtNicht;

        AusgabeDelegate[] mehrereAusgabeDelegate; // Methoden-Arrays gehen nicht

        MacheWasMitDelegates(ausgabeMethode);


        AusgabeDelegate? sammlungMethoden = NameIstWurscht;
        sammlungMethoden += AndererWurschtName; // zur Sammlung hinzufügen
        sammlungMethoden += AndererWurschtName;
        sammlungMethoden -= AndererWurschtName; // aus der Sammlung entfernen


        // Beispiel Verwendung von Delegaten
        List<string> texte = new List<string>()
        {
            "Hallo", "Welt", "!", "Ich", "bin", "ein", "Text", ".", "Langer Text", ".", "Viel längerer Teeeeeeext", "."
        };

        texte.ForEach(NameIstWurscht);
        texte.ForEach(AndererWurschtName);

        Console.WriteLine();
        //Nicht manuell, sondern mit eingebauten Delegates dank Generik
        Action<string> derDelegateMitGenerik = NameIstWurscht;
        derDelegateMitGenerik += AndererWurschtName;

        derDelegateMitGenerik("Test des Delegates mit Generik!");

        texte.ForEach(derDelegateMitGenerik);

        // Action<string> ist identisch zu unserem Delegate
        // Actions sind definiert, als Delagten ohne Rückgabewert
        // Actions können keinen oder bis zu 16 Parametern haben
        // in den Gereschen Klammern < > kommt der Typ der Parametern rein

        Action<int> zahlDelegate; // = NameWurscht nicht kompatibel zum Delegate
        Action<int> zahlDelegate2 = DieGehtAuchNicht;
        zahlDelegate2(int.MaxValue);


        // Es gibt noch anonyme Delegaten die mit dem Lambda Operator (=>) verwendet werden
        // Kein Beispiel hierzu

        //Beispiele mit Kunden Daten
        Kunde kunde1 = new Kunde() { ID = 1, Vorname = "Max", Nachname = "Undmoritz"};
        Kunde kunde2 = new Kunde() { ID = 1, Vorname = "Moritz", Nachname = "Undmax" };

        Action<Kunde> nurID = AusgabenAlogrithmen.NurID;
        Action<Kunde> nurVorname = AusgabenAlogrithmen.NurVorname;
        Action<Kunde> nurNachname = AusgabenAlogrithmen.NurNachname;
        Action<Kunde> nurVorUndNachname = AusgabenAlogrithmen.NurVorUndNachname;
        Action<Kunde> alles = AusgabenAlogrithmen.Alles;

        kunde1.Ausgabe(nurID);
        kunde2.Ausgabe(alles);
        kunde1.Ausgabe(nurVorUndNachname);

        // Die eingebauten Delegaten kommen in 3 Varianten
        // Action -> ohne Rückgabewert und mit 0-16 Parametern
        // Func -> mit beliebigen Rückgabewerten und mit 0-16 Parametern
        // Predicate -> mit booleschen Rückgabewert und mit einem Parametern

        Action<string, int, bool> eineAction; // 3 Parameter, kein return type
        Func<string, int, bool> eineFunc; // 2 Parameter, return type bool
        Predicate<string> einPredicate; // 1 Parameter, return type bool, identisch mit Func<string, bool> einPredicateAlsFunc
    }


    // Delegates können als Paramater verwendet werden
    static void MacheWasMitDelegates(AusgabeDelegate x)
    {
        x("Hallo Delegate-Welt"); // Diese Methode hier weiß nicht, was im Delegate passiert
    }

    static void NameIstWurscht(string bezeichnerWurscht)
    {
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(" " + bezeichnerWurscht + " ");
        Console.ResetColor();
    }

    static void AndererWurschtName(string wurschtBezeichner)
    {
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine(wurschtBezeichner.Reverse().ToArray());
        Console.WriteLine(string.Join(" ",wurschtBezeichner.Reverse()));
        Console.ResetColor();
    }

    static void DieHierGehtNicht()
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Hallo Reversewelt!".Reverse().ToArray());
        Console.ResetColor();
    }

    static void DieGehtAuchNicht(int text)
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(text.ToString().Reverse().ToArray());
        Console.ResetColor();
    }

    static int DieSollteAuchNichtGehen()
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(Math.PI.ToString().Reverse());
        Console.ResetColor();
        return 3;
    }
}