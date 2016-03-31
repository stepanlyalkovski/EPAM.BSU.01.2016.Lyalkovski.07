using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class CustomQueue<T> : IEnumerable<T>
    {
        private T[] array;
        private int size;
        private int head;
        private int tail;

        public CustomQueue() : this(20) { }

        public CustomQueue(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException();

            array = new T[capacity];
            size = 0;
            head = 0;
            tail = 0;
        }

        public CustomQueue(IEnumerable<T> collection)
        {
            array = new T[20];
            using (IEnumerator<T> en = collection.GetEnumerator())
            {
                while (en.MoveNext())
                {
                    Enqueue(en.Current);
                }
            }
        }

        public void Enqueue(T elem)
        {
            if (size == array.Length)
            {
                int newcapacity = array.Length * 2;

                SetCapacity(newcapacity);
            }

            array[tail] = elem;
            tail = (tail + 1) % array.Length;
            size++;
        }

        public T Dequeue()
        {
            if(size == 0)
                throw new InvalidOperationException("Queue is empty");
            T removed = array[head];
            array[head] = default(T);
            head = (head + 1) % array.Length;
            size--;
            return removed;
        }

        public T Peek()
        {
            if (size == 0)
                throw new InvalidOperationException("Queue is empty");

            return array[head];
        }

        private void SetCapacity(int capacity)
        {
            T[] newarray = new T[capacity];

            if (size > 0)
            {
                if (head < tail)
                {
                    Array.Copy(array, head, newarray, 0, size);
                }
                else
                {
                    Array.Copy(array, head, newarray, 0, array.Length - head);
                    Array.Copy(array, 0, newarray, array.Length - head, tail);
                }
            }

            array = newarray;
            head = 0;
            tail = (size == capacity) ? 0 : size;
        }

        internal T GetElement(int i)
        {
            return array[(head + i) % array.Length];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }
         
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public class Enumerator : IEnumerator<T>
        {
            private CustomQueue<T> queue;
            private int index;
            private T _currentElement;
            public Enumerator(CustomQueue<T> queue)
            {
                this.queue = queue;
                index = -1;
                _currentElement = default(T);
            }

            public bool MoveNext()
            {
                index++;

                if (index == queue.size)
                {
                    index = -2;
                    _currentElement = default(T);
                    return false;
                }

                _currentElement = queue.GetElement(index);
                return true;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

            public T Current {
                get
                {
                    if (index < 0)
                       throw new InvalidOperationException();

                    return _currentElement;
                }
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                index = -2;
                _currentElement = default(T);
            }
        }
    }
}
