USE [master]
GO
/****** Object:  Database [smk_restaurant]    Script Date: 11/26/2016 2:06:06 PM ******/
CREATE DATABASE [smk_restaurant]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'smk_restaurant', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\smk_restaurant.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'smk_restaurant_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\smk_restaurant_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [smk_restaurant] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [smk_restaurant].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [smk_restaurant] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [smk_restaurant] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [smk_restaurant] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [smk_restaurant] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [smk_restaurant] SET ARITHABORT OFF 
GO
ALTER DATABASE [smk_restaurant] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [smk_restaurant] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [smk_restaurant] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [smk_restaurant] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [smk_restaurant] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [smk_restaurant] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [smk_restaurant] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [smk_restaurant] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [smk_restaurant] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [smk_restaurant] SET  DISABLE_BROKER 
GO
ALTER DATABASE [smk_restaurant] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [smk_restaurant] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [smk_restaurant] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [smk_restaurant] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [smk_restaurant] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [smk_restaurant] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [smk_restaurant] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [smk_restaurant] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [smk_restaurant] SET  MULTI_USER 
GO
ALTER DATABASE [smk_restaurant] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [smk_restaurant] SET DB_CHAINING OFF 
GO
ALTER DATABASE [smk_restaurant] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [smk_restaurant] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [smk_restaurant] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'smk_restaurant', N'ON'
GO
USE [smk_restaurant]
GO
/****** Object:  Table [dbo].[Bank]    Script Date: 11/26/2016 2:06:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bank](
	[bankId] [int] IDENTITY(1,1) NOT NULL,
	[bankName] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Bank] PRIMARY KEY CLUSTERED 
(
	[bankId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 11/26/2016 2:06:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[employeeId] [varchar](12) NOT NULL,
	[DOB] [date] NOT NULL,
	[employeeName] [varchar](60) NOT NULL,
	[roleId] [int] NOT NULL,
	[phoneNumber] [varchar](20) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[employeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ingredients]    Script Date: 11/26/2016 2:06:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ingredients](
	[ingredientsId] [int] IDENTITY(1,1) NOT NULL,
	[ingredientsName] [varchar](50) NOT NULL,
	[stock] [int] NOT NULL,
	[unit] [varchar](10) NOT NULL,
	[price] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_Ingredients] PRIMARY KEY CLUSTERED 
(
	[ingredientsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Member]    Script Date: 11/26/2016 2:06:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Member](
	[memberId] [varchar](6) NOT NULL,
	[firstName] [varchar](20) NOT NULL,
	[lastName] [varchar](20) NOT NULL,
	[phoneNumber] [varchar](20) NOT NULL,
	[email] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[memberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 11/26/2016 2:06:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Menu](
	[menuId] [int] IDENTITY(1,1) NOT NULL,
	[menuName] [varchar](50) NOT NULL,
	[price] [decimal](10, 2) NOT NULL,
	[startDate] [date] NOT NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[menuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MenuIngredients]    Script Date: 11/26/2016 2:06:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuIngredients](
	[menuIngredientsId] [int] IDENTITY(1,1) NOT NULL,
	[menuId] [int] NOT NULL,
	[ingredientsId] [int] NOT NULL,
	[qty] [int] NOT NULL,
 CONSTRAINT [PK_MenuIngredients] PRIMARY KEY CLUSTERED 
(
	[menuIngredientsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 11/26/2016 2:06:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Order](
	[orderId] [int] IDENTITY(1,1) NOT NULL,
	[tableId] [int] NOT NULL,
	[status] [varchar](20) NOT NULL,
	[totalPrice] [decimal](10, 2) NOT NULL,
	[createdAt] [datetime] NOT NULL,
	[updatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[orderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 11/26/2016 2:06:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[orderDetailsId] [int] IDENTITY(1,1) NOT NULL,
	[orderId] [int] NOT NULL,
	[menuId] [int] NOT NULL,
	[qty] [int] NOT NULL,
	[price] [decimal](10, 2) NOT NULL,
	[subTotal] [decimal](10, 2) NOT NULL,
	[status] [varchar](20) NULL,
 CONSTRAINT [PK_orderDetails] PRIMARY KEY CLUSTERED 
(
	[orderDetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 11/26/2016 2:06:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Payment](
	[paymentId] [int] IDENTITY(1,1) NOT NULL,
	[orderId] [int] NOT NULL,
	[memberId] [varchar](6) NULL,
	[payMethod] [varchar](20) NOT NULL,
	[bankId] [int] NULL,
	[creditCardNumber] [varchar](25) NULL,
	[promoId] [int] NULL,
	[amount] [decimal](10, 2) NOT NULL,
	[createdAt] [date] NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[paymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Promo]    Script Date: 11/26/2016 2:06:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Promo](
	[promoId] [int] IDENTITY(1,1) NOT NULL,
	[promoName] [varchar](50) NOT NULL,
	[startDate] [date] NOT NULL,
	[endDate] [date] NOT NULL,
	[minPayment] [decimal](10, 2) NOT NULL,
	[discountPercent] [int] NOT NULL,
	[bankId] [int] NOT NULL,
 CONSTRAINT [PK_Promo] PRIMARY KEY CLUSTERED 
(
	[promoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/26/2016 2:06:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[roleId] [int] IDENTITY(1,1) NOT NULL,
	[roleName] [varchar](20) NOT NULL,
	[privileges] [varchar](20) NOT NULL,
	[defaultPrivileges] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[roleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Table]    Script Date: 11/26/2016 2:06:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Table](
	[tableId] [int] IDENTITY(1,1) NOT NULL,
	[tableNo] [varchar](20) NOT NULL,
	[status] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED 
(
	[tableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Bank] ON 

INSERT [dbo].[Bank] ([bankId], [bankName]) VALUES (1, N'BCA')
INSERT [dbo].[Bank] ([bankId], [bankName]) VALUES (2, N'BNI')
INSERT [dbo].[Bank] ([bankId], [bankName]) VALUES (3, N'Mandiri')
INSERT [dbo].[Bank] ([bankId], [bankName]) VALUES (4, N'HSBC')
SET IDENTITY_INSERT [dbo].[Bank] OFF
INSERT [dbo].[Employee] ([employeeId], [DOB], [employeeName], [roleId], [phoneNumber], [email], [password]) VALUES (N'19511000001', CAST(N'1951-10-17' AS Date), N'ESTELLA ROBERT', 1, N'818123456', N'e_blalock@ccf.org', N'tes123')
INSERT [dbo].[Employee] ([employeeId], [DOB], [employeeName], [roleId], [phoneNumber], [email], [password]) VALUES (N'19521100001', CAST(N'1952-11-26' AS Date), N'KING MERCADO', 5, N'818123457', N'k_mercado@hotmail.com', N'tes123')
INSERT [dbo].[Employee] ([employeeId], [DOB], [employeeName], [roleId], [phoneNumber], [email], [password]) VALUES (N'19530800001', CAST(N'1953-08-19' AS Date), N'GERARDO BOWSER', 3, N'818123458', N'gerardo_bowser@hotmail.com', N'tes123')
INSERT [dbo].[Employee] ([employeeId], [DOB], [employeeName], [roleId], [phoneNumber], [email], [password]) VALUES (N'19560300001', CAST(N'1956-03-23' AS Date), N'CLIFTON FIGUEROA', 6, N'818123459', N'c_figueroa@live.com', N'tes123')
INSERT [dbo].[Employee] ([employeeId], [DOB], [employeeName], [roleId], [phoneNumber], [email], [password]) VALUES (N'19581200001', CAST(N'1958-12-13' AS Date), N'CALLAN MCCONNELL', 3, N'818123460', N'callan.mcconnell@@gmail.com', N'tes123')
INSERT [dbo].[Employee] ([employeeId], [DOB], [employeeName], [roleId], [phoneNumber], [email], [password]) VALUES (N'19610800001', CAST(N'1961-08-06' AS Date), N'LAKISHA TOMBLIN', 6, N'818123461', N'l_tomblin@nnl.com', N'tes123')
INSERT [dbo].[Employee] ([employeeId], [DOB], [employeeName], [roleId], [phoneNumber], [email], [password]) VALUES (N'19621200001', CAST(N'1962-12-04' AS Date), N'MADELYN HOOVER', 3, N'818123462', N'madelyn_hoover@@hotmail.com', N'tes123')
INSERT [dbo].[Employee] ([employeeId], [DOB], [employeeName], [roleId], [phoneNumber], [email], [password]) VALUES (N'19631100001', CAST(N'1963-11-18' AS Date), N'GLORY FELDER', 6, N'898123463', N'glory.felder@hotmail.com', N'tes123')
INSERT [dbo].[Employee] ([employeeId], [DOB], [employeeName], [roleId], [phoneNumber], [email], [password]) VALUES (N'19650800001', CAST(N'1965-08-02' AS Date), N'TYRELL ROSENBERG', 3, N'818123464', N'tyrell_rosenberg@hotmail.com', N'tes123')
INSERT [dbo].[Employee] ([employeeId], [DOB], [employeeName], [roleId], [phoneNumber], [email], [password]) VALUES (N'19670300001', CAST(N'1967-03-30' AS Date), N'KENETH PARHAM', 6, N'818123465', N'k_parham@live.com', N'tes123')
INSERT [dbo].[Employee] ([employeeId], [DOB], [employeeName], [roleId], [phoneNumber], [email], [password]) VALUES (N'19681000001', CAST(N'1968-10-20' AS Date), N'WINIFRED DUNCAN', 3, N'817123466', N'w_duncan@hotmail.com', N'tes123')
INSERT [dbo].[Employee] ([employeeId], [DOB], [employeeName], [roleId], [phoneNumber], [email], [password]) VALUES (N'19711000001', CAST(N'1971-10-13' AS Date), N'DON RUSS', 6, N'818123467', N'don_russ@jcl.net', N'tes123')
INSERT [dbo].[Employee] ([employeeId], [DOB], [employeeName], [roleId], [phoneNumber], [email], [password]) VALUES (N'19731000001', CAST(N'1973-10-11' AS Date), N'LORRAINE MCKEE', 3, N'818123468', N'l_mckee@hotmail.com', N'tes123')
INSERT [dbo].[Employee] ([employeeId], [DOB], [employeeName], [roleId], [phoneNumber], [email], [password]) VALUES (N'19740700001', CAST(N'1974-07-07' AS Date), N'ELSIE ESTELL', 6, N'818123469', N'elsie.estell@rrg.net', N'tes123')
INSERT [dbo].[Employee] ([employeeId], [DOB], [employeeName], [roleId], [phoneNumber], [email], [password]) VALUES (N'19740900001', CAST(N'1974-09-19' AS Date), N'SHELLIE MONTANO', 3, N'818123470', N'shellie_montano@hotmail.com', N'tes123')
INSERT [dbo].[Employee] ([employeeId], [DOB], [employeeName], [roleId], [phoneNumber], [email], [password]) VALUES (N'19780900001', CAST(N'1978-09-21' AS Date), N'WILFORD RIVERA', 6, N'818123471', N'wilford.rivera@gmail.com', N'tes123')
INSERT [dbo].[Employee] ([employeeId], [DOB], [employeeName], [roleId], [phoneNumber], [email], [password]) VALUES (N'19790500001', CAST(N'1979-05-17' AS Date), N'ILA THOMPSON', 3, N'818123472', N'i_thompson@yahoo.com', N'tes123')
INSERT [dbo].[Employee] ([employeeId], [DOB], [employeeName], [roleId], [phoneNumber], [email], [password]) VALUES (N'19790800001', CAST(N'1979-08-07' AS Date), N'MAYRA CALLAHAN', 6, N'878123473', N'm_callahan@live.com', N'tes123')
INSERT [dbo].[Employee] ([employeeId], [DOB], [employeeName], [roleId], [phoneNumber], [email], [password]) VALUES (N'19801200001', CAST(N'1980-12-24' AS Date), N'KRIS SWEELY', 3, N'0818123474', N'k_sweely@yahoo.com', N'tes123')
INSERT [dbo].[Employee] ([employeeId], [DOB], [employeeName], [roleId], [phoneNumber], [email], [password]) VALUES (N'19820400001', CAST(N'1982-04-28' AS Date), N'GOLDA GRANGER', 6, N'818123475', N'g_granger@msv.org', N'tes123')
INSERT [dbo].[Employee] ([employeeId], [DOB], [employeeName], [roleId], [phoneNumber], [email], [password]) VALUES (N'19830400001', CAST(N'1983-04-21' AS Date), N'TRAVIS RAMOS', 3, N'818123476', N'travis_ramos@hotmail.com', N'tes123')
INSERT [dbo].[Employee] ([employeeId], [DOB], [employeeName], [roleId], [phoneNumber], [email], [password]) VALUES (N'19830600001', CAST(N'1983-06-28' AS Date), N'LASHANDA SNOWDEN', 6, N'818123477', N'lashanda.snowden@rrg.net', N'tes123')
INSERT [dbo].[Employee] ([employeeId], [DOB], [employeeName], [roleId], [phoneNumber], [email], [password]) VALUES (N'19841200001', CAST(N'1984-12-20' AS Date), N'ERVIN LAWRENCE', 3, N'818123478', N'ervin_lawrence@hotmail.com', N'tes123')
INSERT [dbo].[Employee] ([employeeId], [DOB], [employeeName], [roleId], [phoneNumber], [email], [password]) VALUES (N'19851000001', CAST(N'1985-10-17' AS Date), N'KARIN MCCARTY', 6, N'818123479', N'k_mccarty@gmail.com', N'tes123')
INSERT [dbo].[Employee] ([employeeId], [DOB], [employeeName], [roleId], [phoneNumber], [email], [password]) VALUES (N'19890700001', CAST(N'1989-07-06' AS Date), N'LYLE MALLORY', 3, N'818123480', N'l_mallory@live.com', N'tes123')
INSERT [dbo].[Employee] ([employeeId], [DOB], [employeeName], [roleId], [phoneNumber], [email], [password]) VALUES (N'19900900001', CAST(N'1990-09-30' AS Date), N'LANCE BEYER', 6, N'818123481', N'l_beyer@rnl.com', N'tes123')
INSERT [dbo].[Employee] ([employeeId], [DOB], [employeeName], [roleId], [phoneNumber], [email], [password]) VALUES (N'19901100001', CAST(N'1990-11-25' AS Date), N'HAEKAL YUDH', 3, N'085603050550', N'haekal@gmail.com', N'tes123')
INSERT [dbo].[Employee] ([employeeId], [DOB], [employeeName], [roleId], [phoneNumber], [email], [password]) VALUES (N'19920200001', CAST(N'1992-02-13' AS Date), N'THADDEUS STALEY', 3, N'818123482', N't_staley@nnl.com', N'tes123')
INSERT [dbo].[Employee] ([employeeId], [DOB], [employeeName], [roleId], [phoneNumber], [email], [password]) VALUES (N'19931000001', CAST(N'1993-10-13' AS Date), N'VERNITA SEABORN', 6, N'818123483', N'v_seaborn@gmail.com', N'tes123')
INSERT [dbo].[Employee] ([employeeId], [DOB], [employeeName], [roleId], [phoneNumber], [email], [password]) VALUES (N'19950700001', CAST(N'1995-07-01' AS Date), N'MOHAMMAD RICHEY', 3, N'818123484', N'mohammad_richey@jcl.net', N'tes123')
INSERT [dbo].[Employee] ([employeeId], [DOB], [employeeName], [roleId], [phoneNumber], [email], [password]) VALUES (N'19970600001', CAST(N'1997-06-29' AS Date), N'LENORA HIGGINS', 6, N'818123485', N'l_higgins@msv.org', N'tes123')
SET IDENTITY_INSERT [dbo].[Ingredients] ON 

INSERT [dbo].[Ingredients] ([ingredientsId], [ingredientsName], [stock], [unit], [price]) VALUES (2, N'ayam', 90000, N'gram', CAST(30.00 AS Decimal(10, 2)))
INSERT [dbo].[Ingredients] ([ingredientsId], [ingredientsName], [stock], [unit], [price]) VALUES (3, N'wortel', 90000, N'buah', CAST(700.00 AS Decimal(10, 2)))
INSERT [dbo].[Ingredients] ([ingredientsId], [ingredientsName], [stock], [unit], [price]) VALUES (4, N'udang', 90000, N'gram', CAST(85.00 AS Decimal(10, 2)))
INSERT [dbo].[Ingredients] ([ingredientsId], [ingredientsName], [stock], [unit], [price]) VALUES (5, N'kembang kol', 90000, N'gram', CAST(12.00 AS Decimal(10, 2)))
INSERT [dbo].[Ingredients] ([ingredientsId], [ingredientsName], [stock], [unit], [price]) VALUES (6, N'sawi putih', 90000, N'gram', CAST(5.00 AS Decimal(10, 2)))
INSERT [dbo].[Ingredients] ([ingredientsId], [ingredientsName], [stock], [unit], [price]) VALUES (7, N'cabe merah', 90000, N'gram', CAST(40.00 AS Decimal(10, 2)))
INSERT [dbo].[Ingredients] ([ingredientsId], [ingredientsName], [stock], [unit], [price]) VALUES (8, N'bawang putih', 90000, N'siung', CAST(1.00 AS Decimal(10, 2)))
INSERT [dbo].[Ingredients] ([ingredientsId], [ingredientsName], [stock], [unit], [price]) VALUES (9, N'kangkung', 90000, N'gram', CAST(12.00 AS Decimal(10, 2)))
INSERT [dbo].[Ingredients] ([ingredientsId], [ingredientsName], [stock], [unit], [price]) VALUES (10, N'bawang merah', 90000, N'siung', CAST(1.00 AS Decimal(10, 2)))
INSERT [dbo].[Ingredients] ([ingredientsId], [ingredientsName], [stock], [unit], [price]) VALUES (11, N'saos tiram', 90000, N'ml', CAST(4.00 AS Decimal(10, 2)))
INSERT [dbo].[Ingredients] ([ingredientsId], [ingredientsName], [stock], [unit], [price]) VALUES (12, N'kecap manis', 90000, N'ml', CAST(4.00 AS Decimal(10, 2)))
INSERT [dbo].[Ingredients] ([ingredientsId], [ingredientsName], [stock], [unit], [price]) VALUES (13, N'terasi', 90000, N'gram', CAST(4.00 AS Decimal(10, 2)))
INSERT [dbo].[Ingredients] ([ingredientsId], [ingredientsName], [stock], [unit], [price]) VALUES (14, N'tepung terigu', 90000, N'gram', CAST(1.20 AS Decimal(10, 2)))
INSERT [dbo].[Ingredients] ([ingredientsId], [ingredientsName], [stock], [unit], [price]) VALUES (15, N'mayonaise', 90000, N'ml', CAST(2.00 AS Decimal(10, 2)))
INSERT [dbo].[Ingredients] ([ingredientsId], [ingredientsName], [stock], [unit], [price]) VALUES (16, N'biji wijen', 90000, N'gram', CAST(3.20 AS Decimal(10, 2)))
INSERT [dbo].[Ingredients] ([ingredientsId], [ingredientsName], [stock], [unit], [price]) VALUES (17, N'telur ayam', 90000, N'butir', CAST(1700.00 AS Decimal(10, 2)))
INSERT [dbo].[Ingredients] ([ingredientsId], [ingredientsName], [stock], [unit], [price]) VALUES (18, N'saos tomat', 90000, N'ml', CAST(2.00 AS Decimal(10, 2)))
INSERT [dbo].[Ingredients] ([ingredientsId], [ingredientsName], [stock], [unit], [price]) VALUES (19, N'tepung maizena', 90000, N'gram', CAST(10.00 AS Decimal(10, 2)))
INSERT [dbo].[Ingredients] ([ingredientsId], [ingredientsName], [stock], [unit], [price]) VALUES (20, N'bawang bombay', 90000, N'buah', CAST(800.00 AS Decimal(10, 2)))
INSERT [dbo].[Ingredients] ([ingredientsId], [ingredientsName], [stock], [unit], [price]) VALUES (21, N'cumi', 90000, N'ekor', CAST(65.00 AS Decimal(10, 2)))
INSERT [dbo].[Ingredients] ([ingredientsId], [ingredientsName], [stock], [unit], [price]) VALUES (22, N'lada hitam', 90000, N'gram', CAST(40.00 AS Decimal(10, 2)))
INSERT [dbo].[Ingredients] ([ingredientsId], [ingredientsName], [stock], [unit], [price]) VALUES (23, N'sapi', 90000, N'gram', CAST(65.00 AS Decimal(10, 2)))
INSERT [dbo].[Ingredients] ([ingredientsId], [ingredientsName], [stock], [unit], [price]) VALUES (25, N'ikan gurame', 90000, N'ekor', CAST(27000.00 AS Decimal(10, 2)))
INSERT [dbo].[Ingredients] ([ingredientsId], [ingredientsName], [stock], [unit], [price]) VALUES (26, N'tahu', 90000, N'gram', CAST(34.00 AS Decimal(10, 2)))
INSERT [dbo].[Ingredients] ([ingredientsId], [ingredientsName], [stock], [unit], [price]) VALUES (27, N'jamur', 90000, N'gram', CAST(12.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Ingredients] OFF
INSERT [dbo].[Member] ([memberId], [firstName], [lastName], [phoneNumber], [email]) VALUES (N'AA0001', N'Arrival', N'Sentosa', N'02392093232', N'arrival@odt.web.id')
INSERT [dbo].[Member] ([memberId], [firstName], [lastName], [phoneNumber], [email]) VALUES (N'MA0001', N'Muhammad', N'Sibra', N'089643299667', N'msibrha@gmail.com')
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([menuId], [menuName], [price], [startDate]) VALUES (1, N'Capcay', CAST(24001.50 AS Decimal(10, 2)), CAST(N'2016-10-17' AS Date))
INSERT [dbo].[Menu] ([menuId], [menuName], [price], [startDate]) VALUES (2, N'Capcay', CAST(21601.35 AS Decimal(10, 2)), CAST(N'2016-04-20' AS Date))
INSERT [dbo].[Menu] ([menuId], [menuName], [price], [startDate]) VALUES (3, N'Capcay', CAST(19441.21 AS Decimal(10, 2)), CAST(N'2015-10-23' AS Date))
INSERT [dbo].[Menu] ([menuId], [menuName], [price], [startDate]) VALUES (4, N'kangkung balacan', CAST(3970.50 AS Decimal(10, 2)), CAST(N'2016-11-21' AS Date))
INSERT [dbo].[Menu] ([menuId], [menuName], [price], [startDate]) VALUES (5, N'kangkung balacan', CAST(3573.45 AS Decimal(10, 2)), CAST(N'2016-05-25' AS Date))
INSERT [dbo].[Menu] ([menuId], [menuName], [price], [startDate]) VALUES (6, N'kangkung balacan', CAST(3216.10 AS Decimal(10, 2)), CAST(N'2015-11-27' AS Date))
INSERT [dbo].[Menu] ([menuId], [menuName], [price], [startDate]) VALUES (7, N'udang mayonaise', CAST(65730.00 AS Decimal(10, 2)), CAST(N'2016-07-21' AS Date))
INSERT [dbo].[Menu] ([menuId], [menuName], [price], [startDate]) VALUES (8, N'udang mayonaise', CAST(59157.00 AS Decimal(10, 2)), CAST(N'2016-01-23' AS Date))
INSERT [dbo].[Menu] ([menuId], [menuName], [price], [startDate]) VALUES (9, N'fuyunghai', CAST(10053.00 AS Decimal(10, 2)), CAST(N'2016-03-01' AS Date))
INSERT [dbo].[Menu] ([menuId], [menuName], [price], [startDate]) VALUES (10, N'fuyunghai', CAST(9047.70 AS Decimal(10, 2)), CAST(N'2015-09-03' AS Date))
INSERT [dbo].[Menu] ([menuId], [menuName], [price], [startDate]) VALUES (11, N'fuyunghai', CAST(8142.93 AS Decimal(10, 2)), CAST(N'2015-03-07' AS Date))
INSERT [dbo].[Menu] ([menuId], [menuName], [price], [startDate]) VALUES (12, N'cumi goreng tepung', CAST(4890.00 AS Decimal(10, 2)), CAST(N'2016-05-10' AS Date))
INSERT [dbo].[Menu] ([menuId], [menuName], [price], [startDate]) VALUES (13, N'cumi goreng tepung', CAST(4401.00 AS Decimal(10, 2)), CAST(N'2015-11-12' AS Date))
INSERT [dbo].[Menu] ([menuId], [menuName], [price], [startDate]) VALUES (14, N'sapi lada hitam', CAST(37174.50 AS Decimal(10, 2)), CAST(N'2016-06-12' AS Date))
INSERT [dbo].[Menu] ([menuId], [menuName], [price], [startDate]) VALUES (15, N'sapi lada hitam', CAST(33457.05 AS Decimal(10, 2)), CAST(N'2015-12-15' AS Date))
INSERT [dbo].[Menu] ([menuId], [menuName], [price], [startDate]) VALUES (16, N'sapi lada hitam', CAST(30111.34 AS Decimal(10, 2)), CAST(N'2015-06-18' AS Date))
INSERT [dbo].[Menu] ([menuId], [menuName], [price], [startDate]) VALUES (17, N'gurame asam manis', CAST(41919.00 AS Decimal(10, 2)), CAST(N'2016-03-04' AS Date))
INSERT [dbo].[Menu] ([menuId], [menuName], [price], [startDate]) VALUES (18, N'gurame asam manis', CAST(37727.10 AS Decimal(10, 2)), CAST(N'2015-09-06' AS Date))
INSERT [dbo].[Menu] ([menuId], [menuName], [price], [startDate]) VALUES (19, N'gurame asam manis', CAST(33954.39 AS Decimal(10, 2)), CAST(N'2015-03-10' AS Date))
INSERT [dbo].[Menu] ([menuId], [menuName], [price], [startDate]) VALUES (20, N'sapo tahu seafood', CAST(51234.00 AS Decimal(10, 2)), CAST(N'2016-03-04' AS Date))
SET IDENTITY_INSERT [dbo].[Menu] OFF
SET IDENTITY_INSERT [dbo].[MenuIngredients] ON 

INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (1, 1, 2, 150)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (2, 1, 3, 1)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (3, 1, 4, 100)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (4, 1, 5, 100)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (5, 1, 6, 100)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (6, 1, 7, 15)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (7, 1, 8, 1)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (15, 3, 2, 150)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (16, 3, 3, 1)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (17, 3, 4, 100)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (18, 3, 5, 100)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (19, 3, 6, 100)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (20, 3, 7, 15)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (21, 3, 8, 1)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (22, 4, 9, 150)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (23, 4, 10, 5)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (24, 4, 8, 2)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (25, 4, 11, 100)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (26, 4, 12, 100)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (27, 4, 13, 10)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (28, 5, 9, 150)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (29, 5, 10, 5)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (30, 5, 8, 2)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (31, 5, 11, 100)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (32, 5, 12, 100)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (33, 5, 13, 10)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (34, 6, 9, 150)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (35, 6, 10, 5)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (36, 6, 8, 2)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (37, 6, 11, 100)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (38, 6, 12, 100)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (39, 6, 13, 10)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (40, 7, 4, 500)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (41, 7, 14, 500)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (42, 7, 15, 200)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (43, 7, 16, 100)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (44, 8, 4, 500)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (45, 8, 14, 500)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (46, 8, 15, 200)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (47, 8, 16, 100)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (48, 9, 17, 2)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (49, 9, 3, 1)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (50, 9, 18, 300)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (51, 9, 12, 50)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (52, 9, 19, 100)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (53, 9, 8, 2)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (54, 9, 20, 1)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (55, 10, 17, 2)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (56, 10, 3, 1)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (57, 10, 18, 300)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (58, 10, 12, 50)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (59, 10, 19, 100)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (60, 10, 8, 2)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (61, 10, 20, 1)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (62, 11, 17, 2)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (63, 11, 3, 1)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (64, 11, 18, 300)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (65, 11, 12, 50)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (66, 11, 19, 100)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (67, 11, 8, 2)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (68, 11, 20, 1)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (69, 12, 21, 12)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (70, 12, 14, 400)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (71, 12, 22, 50)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (72, 13, 21, 12)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (73, 13, 14, 400)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (74, 13, 22, 50)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (75, 14, 23, 300)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (76, 14, 20, 1)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (77, 14, 8, 3)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (78, 14, 7, 4)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (79, 14, 11, 80)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (80, 14, 22, 100)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (81, 15, 23, 300)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (82, 15, 20, 1)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (83, 15, 8, 3)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (84, 15, 7, 4)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (85, 15, 11, 80)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (86, 15, 22, 100)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (87, 16, 23, 300)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (88, 16, 20, 1)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (89, 16, 8, 3)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (90, 16, 7, 4)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (91, 16, 11, 80)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (92, 16, 22, 100)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (93, 17, 25, 1)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (94, 17, 8, 3)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (95, 17, 10, 3)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (96, 17, 11, 70)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (97, 17, 18, 120)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (98, 17, 14, 350)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (99, 18, 25, 1)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (100, 18, 8, 3)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (101, 18, 10, 3)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (102, 18, 11, 70)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (103, 18, 18, 120)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (104, 18, 14, 350)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (105, 19, 25, 1)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (106, 19, 8, 3)
GO
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (107, 19, 10, 3)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (108, 19, 11, 70)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (109, 19, 18, 120)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (110, 19, 14, 350)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (129, 20, 4, 250)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (130, 20, 26, 300)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (131, 20, 27, 100)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (132, 20, 3, 1)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (133, 20, 20, 1)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (134, 20, 10, 3)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (135, 20, 8, 1)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (150, 2, 2, 150)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (151, 2, 3, 1)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (152, 2, 4, 100)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (153, 2, 5, 100)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (154, 2, 6, 100)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (155, 2, 7, 15)
INSERT [dbo].[MenuIngredients] ([menuIngredientsId], [menuId], [ingredientsId], [qty]) VALUES (156, 2, 8, 1)
SET IDENTITY_INSERT [dbo].[MenuIngredients] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([orderId], [tableId], [status], [totalPrice], [createdAt], [updatedAt]) VALUES (5, 2, N'done', CAST(24001.50 AS Decimal(10, 2)), CAST(N'2016-11-26 01:54:25.567' AS DateTime), CAST(N'2016-11-26 01:54:25.567' AS DateTime))
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 

INSERT [dbo].[OrderDetails] ([orderDetailsId], [orderId], [menuId], [qty], [price], [subTotal], [status]) VALUES (9, 5, 1, 1, CAST(24001.50 AS Decimal(10, 2)), CAST(24001.50 AS Decimal(10, 2)), N'delivered')
INSERT [dbo].[OrderDetails] ([orderDetailsId], [orderId], [menuId], [qty], [price], [subTotal], [status]) VALUES (10, 5, 4, 2, CAST(3970.50 AS Decimal(10, 2)), CAST(7941.00 AS Decimal(10, 2)), N'delivered')
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
SET IDENTITY_INSERT [dbo].[Payment] ON 

INSERT [dbo].[Payment] ([paymentId], [orderId], [memberId], [payMethod], [bankId], [creditCardNumber], [promoId], [amount], [createdAt]) VALUES (5, 5, N'AA0001', N'cash', NULL, NULL, NULL, CAST(23000.00 AS Decimal(10, 2)), CAST(N'2016-11-26' AS Date))
SET IDENTITY_INSERT [dbo].[Payment] OFF
SET IDENTITY_INSERT [dbo].[Promo] ON 

INSERT [dbo].[Promo] ([promoId], [promoName], [startDate], [endDate], [minPayment], [discountPercent], [bankId]) VALUES (1, N'Valentine Day', CAST(N'2016-11-23' AS Date), CAST(N'2016-11-24' AS Date), CAST(200000.00 AS Decimal(10, 2)), 10, 1)
INSERT [dbo].[Promo] ([promoId], [promoName], [startDate], [endDate], [minPayment], [discountPercent], [bankId]) VALUES (3, N'Ramadhan', CAST(N'2016-11-26' AS Date), CAST(N'2016-11-30' AS Date), CAST(5000.00 AS Decimal(10, 2)), 5, 1)
SET IDENTITY_INSERT [dbo].[Promo] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([roleId], [roleName], [privileges], [defaultPrivileges]) VALUES (1, N'admin', N'1,1,1,1,1,1,1,1,1,1', N'1,1,1,1,1,1,1,1,1,1')
INSERT [dbo].[Role] ([roleId], [roleName], [privileges], [defaultPrivileges]) VALUES (3, N'cashier', N'0,0,0,0,0,0,0,1,1,0', N'0,0,0,0,0,0,0,1,1,0')
INSERT [dbo].[Role] ([roleId], [roleName], [privileges], [defaultPrivileges]) VALUES (5, N'manager', N'0,0,0,0,0,0,0,0,0,1', N'0,0,0,0,0,0,0,0,0,1')
INSERT [dbo].[Role] ([roleId], [roleName], [privileges], [defaultPrivileges]) VALUES (6, N'chef', N'1,0,0,0,0,0,1,1,0,0', N'0,0,0,0,0,0,1,1,0,0')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[Table] ON 

INSERT [dbo].[Table] ([tableId], [tableNo], [status]) VALUES (2, N'1A', N'available')
INSERT [dbo].[Table] ([tableId], [tableNo], [status]) VALUES (3, N'1B', N'available')
INSERT [dbo].[Table] ([tableId], [tableNo], [status]) VALUES (4, N'1C', N'available')
INSERT [dbo].[Table] ([tableId], [tableNo], [status]) VALUES (5, N'2A', N'available')
INSERT [dbo].[Table] ([tableId], [tableNo], [status]) VALUES (6, N'2B', N'available')
INSERT [dbo].[Table] ([tableId], [tableNo], [status]) VALUES (7, N'2C', N'available')
INSERT [dbo].[Table] ([tableId], [tableNo], [status]) VALUES (8, N'3A', N'available')
INSERT [dbo].[Table] ([tableId], [tableNo], [status]) VALUES (9, N'3B', N'available')
INSERT [dbo].[Table] ([tableId], [tableNo], [status]) VALUES (10, N'3C', N'available')
INSERT [dbo].[Table] ([tableId], [tableNo], [status]) VALUES (11, N'4A', N'available')
INSERT [dbo].[Table] ([tableId], [tableNo], [status]) VALUES (12, N'4B', N'available')
INSERT [dbo].[Table] ([tableId], [tableNo], [status]) VALUES (13, N'4C', N'available')
INSERT [dbo].[Table] ([tableId], [tableNo], [status]) VALUES (14, N'5A', N'available')
INSERT [dbo].[Table] ([tableId], [tableNo], [status]) VALUES (15, N'5B', N'available')
INSERT [dbo].[Table] ([tableId], [tableNo], [status]) VALUES (16, N'5C', N'available')
SET IDENTITY_INSERT [dbo].[Table] OFF
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Role] FOREIGN KEY([roleId])
REFERENCES [dbo].[Role] ([roleId])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Role]
GO
ALTER TABLE [dbo].[MenuIngredients]  WITH CHECK ADD  CONSTRAINT [FK_MenuIngredients_Ingredients] FOREIGN KEY([ingredientsId])
REFERENCES [dbo].[Ingredients] ([ingredientsId])
GO
ALTER TABLE [dbo].[MenuIngredients] CHECK CONSTRAINT [FK_MenuIngredients_Ingredients]
GO
ALTER TABLE [dbo].[MenuIngredients]  WITH CHECK ADD  CONSTRAINT [FK_MenuIngredients_Menu] FOREIGN KEY([menuId])
REFERENCES [dbo].[Menu] ([menuId])
GO
ALTER TABLE [dbo].[MenuIngredients] CHECK CONSTRAINT [FK_MenuIngredients_Menu]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Table] FOREIGN KEY([tableId])
REFERENCES [dbo].[Table] ([tableId])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Table]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_orderDetails_Menu] FOREIGN KEY([menuId])
REFERENCES [dbo].[Menu] ([menuId])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_orderDetails_Menu]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_orderDetails_Order] FOREIGN KEY([orderId])
REFERENCES [dbo].[Order] ([orderId])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_orderDetails_Order]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Bank] FOREIGN KEY([bankId])
REFERENCES [dbo].[Bank] ([bankId])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Bank]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Member] FOREIGN KEY([memberId])
REFERENCES [dbo].[Member] ([memberId])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Member]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Order] FOREIGN KEY([orderId])
REFERENCES [dbo].[Order] ([orderId])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Order]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Promo] FOREIGN KEY([promoId])
REFERENCES [dbo].[Promo] ([promoId])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Promo]
GO
ALTER TABLE [dbo].[Promo]  WITH CHECK ADD  CONSTRAINT [FK_Promo_Bank] FOREIGN KEY([bankId])
REFERENCES [dbo].[Bank] ([bankId])
GO
ALTER TABLE [dbo].[Promo] CHECK CONSTRAINT [FK_Promo_Bank]
GO
USE [master]
GO
ALTER DATABASE [smk_restaurant] SET  READ_WRITE 
GO
