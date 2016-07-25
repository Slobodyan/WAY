CREATE TABLE [acc].[Article]
(
	[Id] INT NOT NULL IDENTITY(1, 1),
	[Title] NVARCHAR(128) NOT NULL,
	[Description] NVARCHAR(MAX) NOT NULL,
	[PublishedDateUtc] DATETIME NOT NULL,
	[Views] INT NOT NULL,
	[HasPhoto] BIT NOT NULL DEFAULT 0,
	[BloggerId] INT NOT NULL,
	[EntityInfoId] INT NOT NULL,
	CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Article_Blogger] FOREIGN KEY ([BloggerId]) REFERENCES [acc].[Blogger] ([Id]),
	CONSTRAINT [FK_Article_EntityInfo] FOREIGN KEY ([EntityInfoId]) REFERENCES [plt].[EntityInfo] ([Id])
)
