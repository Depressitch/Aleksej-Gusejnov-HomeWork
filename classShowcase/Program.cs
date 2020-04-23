using System;
using System.Collections.Generic;
using System.Linq;

namespace classShowcase
{
    class Program
    {
        static void Main()
        {
            Product productOne = new Product(22.2m);
            Product productTwo = new Product(13.8m);
            Product productThree = new Product(2.0m);
            Purchase purchase = new Purchase(productOne, productTwo, productThree);
            purchase.Print();
            Order order = new Order(5m, 16m, 8m);
            order.Print();
            order += productThree;
            order.Print();
            order -= productTwo;
            order.Print();
            order -= productThree;
            order.Print();
            order.Discount = 0.12m;
            order += purchase;
            order.Print();
            Console.ReadKey();
        }
    }
    public class Product
    {
        public decimal Price { get; set; }
        public Product(decimal price)
        {
            Price = price;
        }
    }
    public class Purchase
    {
        protected List<Product> Goods { get; set; } = new List<Product>();
        public Purchase(params Product[] products)
        {
            foreach (var product in products)
                Goods.Add(product);
        } //инициализация с товарами через запятую
        public Purchase(params decimal[] prices)
        {
            foreach (var price in prices)
                Goods.Add(new Product(price));
        } //инициализация с ценами за товар через запятую
        public virtual decimal GetTotalPrice()
        {
            return Goods.Sum(item => item.Price);
        }
        public virtual void Print()
        {
            byte i = 1;
            foreach (var product in this.Goods)
            {
                Console.WriteLine($"{i++}. {product.Price}");
            }
            Console.WriteLine($"Total:  {GetTotalPrice()}");
        }
        public static Purchase operator -(Purchase purchase, Product product)
        {
            purchase.Goods.Remove(product);
            return purchase;
        }
        public static Purchase operator +(Purchase purchase, Product product)
        {
            purchase.Goods.Add(product);
            return purchase;
        }
        public IEnumerator<Product> GetEnumerator()
        {
            foreach (var product in Goods)
                yield return product;
        }
    }
    public class Order : Purchase
    {
        public decimal Discount { get; set; } = 0; //к заказам может применяться скидка, например купоном
        public Order(params Product[] products) : base(products){}
        public Order(params decimal[] prices) : base(prices){}
        public override decimal GetTotalPrice()
        {
            return Goods.Sum(item => item.Price) * (1 - Discount);
        }
        public override void Print()
        {
            byte i = 1;
            foreach (var product in this.Goods)
            {
                Console.WriteLine($"{i++}. {product.Price} - {Discount*100}% = {product.Price * (1 - Discount)}");
            }
            Console.WriteLine($"Total:  {GetTotalPrice()}");
        }
        public static Order operator -(Order order, Product product)
        {
            order.Goods.Remove(product);
            return order;
        }
        public static Order operator +(Order order, Product product)
        {
            order.Goods.Add(product);
            return order;
        }
        public static Order operator +(Order orderOne, Order orderTwo) //объединение двух заказов
        {
            foreach (var product in orderTwo)
            {
                orderOne.Goods.Add(product);
            }
            return orderOne;
        }
        public static Order operator +(Order order, Purchase purchase) //объединение заказа и покупки
        {
            foreach (var product in purchase)
            {
                order.Goods.Add(product);
            }
            return order;
        }
    }
}
