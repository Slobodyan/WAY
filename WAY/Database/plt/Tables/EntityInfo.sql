CREATE TABLE [plt].[EntityInfo]
(
	[Id] INT NOT NULL IDENTITY(1, 1),
	[Guid] UNIQUEIDENTIFIER NOT NULL,
	[CreatedDateUtc] DATETIME NOT NULL,
	[EntityTypeId] INT NOT NULL,
	[EntityStateId] INT NOT NULL,
	CONSTRAINT [PK_EntityInfo] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_EntityInfo_EntityType] FOREIGN KEY ([EntityTypeId]) REFERENCES [plt].[EntityType] ([Id]),
	CONSTRAINT [FK_EntityInfo_EntityState] FOREIGN KEY ([EntityStateId]) REFERENCES [plt].[EntityState] ([Id])
)
GO

CREATE NONCLUSTERED INDEX [IX_EntityInfo_EntityTypeId] ON [plt].[EntityInfo] ([EntityTypeId] ASC)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_EntityInfo_Guid] ON [plt].[EntityInfo] ([Guid] ASC)
GO

CREATE NONCLUSTERED INDEX [IX_EntityInfo_CreateDateUtc] ON [plt].[EntityInfo] ([CreatedDateUtc]) INCLUDE ([Id])