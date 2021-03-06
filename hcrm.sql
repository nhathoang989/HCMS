USE [HCRM]
GO
/****** Object:  Table [dbo].[CRM_Provider]    Script Date: 08/08/2016 20:40:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRM_Provider](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](150) NULL,
	[Name] [nvarchar](250) NULL,
 CONSTRAINT [PK_CRM_Provider] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CRM_Products]    Script Date: 08/08/2016 20:40:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRM_Products](
	[ProductId] [bigint] NOT NULL,
	[Menus] [nvarchar](50) NULL,
	[Image] [nvarchar](250) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Views] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](250) NOT NULL,
	[Title] [nvarchar](4000) NULL,
	[Description] [nvarchar](max) NULL,
	[FullDetails] [nvarchar](max) NULL,
	[SEName] [nvarchar](4000) NULL,
	[SEOTitle] [nvarchar](4000) NULL,
	[SEODescription] [nvarchar](4000) NULL,
	[SEOKeywords] [nvarchar](4000) NULL,
	[Source] [nvarchar](max) NULL,
	[Position] [int] NULL,
	[CateId] [int] NULL,
	[DisplayOrder] [int] NULL,
	[IsVisible] [bit] NOT NULL,
	[Hot] [bit] NULL,
	[Type] [int] NOT NULL,
	[DealPrice] [float] NULL,
	[NormalPrice] [float] NULL,
	[SubImages] [nvarchar](max) NULL,
	[Tags] [nvarchar](max) NULL,
	[ViewPerDay] [int] NULL,
	[Code] [nchar](10) NULL,
	[Language] [nchar](10) NULL,
	[Infos] [ntext] NULL,
	[IsDraft] [bit] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CRM_Product_Details_Template]    Script Date: 08/08/2016 20:40:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRM_Product_Details_Template](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Template] [nvarchar](max) NOT NULL,
	[CateID] [int] NULL,
 CONSTRAINT [PK_CRM_Product_Details_Template] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CRM_Product_Details_Template] ON
INSERT [dbo].[CRM_Product_Details_Template] ([ID], [Name], [Template], [CateID]) VALUES (1, N't1', N'[{"name":"g1","order":1,"data":[{"o1":""}]},{"name":"g2","order":0,"data":[{"o1":""}]}]', NULL)
SET IDENTITY_INSERT [dbo].[CRM_Product_Details_Template] OFF
/****** Object:  Table [dbo].[CRM_Menu]    Script Date: 08/08/2016 20:40:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRM_Menu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Icon] [nvarchar](50) NULL,
	[Path] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[Level] [smallint] NOT NULL,
	[ParentID] [int] NULL,
 CONSTRAINT [PK_CRM_Menu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CRM_Menu] ON
INSERT [dbo].[CRM_Menu] ([ID], [Name], [Icon], [Path], [Type], [Level], [ParentID]) VALUES (1, N'Admin', NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[CRM_Menu] ([ID], [Name], [Icon], [Path], [Type], [Level], [ParentID]) VALUES (3, N'Nhập hàng', NULL, NULL, NULL, 1, 1)
INSERT [dbo].[CRM_Menu] ([ID], [Name], [Icon], [Path], [Type], [Level], [ParentID]) VALUES (4, N'test', NULL, NULL, NULL, 2, 3)
INSERT [dbo].[CRM_Menu] ([ID], [Name], [Icon], [Path], [Type], [Level], [ParentID]) VALUES (5, N'Manager', NULL, NULL, NULL, 0, NULL)
INSERT [dbo].[CRM_Menu] ([ID], [Name], [Icon], [Path], [Type], [Level], [ParentID]) VALUES (6, N'sub Manager', NULL, NULL, NULL, 1, 5)
SET IDENTITY_INSERT [dbo].[CRM_Menu] OFF
/****** Object:  Table [dbo].[CRM_Customer]    Script Date: 08/08/2016 20:40:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRM_Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](150) NULL,
	[Name] [nvarchar](250) NULL,
 CONSTRAINT [PK_CRM_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CRM_Receipt_Delivery]    Script Date: 08/08/2016 20:40:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRM_Receipt_Delivery](
	[ReceiptId] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[OrderName] [nvarchar](max) NULL,
	[OrderAddress] [nvarchar](max) NULL,
	[OrderPhone] [nvarchar](50) NULL,
	[ReceiveName] [nvarchar](max) NULL,
	[ReceiveAddress] [nvarchar](max) NULL,
	[ReceivePhone] [nvarchar](50) NULL,
	[Shipping] [float] NULL,
	[Price] [float] NULL,
	[Total] [float] NULL,
	[IsOrdered] [bit] NOT NULL,
	[IsPaid] [bit] NOT NULL,
	[IsDeliveried] [bit] NOT NULL,
	[IsReceived] [bit] NOT NULL,
	[Status] [nvarchar](250) NULL,
	[IsDeleted] [bit] NULL,
	[FormPayment] [nvarchar](250) NULL,
	[UserId] [bigint] NOT NULL,
	[CustomerId] [bigint] NOT NULL,
 CONSTRAINT [PK__CRM_Or__C3905BCF0DAF0CB0] PRIMARY KEY CLUSTERED 
(
	[ReceiptId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CRM_Receipt_Warehouse]    Script Date: 08/08/2016 20:40:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRM_Receipt_Warehouse](
	[ReceiptId] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[Price] [float] NULL,
	[Total] [float] NULL,
	[IsPaid] [bit] NOT NULL,
	[IsReceived] [bit] NOT NULL,
	[Status] [nvarchar](250) NULL,
	[IsDeleted] [bit] NULL,
	[FormPayment] [nvarchar](250) NULL,
	[UserId] [bigint] NOT NULL,
	[ProviderId] [bigint] NOT NULL,
 CONSTRAINT [PK__CRM_Receipt_Warehouse] PRIMARY KEY CLUSTERED 
(
	[ReceiptId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CRM_Receipt_Return]    Script Date: 08/08/2016 20:40:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRM_Receipt_Return](
	[ReceiptId] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[Price] [float] NULL,
	[Total] [float] NULL,
	[IsPaid] [bit] NOT NULL,
	[IsReceived] [bit] NOT NULL,
	[Status] [nvarchar](250) NULL,
	[IsDeleted] [bit] NULL,
	[FormPayment] [nvarchar](250) NULL,
	[UserId] [bigint] NOT NULL,
	[ProviderId] [bigint] NOT NULL,
	[DeliveryReceiptId] [bigint] NULL,
 CONSTRAINT [PK__CRM_Receipt_Return] PRIMARY KEY CLUSTERED 
(
	[ReceiptId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CRM_Tags]    Script Date: 08/08/2016 20:40:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRM_Tags](
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](250) NULL,
	[EditedBy] [nvarchar](250) NULL,
	[Content] [nvarchar](250) NOT NULL,
	[IsView] [bit] NULL,
	[SEOKeyWords] [nvarchar](250) NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[Content] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CRM_Role_Menu]    Script Date: 08/08/2016 20:40:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRM_Role_Menu](
	[Role] [nvarchar](50) NOT NULL,
	[MenuID] [int] NOT NULL,
 CONSTRAINT [PK_CRM_Role_Menu] PRIMARY KEY CLUSTERED 
(
	[Role] ASC,
	[MenuID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CRM_Role_Menu] ([Role], [MenuID]) VALUES (N'Admin', 1)
INSERT [dbo].[CRM_Role_Menu] ([Role], [MenuID]) VALUES (N'Admin', 3)
INSERT [dbo].[CRM_Role_Menu] ([Role], [MenuID]) VALUES (N'Admin', 4)
INSERT [dbo].[CRM_Role_Menu] ([Role], [MenuID]) VALUES (N'Admin', 5)
INSERT [dbo].[CRM_Role_Menu] ([Role], [MenuID]) VALUES (N'Admin', 6)
/****** Object:  Table [dbo].[CRM_Receipt_Details]    Script Date: 08/08/2016 20:40:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRM_Receipt_Details](
	[OrderDetailId] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderId] [bigint] NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [float] NOT NULL,
	[Album_producId] [int] NULL,
 CONSTRAINT [PK__CRM_Or__D3B9D36C0A9D95DB] PRIMARY KEY CLUSTERED 
(
	[OrderDetailId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CRM_Provider_Address]    Script Date: 08/08/2016 20:40:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRM_Provider_Address](
	[AddressID] [int] IDENTITY(1,1) NOT NULL,
	[City] [nvarchar](250) NULL,
	[State] [nvarchar](250) NULL,
	[Street] [nvarchar](250) NULL,
	[Zip] [nchar](10) NULL,
	[CustomerID] [int] NOT NULL,
 CONSTRAINT [PK_CRM_Provider_Address] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CRM_Customer_Address]    Script Date: 08/08/2016 20:40:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRM_Customer_Address](
	[AddressID] [int] IDENTITY(1,1) NOT NULL,
	[City] [nvarchar](250) NULL,
	[State] [nvarchar](250) NULL,
	[Street] [nvarchar](250) NULL,
	[Zip] [nchar](10) NULL,
	[CustomerID] [int] NOT NULL,
 CONSTRAINT [PK_CRM_Customer_Address] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_Products_IsDeleted]    Script Date: 08/08/2016 20:40:46 ******/
ALTER TABLE [dbo].[CRM_Products] ADD  CONSTRAINT [DF_Products_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_Products_IsVisible]    Script Date: 08/08/2016 20:40:46 ******/
ALTER TABLE [dbo].[CRM_Products] ADD  CONSTRAINT [DF_Products_IsVisible]  DEFAULT ((1)) FOR [IsVisible]
GO
/****** Object:  Default [DF_Products_Hot]    Script Date: 08/08/2016 20:40:46 ******/
ALTER TABLE [dbo].[CRM_Products] ADD  CONSTRAINT [DF_Products_Hot]  DEFAULT ((0)) FOR [Hot]
GO
/****** Object:  Default [DF_Products_loai]    Script Date: 08/08/2016 20:40:46 ******/
ALTER TABLE [dbo].[CRM_Products] ADD  CONSTRAINT [DF_Products_loai]  DEFAULT ((0)) FOR [Type]
GO
/****** Object:  Default [DF_Products_DealPrice]    Script Date: 08/08/2016 20:40:46 ******/
ALTER TABLE [dbo].[CRM_Products] ADD  CONSTRAINT [DF_Products_DealPrice]  DEFAULT ((0)) FOR [DealPrice]
GO
/****** Object:  Default [DF_Products_NormalPrice]    Script Date: 08/08/2016 20:40:46 ******/
ALTER TABLE [dbo].[CRM_Products] ADD  CONSTRAINT [DF_Products_NormalPrice]  DEFAULT ((0)) FOR [NormalPrice]
GO
/****** Object:  Default [DF_Products_Language]    Script Date: 08/08/2016 20:40:46 ******/
ALTER TABLE [dbo].[CRM_Products] ADD  CONSTRAINT [DF_Products_Language]  DEFAULT (N'vn') FOR [Language]
GO
/****** Object:  Default [DF_CRM_Products_IsDraft]    Script Date: 08/08/2016 20:40:46 ******/
ALTER TABLE [dbo].[CRM_Products] ADD  CONSTRAINT [DF_CRM_Products_IsDraft]  DEFAULT ((0)) FOR [IsDraft]
GO
/****** Object:  Default [DF_CRM_Receipt_IsOrdered]    Script Date: 08/08/2016 20:40:46 ******/
ALTER TABLE [dbo].[CRM_Receipt_Delivery] ADD  CONSTRAINT [DF_CRM_Receipt_IsOrdered]  DEFAULT ((0)) FOR [IsOrdered]
GO
/****** Object:  Default [DF_CRM_Receipt_UserId]    Script Date: 08/08/2016 20:40:46 ******/
ALTER TABLE [dbo].[CRM_Receipt_Delivery] ADD  CONSTRAINT [DF_CRM_Receipt_UserId]  DEFAULT ((0)) FOR [UserId]
GO
/****** Object:  ForeignKey [FK_CRM_Customer_Address_CRM_Customer]    Script Date: 08/08/2016 20:40:46 ******/
ALTER TABLE [dbo].[CRM_Customer_Address]  WITH CHECK ADD  CONSTRAINT [FK_CRM_Customer_Address_CRM_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[CRM_Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[CRM_Customer_Address] CHECK CONSTRAINT [FK_CRM_Customer_Address_CRM_Customer]
GO
/****** Object:  ForeignKey [FK_CRM_Provider_Address_CRM_Provider]    Script Date: 08/08/2016 20:40:46 ******/
ALTER TABLE [dbo].[CRM_Provider_Address]  WITH CHECK ADD  CONSTRAINT [FK_CRM_Provider_Address_CRM_Provider] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[CRM_Provider] ([CustomerID])
GO
ALTER TABLE [dbo].[CRM_Provider_Address] CHECK CONSTRAINT [FK_CRM_Provider_Address_CRM_Provider]
GO
/****** Object:  ForeignKey [FK_CRM_ReceiptDetails_CRM_Products]    Script Date: 08/08/2016 20:40:46 ******/
ALTER TABLE [dbo].[CRM_Receipt_Details]  WITH CHECK ADD  CONSTRAINT [FK_CRM_ReceiptDetails_CRM_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[CRM_Products] ([ProductId])
GO
ALTER TABLE [dbo].[CRM_Receipt_Details] CHECK CONSTRAINT [FK_CRM_ReceiptDetails_CRM_Products]
GO
/****** Object:  ForeignKey [FK_CRM_ReceiptDetails_CRM_Receipt]    Script Date: 08/08/2016 20:40:46 ******/
ALTER TABLE [dbo].[CRM_Receipt_Details]  WITH CHECK ADD  CONSTRAINT [FK_CRM_ReceiptDetails_CRM_Receipt] FOREIGN KEY([OrderId])
REFERENCES [dbo].[CRM_Receipt_Delivery] ([ReceiptId])
GO
ALTER TABLE [dbo].[CRM_Receipt_Details] CHECK CONSTRAINT [FK_CRM_ReceiptDetails_CRM_Receipt]
GO
/****** Object:  ForeignKey [FK_CRM_Role_Menu_CRM_Menu]    Script Date: 08/08/2016 20:40:46 ******/
ALTER TABLE [dbo].[CRM_Role_Menu]  WITH CHECK ADD  CONSTRAINT [FK_CRM_Role_Menu_CRM_Menu] FOREIGN KEY([MenuID])
REFERENCES [dbo].[CRM_Menu] ([ID])
GO
ALTER TABLE [dbo].[CRM_Role_Menu] CHECK CONSTRAINT [FK_CRM_Role_Menu_CRM_Menu]
GO
