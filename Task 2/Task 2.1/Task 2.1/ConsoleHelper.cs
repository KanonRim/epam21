﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._1
{
    public class ConsoleHelper
    {
        static public int IntReadParse(string Mess,int min,int max)
        {
            int data;
            bool parse;
            bool range;
            do
            {
                Console.WriteLine(Mess);
                parse = int.TryParse(Console.ReadLine(), out data);
                range = data>=min && data<=max;

            } while  (!parse || !range);
            return data;
        }
    }
}
