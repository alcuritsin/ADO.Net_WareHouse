using System;
using System.Collections.Generic;
using LibDB;

namespace WareHouse_CLI
{
    public static class CLI
    {
        // Вывод информации в консоль
        public static void ShowMenu()
        {
            // Меню приложнения
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("::  База Данных: Продукты  ::");
            Console.WriteLine("Выберите режим работы:");
            Console.WriteLine("1. Отображение всей информации о товарах\n" +
                              "2. Отображение всех типов товаров\n" +
                              "3. Отображение всех поставщиков\n" +
                              "4. Показать товар с максимальным количеством\n" +
                              "5. Показать товар с минимальным количеством\n" +
                              "6. Показать товар с минимальной себестоимостью\n" +
                              "7. Показать товар с максимальной себестоимостью");
            Console.WriteLine("0. Выход");
            Console.ResetColor();
        }
        
        public static void ShowProducts(List<Product> products)
        {
            Console.WriteLine("Отображение всей информации о товарах:");
            foreach (Product product in products)
            {
                ShowProduct(product);
            }
            Console.WriteLine("--- --- --- --- ---");
        }

        public static void ShowProduct(Product product)
        {
            Console.WriteLine("*** *** *** *** ***");
            Console.WriteLine($"           id: {product.Id}\n" +
                              $"         Name: {product.ProductName}\n" +
                              $"         Type: {product.ProducType}\n" +
                              $"     Supplier: {product.ProducSupplier}\n" +
                              $"     Quantity: {product.ProductQuantity}\n" +
                              $"         Cost: {product.ProductCost}\n" +
                              $"Date delivery: {product.DeliveryDate}");
        }

        public static void SayGoodBy()
        {
            // Сказать досвидания
            
            Console.WriteLine();
            Console.WriteLine("Программа завершена.");
            Console.ReadKey();
        }
    }
}