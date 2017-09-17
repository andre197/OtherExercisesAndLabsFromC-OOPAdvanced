public class Pet : IName, IBirthable
{
    public Pet(string name, string birthdate)
    {
        this.Name = name;
        this.Birthdate = birthdate;
    }

    public string Name { get; protected set; }
    public string Birthdate { get; protected set; }
}

