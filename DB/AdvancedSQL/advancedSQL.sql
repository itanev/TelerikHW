select FirstName, LastName, Salary from Employees
where Salary = (select MIN(Salary) from Employees)

select FirstName, LastName, Salary from Employees
where Salary <= (select MIN(Salary) * 0.1 from Employees)

select e.FirstName + ' ' + e.LastName as FullName, e.Salary from Employees e
where Salary = (select MIN(Salary) from Employees
				where DepartmentID = e.DepartmentID)
				order by DepartmentID

select AVG(Salary) as AverageSalary from Employees where DepartmentID = 1
	
select AVG(Salary) as AverageSalary from Employees e
join Departments d
	on(d.Name = 'Sales')
	
select COUNT(*) from Employees 
where ManagerID is not NULL

select COUNT(*) from Employees 
where ManagerID is NULL

select DepartmentId, AVG(Salary) from Employees
Group by DepartmentID

select COUNT(*) from Employees e
join Towns t
	on ( t.TownID = e.AddressID )
	group by e.DepartmentID

select em.FirstName, em.LastName, em.ManagerID from Employees em
	join (  select e.FirstName, e.LastName, e.EmployeeID 
			from Employees e
			where ManagerID is null  ) e
			on(em.ManagerID = e.EmployeeID)
	group by em.FirstName, em.LastName, em.ManagerID 
	having COUNT(em.EmployeeID) = 5

select e.FirstName, e.LastName as Employee, COALESCE(m.LastName, '(no manager)') as Manager
from Employees e
LEFT JOIN Employees m
on e.ManagerId = m.EmployeeId;

select LastName from Employees where LEN(LastName) = 5

SELECT CONVERT(VARCHAR(23), GETDATE(), 126)

CREATE TABLE Users
(
	id int NOT NULL,
	Username varchar(255) NOT NULL,
	Password varchar(255),
	FullName varchar(255),
	LastLoginTime DateTime,
	CONSTRAINT uc UNIQUE (id,Username),
	PRIMARY KEY (id),
	CHECK ( LEN(Password) >= 5 )
)

create view TodayLogin as
select username from Users where LastLoginTime = GETDATE()

CREATE TABLE Groups
(
	id int NOT NULL,
	Name varchar(255) NOT NULL,
	CONSTRAINT ug UNIQUE (id,Name),
	PRIMARY KEY (id)
)

Alter table Users add GroupID int
go

insert into Users (id, Username, Password, FullName, LastLoginTime, GroupID)
values(4, 'stamat', 'passwords', 'stamat stamatov', '12/07/2013', '1')

alter table Users
add foreign key (GroupID)
	references Groups(id)

insert into Users(id, Username, Password, FullName, LastLoginTime, GroupID)
values(5, 'krosa', 'passwords', 'kiro kirov', '12/07/2013', '2')

insert into Groups(id, Name)
values(3, 'banans')

update Users set Username = 'kirosa' where id = 5

update Groups set name = 'kirosGroup' where id = 2

insert into Users(id, Username, Password, FullName, LastLoginTime)
select EmployeeID + 5, LEFT(FirstName, 1) + LastName, LEFT(FirstName, 1) + LastName + 'pass', FirstName + LastName as FullName, NULL from Employees

update Users set Password = NULL where LastLoginTime = CONVERT( DATETIME, '03-10-2010')

delete from Users where Password is NULL

select DepartmentID, JobTitle, AVG(Salary) as AvgSalary from Employees
group by DepartmentID, JobTitle

select DepartmentID, JobTitle, FirstName, LastName, MIN(Salary) as MinSalary from Employees
group by DepartmentID, JobTitle, FirstName, LastName
having FirstName like '%p%'

select top(1) t.Name
from Employees e 
join Addresses a ON e.AddressId = a.AddressId
join Towns t ON t.TownId = a.TownId
group by t.TownId, t.Name
order by COUNT(*) DESC;

select t.Name, COUNT(*) from Employees e
join Addresses a on (e.AddressID = a.AddressID)
join Towns t on (t.TownID = a.TownID)
group by t.TownID, t.Name

create table WorkHours
(
	Id int identity primary key,
	EmployeeId int not NULL foreign key references Employees(EmployeeId),
	Date_ date not NULL,
	Task varchar(16) not NULL,
	Hours_ int not NULL,
	Comments text
);

BEGIN TRAN
	ALTER TABLE EmployeesProjects
	ADD CONSTRAINT FK_CASCADE_1 FOREIGN KEY (EmployeeID)
	REFERENCES Employees (EmployeeID)
	ON DELETE CASCADE;

	ALTER TABLE Departments
	ADD CONSTRAINT FK_CASCADE_2 FOREIGN KEY (ManagerId)
	REFERENCES Employees (EmployeeID)
	ON DELETE SET NULL;

	DELETE FROM Employees 
	WHERE DepartmentId IN (SELECT DepartmentId FROM Departments WHERE Name = 'Sales')

	ROLLBACK TRAN
GO

BEGIN TRAN
	CREATE DATABASE TelerikAcademy_snapshot1900 
	ON (NAME = TelerikAcademy_Data, FILENAME = 'TelerikAcademy_snapshot1900.ss')
	AS SNAPSHOT OF TelerikAcademy;

	DROP TABLE EmployeesProjects
GO

BEGIN TRAN
	ALTER DATABASE TelerikAcademy
	SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

	USE master;
	RESTORE DATABASE TeleikAcademy FROM DATABASE_SNAPSHOT = 'TelerikAcademy_snapshot1900';
GO

BEGIN TRAN
	SELECT * INTO #TempEmployeesProjects 
	FROM EmployeesProjects;

	DROP TABLE EmployeesProjects;

	SELECT * INTO EmployeesProjects
	FROM #TempEmployeesProjects;

	DROP TABLE #TempEmployeesProjects
GO
