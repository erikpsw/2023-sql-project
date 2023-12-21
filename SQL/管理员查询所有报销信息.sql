CREATE PROCEDURE get_all_expense
AS
BEGIN
    SELECT Expenses.ExpenseID AS ID,
           Projects.ProjectName AS ��Ŀ����,
           Users.FullName AS ������,
           ExpenseCategories.CategoryName AS �������,
           Expenses.Amount AS ���,
           Expenses.Note AS ��ע,
           Expenses.SubmitTime AS �ύʱ��,
           Expenses.[Status] AS ״̬,
           Users_Approver.FullName AS ��׼��,
           ApprovalTime AS ��׼ʱ��
    FROM Expenses
    INNER JOIN Projects ON Expenses.ProjectID = Projects.ProjectID
    INNER JOIN ExpenseCategories ON Expenses.CategoryID = ExpenseCategories.CategoryID
    INNER JOIN Users ON Expenses.UserID = Users.UserID
    INNER JOIN Users AS Users_Approver ON Expenses.ApproverID = Users_Approver.UserID
END;

-- EXEC get_all_expense