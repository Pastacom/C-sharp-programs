using System;

class Plant
{
    private double _growth;
    private double _photosensitivity;
    private double _frostresistance;

    public double Growth
    {
        get
        {
            return _growth;
        }
        set
        {
            _growth = value;
        }
    }

    public double Photosensitivity
    {
        get
        {
            return _photosensitivity;
        }
        set
        {
            _photosensitivity = Math.Max(Math.Min(value, 100), 0);
        }
    }

    public double Frostresistance
    {
        get
        {
            return _frostresistance;
        }
        set
        {
            _frostresistance = Math.Max(Math.Min(value, 100), 0);
        }
    }
        
    public string Name{ get; }
    
    public Plant(string name, double growth, double photosensitivity, double frostresistance)
    {
        Name = name;
        Growth = growth;
        Photosensitivity = photosensitivity;
        Frostresistance = frostresistance;
    }

    public override string ToString()
    {
        return $"Plant {Name}: growth = {Growth:F3}, photosensitivity = {Photosensitivity:F3}, frostresistance = {Frostresistance:F3}";
    }
}

class Program
{
    static Random rng = new();
    public static string GenerateName()
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

    public static Plant GeneratePlant()  
    {
        return new(GenerateName(), rng.Next(25, 100) + rng.NextDouble(),
        rng.Next(0, 100) + rng.NextDouble(), rng.Next(0, 80) + rng.NextDouble());
    }

    public static int Comparator(Plant plant1, Plant plant2)
    {
        if ((int)plant1.Photosensitivity % 2 != 0 && (int)plant2.Photosensitivity % 2 == 0)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }

    static void Main()
    {
        int n;
        do
        {
            Console.Write("Введите число растений: ");
        } while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);
        Plant[] plants = new Plant[n];
        for (int i = 0; i < n; i++)
        {
            plants[i] = GeneratePlant();
        }
        Action<Plant> print = x => Console.WriteLine(x);
        Array.ForEach(plants, print);
        Console.WriteLine("\n*****************\n");
        Comparison<Plant> firstSort = delegate (Plant plant1, Plant plant2)
        {
            if (plant1.Growth < plant2.Growth)
            {
                return 1;
            }
            else 
            {
                return -1;
            }

        };
        Array.Sort(plants, firstSort);
        Array.ForEach(plants, print);
        Console.WriteLine("\n*****************\n");
        Array.Sort(plants, (plant1, plant2) => plant1.Frostresistance < plant2.Frostresistance ? -1 : 1);
        Array.ForEach(plants, print);
        Console.WriteLine("\n*****************\n");
        Array.Sort(plants, Comparator);
        Array.ForEach(plants, print);
        Console.WriteLine("\n*****************\n");
        Array.ConvertAll(plants, plant => plant.Frostresistance = (int)plant.Frostresistance % 2 == 0 ?
        plant.Frostresistance / 3 : plant.Frostresistance / 2);
        Array.ForEach(plants, print);

    }
}
