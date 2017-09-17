using System;

public class Program
{
    public static void Main(string[] args)
    {
        var numbers = Console.ReadLine().Split();
        var urls = Console.ReadLine().Split();

        ICallable call = new Smartphone();
        foreach (var number in numbers)
        {
            Console.WriteLine(call.Call(number));
        }
        IBrowseable browse = new Smartphone();
        foreach (string url in urls)
        {
            Console.WriteLine(browse.Browse(url));
        }
    }
}

