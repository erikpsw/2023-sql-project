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
    -- 检查提供的UserID是否符合格式要求
    IF @UserID LIKE '[A-Z][0-9][0-9][0-9][0-9][0-9][0-9]'
   OR @UserID LIKE '[A-Z][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
   OR @UserID LIKE '[A-Z][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
   OR @UserID LIKE '[A-Z][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
   OR @UserID LIKE '[A-Z][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
 
    BEGIN
        -- 检查提供的Password是否符合格式要求
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
            -- 提供的Password不符合格式要求，可选择抛出错误或采取其他处理方式
            RAISERROR('Password格式不正确，请提供以大写字母开头，后跟6到10位数字的Password。', 16, 1);
        END
    END
    ELSE
    BEGIN
        -- 提供的UserID不符合格式要求，可选择抛出错误或采取其他处理方式
        RAISERROR('UserID格式不正确，请提供以大写字母开头，后跟6到10位数字的UserID。', 16, 1);
    END
END;