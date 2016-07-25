CREATE TABLE [plt].[EntityState]
(
	[Id] INT NOT NULL,
	[NameCode] INT,
	[Order] TINYINT NOT NULL,
	[IsStart] BIT NOT NULL,
	[IsFinish] BIT NOT NULL,
	[IsActive] BIT NOT NULL,
	[IsSystem] BIT NOT NULL DEFAULT(0),
	[EntityLifecycleId] INT NOT NULL,
	CONSTRAINT [PK_EntityState] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_EntityState_EntityLifecycle] FOREIGN KEY ([EntityLifecycleId]) REFERENCES [plt].[EntityLifecycle] ([Id])
)
