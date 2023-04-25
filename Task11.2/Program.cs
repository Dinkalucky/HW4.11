using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task11._2
{
    internal class Program
    {
        static string outputText;
        private static object locker = new object();
        public static void FileReader(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                outputText = reader.ReadToEnd();
            }
        }
        public static void FileWriter(string text)
        {
            lock (locker)
            {
                using (StreamWriter writer = new StreamWriter(@"File3.txt", true))
                {
                    writer.WriteLine(text);
                }
            }
            
        }

        static void Main(string[] args)
        {
            Thread thread1 = new Thread(() => FileReader(@"File1.txt"));
            thread1.Start();
            Thread.Sleep(500);
            thread1 = new Thread(() => FileWriter(outputText));
            thread1.Start();
            

            Thread thread2 = new Thread(() => FileReader(@"File2.txt"));
            thread2.Start();
            Thread.Sleep(500);
            thread2 = new Thread(() => FileWriter(outputText));
            thread2.Start();
            Console.WriteLine("Запис завершено");
            Console.ReadLine();
        }
    }
}
