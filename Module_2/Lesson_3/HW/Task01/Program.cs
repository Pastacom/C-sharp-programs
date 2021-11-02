using System;
using System.Text;
class VideoFile
{
    private string string_name;
    private int int_duration;
    private int int_quality;
    public string Name { get { return string_name; } private set { string_name = value; } }
    public int Duration { get { return int_duration; } private set { int_duration = value; } }
    public int Quality { get { return int_quality; } private set { int_quality = value; } }
    public VideoFile(string name, int duration, int quality)
    {
        Name = name; Duration = duration; Quality = quality;
    }
    private int Size { get { return Duration * Quality; } }
    public string GetInfo()
    {
        return $"{Name}({Duration}c, {Quality}х{Quality}, {Size}КБ)";
    }
    public void CompareFiles(ref VideoFile[] my_array)
    {
        foreach (VideoFile file in my_array)
        {
            if (file.Size > Size)
            {
                Console.WriteLine(file.GetInfo());
            }
        }
    }
}
class Program
{
    static string GenerateName()
    {
        Random rng = new Random();
        StringBuilder str = new StringBuilder();
        for (int i = 0; i < rng.Next(2, 10); i++)
        {
            str.Append((char)rng.Next('a', 'z' + 1));
        }
        return str.ToString();
    }
    static void Main()
    {
        int option;
        Random rng = new Random();
        VideoFile[] files = new VideoFile[rng.Next(5, 16)];
        for (int i = 0; i < files.Length; i++)
        {
            files[i] = new VideoFile(GenerateName(), rng.Next(60, 361), rng.Next(100, 1001));
            Console.WriteLine($"Создан файл: {files[i].GetInfo()}");
        }
        do
        {
            do
            {
                Console.Write("Введите номер файла: ");
            } while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > files.Length);
            files[option-1].CompareFiles(ref files);
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
}
