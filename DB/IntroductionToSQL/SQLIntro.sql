select * from Departments

select Name from Departments

select Salary from Employees

select  FirstName, LastName from Employees

select FirstName, LastName, FirstName + '.' + LastName + '@telerik.com' as 
FullEmailAddress from Employees

select distinct Salary from Employees

select FirstName, LastName from Employees
where JobTitle = 'Sales Representative'

select FirstName, LastName from Employees where FirstName like 'SA%'

select FirstName, LastName from Employees where FirstName like '%SA%'

select FirstName, LastName from Employees where LastName like '%ei%'

select FirstName, LastName, Salary from Employees where Salary >= 20000 and Salary <= 30000

select FirstName, LastName from Employees 
where Salary in (25000, 14000, 12500, 23600)

select FirstName, LastName from Employees where ManagerID is NULL

select FirstName, LastName, Salary from Employees where Salary > 50000 order by Salary DESC

select top(5) FirstName, LastName from Employees order by Salary DESC

select e.FirstName, e.LastName, a.AddressText from Employees e inner join Addresses a 
	on e.AddressID = a.AddressID

select e.FirstName, e.LastName, e.Salary, a.AddressText from Employees e inner join Addresses a
	on e.AddressID = a.AddressID 
	where e.Salary > 15000

select e.FirstName, e.LastName from Employees e join Employees m 
	on (e.ManagerId = m.EmployeeId)

select e.FirstName, e.LastName, m.FirstName, m.LastName, a.AddressText from Employees e 
	join Employees m
		on e.ManagerID = m.ManagerID
	join Addresses a
		on e.AddressID = a.AddressID

select name from Departments
union
select Name from Towns

select e.FirstName, e.LastName, e.Salary from Employees e
right outer join Employees m
	on e.ManagerID = m.EmployeeID or e.ManagerID is NULL

select e.FirstName, e.LastName, e.Salary from Employees e
left outer join Employees m
	on e.ManagerID = m.EmployeeID or e.ManagerID is NULL

select e.FirstName, e.LastName, e.HireDate, d.Name from Employees e
join Departments d
	on e.DepartmentID = d.DepartmentID and d.Name = 'Sales' or d.Name = 'Finance' 
	and e.HireDate > '1/1/1995' and e.HireDate < '1/1/2005'


