// See https://aka.ms/new-console-template for more information

using System;
using System.ComponentModel.Design;
using System.Globalization;
using LibDB;
using Org.BouncyCastle.Crypto.Tls;
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
            InsertNewType();
            break;
        case "210_3": // Вставка новых поставщиков
            InsertNewSypplier();
            break;

        #endregion // 210

        #region Menu 220

        case "220_1": // Обновление информации о существующих товарах
            UpdateProduct();
            break;
        case "220_2": // Обновление информации о существующих поставщиках
            UpdateProductSupplier();
            break;
        case "220_3": // Обновление информации о существующих типах товаров
            UpdateProductType();
            break;

        #endregion // 220

        #region Menu 230

        case "230_1": // Удаление товаров
            DeleteProduct();
            break;
        case "230_2": // Удаление поставщиков
            DeleteProductSupplier();
            break;
        case "230_3": // Удаление типов товаров
            DeleteProductType();
            break;

        #endregion // 230

        #region Menu 240

        case "240_1": // Показать информацию о поставщике с наибольшим количеством товаров на складе
            CLI.ShowMessage(":: Показать информацию о поставщике с наибольшим количеством товаров на складе ::");
            db.Open();
            CLI.ShoTable(db.GetSupplierMaxQuantity());
            db.Close();
            break;
        
        case "240_2": // Показать информацию о поставщике с наименьшим количеством товаров на складе
            CLI.ShowMessage(":: Показать информацию о поставщике с наименьшим количеством товаров на складе ::");
            db.Open();
            CLI.ShoTable(db.GetSupplierMinQuantity());
            db.Close();
            break;
        
        case "240_3": // Показать информацию о типе товаров с наибольшим количеством товаров на складе
            CLI.ShowMessage(":: Показать информацию о типе товаров с наибольшим количеством товаров на складе ::");
            db.Open();
            CLI.ShoTable(db.GetTypeProductMaxQuantity());
            db.Close();
            break;
        
        case "240_4": // Показать информацию о типе товаров с наименьшим количеством товаров на складе
            CLI.ShowMessage(":: Показать информацию о типе товаров с наименьшим количеством товаров на складе ::");
            db.Open();
            CLI.ShoTable(db.GetTypeProductMinQuantity());
            db.Close();
            break;
        
        case "240_5": // Показать товары с поставки, которых прошло заданное количество дней
            GetProductWhereDeliveryOldDay();
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
    // Вставка новых товаров
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

    db.Open();
    CLI.ShowProducts(db.GetProducts());
    db.Close();
}

void InsertNewType()
{
    // Вставка новых типов товаров
    ProductType productType = new ProductType();

    CLI.ShowMessage(":: Добавить новый тип продукта в БД ::");
    productType.TypeName = CLI.InputString("Введите наименование типа: ");

    db.Open();
    CLI.ShowMessage($"Добавлено {db.InsertNewProductType(productType)} строк.");
    db.Close();

    db.Open();
    CLI.ShowTypes(db.GetTypes());
    db.Close();
}

void InsertNewSypplier()
{
    // Вставка новых поставщиков
    ProductSupplier productSupplier = new ProductSupplier();
    CLI.ShowMessage(":: Добавить нового поставщика продуктов в БД ::");
    productSupplier.SupplierName = CLI.InputString("Введите наименование поставщика: ");

    db.Open();
    CLI.ShowMessage($"Добавлено {db.InsertNewSupplier(productSupplier)} строк.");
    db.Close();

    db.Open();
    CLI.ShowSuppliers(db.GetSuppliers());
    db.Close();
}

void UpdateProduct()
{
    CLI.ShowMessage(":: Обновление информации о товаре ::");
    int productId = CLI.InputChoice("Введите ID товара: ");

    db.Open();
    Product product = db.GetProductById(productId);
    db.Close();

    bool done = false;
    bool update = false;

    do
    {
        CLI.ShowMessage("Редактирование продукта:");
        CLI.ShowProduct(product);

        CLI.ShowMenu("221");

        string select = Console.ReadLine();

        switch (select)
        {
            case "1":
                // Новое имя
                product.ProductName = CLI.InputString("Введите новое имя: ");
                break;

            case "2":
                // Новый тип продукта
                db.Open();
                CLI.ShowTypes(db.GetTypes());
                db.Close();

                product.ProductTypeId = CLI.InputChoice("Введите новый тип (int): ");

                //  Меняем текстовое отображение типа в локальной пееменной
                db.Open();
                product.ProducType = db.GetTypeNameById(product.ProductTypeId);
                db.Close();
                break;

            case "3":
                // Новый поставщик
                db.Open();
                CLI.ShowSuppliers(db.GetSuppliers());
                db.Close();

                product.ProductSupplierId = CLI.InputChoice("Введите нового поставщика (int): ");

                //  Меняем текстовое отображение поставщика в локальной пееменной
                db.Open();
                product.ProducSupplier = db.GetSupplierNameById(product.ProductSupplierId);
                db.Close();
                break;

            case "4":
                // Количество продукта
                product.ProductQuantity = Convert.ToDouble(CLI.InputString("Введите новое количество (double coma): "));
                break;

            case "5":
                // Себестоимость продукта
                product.ProductCost = Convert.ToDouble(CLI.InputString("Введите новую себестоимость (double coma): "));
                break;

            case "6":
                product.DeliveryDate = Convert.ToDateTime(CLI.InputString("Введите новую дату (dd.mm.yyyy): "));
                break;
            case "+":
                // Сохранить и выйти
                update = true;
                done = true;
                break;
            case "-":
                // Выход без сохранения
                update = false;
                done = true;
                break;
        }
    } while (!done);

    if (update)
    {
        db.Open();
        CLI.ShowMessage($"Изменено {db.UpdateProduct(product)} строк.");
        db.Close();
    }
    else
    {
        CLI.ShowMessage("Изменения не внесены.");
    }
}

void UpdateProductSupplier()
{
    // Обновление информации о существующих поставщиках
    CLI.ShowMessage(":: Обновление информации о поставщике ::");
    int supplierId = CLI.InputChoice("Введите ID поставщика: ");

    db.Open();
    ProductSupplier productSupplier = db.GetProductSupplierById(supplierId);
    db.Close();

    bool done = false;
    bool update = false;

    do
    {
        CLI.ShowMessage("Редактирование поставщика: ");
        CLI.ShowSupplier(productSupplier);

        CLI.ShowMenu("222");

        string select = Console.ReadLine();

        switch (select)
        {
            case "1":
                // Новое наименование
                productSupplier.SupplierName = CLI.InputString("Введите новое наименование поставщика: ");
                break;
            
            case "+":
                // Сохранить и выйти
                update = true;
                done = true;
                break;
            
            case "-":
                // Выход без сохранения
                update = false;
                done = true;
                break;
        }
    } while (!done);

    if (update)
    {
        db.Open();
        CLI.ShowMessage($"Измененно {db.UpdateProductSupplier(productSupplier)} строк.");
        db.Close();
    }
    else
    {
        CLI.ShowMessage("Изменения не внесены.");
    }
}

void UpdateProductType()
{
    // Обновление информации о существующих типах товаров
    CLI.ShowMessage(":: Обновление информации о типах продуктов ::");
    int typeId = CLI.InputChoice("Введите ID типа продукта: ");

    db.Open();
    ProductType productType = db.GetProductTypeById(typeId);
    db.Close();

    bool done = false;
    bool update = false;

    do
    {
        CLI.ShowMessage("Редактирование типа продукта: ");
        CLI.ShowType(productType);

        CLI.ShowMenu("222");

        string select = Console.ReadLine();

        switch (select)
        {
            case "1":
                // Новое наименование
                productType.TypeName = CLI.InputString("Введите новое наименование поставщика: ");
                break;
            
            case "+":
                // Сохранить и выйти
                update = true;
                done = true;
                break;
            
            case "-":
                // Выход без сохранения
                update = false;
                done = true;
                break;
        }
    } while (!done);

    if (update)
    {
        db.Open();
        CLI.ShowMessage($"Измененно {db.UpdateProductType(productType)} строк.");
        db.Close();
    }
    else
    {
        CLI.ShowMessage("Изменения не внесены.");
    }
}

void DeleteProduct()
{
    // Удаление товаров
    CLI.ShowMessage(": Удаление продукта :");
    int prodictId = CLI.InputChoice("Введите ID продукта: ");
    
    db.Open();
    CLI.ShowMessage($"Измененно {db.DeleteProductById(prodictId)} строк.");
    db.Close();
}

void DeleteProductSupplier()
{
    // Удаление поставщиков
    CLI.ShowMessage(": Удаление поставщика :");
    int supplierId = CLI.InputChoice("Введите ID поставщика: ");
    
    db.Open();
    CLI.ShowMessage($"Измененно {db.DeleteProductSupplierById(supplierId)} строк.");
    db.Close();
}

void DeleteProductType()
{
    // Удаление типов товаров
    CLI.ShowMessage(": Удаление типа товара :");
    int typeId = CLI.InputChoice("Введите ID типа товара: ");
    
    db.Open();
    CLI.ShowMessage($"Измененно {db.DeleteProductTypeById(typeId)} строк.");
    db.Close();
}

void GetProductWhereDeliveryOldDay()
{
    CLI.ShowMessage(": Показать товары с поставки, которых прошло заданное количество дней :");
    int day = CLI.InputChoice("Введиет количество дней: ");
    
    db.Open();
    CLI.ShoTable(db.GetProductWhereDeliveryOldDay(day));
    db.Close();
}