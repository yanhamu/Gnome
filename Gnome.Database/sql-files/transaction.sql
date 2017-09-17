CREATE TABLE [transaction]
(
	[id] uniqueidentifier not null primary key,
	[account_id] uniqueidentifier not null,
	[date] datetime not null,
	[amount] decimal(18,2) not null,
	[type] nvarchar(40) not null,
	[data] text,
	foreign key ([account_id]) references account(id)
)
