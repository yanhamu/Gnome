using Gnome.Core.Model.Database;
using MediatR;
using System;

namespace Gnome.Api.Services.Transactions.Requests
{
    public class CreateTransaction : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public string Data { get; set; }
    }
}
