# Задание 1 --done
## Init DatdBase
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

## Insert data in tables
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

INSERT INTO host1323541_pd3.table_products
(product_name, type_id, supplier_id, product_quantity, product_cost, date_delivery)
VALUES ('Майонез', 1, 3, 20, 49.8, '2021-09-10');

INSERT INTO host1323541_pd3.table_products
(product_name, type_id, supplier_id, product_quantity, product_cost, date_delivery)
VALUES ('Кефир', 1, 1, 30, 29.8, '2021-09-11');

INSERT INTO host1323541_pd3.table_products
(product_name, type_id, supplier_id, product_quantity, product_cost, date_delivery)
VALUES ('Варенец', 1, 2, 15, 50.5, '2021-09-12');

## Задание 3 --done
### Отображение всей информации о товаре -done
SELECT table_products.id, product_name, type_name, suppliers_name, product_quantity, product_cost, date_delivery
FROM table_products,
     table_product_types,
     table_product_suppliers
WHERE table_products.type_id = table_product_types.id
  AND table_products.supplier_id = table_product_suppliers.id;

### Отображение всех типов товаров --done
SELECT id, type_name
FROM table_product_types;

### Отображение всех поставщиков --done
SELECT id, suppliers_name
FROM table_product_suppliers;

### Показать товар с максимальным количеством --done
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
  AND table_products.supplier_id = table_product_suppliers.id;

### Показать товар с минимальным количеством --done
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
  AND table_products.supplier_id = table_product_suppliers.id;

### Показать товар с минимальной себестоимостью --done
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
  AND table_products.supplier_id = table_product_suppliers.id;

### Показать товар с максимальной себестоимостью --done
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
  AND table_products.supplier_id = table_product_suppliers.id;

## Задание 4 --done
### Показать товары, заданной категории --done
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
  AND table_products.supplier_id = table_product_suppliers.id
  AND table_products.type_id = 1;

### Показать товары, заданного поставщика --done
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
  AND table_products.supplier_id = table_product_suppliers.id
  AND table_products.supplier_id = 1;

### Показать самый старый товар на складе --done
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
  AND table_products.supplier_id = table_product_suppliers.id;

### Показать среднее количество товаров по каждому типу товара --done
SELECT t.type_name as type_name, AVG(p.product_quantity) as avg
FROM table_products as p 
INNER JOIN table_product_types t ON p.type_id = t.id
GROUP BY p.type_id;

# Модуль 2
## Задание 1
### Вставка новых товаров --done
SELECT type_name
FROM table_product_types
WHERE id = 1;

SELECT suppliers_name
FROM table_product_suppliers
WHERE id = 1;

INSERT INTO host1323541_pd3.table_products
(product_name, type_id, supplier_id, product_quantity, product_cost, date_delivery) VALUES ('Варенец', 1, 1, 5, 50,5, '20.09.2021 0:00:00');

### Вставка новых типов товаров --done
INSERT INTO table_product_types
(type_name)
VALUE ('New TypeName');

