USE [account]
GO
/****** Object:  StoredProcedure [dbo].[login]    Script Date: 2023/12/25 18:25:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[login]
    @UserID varchar(50),
    @Password varchar(50)
AS
BEGIN
    -- ����ṩ��UserID�Ƿ���ϸ�ʽҪ��
    IF @UserID LIKE '[A-Z][0-9][0-9][0-9][0-9][0-9][0-9]'
   OR @UserID LIKE '[A-Z][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
   OR @UserID LIKE '[A-Z][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
   OR @UserID LIKE '[A-Z][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
   OR @UserID LIKE '[A-Z][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
 
    BEGIN
        -- ����ṩ��Password�Ƿ���ϸ�ʽҪ��
        IF @Password LIKE '[A-Z][0-9][0-9][0-9][0-9][0-9][0-9]'
           OR @Password LIKE '[A-Z][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
           OR @Password LIKE '[A-Z][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
           OR @Password LIKE '[A-Z][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
           OR @Password LIKE '[A-Z][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' 
        BEGIN
            IF EXISTS(select * from Users where UserID=@UserID and [Password]=@Password)
                SELECT 1 as res,Fullname,Telephone,Email FROM Users WHERE UserID=@UserID
            ELSE 
                SELECT 0 as res
        END
        ELSE
        BEGIN
            -- �ṩ��Password�����ϸ�ʽҪ�󣬿�ѡ���׳�������ȡ��������ʽ
            RAISERROR('Password��ʽ����ȷ�����ṩ�Դ�д��ĸ��ͷ�����6��10λ���ֵ�Password��', 16, 1);
        END
    END
    ELSE
    BEGIN
        -- �ṩ��UserID�����ϸ�ʽҪ�󣬿�ѡ���׳�������ȡ��������ʽ
        RAISERROR('UserID��ʽ����ȷ�����ṩ�Դ�д��ĸ��ͷ�����6��10λ���ֵ�UserID��', 16, 1);
    END
END;