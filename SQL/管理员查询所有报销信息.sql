CREATE PROCEDURE get_all_expense
AS
BEGIN
    SELECT Expenses.ExpenseID AS ID,
           Projects.ProjectName AS 项目名称,
           Users.FullName AS 报销人,
           ExpenseCategories.CategoryName AS 报销类别,
           Expenses.Amount AS 金额,
           Expenses.Note AS 备注,
           Expenses.SubmitTime AS 提交时间,
           Expenses.[Status] AS 状态,
           Users_Approver.FullName AS 批准人,
           ApprovalTime AS 批准时间
    FROM Expenses
    INNER JOIN Projects ON Expenses.ProjectID = Projects.ProjectID
    INNER JOIN ExpenseCategories ON Expenses.CategoryID = ExpenseCategories.CategoryID
    INNER JOIN Users ON Expenses.UserID = Users.UserID
    INNER JOIN Users AS Users_Approver ON Expenses.ApproverID = Users_Approver.UserID
END;

-- EXEC get_all_expense