CREATE TABLE [dbo].[Cars]
(
	[BrandId] INT NOT NULL PRIMARY KEY, 
    [ ColorId] INT NULL, 
    [ModelYear] NCHAR(10) NULL, 
    [DailyPrice] INT NULL, 
    [Description] NCHAR(10) NULL
)