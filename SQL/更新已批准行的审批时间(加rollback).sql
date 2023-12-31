ALTER TRIGGER [dbo].[ApproveExpense]
ON [dbo].[Expenses]
AFTER UPDATE
AS
BEGIN
   -- 检查是否有状态从未批准变为已批准的行
    IF (SELECT COUNT(*) FROM INSERTED WHERE Status = 'Approved') > 0
    BEGIN
        -- 更新已批准行的审批时间
        UPDATE e
        SET ApprovalTime = GETDATE()
        FROM Expenses e
        INNER JOIN INSERTED i ON e.ExpenseID = i.ExpenseID
        WHERE e.Status = 'Approved' AND i.Status = 'Approved';
    END;
	else
	begin
	-- 如果没有状态从未批准变为已批准的行，则回滚事务
        ROLLBACK;
	end;
END;
