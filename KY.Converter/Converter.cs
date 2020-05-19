using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KY.Converter
{
    public static class Converter
    {
        #region Json和Dictionary相互转化
        /// <summary>
        /// 将字典类型序列化为json字符串
        /// </summary>
        /// <typeparam name="TKey">字典key</typeparam>
        /// <typeparam name="TValue">字典value</typeparam>
        /// <param name="dict">要序列化的字典数据</param>
        /// <returns>json字符串</returns>
        public static string SerializeDictionaryToJsonString<TKey, TValue>(this Dictionary<TKey, TValue> dict)
        {
            string jsonStr = JsonConvert.SerializeObject(dict);
            return jsonStr;
        }

        /// <summary>
        /// 将json字符串反序列化为字典类型
        /// </summary>
        /// <typeparam name="TKey">字典key</typeparam>
        /// <typeparam name="TValue">字典value</typeparam>
        /// <param name="jsonStr">json字符串</param>
        /// <returns>字典数据</returns>
        public static Dictionary<TKey, TValue> DeserializeStringToDictionary<TKey, TValue>(this string jsonStr)
        {
            if (string.IsNullOrEmpty(jsonStr))
                return new Dictionary<TKey, TValue>();
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects,
                DateFormatString = "yyyy-MM-dd hh:mm:sss",
                ObjectCreationHandling = ObjectCreationHandling.Replace
            };
            Dictionary<TKey, TValue> jsonDict = JsonConvert.DeserializeObject<Dictionary<TKey, TValue>>(jsonStr, settings);

            return jsonDict;

        }

        public static object DeserializeJson(this string json)
        {
            return ToObject(JToken.Parse(json));
        }

        private static object ToObject(JToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Object:
                    return token.Children<JProperty>()
                                .ToDictionary(prop => prop.Name,
                                              prop => ToObject(prop.Value));

                case JTokenType.Array:
                    return token.Select(ToObject).ToList();

                default:
                    return ((JValue)token).Value;
            }
        }

        #endregion

        #region 将对象转化为Dictionary

        public static Dictionary<string, object> ConvertDictionary(this object obj)
        {
            if (obj is Dictionary<string, object>)
                return (Dictionary<string, object>)obj;
            Dictionary<string, object> dict = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            var nvc = obj as NameValueCollection;
            if (nvc != null)
            {

                foreach (string key in nvc.Keys)
                    dict.Add(key, nvc[key]);
                return dict;
            }

            var hs = obj as Hashtable;
            if (hs != null)
            {
                foreach (string key in hs.Keys.OfType<string>())
                    dict.Add(key, hs[key]);
                return dict;
            }
            var type = obj.GetType();

            //lock (CachedictionaryCache)
            //{
            //    Func<object, Dictionary<string, object>> getter;
            //    if (dictionaryCache.TryGetValue(type, out getter) == false)
            //    {
            //        getter = CreateDictionaryGenerator(type);
            //        dictionaryCache[type] = getter;
            //    }
            //    var dict = getter(obj);
            //    return dict;
            //}
            Func<object, Dictionary<string, object>> getter = type.ConvertDictionary();
            return getter(obj);
            //if (dictionaryCache.TryGetValue(type, out getter) == false)
            //{
            //    getter = CreateDictionaryGenerator(type);
            //    dictionaryCache[type] = getter;
            //}
            //var dict = getter(obj);
            //return dict;
        }

        /// <summary>
        /// 将Type转化未Dictionary
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static Func<object, Dictionary<string, object>> ConvertDictionary(this Type type)
        {
            var dm = new DynamicMethod((string.Format("Dictionary{0}", Guid.NewGuid())), typeof(Dictionary<string, object>), new[] { typeof(object) }, type, true);
            ILGenerator il = dm.GetILGenerator();
            il.DeclareLocal(typeof(Dictionary<string, object>));
            il.Emit(OpCodes.Nop);
            //Dictionary<string, object> dic = new Dictionary<string, object>();
            il.Emit(OpCodes.Newobj, typeof(Dictionary<string, object>).GetConstructor(Type.EmptyTypes));
            il.Emit(OpCodes.Stloc_0);

            foreach (var item in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                string columnName = item.Name;
                il.Emit(OpCodes.Nop);
                il.Emit(OpCodes.Ldloc_0);
                il.Emit(OpCodes.Ldstr, columnName);
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Callvirt, item.GetGetMethod());
                if (item.PropertyType.IsValueType)
                {
                    il.Emit(OpCodes.Box, item.PropertyType);
                }
                il.Emit(OpCodes.Callvirt, typeof(Dictionary<string, object>).GetMethod("Add"));
            }
            il.Emit(OpCodes.Nop);

            il.Emit(OpCodes.Ldloc_0);
            il.Emit(OpCodes.Ret);
            var func = (Func<object, Dictionary<string, object>>)dm.CreateDelegate(typeof(Func<object, Dictionary<string, object>>));
            return func;
        }
        #endregion
    }
}
