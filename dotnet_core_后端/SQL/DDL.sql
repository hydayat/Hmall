create table account(
    username varchar(20) primary key ,
    password varchar(20)
);
create table cart(
    username varchar(20),
    goodname varchar(20),
    price integer,
    amount integer,
    primary key (username, goodname)
);
create table orders(
    username varchar(20),
    goodname varchar(20),
    price integer,
    amount integer,
    time datetime
);
select * from account;
use hmall;