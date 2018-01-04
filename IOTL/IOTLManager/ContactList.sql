CREATE TABLE [dbo].[ContactList]
(
	[ContactID] INT NOT NULL PRIMARY KEY IDentity (1,1),
	[ContactName] nvarchar(200) NULL,
	[CompanyName] nvarchar(200) NULL,
	[PhoneNo] nvarchar(20) NULL,
	[EMailAddress] nvarchar(100) NULL,
	[IsClient] bit NULL,
	[LastCall] datetime NULL
)
