using System;
using System.Text;
using System.Threading;

namespace ThreadSample
{
    class Program
    {
        private static object locker = new object();
        static void Function(string text)
        {
            lock (locker)
            {
                Console.WriteLine("ID " + text + " потік: {0}", Thread.CurrentThread.ManagedThreadId);
                Console.ForegroundColor = ConsoleColor.Yellow;

                for (int i = 0; i < 50; i++)
                {
                    Thread.Sleep(20);
                    Console.Write(".");
                }

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(text + " потік завершився.");
            }
        }

        static void Main() // Метод Main - виконується у первинному потоці.
        {
            Console.OutputEncoding = Encoding.Unicode;
            
            Thread thread1 = new Thread(()=>Function("Первинний"));
            thread1.Start();
            Thread thread2 = new Thread(() => Function("Вторинний"));
            thread2.Start();
            Thread thread3 = new Thread(() => Function("Третинний"));
            thread3.Start();

            // Очікування первинного потоку, завершення роботи вторинного потоку.
            //thread.Join(); //TODO Зняти чи встановити коментар.


            // Delay
            Console.ReadKey();
        }
    }
}
