USE [master]
GO
/****** Object:  Database [DHL]    Script Date: 4/21/2020 10:17:41 PM ******/
CREATE DATABASE [DHL]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DHL', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\DHL.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DHL_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\DHL_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DHL] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DHL].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DHL] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DHL] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DHL] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DHL] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DHL] SET ARITHABORT OFF 
GO
ALTER DATABASE [DHL] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DHL] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DHL] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DHL] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DHL] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DHL] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DHL] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DHL] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DHL] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DHL] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DHL] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DHL] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DHL] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DHL] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DHL] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DHL] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DHL] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DHL] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DHL] SET  MULTI_USER 
GO
ALTER DATABASE [DHL] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DHL] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DHL] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DHL] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DHL] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DHL] SET QUERY_STORE = OFF
GO
USE [DHL]
GO
/****** Object:  Table [dbo].[tbl_address]    Script Date: 4/21/2020 10:17:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_address](
	[IdAddress] [int] IDENTITY(1,1) NOT NULL,
	[IdAddressType] [tinyint] NOT NULL,
	[AddressLabel] [varchar](100) NOT NULL,
	[Country] [varchar](50) NOT NULL,
	[Province] [nchar](10) NOT NULL,
	[City] [varchar](40) NOT NULL,
	[PostalCode] [varchar](5) NOT NULL,
	[PostAddress] [varchar](250) NOT NULL,
	[PostAddressNumber] [varchar](10) NOT NULL,
	[PostIntern] [varchar](10) NOT NULL,
	[OpenTimeStart] [varchar](5) NOT NULL,
	[OpenTimeEnd] [varchar](5) NOT NULL,
	[LunchTimeStart] [varchar](5) NOT NULL,
	[LunchTimeEnd] [varchar](5) NOT NULL,
	[ContactName] [varchar](25) NOT NULL,
 CONSTRAINT [PK_tbl_address] PRIMARY KEY CLUSTERED 
(
	[IdAddress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_address_type]    Script Date: 4/21/2020 10:17:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_address_type](
	[IdAddressType] [tinyint] IDENTITY(1,1) NOT NULL,
	[AdressType] [varchar](50) NOT NULL,
	[Description] [nchar](10) NOT NULL,
	[InsertBy] [int] NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateBy] [int] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_address_type] PRIMARY KEY CLUSTERED 
(
	[IdAddressType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_card_status]    Script Date: 4/21/2020 10:17:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_card_status](
	[IdCardStatus] [tinyint] IDENTITY(1,1) NOT NULL,
	[CardStatus] [varchar](50) NOT NULL,
	[UpdateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_tbl_card_status] PRIMARY KEY CLUSTERED 
(
	[IdCardStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_cards]    Script Date: 4/21/2020 10:17:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_cards](
	[IdCustomer] [varchar](50) NOT NULL,
	[IdCard] [varchar](50) NOT NULL,
	[Balance] [real] NOT NULL,
	[BalanceAvailable] [real] NOT NULL,
	[CardStatus] [tinyint] NOT NULL,
	[InsertBy] [int] NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCustomer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[IdCard] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_customer_address]    Script Date: 4/21/2020 10:17:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_customer_address](
	[IdCustomer] [varchar](50) NOT NULL,
	[IdAddress] [int] NOT NULL,
	[InsertBy] [int] NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCustomer] ASC,
	[IdAddress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_customer_discount]    Script Date: 4/21/2020 10:17:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_customer_discount](
	[IdCustomer] [varchar](50) NOT NULL,
	[IdDiscount] [int] NOT NULL,
	[CodeForActive] [varchar](255) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[InsertBy] [int] NOT NULL,
	[InsertDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCustomer] ASC,
	[IdDiscount] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_customer_logs]    Script Date: 4/21/2020 10:17:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_customer_logs](
	[PID] [bigint] IDENTITY(1,1) NOT NULL,
	[IdCustomer] [varchar](50) NOT NULL,
	[CustomerXML] [xml] NOT NULL,
	[InsertBy] [int] NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[IdTool] [varchar](100) NULL,
 CONSTRAINT [PK_tbl_customer_logs] PRIMARY KEY CLUSTERED 
(
	[PID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_customer_status]    Script Date: 4/21/2020 10:17:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_customer_status](
	[IdCustomerStatus] [tinyint] IDENTITY(1,1) NOT NULL,
	[Status] [varchar](20) NOT NULL,
	[Description] [varchar](100) NOT NULL,
	[InsertBy] [int] NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_tbl_customer_status] PRIMARY KEY CLUSTERED 
(
	[IdCustomerStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_customer_type]    Script Date: 4/21/2020 10:17:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_customer_type](
	[IdCustomerType] [tinyint] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[InsertBy] [int] NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_tbl_customer_type] PRIMARY KEY CLUSTERED 
(
	[IdCustomerType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_customers]    Script Date: 4/21/2020 10:17:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_customers](
	[IdCustomer] [varchar](50) NOT NULL,
	[CustomerType] [tinyint] NOT NULL,
	[CustomerStatus] [tinyint] NOT NULL,
	[Channel] [varchar](50) NOT NULL,
	[CompanyName] [varchar](150) NULL,
	[IVA] [varchar](150) NULL,
	[SDI] [varchar](150) NULL,
	[ContactName] [varchar](150) NULL,
	[FiscalCode] [varchar](16) NULL,
	[PEC] [varchar](250) NULL,
	[Email] [varchar](250) NOT NULL,
	[PhoneNumber] [varchar](25) NOT NULL,
	[InsertBy] [int] NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[IdDiscount] [int] NULL,
 CONSTRAINT [PK_tbl_customers] PRIMARY KEY CLUSTERED 
(
	[IdCustomer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_discount_filetab]    Script Date: 4/21/2020 10:17:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_discount_filetab](
	[IdDiscount] [int] NOT NULL,
	[path_locator] [hierarchyid] NOT NULL,
	[InsertBy] [int] NOT NULL,
	[InsertDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDiscount] ASC,
	[path_locator] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_discount_type]    Script Date: 4/21/2020 10:17:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_discount_type](
	[IdDiscountType] [tinyint] IDENTITY(1,1) NOT NULL,
	[DiscountTypeTitle] [varchar](50) NOT NULL,
	[Description] [varchar](100) NOT NULL,
	[InsertBy] [int] NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_tbl_discount_type] PRIMARY KEY CLUSTERED 
(
	[IdDiscountType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_discounts]    Script Date: 4/21/2020 10:17:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_discounts](
	[IdDiscount] [int] IDENTITY(1,1) NOT NULL,
	[DiscountTitle] [varchar](20) NOT NULL,
	[DiscountDescription] [varchar](150) NOT NULL,
	[DiscountType] [tinyint] NOT NULL,
	[DiscountPerc] [real] NOT NULL,
	[DiscountStartDate] [date] NOT NULL,
	[DiscountEndDate] [date] NOT NULL,
	[DiscountToActive] [bit] NOT NULL,
	[InsertBy] [int] NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_tbl_discounts] PRIMARY KEY CLUSTERED 
(
	[IdDiscount] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_filetab]    Script Date: 4/21/2020 10:17:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_filetab](
	[path_locator] [hierarchyid] NOT NULL,
	[stream_id] [uniqueidentifier] NOT NULL,
	[file_stream] [varbinary](max) NULL,
	[file_type] [nvarchar](255) NULL,
	[Nome] [nvarchar](255) NOT NULL,
	[parent_path_locator] [hierarchyid] NOT NULL,
	[cached_file_size] [bigint] NOT NULL,
	[creation_time] [datetime2](7) NOT NULL,
	[last_write_time] [datetime2](7) NOT NULL,
	[last_access_time] [datetime2](7) NOT NULL,
	[is_directory] [bit] NOT NULL,
	[is_offline] [bit] NOT NULL,
	[is_hidden] [bit] NOT NULL,
	[is_readonly] [bit] NOT NULL,
	[is_archive] [bit] NOT NULL,
	[is_system] [bit] NOT NULL,
	[is_temporary] [bit] NOT NULL,
 CONSTRAINT [PK_tbl_filetab] PRIMARY KEY CLUSTERED 
(
	[path_locator] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_product_discount]    Script Date: 4/21/2020 10:17:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_product_discount](
	[IdProduct] [varchar](50) NOT NULL,
	[IdDiscount] [int] NOT NULL,
	[CodeForActive] [varchar](255) NULL,
	[IsActive] [bit] NOT NULL,
	[InsertBy] [int] NULL,
	[InsertDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProduct] ASC,
	[IdDiscount] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_products]    Script Date: 4/21/2020 10:17:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_products](
	[IdProduct] [varchar](50) NOT NULL,
	[ProductName] [varchar](100) NOT NULL,
	[InsertBy] [int] NOT NULL,
	[InsertData] [datetime] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_tbl_products] PRIMARY KEY CLUSTERED 
(
	[IdProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_profile_permission]    Script Date: 4/21/2020 10:17:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_profile_permission](
	[ProfileSetName] [varchar](250) NOT NULL,
	[IdProfile] [int] NOT NULL,
	[ProfileCode] [varchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProfileSetName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_shipments]    Script Date: 4/21/2020 10:17:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_shipments](
	[PID] [bigint] IDENTITY(1,1) NOT NULL,
	[IdCostumer] [varchar](50) NULL,
	[AWB] [bigint] NOT NULL,
	[DatetimeCreation] [datetime] NOT NULL,
	[ImmediateInvoicing] [bit] NOT NULL,
	[CheckPointFound] [bit] NOT NULL,
	[ShipmentDate] [datetime] NOT NULL,
	[TotalInvoice] [real] NOT NULL,
	[isDeleted] [bit] NOT NULL,
	[InsertBy] [int] NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[IdTool] [varchar](100) NULL,
 CONSTRAINT [PK_tbl_shipments] PRIMARY KEY CLUSTERED 
(
	[PID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_tool_permission]    Script Date: 4/21/2020 10:17:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_tool_permission](
	[IdProfile] [int] IDENTITY(1,1) NOT NULL,
	[ProfileCode] [varchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProfile] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_tools]    Script Date: 4/21/2020 10:17:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_tools](
	[IdTool] [varchar](100) NOT NULL,
	[ToolName] [varchar](100) NOT NULL,
	[ToolKey] [binary](32) NOT NULL,
	[ToolStatus] [bit] NOT NULL,
	[IdProfile] [int] NOT NULL,
 CONSTRAINT [PK_tbl_tools] PRIMARY KEY CLUSTERED 
(
	[IdTool] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_transaction_logs]    Script Date: 4/21/2020 10:17:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_transaction_logs](
	[PID] [bigint] IDENTITY(1,1) NOT NULL,
	[IdCustomer] [varchar](50) NOT NULL,
	[IdCard] [varchar](50) NULL,
	[TransactionType] [tinyint] NOT NULL,
	[TransactionStatus] [tinyint] NOT NULL,
	[TransactionID] [varchar](18) NOT NULL,
	[TransactionDateTime] [datetime] NOT NULL,
	[Value] [real] NOT NULL,
	[AWB] [bigint] NULL,
	[AWBStatus] [bit] NOT NULL,
	[InsertBy] [int] NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[IdTool] [varchar](100) NULL,
 CONSTRAINT [PK_tbl_transaction_logs] PRIMARY KEY CLUSTERED 
(
	[PID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_user_type]    Script Date: 4/21/2020 10:17:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_user_type](
	[IdUserType] [tinyint] IDENTITY(1,1) NOT NULL,
	[UserTypeTitle] [varchar](50) NOT NULL,
	[Description] [varchar](100) NOT NULL,
	[InsertBy] [int] NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_tbl_user_type] PRIMARY KEY CLUSTERED 
(
	[IdUserType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_users]    Script Date: 4/21/2020 10:17:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_users](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[ContactName] [varchar](50) NOT NULL,
	[UserType] [tinyint] NOT NULL,
	[TitleOfCourtesy] [varchar](5) NOT NULL,
	[Birthdate] [datetime] NOT NULL,
	[Hiredate] [datetime] NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[Region] [varchar](50) NOT NULL,
	[Phone] [int] NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_users] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_address]  WITH CHECK ADD FOREIGN KEY([IdAddressType])
REFERENCES [dbo].[tbl_address_type] ([IdAddressType])
GO
ALTER TABLE [dbo].[tbl_address_type]  WITH CHECK ADD FOREIGN KEY([InsertBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_address_type]  WITH CHECK ADD FOREIGN KEY([UpdateBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_card_status]  WITH CHECK ADD FOREIGN KEY([UpdateBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_cards]  WITH CHECK ADD FOREIGN KEY([CardStatus])
REFERENCES [dbo].[tbl_card_status] ([IdCardStatus])
GO
ALTER TABLE [dbo].[tbl_cards]  WITH CHECK ADD FOREIGN KEY([IdCustomer])
REFERENCES [dbo].[tbl_customers] ([IdCustomer])
GO
ALTER TABLE [dbo].[tbl_cards]  WITH CHECK ADD FOREIGN KEY([InsertBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_cards]  WITH CHECK ADD FOREIGN KEY([UpdateBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_customer_address]  WITH CHECK ADD FOREIGN KEY([IdAddress])
REFERENCES [dbo].[tbl_address] ([IdAddress])
GO
ALTER TABLE [dbo].[tbl_customer_address]  WITH CHECK ADD FOREIGN KEY([IdCustomer])
REFERENCES [dbo].[tbl_customers] ([IdCustomer])
GO
ALTER TABLE [dbo].[tbl_customer_address]  WITH CHECK ADD FOREIGN KEY([InsertBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_customer_address]  WITH CHECK ADD FOREIGN KEY([UpdateBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_customer_discount]  WITH CHECK ADD FOREIGN KEY([IdCustomer])
REFERENCES [dbo].[tbl_customers] ([IdCustomer])
GO
ALTER TABLE [dbo].[tbl_customer_discount]  WITH CHECK ADD FOREIGN KEY([IdDiscount])
REFERENCES [dbo].[tbl_discounts] ([IdDiscount])
GO
ALTER TABLE [dbo].[tbl_customer_discount]  WITH CHECK ADD FOREIGN KEY([InsertBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_customer_logs]  WITH CHECK ADD FOREIGN KEY([IdCustomer])
REFERENCES [dbo].[tbl_customers] ([IdCustomer])
GO
ALTER TABLE [dbo].[tbl_customer_logs]  WITH CHECK ADD FOREIGN KEY([IdTool])
REFERENCES [dbo].[tbl_tools] ([IdTool])
GO
ALTER TABLE [dbo].[tbl_customer_logs]  WITH CHECK ADD FOREIGN KEY([InsertBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_customer_status]  WITH CHECK ADD FOREIGN KEY([InsertBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_customer_status]  WITH CHECK ADD FOREIGN KEY([UpdateBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_customer_type]  WITH CHECK ADD FOREIGN KEY([InsertBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_customer_type]  WITH CHECK ADD FOREIGN KEY([UpdateBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_customers]  WITH CHECK ADD FOREIGN KEY([CustomerType])
REFERENCES [dbo].[tbl_customer_type] ([IdCustomerType])
GO
ALTER TABLE [dbo].[tbl_customers]  WITH CHECK ADD FOREIGN KEY([CustomerStatus])
REFERENCES [dbo].[tbl_customer_status] ([IdCustomerStatus])
GO
ALTER TABLE [dbo].[tbl_customers]  WITH CHECK ADD FOREIGN KEY([IdDiscount])
REFERENCES [dbo].[tbl_discounts] ([IdDiscount])
GO
ALTER TABLE [dbo].[tbl_customers]  WITH CHECK ADD FOREIGN KEY([InsertBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_customers]  WITH CHECK ADD FOREIGN KEY([UpdateBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_discount_filetab]  WITH CHECK ADD FOREIGN KEY([IdDiscount])
REFERENCES [dbo].[tbl_discounts] ([IdDiscount])
GO
ALTER TABLE [dbo].[tbl_discount_filetab]  WITH CHECK ADD FOREIGN KEY([InsertBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_discount_filetab]  WITH CHECK ADD FOREIGN KEY([path_locator])
REFERENCES [dbo].[tbl_filetab] ([path_locator])
GO
ALTER TABLE [dbo].[tbl_discount_type]  WITH CHECK ADD FOREIGN KEY([InsertBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_discount_type]  WITH CHECK ADD FOREIGN KEY([UpdateBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_discounts]  WITH CHECK ADD FOREIGN KEY([DiscountType])
REFERENCES [dbo].[tbl_discount_type] ([IdDiscountType])
GO
ALTER TABLE [dbo].[tbl_discounts]  WITH CHECK ADD FOREIGN KEY([InsertBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_discounts]  WITH CHECK ADD FOREIGN KEY([UpdateBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_product_discount]  WITH CHECK ADD FOREIGN KEY([IdDiscount])
REFERENCES [dbo].[tbl_discounts] ([IdDiscount])
GO
ALTER TABLE [dbo].[tbl_product_discount]  WITH CHECK ADD FOREIGN KEY([InsertBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_product_discount]  WITH CHECK ADD  CONSTRAINT [FK_tbl_product_discount_tbl_products] FOREIGN KEY([IdProduct])
REFERENCES [dbo].[tbl_products] ([IdProduct])
GO
ALTER TABLE [dbo].[tbl_product_discount] CHECK CONSTRAINT [FK_tbl_product_discount_tbl_products]
GO
ALTER TABLE [dbo].[tbl_products]  WITH CHECK ADD FOREIGN KEY([InsertBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_products]  WITH CHECK ADD FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_profile_permission]  WITH CHECK ADD FOREIGN KEY([IdProfile])
REFERENCES [dbo].[tbl_tool_permission] ([IdProfile])
GO
ALTER TABLE [dbo].[tbl_shipments]  WITH CHECK ADD FOREIGN KEY([IdCostumer])
REFERENCES [dbo].[tbl_customers] ([IdCustomer])
GO
ALTER TABLE [dbo].[tbl_shipments]  WITH CHECK ADD FOREIGN KEY([IdTool])
REFERENCES [dbo].[tbl_tools] ([IdTool])
GO
ALTER TABLE [dbo].[tbl_shipments]  WITH CHECK ADD FOREIGN KEY([InsertBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_shipments]  WITH CHECK ADD FOREIGN KEY([UpdateBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_tools]  WITH CHECK ADD FOREIGN KEY([IdProfile])
REFERENCES [dbo].[tbl_tool_permission] ([IdProfile])
GO
ALTER TABLE [dbo].[tbl_transaction_logs]  WITH CHECK ADD FOREIGN KEY([IdCard])
REFERENCES [dbo].[tbl_cards] ([IdCard])
GO
ALTER TABLE [dbo].[tbl_transaction_logs]  WITH CHECK ADD FOREIGN KEY([IdCustomer])
REFERENCES [dbo].[tbl_customers] ([IdCustomer])
GO
ALTER TABLE [dbo].[tbl_transaction_logs]  WITH CHECK ADD FOREIGN KEY([IdTool])
REFERENCES [dbo].[tbl_tools] ([IdTool])
GO
ALTER TABLE [dbo].[tbl_transaction_logs]  WITH CHECK ADD FOREIGN KEY([InsertBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_users]  WITH CHECK ADD FOREIGN KEY([UserType])
REFERENCES [dbo].[tbl_user_type] ([IdUserType])
GO
USE [master]
GO
ALTER DATABASE [DHL] SET  READ_WRITE 
GO
