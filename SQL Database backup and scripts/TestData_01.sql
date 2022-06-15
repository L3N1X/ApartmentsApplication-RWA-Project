USE [RwaApartmani]
GO
SET IDENTITY_INSERT [dbo].[ApartmentStatus] ON 
GO
INSERT [dbo].[ApartmentStatus] ([Id], [Guid], [Name], [NameEng]) VALUES (1, N'9ced816e-c189-419d-a20b-3eafc71beb61', N'Zauzeto', N'Occupied')
GO
INSERT [dbo].[ApartmentStatus] ([Id], [Guid], [Name], [NameEng]) VALUES (2, N'5a9fe397-ed1a-464e-b423-0ae1a25494f3', N'Rezervirano', N'Reserved')
GO
INSERT [dbo].[ApartmentStatus] ([Id], [Guid], [Name], [NameEng]) VALUES (3, N'0cce449e-a340-4fae-b585-b1203598a9c5', N'Slobodno', N'Vacant')
GO
SET IDENTITY_INSERT [dbo].[ApartmentStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Apartment] ON 
GO
INSERT [dbo].[Apartment] ([Id], [Guid], [CreatedAt], [DeletedAt], [OwnerId], [TypeId], [StatusId], [CityId], [Address], [Name], [NameEng], [Price], [MaxAdults], [MaxChildren], [TotalRooms], [BeachDistance]) VALUES (1, N'accca4cb-b351-4605-8606-b134e814075d', CAST(N'2022-04-11T12:20:41.4916121' AS DateTime2), NULL, 1, 999, 3, 53, N'Opatijska 123a', N'Plavi Biser', N'Blue pearl', 180.0000, 2, 2, 4, 50)
GO
INSERT [dbo].[Apartment] ([Id], [Guid], [CreatedAt], [DeletedAt], [OwnerId], [TypeId], [StatusId], [CityId], [Address], [Name], [NameEng], [Price], [MaxAdults], [MaxChildren], [TotalRooms], [BeachDistance]) VALUES (2, N'd1d583b4-c4c4-4c7b-82b3-ec44e76d461c', CAST(N'2022-04-11T12:25:15.9502916' AS DateTime2), NULL, 1, 999, 2, 5, N'Zadarska 23a', N'Zeleni Biser', N'Green pearl', 225.0000, 3, 4, 5, 200)
GO
INSERT [dbo].[Apartment] ([Id], [Guid], [CreatedAt], [DeletedAt], [OwnerId], [TypeId], [StatusId], [CityId], [Address], [Name], [NameEng], [Price], [MaxAdults], [MaxChildren], [TotalRooms], [BeachDistance]) VALUES (3, N'fdeea433-87bd-4825-9f93-08c7534145e1', CAST(N'2022-04-11T12:25:15.9502916' AS DateTime2), NULL, 1, 999, 2, 5, N'Omiška 3a', N'Bijeli Biser', N'White pearl', 150.0000, 4, 0, 3, 170)
GO
SET IDENTITY_INSERT [dbo].[Apartment] OFF
GO
SET IDENTITY_INSERT [dbo].[ApartmentReservation] ON 
GO
INSERT [dbo].[ApartmentReservation] ([Id], [Guid], [CreatedAt], [ApartmentId], [Details], [UserId], [UserName], [UserEmail], [UserPhone], [UserAddress]) VALUES (1, N'40d98373-0e0e-4f9d-ba91-51cc3b57d9ef', CAST(N'2022-04-11T12:26:29.2449772' AS DateTime2), 1, N'27.6.2022.-19.6.2022.', 7, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ApartmentReservation] ([Id], [Guid], [CreatedAt], [ApartmentId], [Details], [UserId], [UserName], [UserEmail], [UserPhone], [UserAddress]) VALUES (2, N'663c146e-fbcc-4550-bcf8-6c258381707d', CAST(N'2022-04-11T12:26:47.0390615' AS DateTime2), 2, N'Prvi tjedan u kolovozu; javiti se prije', 15, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ApartmentReservation] ([Id], [Guid], [CreatedAt], [ApartmentId], [Details], [UserId], [UserName], [UserEmail], [UserPhone], [UserAddress]) VALUES (3, N'695d6e78-ee34-4a71-94d7-d06e1489e00a', CAST(N'2022-04-11T12:30:37.6977100' AS DateTime2), 3, N'13.6.2022.-08.7.2022.', NULL, N'Barbara', N'Mišković', N'0987654321          ', N'Mornara 59c, Virovitica')
GO
INSERT [dbo].[ApartmentReservation] ([Id], [Guid], [CreatedAt], [ApartmentId], [Details], [UserId], [UserName], [UserEmail], [UserPhone], [UserAddress]) VALUES (5, N'ea9b11d2-cf84-4f41-8e0b-2e7753874be6', CAST(N'2022-04-11T12:35:35.0437544' AS DateTime2), 3, N'8.7.2022.-9.7.2022.', 3, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[ApartmentReservation] OFF
GO
SET IDENTITY_INSERT [dbo].[ApartmentPicture] ON 
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (2, N'd33cde78-b19b-478d-99b8-037936b4a64c', CAST(N'2022-04-11T12:43:43.2234512' AS DateTime2), NULL, 1, N'ACCCA4CB-B351-4605-8606-B134E814075D/img1.png', NULL, N'Glavna', 1)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (4, N'3f46f64c-605e-4b4c-9292-683ae3984091', CAST(N'2022-04-11T12:44:02.1536099' AS DateTime2), NULL, 1, N'ACCCA4CB-B351-4605-8606-B134E814075D/img1.png', NULL, N'Terasa', 0)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (5, N'31294e1f-b813-4dcb-92f4-5180d22b55f0', CAST(N'2022-04-11T12:47:20.0590965' AS DateTime2), NULL, 1, N'ACCCA4CB-B351-4605-8606-B134E814075D/img3.png', NULL, N'Interijer', 0)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (6, N'8c4199f1-7681-4772-a1ab-4218488688d4', CAST(N'2022-04-11T12:47:20.0590965' AS DateTime2), NULL, 1, N'ACCCA4CB-B351-4605-8606-B134E814075D/img4.png', NULL, N'Interijer', 0)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (7, N'e164317c-2fec-408c-8ce5-8e0bfef8d041', CAST(N'2022-04-11T12:47:20.0590965' AS DateTime2), NULL, 1, N'ACCCA4CB-B351-4605-8606-B134E814075D/img5.png', NULL, N'Interijer', 0)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (8, N'11e01c91-dbfb-43f2-b77a-087725b3f8c2', CAST(N'2022-04-11T12:47:20.0590965' AS DateTime2), NULL, 1, N'ACCCA4CB-B351-4605-8606-B134E814075D/img6.png', NULL, N'Interijer', 0)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (9, N'f7b0cbca-5b24-482b-9482-6672546904bd', CAST(N'2022-04-11T12:47:20.0590965' AS DateTime2), NULL, 1, N'ACCCA4CB-B351-4605-8606-B134E814075D/img7.png', NULL, N'Tuš kada', 0)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (10, N'a30aaab8-408d-42f5-9771-0c37673e0fb9', CAST(N'2022-04-11T12:47:20.0590965' AS DateTime2), NULL, 1, N'ACCCA4CB-B351-4605-8606-B134E814075D/img8.png', NULL, N'Kupaonica', 0)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (11, N'eeb17e09-39f2-4854-b289-9e06e51b503c', CAST(N'2022-04-11T12:47:20.0590965' AS DateTime2), NULL, 1, N'ACCCA4CB-B351-4605-8606-B134E814075D/img9.png', NULL, N'Kupaonica', 0)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (12, N'f8ec97d4-9e94-408d-a46d-971cbd50a980', CAST(N'2022-04-11T12:47:20.0590965' AS DateTime2), NULL, 1, N'ACCCA4CB-B351-4605-8606-B134E814075D/img10.png', NULL, N'Hodnik', 0)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (13, N'c2134ba6-3bab-4e02-b7b3-2b196a20ee33', CAST(N'2022-04-11T12:47:20.0590965' AS DateTime2), NULL, 1, N'ACCCA4CB-B351-4605-8606-B134E814075D/img11.png', NULL, N'Terasa', 0)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (14, N'05ca4f98-b5ce-4477-996f-d936d299c259', CAST(N'2022-04-11T12:47:20.0590965' AS DateTime2), NULL, 1, N'ACCCA4CB-B351-4605-8606-B134E814075D/img12.png', NULL, N'Plaža', 0)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (15, N'1f99fa36-8865-49d1-8edc-9a8c4a7ebe68', CAST(N'2022-04-11T12:47:20.0590965' AS DateTime2), NULL, 1, N'ACCCA4CB-B351-4605-8606-B134E814075D/img13.png', NULL, N'Plaža', 0)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (16, N'90d05427-3f84-43c1-9736-a2f9cc4f246f', CAST(N'2022-04-11T12:48:25.8207661' AS DateTime2), NULL, 2, N'D1D583B4-C4C4-4C7B-82B3-EC44E76D461C/img1.png', NULL, N'', 0)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (17, N'6aae0268-bbff-41a5-bdf6-e0b042a071e3', CAST(N'2022-04-11T12:48:25.8207661' AS DateTime2), NULL, 2, N'D1D583B4-C4C4-4C7B-82B3-EC44E76D461C/img2.png', NULL, N'', 0)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (18, N'3cc42a12-800c-45cb-bb3d-60a5d86e6305', CAST(N'2022-04-11T12:53:31.8544660' AS DateTime2), NULL, 3, N'FDEEA433-87BD-4825-9F93-08C7534145E1/more.png', NULL, N'Kupanac', 1)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (19, N'd0bee389-5970-4258-a532-e3ee7b72ca7d', CAST(N'2022-04-11T12:53:31.8544660' AS DateTime2), NULL, 3, N'FDEEA433-87BD-4825-9F93-08C7534145E1/more_a.png', NULL, N'', 0)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (20, N'a7638ec7-9e92-4e8e-849b-fc97f09a4c89', CAST(N'2022-04-11T12:53:31.8544660' AS DateTime2), NULL, 3, N'FDEEA433-87BD-4825-9F93-08C7534145E1/more_b.png', NULL, N'', 0)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (21, N'026fbf56-787d-42d8-b067-6a5ded388c83', CAST(N'2022-04-11T12:53:31.8544660' AS DateTime2), NULL, 3, N'FDEEA433-87BD-4825-9F93-08C7534145E1/ulaz.png', NULL, N'Ulaz', 0)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (22, N'7365dbb9-43df-4e27-839b-ecee4a8dadfb', CAST(N'2022-04-11T12:53:31.8544660' AS DateTime2), NULL, 3, N'FDEEA433-87BD-4825-9F93-08C7534145E1/predsoblje.png', NULL, N'Predsoblje', 0)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (23, N'42258c7e-de09-45e4-9751-dbdd7f75e435', CAST(N'2022-04-11T12:53:31.8544660' AS DateTime2), NULL, 3, N'FDEEA433-87BD-4825-9F93-08C7534145E1/ormari.png', NULL, N'Dnevna soba', 0)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (24, N'61f9588e-3d62-4af8-a412-3536278fdf06', CAST(N'2022-04-11T12:53:31.8544660' AS DateTime2), NULL, 3, N'FDEEA433-87BD-4825-9F93-08C7534145E1/telka.png', NULL, N'Dnevna soba', 0)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (25, N'cf1bcca1-b890-4f90-94b4-2342622f88c9', CAST(N'2022-04-11T12:53:31.8544660' AS DateTime2), NULL, 3, N'FDEEA433-87BD-4825-9F93-08C7534145E1/telka2.png', NULL, N'Dnevna soba', 0)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (26, N'2d50bc81-ceb1-4255-84fd-7aafd6349ce9', CAST(N'2022-04-11T12:53:31.8544660' AS DateTime2), NULL, 3, N'FDEEA433-87BD-4825-9F93-08C7534145E1/spavaca1_1.png', NULL, N'Spavaća soba 1', 0)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (27, N'59d182f5-38f0-43f9-9f3f-2cd595822c7d', CAST(N'2022-04-11T12:53:31.8544660' AS DateTime2), NULL, 3, N'FDEEA433-87BD-4825-9F93-08C7534145E1/spavaca1_2.png', NULL, N'', 0)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (28, N'4c22b8a6-e213-4a54-a79f-da529c643c02', CAST(N'2022-04-11T12:53:31.8544660' AS DateTime2), NULL, 3, N'FDEEA433-87BD-4825-9F93-08C7534145E1/spavaca1_3.png', NULL, N'', 0)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (29, N'46532854-8330-43bf-b32e-4852b6249711', CAST(N'2022-04-11T12:53:31.8544660' AS DateTime2), NULL, 3, N'FDEEA433-87BD-4825-9F93-08C7534145E1/spavaca2_1.png', NULL, N'Spavaća soba 2', 0)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (30, N'330ba3a9-2492-4580-ba80-4a4ac18b508c', CAST(N'2022-04-11T12:53:31.8544660' AS DateTime2), NULL, 3, N'FDEEA433-87BD-4825-9F93-08C7534145E1/spavaca2_1a.png', NULL, N'', 0)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (31, N'61a5fcc7-4919-40e5-9044-b9210d35b099', CAST(N'2022-04-11T12:53:31.8544660' AS DateTime2), NULL, 3, N'FDEEA433-87BD-4825-9F93-08C7534145E1/spavaca2_2.png', NULL, N'', 0)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (32, N'6d87461a-6836-459e-8aab-e7850f0416d4', CAST(N'2022-04-11T12:53:31.8544660' AS DateTime2), NULL, 3, N'FDEEA433-87BD-4825-9F93-08C7534145E1/spavaca2_5.png', NULL, N'', 0)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (33, N'4fad7681-05db-4ecd-96df-055a24e0fc45', CAST(N'2022-04-11T12:53:31.8544660' AS DateTime2), NULL, 3, N'FDEEA433-87BD-4825-9F93-08C7534145E1/kuhinjica.png', NULL, N'Kuhinja', 0)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (34, N'ef31f15c-5a8a-4ebf-8b7f-156365852016', CAST(N'2022-04-11T12:53:31.8544660' AS DateTime2), NULL, 3, N'FDEEA433-87BD-4825-9F93-08C7534145E1/izvana_1.png', NULL, N'Ispred apartmana', 0)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (35, N'bf02956c-fa1f-4beb-a13e-74daaf930180', CAST(N'2022-04-11T12:53:31.8544660' AS DateTime2), NULL, 3, N'FDEEA433-87BD-4825-9F93-08C7534145E1/izvana_2.png', NULL, N'', 0)
GO
INSERT [dbo].[ApartmentPicture] ([Id], [Guid], [CreatedAt], [DeletedAt], [ApartmentId], [Path], [Base64Content], [Name], [IsRepresentative]) VALUES (36, N'0198570c-8e45-4d3b-879c-d050e70b47f6', CAST(N'2022-04-11T12:53:31.8544660' AS DateTime2), NULL, 3, N'FDEEA433-87BD-4825-9F93-08C7534145E1/izvana_3.png', NULL, N'', 0)
GO
SET IDENTITY_INSERT [dbo].[ApartmentPicture] OFF
GO
SET IDENTITY_INSERT [dbo].[ApartmentReview] ON 
GO
INSERT [dbo].[ApartmentReview] ([Id], [Guid], [CreatedAt], [ApartmentId], [UserId], [Details], [Stars]) VALUES (1, N'6e09f26d-da25-474b-a265-1e7da0c08362', CAST(N'2022-04-11T12:35:58.0014417' AS DateTime2), 1, 4, NULL, 5)
GO
INSERT [dbo].[ApartmentReview] ([Id], [Guid], [CreatedAt], [ApartmentId], [UserId], [Details], [Stars]) VALUES (2, N'52c522fc-fa83-43ab-9fde-5e3d57b42bda', CAST(N'2022-04-11T12:36:33.7010567' AS DateTime2), 2, 1, N'Odlično mjesto za odmor!', 5)
GO
INSERT [dbo].[ApartmentReview] ([Id], [Guid], [CreatedAt], [ApartmentId], [UserId], [Details], [Stars]) VALUES (3, N'90056e6e-cecf-468e-94ca-32a677d0c886', CAST(N'2022-04-11T12:37:50.8954864' AS DateTime2), 1, 11, N'Nice place for children, but little dull for parents. Some night life would do better.', 4)
GO
INSERT [dbo].[ApartmentReview] ([Id], [Guid], [CreatedAt], [ApartmentId], [UserId], [Details], [Stars]) VALUES (6, N'fabf05a3-bcf3-4f03-bed3-efba4880c79a', CAST(N'2022-04-11T12:38:52.0942991' AS DateTime2), 3, 14, N'Za te pare moglo bi i bolje...', 3)
GO
INSERT [dbo].[ApartmentReview] ([Id], [Guid], [CreatedAt], [ApartmentId], [UserId], [Details], [Stars]) VALUES (7, N'd8efb9d8-c38f-490c-ace8-bff12f68d585', CAST(N'2022-04-11T12:39:19.1457666' AS DateTime2), 3, 2, NULL, 5)
GO
SET IDENTITY_INSERT [dbo].[ApartmentReview] OFF
GO
SET IDENTITY_INSERT [dbo].[TaggedApartment] ON 
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (1, N'eb3fe92c-e925-445c-a0c1-293b985b1122', 1, 38)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (2, N'7187c76f-d11f-409b-bce9-ac4c039340ba', 1, 35)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (3, N'c337dfa2-10cd-464b-a64f-04d48e5f099b', 1, 46)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (4, N'b95071cb-b8db-4059-bbbc-91c3f6bad5c0', 1, 39)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (5, N'1bfaca69-5df5-4dc0-bb70-e96a4bdb3a6b', 1, 22)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (6, N'514cd996-8158-4543-a0a3-61e9d5a0ed42', 1, 32)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (7, N'87ab0c07-e74e-4291-9f3b-94edf93e6b18', 1, 18)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (8, N'a0e177b9-8f07-4a3d-803c-4838b7869d08', 1, 9)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (34, N'6f925ad5-2050-49ad-b487-a2aa3db22a40', 2, 14)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (35, N'db2d1818-60cf-478e-bf27-e034b0d9cff4', 2, 19)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (36, N'826b3de8-fcc3-45f8-9b85-83cbec3aef9b', 2, 22)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (38, N'b7f3c307-9cd7-43a4-af8b-9fc133e5654e', 2, 45)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (39, N'bbf02a60-6552-4de4-93f1-076a89eb7756', 2, 4)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (40, N'5ee92ce8-8708-4418-9c8d-db38c3d1c700', 2, 47)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (42, N'15a971ed-274b-4afd-9ce3-60a73adcc7bd', 2, 9)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (44, N'714fbf92-c74f-4010-bf46-a1b7c01a1eda', 2, 37)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (45, N'24ca28fb-7558-4faa-96df-bf19996634f6', 2, 43)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (46, N'db391257-7c05-4992-a613-7a09cb254f26', 2, 18)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (47, N'949f4966-5db2-4509-aa1a-4871d7509130', 2, 46)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (48, N'06b39737-9645-4d4c-ad5c-8938abb8c63d', 3, 10)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (50, N'1d62475a-9a98-486e-b10a-b3fc814cffc4', 3, 35)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (51, N'539f9e28-469e-4d3d-81c4-8f34dc08d22f', 3, 14)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (52, N'6e7c83f2-167c-4266-ad30-14a9a79bef1a', 3, 32)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (53, N'54181f4b-1d18-4363-b80e-118a85f6f785', 3, 28)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (54, N'122d6c04-3163-463d-a32b-fde6f50ace36', 3, 20)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (56, N'522a0746-8066-4630-a7b8-7fcdd8a9cf97', 3, 38)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (57, N'2d2a46ab-00d2-4fa2-9c17-bd94a99ec9d1', 3, 46)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (58, N'e5b27ee6-8828-495c-8fcd-56fc0ebb08f0', 3, 13)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (60, N'32bec107-f9a2-47fa-a339-4968a5dbce3a', 3, 27)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (61, N'd7172fb4-cea6-4cf6-9f38-87f92dfc340e', 3, 11)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (63, N'b99034ea-7943-4488-bad9-9a23a70bc368', 3, 15)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (64, N'ecf67aec-af65-465e-a24c-eeaf2e6ec66d', 3, 30)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (65, N'19eee4ba-0ca7-4943-a36b-a2309c72762b', 3, 40)
GO
INSERT [dbo].[TaggedApartment] ([Id], [Guid], [ApartmentId], [TagId]) VALUES (66, N'2578d4f6-0cd8-40b2-b01c-0ba9e04d8bdc', 3, 43)
GO
SET IDENTITY_INSERT [dbo].[TaggedApartment] OFF
GO
CREATE PROC LoadAparmentsByTagID
	@tagID INT
AS
BEGIN
	SELECT A.Name FROM Tag AS T INNER JOIN TaggedApartment AS TA ON T.Id = TA.TagId INNER JOIN Apartment AS A ON TA.ApartmentId=A.Id WHERE T.Id=@tagID 
END
GO
CREATE PROC LoadTags
AS
BEGIN
	SELECT * FROM Tag
END
GO