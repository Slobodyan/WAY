SET IDENTITY_INSERT [acc].[Blogger] ON
INSERT INTO [acc].[Blogger] ([Id], [Email], [Password], [Name], [EntityInfoId]) VALUES
(1, N'way.aslobodyan@gmail.com', N'aslobodyan', N'Andrii Slobodyan', 1),
(2, N'way.aolaru@gmail.com', N'aolaru', N'Anatolii Olaru', 2)
SET IDENTITY_INSERT [acc].[Blogger] OFF

GO

SET IDENTITY_INSERT [acc].[User] ON
INSERT INTO [acc].[User] ([Id], [Mobile], [Phone], [Skype], [FirstName], [LastName], [MiddleName], [ParentName], [BirthDate], [GenderId], [HasPhoto], [BloggerId]) VALUES
(1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1),
(2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 2)
SET IDENTITY_INSERT [acc].[User] OFF