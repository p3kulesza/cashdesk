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
            Console.WriteLine("Witaj w moim sklepie.");
            while (ans == "0")
            {
                W("Chcesz coś kupić? Czy może trochę się rozejrzeć?");
                W("Pokaż mi swoje towary. (p)");
                W("Chcę coś kupić. (k)");
                ans = Console.ReadLine();
                Console.WriteLine();
                if (!(ans.Equals("p") || ans.Equals("k") || ans.Equals("t") || ans.Equals("n") || ans.Equals("0")))
                {
                    Console.WriteLine("Co? Gadaj do mnie normalnie.");
                    ans = "0";
                }
                if (ans == "p")
                {
                    ShowProducts(cashDesk);
                    ans = "0";
                    Console.WriteLine();
                };
                while ((ans == "k") || (ans == "t"))
                {
                    Console.WriteLine("Podaj mi kod a ja wrzucę produkt do koszyka.");
                    ans = Console.ReadLine();
                    Console.WriteLine();
                    W("Ile tego?");
                    string squantity = Console.ReadLine();
                    int quantity = Convert.ToInt32(squantity);
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

                    ShowCart(cashDesk);

                    Console.WriteLine();
                    W("Podać coś...?");
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
        static void ShowProducts(CashDesk cashDesk)
        {
            foreach (Product s in cashDesk.Items)
            {
                Console.WriteLine($"{s.Name}, {(s.Price + (s.VAT * s.Price)).ToString("0.00")} złoty {s.Unit}. Kod: {s.Barcode}");
            }
        }

        static void ShowCart(CashDesk cashDesk)
        {
            foreach (CartItem a in cashDesk.Cart.cartItems)
            {
                Console.WriteLine($"{a.Product.Name} - {a.Quantity}{a.Product.Unit} ");
            }
        }

        static void ShowReceipt(CashDesk cashDesk)
        {
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
            Console.WriteLine($"Łącznie do zapłaty: {toPay.ToString("0.00")} PLN");
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
