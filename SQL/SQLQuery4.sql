--��������ͨ��ʱ����״̬������ʱ�䴥����
CREATE TRIGGER ApproveExpense
ON Expenses
AFTER UPDATE
AS
BEGIN
    -- ��������¼��״̬������Ϊ����׼ʱ����������ʱ��
    IF UPDATE(Status) AND (SELECT Status FROM INSERTED) = 'Approved'
    BEGIN
        UPDATE Expenses
        SET ApprovalTime = GETDATE()
        WHERE ExpenseID IN (SELECT ExpenseID FROM INSERTED);
    END;
END;
