namespace MyDataStructures;

public class Heap<T> where T : IComparable<T>
{
    private List<T> _list;
    private int Size { get; set; }
    public bool IsEmpty => Size == 0;

    public Heap()
    {
        _list = new List<T>();
    }

    public void Insert(T val)
    {
        _list.Add(val);
        Size++;
        HeapifyUp(Size - 1);
    }

    public T ExtractMax()
    {
        T value = _list[0];
        _list[0] = _list[Size-1];
        _list.RemoveAt(Size-1);
        Size--;
        if (Size > 0)
        {
            HeapifyDown(0);
        }
        return value;
    }

    private void HeapifyUp(int index)
    {
        while (index > 0)
        {
            int parent = (index - 1) / 2;
            if (_list[index].CompareTo(_list[parent]) <= 0) break;

            T temp = _list[index];
            _list[index] = _list[parent];
            _list[parent] = temp;

            index = parent;
        }
    }

    private void HeapifyDown(int index)
    {
        while (index < Size)
        {
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;
            int largest = index;

            if (leftChild < Size && _list[leftChild].CompareTo(_list[largest]) > 0)
            {
                largest = leftChild;
            }

            if (rightChild < Size && _list[rightChild].CompareTo(_list[largest]) > 0)
            {
                largest = rightChild;
            }

            if (largest == index) break;

            T temp = _list[index];
            _list[index] = _list[largest];
            _list[largest] = temp;

            index = largest;
        }
    }
}
