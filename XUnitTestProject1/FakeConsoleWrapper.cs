using Xunit.Abstractions;

namespace ScrumPoker
{
    public class FakeConsoleWrapper : IConsoleWrapper
    {
        public ITestOutputHelper Output { set; get; }

        public string Read()
        {
            return "Fake value";
        }

        public int ReadInt()
        {
            return 1;
        }

        public void Write(string value)
        {
            Output.WriteLine(value);
        }
    }
}
