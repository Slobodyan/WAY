CREATE TABLE [acc].[Address]
(
	[Id] INT NOT NULL IDENTITY(1, 1),
	[CountryId] INT NOT NULL,
	[City] NVARCHAR(256),
	[PostalCode] NVARCHAR(16),
	[Street] NVARCHAR(256),
	[Number] NVARCHAR(16),
	[Unit] NVARCHAR(32),
	[Latitude] FLOAT NOT NULL,
	[Longitude] FLOAT NOT NULL,
	[BloggerId] INT NOT NULL,
	[IsPrimary] BIT NOT NULL DEFAULT(0),
	CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Address_Country] FOREIGN KEY ([CountryId]) REFERENCES [dom].[DomainValue] ([Id]),
	CONSTRAINT [FK_Address_Blogger] FOREIGN KEY ([BloggerId]) REFERENCES [acc].[Blogger] ([Id])
)
