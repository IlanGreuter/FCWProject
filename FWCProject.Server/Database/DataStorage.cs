using System.Collections.Generic;

namespace FCWProject.Database
{
    /// <summary>
    /// This class is essentially a mock of a database. It has a queue that will keep its size at a set capacity. 
    /// Note that it is not persistent storage.
    /// </summary>
    public class DataStorage
    {
        private Queue<DataPoint> _storage;

        private const int STORAGE_SIZE = 10;

        public DataStorage()
        {
            _storage = new Queue<DataPoint>(STORAGE_SIZE);
        }

        /// <summary>
        /// Write a datapoint to the storage.
        /// </summary>
        public void Write(DataPoint data)
        {
            _storage.Enqueue(data);
            if (_storage.Count == STORAGE_SIZE)
            {
                // Dequeue and toss the first datapoint to prevent queue from growing too big.
                _storage.Dequeue();
            }
        }

        /// <summary>
        /// Returns the latest X datapoints from the storage
        /// </summary>
        /// <param name="amountToRead">Number of datapoints to read</param>
        /// <returns>A list containing the latest datapoints in the storage</returns>
        public List<DataPoint> GetLatest(int amountToRead) => _storage.TakeLast(amountToRead).ToList();
    }
}
