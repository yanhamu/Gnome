using Gnome.Core.Model.Database;
using System;

namespace Gnome.Core.Service.Rules.Actions
{
    public interface IActionFactory
    {
        Action Create(Rule rule, Guid id);
    }
}