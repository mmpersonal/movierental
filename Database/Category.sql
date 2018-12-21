USE [MovieRental]
GO

/****** Object:  Table [dbo].[Category]    Script Date: 12/20/2018 9:05:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Category](
	[CategoryId] [INT] IDENTITY(1,1) NOT NULL,
	[CategoryName] [NVARCHAR](50) NULL,
	[Description] [NVARCHAR](100) NULL,
	[ShortDesc] [NVARCHAR](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


