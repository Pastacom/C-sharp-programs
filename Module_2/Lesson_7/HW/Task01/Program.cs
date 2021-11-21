using System;

class Creature
{
    public string Name { get; }
    public double Speed { get; }

    public Creature(string name, double speed)
    {
        Name = name; Speed = speed;
    }

    public virtual string Run()
    {
        return $"I am running with a speed of {Math.Round(Speed, 2)}. ";
    }

    public override string ToString()
    {
        return Run() + $"My name is {Name}.";
    }
}

class Dwarf : Creature
{
    Random rng = new Random();
    private int _strength;
    public int Strength
    {
        get
        {
            return _strength;
        }
        set
        {
            if (0 < value && value < 21)
            {
                _strength = value;
            }
            else
            {
                _strength = rng.Next(1, 21);
            }
        }
    }

    public Dwarf(string name, double speed, int strength) : base(name, speed)
    {
        Strength = strength;
    }

    public override string Run()
    {
        return base.Run() + $"My strength is {Strength}. ";
    }
    public static string MakeNewStaff()
    {
        return "I've created a new staff!";
    }
}
class Elf : Creature
{
    Random rng = new Random();
    private int _age;
    public int Age
    {
        get
        {
            return _age;
        }
        set
        {
            _age = value;
        }
    }
    public double ElfSpeed { get; }

    public Elf(string name, double speed) : base(name, speed)
    {
        Age = rng.Next(100, 201);
        ElfSpeed = Speed + Age / 77;
    }

    public override string Run()
    {
        return $"I am running with a speed of {Math.Round(ElfSpeed, 2)}. My age is {Age}. ";
    }
}
class Program
{
    static Random rng = new Random();
    static void Main()
    {

        do
        {
            int n;
            do
            {
                Console.Write("Введите число существ: ");
            } while (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 100);
            Creature[] creatures = new Creature[n];
            for (int i = 0; i < n; i++)
            {
                int chance = rng.Next(0, 10);
                if (chance <= 1)
                {
                    creatures[i] = new Creature(GenerateName(), GenerateSpeed());
                }
                else if (chance <= 5)
                {
                    creatures[i] = new Dwarf(GenerateName(), GenerateSpeed(), rng.Next(-50, 51));
                }
                else
                {
                    creatures[i] = new Elf(GenerateName(), GenerateSpeed());
                }
            }
            foreach (Creature creature in creatures)
            {
                Console.WriteLine(creature);
                if (creature is Dwarf)
                {
                    Console.WriteLine(Dwarf.MakeNewStaff());
                }
            }
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
    static double GenerateSpeed()
    {
        double speed = rng.Next(11, 19) - rng.NextDouble() - 0.001;
        return speed;
    }
    static string GenerateName()
    {
        int length = rng.Next(2, 15);
        string name = "";
        name += (char)rng.Next('A', 'Z' + 1);
        for (int i = 0; i < length; i++)
        {
            switch(rng.Next(0, 2))
            {
                case 0:
                    name += (char)rng.Next('A', 'Z' + 1);
                    break;
                case 1:
                    name += (char)rng.Next('a', 'z' + 1);
                    break;
            }
        }
        return name;
    }
}
