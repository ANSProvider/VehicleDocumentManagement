CREATE TABLE [dbo].[Users](
	Uniqueid numeric(18,0) identity(1,1),
	[UserName] [nvarchar](150) NOT NULL,
	[Password] [nvarchar](150) NULL,
	[Role] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
Insert into Users Values('admin','123','admin')
Insert into Users Values('user','123','user')


