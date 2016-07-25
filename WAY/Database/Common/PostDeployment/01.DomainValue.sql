SET IDENTITY_INSERT [dom].[DomainValueType] ON
INSERT INTO [dom].[DomainValueType] ([Id], [Name]) VALUES
(1, 'Language'),
(2, 'Country'),
(3, 'Gender')
SET IDENTITY_INSERT [dom].[DomainValueType] OFF

GO

SET IDENTITY_INSERT [dom].[DomainValue] ON
INSERT INTO [dom].[DomainValue] ([Id], [NameCode], [IsActive], [DomailValueTypeId]) VALUES
--Language
--1-10
(1, 1, 1, 1), --UA
(2, 2, 1, 1), --EN
--Country
--11-240
 
--Gender
--241-243
(241, 241, 1, 3), --Male
(242, 242, 1, 3), --Female
(243, 243, 1, 3) --Unknown
SET IDENTITY_INSERT [dom].[DomainValue] OFF
