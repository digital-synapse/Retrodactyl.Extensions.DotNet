using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Retrodactyl.Extensions.DotNet
{
    // like a list but without dynamic allocations
    public class FastList<T>
    {
        private T[] data;
        private int count = 0;
        public FastList(int capacity, Func<T> initializer = null)
        {
            data = new T[capacity];
            if (initializer != null)
                for (int i = 0; i < capacity; i++) data[i] = initializer();
            else
                for (int i = 0; i < capacity; i++) data[i] = default(T);
        }

        public FastList<T> Init(IEnumerable<T> items)
        {
            int i = 0;
            foreach (var item in items)
            {
                data[i++] = item;
            }
            count = i;
            return this;
        }
        public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Any(Func<T, bool> p)
        {
            return data.Take(count).Any(p);
        }

        public int Count => count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            data[count++] = item;
        }

        public void Clear()
        {
            count = 0;
        }

        public bool Contains(T item)
        {
            return data.Take(count).Contains(item);
        }

        public IEnumerable<T> GetEnumerable()
        {
            return data.Take(count);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return data.Take(count).GetEnumerator();
        }
    }
}
