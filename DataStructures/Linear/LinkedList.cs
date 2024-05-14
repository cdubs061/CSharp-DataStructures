namespace MyDataStructures;

public class LinkedList<T> : IList<T>, IEnumerable<T>
{	
	private int _count;
	private LinkedListNode<T> _root;

	public LinkedList()
	{
        _count = 0;
		_root = null;
	}
    
    public int Count
    {
        get { return _count; }
    }

	public void Insert(T val)
	{
		_root = Insert(_root, val);
	}

	private LinkedListNode<T> Insert(LinkedListNode<T> node, T val) 
	{
		if (node == null)
		{	
			node = new LinkedListNode<T>(val);
			_count++;
			return node;
		}
		else if (node.Next == null)
		{
			node.Next = new LinkedListNode<T>(val);
			_count++;
			return node;
		}
		else
		{
			node.Next = Insert(node.Next, val);
			return node;
		}
	}

	public void Delete(T val)
	{
        _root = Delete(_root, val);
    } 

    private LinkedListNode<T> Delete(LinkedListNode<T> node, T val)
    {
        if (node == null)
        {
            return null;
        }

        if (EqualityComparer<T>.Default.Equals(node.Value, val))
        {
            return node.Next;
        }
        
        node.Next = Delete(node.Next, val);
        return node;
    }


    public bool Contains(T val)
    {
        return Contains(_root, val);
    }

    private bool Contains(LinkedListNode<T> node, T val)
    {
        if(node == null)
        {
            return false;
        }
        else if (EqualityComparer<T>.Default.Equals(node.Value, val))
        {
            return true;
        }
        else if (node.Next != null)
        {
            return Contains(node.Next, val);
        }
        return false;
    }

    public T Get(int index)
    {
        return Get(_root, index);
    }

    private T Get(LinkedListNode<T> node, int index)
    {
        if (node == null || index < 0 || index > _count)
        {
            return default(T);
        }
        
        for (int i = 0; i < index; i++)
        {
            if (node.Next != null)
            {
                node = node.Next;
            }
            else
            {
                return default(T);
            }
        }
        
        return node.Value;
    }

    public IEnumerator<T> GetEnumerator()
    {
        LinkedListNode<T> current = _root;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator(); 
    }
}
