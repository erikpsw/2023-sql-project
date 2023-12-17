--报销审批通过时更新状态和审批时间触发器
CREATE TRIGGER ApproveExpense
ON Expenses
AFTER UPDATE
AS
BEGIN
    -- 当报销记录的状态被更新为已批准时，更新审批时间
    IF UPDATE(Status) AND (SELECT Status FROM INSERTED) = 'Approved'
    BEGIN
        UPDATE Expenses
        SET ApprovalTime = GETDATE()
        WHERE ExpenseID IN (SELECT ExpenseID FROM INSERTED);
    END;
END;
