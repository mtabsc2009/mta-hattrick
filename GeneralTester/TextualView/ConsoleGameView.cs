using System;

namespace TextualView
{
    public class ConsoleGameView : IGameView
    {
        public void Print(string i_String)
        {
            Console.Write(i_String);
        }

        public void PrintLine(string i_String)
        {
            Console.WriteLine(i_String);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
