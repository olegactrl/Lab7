using System;
using System.Collections.Generic;

namespace Lab7_3_
{
    public class FunctionCache<TKey, TResult>
    {
        public delegate TResult FuncDelegate(TKey key);

        private Dictionary<TKey, TResult> cache;

        // Конструктор класу
        public FunctionCache()
        {
            cache = new Dictionary<TKey, TResult>();
        }

        public TResult GetOrAdd(TKey key, FuncDelegate func)
        {
            if (cache.TryGetValue(key, out TResult result))
            {
                return result;
            }

            result = func(key);
            cache.Add(key, result);

            return result;
        }
    }
}
