CREATE TABLE [acc].[Blogger]
(
	[Id] INT NOT NULL IDENTITY(1, 1),
	[Email] NVARCHAR(128) NOT NULL,
	[Password] NVARCHAR(MAX) NOT NULL,
	[Name] NVARCHAR(128),
	[EntityInfoId] INT NOT NULL,
	CONSTRAINT [PK_Blogger] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Blogger_EntityInfo] FOREIGN KEY ([EntityInfoId]) REFERENCES [plt].[EntityInfo] ([Id])
)
