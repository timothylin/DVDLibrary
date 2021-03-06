USE [master]
GO
/****** Object:  Database [DVDLibrary]    Script Date: 11/10/2015 2:22:04 PM ******/
CREATE DATABASE [DVDLibrary]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DVDLibrary', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\DVDLibrary.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DVDLibrary_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\DVDLibrary_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DVDLibrary] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DVDLibrary].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DVDLibrary] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DVDLibrary] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DVDLibrary] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DVDLibrary] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DVDLibrary] SET ARITHABORT OFF 
GO
ALTER DATABASE [DVDLibrary] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DVDLibrary] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DVDLibrary] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DVDLibrary] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DVDLibrary] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DVDLibrary] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DVDLibrary] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DVDLibrary] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DVDLibrary] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DVDLibrary] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DVDLibrary] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DVDLibrary] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DVDLibrary] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DVDLibrary] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DVDLibrary] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DVDLibrary] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DVDLibrary] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DVDLibrary] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DVDLibrary] SET  MULTI_USER 
GO
ALTER DATABASE [DVDLibrary] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DVDLibrary] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DVDLibrary] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DVDLibrary] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DVDLibrary] SET DELAYED_DURABILITY = DISABLED 
GO
USE [DVDLibrary]
GO
/****** Object:  Table [dbo].[Actors]    Script Date: 11/10/2015 2:22:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Actors](
	[ActorID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](30) NOT NULL,
	[LastName] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ActorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Borrowers]    Script Date: 11/10/2015 2:22:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Borrowers](
	[BorrowerID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](30) NOT NULL,
	[LastName] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BorrowerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Directors]    Script Date: 11/10/2015 2:22:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Directors](
	[DirectorID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](30) NOT NULL,
	[LastName] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DirectorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MovieActors]    Script Date: 11/10/2015 2:22:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieActors](
	[ActorID] [int] NOT NULL,
	[MovieID] [int] NOT NULL,
 CONSTRAINT [PK_MovieActors] PRIMARY KEY CLUSTERED 
(
	[ActorID] ASC,
	[MovieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MovieBorrower]    Script Date: 11/10/2015 2:22:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MovieBorrower](
	[MovieID] [int] NOT NULL,
	[BorrowerID] [int] NOT NULL,
	[DateBorrowed] [date] NULL,
	[DateReturned] [date] NULL,
	[UserRating] [int] NULL,
	[UserNotes] [varchar](1000) NULL,
 CONSTRAINT [PK_MovieBorrower] PRIMARY KEY CLUSTERED 
(
	[BorrowerID] ASC,
	[MovieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 11/10/2015 2:22:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Movies](
	[MovieID] [int] IDENTITY(1,1) NOT NULL,
	[MovieTitle] [varchar](50) NOT NULL,
	[MPAARatingID] [int] NOT NULL,
	[DirectorID] [int] NOT NULL,
	[StudioID] [int] NOT NULL,
	[ReleaseDate] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MovieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MPAARatings]    Script Date: 11/10/2015 2:22:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MPAARatings](
	[MPAARatingID] [int] IDENTITY(1,1) NOT NULL,
	[FilmRating] [varchar](5) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MPAARatingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Studios]    Script Date: 11/10/2015 2:22:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Studios](
	[StudioID] [int] IDENTITY(1,1) NOT NULL,
	[StudioName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StudioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Actors] ON 

INSERT [dbo].[Actors] ([ActorID], [FirstName], [LastName]) VALUES (1, N'Patrick', N'Tighe')
INSERT [dbo].[Actors] ([ActorID], [FirstName], [LastName]) VALUES (2, N'Lara', N'Caves')
INSERT [dbo].[Actors] ([ActorID], [FirstName], [LastName]) VALUES (3, N'Koshin', N'Abdi')
INSERT [dbo].[Actors] ([ActorID], [FirstName], [LastName]) VALUES (4, N'Timothy', N'Lin')
INSERT [dbo].[Actors] ([ActorID], [FirstName], [LastName]) VALUES (5, N'Victor', N'Kim')
SET IDENTITY_INSERT [dbo].[Actors] OFF
SET IDENTITY_INSERT [dbo].[Borrowers] ON 

INSERT [dbo].[Borrowers] ([BorrowerID], [FirstName], [LastName]) VALUES (1, N'Jim', N'Shaw')
INSERT [dbo].[Borrowers] ([BorrowerID], [FirstName], [LastName]) VALUES (2, N'Chary', N'Gurney')
INSERT [dbo].[Borrowers] ([BorrowerID], [FirstName], [LastName]) VALUES (3, N'Andrew', N'Tang')
INSERT [dbo].[Borrowers] ([BorrowerID], [FirstName], [LastName]) VALUES (4, N'Eric', N'Wise')
INSERT [dbo].[Borrowers] ([BorrowerID], [FirstName], [LastName]) VALUES (5, N'Victor', N'Pudelski')
SET IDENTITY_INSERT [dbo].[Borrowers] OFF
SET IDENTITY_INSERT [dbo].[Directors] ON 

INSERT [dbo].[Directors] ([DirectorID], [FirstName], [LastName]) VALUES (1, N'Stephen', N'Spielberg')
INSERT [dbo].[Directors] ([DirectorID], [FirstName], [LastName]) VALUES (2, N'Ron', N'Howard')
INSERT [dbo].[Directors] ([DirectorID], [FirstName], [LastName]) VALUES (3, N'Christopher', N'Nolan')
INSERT [dbo].[Directors] ([DirectorID], [FirstName], [LastName]) VALUES (4, N'Alexander', N'McQueen')
INSERT [dbo].[Directors] ([DirectorID], [FirstName], [LastName]) VALUES (5, N'Geroge', N'Lucas')
SET IDENTITY_INSERT [dbo].[Directors] OFF
SET IDENTITY_INSERT [dbo].[Movies] ON 

INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MPAARatingID], [DirectorID], [StudioID], [ReleaseDate]) VALUES (1, N'Good Burger', 1, 1, 1, 2009)
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MPAARatingID], [DirectorID], [StudioID], [ReleaseDate]) VALUES (2, N'Brave Heart', 2, 2, 2, 2014)
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MPAARatingID], [DirectorID], [StudioID], [ReleaseDate]) VALUES (3, N'Dot Not September', 3, 3, 3, 2016)
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MPAARatingID], [DirectorID], [StudioID], [ReleaseDate]) VALUES (4, N'Star Wars', 4, 4, 4, 2015)
INSERT [dbo].[Movies] ([MovieID], [MovieTitle], [MPAARatingID], [DirectorID], [StudioID], [ReleaseDate]) VALUES (5, N'Star Trek', 5, 5, 5, 2015)
SET IDENTITY_INSERT [dbo].[Movies] OFF
SET IDENTITY_INSERT [dbo].[MPAARatings] ON 

INSERT [dbo].[MPAARatings] ([MPAARatingID], [FilmRating]) VALUES (1, N'G')
INSERT [dbo].[MPAARatings] ([MPAARatingID], [FilmRating]) VALUES (2, N'PG')
INSERT [dbo].[MPAARatings] ([MPAARatingID], [FilmRating]) VALUES (3, N'PG-13')
INSERT [dbo].[MPAARatings] ([MPAARatingID], [FilmRating]) VALUES (4, N'R')
INSERT [dbo].[MPAARatings] ([MPAARatingID], [FilmRating]) VALUES (5, N'NC-17')
SET IDENTITY_INSERT [dbo].[MPAARatings] OFF
SET IDENTITY_INSERT [dbo].[Studios] ON 

INSERT [dbo].[Studios] ([StudioID], [StudioName]) VALUES (1, N'Warner Bros.')
INSERT [dbo].[Studios] ([StudioID], [StudioName]) VALUES (2, N'Universal')
INSERT [dbo].[Studios] ([StudioID], [StudioName]) VALUES (3, N'Fox')
INSERT [dbo].[Studios] ([StudioID], [StudioName]) VALUES (4, N'Sony')
INSERT [dbo].[Studios] ([StudioID], [StudioName]) VALUES (5, N'Legendary')
INSERT [dbo].[Studios] ([StudioID], [StudioName]) VALUES (6, N'Lionsgate')
SET IDENTITY_INSERT [dbo].[Studios] OFF
ALTER TABLE [dbo].[MovieActors]  WITH CHECK ADD  CONSTRAINT [FK_MovieActors_Actors] FOREIGN KEY([ActorID])
REFERENCES [dbo].[Actors] ([ActorID])
GO
ALTER TABLE [dbo].[MovieActors] CHECK CONSTRAINT [FK_MovieActors_Actors]
GO
ALTER TABLE [dbo].[MovieActors]  WITH CHECK ADD  CONSTRAINT [FK_MovieActors_Movies] FOREIGN KEY([MovieID])
REFERENCES [dbo].[Movies] ([MovieID])
GO
ALTER TABLE [dbo].[MovieActors] CHECK CONSTRAINT [FK_MovieActors_Movies]
GO
ALTER TABLE [dbo].[MovieBorrower]  WITH CHECK ADD  CONSTRAINT [FK_MovieBorrower_Borrowers] FOREIGN KEY([BorrowerID])
REFERENCES [dbo].[Borrowers] ([BorrowerID])
GO
ALTER TABLE [dbo].[MovieBorrower] CHECK CONSTRAINT [FK_MovieBorrower_Borrowers]
GO
ALTER TABLE [dbo].[MovieBorrower]  WITH CHECK ADD  CONSTRAINT [FK_MovieBorrower_Movies] FOREIGN KEY([MovieID])
REFERENCES [dbo].[Movies] ([MovieID])
GO
ALTER TABLE [dbo].[MovieBorrower] CHECK CONSTRAINT [FK_MovieBorrower_Movies]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Directors] FOREIGN KEY([DirectorID])
REFERENCES [dbo].[Directors] ([DirectorID])
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_Directors]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_MPAARatings] FOREIGN KEY([MPAARatingID])
REFERENCES [dbo].[MPAARatings] ([MPAARatingID])
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_MPAARatings]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Studios] FOREIGN KEY([StudioID])
REFERENCES [dbo].[Studios] ([StudioID])
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_Studios]
GO
USE [master]
GO
ALTER DATABASE [DVDLibrary] SET  READ_WRITE 
GO
