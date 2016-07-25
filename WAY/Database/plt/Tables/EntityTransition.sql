CREATE TABLE [plt].[EntityTransition]
(
	[Id] INT NOT NULL,
	[ActionBeforeCode] INT,
	[ActionAfterCode] INT,
	[Order] TINYINT NOT NULL,
	[EntityStateFromId] INT,
	[EntityStateToId] INT NOT NULL,
	[IsSystem] BIT NOT NULL DEFAULT 0,
	[EntityLifecycleId] INT NOT NULL,
	CONSTRAINT [PK_EntityTransition] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_EntityTransition_EntityLifecycle] FOREIGN KEY ([EntityLifecycleId]) REFERENCES [plt].[EntityLifecycle] ([Id]),
	CONSTRAINT [FK_EntityTransition_EntityState_From] FOREIGN KEY ([EntityStateFromId]) REFERENCES [plt].[EntityState] ([Id]),
	CONSTRAINT [FK_EntityTransition_EntityState_To] FOREIGN KEY ([EntityStateToId]) REFERENCES [plt].[EntityState] ([Id])
)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_EntityTransition] ON [plt].[EntityTransition]
([EntityStateFromId], [EntityStateToId]) ON [PRIMARY]
GO