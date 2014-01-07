using System;
using System.Threading;
using Kata.App.Infastructure;
using Kata.ConsoleClient.Engine;

namespace Kata.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = IoCConfiguration.BuildContainer();
            var runner = container.GetInstance<GameOfLifeRunner>();

            while(true)
            {
                Console.Clear();
                Console.Write(runner.PerformCycleOfLife());
                Thread.Sleep(300);
            }
        }
    }
}
