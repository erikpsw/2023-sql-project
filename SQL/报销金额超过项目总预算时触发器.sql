ALTER TRIGGER [dbo].[CheckBudgetExceed]
ON [dbo].[Expenses]
AFTER INSERT
AS
BEGIN
    -- 检查新报销记录的金额是否超过项目总预算
    DECLARE @ProjectID INT, @Amount DECIMAL;

    SELECT @ProjectID = i.ProjectID, @Amount = i.Amount
    FROM INSERTED i;

    IF (@Amount > (SELECT TotalBudget FROM Projects WHERE ProjectID = @ProjectID))
    BEGIN
        -- 如果超过预算，可以在此处执行相应的处理逻辑
        RAISERROR('报销金额超过项目总预算！',16,1);
		rollback;
    END;
END;
