--��������ʱ����ʣ�������
ALTER TRIGGER UpdateRemainingAmount
ON Expenses
AFTER UPDATE
AS
BEGIN
    IF UPDATE(Status) AND (SELECT Status FROM INSERTED) = 'Approved'
    BEGIN
        -- ��������¼������ʱ��������Ŀ���е�ʣ����
        UPDATE Projects
        SET RemainingAmount = RemainingAmount - (SELECT Amount FROM INSERTED)
        WHERE ProjectID = (SELECT ProjectID FROM INSERTED);
    END
END;
