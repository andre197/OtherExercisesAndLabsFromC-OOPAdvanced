using System;
using System.Collections;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        IList<IBirthable> citizens = new List<IBirthable>();

        while (true)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (input[0] == "End")
            {
                break;
            }

            if (input[0] == "Pet")
            {
                citizens.Add(new Pet(input[1], input[2]));
            }
            else if (input[0] == "Citizen")
            {
                citizens.Add(new Citizen(input[1], int.Parse(input[2]), input[3], input[4]));
            }
        }
        
        ValidateIds(citizens);
    }

    private static void ValidateIds(IList<IBirthable> citizens)
    {
        string validator = Console.ReadLine();

        IList<string> birthDates = new List<string>();

        foreach (var citizen in citizens)
        {
            if (citizen.Birthdate.EndsWith(validator))
            {
                birthDates.Add(citizen.Birthdate);
            }
        }

        Print(birthDates);
    }

    private static void Print(IList<string> birthDates)
    {
        if (birthDates.Count==0)
        {
            Console.WriteLine("<empty output>");
        }
        else
        {
            foreach (var birthDate in birthDates)
            {
                Console.WriteLine(birthDate);
            }
        }
    }
}

