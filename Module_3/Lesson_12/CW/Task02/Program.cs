using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using System.Text;

[Serializable]
public class Human
{
    public string Name { get; set; }
    public Human() { }
    public Human(string name)
    {
        Name = name;
    }
}

[Serializable]
public class Professor : Human
{
    public Professor() { }
    public Professor(string name) : base(name) { }
}

[Serializable]
public class Department
{
    static int _counter = 1;
    public Department() { }
    public string Name { get; set; }
    public List<Human> Staff { get; set; }
    public Department(string name)
    {
        Name = name;
        Staff = new List<Human>(){ new Human(_counter.ToString()), new Human((_counter + 1).ToString()), new Human((_counter + 2).ToString())};
        _counter += 3;
    }
    public override string ToString()
    {
        StringBuilder str = new();
        str.Append($"Department {Name}:\n");
        foreach (var human in Staff)
        {
            str.Append($"Professor {human.Name}\n");
        }
        return str.ToString();
    }
}

[Serializable]
public class University
{
    public string Name { get; set; }
    public List<Department> Departments { get; set; }
    public University() { }
    public University(string name, List<Department> departments)
    {
        Name = name;
        Departments = departments;
    }
    public override string ToString()
    {
        StringBuilder str = new();
        str.Append($"University {Name}:\n");
        foreach(var department in Departments)
        {
            str.Append(department.ToString());
        }
        return str.ToString();

    }

}
class Program
{
    static void Main()
    {
        List<University> universities = new List<University>()
        {
        new University("MSU", new List<Department>(){ new Department("A"), new Department("B") }),
        new University("HSE", new List<Department>(){ new Department("C"), new Department("D") })
        };

        BinaryFormatter formatter = new();
        using (FileStream file = new FileStream("out3.txt", FileMode.OpenOrCreate))
        {
            formatter.Serialize(file, universities);
        }
        using (FileStream file = new FileStream("out3.txt", FileMode.OpenOrCreate))
        {
            List<University> res = (List<University>)formatter.Deserialize(file);
            foreach (var university in res)
            {
                Console.WriteLine(university);
            }
        }
        Console.WriteLine("\n\n\n");


        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<University>));
        using (FileStream file = new FileStream("out4.txt", FileMode.OpenOrCreate))
        {
            xmlSerializer.Serialize(file, universities);
        }
        using (FileStream file = new FileStream("out4.txt", FileMode.OpenOrCreate))
        {
            List<University> res = (List<University>)xmlSerializer.Deserialize(file);
            foreach (var university in res)
            {
                Console.WriteLine(university);
            }
        }
        Console.WriteLine("\n\n\n");


        {
            string json = JsonSerializer.Serialize<List<University>>(universities);
            List<University> res = JsonSerializer.Deserialize<List<University>>(json);
            foreach (var university in res)
            {
                Console.WriteLine(university);
            }
        }

    }
}
