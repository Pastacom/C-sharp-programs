using System;
class Program
    {
        static void Main()
        {
            float sm1 = 0; float sm2 = -1; int counter = 1;
            while (sm1 > sm2)
            {
                sm2 = sm1;
                sm1 += 1.0f / (counter * (counter + 1) * (counter + 2));
                counter += 1;
            }
            Console.WriteLine($"Float {sm1}");


            double sm3 = 0; double sm4 = -1;
            counter = 1;
            while (sm3 > sm4)
            {
                sm4 = sm3;
                sm3 += 1.0 / (counter * (counter + 1) * (counter + 2));
                counter += 1;
            }
            Console.WriteLine($"Double {sm3}");
        }
    }
