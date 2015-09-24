CREATE TABLE [dbo].[Applications]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
    [Sender] NVARCHAR(30) NOT NULL, 
    [PostDate] DATE NOT NULL,
    [Subject] NVARCHAR(30) NOT NULL,
    [RegistrationNumber] NVARCHAR(20) NOT NULL,
    [IsActive] BIT NOT NULL,
	CONSTRAINT PK_App_Id PRIMARY KEY ([Id]),
	CONSTRAINT RegNum_Unique UNIQUE ([RegistrationNumber])
)
