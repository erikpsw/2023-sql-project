--报销申请存储过程
Alter PROCEDURE SubmitExpense
    @ProjectID varchar(50),
    @UserID varchar(50),
    @CategoryID varchar(50),
    @Amount DECIMAL,
    @SubmitTime DATETIME,
    @Note text
AS
BEGIN
    -- 提交报销申请，将状态设置为待审批
    DECLARE @MAXID INT;
    SELECT @MAXID = MAX(CAST(ExpenseID AS INT)) FROM Expenses;
    Print @MAXID;
	INSERT INTO Expenses (ExpenseID,ProjectID, UserID, CategoryID, Amount, SubmitTime, Note, Status)
    VALUES (@MAXID+1,@ProjectID, @UserID, @CategoryID, @Amount, @SubmitTime, @Note, 'Pending');
END;


Exec SubmitExpense 1,'A123456789',1,111,'2023-01-06 00:00:00.000','测试'
