CREATE TABLE [dbo].[TransactionLog] (
    [Id]              INT        IDENTITY (1, 1) NOT NULL,
    [StockId]         INT        NULL,
    [Quantity]        INT        NULL,
    [Price]           FLOAT (53) NULL,
    [Purchased]       BIT        NULL,
    [TransactionDate] DATETIME   NULL,
    CONSTRAINT [PK_TransactionLog] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TransactionLog_Stock] FOREIGN KEY ([StockId]) REFERENCES [dbo].[Stock] ([ID])
);

