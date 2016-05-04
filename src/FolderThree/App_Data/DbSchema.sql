
CREATE DATABASE folderdb

--- Create db schema

USE folderdb;
GO

CREATE TABLE dbo.Folder(
  FolderId int NOT NULL
    CONSTRAINT PK_FolderId PRIMARY KEY CLUSTERED,
  Name nvarchar(120) NOT NULL,
  ParentId int NUll
	CONSTRAINT FK_FolderId FOREIGN KEY 
	REFERENCES dbo.Folder (FolderId)
);
