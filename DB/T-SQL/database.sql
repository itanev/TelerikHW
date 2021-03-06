USE [master]
GO
/****** Object:  Database [T_SQL]    Script Date: 7/13/2013 18:05:33 ******/
CREATE DATABASE [T_SQL]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'T_SQL', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\T_SQL.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'T_SQL_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\T_SQL_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [T_SQL] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [T_SQL].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [T_SQL] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [T_SQL] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [T_SQL] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [T_SQL] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [T_SQL] SET ARITHABORT OFF 
GO
ALTER DATABASE [T_SQL] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [T_SQL] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [T_SQL] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [T_SQL] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [T_SQL] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [T_SQL] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [T_SQL] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [T_SQL] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [T_SQL] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [T_SQL] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [T_SQL] SET  DISABLE_BROKER 
GO
ALTER DATABASE [T_SQL] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [T_SQL] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [T_SQL] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [T_SQL] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [T_SQL] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [T_SQL] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [T_SQL] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [T_SQL] SET RECOVERY FULL 
GO
ALTER DATABASE [T_SQL] SET  MULTI_USER 
GO
ALTER DATABASE [T_SQL] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [T_SQL] SET DB_CHAINING OFF 
GO
ALTER DATABASE [T_SQL] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [T_SQL] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'T_SQL', N'ON'
GO
USE [T_SQL]
GO
/****** Object:  StoredProcedure [dbo].[DepositMoney]    Script Date: 7/13/2013 18:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DepositMoney](@accId int, @money float) as
	if(@money < 0)
		print 'error. Can not deposit negative quantity'
	else
		update Accounts set Balance += @money
		where id = @accId

GO
/****** Object:  StoredProcedure [dbo].[GetPeopleWithGratterBalance]    Script Date: 7/13/2013 18:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetPeopleWithGratterBalance](@balance float) as
	select p.FirstName + ' ' + p.LastName as FullName from  Persons p
	join Accounts a
		on(p.id = a.PersonID)
	where a.Balance > @balance

GO
/****** Object:  StoredProcedure [dbo].[GiveInterest]    Script Date: 7/13/2013 18:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GiveInterest](@accId int, @interest float) as
	declare @currBalance float
	set @currBalance = (select Balance from Accounts where id = @accId)
	update Accounts set Balance += @currBalance * @interest
	where id = @accId

GO
/****** Object:  StoredProcedure [dbo].[SelectFullName]    Script Date: 7/13/2013 18:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SelectFullName] as
	select FirstName + ' ' + LastName as FullName from Persons	

GO
/****** Object:  StoredProcedure [dbo].[WithdrawMoney]    Script Date: 7/13/2013 18:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[WithdrawMoney](@accId int, @money float) as
	declare @currBalance float
	set @currBalance = (select Balance from Accounts where id = @accId)
	if(@currBalance < @money)
		print 'error. Too little money'
	else
		update Accounts set Balance -= @money
		where id = @accId

GO
/****** Object:  UserDefinedFunction [dbo].[GetSum]    Script Date: 7/13/2013 18:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[GetSum](@sum float, @interest float, @numMonths int) 
	returns float 
	as
begin
	declare @currSum float
	set @currSum = @sum
	while(@numMonths > 0)
	begin
		set @currSum = @currSum + (@currSum * @interest)
		set @numMonths = @numMonths - 1
	end
	return @sum
end

GO
/****** Object:  UserDefinedFunction [dbo].[GetSumWithInterest]    Script Date: 7/13/2013 18:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[GetSumWithInterest](@sum float, @interest float, @numMonths int) 
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

GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 7/13/2013 18:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[id] [int] NOT NULL,
	[PersonID] [int] NULL,
	[Balance] [float] NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Logs]    Script Date: 7/13/2013 18:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[logId] [int] NOT NULL,
	[AccountId] [int] NULL,
	[OldSum] [float] NULL,
	[NewSum] [float] NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[logId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persons]    Script Date: 7/13/2013 18:05:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Persons](
	[id] [int] NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[SSN] [int] NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Persons] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Persons] ([id])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Persons]
GO
USE [master]
GO
ALTER DATABASE [T_SQL] SET  READ_WRITE 
GO
