USE [account]
GO
/****** Object:  StoredProcedure [dbo].[UpdateExpenseStatus_Disapproved]    Script Date: 2023/12/26 15:28:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- 更新报销状态存储过程
ALTER PROCEDURE [dbo].[UpdateExpenseStatus_Disapproved]
    @ExpenseID INT,
    @AdminID   VARCHAR(50),
    @ApprovalTime DATE
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;  -- 开始事务

        -- 更新报销记录的状态
        UPDATE Expenses
        SET Status = 'Disapproved', ApprovalTime = @ApprovalTime, ApproverID = @AdminID
        WHERE ExpenseID = @ExpenseID;

        -- 如果更新成功，则提交事务
        COMMIT;
    END TRY
    BEGIN CATCH
        -- 发生错误时回滚事务
        ROLLBACK;

        -- 输出错误信息
        SELECT ERROR_MESSAGE() AS ErrorMessage;
    END CATCH;
END;
    
