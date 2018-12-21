USE [MovieRental]
GO

/****** Object:  Table [dbo].[Movie]    Script Date: 12/20/2018 9:07:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Movie](
	[MovieId] [BIGINT] IDENTITY(1,1) NOT NULL,
	[LanguageId] [INT] NOT NULL,
	[CategoryId] [INT] NULL,
	[Title] [NVARCHAR](50) NULL,
	[Description] [NVARCHAR](50) NULL,
	[ReleaseYear] [SMALLINT] NULL,
	[rental_duaration] [SMALLINT] NULL,
	[rental_rate] [NUMERIC](18, 0) NULL,
	[Length] [SMALLINT] NULL,
	[RatingId] [INT] NULL,
	[Summary] [NVARCHAR](255) NULL,
	[CreatedBy] [INT] NULL,
	[CreatedOn] [DATETIME] NOT NULL,
	[UpdatedBy] [INT] NULL,
	[UpdatedOn] [DATETIME] NOT NULL,
 CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Movie] ADD  CONSTRAINT [DF_Movie_CreatedOn]  DEFAULT (GETDATE()) FOR [CreatedOn]
GO

ALTER TABLE [dbo].[Movie] ADD  CONSTRAINT [DF_Movie_UpdatedOn]  DEFAULT (GETDATE()) FOR [UpdatedOn]
GO


