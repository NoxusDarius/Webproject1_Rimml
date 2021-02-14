create database if not exists db_shop collate utf8mb4_general_ci;

use db_shop;

create table articles (
	article_ID int unsigned not null auto_increment,
    name varchar(200) not null,
    description varchar(5000) null,
    price decimal(6,2) not null,
	constraint article_id_PK primary key(article_id)
) engine=InnoDb;

insert into articles values(null,"Trip to New York", "Incl. FLight, 5 Star Hotel",3450);
insert into articles values(null,"Trip to Los Angeles", "Incl. FLight, 5 Star Hotel",5200.76);
insert into articles values(null,"Trip to Innsbruck", "Incl. FLight, 5 Star Hotel",1600.90);
insert into articles values(null,"Trip to Spain", "Incl. FLight, 5 Star Hotel",2550);

select * from articles;