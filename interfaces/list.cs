namespace MyDataStructures;

public interface IList<T>
{
	int Count { get; }
    void Insert(T val);
	void Delete(T val);
	bool Contains(T val);
	T Get(int index);
}
