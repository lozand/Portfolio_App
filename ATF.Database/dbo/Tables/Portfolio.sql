CREATE TABLE [dbo].[Portfolio] (
    [StockId]  INT NOT NULL,
    [UserId]   INT NOT NULL,
    [Quantity] INT NULL,
    CONSTRAINT [PK_Portfolio] PRIMARY KEY CLUSTERED ([StockId] ASC, [UserId] ASC),
    CONSTRAINT [FK_Portfolio_Stock] FOREIGN KEY ([StockId]) REFERENCES [dbo].[Stock] ([ID]),
    CONSTRAINT [FK_Portfolio_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([ID])
);

