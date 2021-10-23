# Auto-complete-server

the sql SP is:
ALTER PROCEDURE [dbo].[GetCities] 

	@Characters as varchar(max)
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT *
	FROM Cities
	WHERE name like '%'+ @Characters + '%'
END
