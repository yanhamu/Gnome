CREATE TABLE [dbo].[account_category]
(
	[category_id] INT NOT NULL foreign key(category_id) references category(id),
	account_id int not null foreign key(account_id) references fio_account(id),
	primary key (category_id, account_id)
)
