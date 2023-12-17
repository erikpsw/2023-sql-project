--������Ŀ��Ԥ��ʱ��������ȷ����Ԥ�㲻С����ʹ�ý��
CREATE TRIGGER CheckTotalBudget
ON Projects
AFTER UPDATE
AS
BEGIN
    -- ȷ����Ԥ�㲻С����ʹ�ý��
    UPDATE p
    SET TotalBudget = d.TotalBudget
    FROM Projects p
    JOIN DELETED d ON p.ProjectID = d.ProjectID
    WHERE p.TotalBudget < (SELECT SUM(e.Amount) FROM Expenses e WHERE e.ProjectID = d.ProjectID);
END;
