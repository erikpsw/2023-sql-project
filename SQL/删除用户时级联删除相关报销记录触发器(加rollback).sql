--删除用户时级联删除相关报销记录触发器
ALTER TRIGGER [dbo].[CascadeDeleteUser]
ON [dbo].[Users]
AFTER DELETE
AS
BEGIN TRY
    -- 级联删除相关报销记录
    DELETE FROM Expenses
    WHERE UserID IN (SELECT UserID FROM DELETED);
END TRY
BEGIN CATCH
    -- 发生错误时回滚事务
    ROLLBACK;
END CATCH;