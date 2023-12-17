-- 插入用户数据
-- 调用添加用户存储过程
EXEC AddUser
    @UserID = 'A123456789',  -- 以大写字母开头，后跟 10 位数字
    @Password = 'P123456789',
    @Fullname = '张三',
    @Telephone = '12345678901',
    @Email = 'zhangsan@example.com';
	
EXEC [dbo].[AddUser]
    @UserID = 'B234567890',
    @Password = 'P234567890',
    @Fullname = '李四',
    @Telephone = '98765432109',
    @Email = 'lisi@example.com';

-- 添加更多用户数据...

go

-- 插入管理员数据
INSERT INTO Admins (AdminID)
VALUES
('A123456789')
-- 添加更多管理员数据...

-- 插入项目数据
INSERT INTO Projects (ProjectID, ProjectName, TotalBudget, RemainingAmount)
VALUES
(1, '项目A', 100000, 100000),
(2, '项目B', 50000, 50000);
-- 添加更多项目数据...

-- 插入报销类别数据
INSERT INTO ExpenseCategories (CategoryID, CategoryName)
VALUES
(1, '交通费'),
(2, '餐饮费');
-- 添加更多报销类别数据...

-- 插入报销数据
INSERT INTO Expenses (ExpenseID, ProjectID, UserID, CategoryID, Amount, SubmitTime, Note, Status, ApproverID, ApprovalTime)
VALUES
(1, 1, 'A123456789', 1, 5000, '2023-01-01', '交通费报销', 'Pending', 'A123456789', '2023-01-03'),
(2, 1, 'B234567890', 2, 2000, '2023-01-02', '餐饮费报销', 'Approved','A123456789', '2023-01-03');
-- 添加更多报销数据...
