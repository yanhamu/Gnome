CREATE TABLE [category]
(
	[id] uniqueidentifier not null primary key,
	[user_id] uniqueidentifier not null,
	[parent_id] int,
	[name] varchar(100) not null,
	[is_system] bit not null default(0),
	[type] int null, 
    [color] char(6) null,
    foreign key ([parent_id]) references [category](id),
    foreign key ([user_id]) references [user](id)
)