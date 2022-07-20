CREATE PROCEDURE GetCompletedOrdersWithDetailsFromLastMonth
AS(
	SELECT u.[ID] as 'Order ID', u.[FirstName], u.[LastName], a.[Name] as "Delivery Address"
	FROM [Order] as o
		INNER JOIN [AspNetUsers] as u
		ON u.ID=o.UserID
			INNER JOIN [Address] as a
			ON a.[ID]=o.AddressID
	WHERE o.Status = 'Completed' AND DATEDIFF(MONTH, o.ModifiedAt, GETDATE()) < 1) 
Go

Exec GetCompletedOrdersWithDetailsFromLastMonth