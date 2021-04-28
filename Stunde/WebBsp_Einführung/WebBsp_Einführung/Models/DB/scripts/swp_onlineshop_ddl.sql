create database swp_onlineshop collate utf8mb4_general_ci;

use swp_onlineshop;

create table articles(
	article_id int unsigned not null auto_increment,
    name varchar(200) not null,
    brand varchar(200) null,
    releasedate date null,
    price decimal(6,2) not null,
    category int null,
    
    constraint article_id_PK primary key(article_id)
)engine=InnoDB;

insert into articles values(null, "Acer Laptop X2", "Acer", "2019-5-27", 599.99, 2);
insert into articles values(null, "Galaxy S20", "Samsung", "2020-8-10", 1099.90, 1);

select * from articles;