using Gnome.Api.Services.Accounts.Requests;
using Gnome.Core.Service.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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

        public async Task<List<Account>> Handle(ListUserAccounts message, CancellationToken cancellationToken)
        {
            return (await service
                .List(message.UserId))
                .Select(a => new Account(a.Id, a.Name, a.Token))
                .ToList();
        }

        public async Task<Account> Handle(GetAccount message, CancellationToken cancellationToken)
        {
            var account = await service.Get(message.AccountId);
            return new Account(account.Id, account.Name, account.Token);
        }

        public async Task<Account> Handle(UpdateAccount message, CancellationToken cancellationToken)
        {
            var updated = await service.Update(message.Id, message.Name, message.Token);
            return new Account(updated.Id, updated.Name, updated.Token);
        }

        public Task<Account> Handle(CreateAccount message, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            var created = service.Create(new Core.Model.Database.Account(id, message.UserId, message.Name, message.Token));
            return Task.FromResult(new Account(created.Id, created.Name, created.Token));
        }

        public Task Handle(RemoveAccount notification, CancellationToken cancellationToken)
        {
            service.Remove(notification.AccountId);
            return Task.CompletedTask;
        }
    }
}
