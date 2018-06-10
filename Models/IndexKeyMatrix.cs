using System;
using System.Collections.Generic;
namespace KursachAttemp2.Models
{
    [Serializable]
    public class IndexKeyMatrix<T1, T2> //T1 - key type, T2 - value type;
    {
        private Dictionary<T1, int> _keyToIndex = new Dictionary<T1, int>();
        private T2[,] _timeMatrix;
        private int _lastIndex = 0;
        public int NumberOfUniquePoints { get; private set; }
        public IndexKeyMatrix(int numberOfUniquePoints)
        {
            NumberOfUniquePoints = numberOfUniquePoints;
            _timeMatrix = new T2[NumberOfUniquePoints, NumberOfUniquePoints];
        }
        public void Add(T2 value, T1 row, T1 col)
        {
            int rowi;
            int coli;
            if (!_keyToIndex.TryGetValue(row, out rowi))
            {
                rowi = _lastIndex;
                _keyToIndex.Add(row, rowi);
                _lastIndex++;
            }
            if (!_keyToIndex.TryGetValue(col, out coli))
            {
                coli = _lastIndex;
                _keyToIndex.Add(col, coli);
                _lastIndex++;
            }
            _timeMatrix[rowi, coli] = value;
        }
        public T2 this[int i, int j]
        {
            get { return _timeMatrix[i, j]; }
            set { _timeMatrix[i, j] = value; }
        }
        public T2 this[T1 i, T1 j]
        {
            get { return _timeMatrix[_keyToIndex[i], _keyToIndex[j]]; }
            set { _timeMatrix[_keyToIndex[i], _keyToIndex[j]] = value; }
        }
        public int this[T1 key]
        {
            get { return _keyToIndex[key]; }
        }
        public T1 this[int key]
        {
            get
            {
                foreach(var pair in _keyToIndex)
                {
                    if (pair.Value == key)
                        return pair.Key;
                }
                return default(T1);
            }
        }
    }
}
