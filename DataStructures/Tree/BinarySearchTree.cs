namespace MyDataStructures;

public class BinarySearchTree<T> where T : IComparable<T>
{
	private TreeNode<T> _root;
    private Comparer<T> comparer;

    public BinarySearchTree(Comparer<T> comparer = null)
    {
        this.comparer = comparer ?? Comparer<T>.Default;
    }

    private void AddNode(T val)
    {
        _root = AddNode(_root, val);
    }

    public TreeNode<T> AddNode(TreeNode<T> node, T val)
    {
        if (node == null)
        {
            node = new TreeNode<T>(val);
            return node;
        }

        int compare = val.CompareTo(node.Value);
        if (compare < 0)
        {
            node.Left = AddNode(node.Left, val);
        }
        else if (compare > 0)
        {
            node.Right = AddNode(node.Right, val);
        } 
        return node;
    }

    private void DeleteNode(T val)
    {
        _root = DeleteNode(_root, val);
    }

    public TreeNode<T> DeleteNode(TreeNode<T> node, T val)
    {
        if (node == null)
        {
            return null;
        }

        int compare = val.CompareTo(node.Value);
        if (compare < 0)
        {
            node.Left = DeleteNode(node.Left, val);
        }
        else if (compare > 0)
        {
            node.Right = DeleteNode(node.Right, val);
        }
        else
        {
            if (node.Left != null && node.Right != null)
            {
                TreeNode<T> successor = Min(node.Right);
                node.Value = successor.Value;
                node.Right = DeleteNode(node.Right, successor.Value);
            }
            else
            {
                node = (node.Left != null) ? node.Left : node.Right;
            }
        }
        return node;
    }

    public bool Search(T val)
    {
        TreeNode<T> node = Search(_root, val);
        return node != null; 
    }

    private TreeNode<T> Search(TreeNode<T> node, T val)
    {
        if (node == null)
        {
            return null;
        }

        int compare = val.CompareTo(node.Value);
        if (compare < 0)
        {
            return Search(node.Left, val);
        }
        else if (compare > 0)
        {
            return Search(node.Right, val);
        }
        return node;
    }

    public int Height()
    {
        return Height(_root);
    }

    private int Height(TreeNode<T> node)
    {
        int left = 0;
        int right = 0;
        if (node == null)
        {
            return 0;
        }
        else
        {
            left = Height(node.Left);
            right = Height(node.Right);
        }

        if (left > right)
        {
            return left + 1;
        }
        return right + 1;
    }
    
    public void LevelOrderTraversal()
    {
        Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
        queue.Push(_root);

        while (queue.Count != 0)
        {
            TreeNode<T> node = queue.Pop();
            Console.Write(node + ", ");

            if (node.Left != null)
            {
                queue.Push(node.Left);
            }
            
            if (node.Right != null)
            {
                queue.Push(node.Right);
            }
        }
    }

    private TreeNode<T> Min(TreeNode<T> node)
    {
        if (node == null)
        {
            return null;
        }

        while (node.Left != null)
        {
            node = node.Left;
        }

        return node;
    }
}

