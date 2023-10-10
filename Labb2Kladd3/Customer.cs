using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2Kladd3
{
    internal class Customer
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public List<Product> Cart { get; set; }

        public Customer(string name, string password) 
        {
            Name = name;
            Password = password;
            Cart = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            Cart.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            Cart.Remove(product);
        }

        public void ShowCart()
        {
            Console.Clear();
            string customerInfo = ToString();
            Console.WriteLine(customerInfo);

            foreach (var product  in Cart)
            {
                Console.WriteLine($"{product.Name} - {product.Price} kr");
            }
            Console.WriteLine($"Total cost: {CalculateTotalCost()}");
        }

        public double CalculateTotalCost()
        {
            double totalCost = 0;
            foreach (var product in Cart)
            {
                totalCost += product.Price;
            }
            return totalCost;
        }

        public bool PasswordVerification(string password)
        {
            return Password == password;
        }

        public override string ToString()
        {
            string maskedPassword = new string('*', Password.Length);
            return $"Customer: {Name}\nPassword: {maskedPassword}\n";
        }

    }
}
