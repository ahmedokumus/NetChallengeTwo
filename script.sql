USE [master]
GO
/****** Object:  Database [NetChallengeTwoDbContext]    Script Date: 5.06.2024 00:21:48 ******/
CREATE DATABASE [NetChallengeTwoDbContext]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NetChallengeTwoDbContext', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\NetChallengeTwoDbContext.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NetChallengeTwoDbContext_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\NetChallengeTwoDbContext_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NetChallengeTwoDbContext].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET ARITHABORT OFF 
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET  ENABLE_BROKER 
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET RECOVERY FULL 
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET  MULTI_USER 
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'NetChallengeTwoDbContext', N'ON'
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET QUERY_STORE = ON
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [NetChallengeTwoDbContext]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5.06.2024 00:21:48 ******/
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
/****** Object:  Table [dbo].[CarrierConfigurations]    Script Date: 5.06.2024 00:21:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarrierConfigurations](
	[CarrierConfigurationId] [int] IDENTITY(1,1) NOT NULL,
	[CarrierId] [int] NOT NULL,
	[CarrierMaxDesi] [int] NOT NULL,
	[CarrierMinDesi] [int] NOT NULL,
	[CarrierCost] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_CarrierConfigurations] PRIMARY KEY CLUSTERED 
(
	[CarrierConfigurationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carriers]    Script Date: 5.06.2024 00:21:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carriers](
	[CarrierId] [int] IDENTITY(1,1) NOT NULL,
	[CarrierName] [nvarchar](max) NOT NULL,
	[CarrierIsActive] [bit] NOT NULL,
	[CarrierPlusDesiCost] [int] NOT NULL,
	[CarrierConfigurationId] [int] NOT NULL,
 CONSTRAINT [PK_Carriers] PRIMARY KEY CLUSTERED 
(
	[CarrierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 5.06.2024 00:21:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[CarrierId] [int] NOT NULL,
	[OrderDesi] [int] NOT NULL,
	[OrderDate] [datetime2](7) NOT NULL,
	[OrderCarrierCost] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240601215402_initial', N'6.0.31')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240601220849_mig_1', N'6.0.31')
GO
SET IDENTITY_INSERT [dbo].[CarrierConfigurations] ON 

INSERT [dbo].[CarrierConfigurations] ([CarrierConfigurationId], [CarrierId], [CarrierMaxDesi], [CarrierMinDesi], [CarrierCost]) VALUES (1, 4, 10, 1, CAST(32.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[CarrierConfigurations] OFF
GO
SET IDENTITY_INSERT [dbo].[Carriers] ON 

INSERT [dbo].[Carriers] ([CarrierId], [CarrierName], [CarrierIsActive], [CarrierPlusDesiCost], [CarrierConfigurationId]) VALUES (4, N'Test1', 1, 4, 1)
SET IDENTITY_INSERT [dbo].[Carriers] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderId], [CarrierId], [OrderDesi], [OrderDate], [OrderCarrierCost]) VALUES (5, 4, 13, CAST(N'2024-06-05T00:09:03.4387894' AS DateTime2), CAST(44.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([OrderId], [CarrierId], [OrderDesi], [OrderDate], [OrderCarrierCost]) VALUES (6, 4, 5, CAST(N'2024-06-05T00:17:41.2346706' AS DateTime2), CAST(32.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
/****** Object:  Index [IX_Carriers_CarrierConfigurationId]    Script Date: 5.06.2024 00:21:49 ******/
CREATE NONCLUSTERED INDEX [IX_Carriers_CarrierConfigurationId] ON [dbo].[Carriers]
(
	[CarrierConfigurationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_CarrierId]    Script Date: 5.06.2024 00:21:49 ******/
CREATE NONCLUSTERED INDEX [IX_Orders_CarrierId] ON [dbo].[Orders]
(
	[CarrierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Carriers]  WITH CHECK ADD  CONSTRAINT [FK_Carriers_CarrierConfigurations_CarrierConfigurationId] FOREIGN KEY([CarrierConfigurationId])
REFERENCES [dbo].[CarrierConfigurations] ([CarrierConfigurationId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Carriers] CHECK CONSTRAINT [FK_Carriers_CarrierConfigurations_CarrierConfigurationId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Carriers_CarrierId] FOREIGN KEY([CarrierId])
REFERENCES [dbo].[Carriers] ([CarrierId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Carriers_CarrierId]
GO
USE [master]
GO
ALTER DATABASE [NetChallengeTwoDbContext] SET  READ_WRITE 
GO
