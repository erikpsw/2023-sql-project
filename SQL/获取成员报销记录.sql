USE [account]
GO
/****** Object:  StoredProcedure [dbo].[get_expense]    Script Date: 2023/12/25 18:26:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[get_expense]
    @UserID varchar(50)
AS
BEGIN
    -- ����ṩ��UserID�Ƿ���ϸ�ʽҪ��
    IF @UserID LIKE '[A-Z][0-9][0-9][0-9][0-9][0-9][0-9]'
   OR @UserID LIKE '[A-Z][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
   OR @UserID LIKE '[A-Z][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
   OR @UserID LIKE '[A-Z][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
   OR @UserID LIKE '[A-Z][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
    BEGIN
        select ExpenseID as ID,ProjectName as ��Ŀ����,CategoryName as �������,Amount as ���,Note as ��ע,[Status] as ״̬,
        CASE WHEN image IS NULL THEN 0 ELSE 1 END as �Ƿ��ϴ�����  
        from Expenses,Projects,ExpenseCategories 
        WHERE UserID=@UserID AND Expenses.CategoryID=ExpenseCategories.CategoryID AND Expenses.ProjectID=Projects.ProjectID
    END
    ELSE
    BEGIN
        -- �ṩ��UserID�����ϸ�ʽҪ�󣬿�ѡ���׳�������ȡ��������ʽ
        RAISERROR('UserID��ʽ����ȷ�����ṩ�Դ�д��ĸ��ͷ�����6��10λ���ֵ�UserID��', 16, 1);
    END
END;