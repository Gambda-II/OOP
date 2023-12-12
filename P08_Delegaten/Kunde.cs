namespace P08_Delegaten;

internal class Kunde
{
    public int ID { get; set; }
    public string Vorname { get; set; }
    public string Nachname { get; set; }

    public void Ausgabe(Action<Kunde> ausgabeLogik)
    {
        ausgabeLogik(this);
    }
}
