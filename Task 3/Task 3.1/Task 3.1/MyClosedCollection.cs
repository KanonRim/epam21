using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task_3._1
{
    class MyClosedCollection<T> : IEnumerable<T>
    {
        private T[] _mas;
        public MyClosedCollection()
        {
            Mas = Array.Empty<T>();
        }
        public MyClosedCollection(T[] mas)
        {
            Mas = mas;
        }

        public int Length { get => _mas.Length;}

        public T[] Mas { get => _mas; set => _mas = value; }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
           T[] newMas = new T [Mas.Length + 1];
            for (int i = 0; i < Mas.Length; i++)
            {
                newMas[i] = Mas[i];
            }
            newMas[Mas.Length] = item;
            Mas = newMas;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ((ICollection<T>)Mas).CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MySuperCollectionEnumerator<T>(Mas);
            //return _person.GetEnumerator();
        }

        public bool Remove(T item)
        {
            //crutch
            bool r;
            List<T> bufMas =  _mas.ToList();
            r=  bufMas.Remove(item);
            _mas = bufMas.ToArray();
            return r;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MySuperCollectionEnumerator<T>(Mas);
            //return _person.GetEnumerator();
        }

        public class MySuperCollectionEnumerator<T> : IEnumerator<T>
        {
            int position = -1;
            T[] _mas;
            public MySuperCollectionEnumerator(T[] mas)
            {
                _mas = mas;
            }
            public object Current
            {
                get
                {
                    if (position == -1)
                        throw new InvalidOperationException();
                    while (position >= _mas.Length)
                    {
                        position -= _mas.Length;
                    }
                    return _mas[position];
                }
            }

            T IEnumerator<T>.Current
            {
                get
                {
                   return (T)Current;
                }
            }

            public void Dispose()
            {
                // TODO: реализовать интерфейс IDisposable
            }

            public bool MoveNext(int next = 1)
            {
                position+=next;
                if (position > _mas.Length)
                {
                    position -= _mas.Length;
                }
                return true;
            }

            public bool MoveNext()
            {
                position++;
                if (position > _mas.Length)
                {
                    position -= _mas.Length;
                }
                return true;
            }

            public void Reset()
            {
                position = -1;
            }


        }
    }
}
