CREATE TABLE [dbo].[account]
(
	[id] INT NOT NULL identity(1,1) PRIMARY KEY,
	userid int not null,
	[name] nvarchar(30),
	[token] nvarchar(64),
	foreign key (userid) references [user](id)
)
