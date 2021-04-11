using System;

namespace Task_3._3
{
    class User
    {
        private string _name;
        private Pizzeria pizzeria;

        public User(Pizzeria pizzeria,string name)
        {
            this.pizzeria = pizzeria;
            _name = name;
        }

        public string NameUser { get => _name;}



        public void MakeOrder(Pizza pizza)
        {
            pizzeria.MakeOrder(pizza).OnReady += PizaReady;
        }
        void PizaReady(Order order)
        {
            Console.WriteLine($"{NameUser} ваша пицца {order.Pizza.NamePizza} готова") ;
        }
    }


}
