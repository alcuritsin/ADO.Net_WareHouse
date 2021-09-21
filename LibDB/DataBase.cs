using System;
using System.Collections.Generic;
using System.Data;
using LibDB_Core;
using MySql.Data.MySqlClient;

namespace LibDB
{
    public class DataBase : DB_connect
    {
        #region Get

        public List<Product> GetProducts()
        {
            // Отображение всей информации о товаре
            List<Product> products = new List<Product>();

            string request =
                @"
SELECT table_products.id, product_name, type_name,suppliers_name,product_quantity,product_cost,date_delivery
FROM table_products,table_product_types, table_product_suppliers
WHERE table_products.type_id = table_product_types.id AND table_products.supplier_id = table_product_suppliers.id;";

            var result = GetAnswer(request);

            while (result.Read())
            {
                products.Add(GetProduct(result));
            }

            return products;
        }

        private Product GetProduct(MySqlDataReader answer)
        {
            // Из запроса формирует карточку товара
            var id = answer.GetInt32("id");
            var rpoductName = answer.GetString("product_name");
            var typeName = answer.GetString("type_name");
            var suppliersName = answer.GetString("suppliers_name");
            var productQuantity = answer.GetDouble("product_quantity");
            var productCost = answer.GetDouble("product_cost");
            var dateDelivery = answer.GetDateTime("date_delivery");

            Product product = new Product
            {
                Id = id,
                ProductName = rpoductName,
                ProducType = typeName,
                ProducSupplier = suppliersName,
                ProductQuantity = productQuantity,
                ProductCost = productCost,
                DeliveryDate = dateDelivery
            };

            return product;
        }

        public List<ProductType> GetTypes()
        {
            // Отображение всех типов товаров
            List<ProductType> types = new List<ProductType>();
            string request =
                @"
SELECT id,type_name
FROM table_product_types;";

            var result = GetAnswer(request);

            while (result.Read())
            {
                var id = result.GetInt32("id");
                var typeName = result.GetString("type_name");

                types.Add(new ProductType
                    {
                        Id = id,
                        TypeName = typeName
                    }
                );
            }

            return types;
        }

        public List<ProductSupplier> GetSuppliers()
        {
            // Отображение всех поставщиков 
            List<ProductSupplier> productSuppliers = new List<ProductSupplier>();

            string request =
                @"
SELECT id,suppliers_name
FROM table_product_suppliers;";
            MySqlDataReader result = GetAnswer(request);

            while (result.Read())
            {
                var id = result.GetInt32("id");
                var suppliersName = result.GetString("suppliers_name");

                productSuppliers.Add(new ProductSupplier
                    {
                        Id = id,
                        SupplierName = suppliersName
                    }
                );
            }

            return productSuppliers;
        }

        public Product GetProductMaxQuantity()
        {
            // Показать товар с максимальным количеством
            Product product = new Product();

            string request =
                @"
SELECT table_products.id,
       product_name,
       type_name,
       suppliers_name,
       product_quantity,
       product_cost,
       date_delivery
FROM table_products,
     table_product_types,
     table_product_suppliers
WHERE table_products.product_quantity = (SELECT MAX(product_quantity) FROM table_products)
  AND table_products.type_id = table_product_types.id
  AND table_products.supplier_id = table_product_suppliers.id;";

            MySqlDataReader result = GetAnswer(request);

            while (result.Read())
            {
                product = GetProduct(result);
            }

            return product;
        }

        public Product GetProductMinQuantity()
        {
            // Показать товар с минимальным количеством
            Product product = new Product();

            string request =
                @"
SELECT table_products.id,
       product_name,
       type_name,
       suppliers_name,
       product_quantity,
       product_cost,
       date_delivery
FROM table_products,
     table_product_types,
     table_product_suppliers
WHERE table_products.product_quantity = (SELECT MIN(product_quantity) FROM table_products)
  AND table_products.type_id = table_product_types.id
  AND table_products.supplier_id = table_product_suppliers.id;";

            MySqlDataReader result = GetAnswer(request);

            while (result.Read())
            {
                product = GetProduct(result);
            }

            return product;
        }

        public Product GetProductMinCost()
        {
            // Показать товар с минимальной себестоимостью
            Product product = new Product();

            string request =
                @"
SELECT table_products.id,
       product_name,
       type_name,
       suppliers_name,
       product_quantity,
       product_cost,
       date_delivery
FROM table_products,
     table_product_types,
     table_product_suppliers
WHERE table_products.product_cost = (SELECT MIN(product_cost) FROM table_products)
  AND table_products.type_id = table_product_types.id
  AND table_products.supplier_id = table_product_suppliers.id;";

            MySqlDataReader result = GetAnswer(request);

            while (result.Read())
            {
                product = GetProduct(result);
            }

            return product;
        }

        public Product GetProductMaxCost()
        {
            // Показать товар с максимальной себестоимостью
            Product product = new Product();

            string request =
                @"
SELECT table_products.id,
       product_name,
       type_name,
       suppliers_name,
       product_quantity,
       product_cost,
       date_delivery
FROM table_products,
     table_product_types,
     table_product_suppliers
WHERE table_products.product_cost = (SELECT MAX(product_cost) FROM table_products)
  AND table_products.type_id = table_product_types.id
  AND table_products.supplier_id = table_product_suppliers.id;";

            MySqlDataReader result = GetAnswer(request);

            while (result.Read())
            {
                product = GetProduct(result);
            }

            return product;
        }

        public List<Product> GetProuctFromType(int product_type)
        {
            // Показать товары, заданной категории
            List<Product> products = new List<Product>();

            string request =
                @"
SELECT table_products.id,
       product_name,
       type_name,
       suppliers_name,
       product_quantity,
       product_cost,
       date_delivery
FROM table_products,
     table_product_types,
     table_product_suppliers
WHERE table_products.type_id = table_product_types.id
  AND table_products.supplier_id = table_product_suppliers.id ";
            request += $"\nAND table_products.type_id = {product_type};";

            var result = GetAnswer(request);

            while (result.Read())
            {
                products.Add(GetProduct(result));
            }

            return products;
        }

        public List<Product> GetProuctFromSupplier(int product_supplier)
        {
            // Показать товары, заданного поставщика
            List<Product> products = new List<Product>();

            string request =
                @"
SELECT table_products.id,
       product_name,
       type_name,
       suppliers_name,
       product_quantity,
       product_cost,
       date_delivery
FROM table_products,
     table_product_types,
     table_product_suppliers
WHERE table_products.type_id = table_product_types.id
  AND table_products.supplier_id = table_product_suppliers.id ";
            request += $"\nAND table_products.supplier_id = {product_supplier};";

            var result = GetAnswer(request);

            while (result.Read())
            {
                products.Add(GetProduct(result));
            }

            return products;
        }

        public Product GetProductOld()
        {
            // Показать самый старый товар на складе

            Product product = new Product();

            string request =
                @"
SELECT table_products.id,
       product_name,
       type_name,
       suppliers_name,
       product_quantity,
       product_cost,
       date_delivery
FROM table_products,
     table_product_types,
     table_product_suppliers
WHERE table_products.date_delivery = (SELECT MIN(date_delivery) FROM table_products)
  AND table_products.type_id = table_product_types.id
  AND table_products.supplier_id = table_product_suppliers.id;";

            MySqlDataReader result = GetAnswer(request);

            while (result.Read())
            {
                product = GetProduct(result);
            }

            return product;
        }

        public List<List<string>> GetProductAvgQuantity()
        {
            List<List<string>> tupes = new List<List<string>>();

            string request =
                @"
SELECT t.type_name as type_name, AVG(p.product_quantity) as avg
FROM table_products as p 
INNER JOIN table_product_types t ON p.type_id = t.id
GROUP BY p.type_id;";

            var result = GetAnswer(request);

            while (result.Read())
            {
                List<string> item = new List<string>()
                {
                    result.GetString("type_name"),
                    result.GetDouble("avg").ToString()
                };
                tupes.Add(item);
            }

            return tupes;
        }

        public string GetTypeNameById(int id)
        {
            string typeName = "";
            string sqlExpression = @"
SELECT type_name
FROM table_product_types " + $"WHERE id = {id};";
            MySqlDataReader result = GetAnswer(sqlExpression);

            while (result.Read())
            {
                typeName = result.GetString("type_name");
            }

            return typeName;
        }

        public string GetSupplierNameById(int id)
        {
            string typeName = "";
            string sqlExpression = @"
SELECT suppliers_name
FROM table_product_suppliers " +
                                   $"WHERE id = {id};";
            MySqlDataReader result = GetAnswer(sqlExpression);

            while (result.Read())
            {
                typeName = result.GetString("suppliers_name");
            }

            return typeName;
        }

        public Product GetProductById(int product_id)
        {
            // Прочитать из БД продукт по id
            string sqlExpression =
                $@"
SELECT table_products.id,
       product_name,
       type_id,
       type_name,
       supplier_id,
       suppliers_name,
       product_quantity,
       product_cost,
       date_delivery
FROM table_products,
     table_product_types,
     table_product_suppliers
WHERE table_products.type_id = table_product_types.id
  AND table_products.supplier_id = table_product_suppliers.id
  AND table_products.id = {product_id};";

            MySqlDataReader answer = GetAnswer(sqlExpression);

            Product product = new Product();

            while (answer.Read())
            {
                product.Id = answer.GetInt32("id");
                product.ProductName = answer.GetString("product_name");
                product.ProductTypeId = answer.GetInt32("type_id");
                product.ProducType = answer.GetString("type_name");
                product.ProductSupplierId = answer.GetInt32("supplier_id");
                product.ProducSupplier = answer.GetString("suppliers_name");
                product.ProductQuantity = answer.GetDouble("product_quantity");
                product.ProductCost = answer.GetDouble("product_cost");
                product.DeliveryDate = answer.GetDateTime("date_delivery");
            }

            return product;
        }

        public ProductSupplier GetProductSupplierById(int supplier_id)
        {
            string sqlExpression =
                $@"
SELECT table_product_suppliers.id, suppliers_name
FROM table_product_suppliers
WHERE table_product_suppliers.id = {supplier_id};";

            MySqlDataReader answer = GetAnswer(sqlExpression);

            ProductSupplier productSupplier = new ProductSupplier();

            while (answer.Read())
            {
                productSupplier.Id = answer.GetInt32("id");
                productSupplier.SupplierName = answer.GetString("suppliers_name");
            }

            return productSupplier;
        }

        public ProductType GetProductTypeById(int type_id)
        {
            string sqlExpression =
                $@"
SELECT table_product_types.id, type_name
FROM table_product_types
WHERE table_product_types.id = {type_id};";

            MySqlDataReader answer = GetAnswer(sqlExpression);

            ProductType productType = new ProductType();

            while (answer.Read())
            {
                productType.Id = answer.GetInt32("id");
                productType.TypeName = answer.GetString("type_name");
            }

            return productType;
        }

        #endregion

        #region Insert

        public int InsertNewProduct(Product product)
        {
            // Вставка новых товаров
            string request =
                @"
INSERT INTO host1323541_pd3.table_products
(product_name, type_id, supplier_id, product_quantity, product_cost, date_delivery) " +
                $"VALUES ('{product.ProductName}', {product.ProductTypeId}, {product.ProductSupplierId}, {DoubleToString(product.ProductQuantity)}, {DoubleToString(product.ProductCost)}, '{DateTimeToString(product.DeliveryDate)}');";

            return NonQuery(request);

            // Если результат 1, то всё ок. Добавлена одна строка (кортеж).
        }

        public int InsertNewProductType(ProductType productType)
        {
            // Вставка новых типов товаров
            string sqlExpression =
                $@"
INSERT INTO table_product_types
(type_name)
VALUE ('{productType.TypeName}');";
            return NonQuery(sqlExpression);
        }

        public int InsertNewSupplier(ProductSupplier productSupplier)
        {
            // Вставка новых поставщиков
            string sqlExpression =
                $@"
INSERT INTO table_product_suppliers
(suppliers_name)
VALUE ('{productSupplier.SupplierName}');";
            return NonQuery(sqlExpression);
        }

        #endregion

        #region Update

        public int UpdateProduct(Product product)
        {
            string sqlExpression =
                $@"
UPDATE table_products
SET product_name = '{product.ProductName}',
    type_id = {product.ProductTypeId}, supplier_id = {product.ProductSupplierId},
    product_quantity = {DoubleToString(product.ProductQuantity)}, product_cost = {DoubleToString(product.ProductCost)},
    date_delivery = '{DateTimeToString(product.DeliveryDate)}'
WHERE id = {product.Id};";

            return NonQuery(sqlExpression);
        }

        public int UpdateProductSupplier(ProductSupplier productSupplier)
        {
            string sqlExpression =
                $@"
UPDATE table_product_suppliers
SET suppliers_name = '{productSupplier.SupplierName}'
WHERE table_product_suppliers.id = {productSupplier.Id};";
            return NonQuery(sqlExpression);
        }

        public int UpdateProductType(ProductType productType)
        {
            string sqlExpression =
                $@"
UPDATE table_product_types
SET type_name = '{productType.TypeName}'
WHERE table_product_types.id = {productType.Id};";
            return NonQuery(sqlExpression);
        }

        #endregion

        #region HelpMethods

        private static string DoubleToString(double value)
        {
            return value.ToString().Replace(",", ".");
        }

        private static string DateTimeToString(DateTime dateTime)
        {
            return $"{dateTime.Year.ToString()}-{dateTime.Month.ToString()}-{dateTime.Day.ToString()}";
        }

        #endregion
    }
}