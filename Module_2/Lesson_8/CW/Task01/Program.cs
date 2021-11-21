using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
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
            return $"Name = {Name} Pocket = {Pocket} ";
        }
    }
    class SnowMaiden : Person
    {
        public SnowMaiden(string name) : base(name) { }
        public override void Receive(string present)
        {
            if (Pocket.Equals(string.Empty))
                Pocket = present;
            else
                throw new ArgumentException(">1 gifts");
        }
        private string CreateString()
        {
            int n = random.Next(4, 11);
            StringBuilder sb = new StringBuilder(n);
            for (int i = 0; i < n; i++)
                sb.Append((char)random.Next('a', 'z' + 1));
            return sb.ToString();
        }
        public string[] CreatePresents(int amount)
        {
            string[] gifts = new string[amount];
            for (int i = 0; i < amount; i++)
                gifts[i] = CreateString();
            return gifts;
        }
    }
    class Santa : Person
    {
        List<string> sack;
        public void Request(SnowMaiden snowMaiden, int amount)
        {
            sack.AddRange(snowMaiden.CreatePresents(amount));
        }
        public Santa(string name) : base(name)
        {
            sack = new List<string>();
        }
        public override void Receive(string present)
        {
            if (Pocket.Equals(string.Empty))
                Pocket = present;
            else
                throw new ArgumentException(">1 gifts");
        }
        public void Give(Person person)
        {
            int n = random.Next(0, sack.Count);
            if (sack.Count > 0)
            {
                person.Receive(sack[n]);
                sack.RemoveAt(n);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
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
                throw new ArgumentException(">2 gifts");
        }
        public override string ToString()
        {
            return $"Name = {Name} Pocket = {Pocket} Pocket2 = {AdditionalPocket}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Santa santa = new Santa("Santa");
            SnowMaiden snowMaiden = new SnowMaiden("SnowMaiden");
            int n = 10;
            List<Person> people = new List<Person>(n + 2);
            people.Add(santa);
            people.Add(snowMaiden);
            for (int i = 2; i < n + 2; i++)
                people[i] = new Child(i.ToString());
            for (int i = 0; i < n + 2; i++)
                Console.WriteLine(people[i].ToString());
            Console.WriteLine("***");
            Random random = new Random();
            for (int i = 0; i < n + 1; i++)
            {
                int prob = random.Next(0, 101);
                if (prob < 10)
                {
                    santa.Give(people[0]);
                }
                else
                {
                    santa.Give(people[i]);
                    santa.Request(snowMaiden, random.Next(1, 5));
                }
            }
        }
    }
}