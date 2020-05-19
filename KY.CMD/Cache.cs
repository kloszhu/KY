using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace KY.CMD
{
    public static class Cache
    {
        private static readonly Timer CleanupTimer = new Timer() { AutoReset = true, Enabled = true, Interval = 60000 };
        private static readonly Dictionary<string, CacheItem> InternalCache = new Dictionary<string, CacheItem>();

        static Cache()
        {
            CleanupTimer.Elapsed += Clean;
            CleanupTimer.Start();
        }

        private static void Clean(object sender, ElapsedEventArgs e)
        {
            InternalCache.Keys.ToList().ForEach(x => { try { if (InternalCache[x].ExpireTime <= e.SignalTime) { Remove(x); } } catch (Exception) { /*swallow it*/ } });
        }

        public static bool ContainsKey(string key)
        {
            return InternalCache.ContainsKey(key);
        }

        public static T Get<T>(string key, int expiresMinutes, Func<T> refreshFunction)
        {
            if (InternalCache.ContainsKey(key) && InternalCache[key].ExpireTime > DateTime.Now)
            {
                return (T)InternalCache[key].Item;
            }

            var result = refreshFunction();

            Set(key, result, expiresMinutes);

            return result;
        }

        public static void Set(string key, object item, int expiresMinutes)
        {
            Remove(key);

            InternalCache.Add(key, new CacheItem(item, expiresMinutes));
        }

        public static void Remove(string key)
        {
            if (InternalCache.ContainsKey(key))
            {
                InternalCache.Remove(key);
            }
        }

        private struct CacheItem
        {
            public CacheItem(object item, int expiresMinutes)
                : this()
            {
                Item = item;
                ExpireTime = DateTime.Now.AddMinutes(expiresMinutes);
            }

            public object Item { get; private set; }
            public DateTime ExpireTime { get; private set; }
        }
    }
}
