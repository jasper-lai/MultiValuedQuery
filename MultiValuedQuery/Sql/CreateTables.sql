USE MyCookies1;
GO
-- ===========================
-- ²¾°£ Table
-- ===========================
DROP TABLE IF EXISTS [dbo].[Products];
GO
DROP TABLE IF EXISTS [dbo].[Categories]
GO
-- ===========================
-- «Ø¥ß Table
-- ===========================
CREATE TABLE [dbo].[Categories]
( [Id]              INT							NOT NULL
, [Name]            NVARCHAR(30)				NOT NULL
CONSTRAINT PK_Catgories PRIMARY KEY ( [Id] )
);
GO
CREATE TABLE [dbo].[Products]
( [Id]				INT							NOT NULL
, [Name]            NVARCHAR(30)				NOT NULL
, [CategoryId]		INT							NOT NULL
, [Price]           INT							NOT NULL
  CONSTRAINT PK_Products PRIMARY KEY ( [Id] )
, CONSTRAINT FK_Categories FOREIGN KEY ( [CategoryId] )
                           REFERENCES [dbo].[Categories] ( [Id] )
);
GO
-- ===========================
-- ·s¼W´ú¸Õ¸ê®Æ
-- ===========================
INSERT INTO [dbo].[Categories]
VALUES ( 1, N'»æ°®Ãþ' )
,      ( 2, N'³J¿|Ãþ' )
,      ( 3, N'¥¤¹TÃþ' )
;
GO
INSERT INTO [dbo].[Products]
VALUES ( 1, N'®L«Â¦i¨§¶ð', 1, 50 )
,      ( 2, N'°íªG¶ð', 1, 55 )
,      ( 3, N'¾i¥Í°íªG', 1, 60 )
,      ( 4, N'¨Å¹T¶ð', 1, 60 )
,      ( 5, N'¬õ¨§¶ð', 1, 60 )
,      ( 6, N'¯ó²ù¶ð', 1, 65 )
,      ( 7, N'»´¨Å¹T³J¿|(¤ù)', 2, 65 )
,      ( 8, N'­«¨Å¹T³J¿|(¤ù)', 2, 70 )
,      ( 9, N'©Ù¯ù¥¤¹T', 3, 90 )
,      ( 10, N'¯ó²ù¥¤¹T', 3, 85 )
,      ( 11, N'¨~ªG¥¤¹T', 3, 85 )
,      ( 12, N'¬õ¨§¥¤¹T', 3, 80 )
;
GO

CREATE OR ALTER VIEW [dbo].[ViewProducts]
AS
SELECT		ProductId		= P.Id
	,		ProductName		= P.Name
	,		CategoryId		= P.CategoryId
	,		Price			= P.Price
	,		CategoryName	= C.Name
FROM		dbo.Products	P
LEFT JOIN	dbo.Categories  C	ON ( P.CategoryId = C.Id )
;
GO