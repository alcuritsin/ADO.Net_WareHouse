﻿// See https://aka.ms/new-console-template for more information

using System;
using System.Globalization;
using LibDB;
using WareHouse_CLI;


var db = new DataBase();
var exit = false;
string menuLevel = "210";

do
{
    CLI.ShowMenu(menuLevel);
    var select = Console.ReadLine();
    if (select != "0")
    {
        // Ноль из любого меню выполняет завершение программы
        select = $"{menuLevel}_{select}";
    }

    switch (select)
    {
        #region Menu 000

        case "000_1": // 000_1 - Модуль 1. Присоединенный режим.
            menuLevel = "100";
            break;
        case "000_2": // 000_2 - Модуль 2. Присоединенный режим.
            menuLevel = "200";
            break;

        #endregion // 000

        #region Menu 100 // Модуль 1.

        case "100_1": // 000_1 - Функциональность из Задания 3
            menuLevel = "130";
            break;

        case "100_2": // 000_2 - Функциональность из Задания 4
            menuLevel = "140";
            break;
        case "100_<":
            menuLevel = "000";
            break;

        #region Menu 130 // Функциональность из Задания 3

        case "130_1": // 130_1. Отображение всей информации о товаре
            db.Open();
            CLI.ShowProducts(db.GetProducts());
            db.Close();
            break;

        case "130_2": // 130_2. Отображение всех типов товаров
            db.Open();
            CLI.ShowTypes(db.GetTypes());
            db.Close();
            break;

        case "130_3": // 130_3. Отображение всех поставщиков
            db.Open();
            CLI.ShowSuppliers(db.GetSuppliers());
            db.Close();
            break;

        case "130_4": // 130_4. Показать товар с максимальным количеством
            db.Open();
            CLI.ShowProduct(db.GetProductMaxQuantity());
            db.Close();
            break;

        case "130_5": // 130_5. Показать товар с минимальным количеством
            db.Open();
            CLI.ShowProduct(db.GetProductMinQuantity());
            db.Close();
            break;

        case "130_6": // 130_6. Показать товар с минимальной себестоимостью
            db.Open();
            CLI.ShowProduct(db.GetProductMinCost());
            db.Close();
            break;

        case "130_7": // 130_7. Показать товар с максимальной себестоимостью
            db.Open();
            CLI.ShowProduct(db.GetProductMaxCost());
            db.Close();
            break;

        #endregion // 130

        #region Menu 140 // Функциональность из Задания 4

        case "140_1": // 140_1 - Показать товары, заданной категории

            db.Open();
            CLI.ShowTypes(db.GetTypes());
            db.Close();

            int type_id = CLI.InputChoice("Введите тип (int): ");

            db.Open();
            CLI.ShowProducts(db.GetProuctFromType(type_id));
            db.Close();
            break;

        case "140_2": // 140_2 Показать товары, заданного поставщика
            db.Open();
            CLI.ShowSuppliers(db.GetSuppliers());
            db.Close();

            int supplier_id = CLI.InputChoice("Введите поставщика (int): ");

            db.Open();
            CLI.ShowProducts(db.GetProuctFromSupplier(supplier_id));
            db.Close();

            break;

        case "140_3": // 140_3 - Показать самый старый товар на складе
            db.Open();
            CLI.ShowProduct(db.GetProductOld());
            db.Close();
            break;

        case "140_4": // 140_4 - Показать среднее количество товаров по каждому типу товара
            db.Open();
            CLI.OutTabl(db.GetProductAvgQuantity());
            db.Close();
            break;

        #endregion //140

        case "130_<": // 130_< - Назад
        case "140_<": // 040_< - Назад
            menuLevel = "100";
            break;

        #endregion // 100

        #region Munu 200 // Модуль 2. Присоединенный режим.

        case "200_1": 
            menuLevel = "210";
            break;
        case "200_2":
            menuLevel = "220";
            break;
        case "200_3":
            menuLevel = "230";
            break;
        case "200_4":
            menuLevel = "240";
            break;
        case "200_<":
            menuLevel = "000";
            break;

        #region Menu 210

        case "210_1": // Вставка новых товаров
            InsertNewProduct();
            break;
        case "210_2": // Вставка новых типов товаров
            break;
        case "210_3": // Вставка новых поставщиков
            break;

        #endregion // 210

        #region Menu 220
        
        case "220_1": // Обновление информации о существующих товарах
            break;
        case "220_2": // Обновление информации о существующих поставщиках
            break;
        case "220_3": // Обновление информации о существующих типах товаров
            break;
        
        #endregion // 220

        #region Menu 230
        
        case "230_1": // Удаление товаров
            break;
        case "230_2": // Удаление поставщиков
            break;
        case "230_3": // Удаление типов товаров
            break;

        #endregion // 230

        #region Menu 240
        
        case "240_1": // Показать информацию о поставщике с наибольшим количеством товаров на складе
            break;
        case "240_2": // Показать информацию о поставщике с наименьшим количеством товаров на складе
            break;
        case "240_3": // Показать информацию о типе товаров с наибольшим количеством товаров на складе
            break;
        case "240_4": // Показать информацию о типе товаров с наименьшим количеством товаров на складе
            break;
        case "240_5": // Показать товары с поставки, которых прошло заданное количество дней
            break;

        #endregion // 240

        case "210_<": // 210_< - Назад
        case "220_<": // 220_< - Назад
        case "230_<": // 230_< - Назад
        case "240_<": // 240_< - Назад
            menuLevel = "200";
            break;

        #endregion // 200

        case "0": // 0. Выход
            exit = true;
            break;
        default:
            break;
    }
} while (!exit);

CLI.SayGoodBy();

void InsertNewProduct()
{
    Product product = new Product();
            
    CLI.ShowMessage(":: Добавить новый продукт в БД ::");
    product.ProductName = CLI.InputString("Введите наименование: ");
    
    CLI.ShowMessage("Выбор типа продукта...");
    db.Open();
    CLI.ShowTypes(db.GetTypes());
    db.Close();
    product.ProductTypeId = CLI.InputChoice("Тип продукта (int): ");
    db.Open();
    product.ProducType = db.GetTypeNameById(product.ProductTypeId);
    db.Close();
    
    CLI.ShowMessage("Выбор поставщика...");
    db.Open();
    CLI.ShowSuppliers(db.GetSuppliers());
    db.Close();
    product.ProductSupplierId = CLI.InputChoice("Поставщик продукта (int): ");
    db.Open();
    product.ProducSupplier = db.GetSupplierNameById(product.ProductSupplierId);
    db.Close();

    product.ProductQuantity = Convert.ToDouble(CLI.InputString("Введите количество (double coma): "));
    product.ProductCost = Convert.ToDouble(CLI.InputString("Введите себестоимость (double coma): "));

    product.DeliveryDate = Convert.ToDateTime(CLI.InputString("Введите дату поставки (dd.mm.yyyy): "));

    db.Open();
    CLI.ShowMessage($"Добавлено {db.InsertNewProduct(product)} строк.");
    db.Close();
    
}