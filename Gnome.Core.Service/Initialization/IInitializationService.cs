using System;

namespace Gnome.Core.Service.Initialization
{
    public interface IInitializationService
    {
        int Order { get; }
        void Initialize(Guid userId);
    }
}
