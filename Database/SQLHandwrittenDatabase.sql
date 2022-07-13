/****** Creating Database ******/
CREATE DATABASE Market;
/****** Creating User Table ******/
USE [Market]
GO

CREATE TABLE [dbo].[User](
	[ID] [UNIQUEIDENTIFIER] NOT NULL PRIMARY KEY,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[IsDisabled] [bit] NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [UNIQUEIDENTIFIER] NOT NULL,
	[ModifiedAt] [datetime] NOT NULL,
	[ModifiedBy] [UNIQUEIDENTIFIER] NOT NULL
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
USE [Market]
GO

CREATE TABLE [dbo].[Category](
	[ID] [UNIQUEIDENTIFIER] NOT NULL PRIMARY KEY,
	[Name] [nvarchar](50) NULL,
	[ImageURL] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [UNIQUEIDENTIFIER] NOT NULL REFERENCES [User](ID),
	[ModifiedAt] [datetime] NOT NULL,
	[ModifiedBy] [UNIQUEIDENTIFIER] NOT NULL REFERENCES [User](ID),
) ON [PRIMARY]
GO



/****** Creating SubCategory Table ******/
CREATE TABLE [dbo].[SubCategory](
	[ID] [UNIQUEIDENTIFIER] NOT NULL PRIMARY KEY,
	[Name] [nvarchar](50) NULL,
	[CategoryID] [UNIQUEIDENTIFIER] NOT NULL REFERENCES [Category](ID),
	[ImageURL] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [UNIQUEIDENTIFIER] NOT NULL REFERENCES [User](ID),
	[ModifiedAt] [datetime] NOT NULL,
	[ModifiedBy] [UNIQUEIDENTIFIER] NOT NULL REFERENCES [User](ID),
) ON [PRIMARY]
GO
/****** Creating Product Table ******/
CREATE TABLE [dbo].[Product](
	[ID] [UNIQUEIDENTIFIER] NOT NULL PRIMARY KEY,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](1) NOT NULL,
	[Price] [float] NOT NULL,
	[ImageURL] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [UNIQUEIDENTIFIER] NOT NULL REFERENCES [User](ID),
	[ModifiedAt] [datetime] NOT NULL,
	[ModifiedBy] [UNIQUEIDENTIFIER] NOT NULL REFERENCES [User](ID)
) ON [PRIMARY]
GO
/****** Adding N to N table between Product and Subcategory ******/
CREATE TABLE [dbo].[ProductCategory](
	[ID] [UNIQUEIDENTIFIER] NOT NULL PRIMARY KEY,
	[ProductID] [UNIQUEIDENTIFIER] NOT NULL REFERENCES [Product](ID),
	[SubCategoryID] [UNIQUEIDENTIFIER] NOT NULL REFERENCES [SubCategory](ID),
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [UNIQUEIDENTIFIER] NOT NULL REFERENCES [User](ID),
	[ModifiedAt] [datetime] NOT NULL,
	[ModifiedBy] [UNIQUEIDENTIFIER] NOT NULL REFERENCES [User](ID)
) ON [PRIMARY]
GO
/****** Creating Address Table ******/
CREATE TABLE [dbo].[Address](
	[ID] [UNIQUEIDENTIFIER] NOT NULL PRIMARY KEY,
	[Name] [nvarchar](50) NULL,
	[UserID] [UNIQUEIDENTIFIER] NOT NULL REFERENCES [User](ID),
	[Country] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [UNIQUEIDENTIFIER] NOT NULL REFERENCES [User](ID),
	[ModifiedAt] [datetime] NOT NULL,
	[ModifiedBy] [UNIQUEIDENTIFIER] NOT NULL REFERENCES [User](ID)
) ON [PRIMARY]
GO


/****** Creating Order Table ******/
CREATE TABLE [dbo].[Order](
	[ID] [UNIQUEIDENTIFIER] NOT NULL PRIMARY KEY,
	[Status] [nvarchar](50) NOT NULL,
	[AddressID] [UNIQUEIDENTIFIER] NOT NULL REFERENCES [Address](ID),
	[UserID] [UNIQUEIDENTIFIER] NOT NULL REFERENCES [User](ID),
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [UNIQUEIDENTIFIER] NOT NULL REFERENCES [User](ID),
	[ModifiedAt] [datetime] NOT NULL,
	[ModifiedBy] [UNIQUEIDENTIFIER] NOT NULL REFERENCES [User](ID)
) ON [PRIMARY]
GO
/****** Adding N to N table between Order and Product ******/
CREATE TABLE [dbo].[OrderProduct](
	[ID] [UNIQUEIDENTIFIER] NOT NULL PRIMARY KEY,
	[ProductID] [bigint] NOT NULL,
	[OrderID] [UNIQUEIDENTIFIER] NOT NULL REFERENCES [Order](ID),
	[Quantity] [bigint] NOT NULL,
	[PriceOfSingleProduct] [bigint] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [UNIQUEIDENTIFIER] NOT NULL REFERENCES [User](ID),
	[ModifiedAt] [datetime] NOT NULL,
	[ModifiedBy] [UNIQUEIDENTIFIER] NOT NULL REFERENCES [User](ID)
) ON [PRIMARY]
GO