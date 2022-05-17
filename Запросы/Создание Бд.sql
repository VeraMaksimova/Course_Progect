CREATE TABLE ORDERS(
 order_id int identity not null primary key,
 name_of_ordered_product nvarchar(50) not null,
price_of_ordered_product money unique not null,
 status nvarchar(50) default 'корзина' check(status in ('корзина','оформлен','доствка','доставлен','получен' )) not null
);


CREATE TABLE USERS(
 id_user int identity(1,1) not null primary key,
 user_login nvarchar(50) not null,
user_password nvarchar(50) not null,
 user_name nvarchar(50) not null,
user_surname nvarchar(50) not null,
 user_patronomic nvarchar(50),
 user_adress nvarchar(100),
 user_date_of_birth date not null,
);

create table PRODUCT(
id_product int identity(1,1) not null primary key,
product_name nvarchar(50) not null,
price money unique not null,
amount int not null,
color nvarchar(30) default 'красный' check(color in ('красный','синий','голубой','желтый','зеленый',',белый', 'розовый', 'черный', 'другой' )) not null,
product_description nvarchar(400) not null,
photo_1 nvarchar(500) not null,
photo_2 nvarchar(500) not null,
photo_3 nvarchar(500) not null
);