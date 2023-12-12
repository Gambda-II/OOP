namespace _00Basics;

public class Basics
{
    public static void Main()
    {
        Dictionary<string,int> keyValuePairs = new Dictionary<string,int>();
        keyValuePairs.Add("A",1);
        keyValuePairs.Add("B",2);
        keyValuePairs.Add("C",3);
        keyValuePairs.Add("D",4);

        Console.WriteLine(keyValuePairs["A"]);

        Queue<string> queue = new Queue<string>();
        queue.Enqueue("vier");
        queue.Enqueue("fünf");
        queue.Enqueue("sechs");
        queue.Enqueue("sieben");
        Console.WriteLine(queue.Count);
        foreach (var x in queue)
        {
            Console.WriteLine(x);
        }
        queue.Dequeue();
        Console.WriteLine(queue.Count);
        foreach (var x in queue)
        {
            Console.WriteLine(x);
        }
        queue.Dequeue();
        Console.WriteLine(queue.Count);


    }
}