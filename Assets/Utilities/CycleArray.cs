using System;

namespace Assets.Utilities
{
    class CycleArray<T>
    {
        private T[] _array;
        private int _index;
        public int Index => _index;

        public CycleArray(T[] array)
        {
            _array = new T[array.Length];
            Array.Copy(array, _array, array.Length);
            _index = 0;
        }

        public T GetNext()
        {
            _index = (_index + 1) % _array.Length;
            T ret = _array[_index];
            return ret;
        }

    }
}
