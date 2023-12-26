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
    -- 检查提供的UserID是否符合格式要求
    IF @UserID LIKE '[A-Z][0-9][0-9][0-9][0-9][0-9][0-9]'
   OR @UserID LIKE '[A-Z][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
   OR @UserID LIKE '[A-Z][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
   OR @UserID LIKE '[A-Z][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
   OR @UserID LIKE '[A-Z][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
    BEGIN
        select ExpenseID as ID,ProjectName as 项目名称,CategoryName as 报销类别,Amount as 金额,Note as 备注,[Status] as 状态,
        CASE WHEN image IS NULL THEN 0 ELSE 1 END as 是否上传附件  
        from Expenses,Projects,ExpenseCategories 
        WHERE UserID=@UserID AND Expenses.CategoryID=ExpenseCategories.CategoryID AND Expenses.ProjectID=Projects.ProjectID
    END
    ELSE
    BEGIN
        -- 提供的UserID不符合格式要求，可选择抛出错误或采取其他处理方式
        RAISERROR('UserID格式不正确，请提供以大写字母开头，后跟6到10位数字的UserID。', 16, 1);
    END
END;