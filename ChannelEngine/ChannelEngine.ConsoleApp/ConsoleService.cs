using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelEngine.ConsoleApp
{
    public class ConsoleService: IConsoleService
    {
        public void Display(string value)
        {
            Console.WriteLine(value);
        }

        public void ReadKey()
        {
            Console.ReadKey();
        }
    }
}
