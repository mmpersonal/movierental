USE [MovieRental]
GO

/****** Object:  Table [dbo].[CustomerAddress]    Script Date: 12/20/2018 9:06:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [dbo].[CustomerAddress](
	[CustAddressId] [INT] IDENTITY(1,1) NOT NULL,
	[CustomerId] [INT] NOT NULL,
	[StreetAddress] [VARCHAR](100) NOT NULL,
	[StreetAddress2] [VARCHAR](100) NULL,
	[City] [VARCHAR](50) NULL,
	[StateCode] [CHAR](2) NULL,
	[ZipCode] [VARCHAR](10) NULL,
	[IsActive] [BIT] NOT NULL,
	[CreatedBy] [INT] NOT NULL,
	[CreatedOn] [DATETIME2](0) NOT NULL,
	[UpdatedBy] [INT] NOT NULL,
	[UpdatedOn] [DATETIME2](0) NOT NULL,
 CONSTRAINT [PK_dbo_CustomerAddress] PRIMARY KEY CLUSTERED 
(
	[CustAddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CustomerAddress] ADD  CONSTRAINT [DF_dbo_CustomerAddress_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[CustomerAddress] ADD  CONSTRAINT [DF_dbo_CustomerAddress_CreatedOn]  DEFAULT (GETDATE()) FOR [CreatedOn]
GO

ALTER TABLE [dbo].[CustomerAddress] ADD  CONSTRAINT [DF_dbo_CustomerAddress_UpdatedOn]  DEFAULT (GETDATE()) FOR [UpdatedOn]
GO

ALTER TABLE [dbo].[CustomerAddress]  WITH CHECK ADD  CONSTRAINT [FK_dbo_CustomerAddress_dbo_Customert] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO

ALTER TABLE [dbo].[CustomerAddress] CHECK CONSTRAINT [FK_dbo_CustomerAddress_dbo_Customert]
GO

ALTER TABLE [dbo].[CustomerAddress]  WITH CHECK ADD  CONSTRAINT [FK_dbo_CustomerAddress_StateCode] FOREIGN KEY([StateCode])
REFERENCES [dbo].[StateCode] ([StateCode])
GO

ALTER TABLE [dbo].[CustomerAddress] CHECK CONSTRAINT [FK_dbo_CustomerAddress_StateCode]
GO


