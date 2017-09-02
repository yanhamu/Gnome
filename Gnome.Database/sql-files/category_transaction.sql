CREATE TABLE [dbo].[category_transaction]
(
	transaction_id uniqueidentifier not null foreign key(transaction_id) references [transaction](id),
	[category_id] INT NOT NULL foreign key(category_id) references category(id),
	primary key (category_id, transaction_id)
)
