--更新报销状态存储过程
CREATE PROCEDURE UpdateExpenseStatus
    @ExpenseID INT,
    @NewStatus NVARCHAR(50)
AS
BEGIN
    -- 更新报销记录的状态
    UPDATE Expenses
    SET Status = @NewStatus
    WHERE ExpenseID = @ExpenseID;
END;
