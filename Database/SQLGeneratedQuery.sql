USE [master]
GO
/****** Object:  Database [Market]    Script Date: 7/13/2022 6:58:39 PM ******/
CREATE DATABASE [Market]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Market', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Market.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Market_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Market_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Market] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Market].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Market] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Market] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Market] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Market] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Market] SET ARITHABORT OFF 
GO
ALTER DATABASE [Market] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Market] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Market] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Market] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Market] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Market] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Market] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Market] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Market] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Market] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Market] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Market] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Market] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Market] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Market] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Market] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Market] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Market] SET RECOVERY FULL 
GO
ALTER DATABASE [Market] SET  MULTI_USER 
GO
ALTER DATABASE [Market] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Market] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Market] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Market] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Market] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Market] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Market', N'ON'
GO
ALTER DATABASE [Market] SET QUERY_STORE = OFF
GO
USE [Market]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/13/2022 6:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 7/13/2022 6:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[UserID] [nvarchar](450) NULL,
	[Country] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](450) NULL,
	[ModifiedAt] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](450) NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 7/13/2022 6:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 7/13/2022 6:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 7/13/2022 6:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 7/13/2022 6:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 7/13/2022 6:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 7/13/2022 6:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[ID] [nvarchar](450) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[IsDisabled] [bit] NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](450) NULL,
	[ModifiedAt] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](450) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 7/13/2022 6:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 7/13/2022 6:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[ImageURL] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](450) NULL,
	[ModifiedAt] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](450) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 7/13/2022 6:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[ID] [uniqueidentifier] NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[AddressID] [uniqueidentifier] NOT NULL,
	[UserID] [nvarchar](450) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](450) NULL,
	[ModifiedAt] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](450) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderProduct]    Script Date: 7/13/2022 6:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderProduct](
	[ID] [uniqueidentifier] NOT NULL,
	[ProductID] [bigint] NOT NULL,
	[OrderID] [uniqueidentifier] NOT NULL,
	[Quantity] [bigint] NOT NULL,
	[PriceOfSingleProduct] [bigint] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](450) NULL,
	[ModifiedAt] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](450) NULL,
 CONSTRAINT [PK_OrderProduct] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 7/13/2022 6:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](1) NOT NULL,
	[Price] [float] NOT NULL,
	[ImageURL] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](450) NULL,
	[ModifiedAt] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](450) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 7/13/2022 6:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[ID] [uniqueidentifier] NOT NULL,
	[ProductID] [uniqueidentifier] NOT NULL,
	[SubCategoryID] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](450) NULL,
	[ModifiedAt] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](450) NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubCategory]    Script Date: 7/13/2022 6:58:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubCategory](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[CategoryID] [uniqueidentifier] NOT NULL,
	[ImageURL] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](450) NULL,
	[ModifiedAt] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](450) NULL,
 CONSTRAINT [PK_SubCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Address_CreatedBy]    Script Date: 7/13/2022 6:58:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_Address_CreatedBy] ON [dbo].[Address]
(
	[CreatedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Address_ModifiedBy]    Script Date: 7/13/2022 6:58:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_Address_ModifiedBy] ON [dbo].[Address]
(
	[ModifiedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Address_UserID]    Script Date: 7/13/2022 6:58:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_Address_UserID] ON [dbo].[Address]
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 7/13/2022 6:58:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 7/13/2022 6:58:39 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 7/13/2022 6:58:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 7/13/2022 6:58:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 7/13/2022 6:58:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 7/13/2022 6:58:39 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUsers_CreatedBy]    Script Date: 7/13/2022 6:58:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUsers_CreatedBy] ON [dbo].[AspNetUsers]
(
	[CreatedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUsers_ModifiedBy]    Script Date: 7/13/2022 6:58:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUsers_ModifiedBy] ON [dbo].[AspNetUsers]
(
	[ModifiedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 7/13/2022 6:58:39 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Category_CreatedBy]    Script Date: 7/13/2022 6:58:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_Category_CreatedBy] ON [dbo].[Category]
(
	[CreatedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Category_ModifiedBy]    Script Date: 7/13/2022 6:58:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_Category_ModifiedBy] ON [dbo].[Category]
(
	[ModifiedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Order_AddressID]    Script Date: 7/13/2022 6:58:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_Order_AddressID] ON [dbo].[Order]
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Order_CreatedBy]    Script Date: 7/13/2022 6:58:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_Order_CreatedBy] ON [dbo].[Order]
(
	[CreatedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Order_ModifiedBy]    Script Date: 7/13/2022 6:58:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_Order_ModifiedBy] ON [dbo].[Order]
(
	[ModifiedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Order_UserID]    Script Date: 7/13/2022 6:58:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_Order_UserID] ON [dbo].[Order]
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_OrderProduct_CreatedBy]    Script Date: 7/13/2022 6:58:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderProduct_CreatedBy] ON [dbo].[OrderProduct]
(
	[CreatedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_OrderProduct_ModifiedBy]    Script Date: 7/13/2022 6:58:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderProduct_ModifiedBy] ON [dbo].[OrderProduct]
(
	[ModifiedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderProduct_OrderID]    Script Date: 7/13/2022 6:58:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderProduct_OrderID] ON [dbo].[OrderProduct]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Product_CreatedBy]    Script Date: 7/13/2022 6:58:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_Product_CreatedBy] ON [dbo].[Product]
(
	[CreatedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Product_ModifiedBy]    Script Date: 7/13/2022 6:58:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_Product_ModifiedBy] ON [dbo].[Product]
(
	[ModifiedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ProductCategory_CreatedBy]    Script Date: 7/13/2022 6:58:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductCategory_CreatedBy] ON [dbo].[ProductCategory]
(
	[CreatedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ProductCategory_ModifiedBy]    Script Date: 7/13/2022 6:58:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductCategory_ModifiedBy] ON [dbo].[ProductCategory]
(
	[ModifiedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductCategory_ProductID]    Script Date: 7/13/2022 6:58:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductCategory_ProductID] ON [dbo].[ProductCategory]
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductCategory_SubCategoryID]    Script Date: 7/13/2022 6:58:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductCategory_SubCategoryID] ON [dbo].[ProductCategory]
(
	[SubCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SubCategory_CategoryID]    Script Date: 7/13/2022 6:58:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_SubCategory_CategoryID] ON [dbo].[SubCategory]
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_SubCategory_CreatedBy]    Script Date: 7/13/2022 6:58:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_SubCategory_CreatedBy] ON [dbo].[SubCategory]
(
	[CreatedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_SubCategory_ModifiedBy]    Script Date: 7/13/2022 6:58:39 PM ******/
CREATE NONCLUSTERED INDEX [IX_SubCategory_ModifiedBy] ON [dbo].[SubCategory]
(
	[ModifiedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK__Address__Created__3B75D760] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[AspNetUsers] ([ID])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK__Address__Created__3B75D760]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK__Address__Modifie__3C69FB99] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[AspNetUsers] ([ID])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK__Address__Modifie__3C69FB99]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK__Address__UserID__3A81B327] FOREIGN KEY([UserID])
REFERENCES [dbo].[AspNetUsers] ([ID])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK__Address__UserID__3A81B327]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_Creation8] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[AspNetUsers] ([ID])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_Creation8]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_Modification8] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[AspNetUsers] ([ID])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_Modification8]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK__Category__Create__286302EC] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[AspNetUsers] ([ID])
GO
ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK__Category__Create__286302EC]
GO
ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK__Category__Modifi__29572725] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[AspNetUsers] ([ID])
GO
ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK__Category__Modifi__29572725]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK__Order__AddressID__3F466844] FOREIGN KEY([AddressID])
REFERENCES [dbo].[Address] ([ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK__Order__AddressID__3F466844]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK__Order__CreatedBy__412EB0B6] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[AspNetUsers] ([ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK__Order__CreatedBy__412EB0B6]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK__Order__ModifiedB__4222D4EF] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[AspNetUsers] ([ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK__Order__ModifiedB__4222D4EF]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK__Order__UserID__403A8C7D] FOREIGN KEY([UserID])
REFERENCES [dbo].[AspNetUsers] ([ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK__Order__UserID__403A8C7D]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK__OrderProd__Creat__45F365D3] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[AspNetUsers] ([ID])
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK__OrderProd__Creat__45F365D3]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK__OrderProd__Modif__46E78A0C] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[AspNetUsers] ([ID])
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK__OrderProd__Modif__46E78A0C]
GO
ALTER TABLE [dbo].[OrderProduct]  WITH CHECK ADD  CONSTRAINT [FK__OrderProd__Order__44FF419A] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([ID])
GO
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK__OrderProd__Order__44FF419A]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK__Product__Created__30F848ED] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[AspNetUsers] ([ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK__Product__Created__30F848ED]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK__Product__Modifie__31EC6D26] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[AspNetUsers] ([ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK__Product__Modifie__31EC6D26]
GO
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK__ProductCa__Creat__36B12243] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[AspNetUsers] ([ID])
GO
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK__ProductCa__Creat__36B12243]
GO
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK__ProductCa__Modif__37A5467C] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[AspNetUsers] ([ID])
GO
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK__ProductCa__Modif__37A5467C]
GO
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK__ProductCa__Produ__34C8D9D1] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK__ProductCa__Produ__34C8D9D1]
GO
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK__ProductCa__SubCa__35BCFE0A] FOREIGN KEY([SubCategoryID])
REFERENCES [dbo].[SubCategory] ([ID])
GO
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK__ProductCa__SubCa__35BCFE0A]
GO
ALTER TABLE [dbo].[SubCategory]  WITH CHECK ADD  CONSTRAINT [FK__SubCatego__Categ__2C3393D0] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[SubCategory] CHECK CONSTRAINT [FK__SubCatego__Categ__2C3393D0]
GO
ALTER TABLE [dbo].[SubCategory]  WITH CHECK ADD  CONSTRAINT [FK__SubCatego__Creat__2D27B809] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[AspNetUsers] ([ID])
GO
ALTER TABLE [dbo].[SubCategory] CHECK CONSTRAINT [FK__SubCatego__Creat__2D27B809]
GO
ALTER TABLE [dbo].[SubCategory]  WITH CHECK ADD  CONSTRAINT [FK__SubCatego__Modif__2E1BDC42] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[AspNetUsers] ([ID])
GO
ALTER TABLE [dbo].[SubCategory] CHECK CONSTRAINT [FK__SubCatego__Modif__2E1BDC42]
GO
USE [master]
GO
ALTER DATABASE [Market] SET  READ_WRITE 
GO
