using DalApi;
using System;


namespace Dal;

sealed internal class DalList : IDal
{
    public IOrder Order => new DalOrder();
    public IProduct Product => new DalProduct();
    public IOrderItem OrderItem => new DalOrderItem();
}
