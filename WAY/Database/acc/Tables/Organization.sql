CREATE TABLE [acc].[Organization]
(
	[Id] INT NOT NULL IDENTITY(1, 1),
	[Name] NVARCHAR(256),
	[Description] NVARCHAR(MAX),
	[HasPhoto] BIT NOT NULL DEFAULT(0),
	[BloggerId] INT NOT NULL,
	CONSTRAINT [PK_Organization] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Organization_Blogger] FOREIGN KEY ([BloggerId]) REFERENCES [acc].[Blogger] ([Id])
)
GO
