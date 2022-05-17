create table PRODUCT(
id_product int identity(1,1) not null primary key,
product_name nvarchar(50) not null,
price money unique not null,
amount int not null,
color nvarchar(30) not null,
product_description nvarchar(400) not null,
photo_1 nvarchar(500) not null,
photo_2 nvarchar(500) not null,
photo_3 nvarchar(500) not null
);