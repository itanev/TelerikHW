use T_SQL

go
create proc dbo.SelectFullName as
	select FirstName + ' ' + LastName as FullName from Persons	
go

exec SelectFullName

go 
create proc dbo.GetPeopleWithGratterBalance(@balance float) as
	select p.FirstName + ' ' + p.LastName as FullName from  Persons p
	join Accounts a
		on(p.id = a.PersonID)
	where a.Balance > @balance
go 

exec GetPeopleWithGratterBalance 100

go
create function GetSumWithInterest(@sum float, @interest float, @numMonths int) 
	returns float 
	with execute as caller
	as
begin
	declare @currSum float
	set @currSum = @sum
	while(@numMonths > 0)
	begin
		set @currSum = @currSum + (@currSum * @interest)
		set @numMonths = @numMonths - 1
	end
	return @currSum
end
go

select dbo.GetSumWithInterest(100.0, 0.1, 10) as result;

go
create proc GiveInterest(@accId int, @interest float) as
	declare @currBalance float
	set @currBalance = (select Balance from Accounts where id = @accId)
	update Accounts set Balance += @currBalance * @interest
	where id = @accId
go

exec GiveInterest 1, 0.1

go 
create proc WithdrawMoney(@accId int, @money float) as
	declare @currBalance float
	set @currBalance = (select Balance from Accounts where id = @accId)
	if(@currBalance < @money)
		print 'error. Too little money'
	else
		update Accounts set Balance -= @money
		where id = @accId
go

go 
create proc DepositMoney(@accId int, @money float) as
	if(@money < 0)
		print 'error. Can not deposit negative quantity'
	else
		update Accounts set Balance += @money
		where id = @accId
go

begin tran
exec WithdrawMoney 1, 10
rollback tran

go
create trigger tr_AccountsUpdate on Accounts for UPDATE
as
insert into dbo.Logs (OldSum, NewSum, AccountID)
	select d.Balance, i.Balance, d.id
	from deleted as d
	join inserted as i
    on d.id = i.id
go

use TelerikAcademy
go 
	create function CheckLetters(@setOfLetters varchar(30), @str varchar(30))
		returns tinyint
		as
	begin
		declare @strLen int
		set @strLen = 1

		while(@strLen > LEN(@str))
		begin
			if(@setOfLetters like ('%' + SUBSTRING(@str, @strlen, 1) + '%') )
				set @strlen += 1
			else
				return 0
		end

		return 1
	end
go
	create function dbo.GetNames(@setOfLetters varchar(30)) 
		returns table 
		as
		return (select e.FirstName, t.Name from Employees e
				join Addresses a
					on(e.AddressID = a.AddressID)
				join Towns t
					on(a.TownID = t.TownID)
				where dbo.CheckLetters(@setOfLetters, e.FirstName) = 1 and 
					  dbo.CheckLetters(@setOfLetters, t.Name) = 1)
go

select * from dbo.GetNames('trdsfnmocda')

declare @allEmployees table 
(
	FirstName varchar(50),
	LastName varchar(50),
	AddressId int,
	TownId int
)
 
declare @firstName varchar(50)
declare @lastName varchar(50)
declare @townId int
declare @addressId int
declare @currTownId int
set @currTownId = 1

declare employees_cursor cursor
	for select e.FirstName, e.LastName, e.AddressID, t.TownID from Employees e
		join Addresses a
			on (e.AddressID = a.AddressID)
		join Towns t
			on (a.TownID = t.TownID)
open employees_cursor
fetch next from employees_cursor
into @firstName, @lastName, @townId, @addressId
while @@FETCH_STATUS = 0
begin 
	if(@currTownId = @townId)
	begin
		set @currTownId = @townId
		print(' ')
	end

	print(@firstName + ' ' + @lastName)

	fetch next from employees_cursor
	into @firstName, @lastName, @townId, @addressId
end
close employees_cursor
deallocate employees_cursor
go