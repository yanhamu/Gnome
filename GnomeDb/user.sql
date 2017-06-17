CREATE TABLE [dbo].[user]
(
	[id] INT NOT NULL identity(1,1) PRIMARY KEY,
	email varchar(30) not null,
	[pwd] binary(32) not null,
	[salt] binary(16) not null
)
