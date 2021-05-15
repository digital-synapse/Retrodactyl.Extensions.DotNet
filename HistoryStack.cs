using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Retrodactyl.Extensions.DotNet
{
    public class HistoryStack<T>
    {
        private T[] data;
        private int count = 0;
        private int index = 0;
        private int capacity;

        private int peek()
        {
            var i = index-1;
            if (i == -1) i = capacity - 1;
            return i;
        }
        private int dec()
        {
            index--;
            if (index == -1)
            {
                index = capacity - 1;
            }
            count--;
            return index;
        }
        private int inc()
        {
            index = (index + 1) % capacity;
            count++;
            if (count > capacity) count = capacity;
            return index;
        }

        public HistoryStack(int capacity, Func<int,T> initializer = null)
        {
            this.capacity = capacity;
            data = new T[capacity];
            if (initializer != null)
                for (int i = 0; i < capacity; i++) data[i] = initializer(i);
            else
                for (int i = 0; i < capacity; i++) data[i] = default(T);
        }

        public void Push(T item)
        {
            data[index] = item;
            inc();
        }

        // like peek, but looks ahead
        public T Next()
        {
            return data[index];
        }

        public T Pop()
        {
            if (count == 0)
                return default(T);
            else
            {
                return data[dec()];
            }
        }

        public T Peek()
        {
            if (count == 0)
                return default(T);
            else
                return data[peek()];
        }

        public IEnumerable<T> Peek(int count)
        {
            var requested = count;
            if (count > capacity)
            {
                count = capacity;

            }
            var i = index;
            for (var c = 0; c < count; c++)
            {
                i = i - 1;
                if (i < 0) i = capacity - 1;
                yield return data[i];
            }
            for (var c = 0; c< requested - count; c++)
            {
                yield return default(T);
            }
        }

        public int Count => count;// > capacity ? capacity : count;
    }
}
