USE [MovieRental]
GO

/****** Object:  Table [dbo].[StateCode]    Script Date: 12/20/2018 9:10:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [dbo].[StateCode](
	[StateCode] [CHAR](2) NOT NULL,
	[StateName] [VARCHAR](50) NOT NULL,
	[TimeZone] [CHAR](5) NOT NULL,
	[CreatedBy] [INT] NOT NULL,
	[CreatedOn] [DATETIME2](0) NOT NULL,
	[UpdatedBy] [INT] NOT NULL,
	[UpdatedOn] [DATETIME2](0) NOT NULL,
 CONSTRAINT [PK_lut_StateCode] PRIMARY KEY CLUSTERED 
(
	[StateCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[StateCode] ADD  CONSTRAINT [DF_lut_StateCode_CreatedOn]  DEFAULT (GETDATE()) FOR [CreatedOn]
GO

ALTER TABLE [dbo].[StateCode] ADD  CONSTRAINT [DF_lut_StateCode_UpdatedOn]  DEFAULT (GETDATE()) FOR [UpdatedOn]
GO


