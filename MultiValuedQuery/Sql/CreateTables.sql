USE MyCookies1;
GO
-- ===========================
-- ���� Table
-- ===========================
DROP TABLE IF EXISTS [dbo].[Products];
GO
DROP TABLE IF EXISTS [dbo].[Categories]
GO
-- ===========================
-- �إ� Table
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
-- �s�W���ո��
-- ===========================
INSERT INTO [dbo].[Categories]
VALUES ( 1, N'�氮��' )
,      ( 2, N'�J�|��' )
,      ( 3, N'���T��' )
;
GO
INSERT INTO [dbo].[Products]
VALUES ( 1, N'�L�¦i����', 1, 50 )
,      ( 2, N'��G��', 1, 55 )
,      ( 3, N'�i�Ͱ�G', 1, 60 )
,      ( 4, N'�ŹT��', 1, 60 )
,      ( 5, N'������', 1, 60 )
,      ( 6, N'�����', 1, 65 )
,      ( 7, N'���ŹT�J�|(��)', 2, 65 )
,      ( 8, N'���ŹT�J�|(��)', 2, 70 )
,      ( 9, N'�ٯ����T', 3, 90 )
,      ( 10, N'������T', 3, 85 )
,      ( 11, N'�~�G���T', 3, 85 )
,      ( 12, N'�������T', 3, 80 )
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