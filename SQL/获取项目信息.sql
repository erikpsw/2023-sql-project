
ALTER PROCEDURE get_project
    @_ProjectID text
AS
BEGIN
    select TotalBudget,RemainingAmount from Projects
    WHERE ProjectID like @_ProjectID
END;