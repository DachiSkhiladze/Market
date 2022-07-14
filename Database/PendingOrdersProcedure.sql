/****** Script for SelectTopNRows command from SSMS  ******/
CREATE PROCEDURE PendingOrders
AS
(SELECT TOP (1000) [ID]
      ,[Status]
      ,[AddressID]
      ,[UserID]
      ,[CreatedAt]
      ,[CreatedBy]
      ,[ModifiedAt]
      ,[ModifiedBy]
  FROM [Market].[dbo].[Order]
  WHERE [Status] = 'Pending')
  Go

 EXEC PendingOrders;