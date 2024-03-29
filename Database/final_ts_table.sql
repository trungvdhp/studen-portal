ALTER TABLE [dbo].[webpages_UsersInRoles] DROP CONSTRAINT [fk_UserId]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] DROP CONSTRAINT [fk_RoleId]
GO
ALTER TABLE [dbo].[webpages_Membership] DROP CONSTRAINT [DF__webpages___Passw__4C0DFA54]
GO
ALTER TABLE [dbo].[webpages_Membership] DROP CONSTRAINT [DF__webpages___IsCon__4B19D61B]
GO
/****** Object:  Index [UQ__webpages__8A2B6160465520FE]    Script Date: 10/01/2014 11:34:11 AM ******/
ALTER TABLE [dbo].[webpages_Roles] DROP CONSTRAINT [UQ__webpages__8A2B6160465520FE]
GO
/****** Object:  Index [UQ__UserProf__C9F284562375F915]    Script Date: 10/01/2014 11:34:11 AM ******/
ALTER TABLE [dbo].[UserProfile] DROP CONSTRAINT [UQ__UserProf__C9F284562375F915]
GO
/****** Object:  Table [dbo].[webpages_UsersInRoles]    Script Date: 10/01/2014 11:34:11 AM ******/
DROP TABLE [dbo].[webpages_UsersInRoles]
GO
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 10/01/2014 11:34:11 AM ******/
DROP TABLE [dbo].[webpages_Roles]
GO
/****** Object:  Table [dbo].[webpages_OAuthMembership]    Script Date: 10/01/2014 11:34:11 AM ******/
DROP TABLE [dbo].[webpages_OAuthMembership]
GO
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 10/01/2014 11:34:11 AM ******/
DROP TABLE [dbo].[webpages_Membership]
GO
/****** Object:  Table [dbo].[webpages_Log]    Script Date: 10/01/2014 11:34:11 AM ******/
DROP TABLE [dbo].[webpages_Log]
GO
/****** Object:  Table [dbo].[webpages_Groups_Roles]    Script Date: 10/01/2014 11:34:11 AM ******/
DROP TABLE [dbo].[webpages_Groups_Roles]
GO
/****** Object:  Table [dbo].[webpages_Group]    Script Date: 10/01/2014 11:34:11 AM ******/
DROP TABLE [dbo].[webpages_Group]
GO
/****** Object:  Table [dbo].[webpages_CauHinh]    Script Date: 10/01/2014 11:34:11 AM ******/
DROP TABLE [dbo].[webpages_CauHinh]
GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 10/01/2014 11:34:11 AM ******/
DROP TABLE [dbo].[UserProfile]
GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 10/01/2014 11:34:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfile](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](56) NOT NULL,
	[GroupId] [int] NOT NULL,
 CONSTRAINT [PK__UserProf__1788CC4C0D86B7F6] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_CauHinh]    Script Date: 10/01/2014 11:34:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[webpages_CauHinh](
	[Ten] [nvarchar](100) NOT NULL,
	[Gia_tri] [text] NULL,
	[Kieu] [varchar](50) NULL,
	[Ky_dang_ky] [int] NULL,
	[Mo_ta] [nvarchar](300) NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_webpage_configs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[webpages_Group]    Script Date: 10/01/2014 11:34:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Group](
	[GroupId] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](256) NULL,
 CONSTRAINT [PK__webpages__149AF36A67961938] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_Groups_Roles]    Script Date: 10/01/2014 11:34:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Groups_Roles](
	[GroupId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_webpages_Groups_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_Log]    Script Date: 10/01/2014 11:34:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[webpages_Log](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Thao_tac] [nvarchar](300) NULL,
	[Tham_so] [nvarchar](300) NULL,
	[Thoi_gian] [datetime] NULL,
	[User_id] [int] NULL,
	[Ip] [varchar](50) NULL,
 CONSTRAINT [PK_webpages_Log] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 10/01/2014 11:34:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Membership](
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[ConfirmationToken] [nvarchar](128) NULL,
	[IsConfirmed] [bit] NULL,
	[LastPasswordFailureDate] [datetime] NULL,
	[PasswordFailuresSinceLastSuccess] [int] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordChangedDate] [datetime] NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[PasswordVerificationToken] [nvarchar](128) NULL,
	[PasswordVerificationTokenExpirationDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_OAuthMembership]    Script Date: 10/01/2014 11:34:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_OAuthMembership](
	[Provider] [nvarchar](30) NOT NULL,
	[ProviderUserId] [nvarchar](100) NOT NULL,
	[UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Provider] ASC,
	[ProviderUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 10/01/2014 11:34:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
	[DisplayName] [nvarchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_UsersInRoles]    Script Date: 10/01/2014 11:34:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_UsersInRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[UserProfile] ON 

INSERT [dbo].[UserProfile] ([UserId], [UserName], [GroupId]) VALUES (1, N'34061', 1)
INSERT [dbo].[UserProfile] ([UserId], [UserName], [GroupId]) VALUES (2, N'40471', 2)
INSERT [dbo].[UserProfile] ([UserId], [UserName], [GroupId]) VALUES (3, N'33321', 2)
INSERT [dbo].[UserProfile] ([UserId], [UserName], [GroupId]) VALUES (4, N'47136', 2)
INSERT [dbo].[UserProfile] ([UserId], [UserName], [GroupId]) VALUES (5, N'34057', 2)
INSERT [dbo].[UserProfile] ([UserId], [UserName], [GroupId]) VALUES (6, N'37213', 2)
INSERT [dbo].[UserProfile] ([UserId], [UserName], [GroupId]) VALUES (9, N'42376', 2)
INSERT [dbo].[UserProfile] ([UserId], [UserName], [GroupId]) VALUES (10, N'Hệ thống', 1)
INSERT [dbo].[UserProfile] ([UserId], [UserName], [GroupId]) VALUES (12, N'guest', 7)
INSERT [dbo].[UserProfile] ([UserId], [UserName], [GroupId]) VALUES (13, N'10103', 6)
INSERT [dbo].[UserProfile] ([UserId], [UserName], [GroupId]) VALUES (14, N'45123', 2)
INSERT [dbo].[UserProfile] ([UserId], [UserName], [GroupId]) VALUES (15, N'32145', 2)
INSERT [dbo].[UserProfile] ([UserId], [UserName], [GroupId]) VALUES (16, N'41204', 2)
INSERT [dbo].[UserProfile] ([UserId], [UserName], [GroupId]) VALUES (17, N'32121', 2)
INSERT [dbo].[UserProfile] ([UserId], [UserName], [GroupId]) VALUES (18, N'35416', 2)
INSERT [dbo].[UserProfile] ([UserId], [UserName], [GroupId]) VALUES (19, N'34049', 2)
INSERT [dbo].[UserProfile] ([UserId], [UserName], [GroupId]) VALUES (20, N'34026', 2)
INSERT [dbo].[UserProfile] ([UserId], [UserName], [GroupId]) VALUES (21, N'34601', 2)
INSERT [dbo].[UserProfile] ([UserId], [UserName], [GroupId]) VALUES (22, N'36401', 2)
INSERT [dbo].[UserProfile] ([UserId], [UserName], [GroupId]) VALUES (23, N'34610', 2)
INSERT [dbo].[UserProfile] ([UserId], [UserName], [GroupId]) VALUES (24, N'37172', 2)
SET IDENTITY_INSERT [dbo].[UserProfile] OFF
SET IDENTITY_INSERT [dbo].[webpages_CauHinh] ON 

INSERT [dbo].[webpages_CauHinh] ([Ten], [Gia_tri], [Kieu], [Ky_dang_ky], [Mo_ta], [Id]) VALUES (N'GiangVien_Group', N'6', N'int', 0, N'ID nhóm Giảng viên', 1)
INSERT [dbo].[webpages_CauHinh] ([Ten], [Gia_tri], [Kieu], [Ky_dang_ky], [Mo_ta], [Id]) VALUES (N'Guest_Password', N'21021004~!@#', N'string', 0, N'Mật khẩu tài khoản Guest', 2)
INSERT [dbo].[webpages_CauHinh] ([Ten], [Gia_tri], [Kieu], [Ky_dang_ky], [Mo_ta], [Id]) VALUES (N'Guest_UserName', N'guest', N'string', 0, N'Tên đăng nhập tài khoản Guest', 3)
INSERT [dbo].[webpages_CauHinh] ([Ten], [Gia_tri], [Kieu], [Ky_dang_ky], [Mo_ta], [Id]) VALUES (N'So_TC_CC_max', N'14', N'int', 5, N'Số tín chỉ cảnh cáo MAX', 4)
INSERT [dbo].[webpages_CauHinh] ([Ten], [Gia_tri], [Kieu], [Ky_dang_ky], [Mo_ta], [Id]) VALUES (N'So_TC_CC_min', N'6', N'int', 5, N'Số tín chỉ cảnh cáo MIN', 5)
INSERT [dbo].[webpages_CauHinh] ([Ten], [Gia_tri], [Kieu], [Ky_dang_ky], [Mo_ta], [Id]) VALUES (N'So_TC_ky_phu', N'12', N'int', 5, N'Số tín chỉ học kỳ phụ', 6)
INSERT [dbo].[webpages_CauHinh] ([Ten], [Gia_tri], [Kieu], [Ky_dang_ky], [Mo_ta], [Id]) VALUES (N'So_TC_max', N'30', N'int', 5, N'Số tín chỉ MAX', 7)
INSERT [dbo].[webpages_CauHinh] ([Ten], [Gia_tri], [Kieu], [Ky_dang_ky], [Mo_ta], [Id]) VALUES (N'So_TC_min', N'12', N'int', 5, N'Số tín chỉ MIN', 8)
INSERT [dbo].[webpages_CauHinh] ([Ten], [Gia_tri], [Kieu], [Ky_dang_ky], [Mo_ta], [Id]) VALUES (N'User_Groups', N'2', N'string', 0, N'ID nhóm User', 9)
INSERT [dbo].[webpages_CauHinh] ([Ten], [Gia_tri], [Kieu], [Ky_dang_ky], [Mo_ta], [Id]) VALUES (N'Nang_diem', N'C+', N'string', 5, N'Điểm tối đa được học nâng điểm', 25)
INSERT [dbo].[webpages_CauHinh] ([Ten], [Gia_tri], [Kieu], [Ky_dang_ky], [Mo_ta], [Id]) VALUES (N'Hoc_lai', N'D', N'string', 5, N'Điểm tối thiểu để không bị học lại', 26)
SET IDENTITY_INSERT [dbo].[webpages_CauHinh] OFF
SET IDENTITY_INSERT [dbo].[webpages_Group] ON 

INSERT [dbo].[webpages_Group] ([GroupId], [GroupName]) VALUES (1, N'Admin')
INSERT [dbo].[webpages_Group] ([GroupId], [GroupName]) VALUES (2, N'User')
INSERT [dbo].[webpages_Group] ([GroupId], [GroupName]) VALUES (5, N'Quản lý đào tạo')
INSERT [dbo].[webpages_Group] ([GroupId], [GroupName]) VALUES (6, N'Giảng viên')
INSERT [dbo].[webpages_Group] ([GroupId], [GroupName]) VALUES (7, N'Khách')
SET IDENTITY_INSERT [dbo].[webpages_Group] OFF
SET IDENTITY_INSERT [dbo].[webpages_Groups_Roles] ON 

INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (7, 42, 120)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (7, 43, 121)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (5, 21, 122)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (5, 22, 123)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (5, 25, 124)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (5, 26, 125)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (5, 27, 126)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (5, 28, 127)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (5, 29, 128)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (6, 21, 152)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (6, 22, 153)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (6, 24, 154)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (6, 42, 155)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (6, 43, 156)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (1, 21, 157)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (1, 22, 158)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (1, 23, 159)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (1, 24, 160)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (1, 25, 161)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (1, 26, 162)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (1, 27, 163)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (1, 28, 164)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (1, 29, 165)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (1, 30, 166)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (1, 31, 167)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (1, 32, 168)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (1, 33, 169)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (1, 34, 170)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (1, 35, 171)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (1, 36, 172)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (1, 37, 173)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (1, 38, 174)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (1, 39, 175)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (1, 40, 176)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (1, 41, 177)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (1, 42, 178)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (1, 43, 179)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (1, 46, 180)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (2, 21, 181)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (2, 23, 182)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (2, 42, 183)
INSERT [dbo].[webpages_Groups_Roles] ([GroupId], [RoleId], [Id]) VALUES (2, 43, 184)
SET IDENTITY_INSERT [dbo].[webpages_Groups_Roles] OFF
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (1, CAST(0x0000A1EB009E76A5 AS DateTime), NULL, 1, CAST(0x0000A2AB00CD9D5F AS DateTime), 0, N'AFB8plnSijlLBbUcPMR3PhVGoUcb9ic98a4MOeCJmh0Ek8ItsiEP5UPBYCqBNIZedw==', CAST(0x0000A259016EF5F4 AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (2, CAST(0x0000A23700971894 AS DateTime), NULL, 1, NULL, 0, N'AGDFtVjvu98h5VE9+Lsyn9L0VYVfcea5Zok6Nuc/zrIBbGah0oSP2OPKuoKKA4IJIg==', CAST(0x0000A23700971894 AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (3, CAST(0x0000A2460035B582 AS DateTime), NULL, 1, NULL, 0, N'AKmujkEgy7nrEg5mVnzv865TNdgmwA9ZgtPCj920eL0ObJ57SFMLIgUYLAlcqGtB+g==', CAST(0x0000A2460035B582 AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (4, CAST(0x0000A25000814649 AS DateTime), NULL, 1, NULL, 0, N'AGGgqbXwARPSC66tR/v7L9TwtHpIorlLNeYI8L7c4W6++eT2uP9tRnExP6P1ZkBCFQ==', CAST(0x0000A25000814649 AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (5, CAST(0x0000A252003B3589 AS DateTime), NULL, 1, NULL, 0, N'ADl5jR69+PWhJXv5GMpxH5izjXZA7QMledsImjgLdRqYU7yS4fXJQPjxoHYM+bC0vA==', CAST(0x0000A252003B3589 AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (6, CAST(0x0000A252007E323A AS DateTime), NULL, 1, NULL, 0, N'ABAsVNxTQef58qOX1XrO/gGxyklECGzVRnGdQaZWLqs5YGARxgBam4hc9FW/W03bhA==', CAST(0x0000A252007E323A AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (9, CAST(0x0000A258008809AB AS DateTime), NULL, 1, NULL, 0, N'AFBFtc+gW5kpcxWlowCgUuVh5q+2XgsIv4O2tUFzdqsxku7Zm6ej87JlOEUNr6OX2Q==', CAST(0x0000A258008809AB AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (12, CAST(0x0000A259002B04AF AS DateTime), NULL, 1, NULL, 0, N'AEqTDY6Xw2hZIHiKSKlL2YfUcUMz94Yu72049L5Y6ijtcgMqt5RsTEXtNSDrdWZLQQ==', CAST(0x0000A259002B04AF AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (13, CAST(0x0000A25A001878A2 AS DateTime), NULL, 1, NULL, 0, N'AHCNkilWxHd7cJ4SD/eWBw9pFC0R1VYT7riSuMu1qzvB1zsyg3a0ydGWn+vj0F6rTw==', CAST(0x0000A25A001878A2 AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (14, CAST(0x0000A25A003FC3F8 AS DateTime), NULL, 1, CAST(0x0000A25A003FC40E AS DateTime), 1, N'AIfw/kPWw3PHKIDVuafEdKlTKOs7wSaQ/qSZiN84SY4U/5Nnf5B4pOE+5W97YtWL5A==', CAST(0x0000A25A003FC3F8 AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (15, CAST(0x0000A25A003FDC82 AS DateTime), NULL, 1, CAST(0x0000A25A003FDC92 AS DateTime), 1, N'AIRA/xkhfbyI6BETzFa8z4bXnHyY+/VP4NKnE2cB3fDoyW8Ggp56KU9t11LLTCU7Kg==', CAST(0x0000A25A003FDC82 AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (16, CAST(0x0000A25A00408B8E AS DateTime), NULL, 1, CAST(0x0000A25A00408B9C AS DateTime), 1, N'AGjPapKTm1xIjDAehykvv9zvyOwIbmCHCNAXcEi/cJRD2jdGdJo+TExCOQG6rVUq1A==', CAST(0x0000A25A00408B8E AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (17, CAST(0x0000A25A0040A27E AS DateTime), NULL, 1, CAST(0x0000A25A0040A28D AS DateTime), 1, N'AEIMUnFhkKKXcCJ2+CxrWws5hfNbj5TXXJsYbKCKphu6Rf+5t5aiG0NsR8iIdRwXjg==', CAST(0x0000A25A0040A27E AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (18, CAST(0x0000A25A00801562 AS DateTime), NULL, 1, CAST(0x0000A25A00801586 AS DateTime), 1, N'AJdJiqvuskE4dgoJuLJ13tUC2nWJUJyQpUxS9dOs4AHtR6jIub/sStCVBn8OQrze0g==', CAST(0x0000A25A00801562 AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (19, CAST(0x0000A25F0029829C AS DateTime), NULL, 1, NULL, 0, N'AJVRwQy1e+CJavV6QoFfUO9rWlS8Z/9YvMw0u/lBHJmRfntNcoazzsvR7KrpBtpWAQ==', CAST(0x0000A25F0029829C AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (20, CAST(0x0000A261009DFF1C AS DateTime), NULL, 1, NULL, 0, N'AGBdGjTVUPdkTw2P7WObchC3tReQU7FsDacYelBAaKtCWmepInEPJ21JrZUUDL/NYA==', CAST(0x0000A261009DFF1C AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (21, CAST(0x0000A27A003D057C AS DateTime), NULL, 1, CAST(0x0000A2820042263A AS DateTime), 1, N'AOGHfF2MKDYNovJqd+2kv+HeSL8yWhlWYIp1JeV63lrMvwE0KdXbAYDT/vBYqgGSbA==', CAST(0x0000A27A003D057C AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (22, CAST(0x0000A27A003D2951 AS DateTime), NULL, 1, CAST(0x0000A27A003D295B AS DateTime), 1, N'ALwZ0AOtoGBGJvFCjtNIFlg5283DT4vahcu+tWISaAO332edXOBn0sh6XOmR9GNuSg==', CAST(0x0000A27A003D2951 AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (23, CAST(0x0000A27A003D447C AS DateTime), NULL, 1, NULL, 0, N'AOStSGBOjCuVsshK/ps56zbIaz349rKqfFghasZNCsYbs0PE5BEmJxBZd7b0IDGb5Q==', CAST(0x0000A27A003D447C AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (24, CAST(0x0000A2A1000E9A7E AS DateTime), NULL, 1, NULL, 0, N'ALhe+huG9gsu+WQzwETlDJrAPQf9qPGJmp7KpvLv3EzReDlLjarBgMMe4FEY1vs0XQ==', CAST(0x0000A2A1000E9A7E AS DateTime), N'', NULL, NULL)
SET IDENTITY_INSERT [dbo].[webpages_Roles] ON 

INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName], [DisplayName]) VALUES (21, N'Message', N'Sử dụng tin nhắn')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName], [DisplayName]) VALUES (22, N'Message.Lop', N'Gửi tin nhắn cho lớp')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName], [DisplayName]) VALUES (23, N'SinhVien', N'Sinh Viên')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName], [DisplayName]) VALUES (24, N'GiangVien', N'Giảng Viên')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName], [DisplayName]) VALUES (25, N'News.Create', N'Tạo trang tin')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName], [DisplayName]) VALUES (26, N'News.Edit', N'Sửa Trang tin')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName], [DisplayName]) VALUES (27, N'News.Delete', N'Xóa trang tin')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName], [DisplayName]) VALUES (28, N'DanhSachLopTC', N'Quản lý lớp tín chỉ')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName], [DisplayName]) VALUES (29, N'LopHanhChinh', N'Quản lý lớp hành chính')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName], [DisplayName]) VALUES (30, N'User', N'Quản lý người dùng')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName], [DisplayName]) VALUES (31, N'User.Create', N'Tạo người dùng')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName], [DisplayName]) VALUES (32, N'User.Edit', N'Sửa thông tin người dùng')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName], [DisplayName]) VALUES (33, N'User.Delete', N'Xóa người dùng')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName], [DisplayName]) VALUES (34, N'Group', N'Quản lý nhóm')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName], [DisplayName]) VALUES (35, N'Group.Edit', N'Sửa nhóm')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName], [DisplayName]) VALUES (36, N'Group.Create', N'Thêm nhóm')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName], [DisplayName]) VALUES (37, N'Group.Delete', N'Xóa nhóm')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName], [DisplayName]) VALUES (38, N'Roles', N'Quản lý quyền')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName], [DisplayName]) VALUES (39, N'Roles.Add', N'Thêm quyền')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName], [DisplayName]) VALUES (40, N'Roles.Edit', N'Sửa quyền')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName], [DisplayName]) VALUES (41, N'Roles.Delete', N'Xóa quyền')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName], [DisplayName]) VALUES (42, N'TraCuu.Diem', N'Tra cứu điểm')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName], [DisplayName]) VALUES (43, N'TraCuu.ThuChi', N'Tra cứu tài chính')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName], [DisplayName]) VALUES (46, N'ChuongTrinhKhung', N'Xem chương trình khung')
SET IDENTITY_INSERT [dbo].[webpages_Roles] OFF
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (1, 21)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (1, 22)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (1, 23)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (1, 24)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (1, 25)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (1, 26)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (1, 27)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (1, 28)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (1, 29)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (1, 30)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (1, 31)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (1, 32)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (1, 33)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (1, 34)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (1, 35)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (1, 36)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (1, 37)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (1, 38)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (1, 39)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (1, 40)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (1, 41)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (1, 42)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (1, 43)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (1, 46)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (4, 21)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (4, 23)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (4, 42)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (4, 43)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (12, 42)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (12, 43)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (13, 21)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (13, 22)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (13, 24)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (13, 42)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (13, 43)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (20, 21)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (20, 23)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (20, 42)
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (20, 43)
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__UserProf__C9F284562375F915]    Script Date: 10/01/2014 11:34:11 AM ******/
ALTER TABLE [dbo].[UserProfile] ADD  CONSTRAINT [UQ__UserProf__C9F284562375F915] UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__webpages__8A2B6160465520FE]    Script Date: 10/01/2014 11:34:11 AM ******/
ALTER TABLE [dbo].[webpages_Roles] ADD UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [IsConfirmed]
GO
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [PasswordFailuresSinceLastSuccess]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[webpages_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_RoleId]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_UserId]
GO
