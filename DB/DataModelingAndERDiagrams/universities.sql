USE [master]
GO
/****** Object:  Database [universities]    Script Date: 7/10/2013 14:58:35 ******/
CREATE DATABASE [universities]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'universities', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\universities.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'universities_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\universities_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [universities] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [universities].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [universities] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [universities] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [universities] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [universities] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [universities] SET ARITHABORT OFF 
GO
ALTER DATABASE [universities] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [universities] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [universities] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [universities] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [universities] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [universities] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [universities] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [universities] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [universities] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [universities] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [universities] SET  DISABLE_BROKER 
GO
ALTER DATABASE [universities] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [universities] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [universities] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [universities] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [universities] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [universities] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [universities] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [universities] SET RECOVERY FULL 
GO
ALTER DATABASE [universities] SET  MULTI_USER 
GO
ALTER DATABASE [universities] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [universities] SET DB_CHAINING OFF 
GO
ALTER DATABASE [universities] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [universities] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'universities', N'ON'
GO
USE [universities]
GO
/****** Object:  Table [dbo].[course]    Script Date: 7/10/2013 14:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[course](
	[id] [int] NOT NULL,
	[name] [varchar](50) NULL,
 CONSTRAINT [PK_course] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[course_student]    Script Date: 7/10/2013 14:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[course_student](
	[course_id] [int] NOT NULL,
	[student_id] [int] NULL,
	[id] [int] NOT NULL,
 CONSTRAINT [PK_course_student] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[departament_courses]    Script Date: 7/10/2013 14:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[departament_courses](
	[id] [int] NOT NULL,
	[departament_id] [int] NULL,
	[course_id] [int] NULL,
 CONSTRAINT [PK_departament_courses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[departament_professors]    Script Date: 7/10/2013 14:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[departament_professors](
	[id] [int] NOT NULL,
	[departament_id] [int] NULL,
	[professor_id] [int] NULL,
 CONSTRAINT [PK_departament_professors] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[department]    Script Date: 7/10/2013 14:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[department](
	[id] [int] NOT NULL,
	[name] [varchar](50) NULL,
 CONSTRAINT [PK_department] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[faculty]    Script Date: 7/10/2013 14:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[faculty](
	[id] [int] NOT NULL,
	[name] [varchar](50) NULL,
 CONSTRAINT [PK_faculty] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[faculty_department]    Script Date: 7/10/2013 14:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[faculty_department](
	[id] [int] NOT NULL,
	[faculty_id] [int] NULL,
	[department_id] [int] NULL,
 CONSTRAINT [PK_faculty_department] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[professor]    Script Date: 7/10/2013 14:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[professor](
	[id] [int] NOT NULL,
	[name] [varchar](50) NULL,
 CONSTRAINT [PK_professor] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[professor_title]    Script Date: 7/10/2013 14:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[professor_title](
	[proffesor_id] [int] NOT NULL,
	[title_id] [int] NULL,
	[id] [int] NOT NULL,
 CONSTRAINT [PK_professor_title] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[proffesor_course]    Script Date: 7/10/2013 14:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proffesor_course](
	[profesor_id] [int] NOT NULL,
	[course_id] [int] NULL,
	[id] [int] NOT NULL,
 CONSTRAINT [PK_proffesor_course] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[student]    Script Date: 7/10/2013 14:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[student](
	[id] [int] NOT NULL,
	[name] [varchar](50) NULL,
 CONSTRAINT [PK_student] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[title]    Script Date: 7/10/2013 14:58:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[title](
	[id] [int] NOT NULL,
	[title_name] [varchar](50) NULL,
 CONSTRAINT [PK_title] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[course_student]  WITH CHECK ADD  CONSTRAINT [FK_course_student_course] FOREIGN KEY([course_id])
REFERENCES [dbo].[course] ([id])
GO
ALTER TABLE [dbo].[course_student] CHECK CONSTRAINT [FK_course_student_course]
GO
ALTER TABLE [dbo].[course_student]  WITH CHECK ADD  CONSTRAINT [FK_course_student_student] FOREIGN KEY([student_id])
REFERENCES [dbo].[student] ([id])
GO
ALTER TABLE [dbo].[course_student] CHECK CONSTRAINT [FK_course_student_student]
GO
ALTER TABLE [dbo].[departament_courses]  WITH CHECK ADD  CONSTRAINT [FK_departament_courses_course] FOREIGN KEY([course_id])
REFERENCES [dbo].[course] ([id])
GO
ALTER TABLE [dbo].[departament_courses] CHECK CONSTRAINT [FK_departament_courses_course]
GO
ALTER TABLE [dbo].[departament_courses]  WITH CHECK ADD  CONSTRAINT [FK_departament_courses_department] FOREIGN KEY([departament_id])
REFERENCES [dbo].[department] ([id])
GO
ALTER TABLE [dbo].[departament_courses] CHECK CONSTRAINT [FK_departament_courses_department]
GO
ALTER TABLE [dbo].[departament_professors]  WITH CHECK ADD  CONSTRAINT [FK_departament_professors_department] FOREIGN KEY([departament_id])
REFERENCES [dbo].[department] ([id])
GO
ALTER TABLE [dbo].[departament_professors] CHECK CONSTRAINT [FK_departament_professors_department]
GO
ALTER TABLE [dbo].[departament_professors]  WITH CHECK ADD  CONSTRAINT [FK_departament_professors_professor] FOREIGN KEY([professor_id])
REFERENCES [dbo].[professor] ([id])
GO
ALTER TABLE [dbo].[departament_professors] CHECK CONSTRAINT [FK_departament_professors_professor]
GO
ALTER TABLE [dbo].[faculty_department]  WITH CHECK ADD  CONSTRAINT [FK_faculty_department_department] FOREIGN KEY([department_id])
REFERENCES [dbo].[department] ([id])
GO
ALTER TABLE [dbo].[faculty_department] CHECK CONSTRAINT [FK_faculty_department_department]
GO
ALTER TABLE [dbo].[faculty_department]  WITH CHECK ADD  CONSTRAINT [FK_faculty_department_faculty] FOREIGN KEY([faculty_id])
REFERENCES [dbo].[faculty] ([id])
GO
ALTER TABLE [dbo].[faculty_department] CHECK CONSTRAINT [FK_faculty_department_faculty]
GO
ALTER TABLE [dbo].[professor_title]  WITH CHECK ADD  CONSTRAINT [FK_professor_title_professor] FOREIGN KEY([proffesor_id])
REFERENCES [dbo].[professor] ([id])
GO
ALTER TABLE [dbo].[professor_title] CHECK CONSTRAINT [FK_professor_title_professor]
GO
ALTER TABLE [dbo].[professor_title]  WITH CHECK ADD  CONSTRAINT [FK_professor_title_title] FOREIGN KEY([title_id])
REFERENCES [dbo].[title] ([id])
GO
ALTER TABLE [dbo].[professor_title] CHECK CONSTRAINT [FK_professor_title_title]
GO
ALTER TABLE [dbo].[proffesor_course]  WITH CHECK ADD  CONSTRAINT [FK_proffesor_course_course] FOREIGN KEY([course_id])
REFERENCES [dbo].[course] ([id])
GO
ALTER TABLE [dbo].[proffesor_course] CHECK CONSTRAINT [FK_proffesor_course_course]
GO
ALTER TABLE [dbo].[proffesor_course]  WITH CHECK ADD  CONSTRAINT [FK_proffesor_course_professor] FOREIGN KEY([profesor_id])
REFERENCES [dbo].[professor] ([id])
GO
ALTER TABLE [dbo].[proffesor_course] CHECK CONSTRAINT [FK_proffesor_course_professor]
GO
USE [master]
GO
ALTER DATABASE [universities] SET  READ_WRITE 
GO
