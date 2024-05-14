namespace MyDataStructures;

public class LinkedListNode<T>
{
	private T _val;
	public LinkedListNode<T> Next { get; set; }

	public T Value 
	{
		get { return _val; }
		set { _val = value; } 
	}

	public LinkedListNode(T value) 
	{
		_val = value;
		Next = null;
	}
}

