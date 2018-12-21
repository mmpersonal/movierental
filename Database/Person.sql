USE [MovieRental]
GO

/****** Object:  Table [dbo].[Person]    Script Date: 12/20/2018 9:09:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Person](
	[PersonId] [INT] IDENTITY(1,1) NOT NULL,
	[FirstName] [NVARCHAR](50) NULL,
	[LasttName] [NVARCHAR](50) NULL,
	[RoleId] [INT] NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


