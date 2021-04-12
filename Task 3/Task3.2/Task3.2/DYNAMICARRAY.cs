using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Task3._2
{
    class DynamicArray<T> : IEnumerable<T>
    {
        internal T[] _array;
        int _capacity;
        int _lenght = -1;
        public T this[int index]
        {
            get
            {
                if (index > Lenght)
                    throw new ArgumentOutOfRangeException(nameof(index), "OutOfRangeException");
                return _array[index];
            }

            set => _array[index] = value;
        }

        public int Capacity
        {
            get => _capacity;
            set
            {
                _capacity = value;
                var tempArray = new T[_capacity];
                for (int i = 0; i < _array.Length; i++)
                {
                    tempArray[i] = _array[i];
                }
                _array = tempArray;
            }
        }
        public int Lenght 
        {
            get => _lenght;
            private set
            {
                _lenght = value;
                if (Capacity <= _lenght)
                {
                    int tempCount = Capacity;
                    do
                    {
                        tempCount *= 2;
                    } while (tempCount < _lenght);
                    Capacity = tempCount;
                }
            }
        }

        public DynamicArray()
        {           
            _array = new T[8];            
            Capacity = 8;
        }
        public DynamicArray(int Count)
        {
            
            _array = new T[Count];
            Lenght = Count;
        }
        public DynamicArray(IEnumerable<T> item)
        {
            _array = new T[0];
            Capacity = item.Count();
            AddRange(item);
        }


        public void Add(T item)
        {
            Lenght++;

            _array[Lenght] = item;

            //return true;
        }
        public bool AddRange(IEnumerable<T> item)
        {
            if (Capacity <= _lenght+item.Count())
            {
                int tempCount = Capacity;
                do
                {
                    tempCount *= 2;
                } while (tempCount < _lenght+ item.Count());
                Capacity = tempCount;
            }
            foreach (var i in item)
            {
                Add(i);
            }
            return true;
        }

        public bool Remove(T item)
        {
            var tempArray = new T[_capacity];
            int shift = 0;
            
            for (int i = 0; i < Lenght; i++)
            {
                if (Equals(_array[i], item))
                {
                    shift++;                    
                }
                tempArray[i] = _array[i+shift];
            }
            _array = tempArray;
            if (shift != 0)
            {
                Lenght -= shift;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void  Insert(T item,int pos)
        {
            var tempArray = new T[_capacity];
            if (pos > Lenght)
                throw new  ArgumentOutOfRangeException(nameof(pos), "Array index out ");
            
            Lenght++;
            for (int i = 0; i < Lenght; i++)
            {
                if (i < pos - 1)
                    tempArray[i] = _array[i];
                else if (i == pos - 1)
                    tempArray[i] = item;
                else
                    tempArray[i] =_array[i - 1];
            }            
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _array.GetEnumerator();
        }
    }
}
