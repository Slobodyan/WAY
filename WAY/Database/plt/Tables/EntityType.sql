CREATE TABLE [plt].[EntityType]
(
	[Id] INT NOT NULL,
	[Name] VARCHAR(64),
	[EntityLifecycleId] INT NOT NULL,
	CONSTRAINT [PK_EntityType] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_EntityType_EntityLifecycle] FOREIGN KEY ([EntityLifecycleId]) REFERENCES [plt].[EntityLifecycle] ([Id])
)
