CREATE TABLE [acc].[TagEntity]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[TagId] INT NOT NULL,
	[EntityInfoId] INT NOT NULL,
	CONSTRAINT [PK_TagEntity] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_TagEntity_Tag] FOREIGN KEY ([TagId]) REFERENCES [acc].[Tag] ([Id]),
	CONSTRAINT [FK_TagEntity_EntityInfo] FOREIGN KEY ([EntityInfoId]) REFERENCES [plt].[EntityInfo] ([Id])
)
GO

CREATE NONCLUSTERED INDEX [IX_TagEntity_TagId]
ON [acc].[TagEntity] ([TagId])
INCLUDE ([EntityInfoId])
GO