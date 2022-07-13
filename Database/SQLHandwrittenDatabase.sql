/****** Creating Database ******/
CREATE DATABASE OnlineMarket;
/****** Creating User Table ******/
USE [OnlineMarket]
GO

CREATE TABLE [dbo].[User](
	[ID] [bigint] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[IsDisabled] [bit] NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NOT NULL
) ON [PRIMARY]
GO

/****** Adding self-referencing foreign keys for user table ******/
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_Modification8] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([ID])
GO

ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_Creation8] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([ID])
GO

/****** Creating Category Table ******/
USE [OnlineMarket]
GO

CREATE TABLE [dbo].[Category](
	[ID] [bigint] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [nvarchar](50) NULL,
	[ImageURL] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL REFERENCES [User](ID),
	[ModifiedAt] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NOT NULL REFERENCES [User](ID),
) ON [PRIMARY]
GO



/****** Creating SubCategory Table ******/
CREATE TABLE [dbo].[SubCategory](
	[ID] [bigint] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [nvarchar](50) NULL,
	[CategoryID] [bigint] NOT NULL REFERENCES [Category](ID),
	[ImageURL] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL REFERENCES [User](ID),
	[ModifiedAt] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NOT NULL REFERENCES [User](ID),
) ON [PRIMARY]
GO
/****** Creating Product Table ******/
CREATE TABLE [dbo].[Product](
	[ID] [bigint] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](1) NOT NULL,
	[Price] [float] NOT NULL,
	[ImageURL] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL REFERENCES [User](ID),
	[ModifiedAt] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NOT NULL REFERENCES [User](ID)
) ON [PRIMARY]
GO
/****** Adding N to N table between Product and Subcategory ******/
CREATE TABLE [dbo].[ProductCategory](
	[ID] [bigint] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ProductID] [bigint] NOT NULL REFERENCES [Product](ID),
	[SubCategoryID] [bigint] NOT NULL REFERENCES [SubCategory](ID),
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL REFERENCES [User](ID),
	[ModifiedAt] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NOT NULL REFERENCES [User](ID)
) ON [PRIMARY]
GO
/****** Creating Address Table ******/
CREATE TABLE [dbo].[Address](
	[ID] [bigint] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [nvarchar](50) NULL,
	[UserID] [bigint] NOT NULL REFERENCES [User](ID),
	[Country] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL REFERENCES [User](ID),
	[ModifiedAt] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NOT NULL REFERENCES [User](ID)
) ON [PRIMARY]
GO


/****** Creating Order Table ******/
CREATE TABLE [dbo].[Order](
	[ID] [bigint] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Status] [nvarchar](50) NOT NULL,
	[AddressID] [bigint] NOT NULL REFERENCES [Address](ID),
	[UserID] [bigint] NOT NULL REFERENCES [User](ID),
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL REFERENCES [User](ID),
	[ModifiedAt] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NOT NULL REFERENCES [User](ID)
) ON [PRIMARY]
GO
/****** Adding N to N table between Order and Product ******/
CREATE TABLE [dbo].[OrderProduct](
	[ID] [bigint] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ProductID] [bigint] NOT NULL,
	[OrderID] [bigint] NOT NULL REFERENCES [Order](ID),
	[Quantity] [bigint] NOT NULL,
	[PriceOfSingleProduct] [bigint] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL REFERENCES [User](ID),
	[ModifiedAt] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NOT NULL REFERENCES [User](ID)
) ON [PRIMARY]
GO

