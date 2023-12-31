-- 更新项目总预算时触发器，确保总预算不小于已使用金额
ALTER TRIGGER [dbo].[CheckTotalBudget]
ON [dbo].[Projects]
AFTER UPDATE
AS
BEGIN
    -- 开始事务
    BEGIN TRY
        DECLARE @ProjectID INT;

        -- 获取更新的项目ID
        SELECT @ProjectID = ProjectID FROM INSERTED;

        -- 确保总预算不小于已使用金额
        IF (SELECT TotalBudget FROM Projects WHERE ProjectID = @ProjectID) >=
           (SELECT SUM(Amount) FROM Expenses WHERE ProjectID = @ProjectID)
        BEGIN
            -- 如果满足条件，则更新总预算
            UPDATE p
            SET TotalBudget = d.TotalBudget
            FROM Projects p
            JOIN DELETED d ON p.ProjectID = d.ProjectID
            WHERE p.TotalBudget < (SELECT SUM(e.Amount) FROM Expenses e WHERE e.ProjectID = d.ProjectID);
            commit;
		END
        ELSE
        BEGIN
            -- 如果条件不满足，则回滚事务
            ROLLBACK;
        END;
        -- 提交事务
    END TRY
    BEGIN CATCH
        -- 发生错误时回滚事务
        ROLLBACK;
    END CATCH;
END;
