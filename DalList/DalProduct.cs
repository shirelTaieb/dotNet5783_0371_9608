using DO;

namespace Dal;

public class DalProduct
{
    public int Add(Product item)
    {

    }
    T GetById(int id);
    void Update(T item);
    void Delete(int id);

    //IEnumerable<T?> GetAll(Func<T?, bool>? filter = null);
    IEnumerable<T> GetAll();
}
