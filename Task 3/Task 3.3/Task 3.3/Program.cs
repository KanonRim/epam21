using System;

namespace Task_3._3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Pizzeria PapaKarlo = new Pizzeria();

            do
            {

                User user = new User(PapaKarlo, "Woloda");
                do
                {
                    Console.WriteLine("Ведите пиццу");
                    var pizza = Console.ReadLine();
                    user.MakeOrder(new Pizza("Mega", 9000));
                } while (true);

            } while (true);

            

        }


    }


}
