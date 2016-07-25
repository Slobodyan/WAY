CREATE TABLE [acc].[Comment]
(
	[Id] INT NOT NULL IDENTITY(1, 1),
	[EntityInfoId] INT NOT NULL,
	[BloggerId] INT NOT NULL,
	[BloggerName] NVARCHAR(256),
	[DateTimeUtc] DATETIME NOT NULL,
	[Message] NVARCHAR(MAX) NOT NULL,
	[IsDeleted] BIT NOT NULL DEFAULT 0,
	CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Comment_EntityInfo] FOREIGN KEY ([EntityInfoId]) REFERENCES [plt].[EntityInfo] ([Id]),
	CONSTRAINT [FK_Comment_Blogger] FOREIGN KEY ([BloggerId]) REFERENCES [acc].[Blogger] ([Id])
)