### Подготовка таблиц  
```
CREATE TABLE products(  
id INT PRIMARY KEY IDENTITY,  
name VARCHAR(127));
 
CREATE TABLE category(  
id INT PRIMARY KEY IDENTITY,  
name VARCHAR(127));  
``` 
### Создание таблицы для связей между продуктами и категориями
``` 
CREATE TABLE prodCatRef(  
productsID INT NOT NULL,  
categoryID INT NOT NULL,  
FOREIGN KEY(productsID) REFERENCES products(id),  
FOREIGN KEY(categoryID) REFERENCES category(id));  
``` 
### Заполнение таблиц тестовыми данными
``` 
INSERT INTO products VALUES  
	('Соль'),   
	('Помидоры'),   
	('Садовый шланг'),   
	('Гвозди');  

INSERT INTO category VALUES  
	('Продукты'),   
	('Бакалея'),   
	('Садовые товары');  

INSERT INTO prodCatRef VALUES  
	(1, 1),   
	(2, 1),   
	(2, 2),   
	(3, 3);  
``` 
### Запрос на получение необходимой информации  
``` 
SELECT p.name, c.name  
FROM products p  
LEFT JOIN prodCatRef pc  
	ON p.Id = pc.productsId  
LEFT JOIN Category C  
	ON pc.categoryId = c.Id   
 ``` 
