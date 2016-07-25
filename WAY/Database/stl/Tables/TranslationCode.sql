CREATE TABLE [stl].[TranslationCode]
(
	[Id] INT NOT NULL IDENTITY(1, 1),
	[Name] VARCHAR(128),
	[Description] VARCHAR(512)
	CONSTRAINT [PK_TranslationCode] PRIMARY KEY CLUSTERED ([Id])
)
