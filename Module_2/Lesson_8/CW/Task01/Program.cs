using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;
namespace Task01
{
    abstract class Person
    {
        public static Random random = new Random();
        public string Name { get; set; }
        public string Pocket { get; set; }
        public abstract void Receive(string present);
        public Person(string name)
        {
            Name = name;
            Pocket = string.Empty;
        }
        public override string ToString()
        {
            return $"Name = {Name}, Pocket = {Pocket}";
        }
    }
    class SnowMaiden : Person
    {
        public SnowMaiden(string name) : base(name) { }
        private string CreateName()
        {
            StringBuilder str = new();
            for (int i = 0; i < 3; i++)
            {
                str.Append((char)random.Next('a', 'z' + 1));
            }
            return str.ToString() + str[1] + str[0];
        }
        public string[] CreatePresent(int amount)
        {
            string[] gifts = new string[amount];
            for (int i = 0; i < amount; i++)
            {
                gifts[i] = CreateName();
            }
            return gifts;
        }
        public override void Receive(string present)
        {
            if (Pocket.Equals(string.Empty))
                Pocket = present;
            else
                throw new ArgumentException(">1 gifts");
        }
    }
    class Santa : Person
    {
        List<string> sack;
        public void Request(SnowMaiden snowMaiden, int amount)
        {
            sack.AddRange(snowMaiden.CreatePresent(amount));
        }
        public Santa(string name) : base(name)
        {
            sack = new List<string>();
        }
        public void Give(Person person)
        {
            Console.WriteLine("Sack:" + sack.Count);
            if (sack.Count > 0)
            {
                int n = random.Next(0, sack.Count);
                person.Receive(sack[n]);
                sack.RemoveAt(n);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public override void Receive(string present)
        {
            if (Pocket.Equals(string.Empty))
                Pocket = present;
            else
                throw new ArgumentException(">1 gifts");
        }
    }
    class Child : Person
    {
        public string AdditionalPocket { get; set; }
        public Child(string name) : base(name)
        {
            AdditionalPocket = string.Empty;
        }
        public override void Receive(string present)
        {
            if (Pocket.Equals(string.Empty))
                Pocket = present;
            else if (AdditionalPocket.Equals(string.Empty))
                AdditionalPocket = present;
            else
                throw new ArgumentException(">1 gifts");
        }
        public override string ToString()
        {
            return base.ToString() + $", AdditionalPocket = {AdditionalPocket}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Santa santa = new Santa("Santa");
                SnowMaiden snowMaiden = new SnowMaiden("SnowMaiden");
                Random random = new Random();
                List<Person> people = new List<Person>();
                people.Add(santa);
                people.Add(snowMaiden);
                int n = 10;
                for (int i = 0; i < n; i++)
                    people.Add(new Child(i.ToString()));
                for (int i = 0; i < n + 2; i++)
                    Console.WriteLine(people[i]);
                Console.WriteLine("***");
                santa.Request(snowMaiden, 1);
                while (people.Contains(santa) && people.Count > 1)
                {
                    int prob = random.Next(0, 101);
                    if (prob < 10)
                    {
                        try
                        {
                            santa.Give(people[0]);
                            Console.WriteLine(people[0]);
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Кончились подарки!");
                            break;
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine(people[0]);
                            people.RemoveAt(0);
                            Console.WriteLine("Нельзя больше брать подарки!");
                            Console.WriteLine("Санту выгнали.");
                            continue;
                        }
                    }
                    else
                    {
                        int index = random.Next(1, people.Count);
                        try
                        {
                            santa.Give(people[index]);
                            Console.WriteLine(people[index]);
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Кончились подарки!");
                            break;
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine(people[index]);
                            Console.WriteLine("Нельзя больше брать подарки!");
                            Console.WriteLine($"{people[index].Name} выгнали.");
                            people.RemoveAt(index);
                            continue;
                        }
                    }
                    if (people.Contains(snowMaiden))
                    {
                        santa.Request(snowMaiden, random.Next(1, 5));
                    }
                }
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

        }
    }
}