using System;
using System.Collections.Generic;

public class Registrant
{
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public int Age { get; set; }
    public float? Weight { get; set; }
    public List<string>? Skills { get; set; }
    public Dictionary<string, string?> Favs { get; set; }

    public Registrant(string firstName, int age)
    {
        FirstName = firstName;
        Age = age;
        Favs = new Dictionary<string, string?>()
        {
            { "Color", null },
            { "Food", null },
            { "Movie", null }
        };
    }

    public static void PrintRegistrantDetails(Registrant registrant)
    {
        if (registrant == null) return;

        Console.WriteLine("---- Registrant Details ----");
        Console.WriteLine($"First Name: {registrant.FirstName}");
        Console.WriteLine($"Last Name: {registrant.LastName ?? "Doe"}");
        Console.WriteLine($"Age: {registrant.Age}");
        Console.WriteLine($"Weight: {registrant.Weight ?? 0}");

        if (registrant.Skills != null)
        {
            Console.WriteLine("Skills:");
            foreach (var skill in registrant.Skills)
            {
                Console.WriteLine($"- {skill}");
            }
        }

        Console.WriteLine("Favorites:");
        foreach (var kvp in registrant.Favs)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value ?? "Unknown"}");
        }
        Console.WriteLine();
    }
}

public class Program
{
    public static void Main()
    {

        var r1 = new Registrant("Jasmine", 21)
        {
            LastName = "Smith",
            Weight = 55.5f,
            Skills = new List<string> { "C#", "SQL" },
            Favs = new Dictionary<string, string?>
            {
                { "Color", "Blue" },
                { "Food", "Pizza" },
                { "Movie", "Inception" }
            }
        };

        var r2 = new Registrant("Emma", 21);

        Registrant? r3 = null;

        Registrant?[] registrants = new Registrant?[] { r1, r2, r3 };

        foreach (var r in registrants)
        {
            if (r != null)
            {
                Registrant.PrintRegistrantDetails(r);
            }
        }
    }
}


