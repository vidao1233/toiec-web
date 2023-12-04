USE [master]
GO
/****** Object:  Database [ToiecWeb]    Script Date: 12/4/2023 3:49:24 PM ******/
CREATE DATABASE [ToiecWeb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ToiecWeb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ToiecWeb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ToiecWeb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ToiecWeb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ToiecWeb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ToiecWeb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ToiecWeb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ToiecWeb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ToiecWeb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ToiecWeb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ToiecWeb] SET ARITHABORT OFF 
GO
ALTER DATABASE [ToiecWeb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ToiecWeb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ToiecWeb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ToiecWeb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ToiecWeb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ToiecWeb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ToiecWeb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ToiecWeb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ToiecWeb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ToiecWeb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ToiecWeb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ToiecWeb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ToiecWeb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ToiecWeb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ToiecWeb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ToiecWeb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ToiecWeb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ToiecWeb] SET RECOVERY FULL 
GO
ALTER DATABASE [ToiecWeb] SET  MULTI_USER 
GO
ALTER DATABASE [ToiecWeb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ToiecWeb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ToiecWeb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ToiecWeb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ToiecWeb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ToiecWeb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ToiecWeb', N'ON'
GO
ALTER DATABASE [ToiecWeb] SET QUERY_STORE = ON
GO
ALTER DATABASE [ToiecWeb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ToiecWeb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/4/2023 3:49:24 PM ******/
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
/****** Object:  Table [dbo].[Admins]    Script Date: 12/4/2023 3:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[idAdmin] [uniqueidentifier] NOT NULL,
	[idUser] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Admins] PRIMARY KEY CLUSTERED 
(
	[idAdmin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AnswerQuestions]    Script Date: 12/4/2023 3:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnswerQuestions](
	[idAnswer] [uniqueidentifier] NOT NULL,
	[idQuestion] [uniqueidentifier] NOT NULL,
	[content] [nvarchar](max) NOT NULL,
	[QuestionidQuestion] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AnswerQuestions] PRIMARY KEY CLUSTERED 
(
	[idAnswer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 12/4/2023 3:49:24 PM ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12/4/2023 3:49:24 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12/4/2023 3:49:24 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12/4/2023 3:49:24 PM ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12/4/2023 3:49:24 PM ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12/4/2023 3:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[Discriminator] [nvarchar](max) NOT NULL,
	[Fullname] [nvarchar](max) NULL,
	[DateOfBirth] [nvarchar](max) NULL,
	[Gender] [bit] NULL,
	[Mobile] [bit] NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 12/4/2023 3:49:24 PM ******/
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
/****** Object:  Table [dbo].[Comments]    Script Date: 12/4/2023 3:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[idComment] [uniqueidentifier] NOT NULL,
	[idUser] [nvarchar](450) NOT NULL,
	[idPost] [uniqueidentifier] NOT NULL,
	[content] [nvarchar](max) NOT NULL,
	[createdDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[idComment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 12/4/2023 3:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[idCourse] [uniqueidentifier] NOT NULL,
	[idProfessor] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[idCourse] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lessons]    Script Date: 12/4/2023 3:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lessons](
	[idLesson] [uniqueidentifier] NOT NULL,
	[idCourse] [uniqueidentifier] NOT NULL,
	[title] [nvarchar](max) NOT NULL,
	[content] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Lessons] PRIMARY KEY CLUSTERED 
(
	[idLesson] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentMethods]    Script Date: 12/4/2023 3:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentMethods](
	[idMethod] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_PaymentMethods] PRIMARY KEY CLUSTERED 
(
	[idMethod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 12/4/2023 3:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[idPayment] [uniqueidentifier] NOT NULL,
	[idMethod] [uniqueidentifier] NOT NULL,
	[idStudent] [uniqueidentifier] NOT NULL,
	[idPackage] [uniqueidentifier] NOT NULL,
	[message] [nvarchar](max) NOT NULL,
	[paymentDate] [datetime2](7) NOT NULL,
	[paymentAmount] [float] NOT NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[idPayment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 12/4/2023 3:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[idPost] [uniqueidentifier] NOT NULL,
	[idUser] [nvarchar](450) NOT NULL,
	[title] [nvarchar](max) NOT NULL,
	[createdTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED 
(
	[idPost] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Professors]    Script Date: 12/4/2023 3:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professors](
	[idProfessor] [uniqueidentifier] NOT NULL,
	[idUser] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Professors] PRIMARY KEY CLUSTERED 
(
	[idProfessor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 12/4/2023 3:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[idQuestion] [uniqueidentifier] NOT NULL,
	[idQuiz] [uniqueidentifier] NOT NULL,
	[idUnit] [uniqueidentifier] NOT NULL,
	[idProfessor] [uniqueidentifier] NOT NULL,
	[content] [nvarchar](max) NOT NULL,
	[answer] [nvarchar](max) NOT NULL,
	[explaination] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED 
(
	[idQuestion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quizs]    Script Date: 12/4/2023 3:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quizs](
	[idQuiz] [uniqueidentifier] NOT NULL,
	[idLesson] [uniqueidentifier] NOT NULL,
	[title] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Quizs] PRIMARY KEY CLUSTERED 
(
	[idQuiz] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reports]    Script Date: 12/4/2023 3:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reports](
	[idReport] [uniqueidentifier] NOT NULL,
	[idUser] [nvarchar](450) NOT NULL,
	[idAdmin] [uniqueidentifier] NOT NULL,
	[idPost] [uniqueidentifier] NOT NULL,
	[reason] [nvarchar](max) NOT NULL,
	[isCheck] [bit] NOT NULL,
	[reportDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Reports] PRIMARY KEY CLUSTERED 
(
	[idReport] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResetPasswords]    Script Date: 12/4/2023 3:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResetPasswords](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](max) NOT NULL,
	[OTP] [nvarchar](max) NOT NULL,
	[InsertDateTimeUTC] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_ResetPasswords] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 12/4/2023 3:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[idStudent] [uniqueidentifier] NOT NULL,
	[idUser] [nvarchar](450) NOT NULL,
	[freeTest] [bit] NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[idStudent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestParts]    Script Date: 12/4/2023 3:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestParts](
	[partId] [uniqueidentifier] NOT NULL,
	[partName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_TestParts] PRIMARY KEY CLUSTERED 
(
	[partId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestQuestionUnits]    Script Date: 12/4/2023 3:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestQuestionUnits](
	[idQuestionUnit] [uniqueidentifier] NOT NULL,
	[idTest] [uniqueidentifier] NOT NULL,
	[idTestPart] [uniqueidentifier] NOT NULL,
	[paragraph] [nvarchar](max) NULL,
	[audio] [nvarchar](max) NULL,
	[image] [nvarchar](max) NULL,
	[script] [nvarchar](max) NULL,
	[translation] [nvarchar](max) NULL,
 CONSTRAINT [PK_TestQuestionUnits] PRIMARY KEY CLUSTERED 
(
	[idQuestionUnit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestRecords]    Script Date: 12/4/2023 3:49:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestRecords](
	[idRecord] [uniqueidentifier] NOT NULL,
	[idTest] [uniqueidentifier] NOT NULL,
	[idStudent] [uniqueidentifier] NOT NULL,
	[createDate] [datetime2](7) NOT NULL,
	[score] [float] NOT NULL,
 CONSTRAINT [PK_TestRecords] PRIMARY KEY CLUSTERED 
(
	[idRecord] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tests]    Script Date: 12/4/2023 3:49:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tests](
	[idTest] [uniqueidentifier] NOT NULL,
	[idType] [uniqueidentifier] NOT NULL,
	[idProfessor] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[createDate] [datetime2](7) NOT NULL,
	[useDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Tests] PRIMARY KEY CLUSTERED 
(
	[idTest] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestTypes]    Script Date: 12/4/2023 3:49:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestTypes](
	[idTestType] [uniqueidentifier] NOT NULL,
	[typeName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_TestTypes] PRIMARY KEY CLUSTERED 
(
	[idTestType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAnswers]    Script Date: 12/4/2023 3:49:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAnswers](
	[idUAnswer] [uniqueidentifier] NOT NULL,
	[idQuestion] [uniqueidentifier] NOT NULL,
	[idRecord] [uniqueidentifier] NOT NULL,
	[idStudent] [uniqueidentifier] NOT NULL,
	[answer] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_UserAnswers] PRIMARY KEY CLUSTERED 
(
	[idUAnswer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VipPackages]    Script Date: 12/4/2023 3:49:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VipPackages](
	[idPackage] [uniqueidentifier] NOT NULL,
	[idAdmin] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[description] [nvarchar](max) NOT NULL,
	[price] [float] NOT NULL,
	[duration] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_VipPackages] PRIMARY KEY CLUSTERED 
(
	[idPackage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VipStudents]    Script Date: 12/4/2023 3:49:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VipStudents](
	[idVipStudent] [uniqueidentifier] NOT NULL,
	[idStudent] [uniqueidentifier] NOT NULL,
	[vipExpire] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_VipStudents] PRIMARY KEY CLUSTERED 
(
	[idVipStudent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vocabularies]    Script Date: 12/4/2023 3:49:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vocabularies](
	[idVoc] [uniqueidentifier] NOT NULL,
	[idTopic] [uniqueidentifier] NOT NULL,
	[idProfessor] [uniqueidentifier] NOT NULL,
	[engWord] [nvarchar](max) NOT NULL,
	[wordType] [nvarchar](max) NOT NULL,
	[meaning] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Vocabularies] PRIMARY KEY CLUSTERED 
(
	[idVoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VocabularyTopics]    Script Date: 12/4/2023 3:49:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VocabularyTopics](
	[idVocTopic] [uniqueidentifier] NOT NULL,
	[idProfessor] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_VocabularyTopics] PRIMARY KEY CLUSTERED 
(
	[idVocTopic] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231204082714_update n', N'6.0.24')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1257b8ad-564a-456f-81a1-d38f180ddd63', N'Student', N'Student', N'2')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'35564c0c-f6fc-4ce5-ad98-f3c362e90ed1', N'VipStudent', N'VipStudent', N'3')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'8111cfd6-214a-4694-a13c-c6ec3d7f56b2', N'Admin', N'Admin', N'1')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'9faf18a9-5a41-4b13-9db3-63246839aea9', N'Professor', N'Professor', N'4')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3ba19d1f-b1d8-4cfe-a8d3-8836883843fa', N'9faf18a9-5a41-4b13-9db3-63246839aea9')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'adf2d96d-68e0-48f2-8a35-7d3e8d315afb', N'9faf18a9-5a41-4b13-9db3-63246839aea9')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [Fullname], [DateOfBirth], [Gender], [Mobile], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'3ba19d1f-b1d8-4cfe-a8d3-8836883843fa', N'Users', N'pro2', NULL, 0, 0, N'pro2', N'PRO2', N'pro2@example.com', N'PRO2@EXAMPLE.COM', 0, N'AQAAAAEAACcQAAAAECFHz8nz6eCmIxvYTFX6sCQqgVtyEYum58TBE9JX4n0bUI0aOMIwv5cqLojJ3eYVnw==', N'7GRV53SMFOU7LBSK6P5OMEUGBV5EDIFW', N'b94ef263-6005-4315-8f5d-52620b0c3f98', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [Fullname], [DateOfBirth], [Gender], [Mobile], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'adf2d96d-68e0-48f2-8a35-7d3e8d315afb', N'Users', N'pro1', NULL, 0, 0, N'pro1', N'PRO1', N'pro1@example.com', N'PRO1@EXAMPLE.COM', 0, N'AQAAAAEAACcQAAAAELJxVN3RVdjdghDmeMxFHd2Z/2gasQTki5UfcVga9TrChE4ygxyNYag6dzZY91TQeg==', N'L5VAD4ATZ3AO4ULFSNWYW2E3PBOKWLLG', N'70c17f64-3674-4df0-a4f4-94ea2a60a607', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[Professors] ([idProfessor], [idUser]) VALUES (N'9cdd0817-8978-4f78-8a47-5bd1ea3988e3', N'3ba19d1f-b1d8-4cfe-a8d3-8836883843fa')
INSERT [dbo].[Professors] ([idProfessor], [idUser]) VALUES (N'6b3bdcc1-3443-4a73-a70b-10dd8fbe3875', N'adf2d96d-68e0-48f2-8a35-7d3e8d315afb')
GO
INSERT [dbo].[TestParts] ([partId], [partName]) VALUES (N'ab6cea14-a70e-41cf-99aa-298c2a8eeae8', N'Part 6')
INSERT [dbo].[TestParts] ([partId], [partName]) VALUES (N'108c2c37-5a20-41da-85e3-49f5639efb86', N'Part 7')
INSERT [dbo].[TestParts] ([partId], [partName]) VALUES (N'99092e20-042a-46dd-ab9a-7abed9685129', N'Part 5')
INSERT [dbo].[TestParts] ([partId], [partName]) VALUES (N'50a65bd0-2492-426a-8a0a-9722b4112de7', N'Part 1')
INSERT [dbo].[TestParts] ([partId], [partName]) VALUES (N'9a6bb2e2-61d8-4960-9b6e-c0434bbc8dfe', N'Part 3')
INSERT [dbo].[TestParts] ([partId], [partName]) VALUES (N'7781f88a-b0bd-44c2-94a9-c536f12190e0', N'Part 2')
INSERT [dbo].[TestParts] ([partId], [partName]) VALUES (N'42a4abf4-cc75-48ac-ba3e-e49bef10754e', N'Part 4')
GO
INSERT [dbo].[TestQuestionUnits] ([idQuestionUnit], [idTest], [idTestPart], [paragraph], [audio], [image], [script], [translation]) VALUES (N'5dd01b29-de9e-403b-8d0d-09b6e625a009', N'bbae58fe-d1ca-42d1-8fc8-ca8a2f9afaca', N'ab6cea14-a70e-41cf-99aa-298c2a8eeae8', N'The dog is a loyal and affectionate companion. With its wagging tail and expressive eyes, it exudes an undeniable charm. Dogs come in various shapes, sizes, and breeds, each possessing its own unique characteristics. They are known for their unwavering loyalty, always eager to please their human counterparts. Dogs are highly social creatures, thriving on companionship and forming strong bonds with their owners and families. They bring joy and happiness into homes, often serving as loving and protective members of the family. Dogs are also known for their intelligence and trainability, making them ideal for various tasks such as assistance work, search and rescue, and therapy. Whether they are bounding around with boundless energy or curling up for a cozy nap, dogs have an uncanny ability to brighten our lives and teach us about unconditional love.', N'http://res.cloudinary.com/dru8wcmtb/video/upload/v1701678934/v7kfa0uhrnl5kkacnrw0.mp3', N'http://res.cloudinary.com/dru8wcmtb/image/upload/v1701678937/wba57hgipivge3bkbthv.jpg', NULL, N'Chú chó là một người bạn trung thành và yêu thương. Với đuôi vẫy và đôi mắt biểu cảm, chú chó tạo nên một sự quyến rũ không thể chối từ. Chúng có nhiều hình dạng, kích thước và giống, mỗi giống mang những đặc điểm riêng biệt của mình. Chó nổi tiếng với lòng trung thành không bao giờ thay đổi, luôn háo hức phục vụ con người. Chó là những sinh vật xã hội cao, sống tốt khi có sự gần gũi và tạo dựng những mối quan hệ mạnh mẽ với chủ nhân và gia đình. Chúng mang lại niềm vui và hạnh phúc trong ngôi nhà, thường trở thành thành viên yêu thương và bảo vệ của gia đình. Chó cũng nổi tiếng với sự thông minh và khả năng được huấn luyện, làm cho chúng trở thành lựa chọn lý tưởng cho các công việc như hỗ trợ, tìm kiếm và cứu hộ, và công việc trị liệu. Dù chúng đang chạy nhảy với năng lượng vô tận hay cuộn tròn để ngủ ngon, chó có khả năng đặc biệt để làm sáng tỏ cuộc sống của chúng ta và dạy chúng ta về tình yêu vô điều kiện.')
GO
INSERT [dbo].[Tests] ([idTest], [idType], [idProfessor], [name], [createDate], [useDate]) VALUES (N'bbae58fe-d1ca-42d1-8fc8-ca8a2f9afaca', N'6663edbe-71bf-4f5f-9f35-2f22e3debee7', N'6b3bdcc1-3443-4a73-a70b-10dd8fbe3875', N'Toiec cap toc', CAST(N'2023-12-04T08:31:31.0750000' AS DateTime2), CAST(N'2023-12-04T08:31:31.0750000' AS DateTime2))
GO
INSERT [dbo].[TestTypes] ([idTestType], [typeName]) VALUES (N'6663edbe-71bf-4f5f-9f35-2f22e3debee7', N'Full Test')
INSERT [dbo].[TestTypes] ([idTestType], [typeName]) VALUES (N'6907a63c-b73f-44c2-ba25-b71aef584408', N'Mini Test')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Admins_idUser]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Admins_idUser] ON [dbo].[Admins]
(
	[idUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AnswerQuestions_QuestionidQuestion]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_AnswerQuestions_QuestionidQuestion] ON [dbo].[AnswerQuestions]
(
	[QuestionidQuestion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comments_idPost]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_Comments_idPost] ON [dbo].[Comments]
(
	[idPost] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Comments_idUser]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_Comments_idUser] ON [dbo].[Comments]
(
	[idUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Courses_idProfessor]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_Courses_idProfessor] ON [dbo].[Courses]
(
	[idProfessor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Lessons_idCourse]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_Lessons_idCourse] ON [dbo].[Lessons]
(
	[idCourse] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Payments_idMethod]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_Payments_idMethod] ON [dbo].[Payments]
(
	[idMethod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Payments_idPackage]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_Payments_idPackage] ON [dbo].[Payments]
(
	[idPackage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Payments_idStudent]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_Payments_idStudent] ON [dbo].[Payments]
(
	[idStudent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Posts_idUser]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_Posts_idUser] ON [dbo].[Posts]
(
	[idUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Professors_idUser]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Professors_idUser] ON [dbo].[Professors]
(
	[idUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Questions_idProfessor]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_Questions_idProfessor] ON [dbo].[Questions]
(
	[idProfessor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Questions_idQuiz]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_Questions_idQuiz] ON [dbo].[Questions]
(
	[idQuiz] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Questions_idUnit]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_Questions_idUnit] ON [dbo].[Questions]
(
	[idUnit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Quizs_idLesson]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_Quizs_idLesson] ON [dbo].[Quizs]
(
	[idLesson] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reports_idAdmin]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_Reports_idAdmin] ON [dbo].[Reports]
(
	[idAdmin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reports_idPost]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_Reports_idPost] ON [dbo].[Reports]
(
	[idPost] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Reports_idUser]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_Reports_idUser] ON [dbo].[Reports]
(
	[idUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Students_idUser]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Students_idUser] ON [dbo].[Students]
(
	[idUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TestQuestionUnits_idTest]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_TestQuestionUnits_idTest] ON [dbo].[TestQuestionUnits]
(
	[idTest] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TestQuestionUnits_idTestPart]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_TestQuestionUnits_idTestPart] ON [dbo].[TestQuestionUnits]
(
	[idTestPart] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TestRecords_idStudent]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_TestRecords_idStudent] ON [dbo].[TestRecords]
(
	[idStudent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TestRecords_idTest]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_TestRecords_idTest] ON [dbo].[TestRecords]
(
	[idTest] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tests_idProfessor]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_Tests_idProfessor] ON [dbo].[Tests]
(
	[idProfessor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tests_idType]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_Tests_idType] ON [dbo].[Tests]
(
	[idType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserAnswers_idQuestion]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserAnswers_idQuestion] ON [dbo].[UserAnswers]
(
	[idQuestion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserAnswers_idRecord]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserAnswers_idRecord] ON [dbo].[UserAnswers]
(
	[idRecord] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserAnswers_idStudent]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserAnswers_idStudent] ON [dbo].[UserAnswers]
(
	[idStudent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_VipPackages_idAdmin]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_VipPackages_idAdmin] ON [dbo].[VipPackages]
(
	[idAdmin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_VipStudents_idStudent]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_VipStudents_idStudent] ON [dbo].[VipStudents]
(
	[idStudent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Vocabularies_idProfessor]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_Vocabularies_idProfessor] ON [dbo].[Vocabularies]
(
	[idProfessor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Vocabularies_idTopic]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_Vocabularies_idTopic] ON [dbo].[Vocabularies]
(
	[idTopic] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_VocabularyTopics_idProfessor]    Script Date: 12/4/2023 3:49:25 PM ******/
CREATE NONCLUSTERED INDEX [IX_VocabularyTopics_idProfessor] ON [dbo].[VocabularyTopics]
(
	[idProfessor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Admins]  WITH CHECK ADD  CONSTRAINT [FK_AdminOfUser] FOREIGN KEY([idUser])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Admins] CHECK CONSTRAINT [FK_AdminOfUser]
GO
ALTER TABLE [dbo].[AnswerQuestions]  WITH CHECK ADD  CONSTRAINT [FK_AnswerQuestions_Questions_QuestionidQuestion] FOREIGN KEY([QuestionidQuestion])
REFERENCES [dbo].[Questions] ([idQuestion])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AnswerQuestions] CHECK CONSTRAINT [FK_AnswerQuestions_Questions_QuestionidQuestion]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
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
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_CommentsOfPost] FOREIGN KEY([idPost])
REFERENCES [dbo].[Posts] ([idPost])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_CommentsOfPost]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_CommentsOfUser] FOREIGN KEY([idUser])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_CommentsOfUser]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_CourseOfProfessor] FOREIGN KEY([idProfessor])
REFERENCES [dbo].[Professors] ([idProfessor])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_CourseOfProfessor]
GO
ALTER TABLE [dbo].[Lessons]  WITH CHECK ADD  CONSTRAINT [FK_LessonOfCourse] FOREIGN KEY([idCourse])
REFERENCES [dbo].[Courses] ([idCourse])
GO
ALTER TABLE [dbo].[Lessons] CHECK CONSTRAINT [FK_LessonOfCourse]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [PaymentOfMethod] FOREIGN KEY([idMethod])
REFERENCES [dbo].[PaymentMethods] ([idMethod])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [PaymentOfMethod]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [PaymentOfStudent] FOREIGN KEY([idStudent])
REFERENCES [dbo].[Students] ([idStudent])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [PaymentOfStudent]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [PaymentOfVipPackage] FOREIGN KEY([idPackage])
REFERENCES [dbo].[VipPackages] ([idPackage])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [PaymentOfVipPackage]
GO
ALTER TABLE [dbo].[Posts]  WITH CHECK ADD  CONSTRAINT [FK_PostOfUser] FOREIGN KEY([idUser])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Posts] CHECK CONSTRAINT [FK_PostOfUser]
GO
ALTER TABLE [dbo].[Professors]  WITH CHECK ADD  CONSTRAINT [FK_ProfessorOfUser] FOREIGN KEY([idUser])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Professors] CHECK CONSTRAINT [FK_ProfessorOfUser]
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_QuestionsOfProfessor] FOREIGN KEY([idProfessor])
REFERENCES [dbo].[Professors] ([idProfessor])
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_QuestionsOfProfessor]
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_QuestionsOfQuiz] FOREIGN KEY([idQuiz])
REFERENCES [dbo].[Quizs] ([idQuiz])
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_QuestionsOfQuiz]
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_QuestionsOfUnit] FOREIGN KEY([idUnit])
REFERENCES [dbo].[TestQuestionUnits] ([idQuestionUnit])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_QuestionsOfUnit]
GO
ALTER TABLE [dbo].[Quizs]  WITH CHECK ADD  CONSTRAINT [FK_QuizzesOfLesson] FOREIGN KEY([idLesson])
REFERENCES [dbo].[Lessons] ([idLesson])
GO
ALTER TABLE [dbo].[Quizs] CHECK CONSTRAINT [FK_QuizzesOfLesson]
GO
ALTER TABLE [dbo].[Reports]  WITH CHECK ADD  CONSTRAINT [FK_AdminCheckReport] FOREIGN KEY([idAdmin])
REFERENCES [dbo].[Admins] ([idAdmin])
GO
ALTER TABLE [dbo].[Reports] CHECK CONSTRAINT [FK_AdminCheckReport]
GO
ALTER TABLE [dbo].[Reports]  WITH CHECK ADD  CONSTRAINT [FK_ReportsOfPost] FOREIGN KEY([idPost])
REFERENCES [dbo].[Posts] ([idPost])
GO
ALTER TABLE [dbo].[Reports] CHECK CONSTRAINT [FK_ReportsOfPost]
GO
ALTER TABLE [dbo].[Reports]  WITH CHECK ADD  CONSTRAINT [FK_ReportsOfUser] FOREIGN KEY([idUser])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Reports] CHECK CONSTRAINT [FK_ReportsOfUser]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_StudentOfUser] FOREIGN KEY([idUser])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_StudentOfUser]
GO
ALTER TABLE [dbo].[TestQuestionUnits]  WITH CHECK ADD  CONSTRAINT [FK_UnitOfTestPart] FOREIGN KEY([idTestPart])
REFERENCES [dbo].[TestParts] ([partId])
GO
ALTER TABLE [dbo].[TestQuestionUnits] CHECK CONSTRAINT [FK_UnitOfTestPart]
GO
ALTER TABLE [dbo].[TestQuestionUnits]  WITH CHECK ADD  CONSTRAINT [FK_UnitsOfTest] FOREIGN KEY([idTest])
REFERENCES [dbo].[Tests] ([idTest])
GO
ALTER TABLE [dbo].[TestQuestionUnits] CHECK CONSTRAINT [FK_UnitsOfTest]
GO
ALTER TABLE [dbo].[TestRecords]  WITH CHECK ADD  CONSTRAINT [RecordOfStudent] FOREIGN KEY([idStudent])
REFERENCES [dbo].[Students] ([idStudent])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TestRecords] CHECK CONSTRAINT [RecordOfStudent]
GO
ALTER TABLE [dbo].[TestRecords]  WITH CHECK ADD  CONSTRAINT [RecordOfTest] FOREIGN KEY([idTest])
REFERENCES [dbo].[Tests] ([idTest])
GO
ALTER TABLE [dbo].[TestRecords] CHECK CONSTRAINT [RecordOfTest]
GO
ALTER TABLE [dbo].[Tests]  WITH CHECK ADD  CONSTRAINT [TestOfProfessor] FOREIGN KEY([idProfessor])
REFERENCES [dbo].[Professors] ([idProfessor])
GO
ALTER TABLE [dbo].[Tests] CHECK CONSTRAINT [TestOfProfessor]
GO
ALTER TABLE [dbo].[Tests]  WITH CHECK ADD  CONSTRAINT [TypeTest] FOREIGN KEY([idType])
REFERENCES [dbo].[TestTypes] ([idTestType])
GO
ALTER TABLE [dbo].[Tests] CHECK CONSTRAINT [TypeTest]
GO
ALTER TABLE [dbo].[UserAnswers]  WITH CHECK ADD  CONSTRAINT [FK_AnswerOfQuestion] FOREIGN KEY([idQuestion])
REFERENCES [dbo].[Questions] ([idQuestion])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserAnswers] CHECK CONSTRAINT [FK_AnswerOfQuestion]
GO
ALTER TABLE [dbo].[UserAnswers]  WITH CHECK ADD  CONSTRAINT [FK_AnswerOfStudent] FOREIGN KEY([idStudent])
REFERENCES [dbo].[Students] ([idStudent])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserAnswers] CHECK CONSTRAINT [FK_AnswerOfStudent]
GO
ALTER TABLE [dbo].[UserAnswers]  WITH CHECK ADD  CONSTRAINT [FK_RecordAnswer] FOREIGN KEY([idRecord])
REFERENCES [dbo].[TestRecords] ([idRecord])
GO
ALTER TABLE [dbo].[UserAnswers] CHECK CONSTRAINT [FK_RecordAnswer]
GO
ALTER TABLE [dbo].[VipPackages]  WITH CHECK ADD  CONSTRAINT [FK_ManageVipPackage] FOREIGN KEY([idAdmin])
REFERENCES [dbo].[Admins] ([idAdmin])
GO
ALTER TABLE [dbo].[VipPackages] CHECK CONSTRAINT [FK_ManageVipPackage]
GO
ALTER TABLE [dbo].[VipStudents]  WITH CHECK ADD  CONSTRAINT [FK_VipStudentOfStudent] FOREIGN KEY([idStudent])
REFERENCES [dbo].[Students] ([idStudent])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VipStudents] CHECK CONSTRAINT [FK_VipStudentOfStudent]
GO
ALTER TABLE [dbo].[Vocabularies]  WITH CHECK ADD  CONSTRAINT [FK_VocOfProfessor] FOREIGN KEY([idProfessor])
REFERENCES [dbo].[Professors] ([idProfessor])
GO
ALTER TABLE [dbo].[Vocabularies] CHECK CONSTRAINT [FK_VocOfProfessor]
GO
ALTER TABLE [dbo].[Vocabularies]  WITH CHECK ADD  CONSTRAINT [FK_VocOfTopic] FOREIGN KEY([idTopic])
REFERENCES [dbo].[VocabularyTopics] ([idVocTopic])
GO
ALTER TABLE [dbo].[Vocabularies] CHECK CONSTRAINT [FK_VocOfTopic]
GO
ALTER TABLE [dbo].[VocabularyTopics]  WITH CHECK ADD  CONSTRAINT [FK_TopicOfProfessor] FOREIGN KEY([idProfessor])
REFERENCES [dbo].[Professors] ([idProfessor])
GO
ALTER TABLE [dbo].[VocabularyTopics] CHECK CONSTRAINT [FK_TopicOfProfessor]
GO
USE [master]
GO
ALTER DATABASE [ToiecWeb] SET  READ_WRITE 
GO
