-- ��¼�洢����
-- ALTER PROCEDURE get_expense
--     @UserID varchar(50)
-- AS
-- BEGIN
--     -- ����ṩ��UserID�Ƿ���ϸ�ʽҪ��
--     IF PATINDEX('[A-Z][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]', @UserID) = 1
--     BEGIN
--         select ExpenseID as ID,ProjectName as ��Ŀ����,CategoryName as �������,Amount as ���,Note as ��ע,[Status] as ״̬ from Expenses,Projects,ExpenseCategories 
--         WHERE UserID=@UserID AND Expenses.CategoryID=ExpenseCategories.CategoryID AND Expenses.ProjectID=Projects.ProjectID
--     END
--     ELSE
--     BEGIN
--         -- �ṩ��UserID�����ϸ�ʽҪ�󣬿�ѡ���׳�������ȡ��������ʽ
--         RAISERROR('UserID��ʽ����ȷ�����ṩ�Դ�д��ĸ��ͷ�����6��10λ���ֵ�UserID��', 16, 1);
--     END
-- END;

EXEC get_expense A123456789
