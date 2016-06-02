


CREATE VIEW dbo.v_CurrentPrices
AS
SELECT 
	s.ID AS StockId,
	s.Symbol AS Symbol,
	s.CompanyName AS CompanyName,
	h.Price AS CurrentPrice
FROM (SELECT 
	s.ID AS StockId,
	MAX(h.ObservationTime) AS MaxObservationTime
FROM Stock s
JOIN STockHistory h on h.StockId = s.ID
GROUP BY s.ID) m
JOIN Stock s on s.ID = m.StockId
JOIN StockHistory h on h.StockId = s.ID AND h.ObservationTime = m.MaxObservationTime