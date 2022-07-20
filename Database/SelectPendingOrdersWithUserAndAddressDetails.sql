CREATE PROCEDURE GetPendingDetailss
AS(
	SELECT u.[ID] as 'Order ID', u.[FirstName], u.[LastName], a.[Name] as "Delivery Address"
	FROM [Order] as o
		INNER JOIN [AspNetUsers] as u
		ON u.ID=o.UserID
			INNER JOIN [Address] as a
			ON a.[ID]=o.AddressID
	WHERE o.Status = 'Pending') 

Exec GetPendingDetailss