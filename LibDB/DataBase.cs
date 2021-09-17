using System.Collections.Generic;
using LibDB_Core;

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
            _command.CommandText = request;

            var result = _command.ExecuteReader();

            while (result.Read())
            {
                var id = result.GetInt32("id");
                var rpoduct_name = result.GetString("product_name");
                var type_name = result.GetString("type_name");
                var suppliers_name = result.GetString("suppliers_name");
                var product_quantity = result.GetDouble("product_quantity");
                var product_cost = result.GetDouble("product_cost");
                var date_delivery = result.GetDateTime("date_delivery");

                products.Add(new Product
                    {
                        Id = id,
                        ProductName = rpoduct_name,
                        ProducType = type_name,
                        ProducSupplier = suppliers_name,
                        ProductQuantity = product_quantity,
                        ProductCost = product_cost,
                        DeliveryDate = date_delivery
                    }
                );
            }

            return products;
        }

        public List<ProductType> GetTypes()
        {
            // Отображение всех типов товаров
            List<ProductType> types = new List<ProductType>();
            string request =
                @"
SELECT id,type_name
FROM table_product_types;";
            _command.CommandText = request;

            var result = _command.ExecuteReader();

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
    }
}