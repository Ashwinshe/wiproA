-- case study 1
CREATE DATABASE EmployeeDB;
USE EmployeeDB;
CREATE TABLE Employee(
EmpId INT IDENTITY(1, 1) PRIMARY KEY,
EmpName VARCHAR(199) NOT NULL,
Salary INT NOT NULL,
CreateDate DATETIME DEFAULT GETDATE()
);

CREATE PROCEDURE usp_AddEmployee
    @EmpName VARCHAR(100),
    @Salary DECIMAL(10, 2),
    @NewEmpId INT OUTPUT
AS
BEGIN 
   SET NOCOUNT ON;

   INSERT INTO Employee(EmpName, Salary)
   VALUES(@EmpName, @Salary)

   SET @NewEmpId = SCOPE_IDENTITY();
END;

DECLARE @NewId INT;

EXEC dbo.usp_AddEmployee
    @EmpName = 'Ravi Kumar',
    @Salary = 60000,
    @NewEmpId = @NewId OUTPUT;

SELECT @NewId AS NewEmployeeId;

SELECT * FROM Employee;
--- case study 2
ALTER PROCEDURE dbo.usp_AddEmployee
  @EmpName VARCHAR(100),
  @Salary DECIMAL(10, 2),
  @NewEmpID INT OUTPUT

AS 
BEGIN 
   SET NOCOUNT ON;

   IF(@SALARY <= 0) 
   BEGIN 
   RAISERROR('Salary must be greater then zero.', 16, 1);
   RETURN;
   END

   INSERT INTO dbo.Employee(EmpName, Salary)
   VALUES(@EmpName, @Salary)

   SET @NewEmpID = SCOPE_IDENTITY();
END;

DECLARE @NewId INT;

EXEC dbo.usp_AddEmployee
@EmpName = 'Amit verma',
@Salary = 45000,
@NewEmpID = @NewId OUTPUT;

SELECT @NewId AS NewEmployeeId;

DECLARE @NewId INT;

EXEC dbo.usp_AddEmployee
    @EmpName = 'Invalid Salary Test',
    @Salary = 0,
    @NewEmpId = @NewId OUTPUT;
SELECT * FROM Employee;

-- case study 3

CREATE PROCEDURE dbo.usp_UpdateEmployeeSalary
    @EmpId INT,
    @NewSalary DECIMAL(10, 2)
AS
BEGIN
   SET NOCOUNT ON;

   IF(@NewSalary <= 0)
   BEGIN 
       RAISERROR('Salary must be greater then zero', 16, 1);
       RETURN;
    END;

    IF EXISTS (SELECT 1 FROM dbo.Employee WHERE EmpId = @EmpId)
    BEGIN
       UPDATE dbo.Employee
       SET Salary = @NewSalary
       WHERE EmpId = @EmpId;

       PRINT 'Salary Updated successfully.';
    END
    ELSE
    BEGIN
       RAISERROR('Employee does not exists.', 16, 1);
    END
END;

EXEC dbo.usp_UpdateEmployeeSalary -- employee does not exist
    @EmpId = 999,
    @NewSalary = 80000;

EXEC dbo.usp_UpdateEmployeeSalary --updated
      @EmpId = 1,
      @NewSalary = 7000;

      SELECT * FROM Employee;

    -- case study 4
    IF OBJECT_ID('dbo.usp_UpdateEmployeeSalary', 'P') IS NOT NULL
       DROP PROCEDURE dbo.usp_GetEmployeeById;

    ALTER PROCEDURE dbo.usp_UpdateEmployeeSalary
    @EmpId INT,
    @NewSalary DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Validation
        IF (@NewSalary <= 0)
        BEGIN
            RAISERROR('Salary must be greater than zero.', 16, 1);
        END

        -- Check if Employee Exists
        IF NOT EXISTS (SELECT 1 FROM dbo.Employee WHERE EmpId = @EmpId)
        BEGIN
            RAISERROR('Employee does not exist.', 16, 2);
        END

        -- Update Salary
        UPDATE dbo.Employee
        SET Salary = @NewSalary
        WHERE EmpId = @EmpId;

        -- Commit only if everything succeeds
        COMMIT TRANSACTION;

        PRINT 'Salary updated successfully and committed.';
    END TRY
    BEGIN CATCH
        -- Rollback on ANY error
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- Re-throw error
        DECLARE @ErrMsg NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrState INT = ERROR_STATE();

        RAISERROR(@ErrMsg, @ErrSeverity, @ErrState);
    END CATCH
END;

EXEC dbo.usp_UpdateEmployeeSalary --Salary updated successfully and committed.
    @EmpId = 1,
    @NewSalary = 90000;

    -- case study 5
    IF OBJECT_ID('dbo.usp_GetEmployeeById', 'P') IS NOT NULL
       DROP PROCEDURE dbo.usp_GetEmployeeById;

CREATE PROCEDURE dbo.usp_GetEmployeeById
       @EmpId INT
AS 
BEGIN 
   SET NOCOUNT ON;

   SELECT 
      EmpId,
      EmpName,
      Salary,
      CreateDate
      FROM dbo.Employee
      WHERE EmpId = @EmpId;

END;

EXEC dbo.usp_GetEmployeeById @EmpId = 3; --VALID

EXEC dbo.usp_GetEmployeeById @EmpId = 9999; --INVALID
