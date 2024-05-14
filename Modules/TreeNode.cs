namespace MyDataStructures;

public class TreeNode<T>
{
	private T _val;
	private TreeNode<T>? _left;
	private TreeNode<T>? _right;

    public TreeNode<T> Right
    {
        get { return _right; }
        set { _right = value; }
    }

    public TreeNode<T> Left
    {
        get { return _left; }
        set { _left = value; }
    }

    public T Value
    {
        get { return _val; }
        set { _val = value; }
    }

	public TreeNode(T val)
	{
		_val = val;
		_left = null;
		_right = null;
	}
}
