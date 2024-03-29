USE [master]
GO
/****** Object:  Database [RoomRetalManagement]    Script Date: 5/6/2023 6:36:51 PM ******/
CREATE DATABASE [RoomRetalManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RoomRetalManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.TUNG\MSSQL\DATA\RoomRetalManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RoomRetalManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.TUNG\MSSQL\DATA\RoomRetalManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [RoomRetalManagement] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RoomRetalManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RoomRetalManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RoomRetalManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RoomRetalManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RoomRetalManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RoomRetalManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [RoomRetalManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RoomRetalManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RoomRetalManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RoomRetalManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RoomRetalManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RoomRetalManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RoomRetalManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RoomRetalManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RoomRetalManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RoomRetalManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RoomRetalManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RoomRetalManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RoomRetalManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RoomRetalManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RoomRetalManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RoomRetalManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RoomRetalManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RoomRetalManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [RoomRetalManagement] SET  MULTI_USER 
GO
ALTER DATABASE [RoomRetalManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RoomRetalManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RoomRetalManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RoomRetalManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RoomRetalManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RoomRetalManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [RoomRetalManagement] SET QUERY_STORE = OFF
GO
USE [RoomRetalManagement]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 5/6/2023 6:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Area]    Script Date: 5/6/2023 6:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Area](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Area] [decimal](18, 0) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contract]    Script Date: 5/6/2023 6:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contract](
	[ContractID] [int] IDENTITY(1,1) NOT NULL,
	[RoomID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[DateOfHire] [date] NOT NULL,
	[DateOfExpiration] [date] NOT NULL,
 CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED 
(
	[ContractID] ASC,
	[RoomID] ASC,
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 5/6/2023 6:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[RoomID] [int] NULL,
	[Name] [varchar](100) NOT NULL,
	[Sex] [nchar](10) NOT NULL,
	[DOB] [date] NOT NULL,
	[Phone] [varchar](20) NOT NULL,
	[Email] [varchar](100) NULL,
	[Address] [varchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer_Room]    Script Date: 5/6/2023 6:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer_Room](
	[CustomerID] [int] NOT NULL,
	[RoomID] [int] NOT NULL,
 CONSTRAINT [PK_Customer_Room] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC,
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Floor]    Script Date: 5/6/2023 6:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Floor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Floor] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 5/6/2023 6:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[InvoiceID] [int] IDENTITY(1,1) NOT NULL,
	[RoomID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[InvoiceType] [nchar](20) NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[InvoiceID] ASC,
	[RoomID] ASC,
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NumOfPerson]    Script Date: 5/6/2023 6:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NumOfPerson](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NumOfPerson] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 5/6/2023 6:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[RoomID] [int] IDENTITY(1,1) NOT NULL,
	[RoomName] [nchar](10) NOT NULL,
	[Floor] [int] NOT NULL,
	[NumOfPerson] [int] NOT NULL,
	[NumOfLiving] [int] NOT NULL,
	[Area] [decimal](18, 0) NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room_Customer]    Script Date: 5/6/2023 6:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room_Customer](
	[RoomID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
 CONSTRAINT [PK_Room_Customer] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC,
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomPrice]    Script Date: 5/6/2023 6:36:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomPrice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Price] [money] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Room] ADD  CONSTRAINT [DF_Room_NumOfPerson]  DEFAULT ((0)) FOR [NumOfPerson]
GO
ALTER TABLE [dbo].[Room] ADD  CONSTRAINT [DF_Room_NumOfLiving]  DEFAULT ((0)) FOR [NumOfLiving]
GO
ALTER TABLE [dbo].[Contract]  WITH CHECK ADD  CONSTRAINT [FK_Contract_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Contract] CHECK CONSTRAINT [FK_Contract_Customer]
GO
ALTER TABLE [dbo].[Contract]  WITH CHECK ADD  CONSTRAINT [FK_Contract_Room] FOREIGN KEY([RoomID])
REFERENCES [dbo].[Room] ([RoomID])
GO
ALTER TABLE [dbo].[Contract] CHECK CONSTRAINT [FK_Contract_Room]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Room] FOREIGN KEY([RoomID])
REFERENCES [dbo].[Room] ([RoomID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Room]
GO
ALTER TABLE [dbo].[Customer_Room]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Room_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Customer_Room] CHECK CONSTRAINT [FK_Customer_Room_Customer]
GO
ALTER TABLE [dbo].[Customer_Room]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Room_Room] FOREIGN KEY([RoomID])
REFERENCES [dbo].[Room] ([RoomID])
GO
ALTER TABLE [dbo].[Customer_Room] CHECK CONSTRAINT [FK_Customer_Room_Room]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Customer]
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Room] FOREIGN KEY([RoomID])
REFERENCES [dbo].[Room] ([RoomID])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Room]
GO
ALTER TABLE [dbo].[Room_Customer]  WITH CHECK ADD  CONSTRAINT [FK_Room_Customer_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Room_Customer] CHECK CONSTRAINT [FK_Room_Customer_Customer]
GO
ALTER TABLE [dbo].[Room_Customer]  WITH CHECK ADD  CONSTRAINT [FK_Room_Customer_Room] FOREIGN KEY([RoomID])
REFERENCES [dbo].[Room] ([RoomID])
GO
ALTER TABLE [dbo].[Room_Customer] CHECK CONSTRAINT [FK_Room_Customer_Room]
GO
USE [master]
GO
ALTER DATABASE [RoomRetalManagement] SET  READ_WRITE 
GO
