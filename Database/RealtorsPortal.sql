USE [RealtorsPortalSystem]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 01/09/2020 7:40:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[AdminAcount] [varchar](30) NOT NULL,
	[AdminPass] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[AdminAcount] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Advertisement]    Script Date: 01/09/2020 7:40:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Advertisement](
	[AdvId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[SeLLId] [int] NULL,
	[ModeId] [int] NULL,
	[CateId] [int] NULL,
	[Header] [varchar](300) NOT NULL,
	[Content] [varchar](3000) NOT NULL,
	[Price] [float] NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[Street] [varchar](50) NULL,
	[District] [varchar](50) NULL,
	[Ward] [varchar](50) NULL,
	[CityProvince] [varchar](50) NULL,
	[Area] [float] NOT NULL,
	[Photothumbnail] [varchar](300) NOT NULL,
	[DateUp] [date] NULL,
	[ExpDate] [date] NULL,
	[AgentId] [int] NULL,
	[AgentAcount] [varchar](20) NULL,
	[SellAcount] [varchar](20) NULL,
	[Approved] [bit] NOT NULL,
	[Paid] [bit] NOT NULL,
	[Bedroom] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AdvId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Agent]    Script Date: 01/09/2020 7:40:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agent](
	[AgentId] [int] IDENTITY(1,1) NOT NULL,
	[AgentAcount] [varchar](20) NOT NULL,
	[AgentName] [varchar](30) NULL,
	[AgentPassword] [varchar](20) NOT NULL,
	[AgentAddress] [varchar](100) NULL,
	[AgentPhone] [varchar](20) NULL,
	[AgentEmail] [varchar](30) NULL,
	[TaxCode] [varchar](30) NULL,
	[AgentAvatar] [varchar](200) NULL,
	[AgentActive] [bit] NULL,
 CONSTRAINT [PK__Agent__9AC3BFF113BB8DDB] PRIMARY KEY CLUSTERED 
(
	[AgentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bank]    Script Date: 01/09/2020 7:40:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bank](
	[BankId] [int] IDENTITY(1,1) NOT NULL,
	[BankName] [varchar](30) NULL,
	[BankRate] [float] NULL,
 CONSTRAINT [PK_Bank] PRIMARY KEY CLUSTERED 
(
	[BankId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 01/09/2020 7:40:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CateId] [int] IDENTITY(1,1) NOT NULL,
	[CateName] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[CateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 01/09/2020 7:40:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[CityId] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[District]    Script Date: 01/09/2020 7:40:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[District](
	[DistrictId] [int] IDENTITY(1,1) NOT NULL,
	[CityId] [int] NULL,
	[DistrictName] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[DistrictId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FeautureAdv]    Script Date: 01/09/2020 7:40:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeautureAdv](
	[FeaAdvId] [int] NOT NULL,
	[Content] [varchar](50) NULL,
	[Header] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[FeaAdvId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedbacks]    Script Date: 01/09/2020 7:40:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedbacks](
	[FeedbackId] [int] IDENTITY(1,1) NOT NULL,
	[ModeId] [int] NULL,
	[AgentId] [int] NULL,
	[SeLLId] [int] NULL,
	[FeedbackContent] [varchar](1000) NULL,
	[FeedbackReply] [varchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[FeedbackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LastedNews]    Script Date: 01/09/2020 7:40:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LastedNews](
	[NewsId] [int] IDENTITY(1,1) NOT NULL,
	[AdvId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[NewsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mode]    Script Date: 01/09/2020 7:40:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mode](
	[ModeId] [int] IDENTITY(1,1) NOT NULL,
	[ModeName] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ModeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhotoDetail]    Script Date: 01/09/2020 7:40:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhotoDetail](
	[IdImage] [int] IDENTITY(1,1) NOT NULL,
	[AdvId] [int] NULL,
	[Image] [varchar](200) NULL,
	[Guidimage] [uniqueidentifier] NULL,
	[Extension] [varchar](20) NULL,
 CONSTRAINT [PK_PhotoDetail] PRIMARY KEY CLUSTERED 
(
	[IdImage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PrivateSeller]    Script Date: 01/09/2020 7:40:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrivateSeller](
	[SeLLId] [int] IDENTITY(1,1) NOT NULL,
	[SeLLAcount] [varchar](20) NOT NULL,
	[SellPassword] [varchar](20) NOT NULL,
	[SellFullname] [varchar](50) NULL,
	[SellGender] [bit] NULL,
	[SellDob] [date] NULL,
	[SellAddress] [varchar](100) NULL,
	[SellPhone] [varchar](20) NULL,
	[SellEmail] [varchar](30) NULL,
	[SellActive] [bit] NULL,
 CONSTRAINT [PK__PrivateS__1AF0891CA36CE450] PRIMARY KEY CLUSTERED 
(
	[SeLLId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Street]    Script Date: 01/09/2020 7:40:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Street](
	[StreetId] [int] IDENTITY(1,1) NOT NULL,
	[CityId] [int] NULL,
	[DistrictId] [int] NULL,
	[WardId] [int] NULL,
	[StreetName] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[StreetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 01/09/2020 7:40:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAdvDetails]    Script Date: 01/09/2020 7:40:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAdvDetails](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[AdvId] [int] NULL,
	[AdvTitle] [varchar](300) NULL,
	[UserId] [int] NULL,
	[SeLLId] [int] NULL,
	[SeLLAccount] [varchar](20) NULL,
	[AgentId] [int] NULL,
	[AgentAccount] [varchar](20) NULL,
	[SubTotal] [float] NULL,
	[DateUp] [date] NULL,
	[ExpDate] [date] NULL,
	[Onemonth] [float] NOT NULL,
	[Threemonths] [float] NOT NULL,
	[Sixmonths] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ward]    Script Date: 01/09/2020 7:40:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ward](
	[WardId] [int] IDENTITY(1,1) NOT NULL,
	[CityId] [int] NULL,
	[DistrictId] [int] NULL,
	[WardName] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[WardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Admin] ([AdminAcount], [AdminPass]) VALUES (N'admin', N'123')
INSERT [dbo].[Admin] ([AdminAcount], [AdminPass]) VALUES (N'admin1', N'123')
SET IDENTITY_INSERT [dbo].[Advertisement] ON 

INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (105, 2, NULL, 1, 1, N'House for sale  55m2x 4 floors, suitable for office, wide entrance,first floor is a garage .', N'The first floor is a garage for 2 cars and a dining room.
2nd and 3rd floor each floor has 2 large bedrooms, all rooms have open windows.
The fourth floor is the basilica hall.', 150000, N'356 ba chieu', N'Ba Trieu', N'Hoan Kiem', N'Chuong Duong', N'Ha Noi', 55, N'/Lmages/2e2365b8-57e5-4748-8726-eee485ed6088.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-03-08' AS Date), 5, N'nguyenson', NULL, 1, 1, 3)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (106, 2, NULL, 2, 5, N'My Hoang Duplex Villa for sale Duong so 1,An Khanh,District 2,Ho Chi Minh', N'My Hoang Duplex Villa for sale 
-Area :10.5m x20m
-Having 2 floors', 400, N'45 Duong so 1 An Khanh District 2 Ho chi Minh', N'Duong so 1', N'District 2', N'An Khanh', N'Ho Chi Minh', 100, N'/Lmages/3230c584-e290-4091-87ef-27ab453256ab.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-05-07' AS Date), 6, N'quynhhuong', NULL, 1, 1, 5)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (107, 2, NULL, 1, 4, N'Duplex & Penthouse District 2, amazing views, pink book for foreigner buyer', N'Since its first debut, Gateway Thao Dien become the most sought after address in District 2 by affulent local and expatriates with its exceptional location and attention to many details. Developer carefully selected specific brands and services to complete a living experience tailored to the lifestyle of its residents.

Penthouse at Gateway Thao Dien is located on the top floor of the most iconic residential project in the city. Only for limited selections of rare and bespoke penthouses with rooftop pools and spectacular view on over the city skyline and Saigon river. Each penthouse is unique in design and detail to create a exclusive and extraordinary home for those seeking the pinnacle of living experience.', 500000, N'34 Hoang The Thien', N'Hoang The Thien', N'District 2', N'An Phu', N'Ho Chi Minh', 300, N'/Lmages/8012b1d0-791a-4193-a6cb-75a8b1b1812e.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), 5, N'nguyenson', NULL, 1, 1, 4)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (108, 2, NULL, 1, 4, N'BUDGETED SERVICED APARTMENT FOR RENT AT THE JUNCTURE OF TAY HO AND CAU GIAY DISTRICT', N'27/7 Security, Free spacious garage, safe and calm area with lots of ex-pats around.
Reasonable Rental from 5 million/month
Detailed information: http://lotushouse.vn/
Hotline: 0934 68 9977
Lotus House is located at the juncture of the city''s major district of Tay Ho and Cau Giay.
15 minutes by motorbike or car into the city center
7-10 minutes to the office building area', 300, N'378 Nguyen Thi Minh Khai', N'Nguyen Thi Minh Khai', N'District 1', N'Ben Nghe', N'Ho Chi Minh', 30, N'/Lmages/e43e9c30-3de2-4079-a955-03458e63c976.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), 5, N'nguyenson', NULL, 1, 1, 3)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (109, 2, NULL, 3, 1, N'NEED TO RENT A BUILDING 322/158 NHAN MY, MY DINH 1 -SUITABLE FOR OFFICE OR HOUSING', N'The Building For Hire.
The building is 120 meters squared site,
Full air conditioner from 12-18-24btu for each space,
All the spaces were designed for compliance principles for natural. You don''t need a fan as the house has full air conditioner and lighting systems at each space for a comfortable feeling.
Each space was design separate to another one.', 300, N'12/3 Hang Ngang', N'Hang Ngang', N'Dong Da', N'Hang Bot', N'Ha Noi', 60, N'/Lmages/35f00ae6-1cfa-4337-a9bc-a2b23c7c9973.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-07-06' AS Date), 6, N'quynhhuong', NULL, 1, 1, 2)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (110, 2, NULL, 1, 4, N'Serenity Sky Villas in centre of HCMC - It could be the most luxurious one in the next 3 years!', N'Serenity Sky Villas offers a lifestyle never before experienced in Saigon. Located at one of the citys most exquisite addresses,45 exclusive residences enjoy the upmost privacy and luxury in the centre of the city. Double-height ceiling and private swimming pools offer stunning views, culminating in an unsurpassed feeling of light and space. Welcome to Serenity Sky Villas, where Saigons most privileged residents reside.', 400000, N'345 Dong Khoi', N'Dong Khoi', N'District 1', N'Ben Nghe', N'Ho Chi Minh', 56, N'/Lmages/63f268f0-b068-4fcc-a8ac-bac3b10d6d61.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), 7, N'ngockinh', NULL, 1, 1, 3)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (111, 2, NULL, 1, 5, N'Villa at Saigon Pearl for rent, 1 ground floor, corner,villa area close to Saigon river, fresh air', N'Villa for rent in Saigon Pearl, corner apartment, front of D7 street, villa area close to Saigon river, fresh air, area 10x20m
Internal facilities and a radius of 500 m around the villa area are full of amenities such as supermarkets, commercial centres, hospitals; schools at all levels, kindergartens in the area; green parks, swimming pools,
riverside jogging tracks', 3000, N'478 Le Hien Mai', N'Le Hien Mai', N'District 2', N'An Phu', N'Ho Chi Minh', 200, N'/Lmages/5e66283a-49e6-4311-8a11-926a586870a7.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-04-07' AS Date), 7, N'ngockinh', NULL, 1, 1, 5)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (112, 2, NULL, 3, 2, N'Leasing townhouse with 2 frontages, 1 ground floor, 2 floors, near crossroads; suitable for office', N'+ townhouse with 2 frontages, 1 ground floor, 2 floors, near crossroads; convenient traffic and parking
+ Crowded residential area, surrounded by many offices, schools, apartments, mini supermarkets, cafes ...
+ Convenient for trading in cafes, mini supermarkets, transaction offices, shops, cafes ...', 2000, N'76 Hang Mam', N'Hang Mam', N'Dong Da', N'Cat Linh', N'Ha Noi', 200, N'/Lmages/3ca465e3-0118-4f46-aedd-72a9fbec91da.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-05-07' AS Date), 9, N'nhatnam', NULL, 1, 1, 4)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (113, 2, NULL, 3, 2, N'Renting office with resident for company and co-working space', N'The complex is designed as apartments for rent or use as Officetel to companies for office and resident experts. Built in 2017, the floor area is 1600 m2 consists of 15 apartments, 2 rooms for co-working, 01 garages for motorcycles and automobiles, area of 120 m2 with garden and trees covered entrance.
The building complex is designed with 4 floors, surrounding corridors, floors 4 and 5 with a terrace and an outdoor pool.', 4000, N'34 phan chau trinh', N'Phan Chau Trinh', N'Hai Chau', N'Thanh Binh', N'Da Nang', 600, N'/Lmages/249ab5f6-46ca-4ab8-a544-6e7658ba0c59.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-04-07' AS Date), 9, N'nhatnam', NULL, 1, 1, 4)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (114, 2, NULL, 4, 1, N'Beautiful 3 bedrooms house for lease in Old Quarter - Hoan Kiem dist, Hanoi', N'Modern 4-storey house for rent on Phan Dinh Phung street with 50 sqm x 4 storeys.
The house has 3 bedrooms and 4 modern bathroom. Bedrooms are equipped with wooden floors, high-class cabinets, big windows. The first floor is the living room and fully equipped kitchen.', 1200, N'456 Bach Dang', N'Bach Dang', N'Hoan Kiem', N'Chuong Duong', N'Ha Noi', 120, N'/Lmages/6162b7bc-8708-4721-b5c1-235f7ad2051b.jpg', CAST(N'2019-12-07' AS Date), CAST(N'2020-01-05' AS Date), 8, N'vanchi', NULL, 1, 0, 4)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (115, 2, NULL, 2, 1, N'Need to buy houses under 30m2, under 200.000$ in District 2 Ho Chi Minh city', N'Need to buy houses under 30m2, under 200.000$ in District 2 Ho Chi Minh city', 200000, N'duong so 2', N'Duong so 2', N'District 2', N'An Khanh', N'Ho Chi Minh', 30, N'/Lmages/ff9182c3-230f-4b63-8713-f64ecbff3a36.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), 8, N'vanchi', NULL, 1, 1, 2)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (116, 2, NULL, 4, 1, N'Nice house with The Lake-view, and a garage with 4 bedrooms next to Cong Vien Thong Nhat for lease', N'The house has a total area of ??50m2 x 4 floors. With each floor, it divided into 2 rooms, the bathroom is in the middle. Bedroom outside is wide, with airy balcony, lake view. First floor is  a kitchen, a dining room and reception place. The rooms are bright, with wooden floors, high-class wooden door system, fully equipped with wardrobes, air conditioning, and so on.
Rental Price: US$1,300/month', 1300, N'34 hang Manh', N'Hang Manh', N'Dong Da', N'Cat Linh', N'Ha Noi', 200, N'/Lmages/a7f9106d-7c6f-49c5-9547-d01a0e65f175.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-04-07' AS Date), 8, N'vanchi', NULL, 1, 1, 4)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (117, 2, NULL, 3, 2, N'Office for rent Mê Linh Square, Ho Chi Minh City', N'This space, located on the 21st floor of a building in the heart of Ho Chi Minh City, offers fantastic office solutions on flexible terms. Choose from serviced offices and co-working spaces, plus accessible meeting rooms with videoconferencing availability and virtual office solutions. ', 650000, N'56 Dong Khoi', N'Dong Khoi', N'District 1', N'Ben Nghe', N'Ho Chi Minh', 200, N'/Lmages/aa266383-7122-4de0-89a6-b01fe0a7fc59.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), 8, N'vanchi', NULL, 1, 1, 1)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (118, 1, 7, 1, 1, N'Studio apartment for rent at Vinhomes Central Park, 1 bedroom, 3,2 billion vnd (160$) (all fees)', N'The studio apartment is located on the 1st floor, fully furnished, convenient for travel. The selling price is 3.2 billion including transfer taxes and certificate fee.', 160, N'Cong xa Paris', N'Cong Xa Paris', N'District 1', N'Ben Thanh', N'Ho Chi Minh', 50, N'/Lmages/58b07882-bab1-4b7f-941d-f4838b610c30.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), NULL, NULL, N'nguyenson1', 1, 1, 2)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (119, 1, 7, 1, 4, N'2 bedroom apartment for sale at Gateway Thao Dien, next to MRT station, HCMC', N'Apartment (condominium) for sale at Gateway Thao Dien:

* 2 bedrooms, 90 sqm, nice city view.

* Location: Ha Noi highway, Thao Dien ward, district 2, HCMC

* Fully furnished with high quality

* Facility within: professional management, gym, swimming pool, kid''s pool, sauna, steambath, outdoor & indoor children''s playgrounds, kindergarten BBQ area, F&B courtyard, wine-cellar...', 150000, N'Cao Thang', N'Cao Thang', N'District 3', N'Ward 1', N'Ho Chi Minh', 45, N'/Lmages/d09fd641-771d-40bc-a0bf-535443a5028f.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), NULL, NULL, N'nguyenson1', 1, 1, 2)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (120, 1, 7, 1, 1, N'Nice apartment for sale at Sky Garden 3, 72m2, 2BRs+2WCs, only 3 billion - Call: 0906.647.689', N'Design: 2 beds & 2wc
Area: 72m2
The apartment is suitable for a couple to live in.
Price:(130.000USD)

Furniture: fully furnished', 130000, N'Hoa Hiep Bac', N'Hoa Hiep Bac', N'Lien Chieu', N'Hoa Minh', N'Da Nang', 72, N'/Lmages/77f934e3-1ff2-4055-9622-59184dc512c3.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), NULL, NULL, N'nguyenson1', 1, 1, 2)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (121, 1, 8, 1, 4, N'Property of Vietnam housing no longer difficulty with Vinhomes Ocean Park, bath the sea under home', N'Vinhomes Ocean Park is officially opened for sales to foreigners.

Vinhomes Ocean Park - To the World

To implement the coming-up campaign chain for the foreigners with the followed events of the follows:

Event 1: EVENTS organizing events for sale to foreigners
- Expected location in Coral Area. If the weather is bad, organize on the floor and have a shuttle to the event.
- Audience: Foreigners and partners are Real Estate Brokers of Korea, Hong Kong ... Attending.
Foreigner: LEGAL AS FOLLO', 120000, N'Hang Muoi', N'Hang Muoi', N'Dong Da', N'Hang Bot', N'Ha Noi', 55, N'/Lmages/1a73330e-5fe6-4f5e-9dc9-9006b9d82df7.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), NULL, NULL, N'quynhhuong1', 1, 1, 2)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (122, 1, 8, 3, 5, N'Phu My - Van Phat Hung Villa For Rent, Price 2000$-2200$/Month', N'HU MY - VAN PHAT HUNG VILLA FOR RENT
- Land area: 10mx25m; Usable area: 440 sqm (15mx8m)
- Rental : from 2000$ to 2200$/ Month equivalent to VND46,520,000/Month
- The villa has 3 floors, a terrace, and a rooftop.
- Has a garage for parking, 3 large bedrooms, a small bedroom, a living room, a kitchen, 4 bathrooms.', 2000, N'quan 2,Ho Chi Minh', N'Duong so 1', N'District 2', N'An Khanh', N'Ho Chi Minh', 440, N'/Lmages/02f871ad-3e26-4cfc-b520-e3b01fca1270.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), NULL, NULL, N'quynhhuong1', 1, 1, 4)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (123, 1, 9, 1, 4, N'Need to sale apartment Pearl Plaza, Binh Thanh', N'Need to buy apartment Pearl Plaza, Binh Thanh', 300000, N'Le Quan Dinh', N'Le Quang Dinh', N'Binh Thanh', N'Ward 1', N'Ho Chi Minh', 45, N'/Lmages/28f475a8-f0e1-4b15-b04f-62875da0e107.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), NULL, NULL, N'ngockinh1', 1, 1, 2)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (124, 1, 9, 3, 4, N'Rent an apartment with 5 bedrooms, large garden or pool', N'Rent an apartment with 5 bedrooms, large garden or pool', 40, N'Hang ma ,Ha noi', N'Hang Ma', N'Hoan Kiem', N'Cua Dong', N'Ha Noi', 78, N'/Lmages/12d7b52a-43fa-481f-b25f-b3b0d2c82b7d.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), NULL, NULL, N'ngockinh1', 1, 1, 4)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (125, 1, 9, 4, 2, N'CASH OFFICE D1, D2, BINH THANH. NEW, LUXURY, WITH A ROUND + GIVING FULL INTERIOR, GOOD PRICE', N'CASH OFFICE D1, D2, BINH THANH. NEW, LUXURY, WITH A ROUND + GIVING FULL INTERIOR, GOOD PRICE', 300, N'Phan Van Tri', N'Phan Van Tri', N'Binh Thanh', N'Ward 2', N'Ho Chi Minh', 50, N'/Lmages/86246465-9b03-4034-a0eb-41d876ab01b2.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), NULL, NULL, N'ngockinh1', 1, 1, 3)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (134, 1, 9, 2, 1, N'Buy a private home with a home. Cars can be near the main road. DT 30 - 50m2 ....', N'Buy a private home with a home. Cars can be near the main road. DT 30 - 50m2 ....', 1000, N'Duong so 1 An Khanh Quan 2', N'Duong so 1', N'District 2', N'An Khanh', N'Ho Chi Minh', 50, N'/Lmages/1d424963-abf6-4d6c-a209-6b890dc6719d.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), NULL, NULL, N'ngockinh1', 1, 1, 3)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (135, 1, 7, 1, 1, N'I need to sale a house in Cau Giay, Dong Da, Ba Dinh, Tay Ho, South - North Tu Liem, 30 - 300m2 ground', N'I need to buy a house in Cau Giay, Dong Da, Ba Dinh, Tay Ho, South - North Tu Liem, 30 - 300m2 ground', 160000, N'Hang Manh', N'Hang Mam', N'Dong Da', N'Cat Linh', N'Ha Noi', 300, N'/Lmages/feb64ebd-5f44-4777-bf09-6ad6783e8602.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-04-07' AS Date), NULL, NULL, N'nguyenson1', 1, 1, 3)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (136, 1, 7, 3, 4, N'Need to rent an apartment 2 or 3 bedrooms', N'Need to rent an apartment 2 or 3 bedrooms', 600, N'Ong Ich Khiem', N'Ong Ich Khiem', N'Hai Chau', N'Thach Thang', N'Da Nang', 45, N'/Lmages/9cdb357c-497c-46a5-9f8c-8978b9f56480.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-04-07' AS Date), NULL, NULL, N'nguyenson1', 1, 1, 2)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (137, 1, 11, 3, 4, N'Need to rent a fully furnished apartment, 1 bedroom', N'Need to rent a fully furnished apartment, 1 bedroom', 200, N'Lieu Giai Ha Noi', N'Lieu Giai', N'Ba Dinh', N'Thanh Tan', N'Ha Noi', 30, N'/Lmages/11465e03-2a99-4abc-86e8-6b56f4646da2.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-04-07' AS Date), NULL, NULL, N'nhatnam1', 1, 1, 2)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (138, 1, 11, 4, 1, N'FOR LEASE IN  VINH PHUC WARD, BA DINH, HANOI', N'253/5000
Area of 40m2 x 4 floors including: 5 bedrooms, 3 bathrooms, 1 kitchen, 1 living room. Convenient transportation: Via Doi Can, Hoang Hoa Tham, HQV, De Buoi easily; near 354 Army Hospital; many kindergartens, elementary schools, 2 and 3; near the bustling 7.2 ha market of Vinh Phuc', 700, N'Hung Phat BInh Phuc Ba Dinh Ha Noi', N'Hung Phat', N'Ba Dinh', N'Binh Phuc', N'Ha Noi', 80, N'/Lmages/375d95d0-518a-44dc-9b1f-83926103f84d.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), NULL, NULL, N'nhatnam1', 1, 1, 2)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (139, 1, 7, 2, 1, N'Need to buy a downtown townhouse in District 2, near Saigon Bridge, 6 billion', N'Need to buy a downtown townhouse in District 2, near Saigon Bridge, 6 billion', 300000, N'Le Hien Mai An Phu District 2', N'Le Hien Mai', N'District 2', N'An Phu', N'Ho Chi Minh', 50, N'/Lmages/406190ea-8ae3-426a-bd19-4b0a730c618d.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), NULL, NULL, N'nguyenson1', 1, 1, 2)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (140, 1, 8, 2, 4, N'Need to buy a house in Hoan Kiem', N'Need to buy a house in Hoan Kiem,: Area of 50m2 or more, roads with cars to go. Houses related to the West (Southwest, North or Main West).', 800000, N'Hoan Kiem', N'Ba Trieu', N'Hoan Kiem', N'Chuong Duong', N'Ha Noi', 50, N'/Lmages/ae3eaa98-2bf3-4063-bffd-003554f48ede.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), NULL, NULL, N'quynhhuong1', 1, 1, 3)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (141, 1, 8, 2, 1, N'Need to buy a house near the center of District Phu Nhuan, about VND 6 billion', N'Need to buy a house near the center of District 2, about VND 6 billion', 300000, N'Co Giang Phu Nhuan', N'Co Giang', N'Phu Nhuan', N'Ward 1', N'Ho Chi Minh', 45, N'/Lmages/94fa2634-ccb3-44a0-af58-788ed98cd2c8.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), NULL, NULL, N'quynhhuong1', 1, 1, 2)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (142, 1, 8, 2, 1, N'Need to buy a private house to live and business', N'Need to buy a private house to live and business.
A wide alley where cars can pass through, it can be operated.', 400000, N'Phan Van Tri Go Vap', N'Phan Van Tri', N'Go Vap', N'Ward 1', N'Ho Chi Minh', 55, N'/Lmages/4dd334c7-0628-4a26-912e-57fb7d255302.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), NULL, NULL, N'quynhhuong1', 1, 1, 3)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (143, 1, 9, 2, 1, N'Need to buy a private house in Chua Boc, Khuong Thuong, Dong Da', N'I need to buy a private house in Chua Boc, Khuong Thuong, Truong Chinh.
Area: 35 - 45m2, 3-4 floors, built from 3-5 years here, directions: West, Northwest, Southwest.
Governmental red book.', 400000, N'Dong Da Ha Noi', N'Hang Ngang', N'Dong Da', N'Hang Bot', N'Ha Noi', 45, N'/Lmages/fa3e82d1-cc0b-4d08-90ad-3875dc783ae9.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), NULL, NULL, N'ngockinh1', 1, 1, 2)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (144, 2, NULL, 4, 1, N'Lease A SERVICE TRADING HOUSE IN PHU NHUAN', N'The house consists of 9 apartments 9 wc. - 2 large 40m2 apartments 1 PN separate. - 1 unit of 30m2. - 5 units of 18m2. - 1 apartment 15m2. The house has kitchen shelves, hot and cold machines, electricity and water meters, and there are basements for 22 cars.', 1900, N'Da Nang', N'Hoa Khanh Trung', N'Lien Chieu', N'Hoa Khanh Nam', N'Da Nang', 40, N'/Lmages/e62b6391-242e-4b31-a0d5-41d2d5e2f688.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-04-07' AS Date), 6, N'quynhhuong', NULL, 1, 1, 3)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (145, 2, NULL, 4, 1, N'Lease A FULL GARDEN GARDEN, PRICE 68 MILLION vnd / MONTH', N'Lease A FULL GARDEN GARDEN, PRICE 68 MILLION vnd / MONTH', 100, N'Lien Chieu Da Nang', N'Hoa Hiep', N'Lien Chieu', N'Hoa Minh', N'Da Nang', 60, N'/Lmages/ae0d3873-9249-4fa2-8b11-fffc759b0536.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), 8, N'vanchi', NULL, 1, 1, 3)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (146, 2, NULL, 4, 1, N'HOUSE FOR Lease Entire house 129 / 2D NGUYEN THAI SON, GO VAP', N'HOUSE FOR RENT Entire house 129 / 2D NGUYEN THAI SON, GO VAP', 1000, N'Nguyen Thai Son Go Vap', N'Nguyen Thai Son', N'Go Vap', N'Ward 2', N'Ho Chi Minh', 60, N'/Lmages/314932c7-7791-4ac5-a6d4-4ef9a44cd948.jpg', CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), 9, N'nhatnam', NULL, 1, 1, 2)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (147, 2, NULL, 2, 1, N'Need to buy a house close to Ben Nghe Ward, District 1', N'Need to buy a house close to Ben Nghe Ward, District 1', 150000, N'District 1', N'Nguyen Thi Minh Khai', N'District 1', N'Ben Nghe', N'Ho Chi Minh', 35, N'/Lmages/859f7db1-6f81-494b-b0f9-0bac95dd8c87.jpg', NULL, NULL, 8, N'vanchi', NULL, 0, 0, 2)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (148, 2, NULL, 2, 1, N'Need to buy Penthouse City Garden apartment for rent is new, modern, very special and absolutely beautiful. It has 4 bedrooms, 3 bathrooms and a large open plan living/ dining roo', N'Need to buy Penthouse City Garden apartment for rent is new, modern, very special and absolutely beautiful. It has 4 bedrooms, 3 bathrooms and a large open plan living/ dining roo', 400000, N'Da Nang', N'Hoa Hiep', N'Lien Chieu', N'Hoa Minh', N'Da Nang', 50, N'/Lmages/4464c87b-4c1f-4c3a-bf2c-4e719e730cf7.jpg', CAST(N'2020-01-09' AS Date), CAST(N'2020-02-08' AS Date), 5, N'nguyenson', NULL, 1, 1, 3)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (149, 2, NULL, 2, 4, N'Need to buy apartment Pearl Plaza, Binh Thanh', N'144/5000

Need to buy Pearl Plaza apartment with 2 bedrooms, number 1 or 6.MN, please let me know. If you need it quickly, if the price is good, it will be quickly transferred before Tet.', 350000, N'No Trang Long Binh Thanh', N'No Trang Long', N'Binh Thanh', N'Ward 1', N'Ho Chi Minh', 45, N'/Lmages/52897485-0d0b-4640-b600-1d8e1e3542b2.jpg', CAST(N'2020-01-09' AS Date), CAST(N'2020-02-08' AS Date), 5, N'nguyenson', NULL, 1, 1, 2)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (150, 1, 7, 4, 4, N'Lease A FULL APARTMENT AT LANG HA - Dong Da', N'We have self-contained apartments, fully furnished, designed as Studio (Studio Apartment). The apartments are equipped with a kitchen, a balcony, a separate toilet equipped with equipment according to modern living standards, very suitable for professionals working in the Capital ...', 250, N'Dong Da Ha Noi', N'Hang Muoi', N'Dong Da', N'Hang Bot', N'Ha Noi', 50, N'/Lmages/b4291057-e1f3-458b-8611-4a1f117fc0dc.jpg', CAST(N'2020-01-09' AS Date), CAST(N'2020-02-08' AS Date), NULL, NULL, N'nguyenson1', 1, 1, 3)
INSERT [dbo].[Advertisement] ([AdvId], [UserId], [SeLLId], [ModeId], [CateId], [Header], [Content], [Price], [Address], [Street], [District], [Ward], [CityProvince], [Area], [Photothumbnail], [DateUp], [ExpDate], [AgentId], [AgentAcount], [SellAcount], [Approved], [Paid], [Bedroom]) VALUES (151, 1, 7, 4, 4, N'VINHOMES GOLDEN RIVER APARTMENT FOR LEASE BEST PRICE IN THE MARKET', N'The rental price depends on the view, direction and interior of the apartment.
Price negotiable for goodwill guests to rent or buy.', 350, N'Da Nang', N'Hoa Khanh Trung', N'Lien Chieu', N'Hoa Khanh Nam', N'Da Nang', 45, N'/Lmages/df24d7fa-8f00-49c0-a193-f4f98c81b61d.jpg', CAST(N'2020-01-09' AS Date), CAST(N'2020-05-08' AS Date), NULL, NULL, N'nguyenson1', 1, 1, 2)
SET IDENTITY_INSERT [dbo].[Advertisement] OFF
SET IDENTITY_INSERT [dbo].[Agent] ON 

INSERT [dbo].[Agent] ([AgentId], [AgentAcount], [AgentName], [AgentPassword], [AgentAddress], [AgentPhone], [AgentEmail], [TaxCode], [AgentAvatar], [AgentActive]) VALUES (5, N'nguyenson', N'Nguyen Son', N'123', N'356 No trang long', N'0979498174', N'son1@gmail.com', N'T123', N'/Lmages/person_2.jpg', 1)
INSERT [dbo].[Agent] ([AgentId], [AgentAcount], [AgentName], [AgentPassword], [AgentAddress], [AgentPhone], [AgentEmail], [TaxCode], [AgentAvatar], [AgentActive]) VALUES (6, N'quynhhuong', N'Quynh Huong', N'123', N'345 Le quang dinh', N'0979498176', N'huong@gmail.com', N'T456', N'/Lmages/team-4.jpg', 1)
INSERT [dbo].[Agent] ([AgentId], [AgentAcount], [AgentName], [AgentPassword], [AgentAddress], [AgentPhone], [AgentEmail], [TaxCode], [AgentAvatar], [AgentActive]) VALUES (7, N'ngockinh', N'Ngoc kinh', N'123', N'quan 7', N'0979498179', N'kinh@gmail.com', N'T4565', N'/Lmages/person_1.jpg', NULL)
INSERT [dbo].[Agent] ([AgentId], [AgentAcount], [AgentName], [AgentPassword], [AgentAddress], [AgentPhone], [AgentEmail], [TaxCode], [AgentAvatar], [AgentActive]) VALUES (8, N'vanchi', N'Van Tran Chi', N'123', N'quan phu nhuan', N'0978123456', N'vanchi@gmail.com', N'T1234', N'/Lmages/team-6.jpg', NULL)
INSERT [dbo].[Agent] ([AgentId], [AgentAcount], [AgentName], [AgentPassword], [AgentAddress], [AgentPhone], [AgentEmail], [TaxCode], [AgentAvatar], [AgentActive]) VALUES (9, N'nhatnam', N'Nhat Nam', N'123', N'quan 2', N'0979456173', N'nhatnam@gmail.com', N'T12345', N'/Lmages/team-1.jpg', NULL)
SET IDENTITY_INSERT [dbo].[Agent] OFF
SET IDENTITY_INSERT [dbo].[Bank] ON 

INSERT [dbo].[Bank] ([BankId], [BankName], [BankRate]) VALUES (1, N'SEABANK', 0.8)
INSERT [dbo].[Bank] ([BankId], [BankName], [BankRate]) VALUES (2, N'ACB', 1.2)
INSERT [dbo].[Bank] ([BankId], [BankName], [BankRate]) VALUES (3, N'HDBANK', 1.2)
INSERT [dbo].[Bank] ([BankId], [BankName], [BankRate]) VALUES (4, N'OCB', 1.2)
INSERT [dbo].[Bank] ([BankId], [BankName], [BankRate]) VALUES (5, N'BIDV', 1.2)
INSERT [dbo].[Bank] ([BankId], [BankName], [BankRate]) VALUES (6, N'Techcombank', 0.5)
INSERT [dbo].[Bank] ([BankId], [BankName], [BankRate]) VALUES (7, N'VIETBANK', 1.2)
SET IDENTITY_INSERT [dbo].[Bank] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CateId], [CateName]) VALUES (1, N'House')
INSERT [dbo].[Category] ([CateId], [CateName]) VALUES (2, N'Office space')
INSERT [dbo].[Category] ([CateId], [CateName]) VALUES (3, N'Shops')
INSERT [dbo].[Category] ([CateId], [CateName]) VALUES (4, N'Apartment')
INSERT [dbo].[Category] ([CateId], [CateName]) VALUES (5, N'Villa')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([CityId], [CityName]) VALUES (5, N'Ha Noi')
INSERT [dbo].[City] ([CityId], [CityName]) VALUES (6, N'Ho Chi Minh')
INSERT [dbo].[City] ([CityId], [CityName]) VALUES (7, N'Da Nang')
SET IDENTITY_INSERT [dbo].[City] OFF
SET IDENTITY_INSERT [dbo].[District] ON 

INSERT [dbo].[District] ([DistrictId], [CityId], [DistrictName]) VALUES (8, 5, N'Hoan Kiem')
INSERT [dbo].[District] ([DistrictId], [CityId], [DistrictName]) VALUES (9, 5, N'Dong Da')
INSERT [dbo].[District] ([DistrictId], [CityId], [DistrictName]) VALUES (10, 6, N'District 1')
INSERT [dbo].[District] ([DistrictId], [CityId], [DistrictName]) VALUES (11, 6, N'District 2')
INSERT [dbo].[District] ([DistrictId], [CityId], [DistrictName]) VALUES (12, 7, N'Hai Chau')
INSERT [dbo].[District] ([DistrictId], [CityId], [DistrictName]) VALUES (13, 7, N'Lien Chieu')
INSERT [dbo].[District] ([DistrictId], [CityId], [DistrictName]) VALUES (14, 6, N'District 3')
INSERT [dbo].[District] ([DistrictId], [CityId], [DistrictName]) VALUES (15, 5, N'Ba Dinh')
INSERT [dbo].[District] ([DistrictId], [CityId], [DistrictName]) VALUES (16, 6, N'Phu Nhuan')
INSERT [dbo].[District] ([DistrictId], [CityId], [DistrictName]) VALUES (17, 6, N'Binh Thanh')
INSERT [dbo].[District] ([DistrictId], [CityId], [DistrictName]) VALUES (18, 6, N'Go Vap')
INSERT [dbo].[District] ([DistrictId], [CityId], [DistrictName]) VALUES (19, 5, N'Hai Ba Trung')
INSERT [dbo].[District] ([DistrictId], [CityId], [DistrictName]) VALUES (20, 5, N'Thanh Xuan')
SET IDENTITY_INSERT [dbo].[District] OFF
SET IDENTITY_INSERT [dbo].[Feedbacks] ON 

INSERT [dbo].[Feedbacks] ([FeedbackId], [ModeId], [AgentId], [SeLLId], [FeedbackContent], [FeedbackReply]) VALUES (2, 2, 5, NULL, N'ggffgb', NULL)
SET IDENTITY_INSERT [dbo].[Feedbacks] OFF
SET IDENTITY_INSERT [dbo].[LastedNews] ON 

INSERT [dbo].[LastedNews] ([NewsId], [AdvId]) VALUES (11, 105)
INSERT [dbo].[LastedNews] ([NewsId], [AdvId]) VALUES (12, 106)
INSERT [dbo].[LastedNews] ([NewsId], [AdvId]) VALUES (13, 111)
INSERT [dbo].[LastedNews] ([NewsId], [AdvId]) VALUES (14, 116)
INSERT [dbo].[LastedNews] ([NewsId], [AdvId]) VALUES (15, 109)
INSERT [dbo].[LastedNews] ([NewsId], [AdvId]) VALUES (16, 112)
INSERT [dbo].[LastedNews] ([NewsId], [AdvId]) VALUES (17, 108)
INSERT [dbo].[LastedNews] ([NewsId], [AdvId]) VALUES (18, 113)
INSERT [dbo].[LastedNews] ([NewsId], [AdvId]) VALUES (19, 118)
SET IDENTITY_INSERT [dbo].[LastedNews] OFF
SET IDENTITY_INSERT [dbo].[Mode] ON 

INSERT [dbo].[Mode] ([ModeId], [ModeName]) VALUES (1, N'Sale')
INSERT [dbo].[Mode] ([ModeId], [ModeName]) VALUES (2, N'Buy')
INSERT [dbo].[Mode] ([ModeId], [ModeName]) VALUES (3, N'Rent')
INSERT [dbo].[Mode] ([ModeId], [ModeName]) VALUES (4, N'Lease')
SET IDENTITY_INSERT [dbo].[Mode] OFF
SET IDENTITY_INSERT [dbo].[PhotoDetail] ON 

INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (168, 105, N'/Lmages/2e2365b8-57e5-4748-8726-eee485ed6088.jpg', N'2e2365b8-57e5-4748-8726-eee485ed6088', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (169, 106, N'/Lmages/3230c584-e290-4091-87ef-27ab453256ab.jpg', N'3230c584-e290-4091-87ef-27ab453256ab', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (170, 107, N'/Lmages/8012b1d0-791a-4193-a6cb-75a8b1b1812e.jpg', N'8012b1d0-791a-4193-a6cb-75a8b1b1812e', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (171, 108, N'/Lmages/e43e9c30-3de2-4079-a955-03458e63c976.jpg', N'e43e9c30-3de2-4079-a955-03458e63c976', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (172, 109, N'/Lmages/35f00ae6-1cfa-4337-a9bc-a2b23c7c9973.jpg', N'35f00ae6-1cfa-4337-a9bc-a2b23c7c9973', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (173, 110, N'/Lmages/63f268f0-b068-4fcc-a8ac-bac3b10d6d61.jpg', N'63f268f0-b068-4fcc-a8ac-bac3b10d6d61', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (174, 111, N'/Lmages/5e66283a-49e6-4311-8a11-926a586870a7.jpg', N'5e66283a-49e6-4311-8a11-926a586870a7', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (175, 112, N'/Lmages/3ca465e3-0118-4f46-aedd-72a9fbec91da.jpg', N'3ca465e3-0118-4f46-aedd-72a9fbec91da', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (176, 113, N'/Lmages/249ab5f6-46ca-4ab8-a544-6e7658ba0c59.jpg', N'249ab5f6-46ca-4ab8-a544-6e7658ba0c59', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (177, 114, N'/Lmages/6162b7bc-8708-4721-b5c1-235f7ad2051b.jpg', N'6162b7bc-8708-4721-b5c1-235f7ad2051b', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (178, 115, N'/Lmages/ff9182c3-230f-4b63-8713-f64ecbff3a36.jpg', N'ff9182c3-230f-4b63-8713-f64ecbff3a36', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (179, 116, N'/Lmages/a7f9106d-7c6f-49c5-9547-d01a0e65f175.jpg', N'a7f9106d-7c6f-49c5-9547-d01a0e65f175', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (180, 117, N'/Lmages/aa266383-7122-4de0-89a6-b01fe0a7fc59.jpg', N'aa266383-7122-4de0-89a6-b01fe0a7fc59', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (181, 118, N'/Lmages/58b07882-bab1-4b7f-941d-f4838b610c30.jpg', N'58b07882-bab1-4b7f-941d-f4838b610c30', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (182, 119, N'/Lmages/03422af9-956b-4ea1-bb30-3f765d068009.jpg', N'03422af9-956b-4ea1-bb30-3f765d068009', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (205, 105, N'/Lmages/7e3339fd-65e2-4e55-90f1-ec2dc72ecdea.jpg', N'7e3339fd-65e2-4e55-90f1-ec2dc72ecdea', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (208, 123, N'/Lmages/cff84a05-86c3-4d4f-bf5a-e41059675b31.jfif', N'cff84a05-86c3-4d4f-bf5a-e41059675b31', N'.jfif')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (209, 123, N'/Lmages/28f475a8-f0e1-4b15-b04f-62875da0e107.jpg', N'28f475a8-f0e1-4b15-b04f-62875da0e107', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (210, 124, N'/Lmages/12d7b52a-43fa-481f-b25f-b3b0d2c82b7d.jpg', N'12d7b52a-43fa-481f-b25f-b3b0d2c82b7d', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (211, 125, N'/Lmages/86246465-9b03-4034-a0eb-41d876ab01b2.jpg', N'86246465-9b03-4034-a0eb-41d876ab01b2', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (212, 134, N'/Lmages/1d424963-abf6-4d6c-a209-6b890dc6719d.jpg', N'1d424963-abf6-4d6c-a209-6b890dc6719d', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (213, 135, N'/Lmages/feb64ebd-5f44-4777-bf09-6ad6783e8602.jpg', N'feb64ebd-5f44-4777-bf09-6ad6783e8602', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (214, 119, N'/Lmages/d09fd641-771d-40bc-a0bf-535443a5028f.jpg', N'd09fd641-771d-40bc-a0bf-535443a5028f', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (215, 120, N'/Lmages/77f934e3-1ff2-4055-9622-59184dc512c3.jpg', N'77f934e3-1ff2-4055-9622-59184dc512c3', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (216, 136, N'/Lmages/9cdb357c-497c-46a5-9f8c-8978b9f56480.jpg', N'9cdb357c-497c-46a5-9f8c-8978b9f56480', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (217, 137, N'/Lmages/11465e03-2a99-4abc-86e8-6b56f4646da2.jpg', N'11465e03-2a99-4abc-86e8-6b56f4646da2', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (218, 138, N'/Lmages/375d95d0-518a-44dc-9b1f-83926103f84d.jpg', N'375d95d0-518a-44dc-9b1f-83926103f84d', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (219, 121, N'/Lmages/1a73330e-5fe6-4f5e-9dc9-9006b9d82df7.jpg', N'1a73330e-5fe6-4f5e-9dc9-9006b9d82df7', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (220, 122, N'/Lmages/02f871ad-3e26-4cfc-b520-e3b01fca1270.jpg', N'02f871ad-3e26-4cfc-b520-e3b01fca1270', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (221, 139, N'/Lmages/406190ea-8ae3-426a-bd19-4b0a730c618d.jpg', N'406190ea-8ae3-426a-bd19-4b0a730c618d', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (222, 140, N'/Lmages/ae3eaa98-2bf3-4063-bffd-003554f48ede.jpg', N'ae3eaa98-2bf3-4063-bffd-003554f48ede', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (223, 141, N'/Lmages/94fa2634-ccb3-44a0-af58-788ed98cd2c8.jpg', N'94fa2634-ccb3-44a0-af58-788ed98cd2c8', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (224, 142, N'/Lmages/4dd334c7-0628-4a26-912e-57fb7d255302.jpg', N'4dd334c7-0628-4a26-912e-57fb7d255302', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (225, 134, N'/Lmages/0eb19373-6b25-4910-99e9-b4ee9c29850c.jpg', N'0eb19373-6b25-4910-99e9-b4ee9c29850c', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (226, 134, N'/Lmages/c4b00931-608e-4f06-97e2-4e16467f852a.jpg', N'c4b00931-608e-4f06-97e2-4e16467f852a', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (227, 134, N'/Lmages/4bf0e652-00ab-4fc1-ba53-6ea64be2fe95.jpg', N'4bf0e652-00ab-4fc1-ba53-6ea64be2fe95', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (228, 143, N'/Lmages/fa3e82d1-cc0b-4d08-90ad-3875dc783ae9.jpg', N'fa3e82d1-cc0b-4d08-90ad-3875dc783ae9', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (229, 143, N'/Lmages/010b0d05-173b-4889-9f67-10e8dc1ef0da.jpeg', N'010b0d05-173b-4889-9f67-10e8dc1ef0da', N'.jpeg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (230, 143, N'/Lmages/8036d333-925e-4036-9885-04628fb44d05.jpg', N'8036d333-925e-4036-9885-04628fb44d05', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (231, 143, N'/Lmages/d6484341-9b5d-4284-95cd-9c9b355bee1a.jpg', N'd6484341-9b5d-4284-95cd-9c9b355bee1a', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (232, 124, N'/Lmages/2b27256c-b8a7-4d0a-a5a0-77dc00052b7c.jpg', N'2b27256c-b8a7-4d0a-a5a0-77dc00052b7c', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (233, 124, N'/Lmages/3e92d9a5-5878-426e-94cd-5c505d2c9273.jpg', N'3e92d9a5-5878-426e-94cd-5c505d2c9273', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (234, 124, N'/Lmages/db1fd3d7-c2fb-4ea6-b16a-5f147e53be86.jpg', N'db1fd3d7-c2fb-4ea6-b16a-5f147e53be86', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (235, 123, N'/Lmages/3091c9c7-bd97-400a-8060-6db983592378.jpg', N'3091c9c7-bd97-400a-8060-6db983592378', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (236, 123, N'/Lmages/d28a852a-0d8e-432f-988b-6b5454fa8701.jpg', N'd28a852a-0d8e-432f-988b-6b5454fa8701', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (237, 144, N'/Lmages/e62b6391-242e-4b31-a0d5-41d2d5e2f688.jpg', N'e62b6391-242e-4b31-a0d5-41d2d5e2f688', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (238, 145, N'/Lmages/ae0d3873-9249-4fa2-8b11-fffc759b0536.jpg', N'ae0d3873-9249-4fa2-8b11-fffc759b0536', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (239, 146, N'/Lmages/314932c7-7791-4ac5-a6d4-4ef9a44cd948.jpg', N'314932c7-7791-4ac5-a6d4-4ef9a44cd948', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (240, 146, N'/Lmages/c2e7af88-122e-4fe3-8120-d03f4d97b913.jpeg', N'c2e7af88-122e-4fe3-8120-d03f4d97b913', N'.jpeg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (241, 146, N'/Lmages/b57c2970-9702-4748-8cb7-088622c8b989.jpg', N'b57c2970-9702-4748-8cb7-088622c8b989', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (242, 146, N'/Lmages/0bc56526-4974-4f42-aef4-956eb8cddea4.jpg', N'0bc56526-4974-4f42-aef4-956eb8cddea4', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (243, 144, N'/Lmages/052ce82e-03dd-4234-a65d-b2e2906c5e6e.jpg', N'052ce82e-03dd-4234-a65d-b2e2906c5e6e', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (244, 144, N'/Lmages/33893c90-6cfd-4e7d-9350-b18204b877fb.jpg', N'33893c90-6cfd-4e7d-9350-b18204b877fb', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (245, 144, N'/Lmages/ad35d319-cc93-49fb-bfa9-e66ce0c44c59.jpg', N'ad35d319-cc93-49fb-bfa9-e66ce0c44c59', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (246, 142, N'/Lmages/358fc589-4920-4f5c-aad9-36879b93166d.jpg', N'358fc589-4920-4f5c-aad9-36879b93166d', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (247, 142, N'/Lmages/0791dbc9-aef2-43b9-a26c-3f7501f25f67.jpg', N'0791dbc9-aef2-43b9-a26c-3f7501f25f67', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (248, 142, N'/Lmages/58097cd1-6193-4555-8981-b21c42d78fca.jpg', N'58097cd1-6193-4555-8981-b21c42d78fca', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (249, 108, N'/Lmages/42935688-f91c-40a3-b5f1-7e51e1bb6c72.jpg', N'42935688-f91c-40a3-b5f1-7e51e1bb6c72', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (250, 108, N'/Lmages/cd3cbe9c-632c-4ec6-8909-045c4cf812e0.jpg', N'cd3cbe9c-632c-4ec6-8909-045c4cf812e0', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (251, 108, N'/Lmages/418911d0-2531-4b2c-b2e8-1016b5b70f30.jpg', N'418911d0-2531-4b2c-b2e8-1016b5b70f30', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (252, 105, N'/Lmages/aaecceb4-a8e9-4ba1-8e1c-0bf5b6e690eb.jpg', N'aaecceb4-a8e9-4ba1-8e1c-0bf5b6e690eb', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (253, 105, N'/Lmages/c0cbe3e5-60d3-4af5-8d8d-083aca01afc9.jpg', N'c0cbe3e5-60d3-4af5-8d8d-083aca01afc9', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (254, 109, N'/Lmages/247adcca-6c6b-4047-a52c-75ae1504bce2.jpg', N'247adcca-6c6b-4047-a52c-75ae1504bce2', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (255, 109, N'/Lmages/9fb24a13-7d7f-4559-b848-fe3183465da8.jpg', N'9fb24a13-7d7f-4559-b848-fe3183465da8', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (256, 109, N'/Lmages/7187cfc8-a6c4-416a-99aa-ef90767ffc18.jpg', N'7187cfc8-a6c4-416a-99aa-ef90767ffc18', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (257, 106, N'/Lmages/d25eb06d-0605-425f-ba7f-c5d8788f9d2e.jpeg', N'd25eb06d-0605-425f-ba7f-c5d8788f9d2e', N'.jpeg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (258, 106, N'/Lmages/ae630299-cf03-445b-bf2c-76281bf88ef6.jpeg', N'ae630299-cf03-445b-bf2c-76281bf88ef6', N'.jpeg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (259, 111, N'/Lmages/bdb90dc7-201e-49cf-9f73-99e2809fdc4e.jpg', N'bdb90dc7-201e-49cf-9f73-99e2809fdc4e', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (260, 111, N'/Lmages/3554b04b-9767-40d9-9c87-babd61013920.jpg', N'3554b04b-9767-40d9-9c87-babd61013920', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (261, 111, N'/Lmages/a26bf383-425c-4651-8941-fc9c2217bce1.jpg', N'a26bf383-425c-4651-8941-fc9c2217bce1', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (262, 116, N'/Lmages/f9f88577-93be-4ff6-bba5-6a57390927f6.jpg', N'f9f88577-93be-4ff6-bba5-6a57390927f6', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (263, 116, N'/Lmages/a9d44c5d-0d4a-43a6-9ed3-b9d3274cb9d5.jpg', N'a9d44c5d-0d4a-43a6-9ed3-b9d3274cb9d5', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (264, 116, N'/Lmages/200b4dd7-0e16-4aa6-97a8-b5c932439d95.jpg', N'200b4dd7-0e16-4aa6-97a8-b5c932439d95', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (265, 113, N'/Lmages/b8bd5111-a70d-447b-8265-b09152270cf4.jpg', N'b8bd5111-a70d-447b-8265-b09152270cf4', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (266, 113, N'/Lmages/4723184d-79be-4fee-8f17-df593414f05c.jpg', N'4723184d-79be-4fee-8f17-df593414f05c', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (267, 113, N'/Lmages/85a20931-fffa-429a-b7ea-e14b91050be2.jpg', N'85a20931-fffa-429a-b7ea-e14b91050be2', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (268, 112, N'/Lmages/d660a44e-d502-45e2-9d44-2515afa63620.jpg', N'd660a44e-d502-45e2-9d44-2515afa63620', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (269, 112, N'/Lmages/8168a3f3-0050-4ed4-be08-bbd60a43f543.jpg', N'8168a3f3-0050-4ed4-be08-bbd60a43f543', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (270, 112, N'/Lmages/e1a38ab9-a6b2-40fc-9695-476e4b95e69e.jpg', N'e1a38ab9-a6b2-40fc-9695-476e4b95e69e', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (271, 118, N'/Lmages/1248e3c5-c03d-41b1-8c5e-d8e270ae2558.jpg', N'1248e3c5-c03d-41b1-8c5e-d8e270ae2558', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (272, 118, N'/Lmages/519697d4-d096-449c-9823-e94ecc55c457.jpg', N'519697d4-d096-449c-9823-e94ecc55c457', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (273, 118, N'/Lmages/dcaf241b-8070-4a39-96e8-aae495a7f824.jpg', N'dcaf241b-8070-4a39-96e8-aae495a7f824', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (274, 120, N'/Lmages/7766bc8b-3fc3-4a6c-b0ea-c123060a812c.jpg', N'7766bc8b-3fc3-4a6c-b0ea-c123060a812c', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (275, 120, N'/Lmages/5dd532d8-6132-4389-bc30-6d598d7246f6.jpg', N'5dd532d8-6132-4389-bc30-6d598d7246f6', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (276, 121, N'/Lmages/8660770a-2dce-4c1d-aec4-1dbac72cfaaf.jpg', N'8660770a-2dce-4c1d-aec4-1dbac72cfaaf', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (277, 121, N'/Lmages/0d1fdd18-00a0-4ebe-91b1-6eeb112e7a2f.jpg', N'0d1fdd18-00a0-4ebe-91b1-6eeb112e7a2f', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (278, 122, N'/Lmages/62373177-c59d-4df7-a411-c9d19b4a4ba5.jpg', N'62373177-c59d-4df7-a411-c9d19b4a4ba5', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (279, 122, N'/Lmages/c6591414-bcc6-46b8-a43b-1eb78e713d20.jpg', N'c6591414-bcc6-46b8-a43b-1eb78e713d20', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (280, 122, N'/Lmages/61bf1dbd-66e5-4cca-b756-e27dbebbe158.jpg', N'61bf1dbd-66e5-4cca-b756-e27dbebbe158', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (281, 135, N'/Lmages/f1b700a7-1671-4542-af2f-f01dfe24bc79.jpg', N'f1b700a7-1671-4542-af2f-f01dfe24bc79', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (282, 135, N'/Lmages/282a4be4-c0a7-46d9-acf4-f9aabaa0e13b.jpg', N'282a4be4-c0a7-46d9-acf4-f9aabaa0e13b', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (283, 135, N'/Lmages/ebe9e6bf-1f27-457a-aeef-9383563a7f47.jpg', N'ebe9e6bf-1f27-457a-aeef-9383563a7f47', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (284, 147, N'/Lmages/859f7db1-6f81-494b-b0f9-0bac95dd8c87.jpg', N'859f7db1-6f81-494b-b0f9-0bac95dd8c87', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (285, 148, N'/Lmages/4464c87b-4c1f-4c3a-bf2c-4e719e730cf7.jpg', N'4464c87b-4c1f-4c3a-bf2c-4e719e730cf7', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (286, 149, N'/Lmages/52897485-0d0b-4640-b600-1d8e1e3542b2.jpg', N'52897485-0d0b-4640-b600-1d8e1e3542b2', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (287, 149, N'/Lmages/1161afa4-c658-4c2b-aefe-202fa79be3f6.jpg', N'1161afa4-c658-4c2b-aefe-202fa79be3f6', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (288, 149, N'/Lmages/3dbb8d81-3436-44e3-8d6c-6543767edae8.jpg', N'3dbb8d81-3436-44e3-8d6c-6543767edae8', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (289, 149, N'/Lmages/2ce9abb6-c68f-48c7-a499-1653da8b68b8.jpg', N'2ce9abb6-c68f-48c7-a499-1653da8b68b8', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (290, 148, N'/Lmages/37b7b266-7731-407c-baf7-00acfe9c1bfa.jpg', N'37b7b266-7731-407c-baf7-00acfe9c1bfa', N'.jpg')
GO
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (291, 148, N'/Lmages/8c7cae9e-a3af-4935-ad73-7c69a59ab398.jpg', N'8c7cae9e-a3af-4935-ad73-7c69a59ab398', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (292, 148, N'/Lmages/45e1fc7e-815d-4583-9a1d-97274b25706b.jpg', N'45e1fc7e-815d-4583-9a1d-97274b25706b', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (293, 150, N'/Lmages/b4291057-e1f3-458b-8611-4a1f117fc0dc.jpg', N'b4291057-e1f3-458b-8611-4a1f117fc0dc', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (294, 150, N'/Lmages/3ec6c7b0-f908-47d8-b86e-8e517e915fbd.jpg', N'3ec6c7b0-f908-47d8-b86e-8e517e915fbd', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (295, 150, N'/Lmages/f3e3b456-ecdb-44f9-b39f-8e56e8016700.jpg', N'f3e3b456-ecdb-44f9-b39f-8e56e8016700', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (296, 151, N'/Lmages/df24d7fa-8f00-49c0-a193-f4f98c81b61d.jpg', N'df24d7fa-8f00-49c0-a193-f4f98c81b61d', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (297, 151, N'/Lmages/754ea4b6-12b5-444f-9980-3b283551e5e5.jpg', N'754ea4b6-12b5-444f-9980-3b283551e5e5', N'.jpg')
INSERT [dbo].[PhotoDetail] ([IdImage], [AdvId], [Image], [Guidimage], [Extension]) VALUES (298, 151, N'/Lmages/819544f2-df5f-41e8-b11d-3c410d035445.jpg', N'819544f2-df5f-41e8-b11d-3c410d035445', N'.jpg')
SET IDENTITY_INSERT [dbo].[PhotoDetail] OFF
SET IDENTITY_INSERT [dbo].[PrivateSeller] ON 

INSERT [dbo].[PrivateSeller] ([SeLLId], [SeLLAcount], [SellPassword], [SellFullname], [SellGender], [SellDob], [SellAddress], [SellPhone], [SellEmail], [SellActive]) VALUES (7, N'nguyenson1', N'123', N'nguyen son', 0, CAST(N'1990-01-01' AS Date), N'binh thanh', N'0979498109', N'nguyenson1@gmail.com', 1)
INSERT [dbo].[PrivateSeller] ([SeLLId], [SeLLAcount], [SellPassword], [SellFullname], [SellGender], [SellDob], [SellAddress], [SellPhone], [SellEmail], [SellActive]) VALUES (8, N'quynhhuong1', N'123', N'Quynh Huong', 1, CAST(N'2000-01-01' AS Date), N'binh thanh', N'123456789', N'huong1@gmail.com', NULL)
INSERT [dbo].[PrivateSeller] ([SeLLId], [SeLLAcount], [SellPassword], [SellFullname], [SellGender], [SellDob], [SellAddress], [SellPhone], [SellEmail], [SellActive]) VALUES (9, N'ngockinh1', N'123', N'Ngoc kinh', 0, CAST(N'1997-01-31' AS Date), N'quan 7', N'1234567800', N'aptech@fpt.com', 1)
INSERT [dbo].[PrivateSeller] ([SeLLId], [SeLLAcount], [SellPassword], [SellFullname], [SellGender], [SellDob], [SellAddress], [SellPhone], [SellEmail], [SellActive]) VALUES (10, N'vanchi1', N'123', N'van tran chi', 0, CAST(N'1998-01-30' AS Date), N'quan 3', N'12345690', N'chi2@gmail.com', 1)
INSERT [dbo].[PrivateSeller] ([SeLLId], [SeLLAcount], [SellPassword], [SellFullname], [SellGender], [SellDob], [SellAddress], [SellPhone], [SellEmail], [SellActive]) VALUES (11, N'nhatnam1', N'123', N'Nhat Nam', 0, CAST(N'1999-12-02' AS Date), N'quan 10', N'1456879890', N'nhatnam1@gmail.com', NULL)
SET IDENTITY_INSERT [dbo].[PrivateSeller] OFF
SET IDENTITY_INSERT [dbo].[Street] ON 

INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (18, 6, 10, 14, N'Nguyen Thi Minh Khai')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (19, 6, 10, 14, N'Dong Khoi')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (20, 6, 10, 15, N'Ba Le Chan')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (21, 6, 10, 15, N'Cong Xa Paris')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (22, 6, 11, 16, N'Duong so 1')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (23, 6, 11, 16, N'Duong so 2')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (24, 6, 11, 17, N'Le Hien Mai')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (25, 6, 11, 17, N'Hoang The Thien')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (26, 5, 8, 18, N'Ba Trieu')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (27, 5, 8, 18, N'Bach Dang')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (28, 5, 8, 19, N'Hang Luoc')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (29, 5, 8, 19, N'Hang Ma')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (30, 5, 9, 20, N'Hang Mam')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (31, 5, 9, 20, N'Hang Manh')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (32, 5, 9, 21, N'Hang Muoi')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (33, 5, 9, 21, N'Hang Ngang')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (34, 7, 12, 22, N'Ong Ich Khiem')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (35, 7, 12, 22, N'Dong Da')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (36, 7, 12, 23, N'Quang Trung')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (37, 7, 12, 23, N'Phan Chau Trinh')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (38, 7, 13, 24, N'Hoa Hiep')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (39, 7, 13, 24, N'Hoa Hiep Bac')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (40, 7, 13, 25, N'Hoa Trung')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (41, 7, 13, 25, N'Hoa Khanh Trung')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (42, 6, 14, 26, N'Cao Thang')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (43, 6, 14, 28, N'Ban Co')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (44, 6, 14, 26, N'Dien Bien Phu')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (45, 6, 14, 27, N'HUynh Tinh Cua')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (46, 6, 14, 27, N'Le Ngo Cat')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (47, 6, 14, 28, N'Le Van Sy')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (48, 6, 16, 30, N'Co Giang')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (49, 6, 16, 30, N'Co Bac')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (50, 6, 16, 31, N'Dao Duy Anh')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (51, 6, 16, 31, N'Dao Duy Tu')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (52, 6, 17, 32, N'Le Quang Dinh')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (53, 6, 17, 32, N'No Trang Long')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (54, 6, 17, 33, N'Nguyen Van Dau')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (55, 6, 17, 33, N'Phan Van Tri')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (56, 6, 18, 34, N'Nguyen Van Luong')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (57, 6, 18, 34, N'Phan Van Tri')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (58, 6, 18, 35, N'Nguyen Thai Son')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (59, 6, 18, 35, N'Le Duc Tho')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (60, 5, 15, 40, N'Lieu Giai')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (61, 5, 15, 40, N'Son Tay')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (62, 5, 15, 41, N'Hung Phat')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (63, 5, 15, 41, N'Ton That Dam')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (64, 5, 19, 36, N'Quang Trung')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (65, 5, 19, 37, N'Tam Trinh')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (66, 5, 19, 37, N'Quynh Loi')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (67, 5, 19, 36, N'Thanh Nhan')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (68, 5, 20, 38, N'Thi Sach')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (69, 5, 20, 38, N'Ta Quang Buu')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (70, 5, 20, 39, N'Nguyen Cao')
INSERT [dbo].[Street] ([StreetId], [CityId], [DistrictId], [WardId], [StreetName]) VALUES (71, 5, 20, 39, N'Nguyen Du')
SET IDENTITY_INSERT [dbo].[Street] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [UserName]) VALUES (1, N'PrivateSeller')
INSERT [dbo].[User] ([UserId], [UserName]) VALUES (2, N'Agent')
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[UserAdvDetails] ON 

INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (24, 105, N'House for sale  55m2x 4 floors, suitable for office, wide entrance', 2, NULL, NULL, 5, N'nguyenson', 4, CAST(N'2020-01-08' AS Date), CAST(N'2020-03-08' AS Date), 2, 0, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (25, 107, N'Duplex & Penthouse District 2, amazing views, pink book for foreigner buyer', 2, NULL, NULL, 5, N'nguyenson', 2, CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), 1, 0, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (26, 108, N'BUDGETED SERVICED APARTMENT FOR RENT AT THE JUNCTURE OF TAY HO AND CAU GIAY DISTRICT', 2, NULL, NULL, 5, N'nguyenson', 2, CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), 1, 0, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (27, 106, N'My Hoang Duplex Villa for sale Duong so 1,An Khanh,District 2,Ho Chi Minh', 2, NULL, NULL, 6, N'quynhhuong', 7, CAST(N'2020-01-08' AS Date), CAST(N'2020-05-07' AS Date), 1, 1, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (28, 109, N'NEED TO RENT A BUILDING 322/158 NHAN MY, MY DINH 1 -SUITABLE FOR OFFICE OR HOUSING', 2, NULL, NULL, 6, N'quynhhuong', 8, CAST(N'2020-01-08' AS Date), CAST(N'2020-07-06' AS Date), 0, 0, 1)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (29, 110, N'Serenity Sky Villas in centre of HCMC - It could be the most luxurious one in the next 3 years!', 2, NULL, NULL, 7, N'ngockinh', 2, CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), 1, 0, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (30, 111, N'Villa at Saigon Pearl for rent, 1 ground floor, corner', 2, NULL, NULL, 7, N'ngockinh', 5, CAST(N'2020-01-08' AS Date), CAST(N'2020-04-07' AS Date), 0, 1, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (31, 112, N'Leasing townhouse with 2 frontages, 1 ground floor, 2 floors, near crossroads; suitable for office', 2, NULL, NULL, 9, N'nhatnam', 7, CAST(N'2020-01-08' AS Date), CAST(N'2020-05-07' AS Date), 1, 1, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (32, 113, N'Renting office with resident for company and co-working space', 2, NULL, NULL, 9, N'nhatnam', 5, CAST(N'2020-01-08' AS Date), CAST(N'2020-04-07' AS Date), 0, 1, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (33, 115, N'Need to buy houses under 30m2, under 200.000$ in District 2 Ho Chi Minh city', 2, NULL, NULL, 8, N'vanchi', 2, CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), 1, 0, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (34, 118, N'Studio apartment for rent at Vinhomes Central Park, 1 bedroom, 3,2 billion vnd (160$) (all fees)', 1, 7, N'nguyenson1', NULL, NULL, 2, CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), 1, 0, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (39, 114, N'Beautiful 3 bedrooms house for lease in Old Quarter - Hoan Kiem dist, Hanoi', 2, NULL, NULL, 8, N'vanchi', 2, CAST(N'2019-12-07' AS Date), CAST(N'2020-01-05' AS Date), 1, 0, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (42, 119, N'2 bedroom apartment for sale at Gateway Thao Dien, next to MRT station, HCMC', 1, 7, N'nguyenson1', NULL, NULL, 2, CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), 1, 0, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (43, 120, N'Nice apartment for sale at Sky Garden 3, 72m2, 2BRs+2WCs, only 3 billion - Call: 0906.647.689', 1, 7, N'nguyenson1', NULL, NULL, 2, CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), 1, 0, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (44, 135, N'I need to buy a house in Cau Giay, Dong Da, Ba Dinh, Tay Ho, South - North Tu Liem, 30 - 300m2 ground', 1, 7, N'nguyenson1', NULL, NULL, 5, CAST(N'2020-01-08' AS Date), CAST(N'2020-04-07' AS Date), 0, 1, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (45, 136, N'Need to rent an apartment 2 or 3 bedrooms', 1, 7, N'nguyenson1', NULL, NULL, 5, CAST(N'2020-01-08' AS Date), CAST(N'2020-04-07' AS Date), 0, 1, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (46, 121, N'Property of Vietnam housing no longer difficulty with Vinhomes Ocean Park, bath the sea under home', 1, 8, N'quynhhuong1', NULL, NULL, 2, CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), 1, 0, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (47, 122, N'Phu My - Van Phat Hung Villa For Rent, Price 2000$-2200$/Month', 1, 8, N'quynhhuong1', NULL, NULL, 2, CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), 1, 0, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (48, 123, N'Need to buy apartment Pearl Plaza, Binh Thanh', 1, 9, N'ngockinh1', NULL, NULL, 2, CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), 1, 0, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (49, 124, N'Rent an apartment with 5 bedrooms, large garden or pool', 1, 9, N'ngockinh1', NULL, NULL, 2, CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), 1, 0, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (50, 125, N'CASH OFFICE D1, D2, BINH THANH. NEW, LUXURY, WITH A ROUND + GIVING FULL INTERIOR, GOOD PRICE', 1, 9, N'ngockinh1', NULL, NULL, 2, CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), 1, 0, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (51, 134, N'Buy a private home with a home. Cars can be near the main road. DT 30 - 50m2 ....', 1, 9, N'ngockinh1', NULL, NULL, 2, CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), 1, 0, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (52, 137, N'Need to rent a fully furnished apartment, 1 bedroom', 1, 11, N'nhatnam1', NULL, NULL, 5, CAST(N'2020-01-08' AS Date), CAST(N'2020-04-07' AS Date), 0, 1, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (53, 138, N'FOR LEASE IN  VINH PHUC WARD, BA DINH, HANOI', 1, 11, N'nhatnam1', NULL, NULL, 2, CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), 1, 0, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (54, 116, N'Nice house with The Lake-view, and a garage with 4 bedrooms next to Cong Vien Thong Nhat for lease', 2, NULL, NULL, 8, N'vanchi', 5, CAST(N'2020-01-08' AS Date), CAST(N'2020-04-07' AS Date), 0, 1, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (55, 146, N'HOUSE FOR Lease Entire house 129 / 2D NGUYEN THAI SON, GO VAP', 2, NULL, NULL, 9, N'nhatnam', 2, CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), 1, 0, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (56, 145, N'Lease A FULL GARDEN GARDEN, PRICE 68 MILLION vnd / MONTH', 2, NULL, NULL, 8, N'vanchi', 2, CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), 1, 0, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (57, 117, N'Office for rent Mê Linh Square, Ho Chi Minh City', 2, NULL, NULL, 8, N'vanchi', 2, CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), 1, 0, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (58, 144, N'Lease A SERVICE TRADING HOUSE IN PHU NHUAN', 2, NULL, NULL, 6, N'quynhhuong', 5, CAST(N'2020-01-08' AS Date), CAST(N'2020-04-07' AS Date), 0, 1, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (59, 143, N'Need to buy a private house in Chua Boc, Khuong Thuong, Dong Da', 1, 9, N'ngockinh1', NULL, NULL, 2, CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), 1, 0, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (60, 142, N'Need to buy a private house to live and business', 1, 8, N'quynhhuong1', NULL, NULL, 2, CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), 1, 0, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (61, 141, N'Need to buy a house near the center of District Phu Nhuan, about VND 6 billion', 1, 8, N'quynhhuong1', NULL, NULL, 2, CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), 1, 0, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (62, 140, N'Need to buy a house in Hoan Kiem', 1, 8, N'quynhhuong1', NULL, NULL, 2, CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), 1, 0, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (63, 139, N'Need to buy a downtown townhouse in District 2, near Saigon Bridge, 6 billion', 1, 7, N'nguyenson1', NULL, NULL, 2, CAST(N'2020-01-08' AS Date), CAST(N'2020-02-07' AS Date), 1, 0, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (64, 150, N'Lease A FULL APARTMENT AT LANG HA - Dong Da', 1, 7, N'nguyenson1', NULL, NULL, 2, CAST(N'2020-01-09' AS Date), CAST(N'2020-02-08' AS Date), 1, 0, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (65, 151, N'CHO THUÊ CAN H? VINHOMES GOLDEN RIVER  GIÁ T?T NH?T TH? TRU?NG', 1, 7, N'nguyenson1', NULL, NULL, 7, CAST(N'2020-01-09' AS Date), CAST(N'2020-05-08' AS Date), 1, 1, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (66, 149, N'Need to buy apartment Pearl Plaza, Binh Thanh', 2, NULL, NULL, 5, N'nguyenson', 2, CAST(N'2020-01-09' AS Date), CAST(N'2020-02-08' AS Date), 1, 0, 0)
INSERT [dbo].[UserAdvDetails] ([OrderId], [AdvId], [AdvTitle], [UserId], [SeLLId], [SeLLAccount], [AgentId], [AgentAccount], [SubTotal], [DateUp], [ExpDate], [Onemonth], [Threemonths], [Sixmonths]) VALUES (67, 148, N'Need to buy Penthouse City Garden apartment for rent is new, modern, very special and absolutely beautiful. It has 4 bedrooms, 3 bathrooms and a large open plan living/ dining roo', 2, NULL, NULL, 5, N'nguyenson', 2, CAST(N'2020-01-09' AS Date), CAST(N'2020-02-08' AS Date), 1, 0, 0)
SET IDENTITY_INSERT [dbo].[UserAdvDetails] OFF
SET IDENTITY_INSERT [dbo].[Ward] ON 

INSERT [dbo].[Ward] ([WardId], [CityId], [DistrictId], [WardName]) VALUES (14, 6, 10, N'Ben Nghe')
INSERT [dbo].[Ward] ([WardId], [CityId], [DistrictId], [WardName]) VALUES (15, 6, 10, N'Ben Thanh')
INSERT [dbo].[Ward] ([WardId], [CityId], [DistrictId], [WardName]) VALUES (16, 6, 11, N'An Khanh')
INSERT [dbo].[Ward] ([WardId], [CityId], [DistrictId], [WardName]) VALUES (17, 6, 11, N'An Phu')
INSERT [dbo].[Ward] ([WardId], [CityId], [DistrictId], [WardName]) VALUES (18, 5, 8, N'Chuong Duong')
INSERT [dbo].[Ward] ([WardId], [CityId], [DistrictId], [WardName]) VALUES (19, 5, 8, N'Cua Dong')
INSERT [dbo].[Ward] ([WardId], [CityId], [DistrictId], [WardName]) VALUES (20, 5, 9, N'Cat Linh')
INSERT [dbo].[Ward] ([WardId], [CityId], [DistrictId], [WardName]) VALUES (21, 5, 9, N'Hang Bot')
INSERT [dbo].[Ward] ([WardId], [CityId], [DistrictId], [WardName]) VALUES (22, 7, 12, N'Thach Thang')
INSERT [dbo].[Ward] ([WardId], [CityId], [DistrictId], [WardName]) VALUES (23, 7, 12, N'Thanh Binh')
INSERT [dbo].[Ward] ([WardId], [CityId], [DistrictId], [WardName]) VALUES (24, 7, 13, N'Hoa Minh')
INSERT [dbo].[Ward] ([WardId], [CityId], [DistrictId], [WardName]) VALUES (25, 7, 13, N'Hoa Khanh Nam')
INSERT [dbo].[Ward] ([WardId], [CityId], [DistrictId], [WardName]) VALUES (26, 6, 14, N'Ward 1')
INSERT [dbo].[Ward] ([WardId], [CityId], [DistrictId], [WardName]) VALUES (27, 6, 14, N'Ward 2')
INSERT [dbo].[Ward] ([WardId], [CityId], [DistrictId], [WardName]) VALUES (28, 6, 14, N'Ward 3')
INSERT [dbo].[Ward] ([WardId], [CityId], [DistrictId], [WardName]) VALUES (30, 6, 16, N'Ward 1')
INSERT [dbo].[Ward] ([WardId], [CityId], [DistrictId], [WardName]) VALUES (31, 6, 16, N'Ward 2')
INSERT [dbo].[Ward] ([WardId], [CityId], [DistrictId], [WardName]) VALUES (32, 6, 17, N'Ward 1')
INSERT [dbo].[Ward] ([WardId], [CityId], [DistrictId], [WardName]) VALUES (33, 6, 17, N'Ward 2')
INSERT [dbo].[Ward] ([WardId], [CityId], [DistrictId], [WardName]) VALUES (34, 6, 18, N'Ward 1')
INSERT [dbo].[Ward] ([WardId], [CityId], [DistrictId], [WardName]) VALUES (35, 6, 18, N'Ward 2')
INSERT [dbo].[Ward] ([WardId], [CityId], [DistrictId], [WardName]) VALUES (36, 5, 19, N'Bach Khoa')
INSERT [dbo].[Ward] ([WardId], [CityId], [DistrictId], [WardName]) VALUES (37, 5, 19, N'Bach Mai')
INSERT [dbo].[Ward] ([WardId], [CityId], [DistrictId], [WardName]) VALUES (38, 5, 20, N'Khuong Dinh')
INSERT [dbo].[Ward] ([WardId], [CityId], [DistrictId], [WardName]) VALUES (39, 5, 20, N'Khuong Mai')
INSERT [dbo].[Ward] ([WardId], [CityId], [DistrictId], [WardName]) VALUES (40, 5, 15, N'Thanh Tan')
INSERT [dbo].[Ward] ([WardId], [CityId], [DistrictId], [WardName]) VALUES (41, 5, 15, N'Binh Phuc')
SET IDENTITY_INSERT [dbo].[Ward] OFF
ALTER TABLE [dbo].[Advertisement] ADD  DEFAULT (NULL) FOR [SeLLId]
GO
ALTER TABLE [dbo].[Advertisement] ADD  DEFAULT (NULL) FOR [DateUp]
GO
ALTER TABLE [dbo].[Advertisement] ADD  DEFAULT (NULL) FOR [ExpDate]
GO
ALTER TABLE [dbo].[Advertisement] ADD  DEFAULT (NULL) FOR [AgentId]
GO
ALTER TABLE [dbo].[Advertisement] ADD  DEFAULT (NULL) FOR [AgentAcount]
GO
ALTER TABLE [dbo].[Advertisement] ADD  DEFAULT (NULL) FOR [SellAcount]
GO
ALTER TABLE [dbo].[Advertisement] ADD  DEFAULT ((0)) FOR [Approved]
GO
ALTER TABLE [dbo].[Advertisement] ADD  DEFAULT ((0)) FOR [Paid]
GO
ALTER TABLE [dbo].[Advertisement]  WITH CHECK ADD  CONSTRAINT [FK_AgentId] FOREIGN KEY([AgentId])
REFERENCES [dbo].[Agent] ([AgentId])
GO
ALTER TABLE [dbo].[Advertisement] CHECK CONSTRAINT [FK_AgentId]
GO
ALTER TABLE [dbo].[Advertisement]  WITH CHECK ADD  CONSTRAINT [FK_CateId] FOREIGN KEY([CateId])
REFERENCES [dbo].[Category] ([CateId])
GO
ALTER TABLE [dbo].[Advertisement] CHECK CONSTRAINT [FK_CateId]
GO
ALTER TABLE [dbo].[Advertisement]  WITH CHECK ADD  CONSTRAINT [FK_ModeId] FOREIGN KEY([ModeId])
REFERENCES [dbo].[Mode] ([ModeId])
GO
ALTER TABLE [dbo].[Advertisement] CHECK CONSTRAINT [FK_ModeId]
GO
ALTER TABLE [dbo].[Advertisement]  WITH CHECK ADD  CONSTRAINT [FK_SeLLId] FOREIGN KEY([SeLLId])
REFERENCES [dbo].[PrivateSeller] ([SeLLId])
GO
ALTER TABLE [dbo].[Advertisement] CHECK CONSTRAINT [FK_SeLLId]
GO
ALTER TABLE [dbo].[District]  WITH CHECK ADD  CONSTRAINT [FK_district_city] FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([CityId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[District] CHECK CONSTRAINT [FK_district_city]
GO
ALTER TABLE [dbo].[Feedbacks]  WITH CHECK ADD  CONSTRAINT [FK_AgentId2] FOREIGN KEY([AgentId])
REFERENCES [dbo].[Agent] ([AgentId])
GO
ALTER TABLE [dbo].[Feedbacks] CHECK CONSTRAINT [FK_AgentId2]
GO
ALTER TABLE [dbo].[Feedbacks]  WITH CHECK ADD  CONSTRAINT [FK_ModeId1] FOREIGN KEY([ModeId])
REFERENCES [dbo].[Mode] ([ModeId])
GO
ALTER TABLE [dbo].[Feedbacks] CHECK CONSTRAINT [FK_ModeId1]
GO
ALTER TABLE [dbo].[Feedbacks]  WITH CHECK ADD  CONSTRAINT [FK_SeLLId2] FOREIGN KEY([SeLLId])
REFERENCES [dbo].[PrivateSeller] ([SeLLId])
GO
ALTER TABLE [dbo].[Feedbacks] CHECK CONSTRAINT [FK_SeLLId2]
GO
ALTER TABLE [dbo].[LastedNews]  WITH CHECK ADD  CONSTRAINT [FK_LastedNews_AdvId] FOREIGN KEY([AdvId])
REFERENCES [dbo].[Advertisement] ([AdvId])
GO
ALTER TABLE [dbo].[LastedNews] CHECK CONSTRAINT [FK_LastedNews_AdvId]
GO
ALTER TABLE [dbo].[PhotoDetail]  WITH CHECK ADD  CONSTRAINT [FK_AdvIdphoto] FOREIGN KEY([AdvId])
REFERENCES [dbo].[Advertisement] ([AdvId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PhotoDetail] CHECK CONSTRAINT [FK_AdvIdphoto]
GO
ALTER TABLE [dbo].[Street]  WITH CHECK ADD  CONSTRAINT [FK_Street_City] FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([CityId])
GO
ALTER TABLE [dbo].[Street] CHECK CONSTRAINT [FK_Street_City]
GO
ALTER TABLE [dbo].[Street]  WITH CHECK ADD  CONSTRAINT [FK_Street_district] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[District] ([DistrictId])
GO
ALTER TABLE [dbo].[Street] CHECK CONSTRAINT [FK_Street_district]
GO
ALTER TABLE [dbo].[Street]  WITH CHECK ADD  CONSTRAINT [FK_Street_ward] FOREIGN KEY([WardId])
REFERENCES [dbo].[Ward] ([WardId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Street] CHECK CONSTRAINT [FK_Street_ward]
GO
ALTER TABLE [dbo].[Ward]  WITH CHECK ADD  CONSTRAINT [FK_Ward_tocity] FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([CityId])
GO
ALTER TABLE [dbo].[Ward] CHECK CONSTRAINT [FK_Ward_tocity]
GO
ALTER TABLE [dbo].[Ward]  WITH CHECK ADD  CONSTRAINT [FK_Ward_Todistrict] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[District] ([DistrictId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ward] CHECK CONSTRAINT [FK_Ward_Todistrict]
GO
