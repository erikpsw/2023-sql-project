--ɾ����Ŀ����������ݴ洢����
CREATE PROCEDURE DeleteProject
    @ProjectID INT
AS
BEGIN
    -- ɾ����Ŀ�����������
    DELETE FROM Expenses WHERE ProjectID = @ProjectID;
    DELETE FROM Projects WHERE ProjectID = @ProjectID;
END;
