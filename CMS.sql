/* Script for Database creation*/
USE [master]
GO

DROP DATABASE [CMS]
GO

CREATE DATABASE [CMS] 
GO

/* Script for table creation*/


USE [CMS]
GO

DROP TABLE [dbo].[Tickets]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tickets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [nchar](50) NULL,
	[Category] [nchar](50) NULL,
	[CreatedBy] [nchar](50) NULL,
	[CreatedDate] [date] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


