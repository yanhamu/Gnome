CREATE TABLE [dbo].[category]
(
	[id] INT NOT NULL identity(1,1) PRIMARY KEY,
	[user_id] uniqueidentifier not null foreign key ([user_id]) references [user](id),
	[parent_id] int foreign key ([parent_id]) references [category](id),
	[name] varchar(100) not null,
	[is_system] bit not null default(0),
	[type] int null, 
    [color] char(6) null
)