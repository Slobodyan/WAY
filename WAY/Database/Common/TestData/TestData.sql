--Articles
SET IDENTITY_INSERT [plt].[EntityInfo] ON
INSERT INTO [plt].[EntityInfo] ([Id], [Guid], [EntityTypeId], [EntityStateId], [CreatedDateUtc]) VALUES
(1001, 'B90AD8CD-494C-4434-80DA-149941B21A0F', 4, 2, GETUTCDATE()),
(1002, NEWID(), 4, 2, GETUTCDATE()),
(1003, NEWID(), 4, 2, GETUTCDATE()),
(1004, NEWID(), 4, 2, GETUTCDATE()),
(1005, NEWID(), 4, 2, GETUTCDATE()),
(1006, NEWID(), 4, 2, GETUTCDATE()),
(1007, NEWID(), 4, 2, GETUTCDATE()),
(1008, NEWID(), 4, 2, GETUTCDATE()),
(1009, NEWID(), 4, 2, GETUTCDATE()),
(1010, NEWID(), 4, 2, GETUTCDATE()),
(1011, NEWID(), 4, 2, GETUTCDATE()),
(1012, NEWID(), 4, 2, GETUTCDATE()),
(1013, NEWID(), 4, 2, GETUTCDATE()),
(1014, NEWID(), 4, 2, GETUTCDATE()),
(1015, NEWID(), 4, 2, GETUTCDATE()),
(1016, NEWID(), 4, 2, GETUTCDATE()),
(1017, NEWID(), 4, 2, GETUTCDATE()),
(1018, NEWID(), 4, 2, GETUTCDATE()),
(1019, NEWID(), 4, 2, GETUTCDATE()),
(1020, NEWID(), 4, 2, GETUTCDATE()),
(1021, NEWID(), 4, 2, GETUTCDATE()),
(1022, NEWID(), 4, 2, GETUTCDATE()),
(1023, NEWID(), 4, 2, GETUTCDATE()),
(1024, NEWID(), 4, 2, GETUTCDATE()),
(1025, NEWID(), 4, 2, GETUTCDATE()),
(1026, NEWID(), 4, 2, GETUTCDATE()),
(1027, NEWID(), 4, 2, GETUTCDATE()),
(1028, NEWID(), 4, 2, GETUTCDATE()),
(1029, NEWID(), 4, 2, GETUTCDATE()),
(1030, NEWID(), 4, 2, GETUTCDATE())
SET IDENTITY_INSERT [plt].[EntityInfo] OFF

GO

SET IDENTITY_INSERT [acc].[Article] ON
INSERT INTO [acc].[Article] ([Id], [PublishedDateUtc], [Views], [BloggerId], [EntityInfoId], [HasPhoto], [Title], [Description]) VALUES
(1001, GETUTCDATE(), 0, 1, 1001, 1, N'c# 6.0', N'some text about c# 6.0'),
(1002, GETUTCDATE(), 0, 2, 1002, 0, N'entity framework 7', N'some text about entity framework 7'),
(1003, GETUTCDATE(), 0, 1, 1003, 0, N'.net core', N'some text about .net core'),
(1004, GETUTCDATE(), 0, 2, 1004, 0, N'asp.net 5', N'some text about asp.net 5'),
(1005, GETUTCDATE(), 0, 1, 1005, 0, N'some title', N'some test description about .net core. Test #1000000000000000000000000000000000000000000000000000000000000000000000000000000dsfgjsdakgjlgjafdsfs 2352523523                                  sdfsdf sdfsdf s11'),
(1006, GETUTCDATE(), 0, 2, 1006, 0, N'some title', N'some test description about .net core. Test #1000000000000000000000000000000000000000000000000000000000000000000000000000000dsfgjsdakgjlgjafdsfs 2352523523                                  sdfsdf sdfsdf s12'),
(1007, GETUTCDATE(), 0, 1, 1007, 0, N'some title', N'some test description about .net core. Test #1000000000000000000000000000000000000000000000000000000000000000000000000000000dsfgjsdakgjlgjafdsfs 2352523523                                  sdfsdf sdfsdf s13'),
(1008, GETUTCDATE(), 0, 2, 1008, 0, N'some title', N'some test description about .net core. Test #1000000000000000000000000000000000000000000000000000000000000000000000000000000dsfgjsdakgjlgjafdsfs 2352523523                                  sdfsdf sdfsdf s14'),
(1009, GETUTCDATE(), 0, 1, 1009, 0, N'some title', N'some test description about .net core. Test #1000000000000000000000000000000000000000000000000000000000000000000000000000000dsfgjsdakgjlgjafdsfs 2352523523                                  sdfsdf sdfsdf s15'),
(1010, GETUTCDATE(), 0, 2, 1010, 0, N'some title', N'some test description about .net core. Test #1000000000000000000000000000000000000000000000000000000000000000000000000000000dsfgjsdakgjlgjafdsfs 2352523523                                  sdfsdf sdfsdf s16'),
(1011, GETUTCDATE(), 0, 1, 1011, 0, N'some title', N'some test description about .net core. Test #1000000000000000000000000000000000000000000000000000000000000000000000000000000dsfgjsdakgjlgjafdsfs 2352523523                                  sdfsdf sdfsdf s17'),
(1012, GETUTCDATE(), 0, 2, 1012, 0, N'some title', N'some test description about .net core. Test #1000000000000000000000000000000000000000000000000000000000000000000000000000000dsfgjsdakgjlgjafdsfs 2352523523                                  sdfsdf sdfsdf s18'),
(1013, GETUTCDATE(), 0, 1, 1013, 0, N'some title', N'some test description about .net core. Test #1000000000000000000000000000000000000000000000000000000000000000000000000000000dsfgjsdakgjlgjafdsfs 2352523523                                  sdfsdf sdfsdf s19'),
(1014, GETUTCDATE(), 0, 2, 1014, 0, N'some title', N'some test description about .net core. Test #1000000000000000000000000000000000000000000000000000000000000000000000000000000dsfgjsdakgjlgjafdsfs 2352523523                                  sdfsdf sdfsdf s20'),
(1015, GETUTCDATE(), 0, 1, 1015, 0, N'some title', N'some test description about .net core. Test #1000000000000000000000000000000000000000000000000000000000000000000000000000000dsfgjsdakgjlgjafdsfs 2352523523                                  sdfsdf sdfsdf s21'),
(1016, GETUTCDATE(), 0, 2, 1016, 0, N'some title', N'some test description about .net core. Test #1000000000000000000000000000000000000000000000000000000000000000000000000000000dsfgjsdakgjlgjafdsfs 2352523523                                  sdfsdf sdfsdf s22'),
(1017, GETUTCDATE(), 0, 1, 1017, 0, N'some title', N'some test description about .net core. Test #1000000000000000000000000000000000000000000000000000000000000000000000000000000dsfgjsdakgjlgjafdsfs 2352523523                                  sdfsdf sdfsdf s23'),
(1018, GETUTCDATE(), 0, 2, 1018, 0, N'some title', N'some test description about .net core. Test #1000000000000000000000000000000000000000000000000000000000000000000000000000000dsfgjsdakgjlgjafdsfs 2352523523                                  sdfsdf sdfsdf s24'),
(1019, GETUTCDATE(), 0, 1, 1019, 0, N'some title', N'some test description about .net core. Test #1000000000000000000000000000000000000000000000000000000000000000000000000000000dsfgjsdakgjlgjafdsfs 2352523523                                  sdfsdf sdfsdf s25'),
(1020, GETUTCDATE(), 0, 2, 1020, 0, N'some title', N'some test description about .net core. Test #1000000000000000000000000000000000000000000000000000000000000000000000000000000dsfgjsdakgjlgjafdsfs 2352523523                                  sdfsdf sdfsdf s26'),
(1021, GETUTCDATE(), 0, 1, 1021, 0, N'some title', N'some test description about .net core. Test #1000000000000000000000000000000000000000000000000000000000000000000000000000000dsfgjsdakgjlgjafdsfs 2352523523                                  sdfsdf sdfsdf s27'),
(1022, GETUTCDATE(), 0, 2, 1022, 0, N'some title', N'some test description about .net core. Test #1000000000000000000000000000000000000000000000000000000000000000000000000000000dsfgjsdakgjlgjafdsfs 2352523523                                  sdfsdf sdfsdf s28'),
(1023, GETUTCDATE(), 0, 1, 1023, 0, N'some title', N'some test description about .net core. Test #1000000000000000000000000000000000000000000000000000000000000000000000000000000dsfgjsdakgjlgjafdsfs 2352523523                                  sdfsdf sdfsdf s29'),
(1024, GETUTCDATE(), 0, 2, 1024, 0, N'some title', N'some test description about .net core. Test #1000000000000000000000000000000000000000000000000000000000000000000000000000000dsfgjsdakgjlgjafdsfs 2352523523                                  sdfsdf sdfsdf s20'),
(1025, GETUTCDATE(), 0, 1, 1025, 0, N'some title', N'some test description about .net core. Test #1000000000000000000000000000000000000000000000000000000000000000000000000000000dsfgjsdakgjlgjafdsfs 2352523523                                  sdfsdf sdfsdf s31'),
(1026, GETUTCDATE(), 0, 2, 1026, 0, N'some title', N'some test description about .net core. Test #1000000000000000000000000000000000000000000000000000000000000000000000000000000dsfgjsdakgjlgjafdsfs 2352523523                                  sdfsdf sdfsdf s32'),
(1027, GETUTCDATE(), 0, 1, 1027, 0, N'some title', N'some test description about .net core. Test #1000000000000000000000000000000000000000000000000000000000000000000000000000000dsfgjsdakgjlgjafdsfs 2352523523                                  sdfsdf sdfsdf s33'),
(1028, GETUTCDATE(), 0, 2, 1028, 0, N'some title', N'some test description about .net core. Test #1000000000000000000000000000000000000000000000000000000000000000000000000000000dsfgjsdakgjlgjafdsfs 2352523523                                  sdfsdf sdfsdf s34'),
(1029, GETUTCDATE(), 0, 1, 1029, 0, N'some title', N'some test description about .net core. Test #1000000000000000000000000000000000000000000000000000000000000000000000000000000dsfgjsdakgjlgjafdsfs 2352523523                                  sdfsdf sdfsdf s35'),
(1030, GETUTCDATE(), 0, 2, 1030, 0, N'some title', N'some test description about .net core. Test #1000000000000000000000000000000000000000000000000000000000000000000000000000000dsfgjsdakgjlgjafdsfs 2352523523                                  sdfsdf sdfsdf s36')
SET IDENTITY_INSERT [acc].[Article] OFF

SET IDENTITY_INSERT [acc].[Comment] ON
INSERT INTO [acc].[Comment] ([Id], [EntityInfoId], [BloggerId], [BloggerName], [DateTimeUtc], [IsDeleted], [Message]) VALUES
(1001, 1001, 1, N'Andrii',		GETUTCDATE(), 0, N'Cool'),
(1002, 1001, 2, N'Tolia',		GETUTCDATE(), 0, N'Some new information, thanks'),
(1003, 1001, 1, N'Andrii',		GETUTCDATE(), 1, N'some comment about asp.net 5'),
(1004, 1004, 2, N'Tolia',		GETUTCDATE(), 0, N'some comment about asp.net 5')
SET IDENTITY_INSERT [acc].[Comment] OFF

