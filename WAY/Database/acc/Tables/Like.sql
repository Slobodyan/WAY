CREATE TABLE [acc].[Like]
(
	[Id] INT NOT NULL IDENTITY(1, 1),
	[EntityInfoId] INT NOT NULL,
	[BloggerId] INT NOT NULL,
	[DateTimeUtc] DATETIME NOT NULL,
	[IsDislike] BIT NOT NULL DEFAULT 0,
	CONSTRAINT [PK_Like] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Like_EntityInfo] FOREIGN KEY ([EntityInfoId]) REFERENCES [plt].[EntityInfo] ([Id]),
	CONSTRAINT [FK_Like_Blogger] FOREIGN KEY ([BloggerId]) REFERENCES [acc].[Blogger] ([Id])
)