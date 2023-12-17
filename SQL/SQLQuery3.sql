--审批报销时更新剩余金额触发器
CREATE TRIGGER UpdateRemainingAmount
ON Expenses
AFTER UPDATE
AS
BEGIN
    -- 当报销记录被更新时，更新项目表中的剩余金额
    UPDATE Projects
    SET RemainingAmount = RemainingAmount - (SELECT Amount FROM INSERTED)
    WHERE ProjectID = (SELECT ProjectID FROM INSERTED);
END;
