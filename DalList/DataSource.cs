
using DO;


namespace Dal;
internal class DataSource
{
    public static readonly Random rand= new Random();
    private DataSource() { }
    internal static DataSource? s_instance { get; }=new DataSource();

    internal List<Product> lstP= new List<Product>();
    internal List<Order> lstO= new List<Order>();
    internal List<OrderItem> lstOI= new List<OrderItem>();
    public void addProduct(Product p)
    {
        lstP.Add(p);
    }
    public void addOrder(Order ord)
    {
        lstO.Add(ord);
    }
    public void addOrderItem(OrderItem ordi)
    {
        lstOI.Add(ordi);
    }

   private void s_Initialize()
    {

    }
    internal static class Config
    {
        internal const int s_startOrderNumber = 1000;
        private static int s_nextOrderNumber=s_startOrderNumber;
        internal static int NextOrderNumber { get => ++s_nextOrderNumber; }
    }


}
