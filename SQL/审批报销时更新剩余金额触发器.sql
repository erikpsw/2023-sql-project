USE [account]
GO
/****** Object:  Trigger [dbo].[UpdateRemainingAmount]    Script Date: 2023/12/26 14:38:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--审批报销时更新剩余金额触发器
ALTER TRIGGER [dbo].[UpdateRemainingAmount]
ON [dbo].[Expenses]
AFTER UPDATE
AS
BEGIN TRY
    -- 当报销记录被更新时，更新项目表中的剩余金额
    UPDATE P
    SET P.RemainingAmount = 
        CASE 
            WHEN I.Status = 'Approved' THEN P.RemainingAmount - I.Amount
            WHEN I.Status = 'Disapproved' THEN P.RemainingAmount
            ELSE P.RemainingAmount  -- 可选的默认操作，可以根据实际情况调整
        END
    FROM Projects P
    INNER JOIN INSERTED I ON P.ProjectID = I.ProjectID;
END TRY
BEGIN CATCH
    -- 发生错误时回滚事务
    ROLLBACK;
END CATCH;

