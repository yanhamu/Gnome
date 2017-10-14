using MediatR;
using System;
using System.Collections.Generic;

namespace Gnome.Api.Services.Reports.Requests
{
    public class ListReports : IRequest<List<Report>>
    {
        public Guid UserId { get; }

        public ListReports(Guid userId)
        {
            this.UserId = userId;
        }
    }
}
