using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EPAM.AWARDS.ConsolePl
{
    public class ConsoleHelper
    {
        static public int IntReadParse(string message, int min = int.MinValue, int max = int.MaxValue)
        {
            int data;
            bool parse;
            bool range;
            do
            {
                Console.WriteLine(message);
                parse = int.TryParse(Console.ReadLine(), out data);
                range = data >= min && data <= max;

            } while (!parse || !range);
            return data;
        }

        static public DateTime DateReadParse(string message)
        {
            DateTime dateTime;
            do
                Console.WriteLine(message);
            while (!DateTime.TryParse(Console.ReadLine(), out dateTime));
            return dateTime;
        }

        static public string DirectoryReadParse(string message)
        {
            string directory;
            do
            {
                Console.WriteLine(message);
                directory = Console.ReadLine();
            }
            while (!Directory.Exists(directory));
            return Path.GetFullPath(directory);
        }
    }
}
