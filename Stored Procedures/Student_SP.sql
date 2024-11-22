use StudentManagementSystem;


CREATE TABLE Students (
    StudentID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    Age INT NOT NULL,
    Branch NVARCHAR(25) NOT NULL,
    PhoneNumber NVARCHAR(15) NOT NULL
);

INSERT INTO Students (Name, Age, Branch, PhoneNumber)
VALUES 
    ('John Smith', 20, 'Computer Science', '+1234567890'),
    ('Alice Johnson', 22, 'Mechanical Engineering', '+1987654321'),
    ('Robert Brown', 19, 'Electrical Engineering', '+1123456789'),
    ('Emily Davis', 21, 'Civil Engineering', '+1928374650'),
    ('Michael Wilson', 23, 'Computer Science', '+1212121212'),
    ('Sophia Taylor', 18, 'Information Technology', '+1555555555'),
    ('James Anderson', 24, 'Mechanical Engineering', '+1666666666'),
    ('Isabella Thomas', 20, 'Chemical Engineering', '+1777777777'),
    ('William Moore', 25, 'Aeronautical Engineering', '+1888888888'),
    ('Emma Martin', 19, 'Biotechnology', '+1999999999');

CREATE OR ALTER PROCEDURE spGetStudents
AS
BEGIN
	SELECT * FROM dbo.Students;
END;

CREATE OR ALTER PROCEDURE spGetStudent
	@id int
AS
BEGIN
	SELECT * FROM dbo.Students
	WHERE StudentID=@id;
END;

CREATE OR ALTER PROCEDURE spAddStudent
	@Name varchar(50),
	@Age int,
	@Branch varchar(25),
	@PhoneNumber varchar(15)
AS
BEGIN
	INSERT INTO Students (Name, Age, Branch, PhoneNumber)
	VALUES(@Name,@Age,@Branch,@PhoneNumber)
END;

CREATE OR ALTER PROCEDURE spUpdateStudents
	@Id int,
	@Name varchar(50),
	@Age int,
	@Branch varchar(25),
	@PhoneNumber varchar(15)
AS
BEGIN
	UPDATE dbo.Students
	SET 
		Name = @Name,
		Age = @Age,
		Branch = @Branch,
		PhoneNumber = @PhoneNumber
	WHERE StudentID = @Id
END;

CREATE OR ALTER PROCEDURE spAddStudents
	@Id int
AS
BEGIN
	DELETE FROM dbo.Students
	WHERE StudentID = @Id
END;

EXEC spGetStudent 10
