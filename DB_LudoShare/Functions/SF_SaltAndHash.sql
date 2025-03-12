CREATE FUNCTION [dbo].[SF_SaltAndHash]
(
	@password NVARCHAR(64),
	@salt UNIQUEIDENTIFIER
)
RETURNS VARBINARY(64)
AS
BEGIN
	DECLARE @saltedPassword NVARCHAR(68)
	SET @saltedPassword = CONCAT(@password,@salt)
	RETURN HASHBYTES('SHA2_512',@saltedPassword)
END