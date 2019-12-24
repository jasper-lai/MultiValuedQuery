USE MyCookies1;
GO

CREATE TYPE [dbo].[udt_CategoryId] AS TABLE (
    [CategoryId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([CategoryId] ASC));
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE OR ALTER PROCEDURE dbo.usp_GetProductsByCategories
	@tbl_Categories udt_CategoryId READONLY
,	@pi_ProductName NVARCHAR(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT  A.ProductId
	,		A.ProductName
	,		A.CategoryId
	,		A.Price
	,		A.CategoryName
	FROM	ViewProducts		A
	JOIN	@tbl_Categories		B  ON (A.CategoryId = B.CategoryId)
	WHERE   A.ProductName LIKE	'%' + @pi_ProductName + '%'
	;

END

-- -- ============================
-- -- ¥H TSQL ©I¥s
-- -- ============================
-- 
-- DECLARE @tbl_Categories  udt_CategoryId;
-- DECLARE @ls_ProductName NVARCHAR(30) = N'¬õ¨§';
-- 
-- INSERT INTO @tbl_Categories(CategoryId)
-- VALUES	(1)
-- 	,	(2)
-- 	,	(3)
-- 	;
-- 
-- EXEC usp_GetProductsByCategories @tbl_Categories, @ls_ProductName
-- ;
-- 

-- OUTPUT ==========>
-- ProductId	ProductName	CategoryId	Price	CategoryName
-- 5	¬õ¨§¶ð	1	60	»æ°®Ãþ
-- 12	¬õ¨§¥¤¹T	3	80	¥¤¹TÃþ
