using System;

namespace ScrumPoker
{
    public class ConsoleWrapper : IConsoleWrapper
    {
        public string Read()
        {
            return Console.ReadLine();
        }

        public int ReadInt()
        {
            try
            {
                return Int32.Parse(Read());
            }
            catch (FormatException e)
            {
                Write("Entered value is not valid. Please enter valid value:" + e.Message);
                return ReadInt();
            }
        }

        public void Write(string value)
        {
            Console.WriteLine(value);
        }
    }
}
