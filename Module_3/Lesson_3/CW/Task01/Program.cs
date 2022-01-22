using System;
namespace Task
{
    public delegate void AccountDelegate(string str);
    class Account
    {
        public event AccountDelegate Notify;
        public int Sum { get; set; }
        public Account(int sum) => Sum = sum;
        public void Take(int sum)
        {
            Sum -= sum;
            Notify?.Invoke("Take " + sum);
        }
        public void Put(int sum)
        {
            Sum += sum;
            Notify?.Invoke("Put " + sum);
        }
    }
    class Program
    {
        public static void Print(string str)
        {
            Console.WriteLine(str);
        }
        public static void Print2(string str)
        {
            Console.WriteLine("!!!" + str);
        }
        public static void Main()
        {
            Account account = new Account(1000);
            account.Notify += Print;
            account.Notify += Print2;
            account.Take(100);
            Console.WriteLine(account.Sum);
            account.Take(100);
            Console.WriteLine(account.Sum);
            account.Put(100);
            Console.WriteLine(account.Sum);
        }
    }
}