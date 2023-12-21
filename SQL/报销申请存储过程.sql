--��������洢����
Alter PROCEDURE SubmitExpense
    @ProjectID varchar(50),
    @UserID varchar(50),
    @CategoryID varchar(50),
    @Amount DECIMAL,
    @SubmitTime DATETIME,
    @Note text
AS
BEGIN
    -- �ύ�������룬��״̬����Ϊ������
    DECLARE @MAXID INT;
    SELECT @MAXID = MAX(CAST(ExpenseID AS INT)) FROM Expenses;
    Print @MAXID;
	INSERT INTO Expenses (ExpenseID,ProjectID, UserID, CategoryID, Amount, SubmitTime, Note, Status)
    VALUES (@MAXID+1,@ProjectID, @UserID, @CategoryID, @Amount, @SubmitTime, @Note, 'Pending');
END;


Exec SubmitExpense 1,'A123456789',1,111,'2023-01-06 00:00:00.000','����'
