USE [MovieRental]
GO

/****** Object:  Table [dbo].[Inventory]    Script Date: 12/20/2018 9:06:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Inventory](
	[InventoryId] [INT] IDENTITY(1,1) NOT NULL,
	[MovieId] [INT] NULL,
	[Isavailable] [BIT] NULL,
	[CreatedBy] [INT] NULL,
	[CreatedOn] [DATETIME] NOT NULL,
	[UpdatedBy] [INT] NULL,
	[UpdatedOn] [DATETIME] NOT NULL,
 CONSTRAINT [PK_inventory] PRIMARY KEY CLUSTERED 
(
	[InventoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Inventory] ADD  CONSTRAINT [df_isavilable_constraint]  DEFAULT ((1)) FOR [Isavailable]
GO


