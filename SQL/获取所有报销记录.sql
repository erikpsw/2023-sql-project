-- 登录存储过程
-- ALTER PROCEDURE get_expense
--     @UserID varchar(50)
-- AS
-- BEGIN
--     -- 检查提供的UserID是否符合格式要求
--     IF PATINDEX('[A-Z][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]', @UserID) = 1
--     BEGIN
--         select ExpenseID as ID,ProjectName as 项目名称,CategoryName as 报销类别,Amount as 金额,Note as 备注,[Status] as 状态 from Expenses,Projects,ExpenseCategories 
--         WHERE UserID=@UserID AND Expenses.CategoryID=ExpenseCategories.CategoryID AND Expenses.ProjectID=Projects.ProjectID
--     END
--     ELSE
--     BEGIN
--         -- 提供的UserID不符合格式要求，可选择抛出错误或采取其他处理方式
--         RAISERROR('UserID格式不正确，请提供以大写字母开头，后跟6到10位数字的UserID。', 16, 1);
--     END
-- END;

EXEC get_expense A123456789
