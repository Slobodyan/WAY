CREATE TABLE [acc].[User]
(
	[Id] INT NOT NULL IDENTITY(1, 1),
	[Mobile] VARCHAR(32),
	[Phone] VARCHAR(32),
	[Skype] NVARCHAR(128),
	[FirstName] NVARCHAR(64),
	[LastName] NVARCHAR(64),
	[MiddleName] NVARCHAR(32),
	[ParentName] NVARCHAR(64),
	[BirthDate] DATETIME,
	[GenderId] INT,
	[HasPhoto] BIT NOT NULL DEFAULT 0,
	[BloggerId] INT NOT NULL,
	CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_User_Blogger] FOREIGN KEY ([BloggerId]) REFERENCES [acc].[Blogger] ([Id]),
	CONSTRAINT [FK_User_Gender] FOREIGN KEY ([GenderId]) REFERENCES [dom].[DomainValue] ([Id])
)
GO
