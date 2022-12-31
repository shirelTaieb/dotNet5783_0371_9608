using System;
using DO;
using DalApi;
using DalList;

namespace Dal;
public class DataSource 
{
    public static readonly Random rand= new Random();
    private DataSource() => s_Initialize();
    internal static DataSource? s_instance { get; }=new DataSource();

    internal List<Product?> lstP= new List<Product?>();
    public List<Order?> lstO= new List<Order?>();
    internal List<OrderItem?> lstOI= new List<OrderItem?>();
    private void createProduct()//creating 11 product
    {
        Product p1 = new Product();
        p1.Category = DO.Category.Children;
        p1.Name = "Kipa aduma";
        p1.Price = rand.Next(50, 229);
        p1.ID = ConfigProduct.NextProductNumber;
        p1.InStock= rand.Next(0, 300);
        p1.path = @"C:\Users\97258\source\repos\shirelTaieb\dotNet5783_0371_9608\PL\images\book.png";
        lstP.Add(p1);

        Product p2 = new Product();
        p2.Category = DO.Category.Children;
        p2.Name = "Aladin";
        p2.Price = rand.Next(50, 229);
        p2.ID = ConfigProduct.NextProductNumber;
        p2.InStock = rand.Next(0, 300);
        p2.path = @"C:\Users\97258\source\repos\shirelTaieb\dotNet5783_0371_9608\PL\images\book.png";
        lstP.Add(p2);

        Product p3 = new Product();
        p3.Category = DO.Category.Children;
        p3.Name = "to the sea";
        p3.Price = rand.Next(50, 229);
        p3.ID = ConfigProduct.NextProductNumber;
        p3.InStock = rand.Next(0, 300);
        p3.path = @"C:\Users\97258\source\repos\shirelTaieb\dotNet5783_0371_9608\PL\images\book.png";
        lstP.Add(p3);

        Product p4 = new Product();
        p4.Category = DO.Category.Holy;
        p4.Name = "bereshit";
        p4.Price = rand.Next(50, 229);
        p4.ID = ConfigProduct.NextProductNumber;
        p4.InStock = rand.Next(0, 300);
        p4.path = @"C:\Users\97258\source\repos\shirelTaieb\dotNet5783_0371_9608\PL\images\book.png";
        lstP.Add(p4);

        Product p5 = new Product();
        p5.Category = DO.Category.Holy;
        p5.Name = "The Rambam";
        p5.Price = rand.Next(50, 229);
        p5.ID = ConfigProduct.NextProductNumber;
        p5.InStock = rand.Next(0, 300);
        p5.path = @"C:\Users\97258\source\repos\shirelTaieb\dotNet5783_0371_9608\PL\images\book.png";
        lstP.Add(p5);

        Product p6 = new Product();
        p6.Category = DO.Category.Theoretical;
        p6.Name = "All about labor";
        p6.Price = rand.Next(50, 229);
        p6.ID = ConfigProduct.NextProductNumber;
        p6.InStock = rand.Next(0, 300);
        p6.path = @"C:\Users\97258\source\repos\shirelTaieb\dotNet5783_0371_9608\PL\images\book.png";
        lstP.Add(p6);

        Product p7 = new Product();
        p7.Category = DO.Category.Theoretical;
        p7.Name = "How to improve your self-confidance";
        p7.Price = rand.Next(50, 229);
        p7.ID = ConfigProduct.NextProductNumber;
        p7.InStock = rand.Next(0, 300);
        p7.path = @"C:\Users\97258\source\repos\shirelTaieb\dotNet5783_0371_9608\PL\images\book.png";
        lstP.Add(p7);

        Product p8 = new Product();
        p8.Category = DO.Category.Theoretical;
        p8.Name = "Loyalty";
        p8.Price = rand.Next(50, 229);
        p8.ID = ConfigProduct.NextProductNumber;
        p8.InStock = 0;
        p8.path = @"C:\Users\97258\source\repos\shirelTaieb\dotNet5783_0371_9608\PL\images\book.png";
        lstP.Add(p8);

        Product p9 = new Product();
        p9.Category = DO.Category.History;
        p9.Name = "World War 2";
        p9.Price = rand.Next(50, 229);
        p9.ID = ConfigProduct.NextProductNumber;
        p9.InStock = rand.Next(0, 300);
        p9.path = @"C:\Users\97258\source\repos\shirelTaieb\dotNet5783_0371_9608\PL\images\book.png";
        lstP.Add(p9);

        Product p10 = new Product();
        p10.Category = DO.Category.History;
        p10.Name = "The History of Israel";
        p10.Price = rand.Next(50, 229);
        p10.ID = ConfigProduct.NextProductNumber;
        p10.InStock = rand.Next(0, 300);
        p10.path = @"C:\Users\97258\source\repos\shirelTaieb\dotNet5783_0371_9608\PL\images\book.png";
        lstP.Add(p10);

        Product p11 = new Product();
        p11.Category = DO.Category.Romans;
        p11.Name = "Harry Potter 3";
        p11.Price = rand.Next(50, 229);
        p11.ID = ConfigProduct.NextProductNumber;
        p11.InStock = rand.Next(0, 300);
        p11.path = @"C:\Users\97258\source\repos\shirelTaieb\dotNet5783_0371_9608\PL\images\book.png";
        lstP.Add(p11);

    }
    public void createOrder()//creating a new Order
    {
        string[] names= {"Shirel", "Tamar", "Shana","Samuel", "Shely", "David","Golda","Miryam","Maayan",
                               "TehiLa","Hadar","Avraham","Noa","Rebecca","Roni","Noam","Lital","Andi","Tara","Lola",
                               "Tal","Ishay","Sara","Naomie","Nina","Michael","Ari","Refael","Dan","Julia","Shay","Josh",
                               "Natlie","Boaz","Lea","Avigail","rachel","joe","Shira","Halel","Shlomo","Omer","Aviv","Or"}; //data source of names

        string[] Adresses = {"Rananna","Jerusalem","Paris","Madrid","Torento","Avivim","New York","Tel Aviv","Lod",
                                   "Lisbon","Berlin","Metola","Eilat","Netivot","Ashdod","Ashkelon","Natanya","Tokyo",
                                   "Mexico City","Havanna","Lima","Beer Shaeva","Omer","Tzfat","Nazeret","Tiberiad","Raba",
                                   "Pretoria","Sidny","Givataim","Ariel","Ramat Gan","Ramat Hasharon","Petah Tikva","Yerocham"}; //data source of adress

        for (int i = 0; i < 21; i++)
        {
            Order order = new Order();
            order.ID = ConfigOrder.NextOrderNumber;
            order.CustomerName = names[rand.Next(0, 43)];
            order.CustomerAddress = Adresses[rand.Next(0, 34)];
            order.CustomerEmail = order.CustomerName + "@gmail.com";
            Random s_rand = new Random();
            order.OrderDate = DateTime.Now - new TimeSpan(s_rand.NextInt64(10L * 1000L * 1000L * 3600L * 24L * 100L));
            order.ShipDate = DateTime.Now - new TimeSpan(s_rand.NextInt64(10L * 1000L * 1000L * 3600L * 24L * 100L));
            order.DeliveryDate = DateTime.Now - new TimeSpan(s_rand.NextInt64(10L * 1000L * 1000L * 3600L * 24L * 100L));
            if(i<=16)
                order.DeliveryDate= DateTime.Now - new TimeSpan(s_rand.NextInt64(10L * 1000L * 1000L * 3600L * 24L * 200L));
            if(i<=8)
                order.DeliveryDate = null;
            if (i <= 4)
                order.ShipDate = null;
            lstO.Add(order);
        }
    }
    public void createOrderItem()
    {
        for (int i = 0; i < 21; i++)
        {
            int order_id= ConfigOrderItem1.NextOrderNumber;
            for (int j = 0; j < rand.Next(1,10); j++)
            {
                OrderItem orderItem = new OrderItem();
                orderItem.ID = ConfigOrderItem2.NextOrderNumber;
                orderItem.OrderID = order_id;
                orderItem.Amount= rand.Next(10);
                orderItem.ProductID = rand.Next(100000, 100011);
                //לא עובד הלינקק
                //var result =
                //    from temp in lstP
                //    where temp?.ID == orderItem.ProductID
                //    select (orderItem.Price = temp?.Price);


                foreach (Product temp in lstP)
                {
                    if (temp.ID == orderItem.ProductID)
                        orderItem.Price = temp.Price;
                }
                lstOI.Add(orderItem);
            }    
        }
    }

    private void s_Initialize()
    {
        createProduct();
        createOrder();
        createOrderItem();
    }
    internal static class ConfigOrder
    {
        internal const int s_startOrderNumber = 1000;
        private static int s_nextOrderNumber=s_startOrderNumber;
        internal static int NextOrderNumber { get => ++s_nextOrderNumber; }
    }
    internal static class ConfigProduct

    {
        internal const int s_startProductNumber = 100000;
        private static int s_nextProductNumber = s_startProductNumber;
        internal static int NextProductNumber { get => ++s_nextProductNumber; }
    }
    internal static class ConfigOrderItem1
    {
        internal const int s_startOrderNumber = 1000;
        private static int s_nextOrderNumber = s_startOrderNumber;
        internal static int NextOrderNumber { get => ++s_nextOrderNumber; }
    }
    internal static class ConfigOrderItem2
    {
        internal const int s_startOrderNumber = 1000;
        private static int s_nextOrderNumber = s_startOrderNumber;
        internal static int NextOrderNumber { get => ++s_nextOrderNumber; }
    }
}
