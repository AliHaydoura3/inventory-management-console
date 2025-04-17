// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

class Inventory
{
    static List<string> products = new List<string>();
    static List<double> prices = new List<double>();
    static List<int> quantities = new List<int>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n--- Inventory Menu ---");
            Console.WriteLine("1. Add New Product");
            Console.WriteLine("2. View Products");
            Console.WriteLine("3. Restock Product");
            Console.WriteLine("4. Sell Product");
            Console.WriteLine("5. Remove Product");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option (1-6): ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddNewProduct();
                    break;
                case "2":
                    ViewProducts();
                    break;
                case "3":
                    UpdateProduct(true);
                    break;
                case "4":
                    UpdateProduct(false);
                    break;
                case "5":
                    RemoveProduct();
                    break;
                case "6":
                    Console.WriteLine("Exiting program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 6.");
                    break;
            }
        }
    }

    static void AddNewProduct()
    {
        Console.WriteLine("Enter product's name:");
        string name = Console.ReadLine();
        if (products.Contains(name))
        {
            Console.WriteLine("Product already exists.");
            return;
        }

        Console.WriteLine("Enter product's price:");
        if (!double.TryParse(Console.ReadLine(), out double price))
        {
            Console.WriteLine("Invalid price input.");
            return;
        }

        Console.WriteLine("Enter product's quantity:");
        if (!int.TryParse(Console.ReadLine(), out int quantity))
        {
            Console.WriteLine("Invalid quantity input.");
            return;
        }

        products.Add(name);
        prices.Add(price);
        quantities.Add(quantity);
        Console.WriteLine("Product added successfully.");
    }

    static void UpdateProduct(bool flag)
    {
        Console.WriteLine("Enter product's name:");
        string name = Console.ReadLine();
        for (int i = 0; i < products.Count; i++)
        {
            if (products[i] == name)
            {
                Console.WriteLine("Enter quantity to " + (flag ? "restock:" : "sell:"));
                if (!int.TryParse(Console.ReadLine(), out int quantity))
                {
                    Console.WriteLine("Invalid quantity input.");
                    return;
                }

                if (!flag && quantities[i] < quantity)
                {
                    Console.WriteLine("Not enough stock to sell.");
                    return;
                }

                quantities[i] += flag ? quantity : -quantity;
                Console.WriteLine("Stock updated successfully.");
                return;
            }
        }
        Console.WriteLine("Product does not exist.");
    }


    static void ViewProducts()
    {
        if (products.Count == 0)
        {
            Console.WriteLine("No products available.");
            return;
        }

        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"Product {i + 1}: {products[i]} - ${prices[i]:0.00} each, Quantity: {quantities[i]}.");
        }
    }

    static void RemoveProduct()
    {
        Console.WriteLine("Enter product's name:");
        string name = Console.ReadLine();
        for (int i = 0; i < products.Count; i++)
        {
            if (products[i] == name)
            {
                products.RemoveAt(i);
                prices.RemoveAt(i);
                quantities.RemoveAt(i);
                Console.WriteLine("Product removed successfully.");
                return;
            }
        }
        Console.WriteLine("Product does not exist.");
    }
}
