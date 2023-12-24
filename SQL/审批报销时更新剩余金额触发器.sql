--审批报销时更新剩余金额触发器
ALTER TRIGGER [dbo].[UpdateRemainingAmount]
ON [dbo].[Expenses]
AFTER UPDATE
AS
BEGIN TRY
    -- 当报销记录被更新时，更新项目表中的剩余金额
    UPDATE Projects
    SET RemainingAmount = RemainingAmount - (SELECT Amount FROM INSERTED)
    WHERE ProjectID = (SELECT ProjectID FROM INSERTED);
END Try
BEGIN CATCH
    -- 发生错误时回滚事务
    ROLLBACK;
END CATCH;
