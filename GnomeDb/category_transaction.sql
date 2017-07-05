CREATE TABLE [dbo].[category_transaction]
(
	transaction_id int not null foreign key(transaction_id) references fio_transaction(id),
	[category_id] INT NOT NULL foreign key(category_id) references category(id),
	primary key (category_id, transaction_id)
)
