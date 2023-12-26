CREATE VIEW view_all_expense AS
SELECT Expenses.ExpenseID AS ID,
       Projects.ProjectName AS ��Ŀ����,
       Users.FullName AS ������,
       ExpenseCategories.CategoryName AS �������,
       Expenses.Amount AS ���,
       Expenses.Note AS ��ע,
       Expenses.SubmitTime AS �ύʱ��,
       Expenses.[Status] AS ״̬,
       ApproverID AS ��׼��ID,
       ApprovalTime AS ��׼ʱ��
FROM Expenses
INNER JOIN Projects ON Expenses.ProjectID = Projects.ProjectID
INNER JOIN ExpenseCategories ON Expenses.CategoryID = ExpenseCategories.CategoryID
INNER JOIN Users ON Expenses.UserID = Users.UserID;