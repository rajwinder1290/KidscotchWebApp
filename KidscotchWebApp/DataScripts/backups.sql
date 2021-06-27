INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'f05bcddd-4c85-4db1-a602-a8ea5fb2fbed', N'admin', N'admin', N'f295da6e-8b27-44d4-b46d-725e2dd3dabc')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'b3252371-83ef-4086-8dc3-017cb28670ca', N'user@gmail.com', N'USER@GMAIL.COM', N'user@gmail.com', N'USER@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEDqLfx2obzmLz5uyeASKjlko2oauQx/iAWovj6QWSyxWn/Nl7sq0WJC/mQZoNW1bHA==', N'YYLR2EAVTLQZV4ESEQ5WCBLA7BOSX3U6', N'4bd45a31-a1ef-42d3-a6df-d3bfbf0ed8e8', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'c6d79027-f8d5-4e00-a9b0-b9800263e01b', N'admin@gmail.com', N'ADMIN@GMAIL.COM', N'admin@gmail.com', N'ADMIN@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEGjQm35a4mUwtIU5N7s4PebmI2TG5Kh2C1UXTAzRusPG0g1/b2jjzsT2DlOw+Vfcyg==', N'FBJMIMI5THUIZJWS43BFHHIJGCMRRCKZ', N'f6e577ca-3207-4cd0-af55-301fce6e09ce', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c6d79027-f8d5-4e00-a9b0-b9800263e01b', N'f05bcddd-4c85-4db1-a602-a8ea5fb2fbed')
GO
SET IDENTITY_INSERT [dbo].[CartInfos] ON 
GO
INSERT [dbo].[CartInfos] ([CartID], [UserID], [CartDate], [CartStatus], [OrderDate], [Address], [ContactNo]) VALUES (1, N'user@gmail.com', CAST(N'2021-06-26T13:39:40.0000000' AS DateTime2), N'Order', CAST(N'2021-06-26T13:40:42.2622804' AS DateTime2), N'165  Walker Road, West Brook, Rotorua', N'(028) 6069-100')
GO
INSERT [dbo].[CartInfos] ([CartID], [UserID], [CartDate], [CartStatus], [OrderDate], [Address], [ContactNo]) VALUES (2, N'user@gmail.com', CAST(N'2021-06-26T13:41:02.0000000' AS DateTime2), N'Order', CAST(N'2021-06-26T13:41:32.4807127' AS DateTime2), N'160  Clifford Square, Rimutaka Hill', N'(029) 4215-150')
GO
SET IDENTITY_INSERT [dbo].[CartInfos] OFF
GO
SET IDENTITY_INSERT [dbo].[ClothCompanies] ON 
GO
INSERT [dbo].[ClothCompanies] ([ClothCompanyID], [ClothCompanyName], [About]) VALUES (1, N'Gini & Jony', N'Gini & Jony')
GO
INSERT [dbo].[ClothCompanies] ([ClothCompanyID], [ClothCompanyName], [About]) VALUES (2, N'Liliput', N'Liliput')
GO
INSERT [dbo].[ClothCompanies] ([ClothCompanyID], [ClothCompanyName], [About]) VALUES (3, N'Cucumber', N'Cucumber')
GO
INSERT [dbo].[ClothCompanies] ([ClothCompanyID], [ClothCompanyName], [About]) VALUES (4, N'Nino Bambino', N'Nino Bambino')
GO
INSERT [dbo].[ClothCompanies] ([ClothCompanyID], [ClothCompanyName], [About]) VALUES (5, N'Mothercare', N'Mothercare')
GO
INSERT [dbo].[ClothCompanies] ([ClothCompanyID], [ClothCompanyName], [About]) VALUES (6, N'Little Kangaroos', N'Little Kangaroos')
GO
INSERT [dbo].[ClothCompanies] ([ClothCompanyID], [ClothCompanyName], [About]) VALUES (7, N'Allen Solly Junior', N'Allen Solly Junior')
GO
INSERT [dbo].[ClothCompanies] ([ClothCompanyID], [ClothCompanyName], [About]) VALUES (8, N'Berrytree', N'Berrytree')
GO
INSERT [dbo].[ClothCompanies] ([ClothCompanyID], [ClothCompanyName], [About]) VALUES (9, N'Levis Kids', N'Levis Kids')
GO
INSERT [dbo].[ClothCompanies] ([ClothCompanyID], [ClothCompanyName], [About]) VALUES (10, N'Luke and Lilly', N'Luke and Lilly')
GO
SET IDENTITY_INSERT [dbo].[ClothCompanies] OFF
GO
SET IDENTITY_INSERT [dbo].[ShopCategories] ON 
GO
INSERT [dbo].[ShopCategories] ([ShopCategoryID], [ShopCategoryName]) VALUES (1, N'Girl')
GO
INSERT [dbo].[ShopCategories] ([ShopCategoryID], [ShopCategoryName]) VALUES (2, N'Boy')
GO
INSERT [dbo].[ShopCategories] ([ShopCategoryID], [ShopCategoryName]) VALUES (3, N'Sale')
GO
INSERT [dbo].[ShopCategories] ([ShopCategoryID], [ShopCategoryName]) VALUES (4, N'Daily Care')
GO
INSERT [dbo].[ShopCategories] ([ShopCategoryID], [ShopCategoryName]) VALUES (5, N'Toys')
GO
SET IDENTITY_INSERT [dbo].[ShopCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[ClothInfos] ON 
GO
INSERT [dbo].[ClothInfos] ([ClothInfoID], [Name], [ClothPrice], [SizeChart], [Feature], [ShopCategoryID], [ClothCompanyID], [Extension]) VALUES (1, N'Orange Short Sleeves All Over Printed Rompers', 78, N'0-3 Months, 3-6 Months, 6-9 Months, 9-12 Months', N'FEATURES:
Material: 95% Cotton and 5% Spandex
The actual product may differ slightly in color from the one illustrated in the images.
WHAT''S INCLUDED:
1 Romper
CARE:
Gentle Wash
Suitable for
Unisex
Colour
Orange', 1, 1, N'.PNG')
GO
INSERT [dbo].[ClothInfos] ([ClothInfoID], [Name], [ClothPrice], [SizeChart], [Feature], [ShopCategoryID], [ClothCompanyID], [Extension]) VALUES (2, N'Black Half Sleeves Applique Animal Printed Onesies, Pants and Headband', 90, N'0-3 Months, 3-6 Months, 6-9 Months, 9-12 Months', N'FEATURES:
Material: 95%Cotton and 5%Spandex
The actual product may differ slightly in color from the one illustrated in the images..
WHAT''S INCLUDED:
1 Onesies, 1 Pants, 1 Headband ,1 Shoes
CARE:
Gentle Wash
Suitable for
Girl''s
Colour
Black', 1, 3, N'.PNG')
GO
INSERT [dbo].[ClothInfos] ([ClothInfoID], [Name], [ClothPrice], [SizeChart], [Feature], [ShopCategoryID], [ClothCompanyID], [Extension]) VALUES (3, N'Bumzee Red Half Sleeves T-Shirt Pack Of 3', 48, N'3-6 Months, 6-12 Months, 1-1.5 years, 1.5-2 years', N'FEATURES:
Material: Cotton
The actual product may differ slightly in color from the one illustrated in the images.
WHAT''S INCLUDED:
3Tees
CARE:
Gentle Wash
Suitable for
Boy''s
Colour
Red', 2, 4, N'.PNG')
GO
INSERT [dbo].[ClothInfos] ([ClothInfoID], [Name], [ClothPrice], [SizeChart], [Feature], [ShopCategoryID], [ClothCompanyID], [Extension]) VALUES (4, N'Red Half Sleeves T-Shirt Pack Of 3_14', 49.9, N'3-6 Months, 6-12 Months, 1-1.5 years, 1.5-2 years', N'FEATURES:
Material: Cotton
The actual product may differ slightly in color from the one illustrated in the images.
WHAT''S INCLUDED:
3 Tees
CARE:
Gentle Wash
Suitable for
Boy''s
Colour
Blue', 2, 5, N'.PNG')
GO
INSERT [dbo].[ClothInfos] ([ClothInfoID], [Name], [ClothPrice], [SizeChart], [Feature], [ShopCategoryID], [ClothCompanyID], [Extension]) VALUES (5, N'Multi Half Sleeves Pack Of 3 Tees', 29.9, N'3-6 Months, 6-12 Months, 1-1.5 years, 1.5-2 years', N'FEATURES:
Material: Sinker
The actual product may differ slightly in color from the one illustrated in the images.
WHAT''S INCLUDED:
Pack Of 3 Tees
CARE:
Gentle Wash
Suitable for
Unisex
Colour
Multi', 2, 6, N'.PNG')
GO
INSERT [dbo].[ClothInfos] ([ClothInfoID], [Name], [ClothPrice], [SizeChart], [Feature], [ShopCategoryID], [ClothCompanyID], [Extension]) VALUES (6, N'Multi Color Half Sleeves Graphic Printed T-Shirt and Shorts Set', 28.3, N'3-4 years, 5-6 years, 7-8 years, 8-9 years', N'FEATURES:

Top Material: 65%Cotton and 35%Polyester, Bottom Material: 79% Cotton and 21% Polyester
The actual product may differ slightly in color from the one illustrated in the images.
WHAT''S INCLUDED:
1 T-Shirt, 1 Shorts
CARE:
Gentle Wash
Suitable for
Boy''s
Colour
Multi', 3, 7, N'.PNG')
GO
INSERT [dbo].[ClothInfos] ([ClothInfoID], [Name], [ClothPrice], [SizeChart], [Feature], [ShopCategoryID], [ClothCompanyID], [Extension]) VALUES (7, N'khaki Checked Full Sleeves Shirt and Pant Set', 26.4, N'3-4 years, 5-6 years, 7-8 years, 8-9 years', N'FEATURES:
Top Material: 80%Cotton and 20%Viscose, Bottom Material: 95%Cotton and 5%Viscose
The actual product may differ slightly in color from the one illustrated in the images..
WHAT''S INCLUDED:
1 Shirt, 1 Pant 1 Bag
CARE:
Gentle Wash
Suitable for
Boy''s
Colour
Khaki', 3, 8, N'.PNG')
GO
INSERT [dbo].[ClothInfos] ([ClothInfoID], [Name], [ClothPrice], [SizeChart], [Feature], [ShopCategoryID], [ClothCompanyID], [Extension]) VALUES (8, N'Gray Blazer Style Navy Shirt And Pant Set', 14.9, N'3-4 years, 5-6 years, 7-8 years, 8-9 years, 10-11 years, 12-14 years', N'Stylish is what your little one will look wearing this set

FEATURES:
Fabric: 95%Cotton+5%Spandex
Type: Formal Partywear Sets
Comfort Fit
The actual product may differ slightly in color from the one illustrated in the images.
Blazer is attached to the shirt.
WHAT''S INCLUDED:
1 T-Shirt, 1 Bow, 1 Pant
CARE:
Gentle Wash
Suitable for
Boy''s
Colour
Gray', 3, 9, N'.PNG')
GO
INSERT [dbo].[ClothInfos] ([ClothInfoID], [Name], [ClothPrice], [SizeChart], [Feature], [ShopCategoryID], [ClothCompanyID], [Extension]) VALUES (9, N'Mother Sparsh 98% Pure Water Baby Wipes, mildly scented - 80 pcs', 15.8, N'80 pcs', N'Hello all mother’s out there, Mother Sparsh understand your concern about baby’s health & hygiene so specially for your baby’s delicate skin, we have designed 98% Pure Water Based Wipes - as good as pure water & cotton that provide gentle sparsh to your baby hence keeping your baby comfortable, happy & smiling. Our wipes are developed under expert’s supervision and contain quality ingredients that gently cleanse your baby’s supple, soft and delicate skin without causing irritation, uneasiness, allergy and infection. Mother Sparsh 98% Pure Water Based Wipes are “Proven for Preventing Diaper Rashes”. 

Shelf Life: 24 months

Suitable for
Unisex
Colour
Multi', 4, 9, N'.PNG')
GO
INSERT [dbo].[ClothInfos] ([ClothInfoID], [Name], [ClothPrice], [SizeChart], [Feature], [ShopCategoryID], [ClothCompanyID], [Extension]) VALUES (10, N'Chicco Baby Soft Cleansing Wipes Baby Wipes (20 Pieces)', 7.58, N'20 pcs', N'Thanks to their soft texture, chicco wipes gently cleanse and moisturize baby’s delicate skin. The formula, with aloe vera and chamomile, is ideal both for nappy change and cleanse baby''s hands and face chamomile, is ideal during change moment and to cleanse baby’s hands and face.
Suitable for
Unisex
Colour
Multi', 4, 10, N'.PNG')
GO
INSERT [dbo].[ClothInfos] ([ClothInfoID], [Name], [ClothPrice], [SizeChart], [Feature], [ShopCategoryID], [ClothCompanyID], [Extension]) VALUES (11, N'Mee Mee Caring Baby Wet Wipes with Aloe Vera (72 pcs) (Pack of 3)', 29.7, N'Pack of 3', N'Thoroughly cleanses baby''s delicate skin
Suitable for
Unisex
Colour
White', 4, 10, N'.PNG')
GO
INSERT [dbo].[ClothInfos] ([ClothInfoID], [Name], [ClothPrice], [SizeChart], [Feature], [ShopCategoryID], [ClothCompanyID], [Extension]) VALUES (12, N'Penguin Party Blue Piano Activity Gym', 39.9, N'Free Size', N'Baby Moo''s exclusive range of Piano Gym Mats is the perfect space for your STAR to grow and discover their senses. The dangling toys builds their sense of touch and sight. The piano sounds build their sense of hearing. Warning! Gifting this product leads to extra cuddles & love. Whats Include : 1 x Activity Gym Material: Plastic ABS+Cloth
Suitable for
Unisex
Colour
Blue', 5, 1, N'.PNG')
GO
INSERT [dbo].[ClothInfos] ([ClothInfoID], [Name], [ClothPrice], [SizeChart], [Feature], [ShopCategoryID], [ClothCompanyID], [Extension]) VALUES (13, N'36 Pieces Interlocking Learning Puzzle Foam Floor Mat Tiles with Alphabets and Numbers for Kids', 36.9, N'30x7x20', N'36 pieces Mini Puzzle Foam Mat for Kids, Interlocking Learning Alphabet and Number Mat for Kids. This Item comes with 36 Pcs in different attractive color with Interlock able Mat , Measurement of Each Pcs – 4 X 4 Inches, Thickness – 1 cm This Mini Puzzle Foam Mat can be used to Construct Building Blocks, Puzzles or Floor Mat. Interlocking Learning Alphabet (A to Z) and Number Mat (0-9) for kids Recommended for kids 3+ Years Develops baby''s interest in recognising Alphabet and Numbers. Real learning and play, for early education purposes, completely divorced from the traditional teaching concept.
Suitable for
Unisex
Colour
Multi', 5, 4, N'.PNG')
GO
INSERT [dbo].[ClothInfos] ([ClothInfoID], [Name], [ClothPrice], [SizeChart], [Feature], [ShopCategoryID], [ClothCompanyID], [Extension]) VALUES (14, N'Learning Resources teachable Touchables Texture Squares', 34.99, N'Free Size', N'Children can explore ten different textures with these engaging tactile squares. Scratchy, slippery, silky or soft? Young learners build tactile awareness, vocabulary, matching and communication skills as they interact with these twenty texture squares (ten different pairs).
Suitable for
Unisex
Colour
Multi', 5, 6, N'.PNG')
GO
SET IDENTITY_INSERT [dbo].[ClothInfos] OFF
GO
SET IDENTITY_INSERT [dbo].[CartItems] ON 
GO
INSERT [dbo].[CartItems] ([CartItemID], [CartID], [ClothInfoID], [Price], [Quantity], [Total]) VALUES (1, 1, 2, 90, 1, 90)
GO
INSERT [dbo].[CartItems] ([CartItemID], [CartID], [ClothInfoID], [Price], [Quantity], [Total]) VALUES (2, 1, 1, 78, 1, 78)
GO
INSERT [dbo].[CartItems] ([CartItemID], [CartID], [ClothInfoID], [Price], [Quantity], [Total]) VALUES (3, 2, 3, 48, 1, 48)
GO
INSERT [dbo].[CartItems] ([CartItemID], [CartID], [ClothInfoID], [Price], [Quantity], [Total]) VALUES (4, 2, 4, 49.9, 1, 49.9)
GO
SET IDENTITY_INSERT [dbo].[CartItems] OFF
GO
