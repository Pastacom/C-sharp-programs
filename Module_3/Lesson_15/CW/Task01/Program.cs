using System;
using System.Threading;
namespace Workspace
{
    class BankAccount
    {
        private object thisLock = new object();
        volatile int accountAmount;
        Random r = new Random();
        public BankAccount(int sum)
        {
            accountAmount = sum;
        }
        int Buy(int sum)
        {
            if (accountAmount == 0)
                throw new InvalidOperationException($"Нулевой баланс...");
            // условие никогда не выполнится, пока вы не закомментируете lock.  
            if (accountAmount < 0)
                throw new InvalidOperationException($"Отрицательный баланс");
            bool flag = false;
            Monitor.Enter(thisLock, ref flag);
            if (accountAmount >= sum)
            {
                Console.WriteLine($"Состояние счета: {accountAmount}");
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - Покупка на сумму: {sum}");
                accountAmount = accountAmount - sum;
                Console.WriteLine($" Счет после пок.: {accountAmount}");
                if (flag)
                {
                    Monitor.Exit(thisLock);
                }
                return sum;
            }
            else
            {
                return 0;
            }

        }
        public void DoTransactions()
        {
            try
            {
                while (true)
                {
                    Buy(r.Next(1, 50));
                    Thread.Sleep(r.Next(1, 10));
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Обработано исключение: {ex.Message}. Поток завершает работу...");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Thread[] threads = new Thread[10];
            BankAccount dep = new BankAccount(1000);
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(dep.DoTransactions);
            }
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Start();
            }
        }

    }
}