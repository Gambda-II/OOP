namespace GetLucky;

/*
Schreiben Sie ein Lottoprogramm (6 aus 49).
Dieses soll ein Array enthalten, das 6 pseudozufallsgenerierte Gewinnzahlen beinhaltet.
Nun soll der Anwender 6 Zahlen aus 49 auswählen, die mit den Gewinnzahlen verglichen werden müssen
und es ausgegeben wird, wie viele Richtige man hat.

Beispiel-Ausgabe:

Lotto-Zahlen:   1 2 9 10 42 49
Superzahl:      7

Spielschein:    1234567
Ihre Zahlen:    2 5 9 11 42 48
Richtige:       3 + Superzahl

------------------------------
Lotto-Zahlen:   1 2 9 10 42 49
Superzahl:      6

Spielschein:    1234567
Ihre Zahlen:    2 5 9 11 42 48
Richtige:       3

Optional:
Arbeiten Sie zusätzlich mit der Zusatzzahl.
*/

// Schritt 1. Dafuq ist eine Zusatzzahl? -> Jeder Schein hat eine Spielscheinnummer (6 bzw. 7 stellig, Ziffern von 0 bis 9), die letzte Ziffer ist die SUPERZAHL
// Schritt 2. Rest
// Schritt 4. Vielleicht noch mehrere Tipps gleichzeitig, Preis / Gewinn etc..

public class Program
{
    public static void Main()
    {
        Player player = new Player();
        Console.Clear();
        Lotto spiel = new Lotto();
        Logic.DisplayGame(player,spiel);
        //Console.WriteLine(spiel.CountMatchingNumbers(player.BetNumbers,spiel.WinNumbers));
    }
}