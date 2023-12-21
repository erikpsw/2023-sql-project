--删除项目及其相关数据存储过程
CREATE PROCEDURE DeleteProject
    @ProjectID INT
AS
BEGIN
    -- 删除项目及其相关数据
    DELETE FROM Expenses WHERE ProjectID = @ProjectID;
    DELETE FROM Projects WHERE ProjectID = @ProjectID;
END;
