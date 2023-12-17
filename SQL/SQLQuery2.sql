--报销申请存储过程
CREATE PROCEDURE SubmitExpense
    @ProjectID INT,
    @UserID INT,
    @CategoryID INT,
    @Amount DECIMAL,
    @SubmitTime DATETIME,
    @Note NVARCHAR(255)
AS
BEGIN
    -- 提交报销申请，将状态设置为待审批
    INSERT INTO Expenses (ProjectID, UserID, CategoryID, Amount, SubmitTime, Note, Status)
    VALUES (@ProjectID, @UserID, @CategoryID, @Amount, @SubmitTime, @Note, 'Pending');
END;
