create database if not exists db_testLernen collate utf8mb4_general_ci;
use db_testLernen;
drop table test;
create table test (
	article_ID int unsigned not null auto_increment,
    name varchar(200) not null,
    description varchar(5000) null,
    price decimal(6,2) not null,
	constraint article_id_PK primary key(article_id)
)	 engine=InnoDb;
insert into test (article_ID,name,description,price) value (null,"Hallo Welt","Hier liegt die neue Welt",1234.90);
insert into test (article_ID,name,description,price) value (null,"Hallo Welfewrwgthzjtuzkit","Hier liegt die neue Welt",1234.90);
update test set name='Hallo' , description='Hallo in der Adamgasse', price='1234,9' where article_ID=1;
select * from test;
