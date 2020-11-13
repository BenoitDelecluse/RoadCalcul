USE [RoadCalcul]
GO

/****** Object:  Table [dbo].[CalculDistanceHistorique]    Script Date: 28-10-20 19:00:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[CalculDistanceHistorique]

CREATE TABLE [dbo].[CalculDistanceHistorique](
	[ID] [int]   IDENTITY(1,1) NOT NULL,
	[Time] [datetime] NOT NULL,
	[OriginLat] [float] NOT NULL,
	[OriginLong] [float] NOT NULL,
	[DestinationLat] [float] NOT NULL,
	[DestinationLong] [float] NOT NULL,
	[OriginName] VARCHAR(max) NOT NULL,
	[DestinationName] VARCHAR(max) NOT NULL,
	[OriginType] VARCHAR(max) NOT NULL,
	[DestinationType] VARCHAR(max) NOT NULL,
	[CarCosumption] [float] NOT NULL
) ON [PRIMARY]
GO

DROP TABLE [dbo].[SearchHistorique]
CREATE TABLE [dbo].[SearchHistorique](
	[ID] [int]   IDENTITY(1,1) NOT NULL,
	[Time] [datetime] NOT NULL,
	[Querry] VARCHAR(max) NOT NULL,
) ON [PRIMARY]
GO

--INSERT INTO [dbo].[CalculDistanceHistorique]
--           ([Time]
--           ,[OriginLat]
--           ,[OriginLong]
--           ,[DestinationLat]
--           ,[DestinationLong])
--     VALUES
--('2020-10-10 00:00:00.000',	50.6831347,	3.3165778,	50.6039,	3.3711),
--('2020-10-10 00:00:00.000',	50.6831347,	3.3165778,	50.6039,	3.3711),
--('2020-10-10 00:00:00.000',	50.6831347,	3.3165778,	50.6039,	3.3711),
--('2020-10-10 00:00:00.000',	50.6831347,	3.3165778,	50.6039,	3.3711)

