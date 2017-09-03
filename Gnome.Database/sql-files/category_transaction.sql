CREATE TABLE [category_transaction]
(
	transaction_id uniqueidentifier not null,
	[category_id] uniqueidentifier not null,
	primary key (category_id, transaction_id),
	foreign key(transaction_id) references [transaction](id),
	foreign key(category_id) references category(id)
)
