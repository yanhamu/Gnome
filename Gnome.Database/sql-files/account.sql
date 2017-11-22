CREATE TABLE [account]
(
	[id] uniqueidentifier not null primary key,
	[user_id] uniqueidentifier not null,
	[name] nvarchar(30),
	[token] nvarchar(64) null,
	foreign key (userid) references [user](id)
)