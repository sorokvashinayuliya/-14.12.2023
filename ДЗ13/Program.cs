using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace ДЗ13
{
    internal class Program
    {
        static void DoWork1()
        {
            Random random = new Random();
            int number1 = random.Next(1, 11);
            Console.WriteLine(number1);
        }
        static async Task<int> FactorialAsync(int number)
        {
            await Task.Delay(8000);
            int result = 1;
            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }
        static async Task Main()
        {
            Console.WriteLine("Задание 1.Необходимо создать программу, где будет реализовано 3 потока. Каждый из потоков будет выводить на экран числа от 1 до 10.");
            Thread thread1 = new Thread(new ThreadStart(DoWork1));
            Thread thread2 = new Thread(new ThreadStart(DoWork1));
            Thread thread3 = new Thread(new ThreadStart(DoWork1));
            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread1.Join();
            thread2.Join();
            thread3.Join();
            Console.WriteLine("Задание 2.");
            Console.WriteLine("Введите любое целое число");
            int number = int.Parse(Console.ReadLine());
            Task<int> factorialTask = FactorialAsync(number);
            int factorialResult = await factorialTask;
            Console.WriteLine($"Факториал числа {number} равен {factorialResult}");
            int result2 = number * number;
            Console.WriteLine($"Квадрат числа {number} равен {result2}");
            Console.WriteLine("Задание 3.");
            Ref1 newRef1 = new Ref1();
            Type type = newRef1.GetType();
            MethodInfo[] methods = type.GetMethods();
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.Name);
            }
        }
    }
}
