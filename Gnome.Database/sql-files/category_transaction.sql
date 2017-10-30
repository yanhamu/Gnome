CREATE TABLE [category_transaction]
(
	[category_id] uniqueidentifier not null,
	[transaction_id] uniqueidentifier not null,
	primary key (category_id, transaction_id),
	foreign key(transaction_id) references [transaction](id),
	foreign key(category_id) references category(id)
)
