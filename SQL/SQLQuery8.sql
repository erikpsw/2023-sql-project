--删除用户时级联删除相关报销记录触发器
CREATE TRIGGER CascadeDeleteUser
ON Users
AFTER DELETE
AS
BEGIN
    -- 级联删除相关报销记录
    DELETE FROM Expenses
    WHERE UserID IN (SELECT UserID FROM DELETED);
END;
