--更新项目总预算时触发器，确保总预算不小于已使用金额
CREATE TRIGGER CheckTotalBudget
ON Projects
AFTER UPDATE
AS
BEGIN
    -- 确保总预算不小于已使用金额
    UPDATE p
    SET TotalBudget = d.TotalBudget
    FROM Projects p
    JOIN DELETED d ON p.ProjectID = d.ProjectID
    WHERE p.TotalBudget < (SELECT SUM(e.Amount) FROM Expenses e WHERE e.ProjectID = d.ProjectID);
END;
