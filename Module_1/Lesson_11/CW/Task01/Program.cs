using System;
using System.IO;
using System.Text;

namespace ConsoleApp23
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"Data.txt";

            // Создаем файл с данными
            if (File.Exists(path))
            {
                // Сейчас данные для записи вбиты в коде
                // TODO1: сохранить в файл целые случайные значения из диапазона [10;100)
                int n = int.Parse(Console.ReadLine());
                StringBuilder st = new StringBuilder();
                Random rng = new Random();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < 5; j ++)
                    {
                        st.Append(rng.Next(10, 100) + " ");
                    }
                    st.Append("\n");
                }
                string createText = st.ToString();
                File.WriteAllText(path, createText, Encoding.UTF8);
            }

            // Open the file to read from
            if (File.Exists(path))
            {
                string readText = File.ReadAllText(path);
                string[] stringValues = readText.Split(' ');
                int[] arr = StringArrayToIntArray(stringValues);
                foreach (int i in arr)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
                int[] evenIndex = new int[arr.Length];
                int[] oddIndex = new int[arr.Length];
                for (int i = 0; i < arr.Length; i ++)
                {
                    if(arr[i] % 2 == 0)
                    {
                        evenIndex[i] = i;
                    }
                    else
                    {
                        oddIndex[i] = i;
                    }
                }
                for (int i = 0; i < arr.Length; i ++)
                {
                    if (oddIndex[i] != 0)
                    {
                        arr[oddIndex[i]] = 0;
                    }
                }
                if (arr[0] % 2 == 1)
                {
                    arr[0] = 0;
                }
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write(arr[i] + " ");

                }
                // обрабатываем элементы массива
                // TODO2: Создать два массива по исходному
                // в первый поместить индексы чётных элементов, во второй - нечётных
                // TODO3: Заменяем все нечётные числа исходного массива нулями
            }
        } // end of Main()
        // преобразование массива строк в массив целых чисел
        public static int[] StringArrayToIntArray(string[] str)
        {
            int[] arr = null;
            if (str.Length != 0)
            {
                arr = new int[0];
                foreach (string s in str)
                {
                    int tmp;
                    if (int.TryParse(s, out tmp))
                    {
                        Array.Resize(ref arr, arr.Length + 1);
                        arr[arr.Length - 1] = tmp;
                    }
                } // end of foreach (string s in str)      
            }
            return arr;
        } // end of StringToIntArray()
    } // end of Program
}