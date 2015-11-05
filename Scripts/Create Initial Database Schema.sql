USE PortfolioApp


CREATE TABLE Stock
(
	ID INT Identity(1,1),
	Symbol NVARCHAR(10),
	LastPrice FLOAT,
	CompanyName NVARCHAR(100)
)

CREATE TABLE Portfolio
(
	StockId INT,
	Quantity INT
)

CREATE TABLE TransactionLog
(
	StockId INT,
	Quantity INT,
	Price FLOAT,
	Purchased BIT,
	TransactioNDate DateTime,
)


