USE [Test]
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetTaxMaster]    Script Date: 5/28/2020 9:44:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create PROCEDURE [dbo].[Sp_ModifyProduct]
(
	@PARAM_Result INT OUTPUT,  
	@ProductID BIGINT = 0,
	@ProductName nvarchar(MAX),
	@Price decimal(18,3),
	@IsGSTApplicable bit,
	@PurchaseDate date,
	@ExpireDate date,
	@Color nvarchar(100)
	
)

AS  
  
SET NOCOUNT ON   
  
BEGIN  

IF EXISTS (SELECT 1  FROM tblProductDetails WHERE ProductID = @ProductID)

BEGIN
		UPDATE tblProductDetails
		                 SET
								ProductName=@ProductName,
								Price=@Price,
								IsGSTApplicable=@IsGSTApplicable,
								PurchaseDate=@PurchaseDate,
								[ExpireDate]=@ExpireDate,
								Color=@Color
						  
									  WHERE ProductID = @ProductID

        SET @PARAM_Result = 2
END

ELSE 
BEGIN
			
		 INSERT INTO tblProductDetails(

								ProductName,
								Price,
								IsGSTApplicable,
								PurchaseDate,
								[ExpireDate],
								Color


								   )
						VALUES(
								@ProductName,
								@Price,
								@IsGSTApplicable,
								@PurchaseDate,
								@ExpireDate,
								@Color

								)

								SET	@PARAM_Result = 1
			                        PRINT @PARAM_Result
END 

END 

