# Задание 1 --done
# Init DatdBase
CREATE TABLE table_product_types
(
    id        INT         NOT NULL AUTO_INCREMENT PRIMARY KEY,
    type_name VARCHAR(50) NOT NULL
);

CREATE TABLE table_product_suppliers
(
    id             INT         NOT NULL AUTO_INCREMENT PRIMARY KEY,
    suppliers_name VARCHAR(50) NOT NULL
);

CREATE TABLE table_products
(
    id               INT         NOT NULL AUTO_INCREMENT PRIMARY KEY,
    product_name     VARCHAR(50) NOT NULL,
    type_id          INT         NOT NULL,
    supplier_id      INT         NOT NULL,
    product_quantity DOUBLE      NOT NULL,
    product_cost     DOUBLE      NOT NULL,
    date_delivery    DATE        NOT NULL,
    FOREIGN KEY (type_id) REFERENCES table_product_types (id),
    FOREIGN KEY (supplier_id) REFERENCES table_product_suppliers (id)
);

# Insert data in tables
INSERT INTO host1323541_pd3.table_product_suppliers (suppliers_name)
VALUES ('Село зелёное');

INSERT INTO host1323541_pd3.table_product_suppliers (suppliers_name)
VALUES ('СладКо');

INSERT INTO host1323541_pd3.table_product_suppliers (suppliers_name)
VALUES ('ЕЖК');

INSERT INTO host1323541_pd3.table_product_types (type_name)
VALUES ('Молочка');

INSERT INTO host1323541_pd3.table_product_types (type_name)
VALUES ('Конфеты');

INSERT INTO host1323541_pd3.table_product_types (type_name)
VALUES ('Хлебобулочные');

INSERT INTO host1323541_pd3.table_products (product_name, type_id, supplier_id, product_quantity, product_cost,
                                            date_delivery)
VALUES ('Молоко', 1, 1, 25, 50.58, '2021-09-10');

INSERT INTO host1323541_pd3.table_products (product_name, type_id, supplier_id, product_quantity, product_cost,
                                            date_delivery)
VALUES ('Птичье Молоко', 2, 2, 35, 25.3, '2021-09-10');

INSERT INTO host1323541_pd3.table_products (product_name, type_id, supplier_id, product_quantity, product_cost,
                                            date_delivery)
VALUES ('Майонез', 1, 3, 20, 49.8, '2021-09-10');

# Задание 3
# Отображение всей информации о товаре -done
SELECT table_products.id, product_name, type_name, suppliers_name, product_quantity, product_cost, date_delivery
FROM table_products,
     table_product_types,
     table_product_suppliers
WHERE table_products.type_id = table_product_types.id
  AND table_products.supplier_id = table_product_suppliers.id;

# Отображение всех типов товаров --done
SELECT id, type_name
FROM table_product_types;

# Отображение всех поставщиков --done
SELECT id, suppliers_name
FROM table_product_suppliers;

# Показать товар с максимальным количеством --done
SELECT MAX(product_quantity) as max
FROM table_products;

# Показать товар с максимальным количеством --done
SELECT table_products.id, product_name, type_name, suppliers_name,
       MAX(product_quantity) as product_quantity, product_cost, date_delivery
FROM table_products,
     table_product_types,
     table_product_suppliers
WHERE table_products.type_id = table_product_types.id
  AND table_products.supplier_id = table_product_suppliers.id;

# Показать товар с минимальным количеством
SELECT table_products.id, product_name, type_name, suppliers_name,
       MIN(product_quantity) as product_quantity, product_cost, date_delivery
FROM table_products,
     table_product_types,
     table_product_suppliers
WHERE table_products.type_id = table_product_types.id
  AND table_products.supplier_id = table_product_suppliers.id;

# Показать товар с минимальной себестоимостью
SELECT table_products.id, product_name, type_name, suppliers_name,
       product_quantity, MIN(product_cost) as product_cost, date_delivery
FROM table_products,
     table_product_types,
     table_product_suppliers
WHERE table_products.type_id = table_product_types.id
  AND table_products.supplier_id = table_product_suppliers.id;

# Показать товар с максимальной себестоимостью
SELECT table_products.id, product_name, type_name, suppliers_name,
       product_quantity, MAX(product_cost) as product_cost, date_delivery
FROM table_products,
     table_product_types,
     table_product_suppliers
WHERE table_products.type_id = table_product_types.id
  AND table_products.supplier_id = table_product_suppliers.id;





/*
SELECT login, last_name, first_name
FROM table_account, table_person
WHERE table_person.id = table_account.id;
*/
