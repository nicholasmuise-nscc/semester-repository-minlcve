using System;

public class Person

{
    public string publicName;

    private int privateAge;

    private string _email;

    public string GetEmail() => _email;
    public void SetEmail(string value) => _email = value;

    public string City { get; set; }

    private string _country;
    public string Country
    {
        get { return _country; }
        set { _country = value.ToUpper(); }

    }

    private string _nickname;
    public string Nickname
    {
        get => _nickname;
        set => _nickname = value;
    }

    public Person()
    {
        publicName = "Unknown";
        privateAge = 0;
        _email = "none@example.com";
        City = "Nowhere";
        Country = "None";
        Nickname = "N/A";

    }

    public Person(string name, int age, string email, string city, string country, string nickname)
    {
        publicName = name;
        privateAge = age;
        _email = email;
        City = city;
        Country = country;
        Nickname = nickname;
    }

}

public class Employee : Person
{
    public string JobTitle { get; set; }

    public Employee(String name, int age, string email, string city, string country, string nickname, string jobTitle)
        : base(name, age, email, city, country, nickname)
    {
        JobTitle = jobTitle;
    }

    public Employee() : this("Alice", 30, "alice@example.com", "Toronto", "Canada", "Ali", "Software Developer")
    {

    }

}

class Program
{
    static void Main()
    {
        Person person = new Person("Bob", 25, "bob@example.com", "Vancouver", "Canada", "Bobby");
        Console.WriteLine("Person info:");
        Console.WriteLine($"Name: {person.publicName}");
        Console.WriteLine($"Email: {person.GetEmail()}");
        Console.WriteLine($"City: {person.City}");
        Console.WriteLine($"Country: {person.Country}");
        Console.WriteLine($"Nickname: {person.Nickname}");

        Employee emp = new Employee();
        Console.WriteLine("\nEmployee info:");
        Console.WriteLine($"Name: {emp.publicName}");
        Console.WriteLine($"Email: {emp.GetEmail()}");
        Console.WriteLine($"City: {emp.City}");
        Console.WriteLine($"Country: {emp.Country}");
        Console.WriteLine($"Nickname: {emp.Nickname}");
        Console.WriteLine($"Job Title: {emp.JobTitle}");
    }

}
