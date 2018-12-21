USE [MovieRental]
GO

/****** Object:  Table [dbo].[Rental]    Script Date: 12/20/2018 9:10:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Rental](
	[RentalId] [INT] IDENTITY(1,1) NOT NULL,
	[InventoryId] [INT] NOT NULL,
	[CustomerId] [INT] NOT NULL,
	[Amount] [INT] NOT NULL,
	[PaymentTypeId] [INT] NOT NULL,
	[RentedOn] [DATETIME] NULL,
	[RentalValidUntil] [DATETIME] NOT NULL,
	[CreatedOn] [DATETIME] NOT NULL,
 CONSTRAINT [PK_rental] PRIMARY KEY CLUSTERED 
(
	[RentalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Rental] ADD  DEFAULT (GETDATE()) FOR [RentedOn]
GO

ALTER TABLE [dbo].[Rental] ADD  DEFAULT (GETDATE()) FOR [CreatedOn]
GO


