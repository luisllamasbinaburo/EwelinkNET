using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace EwelinkNet.Helpers.Extensions
{
    /// <summary>
    /// Constains Object extensions
    /// </summary>
    public static class ObjectExtensions
    {
        public static string AsJson(this object item)
        {
            return JsonConvert.SerializeObject(item, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
                Formatting = Formatting.Indented
            });
        }
    }

    /// <summary>
    /// Constains String extensions
    /// </summary>
    public static class StringExtensions
    {
        public static T FromJson<T>(this string item)
        {
            return JsonConvert.DeserializeObject<T>(item, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
                Formatting = Formatting.Indented
            });
        }
    }

    /// <summary>
    /// Constains Dictionary extensions
    /// </summary>
    public static class DictionaryExtensions
    {
        public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key)
        {
            return source.GetOrDefault(key, default(TValue));
        }

        public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, TValue defaultValue)
        {
            TValue value;
            return source.TryGetValue(key, out value) ? value : defaultValue;
        }
    }

    /// <summary>
    /// Constains Expando helper static method (.NET doesn't allow extensions for dynamics)
    /// </summary>
    public static class ExpandoHelpers
    {
        public static void AddProperty(ExpandoObject expando, string key, object value)
        {
            (expando as IDictionary<string, object>)?.Add(key, value);
        }

        public static bool HasProperty(ExpandoObject expando, string key)
        {
            return (expando as IDictionary<string, object>)?.ContainsKey(key) ?? false;
        }

        public static object GetOrDefault(ExpandoObject expando, string key)
        {
            var dic = expando as IDictionary<string, object>;
            return dic.ContainsKey(key) ? dic[key] : null;
        }

        public static void Map(ExpandoObject source, ExpandoObject target)
        {
            var sourceDic = source as IDictionary<string, object>;
            var targetDic = target as IDictionary<string, object>;

            foreach (var key in sourceDic.Keys)
            {
                targetDic[key] = sourceDic[key];
            }
        }
    }
}

