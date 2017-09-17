public class Smartphone : ICallable,IBrowseable
{
    


    public string Call(string number)
    {
        for (int i = 0; i < number.Length; i++)
        {
            if (char.IsLetter(number[0]))
            {
                return "Invalid number!";
            }
        }
        return "Calling... " + number;
    }

    public string Browse(string url)
    {
        foreach (char c in url)
        {
            if (char.IsDigit(c))
            {
                return "Invalid URL!";
            }
        }
        return "Browsing: " + url + "!";
    }
    
}

