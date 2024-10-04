Use KoiFishFarm
Go
Create Table [Role] (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Name NVARCHAR(256),
    CreateAt DATETIME not null
) 
Go
Create Table [User] (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
	Username NVARCHAR(256) UNIQUE not null,
    Password NVARCHAR(256) not null,
    Name NVARCHAR(256) not null,
	Phone NVARCHAR(256),
    Address NVARCHAR(MAX),
	Status NVARCHAR(256) not null,
	RoleId UNIQUEIDENTIFIER foreign key references [Role](Id) not null,
    CreateAt DATETIME not null
)
Go
Create Table Category (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Name NVARCHAR(256) not null,
    CreateAt DATETIME not null
)
Go
Create Table Batch (
	Id UNIQUEIDENTIFIER PRIMARY KEY,
    Name NVARCHAR(256) not null,
    ThumbnailUrl NVARCHAR(MAX) not null,
	Price INT not null,
    PromotionPrice INT,
	CreatorId UNIQUEIDENTIFIER foreign key references [User](Id) not null,
    CreateAt DATETIME not null
)
Go
Create Table Fish (
	Id UNIQUEIDENTIFIER PRIMARY KEY,
    Name NVARCHAR(256) not null,
    Description NVARCHAR(MAX),
    Origin NVARCHAR(256) not null,
    Size INT not null,
    ThumbnailUrl NVARCHAR(MAX) not null,
    DateOfBirth DATETIME not null,
    Price INT not null,
    PromotionPrice INT,
	CreatorId UNIQUEIDENTIFIER foreign key references [User](Id) not null,
	BatchId UNIQUEIDENTIFIER foreign key references Batch(Id),
    Status NVARCHAR(256) not null,
    CreateAt DATETIME not null
)
Go
Create Table FishCategory (
    Id UNIQUEIDENTIFIER unique,
	FishId UNIQUEIDENTIFIER foreign key references Fish(Id) not null,
	CategoryId UNIQUEIDENTIFIER foreign key references Category(Id) not null,
	Primary key (FishId, CategoryId)
)
Go
Create Table DeliveryCompany (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Name NVARCHAR(256) not null,
	Price float not null,
	Phone nvarchar(256) not null,
	Status nvarchar(256) not null,
	CreateAt datetime not null
)
Go
Create Table Driver (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Name NVARCHAR(256) not null,
	DeliveryCompanyId UNIQUEIDENTIFIER foreign key references DeliveryCompany(Id) not null,
	Status nvarchar(256) not null,
	Phone nvarchar(256) not null,
	Plates nvarchar(256) not null,
	CreateAt datetime not null
)
Go
Create Table [Order] (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
	CustomerId UNIQUEIDENTIFIER foreign key references [User](Id) not null,
	DriverId UNIQUEIDENTIFIER foreign key references Driver(Id),
	Amount INT not null,
    Receiver NVARCHAR(256) not null,
    Address NVARCHAR(MAX) not null,
    Phone NVARCHAR(256) not null,
    PaymentMethod NVARCHAR(256) not null,
    IsPayment BIT not null,
    Status NVARCHAR(256) not null,
    CreateAt DATETIME,
)
Go
CREATE TABLE OrderDetail (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    OrderId UNIQUEIDENTIFIER foreign key references [Order](Id) not null,
    FishId UNIQUEIDENTIFIER foreign key references Fish(Id),
    BatchId UNIQUEIDENTIFIER foreign key references Batch(Id),
    Price INT not null,
);
Go
Create Table Feedback (
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	OrderId UNIQUEIDENTIFIER foreign key references [Order](Id) not null,
    CustomerId UNIQUEIDENTIFIER foreign key references [User](Id) not null,
    Message NVARCHAR(MAX),
    Star INT not null,
    CreateAt DATETIME,
)