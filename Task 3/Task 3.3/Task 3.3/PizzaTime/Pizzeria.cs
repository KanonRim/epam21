using System;
using System.Collections.Generic;

namespace Task_3._3
{
    class Pizzeria
    {
        Queue<Order> orders = new Queue<Order>();
        int freeStove = 1;
        public Order MakeOrder(Pizza pizza)
        {
            var order = new Order(pizza);
            order.OnReady += RemoveOrder;
            orders.Enqueue(order);
            if (freeStove == 1)
            {
                orders.Dequeue().StartCocing();
                freeStove -= 1;
            }
            

            return order;
        }

        void RemoveOrder(Order order)
        { 
            
            if (orders.Count > 0)
            {
                orders.Dequeue().StartCocing();
            }
            else
            {
                freeStove = 1;
            }
                      
        }
    }
}
