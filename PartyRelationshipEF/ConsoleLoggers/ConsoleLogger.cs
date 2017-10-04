using System;

namespace PartyRelationshipEF.ConsoleLoggers
{
    public static class ConsoleLogger
    {

        public static void Log(string message, ConsoleColor messageColor)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = messageColor;
            Console.WriteLine(message);
            Console.ForegroundColor = color;
        }
    }
}
