CREATE TABLE [dbo].[Stock] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Symbol]      NVARCHAR (10)  NULL,
    [LastPrice]   FLOAT (53)     NULL,
    [CompanyName] NVARCHAR (100) NULL,
    CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED ([ID] ASC)
);

