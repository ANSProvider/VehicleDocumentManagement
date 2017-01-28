

CREATE TABLE [dbo].[tblCarDocumentDetails](
	[CarDocumentDetailID] [int] IDENTITY(1,1) NOT NULL,
	[CarRegistrationID] [int] NULL,
	[DocumentId] [int] NULL,
	[IssueDate] [datetime] NULL,
	[Validity] [int] NULL,
	[ExpireDate] [datetime] NULL,
	[RenewDate][datetime] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdateOn] [datetime] NULL,
 CONSTRAINT [PK_tblCarDocumentDetails] PRIMARY KEY CLUSTERED 
(
	[CarDocumentDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[tblDocumentMaster](
	[DocumentId] [int] NOT NULL,
	[DocumentName] [nvarchar](50) not NULL,
	[ValiditiyMonth] [int]  NULL
 CONSTRAINT [PK_tblDocumentMaster] PRIMARY KEY CLUSTERED 
(
	[DocumentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO





CREATE TABLE [dbo].[tblCarRegistration](
	[CarRegistrationID] [int] NOT NULL identity,
	[CustomerID] [int] NULL,
	[CarRegistrationNo] [varchar](50) NULL,	
	[DateOfRegistration] [datetime] NULL,
	[ChasissNo][varchar](50) NULL,
	[EngineNo][varchar](50) NULL,
	[MakerName][nvarchar](500) NULL,
	[Model][nvarchar](100) NULL,
	[MfgMonYear][nvarchar](100) NULL,
	[Type][nvarchar](100) NULL,
	[RTOName][nvarchar](100) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdateOn] [datetime] NULL,
 CONSTRAINT [PK_tblEstateRegistration] PRIMARY KEY CLUSTERED 
(
	[CarRegistrationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



CREATE TABLE [dbo].[tblUsers](
	[UName] [nvarchar](50) NOT NULL,
	[UPasswd] [nvarchar](50) NOT NULL,
	[EmailId] [nvarchar](50) NULL,
	[ContactNo] [nvarchar](50) NULL,
	[IsAdmin] [bit] NULL,

 CONSTRAINT [PK_tblUsers] PRIMARY KEY CLUSTERED 
(
	[UName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[tblCustomerDetails](
	[CustomerID] [int] NOT NULL identity,
	[CustomerName] [nvarchar](150) Not NULL,
	[CurrentAddress] [nvarchar](500) NULL,
	[PermantAddress] [nvarchar](500) NULL,
	[MobileNo] [varchar](50) NULL,
	[OfficeNo] [varchar](50) NULL,
	[EmailId] [nvarchar](50) NULL,
	[ContactPerson] [nvarchar](150) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_tblCustomerDetails] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO








