using System;

namespace ScrumPoker
{
    public interface IConsoleWrapper
    {
        void Write(String value);
        string Read();
        int ReadInt();
    }
}
