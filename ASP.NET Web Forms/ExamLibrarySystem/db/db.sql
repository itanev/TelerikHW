USE [master]
GO
/****** Object:  Database [LibrarySystem]    Script Date: 19.9.2013 г. 19:02:32 ч. ******/
CREATE DATABASE [LibrarySystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LibrarySystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\LibrarySystem.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'LibrarySystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\LibrarySystem_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [LibrarySystem] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibrarySystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LibrarySystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LibrarySystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LibrarySystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LibrarySystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LibrarySystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [LibrarySystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LibrarySystem] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [LibrarySystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LibrarySystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LibrarySystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LibrarySystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LibrarySystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LibrarySystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LibrarySystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LibrarySystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LibrarySystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LibrarySystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LibrarySystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LibrarySystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LibrarySystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LibrarySystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LibrarySystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LibrarySystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LibrarySystem] SET RECOVERY FULL 
GO
ALTER DATABASE [LibrarySystem] SET  MULTI_USER 
GO
ALTER DATABASE [LibrarySystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LibrarySystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LibrarySystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LibrarySystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'LibrarySystem', N'ON'
GO
USE [LibrarySystem]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 19.9.2013 г. 19:02:33 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](100) NULL,
	[description] [nvarchar](max) NULL,
	[author] [nvarchar](100) NULL,
	[isbn] [nchar](30) NULL,
	[webSite] [nchar](200) NOT NULL,
	[categoryId] [int] NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 19.9.2013 г. 19:02:33 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([id], [title], [description], [author], [isbn], [webSite], [categoryId]) VALUES (6, N'zdsafadsfadsfadsfdsafadsf', N'sdf', N'sdf', N'sdf                           ', N'sdf                                                                                                                                                                                                     ', 6)
INSERT [dbo].[Books] ([id], [title], [description], [author], [isbn], [webSite], [categoryId]) VALUES (9, N'C# Yellow Book', N'some description', N'Rob Miles', N'some isbn                     ', N'some website                                                                                                                                                                                            ', 16)
INSERT [dbo].[Books] ([id], [title], [description], [author], [isbn], [webSite], [categoryId]) VALUES (11, N'Learning Python', N'Get a comprehensive, in-depth introduction to the core Python language with this hands-on book. Based on author Mark Lutz’s popular training course, this updated fifth edition will help you quickly write efficient, high-quality code with Python. It’s an ideal way to begin, whether you’re new to programming or a professional developer versed in other languages.

Complete with quizzes, exercises, and helpful illustrations, this easy-to-follow, self-paced tutorial gets you started with both Python 2.7 and 3.3— the latest releases in the 3.X and 2.X lines—plus all other releases in common use today. You’ll also learn some advanced language features that recently have become more common in Python code.', N'Mark Lutz', N'1449355730                    ', N'some website                                                                                                                                                                                            ', 16)
INSERT [dbo].[Books] ([id], [title], [description], [author], [isbn], [webSite], [categoryId]) VALUES (12, N'Web Development and Design Foundations with HTML5 (6th Edition)', N'Using Hands-On Practice exercises and Website Case Studies to motivate readers, Web Development and Design Foundations with HTML5 includes all the necessary lessons to guide students in developing highly effective websites.

This textbook has an innovative approach that prepares students to design web pages that work today, in addition to being ready to take advantage of the new HTML5 coding techniques of the future. XHTML syntax is introduced, but the focus is on HTML5 syntax. New HTML5 elements are presented, with an emphasis on coding web pages that work in both current and future browsers.

A well-rounded balance of hard skills (HTML5, XHTML, CSS, and an introduction to JavaScript) and soft skills (web design, e-commerce overview, website promotion strategies) presents everything beginning web developers need to know to build and promote successful websites. Topics include:', N'Terry Felke-Morris', N'0132783398                    ', N'some wesite                                                                                                                                                                                             ', 7)
SET IDENTITY_INSERT [dbo].[Books] OFF
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([id], [name]) VALUES (6, N'Databases')
INSERT [dbo].[Categories] ([id], [name]) VALUES (7, N'Web Development')
INSERT [dbo].[Categories] ([id], [name]) VALUES (8, N'System Administration')
INSERT [dbo].[Categories] ([id], [name]) VALUES (9, N'Data Structures and Algorithms')
INSERT [dbo].[Categories] ([id], [name]) VALUES (10, N'Rocket Science')
INSERT [dbo].[Categories] ([id], [name]) VALUES (16, N'Programmin')
SET IDENTITY_INSERT [dbo].[Categories] OFF
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Categories] FOREIGN KEY([categoryId])
REFERENCES [dbo].[Categories] ([id])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Categories]
GO
USE [master]
GO
ALTER DATABASE [LibrarySystem] SET  READ_WRITE 
GO
