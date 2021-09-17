using System;
using System.Collections.Generic;
using LibDB;

namespace WareHouse_CLI
{
    public static class CLI
    {
        // Вывод информации в консоль
        public static void ShowMenu(string menuLevel)
        {
            // Меню приложнения
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("::  База Данных: Продукты  ::");
            Console.WriteLine("Выберите режим работы:");
            

            switch (menuLevel)
            {
                case "000":
                    Console.WriteLine("1 - Функциональность из Задания 3\n" +
                                      "2 - Функциональность из Задания 4");
                    break;
                case "030":
                    Console.WriteLine("1 - Отображение всей информации о товарах\n" +
                                      "2 - Отображение всех типов товаров\n" +
                                      "3 - Отображение всех поставщиков\n" +
                                      "4 - Показать товар с максимальным количеством\n" +
                                      "5 - Показать товар с минимальным количеством\n" +
                                      "6 - Показать товар с минимальной себестоимостью\n" +
                                      "7 - Показать товар с максимальной себестоимостью\n" +
                                      "< - Назад");
                    break;
                case "040":
                    Console.WriteLine("1 - Показать товары, заданной категории\n" +
                                      "2 - Показать товары, заданного поставщика\n" +
                                      "3 - Показать самый старый товар на складе\n" +
                                      "4 - Показать среднее количество товаров по каждому типу товара\n"+
                                      "< - Назад");
                    break;
            }
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

        public static void ShowTypes(List<ProductType> productTypes)
        {
            Console.WriteLine("Отображение всех типов товаров:");
            foreach (ProductType productType in productTypes)
            {
                ShowType(productType);
            }

            Console.WriteLine("--- --- --- --- ---");
        }

        public static void ShowType(ProductType productType)
        {
            Console.WriteLine("*** *** *** *** ***");
            Console.WriteLine($"      id: {productType.Id}\n" +
                              $"TypeName: {productType.TypeName}");
        }

        public static void ShowSuppliers(List<ProductSupplier> productSuppliers)
        {
            Console.WriteLine("Отображение всех поставщиков:");
            foreach (ProductSupplier productSupplier in productSuppliers)
            {
                ShowSupplier(productSupplier);
            }

            Console.WriteLine("--- --- --- --- ---");
        }

        public static void ShowSupplier(ProductSupplier productSupplier)
        {
            Console.WriteLine("*** *** *** *** ***");
            Console.WriteLine($"      id: {productSupplier.Id}\n" +
                              $"TypeName: {productSupplier.SupplierName}");
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