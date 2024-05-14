namespace MyDataStructures;

public class Stack<T>
{       
    private LinkedListNode<T> _head;

    public Stack()
    {
        _head = null;
    }

    public void Push(T val)
    {
        if (_head == null)
        {
            _head = new LinkedListNode<T>(val);
            _head.Next = null;
        }
        else 
        {
            LinkedListNode<T> temp = new LinkedListNode<T>(val);
            temp.Next = _head;
            _head = temp;
        }
    }

    public T Pop()
    {
       if (_head == null)
       {
            throw new InvalidOperationException("Stack is empty");
       }
       else
       {
            T temp = _head.Value;
            _head = _head.Next;
            return temp;
       }
    }
}
