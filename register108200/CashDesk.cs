using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

            // ustalamy ścieżkę do pliku pytania.json
            string productsDir = $"{Directory.GetCurrentDirectory()}\\products.json";

            // czytamy (program czyta) zawartość pliku pytania.json i zapisuje cały tekst pliku w zmiennej tekstPliku
            string fileTxt = File.ReadAllText(productsDir);

            // zamieniamy tekst pliku na listę pytań (List<Pytanie>)
            Items = JsonConvert.DeserializeObject<List<Product>>(fileTxt);

        }

    }
}
