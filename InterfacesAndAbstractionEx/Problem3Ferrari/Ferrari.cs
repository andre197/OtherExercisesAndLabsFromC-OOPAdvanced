public class Ferrari : ICar
{
    private string model = "488-Spider";

    public string PushBreaks()
    {
        return "Brakes!";
    }

    public string PushGas()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return this.model + "/" + PushBreaks() + "/" + PushGas() + "/";
    }
}

