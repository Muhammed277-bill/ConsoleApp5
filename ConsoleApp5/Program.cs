using System;
using System.Diagnostics;
using System.Media;
using System.Threading;


internal class Program
{
    private static void Main(string[] args)
    {
        
        Thread paint = new Thread(() =>
        {
            while (true)
            {
                Process p = Process.Start("mspaint");
                Thread.Sleep(2000);  
                p.Kill();
                Thread.Sleep(2000);  
            }
        });
        paint.Start();

        Thread musicThread = new Thread(() =>
        {
            while (true)
            {
                SoundPlayer player = new SoundPlayer("music.wav");
                player.PlaySync(); 
            }
        });
        musicThread.IsBackground = true;
        musicThread.Start();

        Thread calculator = new Thread(() =>
        {
            Console.Write("Enter first digit : ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Choose operation (+, -, *, /): ");
            char operation = Convert.ToChar(Console.ReadLine());

            Console.Write("Enter second digit: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            double result = 0;

            switch (operation)
            {
                case '+':
                    result = num1 + num2;
                    break;

                case '-':
                    result = num1 - num2;
                    break;

                case '*':
                    result = num1 * num2;
                    break;

                case '/':
                    if (num2 != 0)
                        result = num1 / num2;
                    else
                        Console.WriteLine("Zero devide!");
                    break;

                default:
                    Console.WriteLine("Wrong operation .");
                    break;
            }

            Console.WriteLine("Result: " + result);
        });
        calculator.Start();

    
    }
}
