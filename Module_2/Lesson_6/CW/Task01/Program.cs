using System;
using System.Runtime.Serialization;
namespace Task01
{
    class MyLovelyException : Exception
    {
        public MyLovelyException()
        {
        }
        public MyLovelyException(string message) : base(message)
        {
        }
        public MyLovelyException(string message, Exception innerException) : base(message, innerException)
        {
        }
        protected MyLovelyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                try { }
                catch { }
                //int[] a = new int[1];
                //a[10]++;
                throw new MyLovelyException("12132");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("finally");
            }
        }
    }
}