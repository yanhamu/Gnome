using Gnome.Api.Services.Accounts.Requests;
using Gnome.Core.Service.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Api.Services.Accounts
{
    public class AccountHandler :
        IRequestHandler<ListUserAccounts, List<Account>>,
        IRequestHandler<GetAccount, Account>,
        IRequestHandler<UpdateAccount, Account>,
        IRequestHandler<CreateAccount, Account>,
        INotificationHandler<RemoveAccount>
    {
        private readonly IAccountService service;

        public AccountHandler(IAccountService accountService)
        {
            this.service = accountService;
        }

        public List<Account> Handle(ListUserAccounts message)
        {
            return service
                .List(message.UserId)
                .Select(a => new Account(a.Id, a.Name, a.Token))
                .ToList();
        }

        public Account Handle(GetAccount message)
        {
            var account = service.Get(message.AccountId);
            return new Account(account.Id, account.Name, account.Token);
        }

        public Account Handle(UpdateAccount message)
        {
            var updated = service.Update(message.Id, message.Name, message.Token);
            return new Account(updated.Id, updated.Name, updated.Token);
        }

        public Account Handle(CreateAccount message)
        {
            var id = Guid.NewGuid();
            var created = service.Create(new Core.Model.Database.Account(id, message.UserId, message.Name, message.Token));
            return new Account(created.Id, created.Name, created.Token);
        }

        public void Handle(RemoveAccount notification)
        {
            service.Remove(notification.AccountId);
        }
    }
}
