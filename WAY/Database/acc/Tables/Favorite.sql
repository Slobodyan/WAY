CREATE TABLE [acc].[Favorite]
(
	[Id] INT NOT NULL IDENTITY(1, 1),
	[EntityInfoId] INT NOT NULL,
	[BloggerId] INT NOT NULL,
	[DateTimeUtc] DATETIME NOT NULL,
	CONSTRAINT [PK_Favorite] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Favorite_EntityInfo] FOREIGN KEY ([EntityInfoId]) REFERENCES [plt].[EntityInfo] ([Id]),
	CONSTRAINT [FK_Favorite_Blogger] FOREIGN KEY ([BloggerId]) REFERENCES [acc].[Blogger] ([Id])
)