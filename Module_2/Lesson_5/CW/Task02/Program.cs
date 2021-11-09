using System;

abstract class Animal
{
    public Animal(string name, int age)
    {
        Nickname = name; Age = age;
    }
    public string Nickname  {get;}
    public int Age { get;}
    public abstract string AnimalSound();
    public abstract string AnimalInfo();
}
class Dog : Animal
{
    public string Breed{ get;}
    public bool IsTrained{ get;}
    public Dog(string name, int age, string breed, bool istrained) : base(name, age)
    {
        Breed = breed;
        IsTrained = istrained;
    }
    public override string AnimalSound()
    {
        return "Woof!";
    }
    public override string AnimalInfo()
    {
        return $"Animal = {GetType().Name}, Name = {Nickname}, Age = {Age}, Breed = {Breed}, IsTrained = {IsTrained}";
    }
}
class Cow : Animal
{
    public int Milk { get;}
    public Cow(string name, int age, int milk) : base(name, age)
    {
        Milk = milk;
    }
    public override string AnimalSound()
    {
        return "Moo!";
    }
    public override string AnimalInfo()
    {
        return $"Animal = {GetType().Name}, Name = {Nickname}, Age = {Age}, Milk per day = {Milk} L";
    }
}
class Program
{
    static void Main(string[] args)
    {
        Animal dog = new Dog("doge", 5, "shiba inu", true);
        Animal cow = new Cow("MooMoo", 9, 5);
        Console.WriteLine(dog.AnimalInfo());
        Console.WriteLine(cow.AnimalInfo());
    }
}
