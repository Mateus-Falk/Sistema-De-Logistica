CREATE TRIGGER TGR_UPDATE_QUANTITY
ON dbo.InOut
AFTER INSERT
AS
BEGIN
    DECLARE
    @QUANTITY  int,
    @ID  int,
	@INOUT int

    SELECT @QUANTITY = Quantity, @ID = ProductId, @INOUT = InOrOut FROM INSERTED
	
    UPDATE dbo.Product SET QuantityStock = CASE WHEN @InOut = 0 Then QuantityStock + @QUANTITY
												WHEN @InOut = 1 Then QuantityStock - @QUANTITY
												ELSE @INOUT END
    WHERE Id = @ID
END
GO
