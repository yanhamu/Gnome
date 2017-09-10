create table [filter]
(
id uniqueidentifier not null primary key,
[user_id] uniqueidentifier not null,
expression text,
foreign key ([user_id]) references [user](id)
)