// See https://aka.ms/new-console-template for more information

using System;
using LibDB;
using WareHouse_CLI;


    var db = new DataBase();
    var exit = false;

    do
    {
        CLI.ShowMenu();
        var select = Console.ReadLine();
        switch (select)
        {

            case "1": //  1. Отображение всей информации о товаре
                db.Open();
                CLI.ShowProducts(db.GetProducts());
                db.Close();
                break;

            case "2": //  2. Отображение всех типов товаров
                db.Open();
                CLI.ShowTypes(db.GetTypes());
                db.Close();
                break;

            case "3": //  3. Отображение всех поставщиков
                db.Open();
                //CLI.ShowListValue(db.GetColorProduct(), "Цвета продуктов:");
                db.Close();
                break;
            case "4": //  4. Показать товар с максимальным количеством
                db.Open();
                //CLI.ShowValue(db.GetMaxEnergyValue(), "Максимальное значение колорийности: ");
                db.Close();
                break;
            case "5": //  5. Показать товар с минимальным количеством
                db.Open();
                //CLI.ShowValue(db.GetMinEnergyValue(), "Минимальное значение колорийности: ");
                db.Close();
                break;
            case "6": //  6. Показать товар с минимальной себестоимостью
                db.Open();
                //CLI.ShowValue(db.GetAvgEnergyValue(), "Среднее значение колорийности: ");
                db.Close();
                break;
            case "7": //  7. Показать товар с максимальной себестоимостью
                db.Open();
                //db.IsertProduct(CLI.InoutProduct());
                db.Close();
                break;
            case "0": // 0. Выход
                exit = true;
                break;
            default:
                break;
        }
    } while (!exit);
    
    CLI.SayGoodBy();