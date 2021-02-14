using System;
using System.Collections.Generic;
using System.Text;

namespace register108200
{
    public class Cart
    {

        public Cart()

        {
            cartItems = new List<CartItem>();
        }

        public List<CartItem> cartItems { get; set; }

        public void AddToCart(Product p, int quantity)

        {
            CartItem item = new CartItem
            {
                Product = p,
                Quantity = quantity
            };
            cartItems.Add(item);

        }
    }
}
