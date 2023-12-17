--更新项目总预算存储过程
CREATE PROCEDURE UpdateTotalBudget
    @ProjectID INT,
    @NewTotalBudget DECIMAL
AS
BEGIN
    -- 更新项目表中的总预算
    UPDATE Projects
    SET TotalBudget = @NewTotalBudget
    WHERE ProjectID = @ProjectID;
END;
