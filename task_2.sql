create table product (
	id serial not null primary key,
	"name" varchar(300) not null
);

create table category (
	id serial not null primary key,
	"name" varchar(300) not null
);

create table product_category (
	product_id integer not null,
	category_id integer not null,
	PRIMARY KEY (product_id, category_id),
	CONSTRAINT product_fk FOREIGN KEY (product_id) REFERENCES product (id) ON DELETE CASCADE,
	CONSTRAINT category_fk FOREIGN KEY (category_id) REFERENCES category (id) ON DELETE CASCADE
);

insert into product("name") 
	values
	('Продукт 1'),
	('Продукт 2'),
	('Продукт 3'),
	('МультиПродукт'),
	('Специфичный продукт');



insert into category("name") 
	values
	('Категория 1'),
	('Категория 2'),
	('Категория 3');

insert into product_category(product_id, category_id)
	values
	(1, 1),
	(2, 2),
	(3, 3),
	(4, 1),
	(4, 2),
	(4, 3);

select 
	pr.name as "Продукт",
	ct.name as "Категория"
from product as pr
left join product_category as pc on pr.id = pc.product_id
left join category as ct on ct.id = pc.category_id;
