USE [master]
GO
/****** Object:  Database [MoviesDatabase]    Script Date: 29.9.2013 г. 00:48:36 ч. ******/
CREATE DATABASE [MoviesDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MoviesDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\MoviesDatabase.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MoviesDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\MoviesDatabase_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MoviesDatabase] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MoviesDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MoviesDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MoviesDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MoviesDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MoviesDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MoviesDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [MoviesDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MoviesDatabase] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [MoviesDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MoviesDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MoviesDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MoviesDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MoviesDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MoviesDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MoviesDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MoviesDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MoviesDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MoviesDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MoviesDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MoviesDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MoviesDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MoviesDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MoviesDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MoviesDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MoviesDatabase] SET RECOVERY FULL 
GO
ALTER DATABASE [MoviesDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [MoviesDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MoviesDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MoviesDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MoviesDatabase] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MoviesDatabase', N'ON'
GO
USE [MoviesDatabase]
GO
/****** Object:  Table [dbo].[Kinds]    Script Date: 29.9.2013 г. 00:48:36 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kinds](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Kinds] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Movies]    Script Date: 29.9.2013 г. 00:48:36 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nchar](100) NOT NULL,
	[year] [int] NOT NULL,
	[directorId] [int] NOT NULL,
	[leadingFemaleRoleId] [int] NOT NULL,
	[leadingMaleRoleId] [int] NOT NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[People]    Script Date: 29.9.2013 г. 00:48:36 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nchar](100) NOT NULL,
	[lastName] [nchar](100) NOT NULL,
	[studioId] [int] NOT NULL,
	[age] [int] NOT NULL,
	[kindId] [int] NOT NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Studio]    Script Date: 29.9.2013 г. 00:48:36 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Studio](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](100) NOT NULL,
	[address] [nchar](200) NOT NULL,
 CONSTRAINT [PK_Studio] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Kinds] ON 

INSERT [dbo].[Kinds] ([id], [name]) VALUES (1, N'Director                                          ')
INSERT [dbo].[Kinds] ([id], [name]) VALUES (2, N'MaleActor                                         ')
INSERT [dbo].[Kinds] ([id], [name]) VALUES (5, N'FemaleActor                                       ')
SET IDENTITY_INSERT [dbo].[Kinds] OFF
SET IDENTITY_INSERT [dbo].[Movies] ON 

INSERT [dbo].[Movies] ([id], [title], [year], [directorId], [leadingFemaleRoleId], [leadingMaleRoleId]) VALUES (1, N'test                                                                                                ', 23, 1, 3, 2)
INSERT [dbo].[Movies] ([id], [title], [year], [directorId], [leadingFemaleRoleId], [leadingMaleRoleId]) VALUES (2, N'test                                                                                                ', 123, 1, 5, 4)
INSERT [dbo].[Movies] ([id], [title], [year], [directorId], [leadingFemaleRoleId], [leadingMaleRoleId]) VALUES (4, N'test                                                                                                ', 123, 1, 9, 8)
INSERT [dbo].[Movies] ([id], [title], [year], [directorId], [leadingFemaleRoleId], [leadingMaleRoleId]) VALUES (5, N'new movie                                                                                           ', 1998, 10, 12, 11)
INSERT [dbo].[Movies] ([id], [title], [year], [directorId], [leadingFemaleRoleId], [leadingMaleRoleId]) VALUES (6, N'test movie                                                                                          ', 1094, 13, 15, 14)
INSERT [dbo].[Movies] ([id], [title], [year], [directorId], [leadingFemaleRoleId], [leadingMaleRoleId]) VALUES (7, N'test again                                                                                          ', 1349, 16, 18, 17)
INSERT [dbo].[Movies] ([id], [title], [year], [directorId], [leadingFemaleRoleId], [leadingMaleRoleId]) VALUES (8, N'test                                                                                                ', 1345, 1, 20, 19)
INSERT [dbo].[Movies] ([id], [title], [year], [directorId], [leadingFemaleRoleId], [leadingMaleRoleId]) VALUES (9, N'testdsfa                                                                                            ', 2434, 22, 24, 23)
INSERT [dbo].[Movies] ([id], [title], [year], [directorId], [leadingFemaleRoleId], [leadingMaleRoleId]) VALUES (10, N'testdsfa                                                                                            ', 2434, 21, 26, 25)
INSERT [dbo].[Movies] ([id], [title], [year], [directorId], [leadingFemaleRoleId], [leadingMaleRoleId]) VALUES (11, N'testdsfa                                                                                            ', 2434, 21, 29, 27)
INSERT [dbo].[Movies] ([id], [title], [year], [directorId], [leadingFemaleRoleId], [leadingMaleRoleId]) VALUES (12, N'testdsfa                                                                                            ', 2434, 21, 30, 28)
INSERT [dbo].[Movies] ([id], [title], [year], [directorId], [leadingFemaleRoleId], [leadingMaleRoleId]) VALUES (13, N'testdsfa                                                                                            ', 2434, 21, 32, 31)
INSERT [dbo].[Movies] ([id], [title], [year], [directorId], [leadingFemaleRoleId], [leadingMaleRoleId]) VALUES (14, N'testdsfa                                                                                            ', 2434, 21, 35, 33)
INSERT [dbo].[Movies] ([id], [title], [year], [directorId], [leadingFemaleRoleId], [leadingMaleRoleId]) VALUES (15, N'testdsfa                                                                                            ', 2434, 21, 36, 34)
INSERT [dbo].[Movies] ([id], [title], [year], [directorId], [leadingFemaleRoleId], [leadingMaleRoleId]) VALUES (16, N'testdsfa                                                                                            ', 2434, 21, 38, 37)
INSERT [dbo].[Movies] ([id], [title], [year], [directorId], [leadingFemaleRoleId], [leadingMaleRoleId]) VALUES (17, N'testdsfa                                                                                            ', 2434, 21, 40, 39)
INSERT [dbo].[Movies] ([id], [title], [year], [directorId], [leadingFemaleRoleId], [leadingMaleRoleId]) VALUES (18, N'testdsfa                                                                                            ', 2434, 21, 42, 41)
INSERT [dbo].[Movies] ([id], [title], [year], [directorId], [leadingFemaleRoleId], [leadingMaleRoleId]) VALUES (19, N'testdsfa                                                                                            ', 2434, 21, 44, 43)
INSERT [dbo].[Movies] ([id], [title], [year], [directorId], [leadingFemaleRoleId], [leadingMaleRoleId]) VALUES (20, N'another test                                                                                        ', 3435, 45, 47, 46)
INSERT [dbo].[Movies] ([id], [title], [year], [directorId], [leadingFemaleRoleId], [leadingMaleRoleId]) VALUES (21, N'sfdfs                                                                                               ', 32, 48, 50, 49)
SET IDENTITY_INSERT [dbo].[Movies] OFF
SET IDENTITY_INSERT [dbo].[People] ON 

INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (1, N'test                                                                                                ', N'test                                                                                                ', 1, 54, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (2, N'test                                                                                                ', N'test                                                                                                ', 1, 54, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (3, N'test                                                                                                ', N'test                                                                                                ', 1, 54, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (4, N'test                                                                                                ', N'test                                                                                                ', 1, 24, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (5, N'test                                                                                                ', N'test                                                                                                ', 1, 24, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (6, N'test                                                                                                ', N'test                                                                                                ', 1, 24, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (7, N'test                                                                                                ', N'test                                                                                                ', 1, 24, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (8, N'test                                                                                                ', N'test                                                                                                ', 1, 24, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (9, N'test                                                                                                ', N'test                                                                                                ', 1, 24, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (10, N'stivan                                                                                              ', N'spilberg                                                                                            ', 2, 56, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (11, N'stivan                                                                                              ', N'spilberg                                                                                            ', 2, 56, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (12, N'stivan                                                                                              ', N'spilberg                                                                                            ', 2, 56, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (13, N'pesho                                                                                               ', N'petrov                                                                                              ', 3, 243, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (14, N'pesho                                                                                               ', N'petrov                                                                                              ', 3, 243, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (15, N'pesho                                                                                               ', N'petrov                                                                                              ', 3, 243, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (16, N'sdf                                                                                                 ', N'dsf                                                                                                 ', 4, 334, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (17, N'sdf                                                                                                 ', N'dsf                                                                                                 ', 4, 334, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (18, N'sdf                                                                                                 ', N'dsf                                                                                                 ', 4, 334, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (19, N'test                                                                                                ', N'test                                                                                                ', 5, 3545, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (20, N'test                                                                                                ', N'test                                                                                                ', 5, 3545, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (21, N'tsetdf                                                                                              ', N'stdset                                                                                              ', 6, 23, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (22, N'tsetdf                                                                                              ', N'stdset                                                                                              ', 6, 23, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (23, N'tsetdf                                                                                              ', N'stdset                                                                                              ', 6, 23, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (24, N'tsetdf                                                                                              ', N'stdset                                                                                              ', 6, 23, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (25, N'tsetdf                                                                                              ', N'stdset                                                                                              ', 6, 23, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (26, N'tsetdf                                                                                              ', N'stdset                                                                                              ', 6, 23, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (27, N'tsetdf                                                                                              ', N'stdset                                                                                              ', 6, 23, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (28, N'tsetdf                                                                                              ', N'stdset                                                                                              ', 6, 23, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (29, N'tsetdf                                                                                              ', N'stdset                                                                                              ', 6, 23, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (30, N'tsetdf                                                                                              ', N'stdset                                                                                              ', 6, 23, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (31, N'tsetdf                                                                                              ', N'stdset                                                                                              ', 6, 23, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (32, N'tsetdf                                                                                              ', N'stdset                                                                                              ', 6, 23, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (33, N'tsetdf                                                                                              ', N'stdset                                                                                              ', 6, 23, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (34, N'tsetdf                                                                                              ', N'stdset                                                                                              ', 6, 23, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (35, N'tsetdf                                                                                              ', N'stdset                                                                                              ', 6, 23, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (36, N'tsetdf                                                                                              ', N'stdset                                                                                              ', 6, 23, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (37, N'tsetdf                                                                                              ', N'stdset                                                                                              ', 6, 23, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (38, N'tsetdf                                                                                              ', N'stdset                                                                                              ', 6, 23, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (39, N'tsetdf                                                                                              ', N'stdset                                                                                              ', 6, 23, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (40, N'tsetdf                                                                                              ', N'stdset                                                                                              ', 6, 23, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (41, N'tsetdf                                                                                              ', N'stdset                                                                                              ', 6, 23, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (42, N'tsetdf                                                                                              ', N'stdset                                                                                              ', 6, 23, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (43, N'tsetdf                                                                                              ', N'stdset                                                                                              ', 6, 23, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (44, N'tsetdf                                                                                              ', N'stdset                                                                                              ', 6, 23, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (45, N'sdfdsf                                                                                              ', N'sdf                                                                                                 ', 7, 45, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (46, N'sdfdsf                                                                                              ', N'sdf                                                                                                 ', 7, 45, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (47, N'sdfdsf                                                                                              ', N'sdf                                                                                                 ', 7, 45, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (48, N'sdf                                                                                                 ', N'sdf                                                                                                 ', 7, 23, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (49, N'sdf                                                                                                 ', N'sdf                                                                                                 ', 7, 23, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (50, N'sdf                                                                                                 ', N'sdf                                                                                                 ', 7, 23, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (51, N'test                                                                                                ', N'test                                                                                                ', 1, 54, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (52, N'test                                                                                                ', N'test                                                                                                ', 1, 54, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (53, N'test                                                                                                ', N'test                                                                                                ', 1, 54, 1)
INSERT [dbo].[People] ([id], [firstName], [lastName], [studioId], [age], [kindId]) VALUES (54, N'test                                                                                                ', N'test                                                                                                ', 1, 54, 1)
SET IDENTITY_INSERT [dbo].[People] OFF
SET IDENTITY_INSERT [dbo].[Studio] ON 

INSERT [dbo].[Studio] ([id], [name], [address]) VALUES (1, N'test                                                                                                ', N'tes                                                                                                                                                                                                     ')
INSERT [dbo].[Studio] ([id], [name], [address]) VALUES (2, N'some name                                                                                           ', N'holiwood                                                                                                                                                                                                ')
INSERT [dbo].[Studio] ([id], [name], [address]) VALUES (3, N'nam                                                                                                 ', N'some addr                                                                                                                                                                                               ')
INSERT [dbo].[Studio] ([id], [name], [address]) VALUES (4, N'sdfsf                                                                                               ', N'sdfdsf                                                                                                                                                                                                  ')
INSERT [dbo].[Studio] ([id], [name], [address]) VALUES (5, N'sdfdsf                                                                                              ', N'ssfdds                                                                                                                                                                                                  ')
INSERT [dbo].[Studio] ([id], [name], [address]) VALUES (6, N'tsedf                                                                                               ', N'tewst                                                                                                                                                                                                   ')
INSERT [dbo].[Studio] ([id], [name], [address]) VALUES (7, N'sdf                                                                                                 ', N'sdfs                                                                                                                                                                                                    ')
SET IDENTITY_INSERT [dbo].[Studio] OFF
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_People] FOREIGN KEY([directorId])
REFERENCES [dbo].[People] ([id])
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_People]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_People1] FOREIGN KEY([leadingFemaleRoleId])
REFERENCES [dbo].[People] ([id])
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_People1]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_People2] FOREIGN KEY([leadingMaleRoleId])
REFERENCES [dbo].[People] ([id])
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_People2]
GO
ALTER TABLE [dbo].[People]  WITH CHECK ADD  CONSTRAINT [FK_People_Kinds] FOREIGN KEY([kindId])
REFERENCES [dbo].[Kinds] ([id])
GO
ALTER TABLE [dbo].[People] CHECK CONSTRAINT [FK_People_Kinds]
GO
ALTER TABLE [dbo].[People]  WITH CHECK ADD  CONSTRAINT [FK_People_Studio] FOREIGN KEY([studioId])
REFERENCES [dbo].[Studio] ([id])
GO
ALTER TABLE [dbo].[People] CHECK CONSTRAINT [FK_People_Studio]
GO
USE [master]
GO
ALTER DATABASE [MoviesDatabase] SET  READ_WRITE 
GO
