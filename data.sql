CREATE DATABASE MVVMLoginDb
GO
USE MVVMLoginDb
GO
CREATE TABLE [User]
(
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Username NVARCHAR (50) UNIQUE NOT NULL,
    [Password] NVARCHAR (100) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    LastName NVARCHAR (50) NOT NULL,
    Email NVARCHAR (100) UNIQUE NOT NULL,
)

GO 
INSERT INTO [User] VALUES (NEWID(),'admin','admin', 'admin', 'Advanced', 'admin@gmail.com')
INSERT INTO [User] VALUES (NEWID(),'jazz','qwerty', 'admin', 'Advanced', 'jazz@gmail.com')
INSERT INTO [User] VALUES (NEWID(),'keni','asdfg', 'admin', 'Advanced', 'keni@gmail.com')
GO

SELECT * from [User]