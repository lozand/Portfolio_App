CREATE TABLE [dbo].[bStock] (
    [ID]                 INT            IDENTITY (1, 1) NOT NULL,
    [Symbol]             NVARCHAR (10)  NULL,
    [CompanyName]        NVARCHAR (100) NULL,
    [CompanyDescription] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED ([ID] ASC)
);

