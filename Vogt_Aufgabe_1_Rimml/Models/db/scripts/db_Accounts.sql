create database if not exists db_Accounts collate utf8mb4_general_ci;

use db_Accounts;

create table Accounts (
	registration_ID int unsigned not null auto_increment,
	benutzer varchar(200) not null,
    password varchar(5000) null,
    plz INTEGER(6) not null,
    email varchar(200) not null,
    wohnort varchar(200) not null,
    payment INTEGER(4) not null,
    
	constraint registration_id_PK primary key(registration_id)
) engine=InnoDb;

insert into Accounts values(null,"admin","admin",6020,"admin@admingmgail.com","Adminstraße",4);

select * from Accounts;