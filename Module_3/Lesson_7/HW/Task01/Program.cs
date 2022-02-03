using System;

struct Person : IComparable<Person>
{
    private readonly string name, lastname;
    private readonly int age;
    public Person(string name, string lastname, string input)
    {
        if(!int.TryParse(input, out int age) || age < 0)
        {
            throw new ArgumentOutOfRangeException("Неверное значение возраста.");
        }
        else
        {
            (this.name, this.lastname, this.age) = (name, lastname, age);
        }
    }
    public int CompareTo(Person person)
    {
        if (age > person.age)
            return 1;
        else
            return -1;
    }
    public override string ToString()
    {
        return $"{name} {lastname} ({age} years old)";
    }
}


class Program
{
    private static Random rng = new();
    private static string GenerateName()
    {
        int length = rng.Next(3, 10);
        string name = "";
        name += (char)rng.Next('A', 'Z' + 1);
        for (int i = 0; i < length; i++)
        {
            name += (char)rng.Next('a', 'z' + 1);
        }
        return name;
    }

    private static Person GeneratePerson()
    {
        return new Person(GenerateName(), GenerateName(), rng.Next(1, 101).ToString());
    }

    static void Main()
    {
        int n;
        do
        {
            Console.Write("Введите число людей: ");
        } while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);
        Person[] characters = new Person[n];
        for (int i = 0; i < n; i++)
        {
            characters[i] = GeneratePerson();
        }

        foreach (var person in characters)
        {
            Console.WriteLine(person);
        }
        Console.WriteLine("\n\n");

        Array.Sort(characters);
        foreach (var person in characters)
        {
            Console.WriteLine(person);
        }
    }
}
