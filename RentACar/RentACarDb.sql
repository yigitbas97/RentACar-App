USE [RentACarDb]
GO
/****** Object:  Table [dbo].[CarMaintenances]    Script Date: 8.09.2019 03:29:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarMaintenances](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PlateNumber] [nvarchar](50) NOT NULL,
	[LastMaintenanceDate] [datetime] NOT NULL,
	[FutureMaintenanceDate] [datetime] NOT NULL,
	[CarKilometers] [int] NOT NULL,
	[User] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 8.09.2019 03:29:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PlateNumber] [nvarchar](50) NOT NULL,
	[Brand] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](20) NOT NULL,
	[GearType] [nvarchar](1) NOT NULL,
	[Color] [nvarchar](50) NOT NULL,
	[NumberOfSeats] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[User] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PlateNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 8.09.2019 03:29:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TC] [nvarchar](11) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[BirthDate] [datetime] NOT NULL,
	[Gender] [nvarchar](1) NOT NULL,
	[EMail] [nvarchar](100) NULL,
	[Address] [nvarchar](250) NOT NULL,
	[PhoneNumber] [nvarchar](13) NOT NULL,
	[PhoneNumber2] [nvarchar](13) NULL,
	[DriverLicence] [nvarchar](3) NOT NULL,
	[User] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RentedCarsRecords]    Script Date: 8.09.2019 03:29:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentedCarsRecords](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PlateNumber] [nvarchar](50) NOT NULL,
	[TC] [nvarchar](11) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[State] [nvarchar](1) NOT NULL,
	[User] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 8.09.2019 03:29:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
