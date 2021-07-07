USE [master]
GO
/****** Object:  Database [db]    Script Date: 07.07.2021 15:09:11 ******/
CREATE DATABASE [db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Users', FILENAME = N'E:\Program Files\MSSQL15.SQLEXPRESS\MSSQL\DATA\Users.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Users_log', FILENAME = N'E:\Program Files\MSSQL15.SQLEXPRESS\MSSQL\DATA\Users.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [db] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [db] SET ANSI_NULLS ON 
GO
ALTER DATABASE [db] SET ANSI_PADDING ON 
GO
ALTER DATABASE [db] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [db] SET ARITHABORT ON 
GO
ALTER DATABASE [db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [db] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db] SET  DISABLE_BROKER 
GO
ALTER DATABASE [db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db] SET RECOVERY FULL 
GO
ALTER DATABASE [db] SET  MULTI_USER 
GO
ALTER DATABASE [db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [db] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [db] SET QUERY_STORE = OFF
GO
USE [db]
GO
/****** Object:  Table [dbo].[AwardAndUser]    Script Date: 07.07.2021 15:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AwardAndUser](
	[idAward] [int] NULL,
	[idUser] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Awards]    Script Date: 07.07.2021 15:09:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Awards](
	[id] [int] NOT NULL,
	[title] [nvarchar](50) NULL,
 CONSTRAINT [PK_Awards] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 07.07.2021 15:09:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] NULL,
	[name] [nvarchar](50) NULL,
	[dateOfBirth] [date] NULL,
	[passHash] [text] NULL,
	[roll] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AddAwardToUser]    Script Date: 07.07.2021 15:09:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddAwardToUser]
	@idUser int,
	@idAward int
AS
BEGIN
	SET NOCOUNT OFF;
	INSERT INTO AwardAndUser VALUES (@idAward,@idUser)
End 
GO
/****** Object:  StoredProcedure [dbo].[Award_GetByID]    Script Date: 07.07.2021 15:09:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Award_GetByID]
	@id int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT TOP 1
		id,title
		FROM dbo.Awards
		WHERE id =@id
END

GO
/****** Object:  StoredProcedure [dbo].[CreateAward]    Script Date: 07.07.2021 15:09:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateAward]
	@id int,
	@title nvarchar(250)
AS
BEGIN
	SET NOCOUNT OFF;

    INSERT INTO dbo.Awards VALUES (@id, @title)
END
GO
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 07.07.2021 15:09:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateUser]
	@id int,
	@name nvarchar(50),
	@dateOfBirth date,
	@passHash text,
	@roll int
AS
BEGIN
	SET NOCOUNT OFF;

    INSERT INTO dbo.Users VALUES (@id,@name,@dateOfBirth,@passHash,@roll)
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteAllAwardOfUser]    Script Date: 07.07.2021 15:09:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteAllAwardOfUser]
	@idUser int
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM dbo.AwardAndUser WHERE idUser = @idUser
End 
GO
/****** Object:  StoredProcedure [dbo].[DeleteAward]    Script Date: 07.07.2021 15:09:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteAward]
	@id int
AS
BEGIN
	SET NOCOUNT OFF;
	DELETE FROM dbo.Awards WHERE id = @id
	DELETE FROM dbo.AwardAndUser WHERE idAward = @id
End 
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 07.07.2021 15:09:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUser]
	@id int
AS
BEGIN
	SET NOCOUNT OFF;

	DELETE FROM dbo.Users WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[FindUserByName]    Script Date: 07.07.2021 15:09:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FindUserByName]
	@Name nvarchar(100)
AS
BEGIN
	SET NOCOUNT OFF;

	SELECT Name FROM dbo.Users WHERE Name = @Name
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllAwardOfUser]    Script Date: 07.07.2021 15:09:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllAwardOfUser]
@idUser int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT idAward FROM dbo.AwardAndUser WHERE @idUser=idUser
END


GO
/****** Object:  StoredProcedure [dbo].[GetAwards]    Script Date: 07.07.2021 15:09:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAwards]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM dbo.Awards
END
GO
/****** Object:  StoredProcedure [dbo].[GetUsers]    Script Date: 07.07.2021 15:09:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUsers]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM dbo.Users
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 07.07.2021 15:09:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUser] 
	@id int,
	@name nvarchar(50),
	@dateOfBirth date,
	@passHash nvarchar(50),
	@roll int
AS
BEGIN
	SET NOCOUNT OFF;

    UPDATE dbo.Users SET 
		name = @name,
		dateOfBirth  = @dateOfBirth,
		passHash=@passHash,
		roll=@roll

		WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[User_GetByID]    Script Date: 07.07.2021 15:09:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[User_GetByID]
	@id int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT TOP 1
		id, name ,dateOfBirth,passHash,roll
		FROM dbo.Users
		WHERE Id =@id
END 
GO
USE [master]
GO
ALTER DATABASE [db] SET  READ_WRITE 
GO
