USE [account]
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 2023/12/25 18:25:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- 更新用户存储过程
ALTER PROCEDURE [dbo].[AddUser]
    @UserID varchar(50),
    @Password varchar(50),
    @Fullname text,
    @Telephone nchar(11),
    @Email varchar(50)
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
            -- 检查提供的Email是否符合格式要求
            IF CHARINDEX('@', @Email) > 0
                AND CHARINDEX('.', @Email, CHARINDEX('@', @Email) + 1) > 0
            BEGIN
                IF NOT EXISTS (SELECT 1 FROM Users WHERE UserID = @UserID)
                BEGIN
                    -- 插入新用户记录
                    INSERT INTO Users (UserID, Password, Fullname, Telephone, Email)
                    VALUES (@UserID, @Password, @Fullname, @Telephone, @Email);
                END
                ELSE
                BEGIN
                    -- 提供的UserID已存在，可选择抛出错误或采取其他处理方式
                    RAISERROR('提供的UserID已存在，请选择其他UserID。', 16, 1);
                END
            END
            ELSE
            BEGIN
                -- 提供的Email不符合格式要求，可选择抛出错误或采取其他处理方式
                RAISERROR('Email格式不正确，请提供有效的Email地址。', 16, 1);
            END
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
