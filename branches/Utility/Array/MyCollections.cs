using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Array
{
    public class MyCollections<T> where T : INameProvider
    {
        private readonly Dictionary<string, T> _collection = new Dictionary<string, T>();

        /// <summary>
        /// 功能：向集合添加元素
        /// </summary>
        /// <param name="e"></param>
        public void Add(T e)
        {
            if (!_collection.ContainsKey(e.Name))
            {
                _collection.Add(e.Name, e);
            }
        }

        /// <summary>
        /// 功能：移调指定索引的元素  
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (index >= 0 && index < _collection.Count)
            {
                String[] keys = GetAllNames();
                _collection.Remove(keys[index]);
            }
        }

        /// <summary>
        /// 功能：移调指定名称的元素   
        /// </summary>
        /// <param name="name"></param>
        public void Remove(string name)
        {
            if (_collection.ContainsKey(name))
            {
                _collection.Remove(name);
            }
        }

        /// <summary>
        /// 功能：清除所有的元素   
        /// </summary>
        public void Clear()
        {
            _collection.Clear();
        }

        /// <summary>
        /// 功能：获取指定名称的元素  
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public T this[string name]
        {
            get
            {
                if (_collection.ContainsKey(name))
                {
                    return _collection[name];
                }

                T result = default(T);
                return result;
            }
        }

        /// <summary>
        /// 是否包含指定元素
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ContainsKey(string name)
        {
            return _collection.ContainsKey(name);
        }

        /// <summary>
        /// 是否包含指定元素
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ContainsValue(T value)
        {
            return _collection.ContainsValue(value);
        }

        /// <summary>
        /// 查找元素在集合中的索引
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public int IndexOf(T e)
        {
            int index = -1;
            if (_collection.Count > 0 && _collection.ContainsValue(e))
            {
                string[] elrments = GetAllNames();
                for (int i = 0; i < elrments.Length; i++)
                {
                    if (elrments[i].Equals(e))
                    {
                        index = i;
                        break;
                    }
                }
            }

            return index;
        }

        /// <summary>
        /// 功能：获取指定索引的元素   
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < _collection.Count)
                {
                    String[] keys = GetAllNames();
                    return _collection[keys[index]];
                }
                T result = default(T);
                return result;
            }
        }

        /// <summary>
        /// 功能：元素总数  
        /// </summary>
        public int Count
        {
            get { return _collection.Count; }
        }

        /// <summary>
        /// 获取所有元素名称
        /// </summary>
        /// <returns>元素名称列表</returns>
        public String[] GetAllNames()
        {
            if (_collection.Count > 0)
            {
                String[] keys = new string[_collection.Count];
                _collection.Keys.CopyTo(keys, 0);
                return keys;
            }
            return null;
        }
    }
}
