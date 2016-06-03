CREATE TABLE [dbo].[bStockHistory] (
    [Id]              INT        IDENTITY (1, 1) NOT NULL,
    [bStockId]        INT        NOT NULL,
    [ObservationTime] DATETIME   NULL,
    [Price]           FLOAT (53) NULL,
    [IsEod]           BIT        DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_StockHisotry] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_bStockHistory_bStock] FOREIGN KEY ([bStockId]) REFERENCES [dbo].[bStock] ([ID])
);

