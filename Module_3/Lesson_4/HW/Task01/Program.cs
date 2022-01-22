using System;


public class RingIsFoundEventArgs : EventArgs
{
    public RingIsFoundEventArgs(string s) { Message = s; }
    public string Message { get; set; }
}

public abstract class Creature
{
    public abstract string Name { get; set; }
    public abstract string Location { get; set; }
    public virtual void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e) { }
}

public class Wizard : Creature
{
    public override string Name { get; set; }
    public override string Location { get; set; }
    public Wizard(string name, string location)
    {
        Name = name;
        Location = location;
    }

    public new delegate void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e);

    public event RingIsFoundEventHandler RaiseRingIsFoundEvent;

    public void SomeThisIsChangedInTheAir()
    {
        Console.WriteLine($"{Name} >> Кольцо найдено у старого Бильбо! Призываю вас в Ривендейл!");
        RaiseRingIsFoundEvent(this, new("Ривендейл"));
    }
}

public class Hobbit : Creature
{
    public override string Name { get; set; }
    public override string Location { get; set; }
    public Hobbit(string name, string location)
    {
        Name = name;
        Location = location;
    }
    public override void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
    {
        Console.WriteLine($"{Name} >> Текущее местоположение: {Location}. Покидаю Шир! Иду в {e.Message}");
        Location = e.Message;
    }
}

public class Human : Creature
{
    public override string Name { get; set; }
    public override string Location { get; set; }
    public Human(string name, string location)
    {
        Name = name;
        Location = location;
    }
    public override void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
    {
        Console.WriteLine($"{Name} >> Текущее местоположение: {Location}. Волшебник {((Wizard)(sender)).Name} позвал. Моя цель {e.Message}");
        Location = e.Message;
    }
}

public class Elf : Creature
{
    public override string Name { get; set; }
    public override string Location { get; set; }
    public Elf(string name, string location)
    {
        Name = name;
        Location = location;
    }
    public override void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
    {
        Console.WriteLine($"{Name} >> Текущее местоположение: {Location}. Звезды светят не так ярко как обычно. Цветы увядают. Листья предсказывают идти в {e.Message}");
        Location = e.Message;
    }
}

public class Dwarf : Creature
{
    public override string Name { get; set; }
    public override string Location { get; set; }
    public Dwarf(string name, string location)
    {
        Name = name;
        Location = location;
    }
    public override void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
    {
        Console.WriteLine($"{Name} >> Текущее местоположение: {Location}. Точим топоры, собираем припасы! Выдвигаемся в {e.Message}");
        Location = e.Message;
    }
}

class Program
{
    static void Main()
    {
        Wizard wizard = new("Гендальф", "1");
        Creature[] creatures =
        {
                new Hobbit("Перегрин", "2"),
                new Hobbit("Фродо", "3"),
                new Hobbit("Сэм", "4"),
                new Hobbit("Мэрри", "5"),
                new Human("Боромир", "6"),
                new Human("Арагорн", "7"),
                new Dwarf("Гимли", "8"),
                new Elf("Леголас", "9")
        };
        foreach (var creature in creatures)
        {
            wizard.RaiseRingIsFoundEvent += creature.RingIsFoundEventHandler;
        }
        wizard.SomeThisIsChangedInTheAir();
    }
}
