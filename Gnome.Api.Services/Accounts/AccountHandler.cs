using Gnome.Api.Services.Accounts.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Service.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Gnome.Api.Services.Accounts
{
    public class AccountHandler :
        IRequestHandler<ListUserAccounts, List<Account>>,
        IRequestHandler<GetAccount, Account>,
        IRequestHandler<UpdateAccount, Account>,
        IRequestHandler<CreateAccount, Account>,
        INotificationHandler<RemoveAccount>
    {
        private readonly IFioAccountRepository repository;
        private readonly IAccountService accountService;

        public AccountHandler(IFioAccountRepository repository,
            IAccountService accountService)
        {
            this.repository = repository;
            this.accountService = accountService;
        }

        public List<Account> Handle(ListUserAccounts message)
        {
            return repository
                .GetAccounts(message.UserId)
                .Select(a => new Account(a.Id, a.Name, a.Token))
                .ToList();
        }

        public Account Handle(GetAccount message)
        {
            var account = repository.Find(message.AccountId);
            return new Account(account.Id, account.Name, account.Token);
        }

        public Account Handle(UpdateAccount message)
        {
            var updated = accountService.Update(message.Id, message.Name, message.Token);
            return new Account(updated.Id, updated.Name, updated.Token);
        }

        public Account Handle(CreateAccount message)
        {
            var created = repository.Create(new Core.Model.FioAccount(0, message.UserId, message.Name, message.Token));
            repository.Save();
            return new Account(created.Id, created.Name, created.Token);
        }

        public void Handle(RemoveAccount notification)
        {
            repository.Remove(notification.Id);
            repository.Save();
        }
    }
}
