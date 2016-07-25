CREATE TABLE [acc].[Website]
(
	[Id] INT NOT NULL IDENTITY(1, 1),
	[Url] NVARCHAR(256) NOT NULL,
	[BloggerId] INT NOT NULL,
	[IsPrimary] BIT NOT NULL DEFAULT(0),
	CONSTRAINT [PK_Website] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Website_Blogger] FOREIGN KEY ([BloggerId]) REFERENCES [acc].[Blogger] ([Id])
)
