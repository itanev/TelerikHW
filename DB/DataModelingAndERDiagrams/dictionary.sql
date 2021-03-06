USE [master]
GO
/****** Object:  Database [dictionary]    Script Date: 7/10/2013 20:39:44 ******/
CREATE DATABASE [dictionary]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dictionary', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\dictionary.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'dictionary_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\dictionary_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [dictionary] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dictionary].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dictionary] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dictionary] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dictionary] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dictionary] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dictionary] SET ARITHABORT OFF 
GO
ALTER DATABASE [dictionary] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dictionary] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [dictionary] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dictionary] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dictionary] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dictionary] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dictionary] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dictionary] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dictionary] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dictionary] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dictionary] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dictionary] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dictionary] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dictionary] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dictionary] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dictionary] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dictionary] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dictionary] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dictionary] SET RECOVERY FULL 
GO
ALTER DATABASE [dictionary] SET  MULTI_USER 
GO
ALTER DATABASE [dictionary] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dictionary] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dictionary] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dictionary] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'dictionary', N'ON'
GO
USE [dictionary]
GO
/****** Object:  Table [dbo].[ForeignWords]    Script Date: 7/10/2013 20:39:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ForeignWords](
	[id] [int] NOT NULL,
	[language] [varchar](50) NOT NULL,
	[word] [nvarchar](50) NOT NULL,
	[explanation] [ntext] NOT NULL,
 CONSTRAINT [PK_ForeignWords] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[hypernym_word]    Script Date: 7/10/2013 20:39:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hypernym_word](
	[wordId] [int] NOT NULL,
	[hypernymId] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[hypernyms]    Script Date: 7/10/2013 20:39:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hypernyms](
	[id] [int] NOT NULL,
	[part] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_hypernyms] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[hyponym]    Script Date: 7/10/2013 20:39:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hyponym](
	[id] [int] NOT NULL,
	[part] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_hyponym] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[hyponym_word]    Script Date: 7/10/2013 20:39:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hyponym_word](
	[wordId] [int] NOT NULL,
	[hyponymId] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[speechParts]    Script Date: 7/10/2013 20:39:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[speechParts](
	[id] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_speechParts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[synonyms]    Script Date: 7/10/2013 20:39:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[synonyms](
	[id] [int] NOT NULL,
	[word] [varchar](50) NOT NULL,
 CONSTRAINT [PK_synonyms] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[words]    Script Date: 7/10/2013 20:39:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[words](
	[id] [int] NOT NULL,
	[word] [varchar](50) NOT NULL,
	[language] [varchar](50) NOT NULL,
	[word_foreign] [int] NOT NULL,
	[synonym] [int] NOT NULL,
	[explanation] [text] NOT NULL,
	[speechPartId] [int] NOT NULL,
 CONSTRAINT [PK_words] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[hypernym_word]  WITH CHECK ADD  CONSTRAINT [FK_hypernym_word_hypernyms] FOREIGN KEY([hypernymId])
REFERENCES [dbo].[hypernyms] ([id])
GO
ALTER TABLE [dbo].[hypernym_word] CHECK CONSTRAINT [FK_hypernym_word_hypernyms]
GO
ALTER TABLE [dbo].[hypernym_word]  WITH CHECK ADD  CONSTRAINT [FK_hypernym_word_words] FOREIGN KEY([wordId])
REFERENCES [dbo].[words] ([id])
GO
ALTER TABLE [dbo].[hypernym_word] CHECK CONSTRAINT [FK_hypernym_word_words]
GO
ALTER TABLE [dbo].[hyponym_word]  WITH CHECK ADD  CONSTRAINT [FK_hyponym_word_hyponym] FOREIGN KEY([hyponymId])
REFERENCES [dbo].[hyponym] ([id])
GO
ALTER TABLE [dbo].[hyponym_word] CHECK CONSTRAINT [FK_hyponym_word_hyponym]
GO
ALTER TABLE [dbo].[hyponym_word]  WITH CHECK ADD  CONSTRAINT [FK_hyponym_word_words] FOREIGN KEY([wordId])
REFERENCES [dbo].[words] ([id])
GO
ALTER TABLE [dbo].[hyponym_word] CHECK CONSTRAINT [FK_hyponym_word_words]
GO
ALTER TABLE [dbo].[words]  WITH CHECK ADD  CONSTRAINT [FK_words_ForeignWords] FOREIGN KEY([word_foreign])
REFERENCES [dbo].[ForeignWords] ([id])
GO
ALTER TABLE [dbo].[words] CHECK CONSTRAINT [FK_words_ForeignWords]
GO
ALTER TABLE [dbo].[words]  WITH CHECK ADD  CONSTRAINT [FK_words_speechParts] FOREIGN KEY([speechPartId])
REFERENCES [dbo].[speechParts] ([id])
GO
ALTER TABLE [dbo].[words] CHECK CONSTRAINT [FK_words_speechParts]
GO
ALTER TABLE [dbo].[words]  WITH CHECK ADD  CONSTRAINT [FK_words_synonyms] FOREIGN KEY([synonym])
REFERENCES [dbo].[synonyms] ([id])
GO
ALTER TABLE [dbo].[words] CHECK CONSTRAINT [FK_words_synonyms]
GO
USE [master]
GO
ALTER DATABASE [dictionary] SET  READ_WRITE 
GO
