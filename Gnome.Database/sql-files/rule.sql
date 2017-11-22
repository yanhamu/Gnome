CREATE TABLE [rule]
(
	[id] uniqueidentifier not null primary key,
	[expression_id] uniqueidentifier not null,
	[user_id] uniqueidentifier not null,
	[name] nvarchar(60) not null,
	[action_type] nvarchar(64) not null,
	[action_data] text not null,
	foreign key (user_id) references [user](id),
	foreign key (expression_id) references [expression](id)
)