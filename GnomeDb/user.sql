CREATE TABLE [dbo].[user]
(
	[id] uniqueidentifier not null primary key,
	email varchar(30) not null,
	[pwd] binary(32) not null,
	[salt] binary(16) not null
)
