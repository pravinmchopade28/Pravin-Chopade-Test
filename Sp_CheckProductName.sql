USE [Test]
GO
/****** Object:  StoredProcedure [dbo].[Sp_CheckTaxName]    Script Date: 5/28/2020 3:04:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[Sp_CheckProductName]
(
    @ProductName NVARCHAR(300)
)
AS  
BEGIN TRY
  
SET NOCOUNT ON   
  
BEGIN  
			SELECT *from tblProductDetails
			WHERE ProductName = @ProductName

END  

END TRY
BEGIN CATCH
	DECLARE @ERRPROCEDURE VARCHAR(500),@ERRMESSAGE VARCHAR(500),@ERRLNNO VARCHAR(10)
	SET @ERRPROCEDURE=ERROR_PROCEDURE()
	SET @ERRMESSAGE=ERROR_MESSAGE()
	SET @ERRLNNO=ERROR_LINE()
END CATCH
