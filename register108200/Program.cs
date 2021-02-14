using System;
using System.Collections.Generic;
using System.Linq;

namespace register108200
{
    class Program
    {
        static void Main(string[] args)
        {
            string ans = "0";
            CashDesk cashDesk = new CashDesk();
            Cart cart = new Cart();
            //string barcode = "0001";
            // Product p = cashDesk.Items.FirstOrDefault(x => x.Barcode == barcode);
            



            while (ans == "0")
            {
                Console.WriteLine();
                W("Witaj w moim sklepie. Chcesz coś kupić? Czy może najpierw trochę się rozejrzeć?");
                W("1. Pokaż mi swoje towary.");
                W("2. Chcę coś kupić.");
                ans = Console.ReadLine();

                if (ans == "1")
                {

                    foreach (Product s in cashDesk.Items)
                    {
                        // Console.WriteLine("{0} {1} {2} {3} {4}", s.Name, s.Price, s.Price, s.Price, s.Price);
                        Console.WriteLine($"{s.Name}, {s.Price} złoty {s.Unit}. Kod: {s.Barcode}");

                    }
                    ans = "0";
                };

                while (ans == "2")
                {
                    Console.WriteLine();
                    W("Podaj mi kod a ja wrzucę produkt do koszyka.");
                    ans = Console.ReadLine();
                    Console.WriteLine();
                    W("Ile tego?");
                    
                    string squantity = Console.ReadLine();
                    int quantity = Convert.ToInt32(squantity);
                    //Console.WriteLine(quantity);
                    
                    Product p = cashDesk.Items.FirstOrDefault(x => x.Barcode == ans);
                    if (p != null)
                    {
                        cashDesk.AddToCart(p, quantity);
                    }
                    else
                    {
                        W("Nie mam nic takiego!");
                    }
                    Console.WriteLine();
                    W("W twoim koszyku jest: ");
                    Console.WriteLine();

                    foreach (CartItem a in cashDesk.Cart.cartItems)
                    {
                        // Console.WriteLine("{0} {1} {2} {3} {4}", s.Name, s.Price, s.Price, s.Price, s.Price);
                        Console.WriteLine($"{a.Product.Name} - {a.Quantity}{a.Product.Unit} ");
                    }

                    W("Bierzesz coś jeszcze...?");
                    W("2. Tak.");
                    W("0. Nie, już mi styknie.");
                    ans = Console.ReadLine();
                    Console.WriteLine();

                };
            };
  
        }


        static void W(string tekst)
        {
            Console.WriteLine(tekst);
        }

        static void WP(string tekst)
        {
            Console.WriteLine();
            Console.WriteLine(tekst);
        }

    }
}
