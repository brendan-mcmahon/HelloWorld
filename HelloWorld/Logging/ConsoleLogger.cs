using System;

namespace HelloWorld.Logging
{
    internal class ConsoleLogger : ILogger
    {
        public void Write(string @string)
        {
            Console.WriteLine(@string);
        }
    }
}
