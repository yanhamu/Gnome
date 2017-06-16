CREATE TABLE [dbo].[account]
(
	[Id] INT NOT NULL PRIMARY KEY,
	userid int not null,
	[name] nvarchar(30),
	[token] nchar(64),
	foreign key (userid) references [user](id)
)
