namespace HashTable.Core
{
    public class HashTable<KeyType, ValueType> where KeyType : notnull
    {
        private class LinkedListNode
        {
            public LinkedListNode(KeyType key, ValueType value)
            {
                Key = key;
                Value = value;
                Prev = null;
                Next = null;
            }

            public LinkedListNode? Prev { get; set; }
            public LinkedListNode? Next { get; set; }
            public KeyType Key { get; private set; }
            public ValueType Value { get; private set; }

            public void UpdateValue(ValueType newValue)
            {
                Value = newValue;
            }
        }

        private LinkedListNode[] Items { get; set; }

        public HashTable(int capacity)
        {
            Items = new LinkedListNode[capacity];
        }

        public void Add(KeyType key, ValueType value)
        {
            LinkedListNode? node = GetNodeForKey(key);
            if (node != null)
            {
                node.UpdateValue(value); // just update the value
            }
            else
            {
                node = new LinkedListNode(key, value);
                int index = GetIndexForKey(key);
                if (Items[index] != null)
                {
                    node.Next = Items[index];
                    node.Next.Prev = node;
                }

                Items[index] = node;
            }
        }

        public ValueType? Get(KeyType key)
        {
            LinkedListNode? node = GetNodeForKey(key);
            return node != null ? node.Value : default;
        }

        public bool Remove(KeyType key)
        {
            LinkedListNode? nodeToBeRemoved = GetNodeForKey(key);
            if (nodeToBeRemoved == null)
            {
                return false;
            }

            if (nodeToBeRemoved.Prev != null)
            {
                nodeToBeRemoved.Prev.Next = nodeToBeRemoved.Next;
            }
            else // Removing head
            {
                int hashKey = GetIndexForKey(key);
                Items[hashKey] = nodeToBeRemoved.Next;
            }

            if (nodeToBeRemoved.Next != null)
            {
                nodeToBeRemoved.Next.Prev = nodeToBeRemoved.Prev;
            }

            return true;
        }

        /// <summary>
        /// Get LinkedListNode associated with a given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private HashTable<KeyType, ValueType>.LinkedListNode? GetNodeForKey(KeyType key)
        {
            int index = GetIndexForKey(key);
            LinkedListNode? current = Items[index];
            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    return current;
                }

                current = current.Next;
            }

            return null;
        }

        /// <summary>
        /// Map the given key to an index
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int GetIndexForKey(KeyType key)
        {
            return Math.Abs(key.GetHashCode() % Items.Length);
        }
    }
}
