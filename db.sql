Create table Account
(
UserID int PRIMARY KEY IDENTITY(1,1),
[Login] nvarchar(50) not null UNIQUE,
[Password] nvarchar(50) not null,
Email nvarchar(50) not null,
Phone int not null,
[Name] nvarchar(50),
Surname nvarchar(50),
Photo nvarchar(100)
)

Create table Category
(
CategoryId int Primary key,
CategoryName nvarchar(50) not null,
)
Create table Item
(
ItemID int  primary key,
[Name] nvarchar(50) not null,
Size nvarchar(50) not null,
Color nvarchar(50) not null,
Price int not null,
Photo nvarchar(50),
CategoryId int not null,
FOREIGN KEY (CategoryId) REFERENCES Category (CategoryId)
)
Create table Delivery
(
DeliveryID int PRIMARY KEY IDENTITY(1,1),
UserID int not null,
Country nvarchar(50) not null,
City nvarchar(50) not null,
Street nvarchar(50) not null,
CityIndex nvarchar (50) not null,
Home nvarchar (50) not null,
Apartment nvarchar(50)
FOREIGN KEY (UserID) REFERENCES Account (UserID)

)

Create table Basket
(
ItemID int not null,
DealId int Primary key Identity,
UserID int not null,
[Status] nvarchar(50) not null,

FOREIGN KEY (ItemID) REFERENCES Item (ItemID),

FOREIGN KEY (UserID) REFERENCES Account (UserID)
)

Create table OrderItem
(
OrderID int Primary key Identity,
ItemID int not null,
UserId int not null,
DeliveryStatus nvarchar(50) not null,
DateOfCreate datetime not null,
Deadline datetime not null,
FOREIGN KEY (UserID) REFERENCES Account (UserID),
FOREIGN KEY (ItemID) REFERENCES Item (ItemID)
)
Create table Review
(
ReviewId int primary key Identity(1,1),
UserID int not null,
ItemId int not null,
Opinion nvarchar(1000),
Photo nvarchar(100)
FOREIGN KEY (UserID) REFERENCES Account (UserID),
FOREIGN KEY (ItemID) REFERENCES Item (ItemID)
)
