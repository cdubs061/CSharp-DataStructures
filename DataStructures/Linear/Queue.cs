namespace MyDataStructures;

public class Queue<T>
{
    public int Count { get; private set; }
    private LinkedListNode<T> _head;
    private LinkedListNode<T> _tail;

    public Queue()
    {
        _head = null;
        _tail = null;
    }

    public void Push(T val)
    {
        if (_head == null)
        {
            _head = new LinkedListNode<T>(val);
            _head.Next = null;
            _tail = _head;
            Count++;
        }
        else
        {
            _tail.Next = new LinkedListNode<T>(val);
            _tail = _tail.Next;
            Count++;
        }
    }

    public T Pop()
    {
        if (_head == null)
        {
            return default(T);
        }
        T ret = _head.Value;
        _head = _head.Next;
        if (_head ==null)
        {
            _tail = null;
        }
        Count--;
        return ret;
    }
}
