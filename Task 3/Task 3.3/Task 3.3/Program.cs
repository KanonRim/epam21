using System;

namespace Task_3._3
{
    class Program
    {
        static void Main(string[] args)
        {
            //testig code 
            Pizzeria PapaKarlo = new Pizzeria();
            
            do
            {
                Console.WriteLine("Ведите имя");
                var userName = Console.ReadLine();
                User user = new User(PapaKarlo, userName);
                do
                {
                    Console.WriteLine("Ведите пиццу");
                    var pizza = Console.ReadLine();
                    if (pizza.Length < 1)
                        continue;
                    int timeCocing = new Random().Next(1000, 9000);
                    Console.WriteLine("ваша пица будет готовиться "+timeCocing/1000+"секунд");
                    user.MakeOrder(new Pizza(pizza, timeCocing));
                    break;
                } while (true);

            } while (true);

            

        }


    }


}
