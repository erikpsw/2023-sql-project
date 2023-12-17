--��������洢����
CREATE PROCEDURE SubmitExpense
    @ProjectID INT,
    @UserID INT,
    @CategoryID INT,
    @Amount DECIMAL,
    @SubmitTime DATETIME,
    @Note NVARCHAR(255)
AS
BEGIN
    -- �ύ�������룬��״̬����Ϊ������
    INSERT INTO Expenses (ProjectID, UserID, CategoryID, Amount, SubmitTime, Note, Status)
    VALUES (@ProjectID, @UserID, @CategoryID, @Amount, @SubmitTime, @Note, 'Pending');
END;
