using System;
namespace sem
{
    public record Person
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public void Deconstruct(out string name, out int id) => (name, id) = (Name, Id);
    }
    //public record Person2(string Name, int Age);
    //public class User : IEquatable<User>
    //{
    //    // Свойства
    //    public int Id { get; init; }
    //    public string Name { get; init; }
    //    // Тип записи. Используется для сравнения и вычисления хеш-кода.
    //    private Type EqualityContract => typeof(User);
    //    // Параметризированный конструктор
    //    public User(int id, string name)
    //    {
    //        Id = id;
    //        Name = name;
    //    }
    //    // Деконструктор
    //    public void Deconstruct(out int Id, out string Name) { … }
    //    // Реализация IEquatable<T>
    //    public bool Equals(User? other) { … }
    //    // Методы
    //    public override bool Equals(object? obj) { … }
    //    public override int GetHashCode() { … }
    //    public override string ToString() { … }
    //    // Операции сравнения
    //    public static bool operator ==(User a, User b) => a.Equals(b);
    //    public static bool operator !=(User a, User b) => !a.Equals(b);
    //    // Конструктор копирования
    //    protected User(User original) { … }
    //    // Поддержка выражения with
    //    public virtual User<Clone>$() => new User(this);
    //}
    class MainClass
    {
        public static void Main(string[] args)
        {
            Person person = new Person() { Name = "Tom", Id = 20 };
            var person2 = person with { Id = 200 };
            var (name, id) = person;
            Console.WriteLine(name); // Tom
            Console.WriteLine(id);   // 20
        }
    }
}