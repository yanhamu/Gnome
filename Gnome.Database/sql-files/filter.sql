CREATE TABLE [filter]
(
	[id] uniqueidentifier not null primary key,
	[userid] uniqueidentifier not null,
	[name] text not null,
	[content] text not null,
	foreign key (userid) references [user](id)
)