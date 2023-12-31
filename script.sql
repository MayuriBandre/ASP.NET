USE [mayuri]
GO
/****** Object:  Table [dbo].[tblCity]    Script Date: 22-12-2023 04:18:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCity](
	[CityId] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [varchar](255) NOT NULL,
	[StateId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblState]    Script Date: 22-12-2023 04:18:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblState](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUserRegistration]    Script Date: 22-12-2023 04:18:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUserRegistration](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[Phone] [varchar](20) NOT NULL,
	[Address] [varchar](255) NULL,
	[StateId] [int] NOT NULL,
	[CityId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblCity] ON 

INSERT [dbo].[tblCity] ([CityId], [CityName], [StateId]) VALUES (1, N'kanpur', 1)
INSERT [dbo].[tblCity] ([CityId], [CityName], [StateId]) VALUES (2, N'Mumbai', 2)
INSERT [dbo].[tblCity] ([CityId], [CityName], [StateId]) VALUES (3, N'Chennai', 3)
INSERT [dbo].[tblCity] ([CityId], [CityName], [StateId]) VALUES (4, N'Bangalore', 4)
INSERT [dbo].[tblCity] ([CityId], [CityName], [StateId]) VALUES (5, N'agra', 1)
SET IDENTITY_INSERT [dbo].[tblCity] OFF
GO
SET IDENTITY_INSERT [dbo].[tblState] ON 

INSERT [dbo].[tblState] ([Id], [StateName]) VALUES (1, N'Uttar Pradesh')
INSERT [dbo].[tblState] ([Id], [StateName]) VALUES (2, N'Maharashtra')
INSERT [dbo].[tblState] ([Id], [StateName]) VALUES (3, N'Tamil Nadu')
INSERT [dbo].[tblState] ([Id], [StateName]) VALUES (4, N'Karnataka')
SET IDENTITY_INSERT [dbo].[tblState] OFF
GO
SET IDENTITY_INSERT [dbo].[tblUserRegistration] ON 

INSERT [dbo].[tblUserRegistration] ([Id], [Name], [Email], [Phone], [Address], [StateId], [CityId]) VALUES (4, N'mayuri', N'mayuribandre27@gmail.com', N'9638952061', N'icc', 1, 1)
SET IDENTITY_INSERT [dbo].[tblUserRegistration] OFF
GO
ALTER TABLE [dbo].[tblCity]  WITH CHECK ADD FOREIGN KEY([StateId])
REFERENCES [dbo].[tblState] ([Id])
GO
ALTER TABLE [dbo].[tblUserRegistration]  WITH CHECK ADD FOREIGN KEY([CityId])
REFERENCES [dbo].[tblCity] ([CityId])
GO
ALTER TABLE [dbo].[tblUserRegistration]  WITH CHECK ADD FOREIGN KEY([StateId])
REFERENCES [dbo].[tblState] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteUser]    Script Date: 22-12-2023 04:18:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteUser]
    @UserId INT
AS
BEGIN
    DELETE FROM tblUserRegistration
    WHERE Id = @UserId;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_Getcity]    Script Date: 22-12-2023 04:18:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Getcity]
    @StateId INT
AS
BEGIN
    SELECT * FROM tblCity
    WHERE StateId = @StateId;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_Getcityname]    Script Date: 22-12-2023 04:18:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_Getcityname]
    @CityId INT
AS
BEGIN
    SELECT * FROM tblCity
    WHERE CityId = @CityId;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetState]    Script Date: 22-12-2023 04:18:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_GetState]
  
AS
BEGIN
    SELECT * FROM tblState;
   
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUserById]    Script Date: 22-12-2023 04:18:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetUserById]
    @UserId INT
AS
BEGIN
    SELECT * FROM tblUserRegistration
    WHERE Id = @UserId;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUserDetails]    Script Date: 22-12-2023 04:18:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_GetUserDetails]
   
AS
BEGIN
    SELECT * FROM tblUserRegistration
    
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertUser]    Script Date: 22-12-2023 04:18:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertUser]
    @Name VARCHAR(255),
    @Email VARCHAR(255),
    @Phone VARCHAR(20),
    @Address VARCHAR(255),
    @StateId INT,
    @CityId INT
AS
BEGIN
 
    IF NOT EXISTS (SELECT 1 FROM tblUserRegistration WHERE Email = @Email)
    BEGIN
        -- Email doesn't exist, proceed with insertion
        INSERT INTO tblUserRegistration (Name, Email, Phone, Address, StateId, CityId)
        VALUES (@Name, @Email, @Phone, @Address, @StateId, @CityId);
    END
    
END;

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateUser]    Script Date: 22-12-2023 04:18:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateUser]
    @UserId INT,
    @Name VARCHAR(255),
    @Email VARCHAR(255),
    @Phone VARCHAR(20),
    @Address VARCHAR(255),
    @StateId INT,
    @CityId INT
AS
BEGIN
    UPDATE tblUserRegistration
    SET
        Name = @Name,
        Email = @Email,
        Phone = @Phone,
        Address = @Address,
        StateId = @StateId,
        CityId = @CityId
    WHERE Id = @UserId;
END;
GO
