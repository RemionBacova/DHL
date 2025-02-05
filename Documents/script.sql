USE [master]
GO
/****** Object:  Database [DHL]    Script Date: 5/12/2020 2:22:29 PM ******/
CREATE DATABASE [DHL]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DHL', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DHL.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DHL_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DHL_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
EXEC sys.sp_db_vardecimal_storage_format N'DHL', N'ON'
GO
ALTER DATABASE [DHL] SET QUERY_STORE = OFF
GO
USE [DHL]
GO
/****** Object:  Table [dbo].[tbl_address]    Script Date: 5/12/2020 2:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_address](
	[IdAddress] [int] IDENTITY(1,1) NOT NULL,
	[IdAddressType] [int] NOT NULL,
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
/****** Object:  Table [dbo].[tbl_address_type]    Script Date: 5/12/2020 2:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_address_type](
	[IdAddressType] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[tbl_card_status]    Script Date: 5/12/2020 2:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_card_status](
	[IdCardStatus] [int] IDENTITY(1,1) NOT NULL,
	[CardStatus] [varchar](50) NOT NULL,
	[UpdateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_tbl_card_status] PRIMARY KEY CLUSTERED 
(
	[IdCardStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_cards]    Script Date: 5/12/2020 2:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_cards](
	[IdCustomer] [int] NOT NULL,
	[IdCard] [int] NOT NULL,
	[Balance] [real] NOT NULL,
	[BalanceAvailable] [real] NOT NULL,
	[CardStatus] [int] NOT NULL,
	[InsertBy] [int] NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK__tbl_card__DB43864AA8BE46E5] PRIMARY KEY CLUSTERED 
(
	[IdCustomer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__tbl_card__3B7B33C3A28EFEFB] UNIQUE NONCLUSTERED 
(
	[IdCard] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_customer_address]    Script Date: 5/12/2020 2:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_customer_address](
	[IdCustomer] [int] NOT NULL,
	[IdAddress] [int] NOT NULL,
	[InsertBy] [int] NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[UpdateBy] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK__tbl_cust__345F797DFD24B982] PRIMARY KEY CLUSTERED 
(
	[IdCustomer] ASC,
	[IdAddress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_customer_discount]    Script Date: 5/12/2020 2:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_customer_discount](
	[IdCustomer] [int] NOT NULL,
	[IdDiscount] [int] NOT NULL,
	[CodeForActive] [varchar](255) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[InsertBy] [int] NOT NULL,
	[InsertDate] [datetime] NOT NULL,
 CONSTRAINT [PK__tbl_cust__E72988E97486E414] PRIMARY KEY CLUSTERED 
(
	[IdCustomer] ASC,
	[IdDiscount] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_customer_logs]    Script Date: 5/12/2020 2:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_customer_logs](
	[PID] [int] IDENTITY(1,1) NOT NULL,
	[IdCustomer] [int] NOT NULL,
	[CustomerXML] [xml] NOT NULL,
	[InsertBy] [int] NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[IdTool] [int] NULL,
 CONSTRAINT [PK_tbl_customer_logs] PRIMARY KEY CLUSTERED 
(
	[PID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_customer_status]    Script Date: 5/12/2020 2:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_customer_status](
	[IdCustomerStatus] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[tbl_customer_type]    Script Date: 5/12/2020 2:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_customer_type](
	[IdCustomerType] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[tbl_customers]    Script Date: 5/12/2020 2:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_customers](
	[IdCustomer] [int] NOT NULL,
	[CustomerType] [int] NOT NULL,
	[CustomerStatus] [int] NOT NULL,
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
/****** Object:  Table [dbo].[tbl_discount_filetab]    Script Date: 5/12/2020 2:22:29 PM ******/
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
/****** Object:  Table [dbo].[tbl_discount_type]    Script Date: 5/12/2020 2:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_discount_type](
	[IdDiscountType] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[tbl_discounts]    Script Date: 5/12/2020 2:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_discounts](
	[IdDiscount] [int] IDENTITY(1,1) NOT NULL,
	[DiscountTitle] [varchar](20) NOT NULL,
	[DiscountDescription] [varchar](150) NOT NULL,
	[DiscountType] [int] NOT NULL,
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
/****** Object:  Table [dbo].[tbl_filetab]    Script Date: 5/12/2020 2:22:29 PM ******/
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
/****** Object:  Table [dbo].[tbl_product_discount]    Script Date: 5/12/2020 2:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_product_discount](
	[IdProduct] [int] NOT NULL,
	[IdDiscount] [int] NOT NULL,
	[CodeForActive] [varchar](255) NULL,
	[IsActive] [bit] NOT NULL,
	[InsertBy] [int] NULL,
	[InsertDate] [datetime] NULL,
 CONSTRAINT [PK__tbl_prod__12E3487743C36AD2] PRIMARY KEY CLUSTERED 
(
	[IdProduct] ASC,
	[IdDiscount] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_products]    Script Date: 5/12/2020 2:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_products](
	[IdProduct] [int] NOT NULL,
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
/****** Object:  Table [dbo].[tbl_profile_permission]    Script Date: 5/12/2020 2:22:29 PM ******/
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
/****** Object:  Table [dbo].[tbl_shipments]    Script Date: 5/12/2020 2:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_shipments](
	[PID] [int] IDENTITY(1,1) NOT NULL,
	[IdCostumer] [int] NULL,
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
	[IdTool] [int] NULL,
 CONSTRAINT [PK_tbl_shipments] PRIMARY KEY CLUSTERED 
(
	[PID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_tool_permission]    Script Date: 5/12/2020 2:22:29 PM ******/
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
/****** Object:  Table [dbo].[tbl_tools]    Script Date: 5/12/2020 2:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_tools](
	[IdTool] [int] NOT NULL,
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
/****** Object:  Table [dbo].[tbl_transaction_logs]    Script Date: 5/12/2020 2:22:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_transaction_logs](
	[PID] [int] IDENTITY(1,1) NOT NULL,
	[IdCustomer] [int] NOT NULL,
	[IdCard] [int] NULL,
	[TransactionType] [tinyint] NOT NULL,
	[TransactionStatus] [tinyint] NOT NULL,
	[TransactionID] [varchar](18) NOT NULL,
	[TransactionDateTime] [datetime] NOT NULL,
	[Value] [real] NOT NULL,
	[AWB] [bigint] NULL,
	[AWBStatus] [bit] NOT NULL,
	[InsertBy] [int] NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[IdTool] [int] NULL,
 CONSTRAINT [PK_tbl_transaction_logs] PRIMARY KEY CLUSTERED 
(
	[PID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_user_type]    Script Date: 5/12/2020 2:22:29 PM ******/
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
/****** Object:  Table [dbo].[tbl_users]    Script Date: 5/12/2020 2:22:29 PM ******/
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
ALTER TABLE [dbo].[tbl_address]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_addre__IdAdd__4F7CD00D] FOREIGN KEY([IdAddressType])
REFERENCES [dbo].[tbl_address_type] ([IdAddressType])
GO
ALTER TABLE [dbo].[tbl_address] CHECK CONSTRAINT [FK__tbl_addre__IdAdd__4F7CD00D]
GO
ALTER TABLE [dbo].[tbl_address_type]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_addre__Inser__5070F446] FOREIGN KEY([InsertBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_address_type] CHECK CONSTRAINT [FK__tbl_addre__Inser__5070F446]
GO
ALTER TABLE [dbo].[tbl_address_type]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_addre__Updat__5165187F] FOREIGN KEY([UpdateBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_address_type] CHECK CONSTRAINT [FK__tbl_addre__Updat__5165187F]
GO
ALTER TABLE [dbo].[tbl_card_status]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_card___Updat__52593CB8] FOREIGN KEY([UpdateBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_card_status] CHECK CONSTRAINT [FK__tbl_card___Updat__52593CB8]
GO
ALTER TABLE [dbo].[tbl_cards]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_cards__CardS__534D60F1] FOREIGN KEY([CardStatus])
REFERENCES [dbo].[tbl_card_status] ([IdCardStatus])
GO
ALTER TABLE [dbo].[tbl_cards] CHECK CONSTRAINT [FK__tbl_cards__CardS__534D60F1]
GO
ALTER TABLE [dbo].[tbl_cards]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_cards__IdCus__5441852A] FOREIGN KEY([IdCustomer])
REFERENCES [dbo].[tbl_customers] ([IdCustomer])
GO
ALTER TABLE [dbo].[tbl_cards] CHECK CONSTRAINT [FK__tbl_cards__IdCus__5441852A]
GO
ALTER TABLE [dbo].[tbl_cards]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_cards__Inser__5535A963] FOREIGN KEY([InsertBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_cards] CHECK CONSTRAINT [FK__tbl_cards__Inser__5535A963]
GO
ALTER TABLE [dbo].[tbl_cards]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_cards__Updat__5629CD9C] FOREIGN KEY([UpdateBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_cards] CHECK CONSTRAINT [FK__tbl_cards__Updat__5629CD9C]
GO
ALTER TABLE [dbo].[tbl_customer_address]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_custo__IdAdd__571DF1D5] FOREIGN KEY([IdAddress])
REFERENCES [dbo].[tbl_address] ([IdAddress])
GO
ALTER TABLE [dbo].[tbl_customer_address] CHECK CONSTRAINT [FK__tbl_custo__IdAdd__571DF1D5]
GO
ALTER TABLE [dbo].[tbl_customer_address]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_custo__IdCus__5812160E] FOREIGN KEY([IdCustomer])
REFERENCES [dbo].[tbl_customers] ([IdCustomer])
GO
ALTER TABLE [dbo].[tbl_customer_address] CHECK CONSTRAINT [FK__tbl_custo__IdCus__5812160E]
GO
ALTER TABLE [dbo].[tbl_customer_address]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_custo__Inser__59063A47] FOREIGN KEY([InsertBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_customer_address] CHECK CONSTRAINT [FK__tbl_custo__Inser__59063A47]
GO
ALTER TABLE [dbo].[tbl_customer_address]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_custo__Updat__59FA5E80] FOREIGN KEY([UpdateBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_customer_address] CHECK CONSTRAINT [FK__tbl_custo__Updat__59FA5E80]
GO
ALTER TABLE [dbo].[tbl_customer_discount]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_custo__IdCus__5AEE82B9] FOREIGN KEY([IdCustomer])
REFERENCES [dbo].[tbl_customers] ([IdCustomer])
GO
ALTER TABLE [dbo].[tbl_customer_discount] CHECK CONSTRAINT [FK__tbl_custo__IdCus__5AEE82B9]
GO
ALTER TABLE [dbo].[tbl_customer_discount]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_custo__IdDis__5BE2A6F2] FOREIGN KEY([IdDiscount])
REFERENCES [dbo].[tbl_discounts] ([IdDiscount])
GO
ALTER TABLE [dbo].[tbl_customer_discount] CHECK CONSTRAINT [FK__tbl_custo__IdDis__5BE2A6F2]
GO
ALTER TABLE [dbo].[tbl_customer_discount]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_custo__Inser__5CD6CB2B] FOREIGN KEY([InsertBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_customer_discount] CHECK CONSTRAINT [FK__tbl_custo__Inser__5CD6CB2B]
GO
ALTER TABLE [dbo].[tbl_customer_logs]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_custo__IdCus__5DCAEF64] FOREIGN KEY([IdCustomer])
REFERENCES [dbo].[tbl_customers] ([IdCustomer])
GO
ALTER TABLE [dbo].[tbl_customer_logs] CHECK CONSTRAINT [FK__tbl_custo__IdCus__5DCAEF64]
GO
ALTER TABLE [dbo].[tbl_customer_logs]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_custo__IdToo__5EBF139D] FOREIGN KEY([IdTool])
REFERENCES [dbo].[tbl_tools] ([IdTool])
GO
ALTER TABLE [dbo].[tbl_customer_logs] CHECK CONSTRAINT [FK__tbl_custo__IdToo__5EBF139D]
GO
ALTER TABLE [dbo].[tbl_customer_logs]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_custo__Inser__5FB337D6] FOREIGN KEY([InsertBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_customer_logs] CHECK CONSTRAINT [FK__tbl_custo__Inser__5FB337D6]
GO
ALTER TABLE [dbo].[tbl_customer_status]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_custo__Inser__60A75C0F] FOREIGN KEY([InsertBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_customer_status] CHECK CONSTRAINT [FK__tbl_custo__Inser__60A75C0F]
GO
ALTER TABLE [dbo].[tbl_customer_status]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_custo__Updat__619B8048] FOREIGN KEY([UpdateBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_customer_status] CHECK CONSTRAINT [FK__tbl_custo__Updat__619B8048]
GO
ALTER TABLE [dbo].[tbl_customer_type]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_custo__Inser__628FA481] FOREIGN KEY([InsertBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_customer_type] CHECK CONSTRAINT [FK__tbl_custo__Inser__628FA481]
GO
ALTER TABLE [dbo].[tbl_customer_type]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_custo__Updat__6383C8BA] FOREIGN KEY([UpdateBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_customer_type] CHECK CONSTRAINT [FK__tbl_custo__Updat__6383C8BA]
GO
ALTER TABLE [dbo].[tbl_customers]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_custo__Custo__6477ECF3] FOREIGN KEY([CustomerType])
REFERENCES [dbo].[tbl_customer_type] ([IdCustomerType])
GO
ALTER TABLE [dbo].[tbl_customers] CHECK CONSTRAINT [FK__tbl_custo__Custo__6477ECF3]
GO
ALTER TABLE [dbo].[tbl_customers]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_custo__Custo__656C112C] FOREIGN KEY([CustomerStatus])
REFERENCES [dbo].[tbl_customer_status] ([IdCustomerStatus])
GO
ALTER TABLE [dbo].[tbl_customers] CHECK CONSTRAINT [FK__tbl_custo__Custo__656C112C]
GO
ALTER TABLE [dbo].[tbl_customers]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_custo__IdDis__66603565] FOREIGN KEY([IdDiscount])
REFERENCES [dbo].[tbl_discounts] ([IdDiscount])
GO
ALTER TABLE [dbo].[tbl_customers] CHECK CONSTRAINT [FK__tbl_custo__IdDis__66603565]
GO
ALTER TABLE [dbo].[tbl_customers]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_custo__Inser__6754599E] FOREIGN KEY([InsertBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_customers] CHECK CONSTRAINT [FK__tbl_custo__Inser__6754599E]
GO
ALTER TABLE [dbo].[tbl_customers]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_custo__Updat__68487DD7] FOREIGN KEY([UpdateBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_customers] CHECK CONSTRAINT [FK__tbl_custo__Updat__68487DD7]
GO
ALTER TABLE [dbo].[tbl_discount_filetab]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_disco__IdDis__693CA210] FOREIGN KEY([IdDiscount])
REFERENCES [dbo].[tbl_discounts] ([IdDiscount])
GO
ALTER TABLE [dbo].[tbl_discount_filetab] CHECK CONSTRAINT [FK__tbl_disco__IdDis__693CA210]
GO
ALTER TABLE [dbo].[tbl_discount_filetab]  WITH NOCHECK ADD FOREIGN KEY([InsertBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_discount_filetab]  WITH NOCHECK ADD FOREIGN KEY([path_locator])
REFERENCES [dbo].[tbl_filetab] ([path_locator])
GO
ALTER TABLE [dbo].[tbl_discount_type]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_disco__Inser__6C190EBB] FOREIGN KEY([InsertBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_discount_type] CHECK CONSTRAINT [FK__tbl_disco__Inser__6C190EBB]
GO
ALTER TABLE [dbo].[tbl_discount_type]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_disco__Updat__6D0D32F4] FOREIGN KEY([UpdateBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_discount_type] CHECK CONSTRAINT [FK__tbl_disco__Updat__6D0D32F4]
GO
ALTER TABLE [dbo].[tbl_discounts]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_disco__Disco__6E01572D] FOREIGN KEY([DiscountType])
REFERENCES [dbo].[tbl_discount_type] ([IdDiscountType])
GO
ALTER TABLE [dbo].[tbl_discounts] CHECK CONSTRAINT [FK__tbl_disco__Disco__6E01572D]
GO
ALTER TABLE [dbo].[tbl_discounts]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_disco__Inser__6EF57B66] FOREIGN KEY([InsertBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_discounts] CHECK CONSTRAINT [FK__tbl_disco__Inser__6EF57B66]
GO
ALTER TABLE [dbo].[tbl_discounts]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_disco__Updat__6FE99F9F] FOREIGN KEY([UpdateBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_discounts] CHECK CONSTRAINT [FK__tbl_disco__Updat__6FE99F9F]
GO
ALTER TABLE [dbo].[tbl_product_discount]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_produ__IdDis__70DDC3D8] FOREIGN KEY([IdDiscount])
REFERENCES [dbo].[tbl_discounts] ([IdDiscount])
GO
ALTER TABLE [dbo].[tbl_product_discount] CHECK CONSTRAINT [FK__tbl_produ__IdDis__70DDC3D8]
GO
ALTER TABLE [dbo].[tbl_product_discount]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_produ__Inser__71D1E811] FOREIGN KEY([InsertBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_product_discount] CHECK CONSTRAINT [FK__tbl_produ__Inser__71D1E811]
GO
ALTER TABLE [dbo].[tbl_product_discount]  WITH NOCHECK ADD  CONSTRAINT [FK_tbl_product_discount_tbl_products] FOREIGN KEY([IdProduct])
REFERENCES [dbo].[tbl_products] ([IdProduct])
GO
ALTER TABLE [dbo].[tbl_product_discount] CHECK CONSTRAINT [FK_tbl_product_discount_tbl_products]
GO
ALTER TABLE [dbo].[tbl_products]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_produ__Inser__73BA3083] FOREIGN KEY([InsertBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_products] CHECK CONSTRAINT [FK__tbl_produ__Inser__73BA3083]
GO
ALTER TABLE [dbo].[tbl_products]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_produ__Updat__74AE54BC] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_products] CHECK CONSTRAINT [FK__tbl_produ__Updat__74AE54BC]
GO
ALTER TABLE [dbo].[tbl_profile_permission]  WITH NOCHECK ADD FOREIGN KEY([IdProfile])
REFERENCES [dbo].[tbl_tool_permission] ([IdProfile])
GO
ALTER TABLE [dbo].[tbl_shipments]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_shipm__IdCos__76969D2E] FOREIGN KEY([IdCostumer])
REFERENCES [dbo].[tbl_customers] ([IdCustomer])
GO
ALTER TABLE [dbo].[tbl_shipments] CHECK CONSTRAINT [FK__tbl_shipm__IdCos__76969D2E]
GO
ALTER TABLE [dbo].[tbl_shipments]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_shipm__IdToo__778AC167] FOREIGN KEY([IdTool])
REFERENCES [dbo].[tbl_tools] ([IdTool])
GO
ALTER TABLE [dbo].[tbl_shipments] CHECK CONSTRAINT [FK__tbl_shipm__IdToo__778AC167]
GO
ALTER TABLE [dbo].[tbl_shipments]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_shipm__Inser__787EE5A0] FOREIGN KEY([InsertBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_shipments] CHECK CONSTRAINT [FK__tbl_shipm__Inser__787EE5A0]
GO
ALTER TABLE [dbo].[tbl_shipments]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_shipm__Updat__797309D9] FOREIGN KEY([UpdateBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_shipments] CHECK CONSTRAINT [FK__tbl_shipm__Updat__797309D9]
GO
ALTER TABLE [dbo].[tbl_tools]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_tools__IdPro__7A672E12] FOREIGN KEY([IdProfile])
REFERENCES [dbo].[tbl_tool_permission] ([IdProfile])
GO
ALTER TABLE [dbo].[tbl_tools] CHECK CONSTRAINT [FK__tbl_tools__IdPro__7A672E12]
GO
ALTER TABLE [dbo].[tbl_transaction_logs]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_trans__IdCar__7B5B524B] FOREIGN KEY([IdCard])
REFERENCES [dbo].[tbl_cards] ([IdCard])
GO
ALTER TABLE [dbo].[tbl_transaction_logs] CHECK CONSTRAINT [FK__tbl_trans__IdCar__7B5B524B]
GO
ALTER TABLE [dbo].[tbl_transaction_logs]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_trans__IdCus__7C4F7684] FOREIGN KEY([IdCustomer])
REFERENCES [dbo].[tbl_customers] ([IdCustomer])
GO
ALTER TABLE [dbo].[tbl_transaction_logs] CHECK CONSTRAINT [FK__tbl_trans__IdCus__7C4F7684]
GO
ALTER TABLE [dbo].[tbl_transaction_logs]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_trans__IdToo__7D439ABD] FOREIGN KEY([IdTool])
REFERENCES [dbo].[tbl_tools] ([IdTool])
GO
ALTER TABLE [dbo].[tbl_transaction_logs] CHECK CONSTRAINT [FK__tbl_trans__IdToo__7D439ABD]
GO
ALTER TABLE [dbo].[tbl_transaction_logs]  WITH NOCHECK ADD  CONSTRAINT [FK__tbl_trans__Inser__7E37BEF6] FOREIGN KEY([InsertBy])
REFERENCES [dbo].[tbl_users] ([IdUser])
GO
ALTER TABLE [dbo].[tbl_transaction_logs] CHECK CONSTRAINT [FK__tbl_trans__Inser__7E37BEF6]
GO
ALTER TABLE [dbo].[tbl_users]  WITH NOCHECK ADD FOREIGN KEY([UserType])
REFERENCES [dbo].[tbl_user_type] ([IdUserType])
GO
USE [master]
GO
ALTER DATABASE [DHL] SET  READ_WRITE 
GO
