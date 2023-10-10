using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Labb2Kladd3
{
    internal class Store
    {
        public List<Product> Products { get; set; }
        private List<Customer> Customers { get; set; }


        public Store()
        {
            Products = new List<Product>
            {
                new Product("Hot Dog", 5),
                new Product("Drink", 5),
                new Product("Apple", 3)
            };

            Customers = new List<Customer>
            {
                new Customer("Knatte", "123"),
                new Customer("Fnatte", "321"),
                new Customer("Tjatte", "213")
            };
        }

        public void SignUp(string name, string password)
        {
            Customers.Add(new Customer(name, password));
            Console.WriteLine($"{name} was registered as a new customer.");
            Console.ReadKey();
        }

        public Customer SignIn(string name, string password)
        {
            Customer customer = Customers.Find(k => k.Name == name);
            if (customer == null)
            {
                Console.WriteLine("The customer does not exist. If you would like to register new customer, press enter.");
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
                    SignUp(name, password);
                }
            } 
            else if (!customer.PasswordVerification(password))
            {
                Console.WriteLine("Incorrect password. Please try again.");
                customer = null;
                Console.ReadKey();
            }

            return customer;
        }

        public void DisplayProducts()
        {
            Console.WriteLine("Products on sale");
            foreach (var product in Products)
            {
                Console.WriteLine($"{product.Name} - {product.Price} kr");
            }
        }
    }
}
