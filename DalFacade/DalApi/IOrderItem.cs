using DO;

namespace DalApi;

public interface IOrderItem:  ICrud<OrderItem>
{
    List<OrderItem> GetByOrderID(int ID);   //maybe public
    OrderItem GetByIDOrder_IDProduct(int IDOrder, int IDProduct);
}
