using System;
using System.Collections.Generic;

public class CoffeeMachine
{
    private int amount;
    private List<CoffeeType> boughtCoffees;

    public CoffeeMachine()
    {
        this.boughtCoffees = new List<CoffeeType>();
    }

    public IEnumerable<CoffeeType> CoffeesSold => this.boughtCoffees;

    public void BuyCoffee(string size, string type)
    {
        var price = (CoffeePrice)Enum.Parse(typeof(CoffeePrice), size);
        if (this.amount>(int)price)
        {
            this.amount = 0;
            this.boughtCoffees.Add((CoffeeType)Enum.Parse(typeof(CoffeeType), type));
        }
    }

    public	void InsertCoin(string coin)
    {
        Coin c = (Coin)Enum.Parse(typeof(Coin), coin);
        this.amount += (int)c;

    }

}

