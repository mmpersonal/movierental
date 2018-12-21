USE [MovieRental]
GO

/****** Object:  Table [dbo].[PaymentType]    Script Date: 12/20/2018 9:09:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PaymentType](
	[PaymentTypeId] [INT] IDENTITY(1,1) NOT NULL,
	[Name] [NVARCHAR](50) NULL,
	[Description] [NVARCHAR](100) NULL,
 CONSTRAINT [PK_PaymentType] PRIMARY KEY CLUSTERED 
(
	[PaymentTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


