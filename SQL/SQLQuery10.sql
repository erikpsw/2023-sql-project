-- �����û�����
-- ��������û��洢����
EXEC AddUser
    @UserID = 'A123456789',  -- �Դ�д��ĸ��ͷ����� 10 λ����
    @Password = 'P123456789',
    @Fullname = '����',
    @Telephone = '12345678901',
    @Email = 'zhangsan@example.com';
	
EXEC [dbo].[AddUser]
    @UserID = 'B234567890',
    @Password = 'P234567890',
    @Fullname = '����',
    @Telephone = '98765432109',
    @Email = 'lisi@example.com';

-- ��Ӹ����û�����...

go

-- �������Ա����
INSERT INTO Admins (AdminID)
VALUES
('A123456789')
-- ��Ӹ������Ա����...

-- ������Ŀ����
INSERT INTO Projects (ProjectID, ProjectName, TotalBudget, RemainingAmount)
VALUES
(1, '��ĿA', 100000, 100000),
(2, '��ĿB', 50000, 50000);
-- ��Ӹ�����Ŀ����...

-- ���뱨���������
INSERT INTO ExpenseCategories (CategoryID, CategoryName)
VALUES
(1, '��ͨ��'),
(2, '������');
-- ��Ӹ��౨���������...

-- ���뱨������
INSERT INTO Expenses (ExpenseID, ProjectID, UserID, CategoryID, Amount, SubmitTime, Note, Status, ApproverID, ApprovalTime)
VALUES
(1, 1, 'A123456789', 1, 5000, '2023-01-01', '��ͨ�ѱ���', 'Pending', 'A123456789', '2023-01-03'),
(2, 1, 'B234567890', 2, 2000, '2023-01-02', '�����ѱ���', 'Approved','A123456789', '2023-01-03');
-- ��Ӹ��౨������...
