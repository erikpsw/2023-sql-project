USE [account]
GO
/****** Object:  StoredProcedure [dbo].[UpdateExpenseStatus_Disapproved]    Script Date: 2023/12/26 15:28:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ���±���״̬�洢����
ALTER PROCEDURE [dbo].[UpdateExpenseStatus_Disapproved]
    @ExpenseID INT,
    @AdminID   VARCHAR(50),
    @ApprovalTime DATE
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;  -- ��ʼ����

        -- ���±�����¼��״̬
        UPDATE Expenses
        SET Status = 'Disapproved', ApprovalTime = @ApprovalTime, ApproverID = @AdminID
        WHERE ExpenseID = @ExpenseID;

        -- ������³ɹ������ύ����
        COMMIT;
    END TRY
    BEGIN CATCH
        -- ��������ʱ�ع�����
        ROLLBACK;

        -- ���������Ϣ
        SELECT ERROR_MESSAGE() AS ErrorMessage;
    END CATCH;
END;
    
