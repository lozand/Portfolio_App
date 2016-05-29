CREATE TABLE [dbo].[StockHistory] (
    [Id]              INT        IDENTITY (1, 1) NOT NULL,
    [StockId]         INT        NOT NULL,
    [ObservationTime] DATETIME   NULL,
    [Price]           FLOAT (53) NULL,
    [IsEod]           BIT        DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_StockHisotry] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_StockHistory_Stock] FOREIGN KEY ([StockId]) REFERENCES [dbo].[Stock] ([ID])
);

