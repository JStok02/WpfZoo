USE [master]
GO
/****** Object:  Database [ZooDB]    Script Date: 09.05.2025 11:54:14 ******/
CREATE DATABASE [ZooDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ZooDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ZooDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ZooDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ZooDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ZooDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ZooDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ZooDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ZooDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ZooDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ZooDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ZooDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ZooDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ZooDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ZooDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ZooDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ZooDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ZooDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ZooDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ZooDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ZooDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ZooDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ZooDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ZooDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ZooDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ZooDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ZooDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ZooDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ZooDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ZooDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ZooDB] SET  MULTI_USER 
GO
ALTER DATABASE [ZooDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ZooDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ZooDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ZooDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ZooDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ZooDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ZooDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [ZooDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ZooDB]
GO
/****** Object:  Table [dbo].[Animals]    Script Date: 09.05.2025 11:54:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Animals](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[species_id] [int] NOT NULL,
	[enclosure_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enclosures]    Script Date: 09.05.2025 11:54:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enclosures](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[max_species] [int] NULL,
 CONSTRAINT [PK__Enclosur__3213E83FB3FD8834] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedings]    Script Date: 09.05.2025 11:54:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedings](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[animal_id] [int] NOT NULL,
	[feeding_time] [datetime] NOT NULL,
	[notes] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Species]    Script Date: 09.05.2025 11:54:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Species](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 09.05.2025 11:54:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](100) NOT NULL,
	[password] [nvarchar](255) NULL,
	[role] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VeterinaryChecks]    Script Date: 09.05.2025 11:54:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VeterinaryChecks](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[animal_id] [int] NOT NULL,
	[check_date] [date] NOT NULL,
	[result] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Animals]  WITH CHECK ADD  CONSTRAINT [FK__Animals__enclosu__3D5E1FD2] FOREIGN KEY([enclosure_id])
REFERENCES [dbo].[Enclosures] ([id])
GO
ALTER TABLE [dbo].[Animals] CHECK CONSTRAINT [FK__Animals__enclosu__3D5E1FD2]
GO
ALTER TABLE [dbo].[Animals]  WITH CHECK ADD FOREIGN KEY([species_id])
REFERENCES [dbo].[Species] ([id])
GO
ALTER TABLE [dbo].[Feedings]  WITH CHECK ADD FOREIGN KEY([animal_id])
REFERENCES [dbo].[Animals] ([id])
GO
ALTER TABLE [dbo].[VeterinaryChecks]  WITH CHECK ADD FOREIGN KEY([animal_id])
REFERENCES [dbo].[Animals] ([id])
GO
ALTER TABLE [dbo].[Enclosures]  WITH CHECK ADD  CONSTRAINT [CK__Enclosure__max_s__398D8EEE] CHECK  (([max_species]<=(3)))
GO
ALTER TABLE [dbo].[Enclosures] CHECK CONSTRAINT [CK__Enclosure__max_s__398D8EEE]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD CHECK  (([role]='Director' OR [role]='Keeper' OR [role]='Vet'))
GO
/****** Object:  Trigger [dbo].[trg_UpdateMaxSpecies]    Script Date: 09.05.2025 11:54:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_UpdateMaxSpecies]
ON [dbo].[Animals]
AFTER INSERT
AS
BEGIN
    DECLARE @species_id INT;
    DECLARE @enclosure_id INT;

    -- Получаем id вида и id вольера из вставленной записи
    SELECT @species_id = species_id, @enclosure_id = enclosure_id
    FROM inserted;

    -- Проверяем количество видов в вольере
    DECLARE @species_count INT;
    SELECT @species_count = COUNT(DISTINCT species_id)
    FROM Animals
    WHERE enclosure_id = @enclosure_id;

    -- Если количество видов уже больше или равно 3, отклоняем вставку
    IF @species_count > 3
    BEGIN
        RAISERROR('Невозможно добавить новый вид, так как в вольере уже есть 3 вида животных.', 16, 1);
        ROLLBACK TRANSACTION;  -- Откатываем вставку
        RETURN;
    END

    -- Проверяем количество животных данного вида в указанном вольере
    DECLARE @animal_count INT;
    SELECT @animal_count = COUNT(*)
    FROM Animals
    WHERE species_id = @species_id AND enclosure_id = @enclosure_id;

    -- Теперь обновляем max_species в зависимости от количества животных
    -- Если количество животных одного вида больше 1, то max_species = 1
    -- Если количество животных разных видов больше 1, то max_species = 2
    DECLARE @max_animal_count INT;

    -- Определяем, какое значение max_species следует установить
    IF @species_count > 1
    BEGIN
        SELECT @max_animal_count = MAX(species_count)
        FROM (
            SELECT species_id, COUNT(*) AS species_count
            FROM Animals
            WHERE enclosure_id = @enclosure_id
            GROUP BY species_id
        ) AS species_counts;

        -- Если количество животных разных видов больше 1, то max_species = 2
        IF @max_animal_count > 1
        BEGIN
            UPDATE Enclosures
            SET max_species = 2
            WHERE id = @enclosure_id;
        END
        ELSE
        BEGIN
            UPDATE Enclosures
            SET max_species = 1
            WHERE id = @enclosure_id;
        END
    END
    ELSE
    BEGIN
        -- Если только один вид в вольере, то max_species = 1
        UPDATE Enclosures
        SET max_species = 1
        WHERE id = @enclosure_id;
    END
END;
GO
ALTER TABLE [dbo].[Animals] ENABLE TRIGGER [trg_UpdateMaxSpecies]
GO
USE [master]
GO
ALTER DATABASE [ZooDB] SET  READ_WRITE 
GO
