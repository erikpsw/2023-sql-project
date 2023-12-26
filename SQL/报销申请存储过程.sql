USE [account]
GO
/****** Object:  StoredProcedure [dbo].[SubmitExpense]    Script Date: 2023/12/26 16:06:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--��������洢����
ALTER PROCEDURE [dbo].[SubmitExpense]
    @ProjectID int,
    @UserID varchar(50),
    @CategoryID int,
    @Amount DECIMAL,
    @SubmitTime DATETIME,
    @Note text,
	@Image varBinary(MAX)
AS
BEGIN
    -- �ύ�������룬��״̬����Ϊ������
    DECLARE @MAXID INT;
    SELECT @MAXID = MAX(ExpenseID) FROM Expenses;
    Print @MAXID;
	INSERT INTO Expenses (ExpenseID,ProjectID, UserID, CategoryID, Amount, SubmitTime, Note, Status,image)
    VALUES (@MAXID+1,@ProjectID, @UserID, @CategoryID, @Amount, @SubmitTime, @Note, 'Pending',@Image);
END;



