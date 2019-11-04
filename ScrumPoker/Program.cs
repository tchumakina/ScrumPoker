using System;

namespace ScrumPoker
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleProcessor consoleProcessor = new ConsoleProcessor();
            consoleProcessor.Voiting();
            consoleProcessor.PrintAll();
        }
    }
}
