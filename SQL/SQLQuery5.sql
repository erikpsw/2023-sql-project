--������Ŀ��Ԥ��洢����
CREATE PROCEDURE UpdateTotalBudget
    @ProjectID INT,
    @NewTotalBudget DECIMAL
AS
BEGIN
    -- ������Ŀ���е���Ԥ��
    UPDATE Projects
    SET TotalBudget = @NewTotalBudget
    WHERE ProjectID = @ProjectID;
END;
