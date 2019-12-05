namespace ScrumPoker
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleWrapper wrapper = new ConsoleWrapper();
            ConsoleProcessor consoleProcessor = new ConsoleProcessor(wrapper);
            consoleProcessor.PopulateData();
            consoleProcessor.CheckPoints();
        }
    }
}
