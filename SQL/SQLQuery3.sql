--��������ʱ����ʣ�������
CREATE TRIGGER UpdateRemainingAmount
ON Expenses
AFTER UPDATE
AS
BEGIN
    -- ��������¼������ʱ��������Ŀ���е�ʣ����
    UPDATE Projects
    SET RemainingAmount = RemainingAmount - (SELECT Amount FROM INSERTED)
    WHERE ProjectID = (SELECT ProjectID FROM INSERTED);
END;
