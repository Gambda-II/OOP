namespace P07_VerwaltungInKonsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Kunde> alleKunden = new List<Kunde>()
            {
                new Kunde(){Vorname = "Max", Nachname = "Mustermann", Geburtsdatum = new DateOnly(1990, 1, 1), Telefonnummer = "0123456789"},
                new Kunde(){Vorname = "Erika", Nachname = "Mustermann", Geburtsdatum = new DateOnly(1991, 1, 1), Telefonnummer = "0987654321"},
                new Kunde(){Vorname = "John", Nachname = "Doe", Geburtsdatum = new DateOnly(1992, 1, 1), Telefonnummer = "0456123789"},
                new Kunde(){Vorname = "Jane", Nachname = "Doe", Geburtsdatum = new DateOnly(1993, 1, 1), Telefonnummer = "0369258147"},
                new Kunde(){Vorname = "Anna", Nachname = "Conda", Geburtsdatum = new DateOnly(1994, 1, 1), Telefonnummer = "0147258369"},
                new Kunde(){Vorname = "Max", Nachname = "Power", Geburtsdatum = new DateOnly(1995, 1, 1), Telefonnummer = "0852741963"},
                new Kunde(){Vorname = "Peter", Nachname = "Pan", Geburtsdatum = new DateOnly(1996, 1, 1), Telefonnummer = "0357159645"},
                new Kunde(){Vorname = "Micky", Nachname = "Mouse", Geburtsdatum = new DateOnly(1997, 1, 1), Telefonnummer = "0987632145"},
                new Kunde(){Vorname = "Donald", Nachname = "Duck", Geburtsdatum = new DateOnly(1998, 1, 1), Telefonnummer = "0964785231"},
                new Kunde(){Vorname = "Dagobert", Nachname = "Duck", Geburtsdatum = new DateOnly(1999, 1, 1), Telefonnummer = "0987542361"},
            };




            string eingabe = "";
            do
            {

                HauptMenu();
                Console.WriteLine("Bitte wählen Sie eine Option aus: (Z.B.: 1 oder 3 oder X)");
                eingabe = Console.ReadLine();

                switch (eingabe)
                {
                    case "1":
                        {
                            KundeListeAnzeigenDynamisch(alleKunden);
                            break;
                        }
                    case "2":
                        {

                            Kunde currentKunde = ChooseKunde(alleKunden);
                            UpdateKunde(currentKunde);

                            break;
                        }
                    case "3":
                        {

                            Kunde currentKunde = ChooseKunde(alleKunden);

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(currentKunde.Ausgabe());
                            Console.ForegroundColor = ConsoleColor.White;

                            bool isToDelete = UserInputYesOrNo();

                            if (isToDelete)
                            {
                                DeleteKunde(currentKunde, alleKunden);
                                Console.WriteLine("\n[Enter] um zurück zum Hauptmenü zu gelangen.");
                                Console.ReadKey(true);
                            }
                            else
                            {
                                Console.WriteLine("\n[Enter] um zurück zum Hauptmenü zu gelangen.");
                                Console.ReadKey(true);
                            }


                            // Der User soll in der Lage sein einen ausgewählten Kuden zu löschen
                            // Es muss eine Sicherheitsabfrage geben, damit der User nicht ausversehen
                            // den falschen Kunden löscht
                            break;
                        }
                    case "4":
                        {
                            CreateNewKunde(alleKunden);
                            // Der User soll in der Lage sein einen neuen Kunden anzulegen
                            // Der User soll alle Eigenschaften außer der ID des Kunden eingeben können
                            // Die ID soll automatisch vergeben werden anhand der letzen vergebenen ID
                            break;
                        }
                    case "X":
                        {

                            break;
                        }
                    default:
                        Console.WriteLine("Keine gültige Eingabe, versuchen Sie es nochmal!");
                        Console.ReadKey();
                        break;
                }




            } while (eingabe != "X");
        }

        private static void DeleteKunde(Kunde currentKunde, List<Kunde> kunden)
        {
            kunden.Remove(currentKunde);
            Console.Write("\n\nDer Kunde wurde erfolgreich gelöscht.");
        }

        private static bool UserInputYesOrNo()
        {
            int position = 0;
            ConsoleKey keyPressed;// = Console.ReadKey().Key;

            (int x, int y) = Console.GetCursorPosition();
            Console.CursorVisible = false;


            string yesString = " JA ";
            string noString = "[NEIN] ";


            (int yesX, int yesY) = (0, 0);
            (int noX, int noY) = (0, 0);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Möchten Sie diesen Kunden wirklich löschen?");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("\t");
            (yesX, yesY) = Console.GetCursorPosition();
            Console.Write(yesString);
            Console.Write("\t");
            (noX, noY) = Console.GetCursorPosition();
            Console.Write(noString);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;

            do
            {
                Console.SetCursorPosition(x, y);
                keyPressed = Console.ReadKey().Key;
                if (keyPressed == ConsoleKey.LeftArrow)
                    position--;
                if (keyPressed == ConsoleKey.RightArrow)
                    position++;

                 int i = position % 2;
                 yesString = Math.Abs(position % 2) == 1 ? "[JA]" : " JA ";
                 noString = position % 2 == 0 ? "[NEIN] " : " NEIN ";


                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Möchten Sie diesen Kunden wirklich löschen?");
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("\t");
                (yesX, yesY) = Console.GetCursorPosition();
                Console.Write(yesString);
                Console.Write("\t");
                (noX, noY) = Console.GetCursorPosition();
                Console.Write(noString);
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.White;

            }
            while ((keyPressed != ConsoleKey.Enter));

            Console.CursorVisible = true;
            return Math.Abs(position % 2) == 1;
        }

        private static void UpdateKunde(Kunde currentKunde)
        {
            Console.Clear();
            string inputString;
            DateOnly inputDate;

            (int x, int y) = (0, 0);
            Console.SetCursorPosition(x, y);

            Console.WriteLine("Aktueller Vorname: {0}", currentKunde.Vorname);
            Console.Write("Neuer Vorname: \t");
            (x, y) = Console.GetCursorPosition();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(currentKunde.Vorname);
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Blue;
            inputString = Console.ReadLine();
            currentKunde.Vorname = inputString.Length == 0 ? currentKunde.Vorname : inputString;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(currentKunde.Vorname);
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("Aktueller Nachname: {0}", currentKunde.Nachname);
            Console.Write("Neuer Vorname: \t");
            (x, y) = Console.GetCursorPosition();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(currentKunde.Nachname);
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Blue;
            inputString = Console.ReadLine();
            currentKunde.Nachname = inputString.Length == 0 ? currentKunde.Nachname : inputString;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(currentKunde.Nachname);
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("Aktuelles Geburtsdatum: {0}", currentKunde.Geburtsdatum);
            Console.Write("Neues Datum: \t");
            (x, y) = Console.GetCursorPosition();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(currentKunde.Geburtsdatum);
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Blue;
            inputString = Console.ReadLine();
            currentKunde.Geburtsdatum = DateOnly.TryParse(inputString.Length == 0 ? currentKunde.Geburtsdatum.ToString() : inputString, out inputDate) ? currentKunde.Geburtsdatum : inputDate;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(currentKunde.Geburtsdatum);
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("Aktuelle Telefonnummer: {0}", currentKunde.Telefonnummer);
            Console.Write("Neues Telefonnummer: \t");
            (x, y) = Console.GetCursorPosition();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(currentKunde.Telefonnummer);
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Blue;
            inputString = Console.ReadLine();
            currentKunde.Telefonnummer = inputString.Length == 0 ? currentKunde.Telefonnummer : inputString;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(currentKunde.Telefonnummer);
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Gray;


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Daten wurden aktualisiert.");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Zurück zum Hauptmenü [Enter] drücken.");
            Console.ReadKey();

            HauptMenu();
        }

        private static Kunde ChooseKunde(List<Kunde> kunden)
        {
            Console.Clear();

            Console.WriteLine("Bitte die Kunden-ID eingeben:");
            bool isValid = false;
            int inputID = -1;

            while (!isValid)
            {
                isValid = int.TryParse(Console.ReadLine(), out inputID) & inputID > 0;
            }

            foreach (Kunde k in kunden)
            {
                if (k.ID == inputID)
                {
                    return k;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ID konnte nicht gefunden werden. Bitte neu versuchen.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey(true);
            return ChooseKunde(kunden);
        }

        static void HauptMenu()
        {
            Console.Clear();
            Console.WriteLine("""
                  ______________________________
                 / \                             \.
                |   |                            |.
                 \_ |                            |.
                    |                            |.
                    |   1. Alle Kunden anzeigen  |.
                    |   2. Kunde bearbeiten      |.
                    |   3. Kunde löschen         |.
                    |   4. Neuen Kunden anlegen  |.
                    |                            |.
                    |   X. Programm beenden      |.
                    |                            |.
                    |                            |.
                    |                            |.
                    |                            |.
                    |   _________________________|___
                    |  /                            /.
                    \_/dc__________________________/.
                """);
        }

        static void KundeListeAnzeigenSimpel(List<Kunde> kunden)
        {
            // Ausgabe der Kunden
            // Die Ausgegebenen Informationen der Kunden sollen dem Leser
            // helfen die Kunden zu identifizieren.
            Console.Clear();

            Console.WriteLine("""
                                ╔══════╦═════════════════╦═════════════════╦════════════╦════════════╗
                                ║ ID   ║ Vorname         ║ Nachname        ║ GebDat     ║ TelefonNr. ║
                                ╠══════╬═════════════════╬═════════════════╬════════════╬════════════╣ 
                                """);

            foreach (var kunde in kunden)
            {
                string vorname = kunde.Vorname.Length > 15 ? kunde.Vorname[..12] + "..." : kunde.Vorname;
                string nachname = kunde.Nachname.Length > 15 ? kunde.Nachname[..12] + "..." : kunde.Nachname;
                Console.WriteLine($"║ {kunde.ID,4} ║ {vorname,-15} ║ {nachname,-15} ║ {kunde.Geburtsdatum,10} ║ {kunde.Telefonnummer,-10} ║");

            }

            Console.WriteLine("╚══════╩═════════════════╩═════════════════╩════════════╩════════════╝");

            Console.ReadKey();

        }

        static void KundeListeAnzeigenDynamisch(List<Kunde> kunden)
        {
            // Ausgabe der Kunden
            // Die Ausgegebenen Informationen der Kunden sollen dem Leser
            // helfen die Kunden zu identifizieren.
            Console.Clear();

            string vornameHeader = "Vorname";
            string nachnameHeader = "Nachname";

            // Berechnung der maximalen Länge der Vor- und Nachnamen
            // Alternative in LINQ mit einer Max() Funktion
            int maxLaengeVorname = vornameHeader.Length;
            int maxLaengeNachname = nachnameHeader.Length;

            foreach (var kunde in kunden)
            {
                if (kunde.Vorname.Length > maxLaengeVorname)
                {
                    maxLaengeVorname = kunde.Vorname.Length;
                }
                if (kunde.Nachname.Length > maxLaengeNachname)
                {
                    maxLaengeNachname = kunde.Nachname.Length;
                }
            }



            string rahmenVorname = "═".PadRight(maxLaengeVorname, '═');
            string headerVorname = vornameHeader.PadRight(maxLaengeVorname);
            string rahmenNachname = "═".PadRight(maxLaengeNachname, '═');
            string headerNachname = nachnameHeader.PadRight(maxLaengeNachname);

            Console.WriteLine($"""
                                ╔══════╦═{rahmenVorname}═╦═{rahmenNachname}═╦════════════╦════════════╗
                                ║ ID   ║ {headerVorname} ║ {headerNachname} ║ GebDat     ║ TelefonNr. ║
                                ╠══════╬═{rahmenVorname}═╬═{rahmenNachname}═╬════════════╬════════════╣ 
                                """);

            foreach (var kunde in kunden)
            {
                Console.WriteLine($"║ {kunde.ID,4} ║ {kunde.Vorname.PadRight(maxLaengeVorname)} ║ {kunde.Nachname.PadRight(maxLaengeNachname)} ║ {kunde.Geburtsdatum,10} ║ {kunde.Telefonnummer,-10} ║");

            }

            Console.WriteLine($"╚══════╩═{rahmenVorname}═╩═{rahmenNachname}═╩════════════╩════════════╝");

            Console.ReadKey();

        }

        static void CreateNewKunde(List<Kunde> kunden)
        {
            Kunde kunde = new Kunde() {};
            (int x, int y) = (0, 0);

            Console.Clear();
            Console.WriteLine("ID wurde automatisch generiert: {0}", kunde.ID);

            (x, y) = Console.GetCursorPosition();
            Console.Write("Bitte Vorname eingeben: ");
            kunde.Vorname = TryGetString();
            Console.SetCursorPosition(x, y);
            Console.WriteLine("".PadLeft(Console.WindowWidth));
            Console.SetCursorPosition(x, y);
            Console.WriteLine("Vorname:\t " + kunde.Vorname);

            (x, y) = Console.GetCursorPosition();
            Console.Write("Bitte Nachname eingeben: ");
            kunde.Nachname = TryGetString();
            Console.SetCursorPosition(x, y);
            Console.WriteLine("".PadLeft(Console.WindowWidth));
            Console.SetCursorPosition(x, y);
            Console.WriteLine("Nachname:\t" + kunde.Nachname);

            (x, y) = Console.GetCursorPosition();
            Console.Write("Bitte Geburtsdatum eingeben: ");
            kunde.Geburtsdatum = TryGetDate();
            Console.SetCursorPosition(x, y);
            Console.WriteLine("".PadLeft(Console.WindowWidth));
            Console.SetCursorPosition(x, y);
            Console.WriteLine("Geburtsdatum:\t" + kunde.Geburtsdatum);

            (x, y) = Console.GetCursorPosition();
            Console.Write("Bitte Telefonnummer eingeben: ");
            kunde.Telefonnummer = TryGetString();
            Console.SetCursorPosition(x, y);
            Console.WriteLine("".PadLeft(Console.WindowWidth));
            Console.SetCursorPosition(x, y);
            Console.WriteLine("Telefonnummer:\t" + kunde.Telefonnummer);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Eingabe erfogreich. Bitte eine beliebige Taste drücken um zurückzukehren.");
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            kunden.Add(kunde);
            HauptMenu();
        }

        private static DateOnly TryGetDate()
        {
            bool hasWorked = false;
            DateOnly date = new DateOnly();

            while (!hasWorked)
            {
                hasWorked = DateOnly.TryParse(Console.ReadLine(), out date);
            }

            return date;
        }

        static string TryGetString()
        {
            string tmp = "";

            while (string.IsNullOrEmpty(tmp))
            {
                tmp = Console.ReadLine();
            }
            return tmp;
        }
    }
}
