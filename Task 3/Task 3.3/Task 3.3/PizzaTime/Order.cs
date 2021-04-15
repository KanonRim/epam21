using System;
using System.Threading;

namespace Task_3._3
{
    class Order
    {
        Pizza pizza;
        Thread tread;

       
        public Pizza Pizza { get => pizza;}

        public event Action<Order> OnReady;
        public Order(Pizza pizza)
        {
            this.pizza = pizza;  
            tread = new Thread(Cocing);    
        }
        public void StartCocing()
        {
            tread.Start();
        }
        void Cocing()
        {
            Thread.Sleep(Pizza.CocingTime);
            OnReady.Invoke(this);
        }


    }
}
