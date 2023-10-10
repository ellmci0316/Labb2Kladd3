using System.Security.Cryptography.X509Certificates;

namespace Labb2Kladd3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the awesome store!");
            StartMenu();
        }

        static void StartMenu()
        {
            Store store = new Store();

            string[] menuOptions = new string[] { "Sign up", "Sign in", "Exit" };
            int menuSelect = 0;

            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;

                if (menuSelect == 0)
                {
                    Console.WriteLine(menuOptions[0] + "**");
                    Console.WriteLine(menuOptions[1]);
                    Console.WriteLine(menuOptions[2]);
                }

                else if (menuSelect == 1)
                {
                    Console.WriteLine(menuOptions[0]);
                    Console.WriteLine(menuOptions[1] + "**");
                    Console.WriteLine(menuOptions[2]);
                }

                else if (menuSelect == 2)
                {
                    Console.WriteLine(menuOptions[0]);
                    Console.WriteLine(menuOptions[1]);
                    Console.WriteLine(menuOptions[2] + "**");
                }

                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.DownArrow && menuSelect != menuOptions.Length - 1)
                {
                    menuSelect++;
                }

                if (key.Key == ConsoleKey.UpArrow && menuSelect >= 1)
                {
                    menuSelect--;
                }

                if (key.Key == ConsoleKey.Enter)
                {
                    switch (menuSelect)
                    {
                        case 0:
                            Console.Write("Enter customer name: ");
                            string newName = Console.ReadLine();
                            Console.Write("Enter password: ");
                            string newPassword = Console.ReadLine();
                            store.SignUp(newName, newPassword);
                            break;

                        case 1:
                            Console.Write("Enter name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter password: ");
                            string password = Console.ReadLine();
                            Customer signedInCustomer = store.SignIn(name, password);

                            if (signedInCustomer != null)
                            {
                                CustomerMenu(signedInCustomer, store);
                            }
                            break;

                        case 2:
                            Environment.Exit(0);
                            break;
                    }


                }


            }
        }

        static void CustomerMenu(Customer customer, Store store)
        {

            while (true)
            {

                string[] menuOptions = new string[] { "Shop", "Show cart", "Go to checkout", "Log out" };
                int menuSelect = 0;

                while (true)
                {
                    Console.Clear();
                    Console.CursorVisible = false;
                    Console.WriteLine($"Welcome {customer.Name}!");

                    if (menuSelect == 0)
                    {
                        Console.WriteLine(menuOptions[0] + "**");
                        Console.WriteLine(menuOptions[1]);
                        Console.WriteLine(menuOptions[2]);
                        Console.WriteLine(menuOptions[3]);
                    }

                    else if (menuSelect == 1)
                    {
                        Console.WriteLine(menuOptions[0]);
                        Console.WriteLine(menuOptions[1] + "**");
                        Console.WriteLine(menuOptions[2]);
                        Console.WriteLine(menuOptions[3]);
                    }

                    else if (menuSelect == 2)
                    {
                        Console.WriteLine(menuOptions[0]);
                        Console.WriteLine(menuOptions[1]);
                        Console.WriteLine(menuOptions[2] + "**");
                        Console.WriteLine(menuOptions[3]);
                    }

                    else if (menuSelect == 3)
                    {
                        Console.WriteLine(menuOptions[0]);
                        Console.WriteLine(menuOptions[1]);
                        Console.WriteLine(menuOptions[2]);
                        Console.WriteLine(menuOptions[3] + "**");
                    }

                    var key = Console.ReadKey();

                    if (key.Key == ConsoleKey.DownArrow && menuSelect != menuOptions.Length - 1)
                    {
                        menuSelect++;
                    }

                    if (key.Key == ConsoleKey.UpArrow && menuSelect >= 1)
                    {
                        menuSelect--;
                    }

                    if (key.Key == ConsoleKey.Enter)
                    {
                        switch (menuSelect)
                        {
                            case 0:
                                while (true)
                                {
                                    Console.Clear();
                                    store.DisplayProducts();
                                    Console.WriteLine($"Choose your product");
                                    Console.WriteLine("Type 'go back' to go back");
                                    string productName = Console.ReadLine();
                                    Product selectedProduct = store.Products.Find(p => p.Name == productName);


                                    if (selectedProduct != null)
                                    {
                                        customer.AddProduct(selectedProduct);
                                        Console.WriteLine($"{productName} added to {customer.Name}'s cart.");
                                        Console.ReadKey();
                                    }

                                    else if (productName == "go back")
                                    {
                                        break;
                                    }

                                    else
                                    {
                                        Console.WriteLine("Invalid product");
                                        Console.ReadKey();
                                    }
                                    
                                }
                                break;

                            case 1:
                                customer.ShowCart();
                                Console.ReadKey();
                                break;

                            case 2:
                                customer.ShowCart();
                                Console.WriteLine(customer.CalculateTotalCost());
                                Console.ReadKey();

                                Console.WriteLine("Thank you come again!");
                                Console.ReadKey();
                                Environment.Exit(0);
                                break;

                            case 3:
                                StartMenu();
                                break;

                        }
                    }
                }

            }

        }

    }
}