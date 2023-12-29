USE [Test]
GO

/****** Object:  StoredProcedure [dbo].[Update_Item_Display_Pend ]    Script Date: 2023/12/29 ¤W¤È 09:58:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Update_Item_Display_Pend ]
	@Date			DateTime
AS

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
BEGIN TRANSACTION

INSERT INTO [dbo].[item_display_pend] (order_date, item_code)
(SELECT a.order_date, a.item_code FROM [dbo].[item_order] as a
left Join [dbo].[item_display] as b
on a.item_code = b.item_code
WHERE a.order_date = @Date and b.item_code is null)

COMMIT TRANSACTION	
GO


