namespace GetLucky;

public class Lotto
{
    private int[] numbers = new int[49];
    private int[] winNumbers = new int[6];
    private int superNumber;

    public int[] Numbers { get => numbers; set => numbers = value; }
    public int[] WinNumbers { get => winNumbers; set => winNumbers = value; }
    public int SuperNumber { get => superNumber; set => superNumber = value; }

    public Lotto()
    {

        this.numbers = ShuffleDomain(GenerateDomain());
        this.WinNumbers = PickWinNumbers(numbers);
        this.SuperNumber = GenerateSuperNumber();
    }

    private int[] GenerateDomain()
    {
        int[] numbers = new int[49];
        for (int i = 1; i < numbers.Length + 1; i++)
        {
            numbers[i - 1] = i;
        }

        return numbers;
    }

    // Fisher-Yates-Shuffle
    // https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
    private int[] ShuffleDomain(int[] numbersToShuffle)
    {
        Random rnd = new Random();

        for (int i = numbersToShuffle.Length - 1; i > 0; i--)
        {
            int j = rnd.Next(minValue: 0, maxValue: i + 1);
            int tmp = numbersToShuffle[i];
            numbersToShuffle[i] = numbersToShuffle[j];
            numbersToShuffle[j] = tmp;
        }

        return numbersToShuffle;
    }

    private int[] PickWinNumbers(int[] shuffledNumbers)
    {
        int[] winNumbers = new int[6];
        for (int i = 0; i < 6; i++)
        {
            winNumbers[i] = shuffledNumbers[i];
        }

        // hint: winNumbers = Array.Sort(winNumbers) does not work, because Array.Sort "overwrites" the array
        Array.Sort(winNumbers);

        return winNumbers;
    }

    private int GenerateSuperNumber()
    {
        return new Random().Next(minValue: 0, maxValue: 10);
    }
}
