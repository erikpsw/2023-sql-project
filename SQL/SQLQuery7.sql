--���±���״̬�洢����
CREATE PROCEDURE UpdateExpenseStatus
    @ExpenseID INT,
    @NewStatus NVARCHAR(50)
AS
BEGIN
    -- ���±�����¼��״̬
    UPDATE Expenses
    SET Status = @NewStatus
    WHERE ExpenseID = @ExpenseID;
END;
