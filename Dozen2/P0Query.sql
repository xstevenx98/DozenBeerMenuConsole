
drop table Order;
drop table Customer;
drop table Drink;
drop table Location;

/*
	drop is used for in case i'd want to alter a certain table,
	its easier to drop and recreate with seed data
	as opposed to going through refactoring your database
	among other things
*/

create table Customer
(
	customerID int identity primary key,
	name varchar(50) not null,
	age varchar(10) not null,
    phoneNumber varchar (12) not null,
);


create table Orders
(
    orderID int identity primary key,
    total decimal not null,
    customer int references Customer(customerID),
    location int references Location(locationID),
	--drink int references Drink(drinkID)
);


create table Drink
(
	--drinkID int identity primary key,
	ABV int not null,
	drinkName varchar(20) not null,
	price float not null,
);


create table Location
(
	locationID int identity primary key,
	locationName varchar(10) not null,
	state varchar(10) not null
);



--ALTER TABLE DrinkOrder
--DROP COLUMN l;

SELECT * FROM Location;

insert into location (locationName, state) VALUES
('Location1', 'NY'), ('Location 2', 'FL'),('Location 3', 'VA');