CREATE TABLE [query]
(
	[id] uniqueidentifier not null primary key,
	[userid] uniqueidentifier not null,
	[name] nvarchar(30) not null,
	[data] text null,
	foreign key (userid) references [user](id)
)