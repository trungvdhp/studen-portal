ALTER TABLE [dbo].[tbl_news] DROP CONSTRAINT [DF_tbl_news_TotalView]
GO
ALTER TABLE [dbo].[tbl_inbox] DROP CONSTRAINT [DF_tbl_inbox_Warning]
GO
ALTER TABLE [dbo].[tbl_inbox] DROP CONSTRAINT [DF_tbl_inbox_Status]
GO
/****** Object:  Table [dbo].[tbl_news]    Script Date: 10/01/2014 02:34:09 PM ******/
DROP TABLE [dbo].[tbl_news]
GO
/****** Object:  Table [dbo].[tbl_inbox]    Script Date: 10/01/2014 02:34:09 PM ******/
DROP TABLE [dbo].[tbl_inbox]
GO
/****** Object:  Table [dbo].[tbl_inbox]    Script Date: 10/01/2014 02:34:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_inbox](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NULL,
	[Contents] [ntext] NULL,
	[PostDate] [datetime] NULL,
	[Ma_sv] [varchar](50) NULL,
	[Status] [bit] NULL,
	[ID_nguoi_tra_loi] [int] NULL,
	[From] [int] NOT NULL,
	[To] [int] NOT NULL,
	[Type] [tinyint] NULL,
	[Warning] [bit] NOT NULL,
 CONSTRAINT [PK_tbl_inbox] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_news]    Script Date: 10/01/2014 02:34:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_news](
	[Id] [int] IDENTITY(2,6) NOT NULL,
	[Title] [nvarchar](300) NULL,
	[Description] [nvarchar](1000) NULL,
	[Contents] [ntext] NULL,
	[ImageUrl] [nvarchar](100) NULL,
	[PostDate] [smalldatetime] NULL,
	[TotalView] [int] NULL,
	[Type] [bit] NULL,
	[UserId] [int] NULL,
	[LastEditUserId] [int] NULL,
	[LastEditDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_news] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tbl_inbox] ON 

INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (11, N'V/v đồ án tốt nghiệp', N'Sáng mai lên cài máy trên trường nhé.<br>', CAST(0x0000A25800F4F16F AS DateTime), NULL, 1, NULL, 3, 1, 1, 0)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (46, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Toán chuyên đề (Khoa Đóng tàu) (chưa đóng): 240000
Kỹ thuật bơi lội (chưa đóng): 120000
Thực tập cơ khí (Khoa Máy khai thác) (chưa đóng): 480000
Sức bền vật liệu 1 (chưa đóng): 240000
Nguyên lý máy (Đóng tàu) (chưa đóng): 480000
Vật liệu kỹ thuật (Đóng tàu) (chưa đóng): 360000
Nguyên lý CB của CNMLN 1 (chưa đóng): 240000
', CAST(0x0000A258011A671A AS DateTime), NULL, 0, NULL, 10, 902, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (47, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Toán chuyên đề (Khoa Đóng tàu) (chưa đóng): 240000
Tư tưởng Hồ Chí Minh (chưa đóng): 240000
Đường lối cách mạng của ĐCS Việt Nam (chưa đóng): 360000
Đại số (chưa đóng): 360000
Vật lý 2 (chưa đóng): 360000
Tiếng Anh cơ bản 3 (chưa đóng): 360000
Đường lối cách mạng của ĐCS Việt Nam (chưa đóng): 360000
Vẽ kỹ thuật cơ khí (chưa đóng): 240000
Cơ lý thuyết (chưa đóng): 480000
', CAST(0x0000A258011A6CE1 AS DateTime), NULL, 0, NULL, 10, 904, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (48, N'Cảnh báo học tập', N'Học kỳ này bạn có thể bị cảnh cáo học tập do điểm trung bình môn học tập hiện tại là 0.0, nhỏ hơn mức trung bình học tập tối thiểu. ', CAST(0x0000A258011A8FB3 AS DateTime), NULL, 0, NULL, 10, 919, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (49, N'Cảnh báo học tập', N'Học kỳ này bạn có thể bị cảnh cáo học tập do điểm trung bình môn học tập hiện tại là 0.0, nhỏ hơn mức trung bình học tập tối thiểu. ', CAST(0x0000A258011AD421 AS DateTime), NULL, 0, NULL, 10, 946, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (50, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật điện (chưa đóng): 240000
Thực tập cơ khí (Khoa Máy khai thác) (chưa đóng): 480000
Sức bền vật liệu 1 (chưa đóng): 240000
Nguyên lý máy (Đóng tàu) (chưa đóng): 480000
Vật liệu kỹ thuật (Đóng tàu) (chưa đóng): 360000
', CAST(0x0000A258011ADA7E AS DateTime), NULL, 0, NULL, 10, 948, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (51, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật điện (chưa đóng): 240000
Toán chuyên đề (Khoa Đóng tàu) (chưa đóng): 240000
Kỹ thuật bơi lội (chưa đóng): 120000
Cơ chất lỏng (chưa đóng): 360000
Sức bền vật liệu 1 (chưa đóng): 240000
Nguyên lý máy (Đóng tàu) (chưa đóng): 480000
Vật liệu kỹ thuật (Đóng tàu) (chưa đóng): 360000
', CAST(0x0000A258011AEA25 AS DateTime), NULL, 0, NULL, 10, 954, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (52, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật điện (chưa đóng): 240000
Giải tích 2 (chưa đóng): 480000
Toán chuyên đề (Khoa Đóng tàu) (chưa đóng): 240000
Kỹ thuật bơi lội (chưa đóng): 120000
Cơ chất lỏng (chưa đóng): 360000
Sức bền vật liệu 1 (chưa đóng): 240000
Nguyên lý máy (Đóng tàu) (chưa đóng): 480000
Vật liệu kỹ thuật (Đóng tàu) (chưa đóng): 360000
', CAST(0x0000A258011B0EE6 AS DateTime), NULL, 0, NULL, 10, 971, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (53, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 360000
Vẽ kỹ thuật – Autocad (chưa đóng): 240000
', CAST(0x0000A258011B1E5C AS DateTime), NULL, 0, NULL, 10, 977, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (54, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Vẽ kỹ thuật – Autocad (chưa đóng): 240000
Cơ lý thuyết (chưa đóng): 480000
', CAST(0x0000A258011B23C4 AS DateTime), NULL, 0, NULL, 10, 979, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (55, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật điện (chưa đóng): 240000
Toán chuyên đề (Khoa Đóng tàu) (chưa đóng): 240000
Kỹ thuật bơi lội (chưa đóng): 120000
Thực tập cơ khí (Khoa Máy khai thác) (chưa đóng): 480000
Cơ chất lỏng (chưa đóng): 360000
Sức bền vật liệu 1 (chưa đóng): 240000
Nguyên lý máy (Đóng tàu) (chưa đóng): 480000
Vật liệu kỹ thuật (Đóng tàu) (chưa đóng): 360000
', CAST(0x0000A258011B32F1 AS DateTime), NULL, 0, NULL, 10, 984, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (56, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Giải tích 2 (chưa đóng): 480000
Nguyên lý CB của CNMLN 1 (chưa đóng): 240000
', CAST(0x0000A258011B4940 AS DateTime), NULL, 0, NULL, 10, 992, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (57, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 360000
Sức bền vật liệu 1 (chưa đóng): 240000
', CAST(0x0000A258011B58AB AS DateTime), NULL, 0, NULL, 10, 1134, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (58, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Trắc địa công trình (chưa đóng): 240000
Cơ học kết cấu 1 (chưa đóng): 240000
Địa chất công trình (chưa đóng): 240000
Vật liệu xây dựng (chưa đóng): 360000
Xác suất thống kê (Kỹ thuật) (chưa đóng): 240000
Kỹ thuật bơi lội (chưa đóng): 120000
Kỹ thuật bóng chuyền (chưa đóng): 120000
Đường lối cách mạng của ĐCS Việt Nam (chưa đóng): 360000
', CAST(0x0000A258011B9C94 AS DateTime), NULL, 0, NULL, 10, 1164, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (59, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
HP2 - Công tác Quốc phòng- An ninh (chưa đóng): 240000
Cơ lý thuyết (chưa đóng): 480000
', CAST(0x0000A258011B9F00 AS DateTime), NULL, 0, NULL, 10, 1165, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (60, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa chất công trình (chưa đóng): 240000
Đại số (chưa đóng): 360000
Vật lý 2 (chưa đóng): 360000
Tiếng Anh cơ bản 3 (chưa đóng): 360000
Tư tưởng Hồ Chí Minh (chưa đóng): 240000
Sức bền vật liệu 1 (chưa đóng): 240000
', CAST(0x0000A258011BABCB AS DateTime), NULL, 0, NULL, 10, 1171, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (61, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Trắc địa công trình (chưa đóng): 240000
Địa chất công trình (chưa đóng): 240000
Vật liệu xây dựng (chưa đóng): 360000
Xác suất thống kê (Kỹ thuật) (chưa đóng): 240000
Kỹ thuật điền kinh (chưa đóng): 120000
Đường lối cách mạng của ĐCS Việt Nam (chưa đóng): 360000
', CAST(0x0000A258011BB820 AS DateTime), NULL, 0, NULL, 10, 1176, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (62, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Vật liệu xây dựng (chưa đóng): 360000
Đại số (chưa đóng): 360000
', CAST(0x0000A258011BDCB2 AS DateTime), NULL, 0, NULL, 10, 1192, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (63, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Cấu trúc dữ liệu (chưa đóng): 360000
PTTK và đánh giá thuật toán (chưa đóng): 360000
', CAST(0x0000A258011BFEC1 AS DateTime), NULL, 0, NULL, 10, 1338, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (64, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Trắc địa công trình (chưa đóng): 240000
Cơ học kết cấu 1 (chưa đóng): 240000
Địa chất công trình (chưa đóng): 240000
Vật liệu xây dựng (chưa đóng): 360000
Xác suất thống kê (Kỹ thuật) (chưa đóng): 240000
HP1- Đường lối QS của Đảng (chưa đóng): 240000
HP2 - Công tác Quốc phòng- An ninh (chưa đóng): 240000
Đường lối cách mạng của ĐCS Việt Nam (chưa đóng): 360000
Sức bền vật liệu 1 (chưa đóng): 240000
Sức bền vật liệu 2 (chưa đóng): 240000
', CAST(0x0000A258011C0543 AS DateTime), NULL, 0, NULL, 10, 1407, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (65, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Thuỷ lực cơ sở (chưa đóng): 360000
Đại số (chưa đóng): 360000
Vật lý 2 (chưa đóng): 360000
Tiếng Anh cơ bản 3 (chưa đóng): 360000
Tư tưởng Hồ Chí Minh (chưa đóng): 240000
Thực tập cơ khí (Khoa công trình) (chưa đóng): 120000
Sức bền vật liệu 1 (chưa đóng): 240000
', CAST(0x0000A258011C087B AS DateTime), NULL, 0, NULL, 10, 1408, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (66, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Trắc địa công trình (chưa đóng): 240000
Cơ học kết cấu 1 (chưa đóng): 240000
Địa chất công trình (chưa đóng): 240000
Vật liệu xây dựng (chưa đóng): 360000
Xác suất thống kê (Kỹ thuật) (chưa đóng): 240000
Kỹ thuật điền kinh (chưa đóng): 120000
HP1- Đường lối QS của Đảng (chưa đóng): 240000
Đường lối cách mạng của ĐCS Việt Nam (chưa đóng): 360000
Sức bền vật liệu 2 (chưa đóng): 240000
HP2 - Công tác Quốc phòng- An ninh (chưa đóng): 240000
', CAST(0x0000A258011C118E AS DateTime), NULL, 0, NULL, 10, 1411, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (68, N'Ngày mai bảo vệ đồ án', N'Làm báo cáo như thế nào?<br>', CAST(0x0000A2580161775B AS DateTime), NULL, 1, NULL, 3, 1, 1, 0)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (69, N'Test gui tin nhan', N'testesstestestes', CAST(0x0000A2580182019A AS DateTime), NULL, 1, NULL, 1, 3, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (71, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bơi lội (chưa đóng): 120000
Sức bền vật liệu 1 (chưa đóng): 240000
Nguyên lý máy (Đóng tàu) (chưa đóng): 480000
Vật liệu kỹ thuật (Đóng tàu) (chưa đóng): 360000
Thực tập cơ khí (Khoa Máy khai thác) (chưa đóng): 480000
Toán chuyên đề (Khoa Đóng tàu) (chưa đóng): 240000
Nguyên lý CB của CNMLN 1 (chưa đóng): 240000
', CAST(0x0000A25900A890DD AS DateTime), NULL, 0, NULL, 10, 902, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (72, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đường lối cách mạng của ĐCS Việt Nam (chưa đóng): 360000
Đường lối cách mạng của ĐCS Việt Nam (chưa đóng): 360000
Tư tưởng Hồ Chí Minh (chưa đóng): 240000
Tiếng Anh cơ bản 3 (chưa đóng): 360000
Đại số (chưa đóng): 360000
Vật lý 2 (chưa đóng): 360000
Cơ lý thuyết (chưa đóng): 480000
Toán chuyên đề (Khoa Đóng tàu) (chưa đóng): 240000
Vẽ kỹ thuật cơ khí (chưa đóng): 240000
', CAST(0x0000A25900A89484 AS DateTime), NULL, 0, NULL, 10, 904, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (73, N'Cảnh báo học tập', N'Học kỳ này bạn có thể bị cảnh cáo học tập do điểm trung bình môn học tập hiện tại là 0.0, nhỏ hơn mức trung bình học tập tối thiểu. ', CAST(0x0000A25900A8AB11 AS DateTime), NULL, 0, NULL, 10, 919, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (74, N'Cảnh báo học tập', N'Học kỳ này bạn có thể bị cảnh cáo học tập do điểm trung bình môn học tập hiện tại là 0.0, nhỏ hơn mức trung bình học tập tối thiểu. ', CAST(0x0000A25900A8D536 AS DateTime), NULL, 0, NULL, 10, 946, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (75, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 1 (chưa đóng): 240000
Kỹ thuật điện (chưa đóng): 240000
Nguyên lý máy (Đóng tàu) (chưa đóng): 480000
Vật liệu kỹ thuật (Đóng tàu) (chưa đóng): 360000
Thực tập cơ khí (Khoa Máy khai thác) (chưa đóng): 480000
', CAST(0x0000A25900A8D8F5 AS DateTime), NULL, 0, NULL, 10, 948, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (76, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bơi lội (chưa đóng): 120000
Sức bền vật liệu 1 (chưa đóng): 240000
Cơ chất lỏng (chưa đóng): 360000
Kỹ thuật điện (chưa đóng): 240000
Nguyên lý máy (Đóng tàu) (chưa đóng): 480000
Vật liệu kỹ thuật (Đóng tàu) (chưa đóng): 360000
Toán chuyên đề (Khoa Đóng tàu) (chưa đóng): 240000
', CAST(0x0000A25900A8E30E AS DateTime), NULL, 0, NULL, 10, 954, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (77, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bơi lội (chưa đóng): 120000
Giải tích 2 (chưa đóng): 480000
Sức bền vật liệu 1 (chưa đóng): 240000
Cơ chất lỏng (chưa đóng): 360000
Kỹ thuật điện (chưa đóng): 240000
Nguyên lý máy (Đóng tàu) (chưa đóng): 480000
Vật liệu kỹ thuật (Đóng tàu) (chưa đóng): 360000
Toán chuyên đề (Khoa Đóng tàu) (chưa đóng): 240000
', CAST(0x0000A25900A8FA93 AS DateTime), NULL, 0, NULL, 10, 971, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (78, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 360000
Vẽ kỹ thuật – Autocad (chưa đóng): 240000
', CAST(0x0000A25900A90454 AS DateTime), NULL, 0, NULL, 10, 977, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (79, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Vẽ kỹ thuật – Autocad (chưa đóng): 240000
Cơ lý thuyết (chưa đóng): 480000
', CAST(0x0000A25900A907AC AS DateTime), NULL, 0, NULL, 10, 979, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (80, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bơi lội (chưa đóng): 120000
Sức bền vật liệu 1 (chưa đóng): 240000
Cơ chất lỏng (chưa đóng): 360000
Kỹ thuật điện (chưa đóng): 240000
Nguyên lý máy (Đóng tàu) (chưa đóng): 480000
Vật liệu kỹ thuật (Đóng tàu) (chưa đóng): 360000
Thực tập cơ khí (Khoa Máy khai thác) (chưa đóng): 480000
Toán chuyên đề (Khoa Đóng tàu) (chưa đóng): 240000
', CAST(0x0000A25900A91076 AS DateTime), NULL, 0, NULL, 10, 984, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (81, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Giải tích 2 (chưa đóng): 480000
Nguyên lý CB của CNMLN 1 (chưa đóng): 240000
', CAST(0x0000A25900A91D12 AS DateTime), NULL, 0, NULL, 10, 992, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (82, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 360000
Sức bền vật liệu 1 (chưa đóng): 240000
', CAST(0x0000A25900A926E9 AS DateTime), NULL, 0, NULL, 10, 1134, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (83, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bơi lội (chưa đóng): 120000
Kỹ thuật bóng chuyền (chưa đóng): 120000
Đường lối cách mạng của ĐCS Việt Nam (chưa đóng): 360000
Địa chất công trình (chưa đóng): 240000
Vật liệu xây dựng (chưa đóng): 360000
Xác suất thống kê (Kỹ thuật) (chưa đóng): 240000
Cơ học kết cấu 1 (chưa đóng): 240000
Trắc địa công trình (chưa đóng): 240000
', CAST(0x0000A25900A95508 AS DateTime), NULL, 0, NULL, 10, 1164, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (84, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bơi lội (chưa đóng): 120000
Sức bền vật liệu 1 (chưa đóng): 240000
Nguyên lý máy (Đóng tàu) (chưa đóng): 480000
Vật liệu kỹ thuật (Đóng tàu) (chưa đóng): 360000
Thực tập cơ khí (Khoa Máy khai thác) (chưa đóng): 480000
Toán chuyên đề (Khoa Đóng tàu) (chưa đóng): 240000
Nguyên lý CB của CNMLN 1 (chưa đóng): 240000
', CAST(0x0000A25900A9E383 AS DateTime), NULL, 0, NULL, 10, 902, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (85, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đường lối cách mạng của ĐCS Việt Nam (chưa đóng): 360000
Đường lối cách mạng của ĐCS Việt Nam (chưa đóng): 360000
Tư tưởng Hồ Chí Minh (chưa đóng): 240000
Tiếng Anh cơ bản 3 (chưa đóng): 360000
Đại số (chưa đóng): 360000
Vật lý 2 (chưa đóng): 360000
Cơ lý thuyết (chưa đóng): 480000
Toán chuyên đề (Khoa Đóng tàu) (chưa đóng): 240000
Vẽ kỹ thuật cơ khí (chưa đóng): 240000
', CAST(0x0000A25900A9E726 AS DateTime), NULL, 0, NULL, 10, 904, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (86, N'Cảnh báo học tập', N'Học kỳ này bạn có thể bị cảnh cáo học tập do điểm trung bình môn học tập hiện tại là 0.0, nhỏ hơn mức trung bình học tập tối thiểu. ', CAST(0x0000A25900A9FD40 AS DateTime), NULL, 0, NULL, 10, 919, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (87, N'Cảnh báo học tập', N'Học kỳ này bạn có thể bị cảnh cáo học tập do điểm trung bình môn học tập hiện tại là 0.0, nhỏ hơn mức trung bình học tập tối thiểu. ', CAST(0x0000A25900AA28FB AS DateTime), NULL, 0, NULL, 10, 946, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (88, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 1 (chưa đóng): 240000
Kỹ thuật điện (chưa đóng): 240000
Nguyên lý máy (Đóng tàu) (chưa đóng): 480000
Vật liệu kỹ thuật (Đóng tàu) (chưa đóng): 360000
Thực tập cơ khí (Khoa Máy khai thác) (chưa đóng): 480000
', CAST(0x0000A25900AA2C9D AS DateTime), NULL, 0, NULL, 10, 948, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (89, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bơi lội (chưa đóng): 120000
Sức bền vật liệu 1 (chưa đóng): 240000
Cơ chất lỏng (chưa đóng): 360000
Kỹ thuật điện (chưa đóng): 240000
Nguyên lý máy (Đóng tàu) (chưa đóng): 480000
Vật liệu kỹ thuật (Đóng tàu) (chưa đóng): 360000
Toán chuyên đề (Khoa Đóng tàu) (chưa đóng): 240000
', CAST(0x0000A25900AA3745 AS DateTime), NULL, 0, NULL, 10, 954, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (90, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bơi lội (chưa đóng): 120000
Giải tích 2 (chưa đóng): 480000
Sức bền vật liệu 1 (chưa đóng): 240000
Cơ chất lỏng (chưa đóng): 360000
Kỹ thuật điện (chưa đóng): 240000
Nguyên lý máy (Đóng tàu) (chưa đóng): 480000
Vật liệu kỹ thuật (Đóng tàu) (chưa đóng): 360000
Toán chuyên đề (Khoa Đóng tàu) (chưa đóng): 240000
', CAST(0x0000A25900AA4F96 AS DateTime), NULL, 0, NULL, 10, 971, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (91, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 360000
Vẽ kỹ thuật – Autocad (chưa đóng): 240000
', CAST(0x0000A25900AA592C AS DateTime), NULL, 0, NULL, 10, 977, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (92, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Vẽ kỹ thuật – Autocad (chưa đóng): 240000
Cơ lý thuyết (chưa đóng): 480000
', CAST(0x0000A25900AA5C76 AS DateTime), NULL, 0, NULL, 10, 979, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (93, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bơi lội (chưa đóng): 120000
Sức bền vật liệu 1 (chưa đóng): 240000
Cơ chất lỏng (chưa đóng): 360000
Kỹ thuật điện (chưa đóng): 240000
Nguyên lý máy (Đóng tàu) (chưa đóng): 480000
Vật liệu kỹ thuật (Đóng tàu) (chưa đóng): 360000
Thực tập cơ khí (Khoa Máy khai thác) (chưa đóng): 480000
Toán chuyên đề (Khoa Đóng tàu) (chưa đóng): 240000
', CAST(0x0000A25900AA6553 AS DateTime), NULL, 0, NULL, 10, 984, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (94, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Giải tích 2 (chưa đóng): 480000
Nguyên lý CB của CNMLN 1 (chưa đóng): 240000
', CAST(0x0000A25900AA71D0 AS DateTime), NULL, 0, NULL, 10, 992, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (95, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 360000
Sức bền vật liệu 1 (chưa đóng): 240000
', CAST(0x0000A25900AA7B27 AS DateTime), NULL, 0, NULL, 10, 1134, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (96, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bơi lội (chưa đóng): 120000
Kỹ thuật bóng chuyền (chưa đóng): 120000
Đường lối cách mạng của ĐCS Việt Nam (chưa đóng): 360000
Địa chất công trình (chưa đóng): 240000
Vật liệu xây dựng (chưa đóng): 360000
Xác suất thống kê (Kỹ thuật) (chưa đóng): 240000
Cơ học kết cấu 1 (chưa đóng): 240000
Trắc địa công trình (chưa đóng): 240000
', CAST(0x0000A25900AAA75F AS DateTime), NULL, 0, NULL, 10, 1164, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (97, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
HP2 - Công tác Quốc phòng- An ninh (chưa đóng): 240000
Cơ lý thuyết (chưa đóng): 480000
', CAST(0x0000A25900AAA933 AS DateTime), NULL, 0, NULL, 10, 1165, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (98, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tư tưởng Hồ Chí Minh (chưa đóng): 240000
Tiếng Anh cơ bản 3 (chưa đóng): 360000
Đại số (chưa đóng): 360000
Vật lý 2 (chưa đóng): 360000
Địa chất công trình (chưa đóng): 240000
Sức bền vật liệu 1 (chưa đóng): 240000
', CAST(0x0000A25900AAB1E6 AS DateTime), NULL, 0, NULL, 10, 1171, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (99, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật điền kinh (chưa đóng): 120000
Đường lối cách mạng của ĐCS Việt Nam (chưa đóng): 360000
Địa chất công trình (chưa đóng): 240000
Vật liệu xây dựng (chưa đóng): 360000
Xác suất thống kê (Kỹ thuật) (chưa đóng): 240000
Trắc địa công trình (chưa đóng): 240000
', CAST(0x0000A25900AABAD6 AS DateTime), NULL, 0, NULL, 10, 1176, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (100, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 360000
Vật liệu xây dựng (chưa đóng): 360000
', CAST(0x0000A25900AAD299 AS DateTime), NULL, 0, NULL, 10, 1192, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (101, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Cấu trúc dữ liệu (chưa đóng): 360000
PTTK và đánh giá thuật toán (chưa đóng): 360000
', CAST(0x0000A25900AAE87C AS DateTime), NULL, 0, NULL, 10, 1338, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (102, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
HP1- Đường lối QS của Đảng (chưa đóng): 240000
HP2 - Công tác Quốc phòng- An ninh (chưa đóng): 240000
Đường lối cách mạng của ĐCS Việt Nam (chưa đóng): 360000
Địa chất công trình (chưa đóng): 240000
Vật liệu xây dựng (chưa đóng): 360000
Xác suất thống kê (Kỹ thuật) (chưa đóng): 240000
Cơ học kết cấu 1 (chưa đóng): 240000
Trắc địa công trình (chưa đóng): 240000
Sức bền vật liệu 1 (chưa đóng): 240000
Sức bền vật liệu 2 (chưa đóng): 240000
', CAST(0x0000A25900AAEC48 AS DateTime), NULL, 0, NULL, 10, 1407, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (103, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tư tưởng Hồ Chí Minh (chưa đóng): 240000
Tiếng Anh cơ bản 3 (chưa đóng): 360000
Đại số (chưa đóng): 360000
Vật lý 2 (chưa đóng): 360000
Thực tập cơ khí (Khoa công trình) (chưa đóng): 120000
Thuỷ lực cơ sở (chưa đóng): 360000
Sức bền vật liệu 1 (chưa đóng): 240000
', CAST(0x0000A25900AAEF00 AS DateTime), NULL, 0, NULL, 10, 1408, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (104, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
HP1- Đường lối QS của Đảng (chưa đóng): 240000
HP2 - Công tác Quốc phòng- An ninh (chưa đóng): 240000
Kỹ thuật điền kinh (chưa đóng): 120000
Đường lối cách mạng của ĐCS Việt Nam (chưa đóng): 360000
Địa chất công trình (chưa đóng): 240000
Vật liệu xây dựng (chưa đóng): 360000
Xác suất thống kê (Kỹ thuật) (chưa đóng): 240000
Cơ học kết cấu 1 (chưa đóng): 240000
Trắc địa công trình (chưa đóng): 240000
Sức bền vật liệu 2 (chưa đóng): 240000
', CAST(0x0000A25900AAF4E5 AS DateTime), NULL, 0, NULL, 10, 1411, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (105, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
HP1- Đường lối QS của Đảng (chưa đóng): 240000
Tiếng Anh cơ bản 3 (chưa đóng): 360000
', CAST(0x0000A25900AB00D4 AS DateTime), NULL, 0, NULL, 10, 1421, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (106, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
HP1- Đường lối QS của Đảng (chưa đóng): 240000
Kỹ thuật điền kinh (chưa đóng): 120000
Tiếng Anh cơ bản 2 (chưa đóng): 360000
Địa chất công trình (chưa đóng): 240000
Vật liệu xây dựng (chưa đóng): 360000
Xác suất thống kê (Kỹ thuật) (chưa đóng): 240000
Cơ học kết cấu 1 (chưa đóng): 240000
Trắc địa công trình (chưa đóng): 240000
Sức bền vật liệu 2 (chưa đóng): 240000
Nguyên lý CB của CNMLN 2 (chưa đóng): 360000
Giáo dục quốc phòng HP3+4 (chưa đóng): 480000
', CAST(0x0000A25900AB3482 AS DateTime), NULL, 0, NULL, 10, 1451, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (107, N'Cảnh báo học tập', N'Học kỳ này bạn có thể bị cảnh cáo học tập do điểm trung bình môn học tập hiện tại là 0.0, nhỏ hơn mức trung bình học tập tối thiểu. ', CAST(0x0000A25900ABE5B9 AS DateTime), NULL, 0, NULL, 10, 2950, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (108, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bóng chuyền (chưa đóng): 120000
Tư tưởng Hồ Chí Minh (chưa đóng): 240000
Tiếng Anh cơ bản 2 (chưa đóng): 360000
Nguyên lý CB của CNMLN 2 (chưa đóng): 360000
Lý thuyết tàu (chưa đóng): 240000
Kinh tế vi mô 1 (chưa đóng): 240000
Toán cao cấp C2 (chưa đóng): 240000
', CAST(0x0000A25900ABED01 AS DateTime), NULL, 0, NULL, 10, 2954, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (109, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bóng chuyền (chưa đóng): 120000
Tư tưởng Hồ Chí Minh (chưa đóng): 240000
Tiếng Anh cơ bản 2 (chưa đóng): 360000
Nguyên lý CB của CNMLN 2 (chưa đóng): 360000
Lý thuyết tàu (chưa đóng): 240000
Kinh tế vi mô 1 (chưa đóng): 240000
Toán cao cấp C2 (chưa đóng): 240000
', CAST(0x0000A25900ABEE87 AS DateTime), NULL, 0, NULL, 10, 2955, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (110, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bơi lội (chưa đóng): 120000
Vẽ kỹ thuật – Autocad (chưa đóng): 240000
Sức bền vật liệu 1 (chưa đóng): 240000
Cơ chất lỏng (chưa đóng): 360000
Kỹ thuật điện (chưa đóng): 240000
Nguyên lý máy (Đóng tàu) (chưa đóng): 480000
Vật liệu kỹ thuật (Đóng tàu) (chưa đóng): 360000
Thực tập cơ khí (Khoa Máy khai thác) (chưa đóng): 480000
Toán chuyên đề (Khoa Đóng tàu) (chưa đóng): 240000
', CAST(0x0000A25900ABFB7D AS DateTime), NULL, 0, NULL, 10, 3025, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (111, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bơi lội (chưa đóng): 120000
Sức bền vật liệu 1 (chưa đóng): 240000
Cơ chất lỏng (chưa đóng): 360000
Vẽ tàu (chưa đóng): 120000
Dung sai kỹ thuật đo (chưa đóng): 240000
Kỹ thuật điện (chưa đóng): 240000
Nguyên lý máy (Đóng tàu) (chưa đóng): 480000
Vật liệu kỹ thuật (Đóng tàu) (chưa đóng): 360000
Thực tập cơ khí (Khoa Máy khai thác) (chưa đóng): 480000
Toán chuyên đề (Khoa Đóng tàu) (chưa đóng): 240000
', CAST(0x0000A25900ABFDE2 AS DateTime), NULL, 0, NULL, 10, 3026, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (112, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Giải tích 2 (chưa đóng): 480000
Vật lý 2 (chưa đóng): 360000
Sức bền vật liệu (chưa đóng): 240000
Thể thao chuyên ngành hàng hải (ĐKTB,MTB) (chưa đóng): 120000
Thực tập sỹ quan (chưa đóng): 480000
', CAST(0x0000A25900AC0BEF AS DateTime), NULL, 0, NULL, 10, 9250, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (113, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu (chưa đóng): 240000
Điện tàu thuỷ 1 (chưa đóng): 480000
Động cơ đốt trong1 (chưa đóng): 480000
Máy phụ 1 (tiếng Việt) (chưa đóng): 480000
Thiết bị trao đổi nhiệt (chưa đóng): 240000
Hóa kỹ thuật (chưa đóng): 240000
Kết cấu và lý thuyết tàu (chưa đóng): 240000
Kỹ thuật gia công cơ khí 2 (chưa đóng): 240000
Nhiệt kỹ thuật (chưa đóng): 480000
Tiếng Anh chuyên ngành MKT 1 (chưa đóng): 360000
Thực tập thợ máy 1 (chưa đóng): 840000
', CAST(0x0000A25900AC2FF1 AS DateTime), NULL, 0, NULL, 10, 9264, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (114, N'Mai bao ve', N'<b><u>Mai</u></b> bao ve day =)))<br><img src="http://"><img title="Image: http://anh.24h.com.vn/upload/1-2013/images/2013-01-21/1358732480-ngoc-trinh--3-.jpg" src="http://anh.24h.com.vn/upload/1-2013/images/2013-01-21/1358732480-ngoc-trinh--3-.jpg"><br>', CAST(0x0000A25900B6B28C AS DateTime), NULL, 1, NULL, 1, 3, 0, 0)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (116, N'Meo con long vang', N'Meo con long vang<br>', CAST(0x0000A25900B80EE3 AS DateTime), NULL, 1, NULL, 1, 3, 0, 0)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (119, N'Đi ăn cơm đê', N'Phúc đang đợi<br>', CAST(0x0000A25900C21C0F AS DateTime), NULL, 1, NULL, 3, 1, 1, 0)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (121, N'Gửi ngay', N'Gửi ngay á?<br>', CAST(0x0000A25900DBEB9D AS DateTime), NULL, 0, NULL, 3, 1, 1, 0)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (123, N'test test test', N'=============================<br>', CAST(0x0000A25900E0364A AS DateTime), NULL, 1, NULL, 3, 1, 1, 0)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (125, N'test test test', N'=============================<br>', CAST(0x0000A25900E51969 AS DateTime), NULL, 0, NULL, 3, 1, 1, 0)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (127, N'7365765', N'=============================<br>', CAST(0x0000A25900E52ABE AS DateTime), NULL, 0, NULL, 3, 1, 1, 0)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (129, N'Về ăn cơm', N'Cơm k?<br>', CAST(0x0000A25900ED240E AS DateTime), NULL, 0, NULL, 3, 1, 1, 0)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (131, N'Về ăn cơm', N'Cơm k?<br>', CAST(0x0000A25900ED7C79 AS DateTime), NULL, 0, NULL, 3, 1, 1, 0)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (133, N'Mai gửi báo cáo tóm tắt', N'Mai là hạn cuối<br>', CAST(0x0000A25900EDA6FD AS DateTime), NULL, 0, NULL, 3, 1, 1, 0)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (134, N'test test test', N'test test test<br>', CAST(0x0000A25900F0A32C AS DateTime), NULL, 1, NULL, 1, 3, 0, 0)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (135, N'test test test', N'test test test<br>', CAST(0x0000A25900F0A35D AS DateTime), NULL, 1, NULL, 1, 3, 1, 0)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (136, N'dasdsadsa', N'dasdsadsadsa', CAST(0x0000A25900F11D38 AS DateTime), NULL, 1, NULL, 1, 3, 0, 0)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (137, N'dasdsadsa', N'dasdsadsadsa', CAST(0x0000A25900F11D38 AS DateTime), NULL, 1, NULL, 1, 3, 1, 0)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (138, N'Ngày mai bảo vệ đồ án', N'Tối hoàn thành<br>', CAST(0x0000A25901166075 AS DateTime), NULL, 1, NULL, 3, 1, 0, 0)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (139, N'Ngày mai bảo vệ đồ án', N'Tối hoàn thành<br>', CAST(0x0000A25901166076 AS DateTime), NULL, 0, NULL, 3, 1, 1, 0)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (140, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E00C18650 AS DateTime), NULL, 0, NULL, 10, 889, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (141, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E00C18B62 AS DateTime), NULL, 0, NULL, 10, 891, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (142, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E00C18FA7 AS DateTime), NULL, 0, NULL, 10, 894, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (143, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E00C19245 AS DateTime), NULL, 0, NULL, 10, 895, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (144, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 450000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
', CAST(0x0000A26E00C19493 AS DateTime), NULL, 0, NULL, 10, 896, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (145, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E00C1974B AS DateTime), NULL, 0, NULL, 10, 897, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (146, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01009193 AS DateTime), NULL, 0, NULL, 10, 889, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (147, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E01009750 AS DateTime), NULL, 0, NULL, 10, 891, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (148, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01009C8B AS DateTime), NULL, 0, NULL, 10, 894, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (149, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01009F6E AS DateTime), NULL, 0, NULL, 10, 895, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (150, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 450000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
', CAST(0x0000A26E0100A198 AS DateTime), NULL, 0, NULL, 10, 896, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (151, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0100A426 AS DateTime), NULL, 0, NULL, 10, 897, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (152, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0100A702 AS DateTime), NULL, 0, NULL, 10, 898, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (153, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E0100A96D AS DateTime), NULL, 0, NULL, 10, 899, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (154, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0100AD3C AS DateTime), NULL, 0, NULL, 10, 901, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (155, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0100AF95 AS DateTime), NULL, 0, NULL, 10, 903, 0, 1)
GO
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (156, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đường lối CM của ĐCS Việt Nam (chưa đóng): 345000
Đường lối CM của ĐCS Việt Nam (chưa đóng): 345000
Tư tưởng Hồ Chí Minh (chưa đóng): 230000
Tiếng Anh cơ bản 3 (chưa đóng): 345000
Đại số (chưa đóng): 345000
Vật lý 2 (chưa đóng): 345000
Cơ lý thuyết (chưa đóng): 460000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật nhiệt (chưa đóng): 450000
Toán chuyên đề (Khoa Đóng tàu) (chưa đóng): 230000
Vẽ kỹ thuật cơ khí (chưa đóng): 230000
', CAST(0x0000A26E0100B17A AS DateTime), NULL, 0, NULL, 10, 904, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (157, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0100B3A7 AS DateTime), NULL, 0, NULL, 10, 905, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (158, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Giải tích 1 (chưa đóng): 600000
Vật lý 2 (chưa đóng): 450000
Hình họa (chưa đóng): 300000
Hóa đại cương (chưa đóng): 450000
Sức bền vật liệu 1 (chưa đóng): 300000
Vẽ kỹ thuật cơ khí (chưa đóng): 300000
', CAST(0x0000A26E0100B5DB AS DateTime), NULL, 0, NULL, 10, 906, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (159, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0100B838 AS DateTime), NULL, 0, NULL, 10, 907, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (160, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0100BBB4 AS DateTime), NULL, 0, NULL, 10, 909, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (161, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0100BF6C AS DateTime), NULL, 0, NULL, 10, 911, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (162, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0100C1BF AS DateTime), NULL, 0, NULL, 10, 912, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (163, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0100C5B8 AS DateTime), NULL, 0, NULL, 10, 914, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (164, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0100C7F0 AS DateTime), NULL, 0, NULL, 10, 915, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (165, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0100CB57 AS DateTime), NULL, 0, NULL, 10, 917, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (166, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E0100CD83 AS DateTime), NULL, 0, NULL, 10, 918, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (167, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E0100CFCC AS DateTime), NULL, 0, NULL, 10, 920, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (168, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0100D22C AS DateTime), NULL, 0, NULL, 10, 921, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (169, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0100D73C AS DateTime), NULL, 0, NULL, 10, 924, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (170, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0100D989 AS DateTime), NULL, 0, NULL, 10, 925, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (171, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0100DBFF AS DateTime), NULL, 0, NULL, 10, 926, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (172, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0100DE5C AS DateTime), NULL, 0, NULL, 10, 927, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (173, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Vẽ tàu (chưa đóng): 150000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0100E0E8 AS DateTime), NULL, 0, NULL, 10, 928, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (174, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0100E32F AS DateTime), NULL, 0, NULL, 10, 929, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (175, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0100E54F AS DateTime), NULL, 0, NULL, 10, 930, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (176, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0100E742 AS DateTime), NULL, 0, NULL, 10, 931, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (177, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0100E9C8 AS DateTime), NULL, 0, NULL, 10, 932, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (178, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0100EC68 AS DateTime), NULL, 0, NULL, 10, 933, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (179, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0100EEE3 AS DateTime), NULL, 0, NULL, 10, 934, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (180, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0100F0E1 AS DateTime), NULL, 0, NULL, 10, 935, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (181, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0100F382 AS DateTime), NULL, 0, NULL, 10, 936, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (182, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Giải tích 1 (chưa đóng): 600000
Vật lý 2 (chưa đóng): 450000
Hình họa (chưa đóng): 300000
Hóa đại cương (chưa đóng): 450000
Sức bền vật liệu 1 (chưa đóng): 300000
', CAST(0x0000A26E0100F6CB AS DateTime), NULL, 0, NULL, 10, 938, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (183, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0100F8D9 AS DateTime), NULL, 0, NULL, 10, 939, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (184, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0100FB22 AS DateTime), NULL, 0, NULL, 10, 940, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (185, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0100FD34 AS DateTime), NULL, 0, NULL, 10, 941, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (186, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E010100AB AS DateTime), NULL, 0, NULL, 10, 943, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (187, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 1 (chưa đóng): 300000
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01010304 AS DateTime), NULL, 0, NULL, 10, 944, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (188, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01010529 AS DateTime), NULL, 0, NULL, 10, 945, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (189, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0101076B AS DateTime), NULL, 0, NULL, 10, 947, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (190, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 1 (chưa đóng): 230000
Kỹ thuật điện (chưa đóng): 230000
Nguyên lý máy (Đóng tàu) (chưa đóng): 460000
Vật liệu kỹ thuật (Đóng tàu) (chưa đóng): 345000
Thực tập cơ khí (Khoa Máy khai thác) (chưa đóng): 460000
', CAST(0x0000A26E01010930 AS DateTime), NULL, 0, NULL, 10, 948, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (191, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01010B5C AS DateTime), NULL, 0, NULL, 10, 949, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (192, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01010F08 AS DateTime), NULL, 0, NULL, 10, 951, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (193, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 1 (chưa đóng): 300000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01011367 AS DateTime), NULL, 0, NULL, 10, 953, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (194, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bơi lội (chưa đóng): 115000
Sức bền vật liệu 1 (chưa đóng): 230000
Sức bền vật liệu 2 (chưa đóng): 300000
Cơ chất lỏng (chưa đóng): 345000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật điện (chưa đóng): 230000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
Nguyên lý máy (Đóng tàu) (chưa đóng): 460000
Vật liệu kỹ thuật (Đóng tàu) (chưa đóng): 345000
Toán chuyên đề (Khoa Đóng tàu) (chưa đóng): 230000
', CAST(0x0000A26E010115E2 AS DateTime), NULL, 0, NULL, 10, 954, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (195, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01011813 AS DateTime), NULL, 0, NULL, 10, 955, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (196, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01011B75 AS DateTime), NULL, 0, NULL, 10, 957, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (197, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tư tưởng Hồ Chí Minh (chưa đóng): 300000
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
Vẽ kỹ thuật cơ khí (chưa đóng): 300000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E01011E07 AS DateTime), NULL, 0, NULL, 10, 958, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (198, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01012218 AS DateTime), NULL, 0, NULL, 10, 960, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (199, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01012506 AS DateTime), NULL, 0, NULL, 10, 961, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (200, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01012781 AS DateTime), NULL, 0, NULL, 10, 962, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (201, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01012B25 AS DateTime), NULL, 0, NULL, 10, 964, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (202, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01012D93 AS DateTime), NULL, 0, NULL, 10, 965, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (203, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bơi lội (chưa đóng): 115000
Đường lối CM của ĐCS Việt Nam (chưa đóng): 345000
Tư tưởng Hồ Chí Minh (chưa đóng): 230000
Tiếng Anh cơ bản 2 (chưa đóng): 345000
Tiếng Anh cơ bản 3 (chưa đóng): 345000
Đại số (chưa đóng): 345000
Vật lý 1 (chưa đóng): 345000
Vật lý 2 (chưa đóng): 345000
Vẽ kỹ thuật – Autocad (chưa đóng): 230000
Cơ lý thuyết (chưa đóng): 460000
Sức bền vật liệu 1 (chưa đóng): 230000
Cơ chất lỏng (chưa đóng): 345000
Kỹ thuật điện (chưa đóng): 230000
Nguyên lý máy (Đóng tàu) (chưa đóng): 460000
Vật liệu kỹ thuật (Đóng tàu) (chưa đóng): 345000
Toán chuyên đề (Khoa Đóng tàu) (chưa đóng): 230000
Vẽ kỹ thuật cơ khí (chưa đóng): 230000
', CAST(0x0000A26E01012FF7 AS DateTime), NULL, 0, NULL, 10, 966, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (204, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0101325C AS DateTime), NULL, 0, NULL, 10, 967, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (205, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0101362D AS DateTime), NULL, 0, NULL, 10, 969, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (206, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Cơ lý thuyết (chưa đóng): 600000
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E010138BE AS DateTime), NULL, 0, NULL, 10, 970, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (207, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bơi lội (chưa đóng): 115000
Giải tích 2 (chưa đóng): 460000
Sức bền vật liệu 1 (chưa đóng): 230000
Sức bền vật liệu 2 (chưa đóng): 300000
Cơ chất lỏng (chưa đóng): 345000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật điện (chưa đóng): 230000
Kỹ thuật nhiệt (chưa đóng): 450000
Nguyên lý máy (Đóng tàu) (chưa đóng): 460000
Vật liệu kỹ thuật (Đóng tàu) (chưa đóng): 345000
Toán chuyên đề (Khoa Đóng tàu) (chưa đóng): 230000
', CAST(0x0000A26E01013B04 AS DateTime), NULL, 0, NULL, 10, 971, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (208, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01013DA5 AS DateTime), NULL, 0, NULL, 10, 972, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (209, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01014177 AS DateTime), NULL, 0, NULL, 10, 974, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (210, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 450000
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E010143DA AS DateTime), NULL, 0, NULL, 10, 975, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (211, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0101466C AS DateTime), NULL, 0, NULL, 10, 976, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (212, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01014878 AS DateTime), NULL, 0, NULL, 10, 977, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (213, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01014A90 AS DateTime), NULL, 0, NULL, 10, 978, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (214, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Vẽ kỹ thuật – Autocad (chưa đóng): 300000
Cơ lý thuyết (chưa đóng): 600000
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01014E80 AS DateTime), NULL, 0, NULL, 10, 979, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (215, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0101511D AS DateTime), NULL, 0, NULL, 10, 980, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (216, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01015638 AS DateTime), NULL, 0, NULL, 10, 982, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (217, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01015856 AS DateTime), NULL, 0, NULL, 10, 983, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (218, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bơi lội (chưa đóng): 115000
Sức bền vật liệu 1 (chưa đóng): 230000
Sức bền vật liệu 2 (chưa đóng): 300000
Cơ chất lỏng (chưa đóng): 345000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật điện (chưa đóng): 230000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
Nguyên lý máy (Đóng tàu) (chưa đóng): 460000
Vật liệu kỹ thuật (Đóng tàu) (chưa đóng): 345000
Thực tập cơ khí (Khoa Máy khai thác) (chưa đóng): 460000
Toán chuyên đề (Khoa Đóng tàu) (chưa đóng): 230000
', CAST(0x0000A26E01015ACA AS DateTime), NULL, 0, NULL, 10, 984, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (219, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Sức bền vật liệu 2 (chưa đóng): 300000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01015CB9 AS DateTime), NULL, 0, NULL, 10, 985, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (220, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01015EF0 AS DateTime), NULL, 0, NULL, 10, 986, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (221, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0101612B AS DateTime), NULL, 0, NULL, 10, 987, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (222, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0101634D AS DateTime), NULL, 0, NULL, 10, 988, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (223, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0101668F AS DateTime), NULL, 0, NULL, 10, 990, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (224, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01016ACA AS DateTime), NULL, 0, NULL, 10, 991, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (225, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Giải tích 2 (chưa đóng): 600000
Nguyên lý CB của CNMLN 1 (chưa đóng): 300000
', CAST(0x0000A26E01016CC4 AS DateTime), NULL, 0, NULL, 10, 992, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (226, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01016EF8 AS DateTime), NULL, 0, NULL, 10, 993, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (227, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0101727F AS DateTime), NULL, 0, NULL, 10, 995, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (228, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Cơ lý thuyết (chưa đóng): 600000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0101752F AS DateTime), NULL, 0, NULL, 10, 996, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (229, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E01017815 AS DateTime), NULL, 0, NULL, 10, 1134, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (230, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0101797D AS DateTime), NULL, 0, NULL, 10, 1135, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (231, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E01017B25 AS DateTime), NULL, 0, NULL, 10, 1136, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (232, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E01017D09 AS DateTime), NULL, 0, NULL, 10, 1137, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (233, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E01017E9B AS DateTime), NULL, 0, NULL, 10, 1138, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (234, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0101802B AS DateTime), NULL, 0, NULL, 10, 1139, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (235, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E01018225 AS DateTime), NULL, 0, NULL, 10, 1140, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (236, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E010183E4 AS DateTime), NULL, 0, NULL, 10, 1141, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (237, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0101870D AS DateTime), NULL, 0, NULL, 10, 1143, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (238, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E01018BA9 AS DateTime), NULL, 0, NULL, 10, 1146, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (239, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E01018E02 AS DateTime), NULL, 0, NULL, 10, 1147, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (240, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E01019090 AS DateTime), NULL, 0, NULL, 10, 1149, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (241, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kinh tế xây dựng (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0101970E AS DateTime), NULL, 0, NULL, 10, 1150, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (242, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Kết cấu thép (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E01019B1A AS DateTime), NULL, 0, NULL, 10, 1151, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (243, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E01019D6B AS DateTime), NULL, 0, NULL, 10, 1152, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (244, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0101A08C AS DateTime), NULL, 0, NULL, 10, 1153, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (245, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0101A45D AS DateTime), NULL, 0, NULL, 10, 1154, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (246, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0101A85A AS DateTime), NULL, 0, NULL, 10, 1155, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (247, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0101ACCA AS DateTime), NULL, 0, NULL, 10, 1157, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (248, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E0101B24F AS DateTime), NULL, 0, NULL, 10, 1158, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (249, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E0101B681 AS DateTime), NULL, 0, NULL, 10, 1159, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (250, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Luật xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học môi trường liên tục (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E0101B9C1 AS DateTime), NULL, 0, NULL, 10, 1160, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (251, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0101BCB3 AS DateTime), NULL, 0, NULL, 10, 1161, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (252, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0101BF3E AS DateTime), NULL, 0, NULL, 10, 1162, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (253, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0101C2B4 AS DateTime), NULL, 0, NULL, 10, 1163, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (254, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bơi lội (chưa đóng): 115000
Kỹ thuật bóng chuyền (chưa đóng): 115000
Đường lối CM của ĐCS Việt Nam (chưa đóng): 345000
Địa chất công trình (chưa đóng): 230000
Vật liệu xây dựng (chưa đóng): 345000
Xác suất thống kê (Kỹ thuật) (chưa đóng): 230000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 1 (chưa đóng): 230000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Trắc địa công trình (chưa đóng): 230000
Cơ lý thuyết (chưa đóng): 600000
Thuỷ văn công trình (chưa đóng): 450000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E0101C806 AS DateTime), NULL, 0, NULL, 10, 1164, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (255, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
HP2 - Công tác Quốc phòng- An ninh (chưa đóng): 300000
Bê tông cốt thép (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Cơ lý thuyết (chưa đóng): 600000
Kết cấu thép (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E0101CAF7 AS DateTime), NULL, 0, NULL, 10, 1165, 0, 1)
GO
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (256, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
Sức bền vật liệu 1 (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E0101CE0D AS DateTime), NULL, 0, NULL, 10, 1166, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (257, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E0101D08D AS DateTime), NULL, 0, NULL, 10, 1167, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (258, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E0101D3B4 AS DateTime), NULL, 0, NULL, 10, 1168, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (259, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
HP2 - Công tác Quốc phòng- An ninh (chưa đóng): 230000
Kỹ thuật bơi lội (chưa đóng): 115000
Đường lối CM của ĐCS Việt Nam (chưa đóng): 345000
Tư tưởng Hồ Chí Minh (chưa đóng): 230000
Tiếng Anh cơ bản 3 (chưa đóng): 345000
Đại số (chưa đóng): 345000
Địa chất công trình (chưa đóng): 230000
Vật liệu xây dựng (chưa đóng): 345000
Tin học đại cương (chưa đóng): 345000
Xác suất thống kê (Kỹ thuật) (chưa đóng): 230000
Trắc địa công trình (chưa đóng): 230000
Sức bền vật liệu 1 (chưa đóng): 230000
Nguyên lý CB của CNMLN 1 (chưa đóng): 230000
', CAST(0x0000A26E0101D6F6 AS DateTime), NULL, 0, NULL, 10, 1169, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (260, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E0101DD59 AS DateTime), NULL, 0, NULL, 10, 1170, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (261, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tư tưởng Hồ Chí Minh (chưa đóng): 230000
Tiếng Anh cơ bản 3 (chưa đóng): 345000
Đại số (chưa đóng): 345000
Vật lý 2 (chưa đóng): 345000
Địa chất công trình (chưa đóng): 230000
Sức bền vật liệu 1 (chưa đóng): 230000
', CAST(0x0000A26E0101E008 AS DateTime), NULL, 0, NULL, 10, 1171, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (262, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0101E2A0 AS DateTime), NULL, 0, NULL, 10, 1172, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (263, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0101E91A AS DateTime), NULL, 0, NULL, 10, 1174, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (264, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0101ECB4 AS DateTime), NULL, 0, NULL, 10, 1175, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (265, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật điền kinh (chưa đóng): 115000
Đường lối CM của ĐCS Việt Nam (chưa đóng): 345000
Địa chất công trình (chưa đóng): 230000
Vật liệu xây dựng (chưa đóng): 345000
Xác suất thống kê (Kỹ thuật) (chưa đóng): 230000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Trắc địa công trình (chưa đóng): 230000
Cơ lý thuyết (chưa đóng): 600000
Thuỷ văn công trình (chưa đóng): 450000
Kỹ thuật bóng chuyền (chưa đóng): 150000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E0101F246 AS DateTime), NULL, 0, NULL, 10, 1176, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (266, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Các phương pháp số (chưa đóng): 450000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
', CAST(0x0000A26E0101F95C AS DateTime), NULL, 0, NULL, 10, 1177, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (267, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0101FB9A AS DateTime), NULL, 0, NULL, 10, 1178, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (268, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
', CAST(0x0000A26E0101FDB0 AS DateTime), NULL, 0, NULL, 10, 1179, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (269, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Vật liệu xây dựng (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
', CAST(0x0000A26E010200D2 AS DateTime), NULL, 0, NULL, 10, 1180, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (270, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Vật liệu xây dựng (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
', CAST(0x0000A26E01020361 AS DateTime), NULL, 0, NULL, 10, 1181, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (271, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E01020549 AS DateTime), NULL, 0, NULL, 10, 1182, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (272, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0102077E AS DateTime), NULL, 0, NULL, 10, 1183, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (273, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0102095B AS DateTime), NULL, 0, NULL, 10, 1184, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (274, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E01020B96 AS DateTime), NULL, 0, NULL, 10, 1185, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (275, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E01020E13 AS DateTime), NULL, 0, NULL, 10, 1187, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (276, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Vật lý 2 (chưa đóng): 450000
Bê tông cốt thép (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học môi trường liên tục (chưa đóng): 300000
Sức bền vật liệu 1 (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E01020F8F AS DateTime), NULL, 0, NULL, 10, 1188, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (277, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
HP2 - Công tác Quốc phòng- An ninh (chưa đóng): 230000
Đường lối CM của ĐCS Việt Nam (chưa đóng): 345000
Vẽ kỹ thuật – Autocad (chưa đóng): 230000
Trắc địa công trình (chưa đóng): 230000
', CAST(0x0000A26E010210AE AS DateTime), NULL, 0, NULL, 10, 1189, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (278, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0102124E AS DateTime), NULL, 0, NULL, 10, 1190, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (279, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Sức bền vật liệu 1 (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E010213E7 AS DateTime), NULL, 0, NULL, 10, 1191, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (280, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 450000
Bê tông cốt thép (chưa đóng): 450000
Vật liệu xây dựng (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
', CAST(0x0000A26E010215B1 AS DateTime), NULL, 0, NULL, 10, 1192, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (281, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E010218AB AS DateTime), NULL, 0, NULL, 10, 1195, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (282, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E01021A28 AS DateTime), NULL, 0, NULL, 10, 1196, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (283, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Luật xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Công trình thuỷ công trong NMĐT (chưa đóng): 450000
Kết cấu thép (chưa đóng): 300000
Kinh tế xây dựng (chưa đóng): 300000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E01021C3E AS DateTime), NULL, 0, NULL, 10, 1197, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (284, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Thiết bị hàng hải (chưa đóng): 300000
Hàng hải cơ sở (chưa đóng): 450000
Khí tượng, thủy, hải văn (chưa đóng): 450000
Máy tàu thủy (chưa đóng): 300000
Trắc địa cơ sở (chưa đóng): 600000
Vật liệu xây dựng (chưa đóng): 450000
Cơ lý thuyết (chưa đóng): 300000
Sức bền vật liệu (chưa đóng): 300000
Kỹ thuật bóng chuyền (chưa đóng): 150000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E01021F00 AS DateTime), NULL, 0, NULL, 10, 1215, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (285, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0102213D AS DateTime), NULL, 0, NULL, 10, 1264, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (286, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01022435 AS DateTime), NULL, 0, NULL, 10, 1267, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (287, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kiến trúc máy tính (chưa đóng): 600000
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E010226EA AS DateTime), NULL, 0, NULL, 10, 1279, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (288, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E010228EC AS DateTime), NULL, 0, NULL, 10, 1294, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (289, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01022B95 AS DateTime), NULL, 0, NULL, 10, 1312, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (290, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Đại số (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01022E65 AS DateTime), NULL, 0, NULL, 10, 1337, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (291, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01023125 AS DateTime), NULL, 0, NULL, 10, 1338, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (292, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01023468 AS DateTime), NULL, 0, NULL, 10, 1406, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (293, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
HP1- Đường lối QS của Đảng (chưa đóng): 230000
HP2 - Công tác Quốc phòng- An ninh (chưa đóng): 230000
Đường lối CM của ĐCS Việt Nam (chưa đóng): 345000
Địa chất công trình (chưa đóng): 230000
Vật liệu xây dựng (chưa đóng): 345000
Xác suất thống kê (Kỹ thuật) (chưa đóng): 230000
Cơ học kết cấu 1 (chưa đóng): 230000
Trắc địa công trình (chưa đóng): 230000
Sức bền vật liệu 1 (chưa đóng): 230000
Sức bền vật liệu 2 (chưa đóng): 230000
', CAST(0x0000A26E01023701 AS DateTime), NULL, 0, NULL, 10, 1407, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (294, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tư tưởng Hồ Chí Minh (chưa đóng): 230000
Tiếng Anh cơ bản 3 (chưa đóng): 345000
Đại số (chưa đóng): 345000
Vật lý 2 (chưa đóng): 345000
Thực tập cơ khí (Khoa công trình) (chưa đóng): 230000
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 345000
Sức bền vật liệu 1 (chưa đóng): 230000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E010239FD AS DateTime), NULL, 0, NULL, 10, 1408, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (295, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01023C66 AS DateTime), NULL, 0, NULL, 10, 1409, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (296, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01023EB5 AS DateTime), NULL, 0, NULL, 10, 1410, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (297, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
HP1- Đường lối QS của Đảng (chưa đóng): 230000
Kỹ thuật điền kinh (chưa đóng): 115000
Đường lối CM của ĐCS Việt Nam (chưa đóng): 345000
Địa chất công trình (chưa đóng): 230000
Vật liệu xây dựng (chưa đóng): 345000
Xác suất thống kê (Kỹ thuật) (chưa đóng): 230000
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 1 (chưa đóng): 230000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Trắc địa công trình (chưa đóng): 230000
Sức bền vật liệu 2 (chưa đóng): 230000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01024139 AS DateTime), NULL, 0, NULL, 10, 1411, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (298, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E01024395 AS DateTime), NULL, 0, NULL, 10, 1412, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (299, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E010245AF AS DateTime), NULL, 0, NULL, 10, 1413, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (300, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01024A40 AS DateTime), NULL, 0, NULL, 10, 1416, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (301, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học môi trường liên tục (chưa đóng): 300000
Sức bền vật liệu 1 (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01024CC3 AS DateTime), NULL, 0, NULL, 10, 1417, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (302, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01024F41 AS DateTime), NULL, 0, NULL, 10, 1418, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (303, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 450000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0102516C AS DateTime), NULL, 0, NULL, 10, 1419, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (304, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0102553D AS DateTime), NULL, 0, NULL, 10, 1421, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (305, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đường lối CM của ĐCS Việt Nam (chưa đóng): 450000
Vật liệu xây dựng (chưa đóng): 450000
Tin học ứng dụng (chưa đóng): 450000
Sức bền vật liệu 1 (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01025756 AS DateTime), NULL, 0, NULL, 10, 1422, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (306, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01025BA7 AS DateTime), NULL, 0, NULL, 10, 1424, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (307, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E01025E16 AS DateTime), NULL, 0, NULL, 10, 1425, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (308, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01026092 AS DateTime), NULL, 0, NULL, 10, 1426, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (309, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01026308 AS DateTime), NULL, 0, NULL, 10, 1427, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (310, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01026592 AS DateTime), NULL, 0, NULL, 10, 1428, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (311, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Sức bền vật liệu 2 (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E010268B9 AS DateTime), NULL, 0, NULL, 10, 1429, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (312, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01026AFE AS DateTime), NULL, 0, NULL, 10, 1430, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (313, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học môi trường liên tục (chưa đóng): 300000
Sức bền vật liệu 2 (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01026D29 AS DateTime), NULL, 0, NULL, 10, 1432, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (314, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01027015 AS DateTime), NULL, 0, NULL, 10, 1433, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (315, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0102745D AS DateTime), NULL, 0, NULL, 10, 1435, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (316, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0102775F AS DateTime), NULL, 0, NULL, 10, 1436, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (317, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Vật lý 2 (chưa đóng): 450000
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E01027AD8 AS DateTime), NULL, 0, NULL, 10, 1437, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (318, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01027D9F AS DateTime), NULL, 0, NULL, 10, 1438, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (319, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01028028 AS DateTime), NULL, 0, NULL, 10, 1439, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (320, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E010282C0 AS DateTime), NULL, 0, NULL, 10, 1440, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (321, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01028709 AS DateTime), NULL, 0, NULL, 10, 1441, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (322, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tư tưởng Hồ Chí Minh (chưa đóng): 300000
Kết cấu gạch đá gỗ (chưa đóng): 300000
Các phương pháp số (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Sức bền vật liệu 2 (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E01028A92 AS DateTime), NULL, 0, NULL, 10, 1442, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (323, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Sức bền vật liệu 2 (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01028CF2 AS DateTime), NULL, 0, NULL, 10, 1443, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (324, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01028F4A AS DateTime), NULL, 0, NULL, 10, 1444, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (325, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Sức bền vật liệu 2 (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E010291C0 AS DateTime), NULL, 0, NULL, 10, 1445, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (326, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0102945E AS DateTime), NULL, 0, NULL, 10, 1446, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (327, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0102971C AS DateTime), NULL, 0, NULL, 10, 1447, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (328, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01029964 AS DateTime), NULL, 0, NULL, 10, 1448, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (329, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01029B98 AS DateTime), NULL, 0, NULL, 10, 1449, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (330, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01029DCC AS DateTime), NULL, 0, NULL, 10, 1450, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (331, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
HP1- Đường lối QS của Đảng (chưa đóng): 230000
HP2 - Công tác Quốc phòng- An ninh (chưa đóng): 230000
Kỹ thuật điền kinh (chưa đóng): 115000
Tiếng Anh cơ bản 2 (chưa đóng): 345000
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Giải tích 1 (chưa đóng): 600000
Địa chất công trình (chưa đóng): 230000
Địa chất công trình (chưa đóng): 300000
Vật liệu xây dựng (chưa đóng): 345000
Tin học đại cương (chưa đóng): 450000
Xác suất thống kê (Kỹ thuật) (chưa đóng): 230000
Cơ học kết cấu 1 (chưa đóng): 230000
Trắc địa công trình (chưa đóng): 230000
Cơ lý thuyết (chưa đóng): 600000
Sức bền vật liệu 1 (chưa đóng): 300000
Sức bền vật liệu 2 (chưa đóng): 230000
Nguyên lý CB của CNMLN 2 (chưa đóng): 345000
Giáo dục quốc phòng HP3+4 (chưa đóng): 460000
Đường lối QS của Đảng (chưa đóng): 450000
Công tác quốc phòng-an ninh (chưa đóng): 300000
Kỹ thuật cầu lông (chưa đóng): 150000
', CAST(0x0000A26E0102A08D AS DateTime), NULL, 0, NULL, 10, 1451, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (332, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0102A2DD AS DateTime), NULL, 0, NULL, 10, 1452, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (333, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E0102A5A2 AS DateTime), NULL, 0, NULL, 10, 1453, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (334, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0102A862 AS DateTime), NULL, 0, NULL, 10, 1454, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (335, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0102AAF6 AS DateTime), NULL, 0, NULL, 10, 1455, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (336, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Sức bền vật liệu 2 (chưa đóng): 300000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E0102AD9A AS DateTime), NULL, 0, NULL, 10, 1456, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (337, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0102AFFC AS DateTime), NULL, 0, NULL, 10, 1457, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (338, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0102B316 AS DateTime), NULL, 0, NULL, 10, 1458, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (339, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0102B5D4 AS DateTime), NULL, 0, NULL, 10, 1459, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (340, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Kiến trúc dân dụng (chưa đóng): 150000
Kết cấu gạch đá gỗ (chưa đóng): 300000
Kỹ thuật thông gió (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Vật lý kiến trúc (chưa đóng): 300000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0102B993 AS DateTime), NULL, 0, NULL, 10, 1460, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (341, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0102BC4D AS DateTime), NULL, 0, NULL, 10, 1461, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (342, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0102BE82 AS DateTime), NULL, 0, NULL, 10, 1462, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (343, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0102C0BF AS DateTime), NULL, 0, NULL, 10, 1463, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (344, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0102C356 AS DateTime), NULL, 0, NULL, 10, 1464, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (345, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Kỹ thuật thông gió (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0102C58A AS DateTime), NULL, 0, NULL, 10, 1465, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (346, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0102C7A2 AS DateTime), NULL, 0, NULL, 10, 1466, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (347, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Vật lý 2 (chưa đóng): 450000
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0102C9EF AS DateTime), NULL, 0, NULL, 10, 1467, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (348, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật thông gió (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Vật lý kiến trúc (chưa đóng): 300000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0102CE05 AS DateTime), NULL, 0, NULL, 10, 1469, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (349, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0102D20A AS DateTime), NULL, 0, NULL, 10, 1471, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (350, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E0102D61B AS DateTime), NULL, 0, NULL, 10, 1473, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (351, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0102D8D7 AS DateTime), NULL, 0, NULL, 10, 1474, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (352, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0102DC23 AS DateTime), NULL, 0, NULL, 10, 1475, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (353, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kiến trúc máy tính (chưa đóng): 600000
Đường lối CM của ĐCS Việt Nam (chưa đóng): 450000
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Đại số (chưa đóng): 450000
Giải tích 1 (chưa đóng): 600000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E0102E0DB AS DateTime), NULL, 0, NULL, 10, 1483, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (354, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0102E36E AS DateTime), NULL, 0, NULL, 10, 1568, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (355, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0102E5B2 AS DateTime), NULL, 0, NULL, 10, 1569, 0, 1)
GO
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (356, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0102E9F6 AS DateTime), NULL, 0, NULL, 10, 1571, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (357, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0102F33B AS DateTime), NULL, 0, NULL, 10, 1575, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (358, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0102F658 AS DateTime), NULL, 0, NULL, 10, 1576, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (359, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0102FA63 AS DateTime), NULL, 0, NULL, 10, 1578, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (360, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0102FC9B AS DateTime), NULL, 0, NULL, 10, 1579, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (361, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0102FF38 AS DateTime), NULL, 0, NULL, 10, 1580, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (362, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E010301BF AS DateTime), NULL, 0, NULL, 10, 1581, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (363, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0103057D AS DateTime), NULL, 0, NULL, 10, 1583, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (364, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0103079F AS DateTime), NULL, 0, NULL, 10, 1584, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (365, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01030B98 AS DateTime), NULL, 0, NULL, 10, 1586, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (366, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01030DCC AS DateTime), NULL, 0, NULL, 10, 1587, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (367, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01031049 AS DateTime), NULL, 0, NULL, 10, 1588, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (368, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E010312C7 AS DateTime), NULL, 0, NULL, 10, 1589, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (369, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Thiết bị hàng hải (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Hàng hải cơ sở (chưa đóng): 450000
Khí tượng, thủy, hải văn (chưa đóng): 450000
Máy tàu thủy (chưa đóng): 300000
Trắc địa cơ sở (chưa đóng): 600000
Vật liệu xây dựng (chưa đóng): 450000
Hình họa (chưa đóng): 300000
Hóa đại cương (chưa đóng): 450000
', CAST(0x0000A26E01031540 AS DateTime), NULL, 0, NULL, 10, 1590, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (370, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01031799 AS DateTime), NULL, 0, NULL, 10, 1591, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (371, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01031BAE AS DateTime), NULL, 0, NULL, 10, 1593, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (372, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01031DD9 AS DateTime), NULL, 0, NULL, 10, 1594, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (373, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E010321D3 AS DateTime), NULL, 0, NULL, 10, 1596, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (374, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01032417 AS DateTime), NULL, 0, NULL, 10, 1597, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (375, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01032652 AS DateTime), NULL, 0, NULL, 10, 1598, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (376, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E010328EE AS DateTime), NULL, 0, NULL, 10, 1599, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (377, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01032B39 AS DateTime), NULL, 0, NULL, 10, 1600, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (378, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Đại số (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E01032D63 AS DateTime), NULL, 0, NULL, 10, 1601, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (379, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01032F85 AS DateTime), NULL, 0, NULL, 10, 1602, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (380, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0103343E AS DateTime), NULL, 0, NULL, 10, 1604, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (381, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E010336D8 AS DateTime), NULL, 0, NULL, 10, 1605, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (382, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0103394B AS DateTime), NULL, 0, NULL, 10, 1606, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (383, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01033BC7 AS DateTime), NULL, 0, NULL, 10, 1607, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (384, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01033EB6 AS DateTime), NULL, 0, NULL, 10, 1608, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (385, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Đại số (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E01034267 AS DateTime), NULL, 0, NULL, 10, 1609, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (386, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E010346BB AS DateTime), NULL, 0, NULL, 10, 1611, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (387, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E010348C5 AS DateTime), NULL, 0, NULL, 10, 1612, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (388, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01034F3D AS DateTime), NULL, 0, NULL, 10, 1615, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (389, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01035179 AS DateTime), NULL, 0, NULL, 10, 1616, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (390, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Đại số (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01035499 AS DateTime), NULL, 0, NULL, 10, 1617, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (391, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01035897 AS DateTime), NULL, 0, NULL, 10, 2933, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (392, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01035DAC AS DateTime), NULL, 0, NULL, 10, 2935, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (393, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E0103662E AS DateTime), NULL, 0, NULL, 10, 2938, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (394, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0103699C AS DateTime), NULL, 0, NULL, 10, 2939, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (395, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0103717E AS DateTime), NULL, 0, NULL, 10, 2943, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (396, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Đại số (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E0103745C AS DateTime), NULL, 0, NULL, 10, 2944, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (397, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E010376FF AS DateTime), NULL, 0, NULL, 10, 2945, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (398, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01037A14 AS DateTime), NULL, 0, NULL, 10, 2946, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (399, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E010381A6 AS DateTime), NULL, 0, NULL, 10, 2949, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (400, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Đại số (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01038742 AS DateTime), NULL, 0, NULL, 10, 2953, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (401, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bóng chuyền (chưa đóng): 115000
Tư tưởng Hồ Chí Minh (chưa đóng): 230000
Tiếng Anh cơ bản 2 (chưa đóng): 345000
Nguyên lý CB của CNMLN 2 (chưa đóng): 345000
Lý thuyết tàu (chưa đóng): 230000
Kinh tế vi mô 1 (chưa đóng): 230000
Toán cao cấp C2 (chưa đóng): 230000
', CAST(0x0000A26E010388FC AS DateTime), NULL, 0, NULL, 10, 2954, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (402, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bóng chuyền (chưa đóng): 115000
Tư tưởng Hồ Chí Minh (chưa đóng): 230000
Tiếng Anh cơ bản 2 (chưa đóng): 345000
Nguyên lý CB của CNMLN 2 (chưa đóng): 345000
Lý thuyết tàu (chưa đóng): 230000
Kinh tế vi mô 1 (chưa đóng): 230000
Toán cao cấp C2 (chưa đóng): 230000
', CAST(0x0000A26E01038AC1 AS DateTime), NULL, 0, NULL, 10, 2955, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (403, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Đại số (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E010393A1 AS DateTime), NULL, 0, NULL, 10, 2960, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (404, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bơi lội (chưa đóng): 115000
Vẽ kỹ thuật – Autocad (chưa đóng): 230000
Sức bền vật liệu 1 (chưa đóng): 230000
Sức bền vật liệu 2 (chưa đóng): 300000
Cơ chất lỏng (chưa đóng): 345000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật điện (chưa đóng): 230000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
Nguyên lý máy (Đóng tàu) (chưa đóng): 460000
Vật liệu kỹ thuật (Đóng tàu) (chưa đóng): 345000
Thực tập cơ khí (Khoa Máy khai thác) (chưa đóng): 460000
Toán chuyên đề (Khoa Đóng tàu) (chưa đóng): 230000
', CAST(0x0000A26E01039821 AS DateTime), NULL, 0, NULL, 10, 3025, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (405, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bơi lội (chưa đóng): 115000
Sức bền vật liệu 1 (chưa đóng): 230000
Sức bền vật liệu 2 (chưa đóng): 300000
Cơ chất lỏng (chưa đóng): 345000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật điện (chưa đóng): 230000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
Nguyên lý máy (Đóng tàu) (chưa đóng): 460000
Vật liệu kỹ thuật (Đóng tàu) (chưa đóng): 345000
Thực tập cơ khí (Khoa Máy khai thác) (chưa đóng): 460000
Toán chuyên đề (Khoa Đóng tàu) (chưa đóng): 230000
Kỹ thuật bóng chuyền (chưa đóng): 150000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E01039B45 AS DateTime), NULL, 0, NULL, 10, 3026, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (406, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
', CAST(0x0000A26E0103A2B5 AS DateTime), NULL, 0, NULL, 10, 9248, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (407, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
La bàn từ (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0103A566 AS DateTime), NULL, 0, NULL, 10, 9249, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (408, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 1 (chưa đóng): 450000
Điện tàu thuỷ (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Thuỷ nghiệp - Thông hiệu HH 1 (chưa đóng): 300000
', CAST(0x0000A26E0103A8B2 AS DateTime), NULL, 0, NULL, 10, 9250, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (409, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Kết cấu bê tông cốt thép 2 (chưa đóng): 150000
TKMH Kiến trúc dân dụng (chưa đóng): 150000
TKMH Kỹ thuật thi công 2 (chưa đóng): 150000
Kết cấu Bê tông cốt thép 2 (chưa đóng): 450000
Kết cấu thép 2 (chưa đóng): 450000
Kiến trúc dân dụng (chưa đóng): 450000
Kỹ thuật thi công 2 (chưa đóng): 450000
Kỹ thuật thông gió (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Vật lý kiến trúc (chưa đóng): 300000
', CAST(0x0000A26E0103AE23 AS DateTime), NULL, 0, NULL, 10, 9252, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (410, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Tự động điều khiển tàu (chưa đóng): 450000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0103B19F AS DateTime), NULL, 0, NULL, 10, 9253, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (411, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0103B51D AS DateTime), NULL, 0, NULL, 10, 9254, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (412, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Giải tích 1 (chưa đóng): 600000
TKMH Kỹ thuật xử lí nước và nước thải (chưa đóng): 150000
TKMH Kỹ thuật xử lý ô nhiễm môi trường biển (chưa đóng): 150000
Các QTSX cơ bản và nguyên lí SXSH (chưa đóng): 300000
Kỹ thuật xử lí nước và nước thải (chưa đóng): 600000
Kỹ thuật xử lý ô nhiễm môi trường biển (chưa đóng): 600000
Quản lý môi trường (chưa đóng): 450000
Độc học môi trường (chưa đóng): 450000
', CAST(0x0000A26E0103B856 AS DateTime), NULL, 0, NULL, 10, 9255, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (413, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
Thiết bị và kỹ thuật đo (chưa đóng): 300000
', CAST(0x0000A26E0103BB0C AS DateTime), NULL, 0, NULL, 10, 9256, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (414, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0103BDA7 AS DateTime), NULL, 0, NULL, 10, 9257, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (415, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
Thiết bị và kỹ thuật đo (chưa đóng): 300000
', CAST(0x0000A26E0103C065 AS DateTime), NULL, 0, NULL, 10, 9258, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (416, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Lập trình mạng (chưa đóng): 750000
Mạng máy tính (chưa đóng): 600000
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Hệ chuyên gia (chưa đóng): 450000
PTTK hệ thống hướng đối tượng (chưa đóng): 300000
Thiết kế và lập trình Web (chưa đóng): 450000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E0103C340 AS DateTime), NULL, 0, NULL, 10, 9259, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (417, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
Thiết bị và kỹ thuật đo (chưa đóng): 300000
', CAST(0x0000A26E0103C60F AS DateTime), NULL, 0, NULL, 10, 9260, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (418, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu (chưa đóng): 230000
Điện tàu thuỷ 1 (chưa đóng): 460000
Động cơ đốt trong1 (chưa đóng): 460000
Máy phụ 1 (tiếng Việt) (chưa đóng): 460000
Thiết bị trao đổi nhiệt (chưa đóng): 230000
Hóa kỹ thuật (chưa đóng): 230000
Kết cấu và lý thuyết tàu (chưa đóng): 230000
Kỹ thuật gia công cơ khí 2 (chưa đóng): 230000
Nhiệt kỹ thuật (chưa đóng): 460000
Tiếng Anh chuyên ngành MKT 1 (chưa đóng): 345000
Thực tập thợ máy 1 (chưa đóng): 805000
', CAST(0x0000A26E0103CE53 AS DateTime), NULL, 0, NULL, 10, 9264, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (419, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
', CAST(0x0000A26E0103D0E2 AS DateTime), NULL, 0, NULL, 10, 9265, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (420, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Hình họa (chưa đóng): 300000
TKMH Cung cấp điện (chưa đóng): 150000
Chuyên đề 1 (chưa đóng): 300000
Công nghệ CAD – CAM (chưa đóng): 300000
Cung cấp điện (chưa đóng): 450000
Điều khiển Robốt (chưa đóng): 450000
Điều khiển sản suất tích hợp máy tính (chưa đóng): 600000
PLC (chưa đóng): 450000
Trang bị điện điện tử máy gia công KL (chưa đóng): 450000
', CAST(0x0000A26E0103D39C AS DateTime), NULL, 0, NULL, 10, 9268, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (421, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Logistics và VTĐPT (chưa đóng): 300000
Kinh tế lượng (chưa đóng): 450000
Thanh toán quốc tế (chưa đóng): 450000
TKMH Thanh toán quốc tế (chưa đóng): 150000
Bảo hiểm đối ngoại (chưa đóng): 450000
Giao nhận hàng hóa XNK (chưa đóng): 600000
Vận tải-Thuê tàu (chưa đóng): 600000
Phân tích hoạt động kinh tế trong KTN (chưa đóng): 450000
TKMH Phân tích hoạt động kinh tế KTN (chưa đóng): 150000
', CAST(0x0000A26E0103D70C AS DateTime), NULL, 0, NULL, 10, 9269, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (422, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Phân tích hoạt động kinh tế QKD (chưa đóng): 150000
TKMH Quản trị dự án đầu tư (chưa đóng): 150000
Bảo hiểm (chưa đóng): 450000
Quản trị công nghệ (chưa đóng): 300000
Quản trị dự án đầu tư (chưa đóng): 450000
Quản trị hành chính (chưa đóng): 450000
Quản trị sản xuất (chưa đóng): 600000
Phân tích hoạt động kinh tế trong QTKD (chưa đóng): 450000
', CAST(0x0000A26E0103D9FF AS DateTime), NULL, 0, NULL, 10, 9270, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (423, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Logistics và VTĐPT (chưa đóng): 300000
Pháp luật kinh tế (chưa đóng): 450000
Thanh toán quốc tế (chưa đóng): 450000
TKMH Thanh toán quốc tế (chưa đóng): 150000
Bảo hiểm đối ngoại (chưa đóng): 450000
Giao nhận hàng hóa XNK (chưa đóng): 600000
Vận tải-Thuê tàu (chưa đóng): 600000
Phân tích hoạt động kinh tế trong KTN (chưa đóng): 450000
Tiếng anh chuyên ngành KTN2 (chưa đóng): 300000
TKMH Phân tích hoạt động kinh tế KTN (chưa đóng): 150000
', CAST(0x0000A26E0103DE30 AS DateTime), NULL, 0, NULL, 10, 9271, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (424, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bảo hiểm (chưa đóng): 450000
TKMH Phân tích hoạt động kinh tế QKT (chưa đóng): 150000
Kế toán doanh nghiệp (chưa đóng): 300000
Kế toán hành chính sự nghiệp (chưa đóng): 450000
Kế toán quản trị (chưa đóng): 300000
Kiểm toán (chưa đóng): 450000
Quản lý tài chính Nhà nước (chưa đóng): 300000
Phân tích hoạt động kinh tế trong QKT (chưa đóng): 450000
', CAST(0x0000A26E0103E159 AS DateTime), NULL, 0, NULL, 10, 9272, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (425, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 1 (chưa đóng): 450000
Hóa đại cương (chưa đóng): 450000
TKMH Kết cấu bê tông cốt thép 2 (chưa đóng): 150000
TKMH Kiến trúc dân dụng (chưa đóng): 150000
TKMH Kỹ thuật thi công 2 (chưa đóng): 150000
Kiến trúc dân dụng (chưa đóng): 450000
Kỹ thuật thi công 2 (chưa đóng): 450000
Kỹ thuật thông gió (chưa đóng): 300000
Vật lý kiến trúc (chưa đóng): 300000
', CAST(0x0000A26E0103E538 AS DateTime), NULL, 0, NULL, 10, 9273, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (426, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E0103EA97 AS DateTime), NULL, 0, NULL, 10, 9275, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (427, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
La bàn từ (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0103F221 AS DateTime), NULL, 0, NULL, 10, 9279, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (428, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Điện tàu thuỷ (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Luật biển (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0103F60B AS DateTime), NULL, 0, NULL, 10, 9280, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (429, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E0103F8DD AS DateTime), NULL, 0, NULL, 10, 9281, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (430, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0103FB83 AS DateTime), NULL, 0, NULL, 10, 9282, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (431, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đường lối CM của ĐCS Việt Nam (chưa đóng): 345000
Sức bền vật liệu (chưa đóng): 230000
Địa văn hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E0103FE68 AS DateTime), NULL, 0, NULL, 10, 9283, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (432, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010401A0 AS DateTime), NULL, 0, NULL, 10, 9285, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (433, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0104051B AS DateTime), NULL, 0, NULL, 10, 9286, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (434, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Tiếng Anh chuyên ngành ĐKT 1 (chưa đóng): 345000
', CAST(0x0000A26E010408A4 AS DateTime), NULL, 0, NULL, 10, 9287, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (435, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01040C84 AS DateTime), NULL, 0, NULL, 10, 9288, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (436, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
An toàn lao động HH (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
La bàn từ (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01040F23 AS DateTime), NULL, 0, NULL, 10, 9289, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (437, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0104138B AS DateTime), NULL, 0, NULL, 10, 9291, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (438, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0104161C AS DateTime), NULL, 0, NULL, 10, 9292, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (439, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01041CC0 AS DateTime), NULL, 0, NULL, 10, 9295, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (440, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01041F57 AS DateTime), NULL, 0, NULL, 10, 9296, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (441, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010421F5 AS DateTime), NULL, 0, NULL, 10, 9297, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (442, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Máy tàu thủy (chưa đóng): 230000
Máy tàu thủy (chưa đóng): 300000
Cơ lý thuyết (chưa đóng): 300000
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Lý thuyết tàu (chưa đóng): 230000
Tiếng Anh chuyên ngành ĐKT 1 (chưa đóng): 345000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E01042568 AS DateTime), NULL, 0, NULL, 10, 9298, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (443, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01042842 AS DateTime), NULL, 0, NULL, 10, 9299, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (444, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01042B05 AS DateTime), NULL, 0, NULL, 10, 9300, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (445, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01042D78 AS DateTime), NULL, 0, NULL, 10, 9301, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (446, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đường lối CM của ĐCS Việt Nam (chưa đóng): 450000
Sức bền vật liệu (chưa đóng): 230000
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Lý thuyết tàu (chưa đóng): 300000
Tiếng Anh chuyên ngành ĐKT 1 (chưa đóng): 345000
Thực tập sỹ quan (chưa đóng): 600000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E010430B9 AS DateTime), NULL, 0, NULL, 10, 9302, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (447, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 450000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01043387 AS DateTime), NULL, 0, NULL, 10, 9303, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (448, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Cơ lý thuyết (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
La bàn từ (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01043607 AS DateTime), NULL, 0, NULL, 10, 9304, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (449, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
La bàn từ (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010438DA AS DateTime), NULL, 0, NULL, 10, 9305, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (450, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0104413D AS DateTime), NULL, 0, NULL, 10, 9309, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (451, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Cơ lý thuyết (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010443CA AS DateTime), NULL, 0, NULL, 10, 9310, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (452, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Giải tích 1 (chưa đóng): 600000
Cơ lý thuyết (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01044667 AS DateTime), NULL, 0, NULL, 10, 9311, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (453, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010448F1 AS DateTime), NULL, 0, NULL, 10, 9312, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (454, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tư tưởng Hồ Chí Minh (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01044BA1 AS DateTime), NULL, 0, NULL, 10, 9313, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (455, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01044E8C AS DateTime), NULL, 0, NULL, 10, 9314, 0, 1)
GO
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (456, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01045550 AS DateTime), NULL, 0, NULL, 10, 9317, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (457, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010457FE AS DateTime), NULL, 0, NULL, 10, 9318, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (458, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E01045D5F AS DateTime), NULL, 0, NULL, 10, 9320, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (459, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010464FF AS DateTime), NULL, 0, NULL, 10, 9324, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (460, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010469C3 AS DateTime), NULL, 0, NULL, 10, 9326, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (461, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Luật biển (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010471AD AS DateTime), NULL, 0, NULL, 10, 9330, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (462, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0104747D AS DateTime), NULL, 0, NULL, 10, 9332, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (463, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bơi lội (chưa đóng): 115000
Địa văn hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E01047ADE AS DateTime), NULL, 0, NULL, 10, 9335, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (464, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
La bàn từ (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01047D32 AS DateTime), NULL, 0, NULL, 10, 9336, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (465, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01047FA9 AS DateTime), NULL, 0, NULL, 10, 9337, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (466, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0104828B AS DateTime), NULL, 0, NULL, 10, 9338, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (467, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 450000
Cơ lý thuyết (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0104855E AS DateTime), NULL, 0, NULL, 10, 9339, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (468, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01048967 AS DateTime), NULL, 0, NULL, 10, 9340, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (469, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Kết cấu bê tông cốt thép 2 (chưa đóng): 150000
TKMH Kiến trúc dân dụng (chưa đóng): 150000
TKMH Kỹ thuật thi công 2 (chưa đóng): 150000
Kết cấu Bê tông cốt thép 2 (chưa đóng): 450000
Kết cấu thép 2 (chưa đóng): 450000
Kiến trúc dân dụng (chưa đóng): 450000
Kỹ thuật thi công 2 (chưa đóng): 450000
Kỹ thuật thông gió (chưa đóng): 300000
Vật lý kiến trúc (chưa đóng): 300000
Cơ học môi trường liên tục (chưa đóng): 300000
', CAST(0x0000A26E01048E55 AS DateTime), NULL, 0, NULL, 10, 9342, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (470, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010491DF AS DateTime), NULL, 0, NULL, 10, 9343, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (471, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010496CA AS DateTime), NULL, 0, NULL, 10, 9345, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (472, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0104995C AS DateTime), NULL, 0, NULL, 10, 9346, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (473, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01049C1F AS DateTime), NULL, 0, NULL, 10, 9347, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (474, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01049FCC AS DateTime), NULL, 0, NULL, 10, 9348, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (475, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Kết cấu bê tông cốt thép 2 (chưa đóng): 150000
TKMH Kiến trúc dân dụng (chưa đóng): 150000
TKMH Kỹ thuật thi công 2 (chưa đóng): 150000
Kết cấu Bê tông cốt thép 2 (chưa đóng): 450000
Kết cấu thép 2 (chưa đóng): 450000
Kỹ thuật thi công 2 (chưa đóng): 450000
Kỹ thuật thông gió (chưa đóng): 300000
Vật lý kiến trúc (chưa đóng): 300000
Cơ học kết cấu 2 (chưa đóng): 450000
', CAST(0x0000A26E0104A51B AS DateTime), NULL, 0, NULL, 10, 9351, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (476, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0104AAB5 AS DateTime), NULL, 0, NULL, 10, 9353, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (477, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0104AE0F AS DateTime), NULL, 0, NULL, 10, 9354, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (478, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 450000
Cơ lý thuyết (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0104B310 AS DateTime), NULL, 0, NULL, 10, 9356, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (479, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0104B793 AS DateTime), NULL, 0, NULL, 10, 9358, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (480, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0104BA4C AS DateTime), NULL, 0, NULL, 10, 9359, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (481, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Điện tàu thuỷ (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0104C0E2 AS DateTime), NULL, 0, NULL, 10, 9361, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (482, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E0104C3E6 AS DateTime), NULL, 0, NULL, 10, 9362, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (483, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 1 (chưa đóng): 450000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0104C719 AS DateTime), NULL, 0, NULL, 10, 9363, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (484, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0104CA0B AS DateTime), NULL, 0, NULL, 10, 9364, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (485, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0104CD1D AS DateTime), NULL, 0, NULL, 10, 9365, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (486, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E0104D21E AS DateTime), NULL, 0, NULL, 10, 9367, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (487, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
', CAST(0x0000A26E0104D4A1 AS DateTime), NULL, 0, NULL, 10, 9368, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (488, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Cơ lý thuyết (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0104D76E AS DateTime), NULL, 0, NULL, 10, 9369, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (489, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Cơ lý thuyết (chưa đóng): 300000
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E0104DAE7 AS DateTime), NULL, 0, NULL, 10, 9370, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (490, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0104DE0A AS DateTime), NULL, 0, NULL, 10, 9371, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (491, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0104E26B AS DateTime), NULL, 0, NULL, 10, 9373, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (492, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0104E519 AS DateTime), NULL, 0, NULL, 10, 9374, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (493, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0104E839 AS DateTime), NULL, 0, NULL, 10, 9375, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (494, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0104ED23 AS DateTime), NULL, 0, NULL, 10, 9377, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (495, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0104EFE7 AS DateTime), NULL, 0, NULL, 10, 9378, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (496, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Giải tích 1 (chưa đóng): 600000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
La bàn từ (chưa đóng): 300000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0104F2BB AS DateTime), NULL, 0, NULL, 10, 9379, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (497, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0104F561 AS DateTime), NULL, 0, NULL, 10, 9381, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (498, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Phân tích hoạt động kinh tế KTB (chưa đóng): 150000
TKMH Quản lý và khai thác cảng (chưa đóng): 150000
Đại lý giao nhận (chưa đóng): 300000
Khai thác tàu (chưa đóng): 450000
Logistics và VTĐPT (chưa đóng): 300000
Quản lý và khai thác cảng (chưa đóng): 450000
Tổ chức lao động tiền lương (chưa đóng): 450000
Toán kinh tế trong vận tải (chưa đóng): 600000
Phân tích hoạt động kinh tế trong VTB (chưa đóng): 450000
Thị trường chứng khoán (chưa đóng): 300000
', CAST(0x0000A26E0104FB65 AS DateTime), NULL, 0, NULL, 10, 9383, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (499, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01050086 AS DateTime), NULL, 0, NULL, 10, 9385, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (500, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Điện tàu thuỷ (chưa đóng): 300000
An toàn lao động HH (chưa đóng): 300000
Khí tượng - Hải dương (chưa đóng): 450000
La bàn từ (chưa đóng): 300000
Luật biển (chưa đóng): 300000
Tự động điều khiển tàu (chưa đóng): 450000
Kết cấu tàu (chưa đóng): 300000
', CAST(0x0000A26E0105054D AS DateTime), NULL, 0, NULL, 10, 9387, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (501, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01050E0B AS DateTime), NULL, 0, NULL, 10, 9391, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (502, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Tiếng Anh chuyên ngành ĐKT 1 (chưa đóng): 345000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E01051160 AS DateTime), NULL, 0, NULL, 10, 9392, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (503, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010515F5 AS DateTime), NULL, 0, NULL, 10, 9393, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (504, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01051B4F AS DateTime), NULL, 0, NULL, 10, 9395, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (505, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01051E7F AS DateTime), NULL, 0, NULL, 10, 9396, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (506, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01052147 AS DateTime), NULL, 0, NULL, 10, 9397, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (507, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0105247C AS DateTime), NULL, 0, NULL, 10, 9398, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (508, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010527C3 AS DateTime), NULL, 0, NULL, 10, 9399, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (509, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01052A6C AS DateTime), NULL, 0, NULL, 10, 9400, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (510, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01052FC8 AS DateTime), NULL, 0, NULL, 10, 9402, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (511, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Thực tập sỹ quan (chưa đóng): 600000
', CAST(0x0000A26E010534C3 AS DateTime), NULL, 0, NULL, 10, 9404, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (512, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Cơ lý thuyết (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01053788 AS DateTime), NULL, 0, NULL, 10, 9405, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (513, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010539F2 AS DateTime), NULL, 0, NULL, 10, 9406, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (514, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01053D1A AS DateTime), NULL, 0, NULL, 10, 9407, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (515, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 450000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01053FF7 AS DateTime), NULL, 0, NULL, 10, 9408, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (516, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010542E3 AS DateTime), NULL, 0, NULL, 10, 9409, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (517, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010545C6 AS DateTime), NULL, 0, NULL, 10, 9410, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (518, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0105492C AS DateTime), NULL, 0, NULL, 10, 9411, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (519, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01054C60 AS DateTime), NULL, 0, NULL, 10, 9412, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (520, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010553FB AS DateTime), NULL, 0, NULL, 10, 9415, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (521, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Điện tàu thuỷ (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010556FB AS DateTime), NULL, 0, NULL, 10, 9416, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (522, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010559B2 AS DateTime), NULL, 0, NULL, 10, 9417, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (523, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01055C79 AS DateTime), NULL, 0, NULL, 10, 9418, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (524, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Điện tàu thuỷ (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01056425 AS DateTime), NULL, 0, NULL, 10, 9422, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (525, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010566DC AS DateTime), NULL, 0, NULL, 10, 9423, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (526, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01056CFE AS DateTime), NULL, 0, NULL, 10, 9425, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (527, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01056FEB AS DateTime), NULL, 0, NULL, 10, 9426, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (528, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0105757A AS DateTime), NULL, 0, NULL, 10, 9428, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (529, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Vật lý 2 (chưa đóng): 450000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Luật biển (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
', CAST(0x0000A26E01057939 AS DateTime), NULL, 0, NULL, 10, 9429, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (530, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu (chưa đóng): 230000
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Lý thuyết tàu (chưa đóng): 230000
Tiếng Anh chuyên ngành ĐKT 1 (chưa đóng): 345000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E01058230 AS DateTime), NULL, 0, NULL, 10, 9432, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (531, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01058735 AS DateTime), NULL, 0, NULL, 10, 9434, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (532, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01058A08 AS DateTime), NULL, 0, NULL, 10, 9435, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (533, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01058D2C AS DateTime), NULL, 0, NULL, 10, 9436, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (534, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01059040 AS DateTime), NULL, 0, NULL, 10, 9437, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (535, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Cơ lý thuyết (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01059392 AS DateTime), NULL, 0, NULL, 10, 9438, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (536, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010596B4 AS DateTime), NULL, 0, NULL, 10, 9439, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (537, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01059A41 AS DateTime), NULL, 0, NULL, 10, 9440, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (538, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01059F55 AS DateTime), NULL, 0, NULL, 10, 9442, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (539, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0105A213 AS DateTime), NULL, 0, NULL, 10, 9443, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (540, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0105A545 AS DateTime), NULL, 0, NULL, 10, 9444, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (541, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0105A9B0 AS DateTime), NULL, 0, NULL, 10, 9446, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (542, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E0105B2F9 AS DateTime), NULL, 0, NULL, 10, 9448, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (543, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E0105B6EA AS DateTime), NULL, 0, NULL, 10, 9449, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (544, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0105BCC2 AS DateTime), NULL, 0, NULL, 10, 9450, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (545, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 450000
Cơ lý thuyết (chưa đóng): 300000
Sức bền vật liệu (chưa đóng): 230000
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Lý thuyết tàu (chưa đóng): 230000
Toán chuyên đề (Khoa ĐKTB) (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E0105CA6B AS DateTime), NULL, 0, NULL, 10, 9454, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (546, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Cơ lý thuyết (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0105CD52 AS DateTime), NULL, 0, NULL, 10, 9455, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (547, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0105CFFC AS DateTime), NULL, 0, NULL, 10, 9456, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (548, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0105D343 AS DateTime), NULL, 0, NULL, 10, 9457, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (549, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0105D61F AS DateTime), NULL, 0, NULL, 10, 9458, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (550, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0105D900 AS DateTime), NULL, 0, NULL, 10, 9459, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (551, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0105DF1C AS DateTime), NULL, 0, NULL, 10, 9461, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (552, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0105E1F9 AS DateTime), NULL, 0, NULL, 10, 9462, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (553, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0105E503 AS DateTime), NULL, 0, NULL, 10, 9463, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (554, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0105F34D AS DateTime), NULL, 0, NULL, 10, 9469, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (555, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E01060157 AS DateTime), NULL, 0, NULL, 10, 9475, 0, 1)
GO
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (556, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Cơ lý thuyết (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01060705 AS DateTime), NULL, 0, NULL, 10, 9477, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (557, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Giải tích 1 (chưa đóng): 600000
Sức bền vật liệu (chưa đóng): 230000
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E01060EEE AS DateTime), NULL, 0, NULL, 10, 9480, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (558, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0106164C AS DateTime), NULL, 0, NULL, 10, 9483, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (559, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01061976 AS DateTime), NULL, 0, NULL, 10, 9484, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (560, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu (chưa đóng): 230000
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E01061CC8 AS DateTime), NULL, 0, NULL, 10, 9485, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (561, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01062683 AS DateTime), NULL, 0, NULL, 10, 9488, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (562, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01062BE1 AS DateTime), NULL, 0, NULL, 10, 9491, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (563, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01063022 AS DateTime), NULL, 0, NULL, 10, 9492, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (564, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01063333 AS DateTime), NULL, 0, NULL, 10, 9493, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (565, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Tự động điều khiển tàu (chưa đóng): 450000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0106388F AS DateTime), NULL, 0, NULL, 10, 9495, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (566, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E01063C4D AS DateTime), NULL, 0, NULL, 10, 9496, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (567, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01063F4E AS DateTime), NULL, 0, NULL, 10, 9497, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (568, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Cơ lý thuyết (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010644C0 AS DateTime), NULL, 0, NULL, 10, 9499, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (569, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010647E6 AS DateTime), NULL, 0, NULL, 10, 9500, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (570, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01064B53 AS DateTime), NULL, 0, NULL, 10, 9501, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (571, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01065020 AS DateTime), NULL, 0, NULL, 10, 9503, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (572, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010652F1 AS DateTime), NULL, 0, NULL, 10, 9504, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (573, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0106562C AS DateTime), NULL, 0, NULL, 10, 9505, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (574, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E0106598A AS DateTime), NULL, 0, NULL, 10, 9506, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (575, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Luật biển (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01065C81 AS DateTime), NULL, 0, NULL, 10, 9507, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (576, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 450000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01066229 AS DateTime), NULL, 0, NULL, 10, 9509, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (577, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tư tưởng Hồ Chí Minh (chưa đóng): 300000
Sức bền vật liệu (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Thực tập sỹ quan (chưa đóng): 600000
Toán chuyên đề (Khoa ĐKTB) (chưa đóng): 300000
', CAST(0x0000A26E01066764 AS DateTime), NULL, 0, NULL, 10, 9511, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (578, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01066BE0 AS DateTime), NULL, 0, NULL, 10, 9513, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (579, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Cơ lý thuyết (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01066EEF AS DateTime), NULL, 0, NULL, 10, 9514, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (580, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01067353 AS DateTime), NULL, 0, NULL, 10, 9515, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (581, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Pháp luật hàng hải 2 (chưa đóng): 300000
', CAST(0x0000A26E01067A8A AS DateTime), NULL, 0, NULL, 10, 9518, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (582, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01067D7A AS DateTime), NULL, 0, NULL, 10, 9519, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (583, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01068078 AS DateTime), NULL, 0, NULL, 10, 9520, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (584, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Phân tích hoạt động kinh tế KTB (chưa đóng): 150000
TKMH Quản lý và khai thác cảng (chưa đóng): 150000
Đại lý giao nhận (chưa đóng): 300000
Khai thác tàu (chưa đóng): 450000
Logistics và VTĐPT (chưa đóng): 300000
Quản lý và khai thác cảng (chưa đóng): 450000
Tổ chức lao động tiền lương (chưa đóng): 450000
Toán kinh tế trong vận tải (chưa đóng): 600000
Phân tích hoạt động kinh tế trong VTB (chưa đóng): 450000
Pháp luật kinh tế (chưa đóng): 450000
', CAST(0x0000A26E01068479 AS DateTime), NULL, 0, NULL, 10, 9521, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (585, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E01068863 AS DateTime), NULL, 0, NULL, 10, 9522, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (586, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Giải tích 1 (chưa đóng): 600000
Hóa đại cương (chưa đóng): 450000
TKMH máy nâng tự hành (chưa đóng): 150000
TKMH Máy vận chuyển liên tục (chưa đóng): 150000
Công nghệ chế tạo máy nâng chuyển (chưa đóng): 450000
Máy nâng tự hành (chưa đóng): 600000
Máy vận chuyển liên tục (chưa đóng): 450000
Ôtô máy kéo (chưa đóng): 300000
Quy phạm thiết kế máy và TB nâng (chưa đóng): 150000
', CAST(0x0000A26E01068B77 AS DateTime), NULL, 0, NULL, 10, 9523, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (587, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01068E4F AS DateTime), NULL, 0, NULL, 10, 9524, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (588, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010693B5 AS DateTime), NULL, 0, NULL, 10, 9526, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (589, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
', CAST(0x0000A26E01069662 AS DateTime), NULL, 0, NULL, 10, 9527, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (590, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0106997E AS DateTime), NULL, 0, NULL, 10, 9528, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (591, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Tự động điều khiển tàu (chưa đóng): 450000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01069F00 AS DateTime), NULL, 0, NULL, 10, 9530, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (592, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0106A26A AS DateTime), NULL, 0, NULL, 10, 9531, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (593, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0106A5D4 AS DateTime), NULL, 0, NULL, 10, 9532, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (594, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0106A931 AS DateTime), NULL, 0, NULL, 10, 9533, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (595, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Luật biển (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0106AC74 AS DateTime), NULL, 0, NULL, 10, 9534, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (596, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0106B1D6 AS DateTime), NULL, 0, NULL, 10, 9535, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (597, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
La bàn từ (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Tự động điều khiển tàu (chưa đóng): 450000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0106B4F6 AS DateTime), NULL, 0, NULL, 10, 9536, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (598, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0106B89C AS DateTime), NULL, 0, NULL, 10, 9537, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (599, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0106BB67 AS DateTime), NULL, 0, NULL, 10, 9538, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (600, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0106BE91 AS DateTime), NULL, 0, NULL, 10, 9539, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (601, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0106C2E6 AS DateTime), NULL, 0, NULL, 10, 9541, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (602, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0106C5CB AS DateTime), NULL, 0, NULL, 10, 9543, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (603, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0106C891 AS DateTime), NULL, 0, NULL, 10, 9544, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (604, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0106CB42 AS DateTime), NULL, 0, NULL, 10, 9545, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (605, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đường lối CM của ĐCS Việt Nam (chưa đóng): 450000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0106CF1E AS DateTime), NULL, 0, NULL, 10, 9546, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (606, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0106D46B AS DateTime), NULL, 0, NULL, 10, 9548, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (607, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0106D752 AS DateTime), NULL, 0, NULL, 10, 9549, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (608, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0106DA31 AS DateTime), NULL, 0, NULL, 10, 9550, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (609, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0106DD52 AS DateTime), NULL, 0, NULL, 10, 9551, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (610, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0106E011 AS DateTime), NULL, 0, NULL, 10, 9552, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (611, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0106E302 AS DateTime), NULL, 0, NULL, 10, 9553, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (612, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0106E5DD AS DateTime), NULL, 0, NULL, 10, 9554, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (613, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0106E952 AS DateTime), NULL, 0, NULL, 10, 9556, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (614, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0106EE56 AS DateTime), NULL, 0, NULL, 10, 9558, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (615, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0106F13A AS DateTime), NULL, 0, NULL, 10, 9559, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (616, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0106F46F AS DateTime), NULL, 0, NULL, 10, 9560, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (617, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0106F711 AS DateTime), NULL, 0, NULL, 10, 9561, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (618, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0106FAE1 AS DateTime), NULL, 0, NULL, 10, 9562, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (619, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0106FDA5 AS DateTime), NULL, 0, NULL, 10, 9563, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (620, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01070067 AS DateTime), NULL, 0, NULL, 10, 9564, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (621, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0107037E AS DateTime), NULL, 0, NULL, 10, 9565, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (622, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010707D2 AS DateTime), NULL, 0, NULL, 10, 9566, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (623, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01070B3E AS DateTime), NULL, 0, NULL, 10, 9567, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (624, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01070DF7 AS DateTime), NULL, 0, NULL, 10, 9568, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (625, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 450000
Sức bền vật liệu (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010710A4 AS DateTime), NULL, 0, NULL, 10, 9569, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (626, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0107135A AS DateTime), NULL, 0, NULL, 10, 9571, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (627, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01071667 AS DateTime), NULL, 0, NULL, 10, 9572, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (628, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010719BD AS DateTime), NULL, 0, NULL, 10, 9573, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (629, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01071C6B AS DateTime), NULL, 0, NULL, 10, 9574, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (630, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01072234 AS DateTime), NULL, 0, NULL, 10, 9576, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (631, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010725B5 AS DateTime), NULL, 0, NULL, 10, 9577, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (632, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Giải tích 1 (chưa đóng): 600000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01072E04 AS DateTime), NULL, 0, NULL, 10, 9580, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (633, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010730FA AS DateTime), NULL, 0, NULL, 10, 9581, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (634, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010734B4 AS DateTime), NULL, 0, NULL, 10, 9582, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (635, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010737CC AS DateTime), NULL, 0, NULL, 10, 9583, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (636, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01073A8F AS DateTime), NULL, 0, NULL, 10, 9584, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (637, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu (chưa đóng): 230000
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Khí tượng - Hải dương (chưa đóng): 450000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Thuỷ nghiệp - Thông hiệu HH 1 (chưa đóng): 300000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E01073EE2 AS DateTime), NULL, 0, NULL, 10, 9585, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (638, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01074278 AS DateTime), NULL, 0, NULL, 10, 9586, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (639, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01074581 AS DateTime), NULL, 0, NULL, 10, 9587, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (640, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01074845 AS DateTime), NULL, 0, NULL, 10, 9588, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (641, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01074B66 AS DateTime), NULL, 0, NULL, 10, 9589, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (642, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0107504A AS DateTime), NULL, 0, NULL, 10, 9591, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (643, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010753D3 AS DateTime), NULL, 0, NULL, 10, 9592, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (644, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010756DD AS DateTime), NULL, 0, NULL, 10, 9593, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (645, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Tiếng Anh chuyên ngành ĐKT 1 (chưa đóng): 345000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E01075993 AS DateTime), NULL, 0, NULL, 10, 9594, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (646, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu (chưa đóng): 240000
Địa văn hàng hải 1 (chưa đóng): 360000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 360000
Quy tắc phòng ngừa đâm va (chưa đóng): 240000
Ổn định tàu (chưa đóng): 240000
Anh văn chuyên ngành HH1 (chưa đóng): 480000
', CAST(0x0000A26E01075C67 AS DateTime), NULL, 0, NULL, 10, 9595, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (647, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E01075F15 AS DateTime), NULL, 0, NULL, 10, 9596, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (648, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01076219 AS DateTime), NULL, 0, NULL, 10, 9597, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (649, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010767D6 AS DateTime), NULL, 0, NULL, 10, 9599, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (650, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 2 (chưa đóng): 345000
Giải tích 1 (chưa đóng): 460000
Thực tập cơ khí (Khoa công trình) (chưa đóng): 240000
Cơ lý thuyết (chưa đóng): 230000
Sức bền vật liệu (chưa đóng): 230000
Thể thao chuyên ngành hàng hải (ĐKTB,MTB) (chưa đóng): 115000
Nguyên lý CB của CNMLN 2 (chưa đóng): 345000
Đại cương hàng hải (chưa đóng): 240000
Kỹ thuật điện (chưa đóng): 345000
Nguyên lý máy (MKT) (chưa đóng): 230000
Thiết bị và kỹ thuật đo (chưa đóng): 240000
Giáo dục quốc phòng HP3+4 (chưa đóng): 460000
Đường lối QS của Đảng (chưa đóng): 360000
Công tác quốc phòng-an ninh (chưa đóng): 240000
Trang trí hệ động lực tàu thủy 1 (chưa đóng): 360000
Nhiệt kỹ thuật (chưa đóng): 360000
Lý thuyết điều khiển tự động (chưa đóng): 240000
Kỹ thuật gia công cơ khí (chưa đóng): 360000
', CAST(0x0000A26E01076ACD AS DateTime), NULL, 0, NULL, 10, 9600, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (651, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01076DA4 AS DateTime), NULL, 0, NULL, 10, 9601, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (652, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01077080 AS DateTime), NULL, 0, NULL, 10, 9602, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (653, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0107761B AS DateTime), NULL, 0, NULL, 10, 9604, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (654, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01077934 AS DateTime), NULL, 0, NULL, 10, 9605, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (655, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01077C09 AS DateTime), NULL, 0, NULL, 10, 9606, 0, 1)
GO
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (656, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01077F04 AS DateTime), NULL, 0, NULL, 10, 9607, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (657, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kinh tế phát triển (chưa đóng): 300000
Kinh tế vĩ mô 2 (chưa đóng): 300000
Tài chính tiền tệ (chưa đóng): 450000
Nguyên lý kế toán (chưa đóng): 600000
Nguyên lý thống kê và TKDN (chưa đóng): 450000
Quản lý NN về KT (chưa đóng): 300000
Thuế vụ (chưa đóng): 300000
Tiếng anh chuyên ngành KTB2 (chưa đóng): 300000
', CAST(0x0000A26E01078206 AS DateTime), NULL, 0, NULL, 10, 9608, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (658, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01078508 AS DateTime), NULL, 0, NULL, 10, 9609, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (659, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0107883B AS DateTime), NULL, 0, NULL, 10, 9610, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (660, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01078BB7 AS DateTime), NULL, 0, NULL, 10, 9611, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (661, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Cơ lý thuyết (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01079226 AS DateTime), NULL, 0, NULL, 10, 9613, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (662, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01079559 AS DateTime), NULL, 0, NULL, 10, 9614, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (663, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0107990A AS DateTime), NULL, 0, NULL, 10, 9615, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (664, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Thực tập sỹ quan (chưa đóng): 600000
', CAST(0x0000A26E01079CD1 AS DateTime), NULL, 0, NULL, 10, 9617, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (665, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Đại số (chưa đóng): 450000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0107A032 AS DateTime), NULL, 0, NULL, 10, 9618, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (666, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0107A2D9 AS DateTime), NULL, 0, NULL, 10, 9619, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (667, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Điện tàu thuỷ (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0107A5B9 AS DateTime), NULL, 0, NULL, 10, 9620, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (668, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0107A8AB AS DateTime), NULL, 0, NULL, 10, 9621, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (669, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 450000
Giải tích 1 (chưa đóng): 600000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Thực tập sỹ quan (chưa đóng): 600000
Toán chuyên đề (Khoa ĐKTB) (chưa đóng): 300000
', CAST(0x0000A26E0107B24D AS DateTime), NULL, 0, NULL, 10, 9624, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (670, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 450000
Điện tàu thuỷ (chưa đóng): 300000
Sức bền vật liệu (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0107B616 AS DateTime), NULL, 0, NULL, 10, 9625, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (671, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0107B975 AS DateTime), NULL, 0, NULL, 10, 9626, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (672, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 450000
Giải tích 2 (chưa đóng): 600000
Vật lý 2 (chưa đóng): 450000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0107BCE8 AS DateTime), NULL, 0, NULL, 10, 9627, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (673, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0107C288 AS DateTime), NULL, 0, NULL, 10, 9629, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (674, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0107C565 AS DateTime), NULL, 0, NULL, 10, 9630, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (675, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0107C85B AS DateTime), NULL, 0, NULL, 10, 9631, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (676, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0107CB42 AS DateTime), NULL, 0, NULL, 10, 9632, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (677, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0107CE8B AS DateTime), NULL, 0, NULL, 10, 9633, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (678, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0107D1ED AS DateTime), NULL, 0, NULL, 10, 9634, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (679, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Khí tượng - Hải dương (chưa đóng): 450000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0107D564 AS DateTime), NULL, 0, NULL, 10, 9635, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (680, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0107D89B AS DateTime), NULL, 0, NULL, 10, 9636, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (681, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Điện tàu thuỷ (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0107DDE1 AS DateTime), NULL, 0, NULL, 10, 9637, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (682, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0107E35C AS DateTime), NULL, 0, NULL, 10, 9639, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (683, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0107E8C9 AS DateTime), NULL, 0, NULL, 10, 9641, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (684, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 450000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0107EE1D AS DateTime), NULL, 0, NULL, 10, 9643, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (685, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Cơ lý thuyết (chưa đóng): 300000
Hóa đại cương (chưa đóng): 450000
Tin học đại cương (chưa đóng): 450000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Thực tập sỹ quan (chưa đóng): 600000
', CAST(0x0000A26E0107F274 AS DateTime), NULL, 0, NULL, 10, 9644, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (686, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0107F5B4 AS DateTime), NULL, 0, NULL, 10, 9645, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (687, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0107F97C AS DateTime), NULL, 0, NULL, 10, 9646, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (688, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0107FDC5 AS DateTime), NULL, 0, NULL, 10, 9647, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (689, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Tự động điều khiển tàu (chưa đóng): 450000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01080113 AS DateTime), NULL, 0, NULL, 10, 9648, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (690, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010803C7 AS DateTime), NULL, 0, NULL, 10, 9649, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (691, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010806A8 AS DateTime), NULL, 0, NULL, 10, 9650, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (692, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01080975 AS DateTime), NULL, 0, NULL, 10, 9651, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (693, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đường lối CM của ĐCS Việt Nam (chưa đóng): 450000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Thuỷ nghiệp - Thông hiệu HH 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01080C2F AS DateTime), NULL, 0, NULL, 10, 9652, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (694, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01080F26 AS DateTime), NULL, 0, NULL, 10, 9653, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (695, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Máy tàu thủy (chưa đóng): 230000
Cơ lý thuyết (chưa đóng): 300000
Sức bền vật liệu (chưa đóng): 230000
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Toán chuyên đề (Khoa ĐKTB) (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E010812D0 AS DateTime), NULL, 0, NULL, 10, 9654, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (696, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Vật lý 2 (chưa đóng): 450000
Sức bền vật liệu (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01081604 AS DateTime), NULL, 0, NULL, 10, 9655, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (697, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01081908 AS DateTime), NULL, 0, NULL, 10, 9656, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (698, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01081C37 AS DateTime), NULL, 0, NULL, 10, 9657, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (699, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 1 (chưa đóng): 450000
Giải tích 1 (chưa đóng): 600000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01081F6F AS DateTime), NULL, 0, NULL, 10, 9658, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (700, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đường lối CM của ĐCS Việt Nam (chưa đóng): 450000
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Giải tích 1 (chưa đóng): 600000
Cơ lý thuyết (chưa đóng): 300000
Hóa đại cương (chưa đóng): 450000
Tin học đại cương (chưa đóng): 450000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
', CAST(0x0000A26E0108235E AS DateTime), NULL, 0, NULL, 10, 9659, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (701, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01082737 AS DateTime), NULL, 0, NULL, 10, 9660, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (702, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01082A29 AS DateTime), NULL, 0, NULL, 10, 9661, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (703, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tư tưởng Hồ Chí Minh (chưa đóng): 300000
Vật lý 2 (chưa đóng): 450000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01082D1F AS DateTime), NULL, 0, NULL, 10, 9662, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (704, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Giải tích 1 (chưa đóng): 600000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0108302D AS DateTime), NULL, 0, NULL, 10, 9663, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (705, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Cơ lý thuyết (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01083381 AS DateTime), NULL, 0, NULL, 10, 9664, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (706, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01083D53 AS DateTime), NULL, 0, NULL, 10, 9668, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (707, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0108406E AS DateTime), NULL, 0, NULL, 10, 9669, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (708, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01084397 AS DateTime), NULL, 0, NULL, 10, 9670, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (709, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010846CF AS DateTime), NULL, 0, NULL, 10, 9671, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (710, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0108495B AS DateTime), NULL, 0, NULL, 10, 9674, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (711, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01084C69 AS DateTime), NULL, 0, NULL, 10, 9675, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (712, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đường lối CM của ĐCS Việt Nam (chưa đóng): 450000
Cơ lý thuyết (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0108509C AS DateTime), NULL, 0, NULL, 10, 9676, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (713, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đường lối CM của ĐCS Việt Nam (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010853F9 AS DateTime), NULL, 0, NULL, 10, 9677, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (714, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Khí tượng - Hải dương (chưa đóng): 450000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010856E5 AS DateTime), NULL, 0, NULL, 10, 9678, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (715, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01085A2C AS DateTime), NULL, 0, NULL, 10, 9679, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (716, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01085F16 AS DateTime), NULL, 0, NULL, 10, 9681, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (717, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010861DD AS DateTime), NULL, 0, NULL, 10, 9682, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (718, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01086534 AS DateTime), NULL, 0, NULL, 10, 9683, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (719, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01086813 AS DateTime), NULL, 0, NULL, 10, 9684, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (720, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E01086AA8 AS DateTime), NULL, 0, NULL, 10, 9685, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (721, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Máy tàu thủy (chưa đóng): 230000
Sức bền vật liệu (chưa đóng): 230000
Địa văn hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E01086DBA AS DateTime), NULL, 0, NULL, 10, 9686, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (722, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010870AF AS DateTime), NULL, 0, NULL, 10, 9687, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (723, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Hóa đại cương (chưa đóng): 450000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01087387 AS DateTime), NULL, 0, NULL, 10, 9688, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (724, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01087654 AS DateTime), NULL, 0, NULL, 10, 9689, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (725, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01087906 AS DateTime), NULL, 0, NULL, 10, 9690, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (726, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01087CE8 AS DateTime), NULL, 0, NULL, 10, 9691, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (727, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01087F91 AS DateTime), NULL, 0, NULL, 10, 9692, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (728, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01088310 AS DateTime), NULL, 0, NULL, 10, 9693, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (729, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01088644 AS DateTime), NULL, 0, NULL, 10, 9694, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (730, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010888DC AS DateTime), NULL, 0, NULL, 10, 9695, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (731, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01088BA4 AS DateTime), NULL, 0, NULL, 10, 9696, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (732, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01088E70 AS DateTime), NULL, 0, NULL, 10, 9697, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (733, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0108916B AS DateTime), NULL, 0, NULL, 10, 9698, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (734, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Điện tàu thuỷ (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0108943A AS DateTime), NULL, 0, NULL, 10, 9700, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (735, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E010896DE AS DateTime), NULL, 0, NULL, 10, 9701, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (736, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01089996 AS DateTime), NULL, 0, NULL, 10, 9702, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (737, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đường lối CM của ĐCS Việt Nam (chưa đóng): 450000
Sức bền vật liệu (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01089C62 AS DateTime), NULL, 0, NULL, 10, 9703, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (738, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0108A1EB AS DateTime), NULL, 0, NULL, 10, 9705, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (739, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0108A5BC AS DateTime), NULL, 0, NULL, 10, 9708, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (740, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tư tưởng Hồ Chí Minh (chưa đóng): 300000
Tổ chức và quản lý thi công (chưa đóng): 450000
Hình họa (chưa đóng): 300000
TKMH Chỉnh trị sông (chưa đóng): 150000
TKMH Công trình bến (chưa đóng): 150000
TKMH Công trình thuỷ công trong NMĐT (chưa đóng): 150000
Âu tàu (chưa đóng): 450000
Chỉnh trị sông (chưa đóng): 450000
Công trình bến (chưa đóng): 450000
Công trình thuỷ công trong NMĐT (chưa đóng): 450000
Kinh tế xây dựng (chưa đóng): 300000
', CAST(0x0000A26E0108A8D4 AS DateTime), NULL, 0, NULL, 10, 9709, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (741, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Cơ lý thuyết (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0108ABAC AS DateTime), NULL, 0, NULL, 10, 9710, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (742, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E0108AEBE AS DateTime), NULL, 0, NULL, 10, 9711, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (743, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
Chi tiết – Dung sai (chưa đóng): 300000
', CAST(0x0000A26E0108B1B3 AS DateTime), NULL, 0, NULL, 10, 9712, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (744, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu (chưa đóng): 300000
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
Thiết bị và kỹ thuật đo (chưa đóng): 300000
', CAST(0x0000A26E0108B49E AS DateTime), NULL, 0, NULL, 10, 9713, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (745, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
Thiết bị và kỹ thuật đo (chưa đóng): 300000
', CAST(0x0000A26E0108B76D AS DateTime), NULL, 0, NULL, 10, 9714, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (746, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0108BA1D AS DateTime), NULL, 0, NULL, 10, 9715, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (747, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0108BC96 AS DateTime), NULL, 0, NULL, 10, 9716, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (748, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
Thiết bị và kỹ thuật đo (chưa đóng): 300000
', CAST(0x0000A26E0108BF41 AS DateTime), NULL, 0, NULL, 10, 9717, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (749, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0108C218 AS DateTime), NULL, 0, NULL, 10, 9718, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (750, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0108C665 AS DateTime), NULL, 0, NULL, 10, 9721, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (751, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0108CB70 AS DateTime), NULL, 0, NULL, 10, 9723, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (752, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0108D177 AS DateTime), NULL, 0, NULL, 10, 9725, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (753, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Cơ lý thuyết (chưa đóng): 300000
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0108D4BA AS DateTime), NULL, 0, NULL, 10, 9726, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (754, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 1 (chưa đóng): 360000
Khí tượng - Hải dương (chưa đóng): 360000
La bàn từ (chưa đóng): 240000
Luật biển (chưa đóng): 240000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 360000
Đường lối QS của Đảng (chưa đóng): 360000
Ổn định tàu (chưa đóng): 240000
Anh văn chuyên ngành HH1 (chưa đóng): 480000
', CAST(0x0000A26E0108D880 AS DateTime), NULL, 0, NULL, 10, 9727, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (755, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0108DB73 AS DateTime), NULL, 0, NULL, 10, 9728, 0, 1)
GO
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (756, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu (chưa đóng): 300000
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0108DE32 AS DateTime), NULL, 0, NULL, 10, 9729, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (757, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0108E157 AS DateTime), NULL, 0, NULL, 10, 9730, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (758, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Giải tích 1 (chưa đóng): 600000
Cơ lý thuyết (chưa đóng): 300000
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
Nguyên lý máy (MKT) (chưa đóng): 300000
', CAST(0x0000A26E0108E72D AS DateTime), NULL, 0, NULL, 10, 9732, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (759, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
Kỹ thuật bóng rổ (chưa đóng): 150000
', CAST(0x0000A26E0108E9E3 AS DateTime), NULL, 0, NULL, 10, 9733, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (760, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0108ECA9 AS DateTime), NULL, 0, NULL, 10, 9734, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (761, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0108F270 AS DateTime), NULL, 0, NULL, 10, 9736, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (762, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tư tưởng Hồ Chí Minh (chưa đóng): 300000
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
Tin học chuyên ngành (chưa đóng): 300000
', CAST(0x0000A26E0108F529 AS DateTime), NULL, 0, NULL, 10, 9737, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (763, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 1 (chưa đóng): 460000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong1 (chưa đóng): 460000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 1 (tiếng Việt) (chưa đóng): 460000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Thiết bị trao đổi nhiệt (chưa đóng): 230000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
Hóa kỹ thuật (chưa đóng): 230000
Kết cấu và lý thuyết tàu (chưa đóng): 230000
Kỹ thuật gia công cơ khí 2 (chưa đóng): 230000
Thực tập thợ máy 1 (chưa đóng): 805000
Kỹ thuật bóng rổ (chưa đóng): 150000
', CAST(0x0000A26E0108F84F AS DateTime), NULL, 0, NULL, 10, 9738, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (764, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tổ chức và quản lý thi công (chưa đóng): 450000
Hình họa (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
TKMH Chỉnh trị sông (chưa đóng): 150000
TKMH Công trình bến (chưa đóng): 150000
TKMH Công trình thuỷ công trong NMĐT (chưa đóng): 150000
Âu tàu (chưa đóng): 450000
Chỉnh trị sông (chưa đóng): 450000
Công trình bến (chưa đóng): 450000
Công trình thuỷ công trong NMĐT (chưa đóng): 450000
Kinh tế xây dựng (chưa đóng): 300000
', CAST(0x0000A26E0108FDFF AS DateTime), NULL, 0, NULL, 10, 9740, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (765, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Giải tích 1 (chưa đóng): 600000
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
Nguyên lý máy (MKT) (chưa đóng): 300000
', CAST(0x0000A26E010900FD AS DateTime), NULL, 0, NULL, 10, 9741, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (766, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu (chưa đóng): 300000
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Máy lạnh và điều hòa không khí (chưa đóng): 600000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
Lý thuyết điều khiển tự động (chưa đóng): 450000
', CAST(0x0000A26E010903EF AS DateTime), NULL, 0, NULL, 10, 9742, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (767, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Vật lý 2 (chưa đóng): 450000
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E01090838 AS DateTime), NULL, 0, NULL, 10, 9743, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (768, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E01090D55 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (769, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E010914C7 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (770, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0109194F AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (771, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E01091D41 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (772, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0109216A AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (773, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E010925D7 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (774, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E010929F6 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (775, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E01092DF4 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (776, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E01093247 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (777, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0109367D AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (778, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E01093B11 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (779, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E01093FD1 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (780, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E01094391 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (781, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E01094801 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (782, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E01094BB2 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (783, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0109500B AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (784, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0109544A AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (785, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E01095869 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (786, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E01095CC1 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (787, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E01096135 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (788, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0109654D AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (789, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E010969B6 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (790, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E01096DB8 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (791, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0109737B AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (792, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0109760B AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (793, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E01097A48 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (794, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E01097E97 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (795, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E010982DA AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (796, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0109870A AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (797, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E01098B62 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (798, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E01098FB3 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (799, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E010993CF AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (800, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E01099800 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (801, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E01099C2A AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (802, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0109A098 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (803, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0109A54D AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (804, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0109A8B8 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (805, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0109AE49 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (806, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0109B168 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (807, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0109B565 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (808, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0109B9BC AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (809, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0109BDCE AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (810, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0109C258 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (811, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0109C64F AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (812, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0109CACA AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (813, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0109CEAD AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (814, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0109D32D AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (815, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0109D80E AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (816, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0109DB9B AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (817, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0109DFDA AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (818, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0109E3F0 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (819, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0109E840 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (820, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0109EC7A AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (821, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0109F0D7 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (822, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0109F50B AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (823, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0109F9D6 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (824, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0109FD7D AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (825, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E010A01FB AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (826, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E010A05E4 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (827, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E010A0A30 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (828, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E010A0E51 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (829, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E010A12B9 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (830, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E010A16DB AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (831, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E010A1B19 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (832, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E010A1F3C AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (833, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E010A2395 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (834, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E010A281D AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (835, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E010A2BED AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (836, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E010A3043 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (837, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E010A346E AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (838, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E010A388A AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (839, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E010A3CD2 AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (840, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E010A414B AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (841, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E010A454C AS DateTime), NULL, 0, NULL, 10, 9744, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (842, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0114F849 AS DateTime), NULL, 0, NULL, 10, 889, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (843, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E0114FD4F AS DateTime), NULL, 0, NULL, 10, 891, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (844, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01150255 AS DateTime), NULL, 0, NULL, 10, 894, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (845, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01150538 AS DateTime), NULL, 0, NULL, 10, 895, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (846, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 450000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
', CAST(0x0000A26E0115077A AS DateTime), NULL, 0, NULL, 10, 896, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (847, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01150A0B AS DateTime), NULL, 0, NULL, 10, 897, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (848, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01150CA6 AS DateTime), NULL, 0, NULL, 10, 898, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (849, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E01150F92 AS DateTime), NULL, 0, NULL, 10, 899, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (850, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E011513C3 AS DateTime), NULL, 0, NULL, 10, 901, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (851, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0115179D AS DateTime), NULL, 0, NULL, 10, 903, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (852, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đường lối CM của ĐCS Việt Nam (chưa đóng): 345000
Đường lối CM của ĐCS Việt Nam (chưa đóng): 345000
Tư tưởng Hồ Chí Minh (chưa đóng): 230000
Tiếng Anh cơ bản 3 (chưa đóng): 345000
Đại số (chưa đóng): 345000
Vật lý 2 (chưa đóng): 345000
Cơ lý thuyết (chưa đóng): 460000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật nhiệt (chưa đóng): 450000
Toán chuyên đề (Khoa Đóng tàu) (chưa đóng): 230000
Vẽ kỹ thuật cơ khí (chưa đóng): 230000
', CAST(0x0000A26E01151B32 AS DateTime), NULL, 0, NULL, 10, 904, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (853, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01151ED4 AS DateTime), NULL, 0, NULL, 10, 905, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (854, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Giải tích 1 (chưa đóng): 600000
Vật lý 2 (chưa đóng): 450000
Hình họa (chưa đóng): 300000
Hóa đại cương (chưa đóng): 450000
Sức bền vật liệu 1 (chưa đóng): 300000
Vẽ kỹ thuật cơ khí (chưa đóng): 300000
', CAST(0x0000A26E01152168 AS DateTime), NULL, 0, NULL, 10, 906, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (855, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E011524D2 AS DateTime), NULL, 0, NULL, 10, 907, 0, 1)
GO
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (856, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01152941 AS DateTime), NULL, 0, NULL, 10, 909, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (857, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01152E5F AS DateTime), NULL, 0, NULL, 10, 911, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (858, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01153156 AS DateTime), NULL, 0, NULL, 10, 912, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (859, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01153754 AS DateTime), NULL, 0, NULL, 10, 914, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (860, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01153A53 AS DateTime), NULL, 0, NULL, 10, 915, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (861, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E011541D5 AS DateTime), NULL, 0, NULL, 10, 917, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (862, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E01154512 AS DateTime), NULL, 0, NULL, 10, 918, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (863, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E0115483C AS DateTime), NULL, 0, NULL, 10, 920, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (864, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01154B0D AS DateTime), NULL, 0, NULL, 10, 921, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (865, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01155103 AS DateTime), NULL, 0, NULL, 10, 924, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (866, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E011553B6 AS DateTime), NULL, 0, NULL, 10, 925, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (867, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E011557AF AS DateTime), NULL, 0, NULL, 10, 926, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (868, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01155DFE AS DateTime), NULL, 0, NULL, 10, 927, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (869, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Vẽ tàu (chưa đóng): 150000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0115615F AS DateTime), NULL, 0, NULL, 10, 928, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (870, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01156580 AS DateTime), NULL, 0, NULL, 10, 929, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (871, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0115690C AS DateTime), NULL, 0, NULL, 10, 930, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (872, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01156C25 AS DateTime), NULL, 0, NULL, 10, 931, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (873, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01156FF4 AS DateTime), NULL, 0, NULL, 10, 932, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (874, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E011574B7 AS DateTime), NULL, 0, NULL, 10, 933, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (875, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01157873 AS DateTime), NULL, 0, NULL, 10, 934, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (876, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01157BA2 AS DateTime), NULL, 0, NULL, 10, 935, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (877, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01157ECE AS DateTime), NULL, 0, NULL, 10, 936, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (878, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Giải tích 1 (chưa đóng): 600000
Vật lý 2 (chưa đóng): 450000
Hình họa (chưa đóng): 300000
Hóa đại cương (chưa đóng): 450000
Sức bền vật liệu 1 (chưa đóng): 300000
', CAST(0x0000A26E011582FB AS DateTime), NULL, 0, NULL, 10, 938, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (879, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01158730 AS DateTime), NULL, 0, NULL, 10, 939, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (880, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E011589F8 AS DateTime), NULL, 0, NULL, 10, 940, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (881, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01158D20 AS DateTime), NULL, 0, NULL, 10, 941, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (882, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E011592E9 AS DateTime), NULL, 0, NULL, 10, 943, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (883, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 1 (chưa đóng): 300000
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E011597CB AS DateTime), NULL, 0, NULL, 10, 944, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (884, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01159BE0 AS DateTime), NULL, 0, NULL, 10, 945, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (885, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01159EA0 AS DateTime), NULL, 0, NULL, 10, 947, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (886, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 1 (chưa đóng): 230000
Kỹ thuật điện (chưa đóng): 230000
Nguyên lý máy (Đóng tàu) (chưa đóng): 460000
Vật liệu kỹ thuật (Đóng tàu) (chưa đóng): 345000
Thực tập cơ khí (Khoa Máy khai thác) (chưa đóng): 460000
', CAST(0x0000A26E0115A231 AS DateTime), NULL, 0, NULL, 10, 948, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (887, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0115A81B AS DateTime), NULL, 0, NULL, 10, 949, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (888, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0115B221 AS DateTime), NULL, 0, NULL, 10, 951, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (889, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 1 (chưa đóng): 300000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0115B8B3 AS DateTime), NULL, 0, NULL, 10, 953, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (890, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bơi lội (chưa đóng): 115000
Sức bền vật liệu 1 (chưa đóng): 230000
Sức bền vật liệu 2 (chưa đóng): 300000
Cơ chất lỏng (chưa đóng): 345000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật điện (chưa đóng): 230000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
Nguyên lý máy (Đóng tàu) (chưa đóng): 460000
Vật liệu kỹ thuật (Đóng tàu) (chưa đóng): 345000
Toán chuyên đề (Khoa Đóng tàu) (chưa đóng): 230000
', CAST(0x0000A26E0115BC64 AS DateTime), NULL, 0, NULL, 10, 954, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (891, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0115C003 AS DateTime), NULL, 0, NULL, 10, 955, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (892, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0115C468 AS DateTime), NULL, 0, NULL, 10, 957, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (893, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tư tưởng Hồ Chí Minh (chưa đóng): 300000
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
Vẽ kỹ thuật cơ khí (chưa đóng): 300000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E0115C78F AS DateTime), NULL, 0, NULL, 10, 958, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (894, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0115CD45 AS DateTime), NULL, 0, NULL, 10, 960, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (895, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0115D0A3 AS DateTime), NULL, 0, NULL, 10, 961, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (896, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0115D3C6 AS DateTime), NULL, 0, NULL, 10, 962, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (897, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0115D917 AS DateTime), NULL, 0, NULL, 10, 964, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (898, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0115DBF9 AS DateTime), NULL, 0, NULL, 10, 965, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (899, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bơi lội (chưa đóng): 115000
Đường lối CM của ĐCS Việt Nam (chưa đóng): 345000
Tư tưởng Hồ Chí Minh (chưa đóng): 230000
Tiếng Anh cơ bản 2 (chưa đóng): 345000
Tiếng Anh cơ bản 3 (chưa đóng): 345000
Đại số (chưa đóng): 345000
Vật lý 1 (chưa đóng): 345000
Vật lý 2 (chưa đóng): 345000
Vẽ kỹ thuật – Autocad (chưa đóng): 230000
Cơ lý thuyết (chưa đóng): 460000
Sức bền vật liệu 1 (chưa đóng): 230000
Cơ chất lỏng (chưa đóng): 345000
Kỹ thuật điện (chưa đóng): 230000
Nguyên lý máy (Đóng tàu) (chưa đóng): 460000
Vật liệu kỹ thuật (Đóng tàu) (chưa đóng): 345000
Toán chuyên đề (Khoa Đóng tàu) (chưa đóng): 230000
Vẽ kỹ thuật cơ khí (chưa đóng): 230000
', CAST(0x0000A26E0115DF03 AS DateTime), NULL, 0, NULL, 10, 966, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (900, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0115E1B5 AS DateTime), NULL, 0, NULL, 10, 967, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (901, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0115E692 AS DateTime), NULL, 0, NULL, 10, 969, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (902, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Cơ lý thuyết (chưa đóng): 600000
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0115E97A AS DateTime), NULL, 0, NULL, 10, 970, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (903, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bơi lội (chưa đóng): 115000
Giải tích 2 (chưa đóng): 460000
Sức bền vật liệu 1 (chưa đóng): 230000
Sức bền vật liệu 2 (chưa đóng): 300000
Cơ chất lỏng (chưa đóng): 345000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật điện (chưa đóng): 230000
Kỹ thuật nhiệt (chưa đóng): 450000
Nguyên lý máy (Đóng tàu) (chưa đóng): 460000
Vật liệu kỹ thuật (Đóng tàu) (chưa đóng): 345000
Toán chuyên đề (Khoa Đóng tàu) (chưa đóng): 230000
', CAST(0x0000A26E0115EC54 AS DateTime), NULL, 0, NULL, 10, 971, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (904, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0115EF05 AS DateTime), NULL, 0, NULL, 10, 972, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (905, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0115F490 AS DateTime), NULL, 0, NULL, 10, 974, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (906, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 450000
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0115F885 AS DateTime), NULL, 0, NULL, 10, 975, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (907, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0115FBB3 AS DateTime), NULL, 0, NULL, 10, 976, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (908, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0115FE2D AS DateTime), NULL, 0, NULL, 10, 977, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (909, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01160099 AS DateTime), NULL, 0, NULL, 10, 978, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (910, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Vẽ kỹ thuật – Autocad (chưa đóng): 300000
Cơ lý thuyết (chưa đóng): 600000
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E011603A5 AS DateTime), NULL, 0, NULL, 10, 979, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (911, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01160687 AS DateTime), NULL, 0, NULL, 10, 980, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (912, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01160AFF AS DateTime), NULL, 0, NULL, 10, 982, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (913, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01160D83 AS DateTime), NULL, 0, NULL, 10, 983, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (914, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bơi lội (chưa đóng): 115000
Sức bền vật liệu 1 (chưa đóng): 230000
Sức bền vật liệu 2 (chưa đóng): 300000
Cơ chất lỏng (chưa đóng): 345000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật điện (chưa đóng): 230000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
Nguyên lý máy (Đóng tàu) (chưa đóng): 460000
Vật liệu kỹ thuật (Đóng tàu) (chưa đóng): 345000
Thực tập cơ khí (Khoa Máy khai thác) (chưa đóng): 460000
Toán chuyên đề (Khoa Đóng tàu) (chưa đóng): 230000
', CAST(0x0000A26E011610A5 AS DateTime), NULL, 0, NULL, 10, 984, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (915, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Sức bền vật liệu 2 (chưa đóng): 300000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01161331 AS DateTime), NULL, 0, NULL, 10, 985, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (916, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E011615DA AS DateTime), NULL, 0, NULL, 10, 986, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (917, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01161865 AS DateTime), NULL, 0, NULL, 10, 987, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (918, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01161B00 AS DateTime), NULL, 0, NULL, 10, 988, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (919, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E0116206E AS DateTime), NULL, 0, NULL, 10, 990, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (920, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01162406 AS DateTime), NULL, 0, NULL, 10, 991, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (921, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Giải tích 2 (chưa đóng): 600000
Nguyên lý CB của CNMLN 1 (chưa đóng): 300000
', CAST(0x0000A26E01162747 AS DateTime), NULL, 0, NULL, 10, 992, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (922, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01162A33 AS DateTime), NULL, 0, NULL, 10, 993, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (923, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01162EF0 AS DateTime), NULL, 0, NULL, 10, 995, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (924, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Cơ lý thuyết (chưa đóng): 600000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
', CAST(0x0000A26E01163173 AS DateTime), NULL, 0, NULL, 10, 996, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (925, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E011634F4 AS DateTime), NULL, 0, NULL, 10, 1134, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (926, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E01163688 AS DateTime), NULL, 0, NULL, 10, 1135, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (927, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E01163849 AS DateTime), NULL, 0, NULL, 10, 1136, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (928, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E01163A4F AS DateTime), NULL, 0, NULL, 10, 1137, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (929, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E01163CAD AS DateTime), NULL, 0, NULL, 10, 1138, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (930, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E01163EA0 AS DateTime), NULL, 0, NULL, 10, 1139, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (931, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0116404B AS DateTime), NULL, 0, NULL, 10, 1140, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (932, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E01164245 AS DateTime), NULL, 0, NULL, 10, 1141, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (933, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E011644B8 AS DateTime), NULL, 0, NULL, 10, 1143, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (934, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E0116498B AS DateTime), NULL, 0, NULL, 10, 1146, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (935, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E01164B82 AS DateTime), NULL, 0, NULL, 10, 1147, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (936, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E01164EC1 AS DateTime), NULL, 0, NULL, 10, 1149, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (937, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kinh tế xây dựng (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E011651EC AS DateTime), NULL, 0, NULL, 10, 1150, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (938, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Kết cấu thép (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E01165471 AS DateTime), NULL, 0, NULL, 10, 1151, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (939, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E011656BD AS DateTime), NULL, 0, NULL, 10, 1152, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (940, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E011658D0 AS DateTime), NULL, 0, NULL, 10, 1153, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (941, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E01165B6E AS DateTime), NULL, 0, NULL, 10, 1154, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (942, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E01165D75 AS DateTime), NULL, 0, NULL, 10, 1155, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (943, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0116602B AS DateTime), NULL, 0, NULL, 10, 1157, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (944, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E011662E6 AS DateTime), NULL, 0, NULL, 10, 1158, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (945, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E01166603 AS DateTime), NULL, 0, NULL, 10, 1159, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (946, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Luật xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học môi trường liên tục (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E01166817 AS DateTime), NULL, 0, NULL, 10, 1160, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (947, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E011669E6 AS DateTime), NULL, 0, NULL, 10, 1161, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (948, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E01166C10 AS DateTime), NULL, 0, NULL, 10, 1162, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (949, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E01166DC1 AS DateTime), NULL, 0, NULL, 10, 1163, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (950, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bơi lội (chưa đóng): 115000
Kỹ thuật bóng chuyền (chưa đóng): 115000
Đường lối CM của ĐCS Việt Nam (chưa đóng): 345000
Địa chất công trình (chưa đóng): 230000
Vật liệu xây dựng (chưa đóng): 345000
Xác suất thống kê (Kỹ thuật) (chưa đóng): 230000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 1 (chưa đóng): 230000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Trắc địa công trình (chưa đóng): 230000
Cơ lý thuyết (chưa đóng): 600000
Thuỷ văn công trình (chưa đóng): 450000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E01167180 AS DateTime), NULL, 0, NULL, 10, 1164, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (951, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
HP2 - Công tác Quốc phòng- An ninh (chưa đóng): 300000
Bê tông cốt thép (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Cơ lý thuyết (chưa đóng): 600000
Kết cấu thép (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E01167678 AS DateTime), NULL, 0, NULL, 10, 1165, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (952, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
Sức bền vật liệu 1 (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E01167B95 AS DateTime), NULL, 0, NULL, 10, 1166, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (953, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E011680C0 AS DateTime), NULL, 0, NULL, 10, 1167, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (954, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E01168604 AS DateTime), NULL, 0, NULL, 10, 1168, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (955, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
HP2 - Công tác Quốc phòng- An ninh (chưa đóng): 230000
Kỹ thuật bơi lội (chưa đóng): 115000
Đường lối CM của ĐCS Việt Nam (chưa đóng): 345000
Tư tưởng Hồ Chí Minh (chưa đóng): 230000
Tiếng Anh cơ bản 3 (chưa đóng): 345000
Đại số (chưa đóng): 345000
Địa chất công trình (chưa đóng): 230000
Vật liệu xây dựng (chưa đóng): 345000
Tin học đại cương (chưa đóng): 345000
Xác suất thống kê (Kỹ thuật) (chưa đóng): 230000
Trắc địa công trình (chưa đóng): 230000
Sức bền vật liệu 1 (chưa đóng): 230000
Nguyên lý CB của CNMLN 1 (chưa đóng): 230000
', CAST(0x0000A26E01168A39 AS DateTime), NULL, 0, NULL, 10, 1169, 0, 1)
GO
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (956, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E01168E2E AS DateTime), NULL, 0, NULL, 10, 1170, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (957, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tư tưởng Hồ Chí Minh (chưa đóng): 230000
Tiếng Anh cơ bản 3 (chưa đóng): 345000
Đại số (chưa đóng): 345000
Vật lý 2 (chưa đóng): 345000
Địa chất công trình (chưa đóng): 230000
Sức bền vật liệu 1 (chưa đóng): 230000
', CAST(0x0000A26E01169069 AS DateTime), NULL, 0, NULL, 10, 1171, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (958, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0116935C AS DateTime), NULL, 0, NULL, 10, 1172, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (959, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E011697BE AS DateTime), NULL, 0, NULL, 10, 1174, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (960, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E011699BD AS DateTime), NULL, 0, NULL, 10, 1175, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (961, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật điền kinh (chưa đóng): 115000
Đường lối CM của ĐCS Việt Nam (chưa đóng): 345000
Địa chất công trình (chưa đóng): 230000
Vật liệu xây dựng (chưa đóng): 345000
Xác suất thống kê (Kỹ thuật) (chưa đóng): 230000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Trắc địa công trình (chưa đóng): 230000
Cơ lý thuyết (chưa đóng): 600000
Thuỷ văn công trình (chưa đóng): 450000
Kỹ thuật bóng chuyền (chưa đóng): 150000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E01169D04 AS DateTime), NULL, 0, NULL, 10, 1176, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (962, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Các phương pháp số (chưa đóng): 450000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
', CAST(0x0000A26E01169F69 AS DateTime), NULL, 0, NULL, 10, 1177, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (963, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0116A1B4 AS DateTime), NULL, 0, NULL, 10, 1178, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (964, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
', CAST(0x0000A26E0116A377 AS DateTime), NULL, 0, NULL, 10, 1179, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (965, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Vật liệu xây dựng (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
', CAST(0x0000A26E0116A53B AS DateTime), NULL, 0, NULL, 10, 1180, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (966, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Vật liệu xây dựng (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
', CAST(0x0000A26E0116A764 AS DateTime), NULL, 0, NULL, 10, 1181, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (967, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0116A944 AS DateTime), NULL, 0, NULL, 10, 1182, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (968, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0116ABCB AS DateTime), NULL, 0, NULL, 10, 1183, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (969, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0116AE3C AS DateTime), NULL, 0, NULL, 10, 1184, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (970, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0116B016 AS DateTime), NULL, 0, NULL, 10, 1185, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (971, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0116B30B AS DateTime), NULL, 0, NULL, 10, 1187, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (972, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Vật lý 2 (chưa đóng): 450000
Bê tông cốt thép (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học môi trường liên tục (chưa đóng): 300000
Sức bền vật liệu 1 (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0116B528 AS DateTime), NULL, 0, NULL, 10, 1188, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (973, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
HP2 - Công tác Quốc phòng- An ninh (chưa đóng): 230000
Đường lối CM của ĐCS Việt Nam (chưa đóng): 345000
Vẽ kỹ thuật – Autocad (chưa đóng): 230000
Trắc địa công trình (chưa đóng): 230000
', CAST(0x0000A26E0116B6D6 AS DateTime), NULL, 0, NULL, 10, 1189, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (974, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Sức bền vật liệu 2 (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0116B8FB AS DateTime), NULL, 0, NULL, 10, 1190, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (975, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Sức bền vật liệu 1 (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0116BAF8 AS DateTime), NULL, 0, NULL, 10, 1191, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (976, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 450000
Bê tông cốt thép (chưa đóng): 450000
Vật liệu xây dựng (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
', CAST(0x0000A26E0116BCFE AS DateTime), NULL, 0, NULL, 10, 1192, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (977, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E0116BFA6 AS DateTime), NULL, 0, NULL, 10, 1195, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (978, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0116C19A AS DateTime), NULL, 0, NULL, 10, 1196, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (979, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Luật xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Công trình thuỷ công trong NMĐT (chưa đóng): 450000
Kết cấu thép (chưa đóng): 300000
Kinh tế xây dựng (chưa đóng): 300000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E0116C3BF AS DateTime), NULL, 0, NULL, 10, 1197, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (980, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Thiết bị hàng hải (chưa đóng): 300000
Hàng hải cơ sở (chưa đóng): 450000
Khí tượng, thủy, hải văn (chưa đóng): 450000
Máy tàu thủy (chưa đóng): 300000
Trắc địa cơ sở (chưa đóng): 600000
Vật liệu xây dựng (chưa đóng): 450000
Cơ lý thuyết (chưa đóng): 300000
Sức bền vật liệu (chưa đóng): 300000
Kỹ thuật bóng chuyền (chưa đóng): 150000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E0116C74E AS DateTime), NULL, 0, NULL, 10, 1215, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (981, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Kết cấu thép (chưa đóng): 300000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0116C9BB AS DateTime), NULL, 0, NULL, 10, 1264, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (982, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0116CCCE AS DateTime), NULL, 0, NULL, 10, 1267, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (983, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kiến trúc máy tính (chưa đóng): 600000
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0116D0B6 AS DateTime), NULL, 0, NULL, 10, 1279, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (984, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bê tông cốt thép (chưa đóng): 450000
Máy xây dựng (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 450000
TKMH Bê tông cốt thép (chưa đóng): 150000
Thuỷ văn công trình (chưa đóng): 450000
', CAST(0x0000A26E0116D2C5 AS DateTime), NULL, 0, NULL, 10, 1294, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (985, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0116D5E6 AS DateTime), NULL, 0, NULL, 10, 1312, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (986, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Đại số (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0116D8A0 AS DateTime), NULL, 0, NULL, 10, 1337, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (987, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0116DC46 AS DateTime), NULL, 0, NULL, 10, 1338, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (988, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0116DF2C AS DateTime), NULL, 0, NULL, 10, 1406, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (989, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
HP1- Đường lối QS của Đảng (chưa đóng): 230000
HP2 - Công tác Quốc phòng- An ninh (chưa đóng): 230000
Đường lối CM của ĐCS Việt Nam (chưa đóng): 345000
Địa chất công trình (chưa đóng): 230000
Vật liệu xây dựng (chưa đóng): 345000
Xác suất thống kê (Kỹ thuật) (chưa đóng): 230000
Cơ học kết cấu 1 (chưa đóng): 230000
Trắc địa công trình (chưa đóng): 230000
Sức bền vật liệu 1 (chưa đóng): 230000
Sức bền vật liệu 2 (chưa đóng): 230000
', CAST(0x0000A26E0116E2C0 AS DateTime), NULL, 0, NULL, 10, 1407, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (990, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tư tưởng Hồ Chí Minh (chưa đóng): 230000
Tiếng Anh cơ bản 3 (chưa đóng): 345000
Đại số (chưa đóng): 345000
Vật lý 2 (chưa đóng): 345000
Thực tập cơ khí (Khoa công trình) (chưa đóng): 230000
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Thuỷ lực cơ sở (chưa đóng): 345000
Sức bền vật liệu 1 (chưa đóng): 230000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0116E635 AS DateTime), NULL, 0, NULL, 10, 1408, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (991, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0116E98F AS DateTime), NULL, 0, NULL, 10, 1409, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (992, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0116ECE7 AS DateTime), NULL, 0, NULL, 10, 1410, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (993, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
HP1- Đường lối QS của Đảng (chưa đóng): 230000
Kỹ thuật điền kinh (chưa đóng): 115000
Đường lối CM của ĐCS Việt Nam (chưa đóng): 345000
Địa chất công trình (chưa đóng): 230000
Vật liệu xây dựng (chưa đóng): 345000
Xác suất thống kê (Kỹ thuật) (chưa đóng): 230000
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 1 (chưa đóng): 230000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Trắc địa công trình (chưa đóng): 230000
Sức bền vật liệu 2 (chưa đóng): 230000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0116F11D AS DateTime), NULL, 0, NULL, 10, 1411, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (994, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E0116F416 AS DateTime), NULL, 0, NULL, 10, 1412, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (995, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0116F69E AS DateTime), NULL, 0, NULL, 10, 1413, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (996, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0116FC74 AS DateTime), NULL, 0, NULL, 10, 1416, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (997, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học môi trường liên tục (chưa đóng): 300000
Sức bền vật liệu 1 (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0116FF9A AS DateTime), NULL, 0, NULL, 10, 1417, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (998, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E011702B1 AS DateTime), NULL, 0, NULL, 10, 1418, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (999, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 450000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E011705B3 AS DateTime), NULL, 0, NULL, 10, 1419, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1000, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01170A1C AS DateTime), NULL, 0, NULL, 10, 1421, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1001, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đường lối CM của ĐCS Việt Nam (chưa đóng): 450000
Vật liệu xây dựng (chưa đóng): 450000
Tin học ứng dụng (chưa đóng): 450000
Sức bền vật liệu 1 (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01170CBF AS DateTime), NULL, 0, NULL, 10, 1422, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1002, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01171217 AS DateTime), NULL, 0, NULL, 10, 1424, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1003, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E0117155D AS DateTime), NULL, 0, NULL, 10, 1425, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1004, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01171897 AS DateTime), NULL, 0, NULL, 10, 1426, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1005, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01171BB2 AS DateTime), NULL, 0, NULL, 10, 1427, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1006, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01171E6D AS DateTime), NULL, 0, NULL, 10, 1428, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1007, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Sức bền vật liệu 2 (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0117210C AS DateTime), NULL, 0, NULL, 10, 1429, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1008, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01172393 AS DateTime), NULL, 0, NULL, 10, 1430, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1009, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học môi trường liên tục (chưa đóng): 300000
Sức bền vật liệu 2 (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01172654 AS DateTime), NULL, 0, NULL, 10, 1432, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1010, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01172963 AS DateTime), NULL, 0, NULL, 10, 1433, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1011, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01172EE6 AS DateTime), NULL, 0, NULL, 10, 1435, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1012, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E011731CB AS DateTime), NULL, 0, NULL, 10, 1436, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1013, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Vật lý 2 (chưa đóng): 450000
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E0117351A AS DateTime), NULL, 0, NULL, 10, 1437, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1014, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01173859 AS DateTime), NULL, 0, NULL, 10, 1438, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1015, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01173BA1 AS DateTime), NULL, 0, NULL, 10, 1439, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1016, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01173F93 AS DateTime), NULL, 0, NULL, 10, 1440, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1017, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E011742D7 AS DateTime), NULL, 0, NULL, 10, 1441, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1018, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tư tưởng Hồ Chí Minh (chưa đóng): 300000
Kết cấu gạch đá gỗ (chưa đóng): 300000
Các phương pháp số (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Sức bền vật liệu 2 (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E011745A2 AS DateTime), NULL, 0, NULL, 10, 1442, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1019, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Sức bền vật liệu 2 (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0117493B AS DateTime), NULL, 0, NULL, 10, 1443, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1020, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01174DFB AS DateTime), NULL, 0, NULL, 10, 1444, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1021, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Sức bền vật liệu 2 (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E011752B3 AS DateTime), NULL, 0, NULL, 10, 1445, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1022, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01175621 AS DateTime), NULL, 0, NULL, 10, 1446, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1023, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0117592A AS DateTime), NULL, 0, NULL, 10, 1447, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1024, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01175CA3 AS DateTime), NULL, 0, NULL, 10, 1448, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1025, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01175FE1 AS DateTime), NULL, 0, NULL, 10, 1449, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1026, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01176389 AS DateTime), NULL, 0, NULL, 10, 1450, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1027, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
HP1- Đường lối QS của Đảng (chưa đóng): 230000
HP2 - Công tác Quốc phòng- An ninh (chưa đóng): 230000
Kỹ thuật điền kinh (chưa đóng): 115000
Tiếng Anh cơ bản 2 (chưa đóng): 345000
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Giải tích 1 (chưa đóng): 600000
Địa chất công trình (chưa đóng): 230000
Địa chất công trình (chưa đóng): 300000
Vật liệu xây dựng (chưa đóng): 345000
Tin học đại cương (chưa đóng): 450000
Xác suất thống kê (Kỹ thuật) (chưa đóng): 230000
Cơ học kết cấu 1 (chưa đóng): 230000
Trắc địa công trình (chưa đóng): 230000
Cơ lý thuyết (chưa đóng): 600000
Sức bền vật liệu 1 (chưa đóng): 300000
Sức bền vật liệu 2 (chưa đóng): 230000
Nguyên lý CB của CNMLN 2 (chưa đóng): 345000
Giáo dục quốc phòng HP3+4 (chưa đóng): 460000
Đường lối QS của Đảng (chưa đóng): 450000
Công tác quốc phòng-an ninh (chưa đóng): 300000
Kỹ thuật cầu lông (chưa đóng): 150000
', CAST(0x0000A26E011767B7 AS DateTime), NULL, 0, NULL, 10, 1451, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1028, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01176AA9 AS DateTime), NULL, 0, NULL, 10, 1452, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1029, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E01176DF7 AS DateTime), NULL, 0, NULL, 10, 1453, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1030, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E011770B4 AS DateTime), NULL, 0, NULL, 10, 1454, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1031, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01177424 AS DateTime), NULL, 0, NULL, 10, 1455, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1032, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Sức bền vật liệu 2 (chưa đóng): 300000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E011777BD AS DateTime), NULL, 0, NULL, 10, 1456, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1033, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01177ABB AS DateTime), NULL, 0, NULL, 10, 1457, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1034, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01177EE7 AS DateTime), NULL, 0, NULL, 10, 1458, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1035, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E011781CC AS DateTime), NULL, 0, NULL, 10, 1459, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1036, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Kiến trúc dân dụng (chưa đóng): 150000
Kết cấu gạch đá gỗ (chưa đóng): 300000
Kỹ thuật thông gió (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Vật lý kiến trúc (chưa đóng): 300000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E011785DC AS DateTime), NULL, 0, NULL, 10, 1460, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1037, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E011788D3 AS DateTime), NULL, 0, NULL, 10, 1461, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1038, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01178BA5 AS DateTime), NULL, 0, NULL, 10, 1462, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1039, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01178E8E AS DateTime), NULL, 0, NULL, 10, 1463, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1040, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01179212 AS DateTime), NULL, 0, NULL, 10, 1464, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1041, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Kỹ thuật thông gió (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E011796E5 AS DateTime), NULL, 0, NULL, 10, 1465, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1042, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01179A0A AS DateTime), NULL, 0, NULL, 10, 1466, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1043, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Vật lý 2 (chưa đóng): 450000
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E01179CCD AS DateTime), NULL, 0, NULL, 10, 1467, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1044, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật thông gió (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Vật lý kiến trúc (chưa đóng): 300000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0117A274 AS DateTime), NULL, 0, NULL, 10, 1469, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1045, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0117A8A0 AS DateTime), NULL, 0, NULL, 10, 1471, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1046, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Máy xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E0117AD51 AS DateTime), NULL, 0, NULL, 10, 1473, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1047, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0117B036 AS DateTime), NULL, 0, NULL, 10, 1474, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1048, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kết cấu gạch đá gỗ (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Các phương pháp số (chưa đóng): 450000
Cơ học đất (chưa đóng): 600000
Cơ học kết cấu 2 (chưa đóng): 450000
Cơ học môi trường liên tục (chưa đóng): 300000
Vẽ kỹ thuật xây dựng 2 (chưa đóng): 300000
', CAST(0x0000A26E0117B487 AS DateTime), NULL, 0, NULL, 10, 1475, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1049, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kiến trúc máy tính (chưa đóng): 600000
Đường lối CM của ĐCS Việt Nam (chưa đóng): 450000
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Đại số (chưa đóng): 450000
Giải tích 1 (chưa đóng): 600000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E0117B7FC AS DateTime), NULL, 0, NULL, 10, 1483, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1050, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0117BB9F AS DateTime), NULL, 0, NULL, 10, 1568, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1051, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0117BE55 AS DateTime), NULL, 0, NULL, 10, 1569, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1052, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0117C3F8 AS DateTime), NULL, 0, NULL, 10, 1571, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1053, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0117CE62 AS DateTime), NULL, 0, NULL, 10, 1575, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1054, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0117D172 AS DateTime), NULL, 0, NULL, 10, 1576, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1055, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0117D6F5 AS DateTime), NULL, 0, NULL, 10, 1578, 0, 1)
GO
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1056, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0117D9CC AS DateTime), NULL, 0, NULL, 10, 1579, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1057, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0117DD15 AS DateTime), NULL, 0, NULL, 10, 1580, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1058, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0117DFAE AS DateTime), NULL, 0, NULL, 10, 1581, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1059, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0117E403 AS DateTime), NULL, 0, NULL, 10, 1583, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1060, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0117E725 AS DateTime), NULL, 0, NULL, 10, 1584, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1061, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0117EC0D AS DateTime), NULL, 0, NULL, 10, 1586, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1062, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0117EF1F AS DateTime), NULL, 0, NULL, 10, 1587, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1063, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0117F1E9 AS DateTime), NULL, 0, NULL, 10, 1588, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1064, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0117F4F1 AS DateTime), NULL, 0, NULL, 10, 1589, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1065, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Thiết bị hàng hải (chưa đóng): 300000
Tin học ứng dụng (chưa đóng): 450000
Hàng hải cơ sở (chưa đóng): 450000
Khí tượng, thủy, hải văn (chưa đóng): 450000
Máy tàu thủy (chưa đóng): 300000
Trắc địa cơ sở (chưa đóng): 600000
Vật liệu xây dựng (chưa đóng): 450000
Hình họa (chưa đóng): 300000
Hóa đại cương (chưa đóng): 450000
', CAST(0x0000A26E0117F7B2 AS DateTime), NULL, 0, NULL, 10, 1590, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1066, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0117FBD3 AS DateTime), NULL, 0, NULL, 10, 1591, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1067, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0118008E AS DateTime), NULL, 0, NULL, 10, 1593, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1068, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01180334 AS DateTime), NULL, 0, NULL, 10, 1594, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1069, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E011807BE AS DateTime), NULL, 0, NULL, 10, 1596, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1070, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01180A9C AS DateTime), NULL, 0, NULL, 10, 1597, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1071, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01180D56 AS DateTime), NULL, 0, NULL, 10, 1598, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1072, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01181049 AS DateTime), NULL, 0, NULL, 10, 1599, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1073, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01181303 AS DateTime), NULL, 0, NULL, 10, 1600, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1074, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Đại số (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E011815A8 AS DateTime), NULL, 0, NULL, 10, 1601, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1075, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0118182A AS DateTime), NULL, 0, NULL, 10, 1602, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1076, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01181D38 AS DateTime), NULL, 0, NULL, 10, 1604, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1077, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01182078 AS DateTime), NULL, 0, NULL, 10, 1605, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1078, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01182393 AS DateTime), NULL, 0, NULL, 10, 1606, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1079, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0118267A AS DateTime), NULL, 0, NULL, 10, 1607, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1080, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01182957 AS DateTime), NULL, 0, NULL, 10, 1608, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1081, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Đại số (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E01182BD3 AS DateTime), NULL, 0, NULL, 10, 1609, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1082, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01183187 AS DateTime), NULL, 0, NULL, 10, 1611, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1083, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01183545 AS DateTime), NULL, 0, NULL, 10, 1612, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1084, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01183CF0 AS DateTime), NULL, 0, NULL, 10, 1615, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1085, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01183FBF AS DateTime), NULL, 0, NULL, 10, 1616, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1086, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Đại số (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E011842A5 AS DateTime), NULL, 0, NULL, 10, 1617, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1087, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01184747 AS DateTime), NULL, 0, NULL, 10, 2933, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1088, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01184CDC AS DateTime), NULL, 0, NULL, 10, 2935, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1089, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E01185419 AS DateTime), NULL, 0, NULL, 10, 2938, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1090, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E011856B8 AS DateTime), NULL, 0, NULL, 10, 2939, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1091, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01185E79 AS DateTime), NULL, 0, NULL, 10, 2943, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1092, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Đại số (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
Kỹ thuật bóng chuyền (chưa đóng): 150000
', CAST(0x0000A26E01186144 AS DateTime), NULL, 0, NULL, 10, 2944, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1093, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01186401 AS DateTime), NULL, 0, NULL, 10, 2945, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1094, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E011866A5 AS DateTime), NULL, 0, NULL, 10, 2946, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1095, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E01186CE9 AS DateTime), NULL, 0, NULL, 10, 2949, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1096, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Đại số (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0118734C AS DateTime), NULL, 0, NULL, 10, 2953, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1097, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bóng chuyền (chưa đóng): 115000
Tư tưởng Hồ Chí Minh (chưa đóng): 230000
Tiếng Anh cơ bản 2 (chưa đóng): 345000
Nguyên lý CB của CNMLN 2 (chưa đóng): 345000
Lý thuyết tàu (chưa đóng): 230000
Kinh tế vi mô 1 (chưa đóng): 230000
Toán cao cấp C2 (chưa đóng): 230000
', CAST(0x0000A26E0118758F AS DateTime), NULL, 0, NULL, 10, 2954, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1098, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bóng chuyền (chưa đóng): 115000
Tư tưởng Hồ Chí Minh (chưa đóng): 230000
Tiếng Anh cơ bản 2 (chưa đóng): 345000
Nguyên lý CB của CNMLN 2 (chưa đóng): 345000
Lý thuyết tàu (chưa đóng): 230000
Kinh tế vi mô 1 (chưa đóng): 230000
Toán cao cấp C2 (chưa đóng): 230000
', CAST(0x0000A26E0118779C AS DateTime), NULL, 0, NULL, 10, 2955, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1099, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật vi xử lý (chưa đóng): 450000
Lập trình Windows (chưa đóng): 450000
Nguyên lý hệ điều hành (chưa đóng): 300000
Phân tích thiết kế HT (chưa đóng): 450000
Lý thuyết đồ thị (chưa đóng): 450000
Đại số (chưa đóng): 450000
Quản trị doanh nghiệp (chưa đóng): 600000
', CAST(0x0000A26E0118826C AS DateTime), NULL, 0, NULL, 10, 2960, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1100, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bơi lội (chưa đóng): 115000
Vẽ kỹ thuật – Autocad (chưa đóng): 230000
Sức bền vật liệu 1 (chưa đóng): 230000
Sức bền vật liệu 2 (chưa đóng): 300000
Cơ chất lỏng (chưa đóng): 345000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Vẽ tàu (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật điện (chưa đóng): 230000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
Nguyên lý máy (Đóng tàu) (chưa đóng): 460000
Vật liệu kỹ thuật (Đóng tàu) (chưa đóng): 345000
Thực tập cơ khí (Khoa Máy khai thác) (chưa đóng): 460000
Toán chuyên đề (Khoa Đóng tàu) (chưa đóng): 230000
', CAST(0x0000A26E0118879F AS DateTime), NULL, 0, NULL, 10, 3025, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1101, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bơi lội (chưa đóng): 115000
Sức bền vật liệu 1 (chưa đóng): 230000
Sức bền vật liệu 2 (chưa đóng): 300000
Cơ chất lỏng (chưa đóng): 345000
TKMH Cơ sở thiết kế máy (chưa đóng): 150000
Cơ sở kỹ thuật điện tử (chưa đóng): 300000
Cơ sở thiết kế máy (chưa đóng): 450000
Kỹ thuật an toàn và môi trường (chưa đóng): 300000
Kỹ thuật điện (chưa đóng): 230000
Kỹ thuật gia công cơ khí (Đóng tàu) (chưa đóng): 600000
Kỹ thuật nhiệt (chưa đóng): 450000
Nguyên lý máy (Đóng tàu) (chưa đóng): 460000
Vật liệu kỹ thuật (Đóng tàu) (chưa đóng): 345000
Thực tập cơ khí (Khoa Máy khai thác) (chưa đóng): 460000
Toán chuyên đề (Khoa Đóng tàu) (chưa đóng): 230000
Kỹ thuật bóng chuyền (chưa đóng): 150000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E01188BD2 AS DateTime), NULL, 0, NULL, 10, 3026, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1102, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
', CAST(0x0000A26E01189457 AS DateTime), NULL, 0, NULL, 10, 9248, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1103, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
La bàn từ (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01189840 AS DateTime), NULL, 0, NULL, 10, 9249, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1104, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 1 (chưa đóng): 450000
Điện tàu thuỷ (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Thuỷ nghiệp - Thông hiệu HH 1 (chưa đóng): 300000
', CAST(0x0000A26E01189C5B AS DateTime), NULL, 0, NULL, 10, 9250, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1105, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Kết cấu bê tông cốt thép 2 (chưa đóng): 150000
TKMH Kiến trúc dân dụng (chưa đóng): 150000
TKMH Kỹ thuật thi công 2 (chưa đóng): 150000
Kết cấu Bê tông cốt thép 2 (chưa đóng): 450000
Kết cấu thép 2 (chưa đóng): 450000
Kiến trúc dân dụng (chưa đóng): 450000
Kỹ thuật thi công 2 (chưa đóng): 450000
Kỹ thuật thông gió (chưa đóng): 300000
Luật xây dựng (chưa đóng): 300000
Vật lý kiến trúc (chưa đóng): 300000
', CAST(0x0000A26E0118A29D AS DateTime), NULL, 0, NULL, 10, 9252, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1106, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Tự động điều khiển tàu (chưa đóng): 450000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0118A6CC AS DateTime), NULL, 0, NULL, 10, 9253, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1107, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0118AA60 AS DateTime), NULL, 0, NULL, 10, 9254, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1108, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Giải tích 1 (chưa đóng): 600000
TKMH Kỹ thuật xử lí nước và nước thải (chưa đóng): 150000
TKMH Kỹ thuật xử lý ô nhiễm môi trường biển (chưa đóng): 150000
Các QTSX cơ bản và nguyên lí SXSH (chưa đóng): 300000
Kỹ thuật xử lí nước và nước thải (chưa đóng): 600000
Kỹ thuật xử lý ô nhiễm môi trường biển (chưa đóng): 600000
Quản lý môi trường (chưa đóng): 450000
Độc học môi trường (chưa đóng): 450000
', CAST(0x0000A26E0118AD97 AS DateTime), NULL, 0, NULL, 10, 9255, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1109, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
Thiết bị và kỹ thuật đo (chưa đóng): 300000
', CAST(0x0000A26E0118B0CA AS DateTime), NULL, 0, NULL, 10, 9256, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1110, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E0118B44D AS DateTime), NULL, 0, NULL, 10, 9257, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1111, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
Thiết bị và kỹ thuật đo (chưa đóng): 300000
', CAST(0x0000A26E0118B8B3 AS DateTime), NULL, 0, NULL, 10, 9258, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1112, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Lập trình mạng (chưa đóng): 750000
Mạng máy tính (chưa đóng): 600000
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Hệ chuyên gia (chưa đóng): 450000
PTTK hệ thống hướng đối tượng (chưa đóng): 300000
Thiết kế và lập trình Web (chưa đóng): 450000
Kỹ thuật điền kinh & TD (chưa đóng): 150000
', CAST(0x0000A26E0118BC3C AS DateTime), NULL, 0, NULL, 10, 9259, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1113, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
Thiết bị và kỹ thuật đo (chưa đóng): 300000
', CAST(0x0000A26E0118C01B AS DateTime), NULL, 0, NULL, 10, 9260, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1114, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu (chưa đóng): 230000
Điện tàu thuỷ 1 (chưa đóng): 460000
Động cơ đốt trong1 (chưa đóng): 460000
Máy phụ 1 (tiếng Việt) (chưa đóng): 460000
Thiết bị trao đổi nhiệt (chưa đóng): 230000
Hóa kỹ thuật (chưa đóng): 230000
Kết cấu và lý thuyết tàu (chưa đóng): 230000
Kỹ thuật gia công cơ khí 2 (chưa đóng): 230000
Nhiệt kỹ thuật (chưa đóng): 460000
Tiếng Anh chuyên ngành MKT 1 (chưa đóng): 345000
Thực tập thợ máy 1 (chưa đóng): 805000
', CAST(0x0000A26E0118CA42 AS DateTime), NULL, 0, NULL, 10, 9264, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1115, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Nồi hơi tua bin tàu thuỷ (chưa đóng): 750000
', CAST(0x0000A26E0118CD26 AS DateTime), NULL, 0, NULL, 10, 9265, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1116, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Hình họa (chưa đóng): 300000
TKMH Cung cấp điện (chưa đóng): 150000
Chuyên đề 1 (chưa đóng): 300000
Công nghệ CAD – CAM (chưa đóng): 300000
Cung cấp điện (chưa đóng): 450000
Điều khiển Robốt (chưa đóng): 450000
Điều khiển sản suất tích hợp máy tính (chưa đóng): 600000
PLC (chưa đóng): 450000
Trang bị điện điện tử máy gia công KL (chưa đóng): 450000
', CAST(0x0000A26E0118D054 AS DateTime), NULL, 0, NULL, 10, 9268, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1117, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Logistics và VTĐPT (chưa đóng): 300000
Kinh tế lượng (chưa đóng): 450000
Thanh toán quốc tế (chưa đóng): 450000
TKMH Thanh toán quốc tế (chưa đóng): 150000
Bảo hiểm đối ngoại (chưa đóng): 450000
Giao nhận hàng hóa XNK (chưa đóng): 600000
Vận tải-Thuê tàu (chưa đóng): 600000
Phân tích hoạt động kinh tế trong KTN (chưa đóng): 450000
TKMH Phân tích hoạt động kinh tế KTN (chưa đóng): 150000
', CAST(0x0000A26E0118D49B AS DateTime), NULL, 0, NULL, 10, 9269, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1118, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Phân tích hoạt động kinh tế QKD (chưa đóng): 150000
TKMH Quản trị dự án đầu tư (chưa đóng): 150000
Bảo hiểm (chưa đóng): 450000
Quản trị công nghệ (chưa đóng): 300000
Quản trị dự án đầu tư (chưa đóng): 450000
Quản trị hành chính (chưa đóng): 450000
Quản trị sản xuất (chưa đóng): 600000
Phân tích hoạt động kinh tế trong QTKD (chưa đóng): 450000
', CAST(0x0000A26E0118D7E5 AS DateTime), NULL, 0, NULL, 10, 9270, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1119, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Logistics và VTĐPT (chưa đóng): 300000
Pháp luật kinh tế (chưa đóng): 450000
Thanh toán quốc tế (chưa đóng): 450000
TKMH Thanh toán quốc tế (chưa đóng): 150000
Bảo hiểm đối ngoại (chưa đóng): 450000
Giao nhận hàng hóa XNK (chưa đóng): 600000
Vận tải-Thuê tàu (chưa đóng): 600000
Phân tích hoạt động kinh tế trong KTN (chưa đóng): 450000
Tiếng anh chuyên ngành KTN2 (chưa đóng): 300000
TKMH Phân tích hoạt động kinh tế KTN (chưa đóng): 150000
', CAST(0x0000A26E0118DD48 AS DateTime), NULL, 0, NULL, 10, 9271, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1120, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Bảo hiểm (chưa đóng): 450000
TKMH Phân tích hoạt động kinh tế QKT (chưa đóng): 150000
Kế toán doanh nghiệp (chưa đóng): 300000
Kế toán hành chính sự nghiệp (chưa đóng): 450000
Kế toán quản trị (chưa đóng): 300000
Kiểm toán (chưa đóng): 450000
Quản lý tài chính Nhà nước (chưa đóng): 300000
Phân tích hoạt động kinh tế trong QKT (chưa đóng): 450000
', CAST(0x0000A26E0118E057 AS DateTime), NULL, 0, NULL, 10, 9272, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1121, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 1 (chưa đóng): 450000
Hóa đại cương (chưa đóng): 450000
TKMH Kết cấu bê tông cốt thép 2 (chưa đóng): 150000
TKMH Kiến trúc dân dụng (chưa đóng): 150000
TKMH Kỹ thuật thi công 2 (chưa đóng): 150000
Kiến trúc dân dụng (chưa đóng): 450000
Kỹ thuật thi công 2 (chưa đóng): 450000
Kỹ thuật thông gió (chưa đóng): 300000
Vật lý kiến trúc (chưa đóng): 300000
', CAST(0x0000A26E0118E467 AS DateTime), NULL, 0, NULL, 10, 9273, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1122, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E0118EA09 AS DateTime), NULL, 0, NULL, 10, 9275, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1123, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
La bàn từ (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0118F31F AS DateTime), NULL, 0, NULL, 10, 9279, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1124, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Điện tàu thuỷ (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Luật biển (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0118F69D AS DateTime), NULL, 0, NULL, 10, 9280, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1125, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E0118FA41 AS DateTime), NULL, 0, NULL, 10, 9281, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1126, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0118FD98 AS DateTime), NULL, 0, NULL, 10, 9282, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1127, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đường lối CM của ĐCS Việt Nam (chưa đóng): 345000
Sức bền vật liệu (chưa đóng): 230000
Địa văn hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E011900C9 AS DateTime), NULL, 0, NULL, 10, 9283, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1128, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01190411 AS DateTime), NULL, 0, NULL, 10, 9285, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1129, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011907AC AS DateTime), NULL, 0, NULL, 10, 9286, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1130, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Tiếng Anh chuyên ngành ĐKT 1 (chưa đóng): 345000
', CAST(0x0000A26E01190C4F AS DateTime), NULL, 0, NULL, 10, 9287, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1131, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01190FEE AS DateTime), NULL, 0, NULL, 10, 9288, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1132, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
An toàn lao động HH (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
La bàn từ (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01191370 AS DateTime), NULL, 0, NULL, 10, 9289, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1133, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0119189D AS DateTime), NULL, 0, NULL, 10, 9291, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1134, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01191BC4 AS DateTime), NULL, 0, NULL, 10, 9292, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1135, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01192420 AS DateTime), NULL, 0, NULL, 10, 9295, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1136, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0119280C AS DateTime), NULL, 0, NULL, 10, 9296, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1137, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01192B61 AS DateTime), NULL, 0, NULL, 10, 9297, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1138, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Máy tàu thủy (chưa đóng): 230000
Máy tàu thủy (chưa đóng): 300000
Cơ lý thuyết (chưa đóng): 300000
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Lý thuyết tàu (chưa đóng): 230000
Tiếng Anh chuyên ngành ĐKT 1 (chưa đóng): 345000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E01192FB1 AS DateTime), NULL, 0, NULL, 10, 9298, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1139, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011932F5 AS DateTime), NULL, 0, NULL, 10, 9299, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1140, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0119367B AS DateTime), NULL, 0, NULL, 10, 9300, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1141, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011939CD AS DateTime), NULL, 0, NULL, 10, 9301, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1142, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đường lối CM của ĐCS Việt Nam (chưa đóng): 450000
Sức bền vật liệu (chưa đóng): 230000
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Lý thuyết tàu (chưa đóng): 300000
Tiếng Anh chuyên ngành ĐKT 1 (chưa đóng): 345000
Thực tập sỹ quan (chưa đóng): 600000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E01193DFD AS DateTime), NULL, 0, NULL, 10, 9302, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1143, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 450000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011941AF AS DateTime), NULL, 0, NULL, 10, 9303, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1144, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Cơ lý thuyết (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
La bàn từ (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011944C0 AS DateTime), NULL, 0, NULL, 10, 9304, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1145, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
La bàn từ (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0119480C AS DateTime), NULL, 0, NULL, 10, 9305, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1146, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01195234 AS DateTime), NULL, 0, NULL, 10, 9309, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1147, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Cơ lý thuyết (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01195577 AS DateTime), NULL, 0, NULL, 10, 9310, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1148, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Giải tích 1 (chưa đóng): 600000
Cơ lý thuyết (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011958F8 AS DateTime), NULL, 0, NULL, 10, 9311, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1149, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01195C47 AS DateTime), NULL, 0, NULL, 10, 9312, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1150, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tư tưởng Hồ Chí Minh (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01195FD9 AS DateTime), NULL, 0, NULL, 10, 9313, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1151, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011962F6 AS DateTime), NULL, 0, NULL, 10, 9314, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1152, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01196AA7 AS DateTime), NULL, 0, NULL, 10, 9317, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1153, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01196E01 AS DateTime), NULL, 0, NULL, 10, 9318, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1154, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Công nghệ sửa chữa tàu thuỷ 1 (chưa đóng): 600000
Điện tàu thuỷ 2 (chưa đóng): 450000
Động cơ đốt trong2 (chưa đóng): 750000
Máy phụ 2 (tiếng Anh) (chưa đóng): 450000
Trang trí hệ động lực tàu thuỷ (chưa đóng): 450000
', CAST(0x0000A26E01197394 AS DateTime), NULL, 0, NULL, 10, 9320, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1155, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01197DC0 AS DateTime), NULL, 0, NULL, 10, 9324, 0, 1)
GO
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1156, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01198516 AS DateTime), NULL, 0, NULL, 10, 9326, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1157, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Luật biển (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011990F3 AS DateTime), NULL, 0, NULL, 10, 9330, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1158, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01199446 AS DateTime), NULL, 0, NULL, 10, 9332, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1159, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Kỹ thuật bơi lội (chưa đóng): 115000
Địa văn hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E01199C50 AS DateTime), NULL, 0, NULL, 10, 9335, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1160, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
La bàn từ (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E01199FEB AS DateTime), NULL, 0, NULL, 10, 9336, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1161, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0119A30D AS DateTime), NULL, 0, NULL, 10, 9337, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1162, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Vật lý 2 (chưa đóng): 450000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0119A64A AS DateTime), NULL, 0, NULL, 10, 9338, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1163, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 450000
Cơ lý thuyết (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0119A977 AS DateTime), NULL, 0, NULL, 10, 9339, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1164, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0119ACDC AS DateTime), NULL, 0, NULL, 10, 9340, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1165, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Kết cấu bê tông cốt thép 2 (chưa đóng): 150000
TKMH Kiến trúc dân dụng (chưa đóng): 150000
TKMH Kỹ thuật thi công 2 (chưa đóng): 150000
Kết cấu Bê tông cốt thép 2 (chưa đóng): 450000
Kết cấu thép 2 (chưa đóng): 450000
Kiến trúc dân dụng (chưa đóng): 450000
Kỹ thuật thi công 2 (chưa đóng): 450000
Kỹ thuật thông gió (chưa đóng): 300000
Vật lý kiến trúc (chưa đóng): 300000
Cơ học môi trường liên tục (chưa đóng): 300000
', CAST(0x0000A26E0119B490 AS DateTime), NULL, 0, NULL, 10, 9342, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1166, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0119B7DF AS DateTime), NULL, 0, NULL, 10, 9343, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1167, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0119BD66 AS DateTime), NULL, 0, NULL, 10, 9345, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1168, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0119C0C3 AS DateTime), NULL, 0, NULL, 10, 9346, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1169, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0119C3E3 AS DateTime), NULL, 0, NULL, 10, 9347, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1170, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0119C6FC AS DateTime), NULL, 0, NULL, 10, 9348, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1171, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Kết cấu bê tông cốt thép 2 (chưa đóng): 150000
TKMH Kiến trúc dân dụng (chưa đóng): 150000
TKMH Kỹ thuật thi công 2 (chưa đóng): 150000
Kết cấu Bê tông cốt thép 2 (chưa đóng): 450000
Kết cấu thép 2 (chưa đóng): 450000
Kỹ thuật thi công 2 (chưa đóng): 450000
Kỹ thuật thông gió (chưa đóng): 300000
Vật lý kiến trúc (chưa đóng): 300000
Cơ học kết cấu 2 (chưa đóng): 450000
', CAST(0x0000A26E0119CD00 AS DateTime), NULL, 0, NULL, 10, 9351, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1172, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0119D269 AS DateTime), NULL, 0, NULL, 10, 9353, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1173, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0119D5A7 AS DateTime), NULL, 0, NULL, 10, 9354, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1174, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 450000
Cơ lý thuyết (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0119DB13 AS DateTime), NULL, 0, NULL, 10, 9356, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1175, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0119E09A AS DateTime), NULL, 0, NULL, 10, 9358, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1176, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0119E524 AS DateTime), NULL, 0, NULL, 10, 9359, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1177, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Điện tàu thuỷ (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0119EB1D AS DateTime), NULL, 0, NULL, 10, 9361, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1178, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E0119EEE6 AS DateTime), NULL, 0, NULL, 10, 9362, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1179, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 1 (chưa đóng): 450000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0119F371 AS DateTime), NULL, 0, NULL, 10, 9363, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1180, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0119F674 AS DateTime), NULL, 0, NULL, 10, 9364, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1181, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E0119F9D6 AS DateTime), NULL, 0, NULL, 10, 9365, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1182, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E0119FF57 AS DateTime), NULL, 0, NULL, 10, 9367, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1183, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
', CAST(0x0000A26E011A01E2 AS DateTime), NULL, 0, NULL, 10, 9368, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1184, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Cơ lý thuyết (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011A050E AS DateTime), NULL, 0, NULL, 10, 9369, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1185, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Cơ lý thuyết (chưa đóng): 300000
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E011A08EA AS DateTime), NULL, 0, NULL, 10, 9370, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1186, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011A0C46 AS DateTime), NULL, 0, NULL, 10, 9371, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1187, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011A119E AS DateTime), NULL, 0, NULL, 10, 9373, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1188, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011A14C3 AS DateTime), NULL, 0, NULL, 10, 9374, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1189, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011A17DF AS DateTime), NULL, 0, NULL, 10, 9375, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1190, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011A1F43 AS DateTime), NULL, 0, NULL, 10, 9377, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1191, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011A22C6 AS DateTime), NULL, 0, NULL, 10, 9378, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1192, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Giải tích 1 (chưa đóng): 600000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
La bàn từ (chưa đóng): 300000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011A2651 AS DateTime), NULL, 0, NULL, 10, 9379, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1193, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011A29C8 AS DateTime), NULL, 0, NULL, 10, 9381, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1194, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Phân tích hoạt động kinh tế KTB (chưa đóng): 150000
TKMH Quản lý và khai thác cảng (chưa đóng): 150000
Đại lý giao nhận (chưa đóng): 300000
Khai thác tàu (chưa đóng): 450000
Logistics và VTĐPT (chưa đóng): 300000
Quản lý và khai thác cảng (chưa đóng): 450000
Tổ chức lao động tiền lương (chưa đóng): 450000
Toán kinh tế trong vận tải (chưa đóng): 600000
Phân tích hoạt động kinh tế trong VTB (chưa đóng): 450000
Thị trường chứng khoán (chưa đóng): 300000
', CAST(0x0000A26E011A2FBA AS DateTime), NULL, 0, NULL, 10, 9383, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1195, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011A3617 AS DateTime), NULL, 0, NULL, 10, 9385, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1196, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Điện tàu thuỷ (chưa đóng): 300000
An toàn lao động HH (chưa đóng): 300000
Khí tượng - Hải dương (chưa đóng): 450000
La bàn từ (chưa đóng): 300000
Luật biển (chưa đóng): 300000
Tự động điều khiển tàu (chưa đóng): 450000
Kết cấu tàu (chưa đóng): 300000
', CAST(0x0000A26E011A3B48 AS DateTime), NULL, 0, NULL, 10, 9387, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1197, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011A45B2 AS DateTime), NULL, 0, NULL, 10, 9391, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1198, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Tiếng Anh chuyên ngành ĐKT 1 (chưa đóng): 345000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E011A48C9 AS DateTime), NULL, 0, NULL, 10, 9392, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1199, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011A4C58 AS DateTime), NULL, 0, NULL, 10, 9393, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1200, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011A5218 AS DateTime), NULL, 0, NULL, 10, 9395, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1201, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011A55C0 AS DateTime), NULL, 0, NULL, 10, 9396, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1202, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011A594B AS DateTime), NULL, 0, NULL, 10, 9397, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1203, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011A5CA8 AS DateTime), NULL, 0, NULL, 10, 9398, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1204, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011A600E AS DateTime), NULL, 0, NULL, 10, 9399, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1205, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011A6308 AS DateTime), NULL, 0, NULL, 10, 9400, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1206, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011A6826 AS DateTime), NULL, 0, NULL, 10, 9402, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1207, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Thực tập sỹ quan (chưa đóng): 600000
', CAST(0x0000A26E011A6E36 AS DateTime), NULL, 0, NULL, 10, 9404, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1208, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Cơ lý thuyết (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011A71CB AS DateTime), NULL, 0, NULL, 10, 9405, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1209, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011A74BD AS DateTime), NULL, 0, NULL, 10, 9406, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1210, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011A7829 AS DateTime), NULL, 0, NULL, 10, 9407, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1211, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 450000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011A7C20 AS DateTime), NULL, 0, NULL, 10, 9408, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1212, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011A7F27 AS DateTime), NULL, 0, NULL, 10, 9409, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1213, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011A827F AS DateTime), NULL, 0, NULL, 10, 9410, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1214, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011A8624 AS DateTime), NULL, 0, NULL, 10, 9411, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1215, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011A8933 AS DateTime), NULL, 0, NULL, 10, 9412, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1216, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011A916F AS DateTime), NULL, 0, NULL, 10, 9415, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1217, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Điện tàu thuỷ (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011A94CA AS DateTime), NULL, 0, NULL, 10, 9416, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1218, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011A9869 AS DateTime), NULL, 0, NULL, 10, 9417, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1219, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011A9CA3 AS DateTime), NULL, 0, NULL, 10, 9418, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1220, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Điện tàu thuỷ (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011AA519 AS DateTime), NULL, 0, NULL, 10, 9422, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1221, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011AA842 AS DateTime), NULL, 0, NULL, 10, 9423, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1222, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011AADAC AS DateTime), NULL, 0, NULL, 10, 9425, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1223, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011AB0C0 AS DateTime), NULL, 0, NULL, 10, 9426, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1224, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011AB6CF AS DateTime), NULL, 0, NULL, 10, 9428, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1225, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Vật lý 2 (chưa đóng): 450000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Luật biển (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
', CAST(0x0000A26E011ABA20 AS DateTime), NULL, 0, NULL, 10, 9429, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1226, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu (chưa đóng): 230000
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Lý thuyết tàu (chưa đóng): 230000
Tiếng Anh chuyên ngành ĐKT 1 (chưa đóng): 345000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E011AC2A6 AS DateTime), NULL, 0, NULL, 10, 9432, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1227, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011AC7C7 AS DateTime), NULL, 0, NULL, 10, 9434, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1228, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011ACB03 AS DateTime), NULL, 0, NULL, 10, 9435, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1229, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011ACE51 AS DateTime), NULL, 0, NULL, 10, 9436, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1230, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011AD181 AS DateTime), NULL, 0, NULL, 10, 9437, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1231, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Cơ lý thuyết (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011AD4C6 AS DateTime), NULL, 0, NULL, 10, 9438, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1232, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011AD849 AS DateTime), NULL, 0, NULL, 10, 9439, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1233, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011ADBE4 AS DateTime), NULL, 0, NULL, 10, 9440, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1234, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011AE1F7 AS DateTime), NULL, 0, NULL, 10, 9442, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1235, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011AE53D AS DateTime), NULL, 0, NULL, 10, 9443, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1236, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011AE89A AS DateTime), NULL, 0, NULL, 10, 9444, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1237, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011AEE13 AS DateTime), NULL, 0, NULL, 10, 9446, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1238, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E011AF39E AS DateTime), NULL, 0, NULL, 10, 9448, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1239, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E011AF720 AS DateTime), NULL, 0, NULL, 10, 9449, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1240, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011AFB06 AS DateTime), NULL, 0, NULL, 10, 9450, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1241, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 450000
Cơ lý thuyết (chưa đóng): 300000
Sức bền vật liệu (chưa đóng): 230000
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Lý thuyết tàu (chưa đóng): 230000
Toán chuyên đề (Khoa ĐKTB) (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E011B07E2 AS DateTime), NULL, 0, NULL, 10, 9454, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1242, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Cơ lý thuyết (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011B0B2F AS DateTime), NULL, 0, NULL, 10, 9455, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1243, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011B0E4C AS DateTime), NULL, 0, NULL, 10, 9456, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1244, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011B1174 AS DateTime), NULL, 0, NULL, 10, 9457, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1245, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011B14D0 AS DateTime), NULL, 0, NULL, 10, 9458, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1246, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011B1893 AS DateTime), NULL, 0, NULL, 10, 9459, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1247, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011B1FAD AS DateTime), NULL, 0, NULL, 10, 9461, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1248, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011B2319 AS DateTime), NULL, 0, NULL, 10, 9462, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1249, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011B2677 AS DateTime), NULL, 0, NULL, 10, 9463, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1250, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011B3511 AS DateTime), NULL, 0, NULL, 10, 9469, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1251, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E011B445D AS DateTime), NULL, 0, NULL, 10, 9475, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1252, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Cơ lý thuyết (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011B4B65 AS DateTime), NULL, 0, NULL, 10, 9477, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1253, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Giải tích 1 (chưa đóng): 600000
Sức bền vật liệu (chưa đóng): 230000
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E011B53B8 AS DateTime), NULL, 0, NULL, 10, 9480, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1254, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011B5C4A AS DateTime), NULL, 0, NULL, 10, 9483, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1255, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011B5FD6 AS DateTime), NULL, 0, NULL, 10, 9484, 0, 1)
GO
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1256, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu (chưa đóng): 230000
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E011B63A0 AS DateTime), NULL, 0, NULL, 10, 9485, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1257, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011B6B4E AS DateTime), NULL, 0, NULL, 10, 9488, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1258, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011B70CA AS DateTime), NULL, 0, NULL, 10, 9491, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1259, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Sức bền vật liệu (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011B7417 AS DateTime), NULL, 0, NULL, 10, 9492, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1260, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011B7753 AS DateTime), NULL, 0, NULL, 10, 9493, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1261, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Tự động điều khiển tàu (chưa đóng): 450000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011B7D9D AS DateTime), NULL, 0, NULL, 10, 9495, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1262, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E011B8128 AS DateTime), NULL, 0, NULL, 10, 9496, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1263, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011B8439 AS DateTime), NULL, 0, NULL, 10, 9497, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1264, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Cơ lý thuyết (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011B89E8 AS DateTime), NULL, 0, NULL, 10, 9499, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1265, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011B8D2E AS DateTime), NULL, 0, NULL, 10, 9500, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1266, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011B9071 AS DateTime), NULL, 0, NULL, 10, 9501, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1267, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011B95FF AS DateTime), NULL, 0, NULL, 10, 9503, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1268, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011B994F AS DateTime), NULL, 0, NULL, 10, 9504, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1269, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011B9C7C AS DateTime), NULL, 0, NULL, 10, 9505, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1270, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E011BA0BB AS DateTime), NULL, 0, NULL, 10, 9506, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1271, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Luật biển (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011BA401 AS DateTime), NULL, 0, NULL, 10, 9507, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1272, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đại số (chưa đóng): 450000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011BA974 AS DateTime), NULL, 0, NULL, 10, 9509, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1273, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tư tưởng Hồ Chí Minh (chưa đóng): 300000
Sức bền vật liệu (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Thực tập sỹ quan (chưa đóng): 600000
Toán chuyên đề (Khoa ĐKTB) (chưa đóng): 300000
', CAST(0x0000A26E011BAF5B AS DateTime), NULL, 0, NULL, 10, 9511, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1274, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011BB4E8 AS DateTime), NULL, 0, NULL, 10, 9513, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1275, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Cơ lý thuyết (chưa đóng): 300000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011BB85D AS DateTime), NULL, 0, NULL, 10, 9514, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1276, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011BBB66 AS DateTime), NULL, 0, NULL, 10, 9515, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1277, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Pháp luật hàng hải 2 (chưa đóng): 300000
', CAST(0x0000A26E011BC33F AS DateTime), NULL, 0, NULL, 10, 9518, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1278, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011BC65D AS DateTime), NULL, 0, NULL, 10, 9519, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1279, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011BC97C AS DateTime), NULL, 0, NULL, 10, 9520, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1280, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
TKMH Phân tích hoạt động kinh tế KTB (chưa đóng): 150000
TKMH Quản lý và khai thác cảng (chưa đóng): 150000
Đại lý giao nhận (chưa đóng): 300000
Khai thác tàu (chưa đóng): 450000
Logistics và VTĐPT (chưa đóng): 300000
Quản lý và khai thác cảng (chưa đóng): 450000
Tổ chức lao động tiền lương (chưa đóng): 450000
Toán kinh tế trong vận tải (chưa đóng): 600000
Phân tích hoạt động kinh tế trong VTB (chưa đóng): 450000
Pháp luật kinh tế (chưa đóng): 450000
', CAST(0x0000A26E011BCD05 AS DateTime), NULL, 0, NULL, 10, 9521, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1281, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 1 (chưa đóng): 345000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 1 (chưa đóng): 345000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
ổn định tàu (chưa đóng): 345000
Pháp luật hàng hải 1 (chưa đóng): 345000
Pháp luật hàng hải 2 (chưa đóng): 300000
Quy tắc phòng ngừa đâm va (chưa đóng): 230000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
Xử lý các tình huống KC trên biển (chưa đóng): 230000
Bảo dưỡng tàu (chưa đóng): 230000
Thực tập thủy thủ (chưa đóng): 460000
', CAST(0x0000A26E011BD052 AS DateTime), NULL, 0, NULL, 10, 9522, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1282, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Giải tích 1 (chưa đóng): 600000
Hóa đại cương (chưa đóng): 450000
TKMH máy nâng tự hành (chưa đóng): 150000
TKMH Máy vận chuyển liên tục (chưa đóng): 150000
Công nghệ chế tạo máy nâng chuyển (chưa đóng): 450000
Máy nâng tự hành (chưa đóng): 600000
Máy vận chuyển liên tục (chưa đóng): 450000
Ôtô máy kéo (chưa đóng): 300000
Quy phạm thiết kế máy và TB nâng (chưa đóng): 150000
', CAST(0x0000A26E011BD3BE AS DateTime), NULL, 0, NULL, 10, 9523, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1283, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011BD6F9 AS DateTime), NULL, 0, NULL, 10, 9524, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1284, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011BDCBD AS DateTime), NULL, 0, NULL, 10, 9526, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1285, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
', CAST(0x0000A26E011BDF9F AS DateTime), NULL, 0, NULL, 10, 9527, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1286, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011BE2BA AS DateTime), NULL, 0, NULL, 10, 9528, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1287, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Tự động điều khiển tàu (chưa đóng): 450000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011BE960 AS DateTime), NULL, 0, NULL, 10, 9530, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1288, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011BEC8F AS DateTime), NULL, 0, NULL, 10, 9531, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1289, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011BF0F7 AS DateTime), NULL, 0, NULL, 10, 9532, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1290, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011BF41B AS DateTime), NULL, 0, NULL, 10, 9533, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1291, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Tiếng Anh cơ bản 3 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Luật biển (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011BF7F5 AS DateTime), NULL, 0, NULL, 10, 9534, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1292, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011BFB52 AS DateTime), NULL, 0, NULL, 10, 9535, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1293, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
La bàn từ (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Tự động điều khiển tàu (chưa đóng): 450000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011BFE92 AS DateTime), NULL, 0, NULL, 10, 9536, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1294, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011C01C7 AS DateTime), NULL, 0, NULL, 10, 9537, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1295, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011C05A0 AS DateTime), NULL, 0, NULL, 10, 9538, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1296, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011C08DE AS DateTime), NULL, 0, NULL, 10, 9539, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1297, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011C0E3C AS DateTime), NULL, 0, NULL, 10, 9541, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1298, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011C115F AS DateTime), NULL, 0, NULL, 10, 9543, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1299, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011C1491 AS DateTime), NULL, 0, NULL, 10, 9544, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1300, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011C17BA AS DateTime), NULL, 0, NULL, 10, 9545, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1301, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Đường lối CM của ĐCS Việt Nam (chưa đóng): 450000
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011C1B60 AS DateTime), NULL, 0, NULL, 10, 9546, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1302, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011C2120 AS DateTime), NULL, 0, NULL, 10, 9548, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1303, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011C2574 AS DateTime), NULL, 0, NULL, 10, 9549, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1304, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011C28E2 AS DateTime), NULL, 0, NULL, 10, 9550, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1305, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011C7378 AS DateTime), NULL, 0, NULL, 10, 9551, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1306, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011C7FE2 AS DateTime), NULL, 0, NULL, 10, 9552, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1307, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011C8F73 AS DateTime), NULL, 0, NULL, 10, 9553, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1308, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011C9381 AS DateTime), NULL, 0, NULL, 10, 9554, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1309, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011C98DA AS DateTime), NULL, 0, NULL, 10, 9556, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1310, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011CA43C AS DateTime), NULL, 0, NULL, 10, 9558, 0, 1)
INSERT [dbo].[tbl_inbox] ([ID], [Title], [Contents], [PostDate], [Ma_sv], [Status], [ID_nguoi_tra_loi], [From], [To], [Type], [Warning]) VALUES (1311, N'Cảnh báo học phí', N'Các lớp học phần còn nợ học phí: 
Địa văn hàng hải 2 (chưa đóng): 450000
Điều động tàu 1 (chưa đóng): 300000
Máy điện hàng hải 1 (chưa đóng): 450000
Máy vô tuyến điện hàng hải 2 (chưa đóng): 450000
Pháp luật hàng hải 2 (chưa đóng): 300000
Thiên văn hàng hải 1 (chưa đóng): 300000
Xếp dỡ và vận chuyển hàng hoá 1 (chưa đóng): 450000
', CAST(0x0000A26E011CA8E1 AS DateTime), NULL, 0, NULL, 10, 9559, 0, 1)
SET IDENTITY_INSERT [dbo].[tbl_inbox] OFF
SET IDENTITY_INSERT [dbo].[tbl_news] ON 

INSERT [dbo].[tbl_news] ([Id], [Title], [Description], [Contents], [ImageUrl], [PostDate], [TotalView], [Type], [UserId], [LastEditUserId], [LastEditDate]) VALUES (92, N'Đăng ký học đợt 1 - học kỳ 1 - 2013 - 2014', N'Phòng đào tạo', N'', NULL, CAST(0xA2500296 AS SmallDateTime), 0, NULL, 1, 3, CAST(0x0000A25901038F92 AS DateTime))
INSERT [dbo].[tbl_news] ([Id], [Title], [Description], [Contents], [ImageUrl], [PostDate], [TotalView], [Type], [UserId], [LastEditUserId], [LastEditDate]) VALUES (104, N'V/v đóng học phí học kỳ I năm học 2013-2014', N'Nothing', N'abc', NULL, CAST(0xA25302A6 AS SmallDateTime), 0, NULL, 3, 3, CAST(0x0000A25300BA1962 AS DateTime))
INSERT [dbo].[tbl_news] ([Id], [Title], [Description], [Contents], [ImageUrl], [PostDate], [TotalView], [Type], [UserId], [LastEditUserId], [LastEditDate]) VALUES (122, N'V/v tổ chức giải bóng đá nữ', N'sdvd', N'dsvd', NULL, CAST(0xA2580408 AS SmallDateTime), 0, NULL, 3, 3, CAST(0x0000A258011B65C9 AS DateTime))
INSERT [dbo].[tbl_news] ([Id], [Title], [Description], [Contents], [ImageUrl], [PostDate], [TotalView], [Type], [UserId], [LastEditUserId], [LastEditDate]) VALUES (128, N'Đón tiếp và làm việc với Đoàn công tác Bộ Giao thông Công chính Campuchia.', N'Ngày 16/10, ông Nguyễn Bá Thanh - Trưởng Ban Nội chính TƯ - có buổi làm việc với Thường trực Ban Chỉ đạo Tây Nam Bộ về tình hình kinh tế, quốc phòng 9 tháng đầu năm. Ông Thanh đề nghị tập trung giải quyết các “điểm nóng” về đất đai.', N'<div>
    <div>
            <div>
                    <img title="Image: http://vimaru.edu.vn/sites/default/files/imagecache/hinh_minh_hoa_tin_tuc/5_40.jpg" src="http://vimaru.edu.vn/sites/default/files/imagecache/hinh_minh_hoa_tin_tuc/5_40.jpg" alt="" height="353" width="530">                    <div>
          	          </div>
                  </div>
        </div>
</div>
&nbsp;10h30 ngày 13/10/2013 PGS.TS Lương Công Nhớ- Hiệu trưởng Nhà trường 
đã có buổi tiếp và làm việc với Đoàn công tác Bộ Giao thông Công chính 
Campuchia do Ông H.E. Mr.&nbsp;Sokhom Pheakavanmony-&nbsp;Quốc vụ khanh dẫn đầu.
<div><img src="http://vimaru.edu.vn/sites/default/files/4_46.jpg" alt="" height="333" width="500"><br>
Trong chuyến thăm Trường ĐHHH Việt Nam lần này, Đoàn công tác Bộ Giao 
thông Công chính Campuchia muốn tìm hiểu cơ hội hợp tác với Nhà trường 
trong việc đào tạo, huấn luyện sinh viên Đại học và Sau đại học.<br>
<img src="http://vimaru.edu.vn/sites/default/files/1_61.jpg" alt="" height="333" width="500"></div>
<div>Mr.&nbsp;Sokhom Pheakavanmony, cảm ơn sự đón tiếp nồng hậu của Nhà 
trường và hy vọng Trường Đại học Hàng hải Việt Nam có những chính sách 
hỗ trợ cho du học sinh Campuchia đặc biệt là trong việc đào tạo sau đại 
học.</div>
<div>PGS. TS. Lương Công Nhớ, Hiệu trưởng cho biết hiện đã có 02 sinh 
viên Campuchia theo học, Nhà trường sẵn sàng hỗ trợ và tạo điều kiện cho
 các sinh viên, học viên Campuchia theo học</div>
<div>&nbsp;<img src="http://vimaru.edu.vn/sites/default/files/2_54.jpg" alt="" height="333" width="500">
<img src="http://vimaru.edu.vn/sites/default/files/3_52.jpg" alt="" height="333" width="500"></div><br>', NULL, CAST(0xA25903D1 AS SmallDateTime), 0, NULL, 1, 1, CAST(0x0000A2590110CB8C AS DateTime))
INSERT [dbo].[tbl_news] ([Id], [Title], [Description], [Contents], [ImageUrl], [PostDate], [TotalView], [Type], [UserId], [LastEditUserId], [LastEditDate]) VALUES (134, N'Lịch bảo vệ tốt nghiệp đợt II khóa 49 Khoa CNTT', N'Công văn từ Phòng đào tạo', N'Lịch bảo vệ :<br>&amp;h30'' sáng 17/10/2013<br>', NULL, CAST(0xA25A0133 AS SmallDateTime), 0, NULL, 3, 3, CAST(0x0000A25A0054571C AS DateTime))
SET IDENTITY_INSERT [dbo].[tbl_news] OFF
ALTER TABLE [dbo].[tbl_inbox] ADD  CONSTRAINT [DF_tbl_inbox_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[tbl_inbox] ADD  CONSTRAINT [DF_tbl_inbox_Warning]  DEFAULT ((0)) FOR [Warning]
GO
ALTER TABLE [dbo].[tbl_news] ADD  CONSTRAINT [DF_tbl_news_TotalView]  DEFAULT ((0)) FOR [TotalView]
GO
