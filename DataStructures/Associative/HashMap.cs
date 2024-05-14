namespace MyDataStructures;

public class HashMap<TKey, TValue>
{
    private class Entry
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        
        public Entry(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }

    private LinkedList<Entry>[] list;
    private int Length;

    public HashMap()
    {
        list = new LinkedList<Entry>[32];
        for (int i = 0; i < list.Length; i++)
        {
            list[i] = new LinkedList<Entry>();
        }
    }

    public bool Put(TKey key, TValue value)
    {
        int hash = key.GetHashCode();
        hash = Math.Abs(hash % list.Length);
        
        foreach (var item in list[hash])
        {
            if (item.Key.Equals(key))
            {
                item.Value = value;
                return false;
            }
        }

        list[hash].Insert(new Entry(key, value));
        return true;
    }

    public bool Remove(TKey key)
    { 
        int hash = key.GetHashCode();
        hash = Math.Abs(hash % list.Length);
        
        foreach (var item in list[hash])
        {
            if (item.Key.Equals(key))
            {
                list[hash].Delete(item);
                return true;
            }
        }
        return false;
    }

    public TValue Get(TKey key)
    {
        int hash = key.GetHashCode();
        hash = Math.Abs(hash % list.Length);
        
        foreach (var item in list[hash])
        {
            if (item.Key.Equals(key))
            {
                return item.Value;
            }
        }

        throw new KeyNotFoundException($"Key not found: {key}");
    }
}
