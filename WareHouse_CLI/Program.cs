// See https://aka.ms/new-console-template for more information

using System;
using LibDB;
using WareHouse_CLI;


var db = new DataBase();
var exit = false;
string menuLevel = "000";

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
        case "000_1": // 000_1 - Функциональность из Задания 3
            menuLevel = "030";
            break;
        
        case "000_2": // 000_2 - Функциональность из Задания 4
            menuLevel = "040";
            break;
        case "030_1": // 030_1. Отображение всей информации о товаре
            db.Open();
            CLI.ShowProducts(db.GetProducts());
            db.Close();
            break;

        case "030_2": // 030_2. Отображение всех типов товаров
            db.Open();
            CLI.ShowTypes(db.GetTypes());
            db.Close();
            break;

        case "030_3": // 030_3. Отображение всех поставщиков
            db.Open();
            CLI.ShowSuppliers(db.GetSuppliers());
            db.Close();
            break;
        
        case "030_4": // 030_4. Показать товар с максимальным количеством
            db.Open();
            CLI.ShowProduct(db.GetProductMaxQuantity());
            db.Close();
            break;
        
        case "030_5": // 030_5. Показать товар с минимальным количеством
            db.Open();
            CLI.ShowProduct(db.GetProductMinQuantity());
            db.Close();
            break;
        
        case "030_6": // 030_6. Показать товар с минимальной себестоимостью
            db.Open();
            CLI.ShowProduct(db.GetProductMinCost());
            db.Close();
            break;
        
        case "030_7": // 030_7. Показать товар с максимальной себестоимостью
            db.Open();
            CLI.ShowProduct(db.GetProductMaxCost());
            db.Close();
            break;
        
        case "030_<": // 030_< - Назад
            menuLevel = "000";
            break;
        
        case "040_1": // 040_1 - Показать товары, заданной категории

            db.Open();
            CLI.ShowTypes(db.GetTypes());
            db.Close();

            int type_id = CLI.InputChoice("Введите тип (int): ");

            db.Open();
            CLI.ShowProducts(db.GetProuctFromType(type_id));
            db.Close();
            break;

        case "040_2": // 040_2 Показать товары, заданного поставщика
            db.Open();
            CLI.ShowSuppliers(db.GetSuppliers());
            db.Close();

            int supplier_id = CLI.InputChoice("Введите поставщика (int): ");

            db.Open();
            CLI.ShowProducts(db.GetProuctFromSupplier(supplier_id));
            db.Close();

            break;

        case "040_3": // 040_3 - Показать самый старый товар на складе
            db.Open();
            CLI.ShowProduct(db.GetProductOld());
            db.Close();
            break;
        
        case "040_4": // 040_4 - Показать среднее количество товаров по каждому типу товара
            db.Open();
            CLI.OutTabl(db.GetProductAvgQuantity());
            db.Close();
            break;
        
        case "040_<": // 040_< - Назад
            menuLevel = "000";
            break;

        case "0": // 0. Выход
            exit = true;
            break;
        default:
            break;
    }
} while (!exit);

CLI.SayGoodBy();