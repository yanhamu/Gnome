create table [expression]
(
	id uniqueidentifier not null primary key,
	[user_id] uniqueidentifier not null,
	[expressionString] text not null,
	foreign key ([user_id]) references [user](id)
)