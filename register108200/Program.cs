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
                Console.WriteLine();

                if (ans == "1")
                {
                    foreach (Product s in cashDesk.Items)
                    {
                        // Console.WriteLine("{0} {1} {2} {3} {4}", s.Name, s.Price, s.Price, s.Price, s.Price);
                        Console.WriteLine($"{s.Name}, {s.Price} złoty {s.Unit}. Kod: {s.Barcode}");
                    }
                    ans = "0";
                };

                while ((ans == "2") || (ans == "t"))
                {
                    //Console.WriteLine();
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
                        Console.WriteLine($"{a.Product.Name} - {a.Quantity}{a.Product.Unit} ");
                    }
                    Console.WriteLine();
                    W("Bierzesz coś jeszcze...?");
                    W("Tak! (t)");
                    W("Nie, już mi styknie. Ile się należy? (n)");
                    ans = Console.ReadLine();
                    Console.WriteLine();

                };

                while (ans == "n")
                {
                    ShowReceipt(cashDesk);
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

        static void ShowReceipt(CashDesk cashDesk)
        {
            //Wyświetlanie paragonu
            Console.WriteLine("--------------------");
            Console.WriteLine();
            Console.WriteLine("Data sprzedaży: "); Console.WriteLine(DateTime.Now.ToString("M/d/yyyy"));
            Console.WriteLine();
            Console.WriteLine("--------------------");
            double toPay = 0;
            foreach (CartItem a in cashDesk.Cart.cartItems)
            {
                Console.WriteLine($"{a.Product.Name} - {a.Quantity}{a.Product.Unit} ");
                toPay += (a.Product.VAT * a.Product.Price * a.Quantity) + (a.Product.Price * a.Quantity);
            }

            double vat8 = 0;
            double vat23 = 0;
            foreach (CartItem a in cashDesk.Cart.cartItems)
            {
                if (a.Product.VAT.Equals(0.08))
                    vat8 += a.Product.VAT * a.Product.Price * a.Quantity;
                if (a.Product.VAT.Equals(0.23))
                    vat23 += a.Product.VAT * a.Product.Price * a.Quantity;
            }
            Console.WriteLine("--------------------");
            Console.WriteLine();
            Console.WriteLine($"Łącznie do zapłaty: {toPay.ToString("0.00")}");
            Console.WriteLine();
            Console.WriteLine("W tym VAT: ");
            Console.WriteLine();
            Console.WriteLine($"VAT 8 : {vat8.ToString("0.00")}");
            Console.WriteLine($"VAT 23 : {vat23.ToString("0.00")}");
            Console.WriteLine();
            Console.WriteLine("--------------------");
            Console.ReadLine();
        }

    }
}
