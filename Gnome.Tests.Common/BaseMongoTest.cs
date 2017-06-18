using Autofac;
using System;

namespace Gnome.Tests.Common
{
    public class BaseMongoTest : IDisposable
    {
        protected IContainer container;
        public BaseMongoTest()
        {
            container = DiInitializer.BuildContainer();
        }

        public void Dispose()
        {
            container.Dispose();
        }
    }
}
