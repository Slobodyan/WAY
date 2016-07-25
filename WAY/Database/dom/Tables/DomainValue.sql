CREATE TABLE [dom].[DomainValue]
(
	[Id] INT NOT NULL IDENTITY(1, 1),
	[NameCode] INT,
	[DomailValueTypeId] INT NOT NULL,
	[IsActive] BIT NOT NULL,
	CONSTRAINT [PK_DomainValue] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_DomainValue_DomailValueTypeId] FOREIGN KEY ([DomailValueTypeId]) REFERENCES [dom].[DomainValueType] ([Id])
)