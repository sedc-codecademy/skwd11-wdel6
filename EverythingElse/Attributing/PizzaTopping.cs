using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributing
{
    [Flags]
    internal enum PizzaTopping
    {
        None = 0,
        Ham = 1,
        Peperoni = 2,
        Mushroom = 4,
        Bacon = 8,
        Pineapple = 16,
        Olives = 32,
        Cheese = 64
    }

    internal class Pizza
    {
        public Pizza() { }

        public void MakePizza(PizzaTopping topping)
        {
            // does not make a real pizza
            Console.WriteLine(topping);

            //var pizza = new Pizza();
            //pizza.MakePizza((PizzaTopping)99);
            //pizza.MakePizza(PizzaTopping.Ham | PizzaTopping.Peperoni | PizzaTopping.Bacon);
        }
    }
}
