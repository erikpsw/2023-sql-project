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
    IF PATINDEX('[A-Z][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]', @UserID) = 1
    BEGIN
        -- 检查提供的Password是否符合格式要求
        IF PATINDEX('[A-Z][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]', @Password) = 1
        BEGIN
            -- 检查提供的Email是否符合格式要求
            IF CHARINDEX('@', @Email) > 0
                AND CHARINDEX('.', @Email, CHARINDEX('@', @Email) + 1) > 0
            BEGIN
                -- 插入新用户记录
                INSERT INTO Users (UserID, Password, Fullname, Telephone, Email)
                VALUES (@UserID, @Password, @Fullname, @Telephone, @Email);
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
