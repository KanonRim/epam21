using System;
using System.Collections.Generic;

namespace Task3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<string> testARR = new DynamicArray<string>();
            testARR.Add("Testirovanie");

            testARR.Add("12334"); 
            testARR.Add("WAAAAGH");
            testARR.Add("zerg"); 
            Console.WriteLine(String.Join(' ', testARR));

            testARR.Remove("12334"); 
            Console.WriteLine(String.Join(' ', testARR));

            string[] add = { "ziva", "menu", "ez_control" };
            DynamicArray<string> test = new DynamicArray<string>(add);
            testARR.AddRange(test);
            Console.WriteLine(String.Join(' ', testARR)); 

            for (int i = 0; i < 100; i++)
            {
                testARR.Add(i.ToString());
                Console.WriteLine($"{testARR.Capacity} {testARR.Lenght}");
            }


        }
       
    }
}
