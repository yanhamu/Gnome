using Gnome.Core.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Gnome.Core.Service.Transactions.TransactionFactories
{
    public class TransactionContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = base.CreateProperties(type, memberSerialization);
            var propertiesToIgnore = typeof(Transaction).GetProperties().Select(p => p.Name).ToList();

            propertiesToIgnore.Add("id");

            return properties.Where(p => !propertiesToIgnore.Contains(p.PropertyName)).ToList();
        }
    }
}
