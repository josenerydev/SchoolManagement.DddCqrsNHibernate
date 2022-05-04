USE [SchoolDb]

INSERT [dbo].[Ids] ([EntityName], [NextHigh]) VALUES (N'Course', 1)
INSERT [dbo].[Ids] ([EntityName], [NextHigh]) VALUES (N'Student', 1)
INSERT [dbo].[Ids] ([EntityName], [NextHigh]) VALUES (N'Enrollment', 1)
INSERT [dbo].[Ids] ([EntityName], [NextHigh]) VALUES (N'Suffix', 1)

INSERT [dbo].[Course] ([CourseID], [Name]) VALUES (1, N'Calculus')
INSERT [dbo].[Course] ([CourseID], [Name]) VALUES (2, N'Chemistry')
INSERT [dbo].[Course] ([CourseID], [Name]) VALUES (3, N'Literature')
INSERT [dbo].[Course] ([CourseID], [Name]) VALUES (4, N'Trigonometry')
INSERT [dbo].[Course] ([CourseID], [Name]) VALUES (5, N'Microeconomics')

INSERT [dbo].[Suffix] ([SuffixID], [Name]) VALUES (1, N'Jr')
INSERT [dbo].[Suffix] ([SuffixID], [Name]) VALUES (2, N'Sr')

INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [Email], [NameSuffixID], [FavoriteCourseID]) VALUES (1, N'Alice', N'Aliceson', N'alice@gmail.com', 1, 2)
INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [Email], [NameSuffixID], [FavoriteCourseID]) VALUES (2, N'Bob', N'Bobson', N'bob@outlook.com', 2, 2)