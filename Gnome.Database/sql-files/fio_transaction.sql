CREATE TABLE [fio_transaction]
(
	[account_id] int not null,
	[fio_id] bigint not null primary key,
	[date] datetime not null,
	[amount] decimal(18,2) not null,
	[currency] nvarchar(3) not null,
	[counter_account] nvarchar(255), 
	[counter_account_name] nvarchar(255),
	[counter_bank_code] nvarchar(10),
	[counter_bank_name] nvarchar(255),
	[constant_symbol] nvarchar(4),
	[variable_symbol] nvarchar(10),
	[specific_symbol] nvarchar(10),
	[identification] nvarchar(255),
	[message] nvarchar(140),
	[type] nvarchar(255) not null,
	[accountant] nvarchar(50),
	[comment] nvarchar(255),
	[bank_identification_number] nvarchar(11),
	[instruction_id] bigint
)
