using System;
using System.Collections.Generic;

public interface IRun
{
    string Run();
}

public interface IJump
{
    string Jump();
}

abstract class Animal: IComparable<Animal>
{
    public int Age { get; private set; }
    protected Animal(int age)
    {
        Age = age;
    }
    public int CompareTo(Animal animal)
    {
        if (Age > animal.Age)
            return 1;
        else
            return -1;
    }
}

class Cockroach: Animal, IRun
{
    public int Speed { get; private set; }
    public Cockroach(int age, int speed) : base(age) { Speed = speed; }
    public string Run()
    {
        return $"Таракан бегает со скоростью {Speed} км/ч";
    }
    public override string ToString()
    {
        return $"Таракан: Возраст = {Age}, Скорость = {Speed}";
    }
}

class CockroachComparer : IComparer<Cockroach>
{
    public int Compare(Cockroach a, Cockroach b)
    {
        if (a.Speed > b.Speed)
            return 1;
        else
            return -1;
    }
}

class Kangaroo: Animal, IJump
{
    public int Length { get; private set; }
    public Kangaroo(int age, int length) : base(age) { Length = length; }
    public string Jump()
    {
        return $"Кенгуру прыгает на {Length} метров";
    }
    public override string ToString()
    {
        return $"Кенгуру: Возраст = {Age}, Дальность прыжка = {Length}";
    }
}

class KangarooComparer : IComparer<Kangaroo>
{
    public int Compare(Kangaroo a, Kangaroo b)
    {
        if (a.Length > b.Length)
            return 1;
        else
            return -1;
    }
}

class Cheetah: Animal, IRun, IJump
{
    public int Speed { get; private set; }
    public int Length { get; private set; }
    public Cheetah(int age, int speed, int length) : base(age) { (Speed, Length) = (speed, length); }
    public string Run()
    {
        return $"Гепард бегает со скоростью {Speed} км/ч";
    }
    public string Jump()
    {
        return $"Гепард прыгает на {Length} метров";
    }
    public override string ToString()
    {
        return $"Гепард: Возраст = {Age}, Скорость = {Speed}, Дальность прыжка = {Length}";
    }
}

class Program
{   
    static void Main()
    {
        Random rng = new();
        List<Animal> animals = new();
        List<IRun> runners = new();
        List<IJump> jumpers = new();
        List<Cockroach> cockroaches = new();
        List<Kangaroo> kangaroos = new();
        for (int i = 0; i < 20; i++)
        {
            int option = rng.Next(3);
            int firstNum = rng.Next(11, 50);
            int secondNum = rng.Next(1, 10);
            int thirdNum = rng.Next(1, 10);
            switch (option)
            {              
                case 0:
                    Cockroach cockroach = new (firstNum, secondNum);
                    animals.Add(cockroach);
                    runners.Add(cockroach);
                    cockroaches.Add(cockroach);
                    Console.WriteLine(cockroach);
                    break;
                case 1:
                    Kangaroo kangaroo = new (firstNum, secondNum);
                    animals.Add(kangaroo);
                    jumpers.Add(kangaroo);
                    kangaroos.Add(kangaroo);
                    Console.WriteLine(kangaroo);
                    break;
                case 2:
                    Cheetah cheetah = new (firstNum, secondNum, thirdNum);
                    animals.Add(cheetah);
                    runners.Add(cheetah);
                    jumpers.Add(cheetah);
                    Console.WriteLine(cheetah);
                    break;
            }
        }
        Console.WriteLine("\n\n");
        foreach (var jumper in jumpers)
        {
            Console.WriteLine($"{jumper.Jump()}, ");
        }
        Console.WriteLine();

        foreach (var runner in runners)
        {
            Console.WriteLine($"{runner.Run()}, ");
        }
        Console.WriteLine();

        animals.Sort((a, b) => a.CompareTo(b));
        foreach (Animal animal in animals)
        {
            Console.WriteLine($"{animal}, ");
        }
        Console.WriteLine("\n\n");

        foreach (Cockroach cockroach in cockroaches)
        {
            Console.WriteLine($"{cockroach}, ");
        }
        Console.WriteLine();
        cockroaches.Sort(new CockroachComparer());
        foreach (Cockroach cockroach in cockroaches)
        {
            Console.WriteLine($"{cockroach}, ");
        }
        Console.WriteLine("\n\n");

        foreach (Kangaroo kangaroo in kangaroos)
        {
            Console.WriteLine($"{kangaroo}, ");
        }
        Console.WriteLine();
        kangaroos.Sort(new KangarooComparer());
        foreach (Kangaroo kangaroo in kangaroos)
        {
            Console.WriteLine($"{kangaroo}, ");
        }
    }
}