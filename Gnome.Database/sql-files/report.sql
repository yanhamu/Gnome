CREATE TABLE [report]
(
	[id] uniqueidentifier not null primary key,
	[userid] uniqueidentifier not null,
	[queryid] uniqueidentifier not null,
	[name] nvarchar(30),
	[type] text not null,
	[data] text null,
	foreign key (userid) references [user](id),
	foreign key (queryid) references [query](id)
)