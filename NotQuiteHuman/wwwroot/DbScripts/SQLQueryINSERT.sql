USE [EfCoreLocal]
GO
SET IDENTITY_INSERT [dbo].[AbilityScoreBonus] ON 
GO
INSERT [dbo].[AbilityScoreBonus] ([Id], [Strength], [Dexterity], [Constitution], [Intelligence], [Wisdom], [Charisma]) VALUES (1, 0, 0, 0, 0, 0, 0)
GO
INSERT [dbo].[AbilityScoreBonus] ([Id], [Strength], [Dexterity], [Constitution], [Intelligence], [Wisdom], [Charisma]) VALUES (2, 2, 2, 0, 2, 2, 2)
GO
INSERT [dbo].[AbilityScoreBonus] ([Id], [Strength], [Dexterity], [Constitution], [Intelligence], [Wisdom], [Charisma]) VALUES (3, 1, 1, 0, 1, 1, 1)
GO
INSERT [dbo].[AbilityScoreBonus] ([Id], [Strength], [Dexterity], [Constitution], [Intelligence], [Wisdom], [Charisma]) VALUES (4, 1, 1, 1, 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[AbilityScoreBonus] OFF
GO
SET IDENTITY_INSERT [dbo].[Race] ON 
GO
INSERT [dbo].[Race] ([Id], [Name], [AbilityScoreBonusId], [Size], [WalkSpeed], [SwimSpeed], [FlySpeed], [ClimbSpeed], [CreatureType]) VALUES (13, N'TestRace', 1, N'Medium', 0, 0, 0, 0, N'Humanoid')
GO
INSERT [dbo].[Race] ([Id], [Name], [AbilityScoreBonusId], [Size], [WalkSpeed], [SwimSpeed], [FlySpeed], [ClimbSpeed], [CreatureType]) VALUES (14, N'TestRace2', 1, N'Large', 0, 0, 0, 0, N'Dragon')
GO
INSERT [dbo].[Race] ([Id], [Name], [AbilityScoreBonusId], [Size], [WalkSpeed], [SwimSpeed], [FlySpeed], [ClimbSpeed], [CreatureType]) VALUES (15, N'TestRace3', 4, N'Medium', 0, 0, 0, 0, N'Humanoid')
GO
SET IDENTITY_INSERT [dbo].[Race] OFF
GO
SET IDENTITY_INSERT [dbo].[Language] ON 
GO
INSERT [dbo].[Language] ([Id], [Name], [Type], [Description]) VALUES (1, N'Common', N'common', N'human language test')
GO
INSERT [dbo].[Language] ([Id], [Name], [Type], [Description]) VALUES (1002, N'lan2', N'common', N'test')
GO
INSERT [dbo].[Language] ([Id], [Name], [Type], [Description]) VALUES (1003, N'test', N'common', N'test')
GO
INSERT [dbo].[Language] ([Id], [Name], [Type], [Description]) VALUES (1004, N'Elvish', N'common', N'Elvish language')
GO
INSERT [dbo].[Language] ([Id], [Name], [Type], [Description]) VALUES (1005, N'lan3', N'common', N'test')
GO
INSERT [dbo].[Language] ([Id], [Name], [Type], [Description]) VALUES (1006, N'lan4', N'common', N'test')
GO
SET IDENTITY_INSERT [dbo].[Language] OFF
GO
SET IDENTITY_INSERT [dbo].[RaceLanguage] ON 
GO
INSERT [dbo].[RaceLanguage] ([Id], [RaceId], [LanguageId]) VALUES (25, 13, 1)
GO
INSERT [dbo].[RaceLanguage] ([Id], [RaceId], [LanguageId]) VALUES (26, 13, 1002)
GO
INSERT [dbo].[RaceLanguage] ([Id], [RaceId], [LanguageId]) VALUES (27, 13, 1005)
GO
INSERT [dbo].[RaceLanguage] ([Id], [RaceId], [LanguageId]) VALUES (28, 14, 1)
GO
INSERT [dbo].[RaceLanguage] ([Id], [RaceId], [LanguageId]) VALUES (29, 14, 1005)
GO
INSERT [dbo].[RaceLanguage] ([Id], [RaceId], [LanguageId]) VALUES (30, 14, 1006)
GO
INSERT [dbo].[RaceLanguage] ([Id], [RaceId], [LanguageId]) VALUES (31, 15, 1002)
GO
INSERT [dbo].[RaceLanguage] ([Id], [RaceId], [LanguageId]) VALUES (32, 15, 1005)
GO
INSERT [dbo].[RaceLanguage] ([Id], [RaceId], [LanguageId]) VALUES (33, 15, 1006)
GO
INSERT [dbo].[RaceLanguage] ([Id], [RaceId], [LanguageId]) VALUES (34, 15, 1)
GO
INSERT [dbo].[RaceLanguage] ([Id], [RaceId], [LanguageId]) VALUES (35, 15, 1)
GO
INSERT [dbo].[RaceLanguage] ([Id], [RaceId], [LanguageId]) VALUES (36, 15, 1)
GO
SET IDENTITY_INSERT [dbo].[RaceLanguage] OFF
GO
SET IDENTITY_INSERT [dbo].[Trait] ON 
GO
INSERT [dbo].[Trait] ([Id], [Name], [Description]) VALUES (1, N'trait1', N'description1')
GO
INSERT [dbo].[Trait] ([Id], [Name], [Description]) VALUES (2, N'trait2', N'description2')
GO
INSERT [dbo].[Trait] ([Id], [Name], [Description]) VALUES (3, N'trait3', N'description3')
GO
INSERT [dbo].[Trait] ([Id], [Name], [Description]) VALUES (4, N'trait4', N'description4')
GO
INSERT [dbo].[Trait] ([Id], [Name], [Description]) VALUES (5, N'trait5', N'description5')
GO
INSERT [dbo].[Trait] ([Id], [Name], [Description]) VALUES (6, N'trait6', N'description6')
GO
INSERT [dbo].[Trait] ([Id], [Name], [Description]) VALUES (9, N'trait8', N'asdfl;kjas;dflkjas;dlfkjasd;lf kjasd;flkjasd;flkjasd ;lfkjas;dlfkjas ;dlkfjas;ldkfjas;ldkfja;s lkfjas;dlfkjas;ldkfja;s dlkfjas;dlkfja;sdl kfjas;dlk fjas;ldkfja;sldkfj')
GO
SET IDENTITY_INSERT [dbo].[Trait] OFF
GO
SET IDENTITY_INSERT [dbo].[RaceTrait] ON 
GO
INSERT [dbo].[RaceTrait] ([Id], [RaceId], [TraitId]) VALUES (15, 13, 1)
GO
INSERT [dbo].[RaceTrait] ([Id], [RaceId], [TraitId]) VALUES (16, 13, 2)
GO
INSERT [dbo].[RaceTrait] ([Id], [RaceId], [TraitId]) VALUES (17, 14, 3)
GO
INSERT [dbo].[RaceTrait] ([Id], [RaceId], [TraitId]) VALUES (18, 14, 3)
GO
INSERT [dbo].[RaceTrait] ([Id], [RaceId], [TraitId]) VALUES (19, 15, 4)
GO
INSERT [dbo].[RaceTrait] ([Id], [RaceId], [TraitId]) VALUES (20, 15, 5)
GO
INSERT [dbo].[RaceTrait] ([Id], [RaceId], [TraitId]) VALUES (21, 15, 1)
GO
INSERT [dbo].[RaceTrait] ([Id], [RaceId], [TraitId]) VALUES (22, 15, 1)
GO
SET IDENTITY_INSERT [dbo].[RaceTrait] OFF
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'3d76eb14-0e32-406c-81ad-ecc158a3056d', N'user', N'USER', N'd7eb9bda-8bd0-4886-9d55-47060aab0e63')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'd2b03cf1-46aa-43ea-b19f-c300b4998e7b', N'admin', N'ADMIN', N'f932e7fa-0f50-4a4d-b09d-01a66bc75e3a')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'1f0bec1c-ae5d-4750-a7c5-a80af6bcf2f9', N'Admin@Admin.com', N'ADMIN@ADMIN.COM', N'Admin@Admin.com', N'ADMIN@ADMIN.COM', 0, N'AQAAAAEAACcQAAAAEExxWFDHrriE9QvWopalTteGhdK/t1a2z2KJ6P4WT/ZhWtw3jSYESeEHXNvrwlpOpw==', N'P33WJPWYCDWMSFHXLPQ3LUG5HRNJZM3N', N'6b0f146b-5e64-48dd-80ab-339e61faabbe', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'5416f9e3-3285-410d-90cf-756dfaa8d40c', N'verwimp.lennert99@gmail.com', N'VERWIMP.LENNERT99@GMAIL.COM', N'verwimp.lennert99@gmail.com', N'VERWIMP.LENNERT99@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEN1MbL2NMFtq/hSYirE3UDiop++OAmyrrk4gXUK4GxGjiLtn++fODYlewG8gOryIBw==', N'NWJ5FSOWIWGVJTIALJLHT3QA6BIKHTUR', N'634e2d73-fe63-48e2-924a-4eb0dc278619', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1f0bec1c-ae5d-4750-a7c5-a80af6bcf2f9', N'd2b03cf1-46aa-43ea-b19f-c300b4998e7b')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221216142715_InitialCreate', N'3.1.32')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221216144914_AddIdentitySchema', N'3.1.32')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221216150135_IdentityUser', N'3.1.32')
GO
