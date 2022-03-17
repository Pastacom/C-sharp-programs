using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

[Serializable]
public class Student
{
    public Student(){ }
    public Student(string surname, int year)
    {
        Surname = surname;
        Year = year;
    }
    public string Surname { get; set; }
    public int Year { get; set; }

    public override string ToString()
    {
        return $"{Surname}, {Year} ";
    }
}

[Serializable]
public class Group
{
    public Group(){ }
    public Group(int id, List<Student> students)
    {
        Students = students;
        Id = id;
    }
    public List<Student> Students { get; set; }
    public int Id { get; set; }

    public override string ToString()
    {
        string str = "";
        foreach (var student in Students)
        {
            str += student.ToString();
        }
        return str;
    }
}
class Program
{
    static void Main()
    {
        
        Group group1 = new(219, new List<Student>() { new Student("a", 1), new Student("b", 1) });
        Group group2 = new(128, new List<Student>() { new Student("c", 3), new Student("d", 3) });
        Group[] groups = { group1, group2 };
        BinaryFormatter formatter = new();
        using (FileStream file = new FileStream("out1.txt", FileMode.OpenOrCreate))
        {
            formatter.Serialize(file, groups);
        }
        using (FileStream file = new FileStream("out1.txt", FileMode.OpenOrCreate))
        {
            Group[] res = (Group[])formatter.Deserialize(file);
            foreach(Group group in res)
            {
                Console.WriteLine(group.Id);
                Console.WriteLine(group);
            }
        }
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Group[]));
        using (FileStream file = new FileStream("out2.txt", FileMode.OpenOrCreate))
        {
            xmlSerializer.Serialize(file, groups);
        }
        using (FileStream file = new FileStream("out2.txt", FileMode.OpenOrCreate))
        {
            Group[] res = (Group[])xmlSerializer.Deserialize(file);
            foreach (Group group in res)
            {
                Console.WriteLine(group.Id);
                Console.WriteLine(group);
            }
        }
        {
            string json = JsonSerializer.Serialize<Group[]>(groups);
            Group[] res = JsonSerializer.Deserialize<Group[]>(json);
            foreach (Group group in res)
            {
                Console.WriteLine(group.Id);
                Console.WriteLine(group);
            }
        }
    }
}
