-------------------------------------------------
-- Task # 1
-- Write a query to return shipper performance
-- This will tell us how much we're using each shipper
-- Tables involved: StoreSample database. Shippers, Orders, and OrderDetails tables
-- No Discount for TotalCostShipped
-- Desired output:
SELECT SH.companyname CompanyName, 
	SUM(ORD.FREIGHT) TotalFreight, 
	SUM((OD.unitprice * OD.qty) /** (1 - OD.discount)*/) TotalCostShipped,
	SUM(OD.QTY) TotalItemsShipped
FROM Sales.Shippers SH
	JOIN Sales.Orders ORD ON SH.shipperid = ORD.shipperid
	JOIN Sales.OrderDetails OD ON ORD.orderid = OD.orderid
GROUP BY SH.shipperid, SH.companyname
ORDER BY 4 DESC

-------------------------------------------------------
-- Task # 2
-- Write a query to return customer habit information
-- Base the next purchase date on an average of days between orders
-- Tables involved: StoreSample database. Orders, Customers
-- Desired output:
SELECT CU.companyname CustomerName, 
	MAX(ORD.ORDERDATE) LastOrderDate,
	DATEADD(DAY, DATEDIFF(DAY, MIN(ORD.ORDERDATE), MAX(ORD.ORDERDATE)) / COUNT(ORD.ORDERID), MAX(ORD.ORDERDATE))
FROM Sales.Customers CU
	JOIN Sales.Orders ORD ON CU.custid = ORD.custid
GROUP BY CU.custid,CU.companyname
ORDER BY CU.companyname