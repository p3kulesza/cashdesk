using System;
using System.Collections.Generic;
using System.Text;

namespace register108200
{
    public class CashDesk
    {

        public CashDesk()
        {
            CreateProducts();
            Cart = new Cart();
        }

        public List<Product> Items { get; set; }

        public Cart Cart { get; set; }

        public void AddToCart(Product p, int quantity)
        {
            Cart.AddToCart(p, quantity);
        }

        public void CreateProducts()
        {
            Items = new List<Product>();

            Product p = new Product
            {
                Name = "Kompot z jaszczura",
                Unit = "l",
                Price = 5,
                VAT = 8,
                Barcode = "0001"
            };
            Items.Add(p);

            Product o = new Product
            {
                Name = "Pierogi z węża",
                Unit = "kg",
                Price = 6,
                VAT = 8,
                Barcode = "0010"
            };
            Items.Add(o);

            Product i = new Product
            {
                Name = "Kanapka z wilka",
                Unit = "szt",
                Price = 8,
                VAT = 8,
                Barcode = "0011"
            };
            Items.Add(i);

        }

    }
}
