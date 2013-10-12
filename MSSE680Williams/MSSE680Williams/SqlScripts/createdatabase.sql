USE [master]
GO

/****** Object:  Database [andy680]    Script Date: 9/11/2013 8:50:00 PM ******/
CREATE DATABASE [andy680]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'andy680', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\andy680.mdf' , SIZE = 4000KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'andy680_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\andy680_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [andy680] SET COMPATIBILITY_LEVEL = 110
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [andy680].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [andy680] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [andy680] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [andy680] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [andy680] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [andy680] SET ARITHABORT OFF 
GO

ALTER DATABASE [andy680] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [andy680] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [andy680] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [andy680] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [andy680] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [andy680] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [andy680] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [andy680] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [andy680] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [andy680] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [andy680] SET  DISABLE_BROKER 
GO

ALTER DATABASE [andy680] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [andy680] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [andy680] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [andy680] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [andy680] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [andy680] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [andy680] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [andy680] SET RECOVERY FULL 
GO

ALTER DATABASE [andy680] SET  MULTI_USER 
GO

ALTER DATABASE [andy680] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [andy680] SET DB_CHAINING OFF 
GO

ALTER DATABASE [andy680] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [andy680] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [andy680] SET  READ_WRITE 
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

USE [andy680]
GO

/****** Object:  Tables ******/
CREATE TABLE [dbo].[Organizations](
	[OrganizationId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Street] [nvarchar](100) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[State] [nvarchar](2) NOT NULL,
	[Zip] [nvarchar](10) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
 CONSTRAINT [PK_Organizations] PRIMARY KEY CLUSTERED 
(
	[OrganizationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[Messages](
	[MessageId] [int] IDENTITY(1,1) NOT NULL,
	[CorrelationIdentifier] [int] NOT NULL,
	[SendingOrgId] [int] NOT NULL,
	[ReceivingOrgId] [int] NOT NULL,
	[Severity] [int] NOT NULL,
	[OrgMessage] [nvarchar](max) NOT NULL,
	[Timestamp] [datetime] NOT NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[MessageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_Organizations] FOREIGN KEY([ReceivingOrgId])
REFERENCES [dbo].[Organizations] ([OrganizationId])
GO

ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_Organizations]
GO

ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_Organizations2] FOREIGN KEY([SendingOrgId])
REFERENCES [dbo].[Organizations] ([OrganizationId])
GO

ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_Organizations2]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'make sure each receiving org has a parent' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Messages', @level2type=N'CONSTRAINT',@level2name=N'FK_Messages_Organizations'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'make sure each sending org has a parent' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Messages', @level2type=N'CONSTRAINT',@level2name=N'FK_Messages_Organizations2'
GO



CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[OrganizationId] [int] NOT NULL,
	[AdminFlag] [bit] NOT NULL,
	[ActiveDate] [datetime] NOT NULL,
	[InactiveDate] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Organization] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organizations] ([OrganizationId])
GO

ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Organization]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'each user has only one organization' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'CONSTRAINT',@level2name=N'FK_Users_Organization'
GO

/*Insert one row for the Organizations and Users tables*/
/*running the unit tests after these inserts should work*/
insert into Organizations values ('TestOrg', 'Testing St', 'Anytown', 'CO', '80000', '2013-09-14 06:30:00.000', '2099-09-14 06:30:00.000');
insert into Users values ('Seed', 'testing', 'Seed', 'User', 1, 0, '2013-09-14 00:00:00.000', '2099-09-14 00:00:00.000');
GO