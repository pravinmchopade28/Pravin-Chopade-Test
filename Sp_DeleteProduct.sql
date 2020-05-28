USE [Test]
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetTaxMaster]    Script Date: 5/28/2020 9:44:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create PROCEDURE [dbo].[Sp_DeleteProduct]
(
    @ProductID BIGINT = 0
)
AS  
  
SET NOCOUNT ON   
  
BEGIN  
     delete From tblProductDetails
			WHERE(ProductID = @ProductID)

END  

