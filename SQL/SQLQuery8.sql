--ɾ���û�ʱ����ɾ����ر�����¼������
CREATE TRIGGER CascadeDeleteUser
ON Users
AFTER DELETE
AS
BEGIN
    -- ����ɾ����ر�����¼
    DELETE FROM Expenses
    WHERE UserID IN (SELECT UserID FROM DELETED);
END;
