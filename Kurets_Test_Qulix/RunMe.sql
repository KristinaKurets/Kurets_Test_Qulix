USE [YourDbsName]
GO

/****** Object:  Table [dbo].[Companies]    Script Date: 05.11.2020 14:35:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Companies](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Form] [nvarchar](50) NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AddCompany]    Script Date: 05.11.2020 14:37:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddCompany]
						@name nvarchar(64),
						@form nvarchar(64)

AS
BEGIN
	INSERT INTO Companies([Name], Form) VALUES (@name, @form)
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteCompany]    Script Date: 05.11.2020 14:38:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCompany]
						@name nvarchar(64),
						@form nvarchar(64)

AS
BEGIN
	DELETE FROM Companies WHERE
	[Name] = @name AND
	Form = @form
END
GO
/****** Object:  StoredProcedure [dbo].[EditCompany]    Script Date: 05.11.2020 14:40:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditCompany]
						@name nvarchar(64),
						@form nvarchar(64)

AS
BEGIN
	UPDATE Companies SET
	[Name] = @name,
	Form = @form
END

GO

/****** Object:  Table [dbo].[Employees]    Script Date: 05.11.2020 14:41:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employees](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[SurName] [nvarchar](50) NULL,
	[Patronymic] [nvarchar](50) NULL,
	[EmploymentDate] [datetime] NULL,
	[Position] [nvarchar](50) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AddEmployee]    Script Date: 05.11.2020 14:41:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddEmployee]
						@name nvarchar(64),
						@surname nvarchar(64),
						@patronymic nvarchar(64),
						@employmentDate datetime
AS
BEGIN
	INSERT INTO Employees(Name, SurName, Patronymic, EmploymentDate) VALUES (@name,@surname,@patronymic,@employmentDate)
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteEmployee]    Script Date: 05.11.2020 14:42:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteEmployee]
						@name nvarchar(64),
						@surname nvarchar(64),
						@patronymic nvarchar(64)
AS
BEGIN
	DELETE FROM Employees WHERE 
	[Name] = @name AND SurName = @surname AND Patronymic = @patronymic
	
END
GO
/****** Object:  StoredProcedure [dbo].[EditEmployee]    Script Date: 05.11.2020 14:42:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditEmployee]
						@name nvarchar(64),
						@surname nvarchar(64),
						@patronymic nvarchar(64),
						@employmentDate date,
						@position nvarchar(64)
AS
BEGIN
	UPDATE Employees SET 
	[Name] = @name, 
	SurName = @surname, 
	Patronymic = @patronymic, 
	EmploymentDate = @employmentDate,
	Position = @position
	
END
