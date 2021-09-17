using System.Collections.Generic;
using LibDB_Core;
using MySql.Data.MySqlClient;

namespace LibDB
{
    public class DataBase : DB_connect
    {
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
                products.Add( GetProduct(result));
            }

            return products;
        }


        private Product GetProduct(MySqlDataReader answer)
        {
            // Из запроса формирует карточку товара
            var id = answer.GetInt32("id");
            var rpoduct_name = answer.GetString("product_name");
            var type_name = answer.GetString("type_name");
            var suppliers_name = answer.GetString("suppliers_name");
            var product_quantity = answer.GetDouble("product_quantity");
            var product_cost = answer.GetDouble("product_cost");
            var date_delivery = answer.GetDateTime("date_delivery");

            Product product = new Product
            {
                Id = id,
                ProductName = rpoduct_name,
                ProducType = type_name,
                ProducSupplier = suppliers_name,
                ProductQuantity = product_quantity,
                ProductCost = product_cost,
                DeliveryDate = date_delivery
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
                var type_name = result.GetString("type_name");

                types.Add(new ProductType
                    {
                        Id = id,
                        TypeName = type_name
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
                var suppliers_name = result.GetString("suppliers_name");

                productSuppliers.Add(new ProductSupplier
                    {
                        Id = id,
                        SupplierName = suppliers_name
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
SELECT table_products.id, product_name, type_name, suppliers_name, MAX(product_quantity) as product_quantity, product_cost, date_delivery
FROM table_products,
     table_product_types,
     table_product_suppliers
WHERE table_products.type_id = table_product_types.id
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
SELECT table_products.id, product_name, type_name, suppliers_name,
       MIN(product_quantity) as product_quantity, product_cost, date_delivery
FROM table_products,
     table_product_types,
     table_product_suppliers
WHERE table_products.type_id = table_product_types.id
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
SELECT table_products.id, product_name, type_name, suppliers_name,
       product_quantity, MIN(product_cost) as product_cost, date_delivery
FROM table_products,
     table_product_types,
     table_product_suppliers
WHERE table_products.type_id = table_product_types.id
  AND table_products.supplier_id = table_product_suppliers.id;";
            
            MySqlDataReader result = GetAnswer(request);
            
            while (result.Read())
            {
                product = GetProduct(result);
            }

            return product;
        }
    }
}