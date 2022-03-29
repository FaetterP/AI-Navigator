using System;

namespace Assets.Utilities
{
    class CycleArray<T>
    {
        private T[] _array;
        private int _index;


        public CycleArray(T[] array)
        {
            _array = new T[array.Length];
            Array.Copy(array, _array, array.Length);
            _index = 0;
        }

        public T GetNext()
        {
            T ret = _array[_index];
            _index = (_index + 1) % _array.Length;
            return ret;
        }

    }
}
