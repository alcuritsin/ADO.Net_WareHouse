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
        
        
        
    }
}