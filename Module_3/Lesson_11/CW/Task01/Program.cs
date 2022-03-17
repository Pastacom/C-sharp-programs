using System;
using System.IO;
using System.Text;

namespace Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var fileStream = new FileStream("out.txt", FileMode.OpenOrCreate))
            {
                if (fileStream.Length < 3)
                {
                    fileStream.Position = fileStream.Length;
                    fileStream.WriteByte((byte)('A' + fileStream.Length));

                }  
            }
            using (var fileStream = new FileStream("out.txt", FileMode.OpenOrCreate))
            {
                for(int i = 0; i < fileStream.Length; i++)
                {
                    Console.Write($"{(char)fileStream.ReadByte()}");
                }
                
            }
        }
    }
}