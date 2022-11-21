using System;
using DO;
using DalApi;
using DalList;

namespace Dal;
internal class DataSource //data 
{
    public static readonly Random rand= new Random();
    private DataSource() => s_Initialize();
    internal static DataSource? s_instance { get; }=new DataSource();

    internal List<Product> lstP= new List<Product>();
    internal List<Order> lstO= new List<Order>();
    internal List<OrderItem> lstOI= new List<OrderItem>();
    private void createProduct()//creating 11 product
    {
        Product p1 = new Product();
        p1.Category = "Children";
        p1.Name = "Kipa aduma";
        p1.Price = rand.Next(50, 229);
        p1.ID = ConfigProduct.NextProductNumber;
        p1.InStuck= rand.Next(0, 300);
        lstP.Add(p1);

        Product p2 = new Product();
        p2.Category = "Children";
        p2.Name = "Aladin";
        p2.Price = rand.Next(50, 229);
        p2.ID = ConfigProduct.NextProductNumber;
        p2.InStuck = rand.Next(0, 300);
        lstP.Add(p2);

        Product p3 = new Product();
        p3.Category = "Children";
        p3.Name = "to the sea";
        p3.Price = rand.Next(50, 229);
        p3.ID = ConfigProduct.NextProductNumber;
        p3.InStuck = rand.Next(0, 300);
        lstP.Add(p3);

        Product p4 = new Product();
        p4.Category = "Holy";
        p4.Name = "bereshit";
        p4.Price = rand.Next(50, 229);
        p4.ID = ConfigProduct.NextProductNumber;
        p4.InStuck = rand.Next(0, 300);
        lstP.Add(p4);

        Product p5 = new Product();
        p5.Category = "Holy";
        p5.Name = "The Rambam";
        p5.Price = rand.Next(50, 229);
        p5.ID = ConfigProduct.NextProductNumber;
        p5.InStuck = rand.Next(0, 300);
        lstP.Add(p5);

        Product p6 = new Product();
        p6.Category = "Theoretical";
        p6.Name = "All about labor";
        p6.Price = rand.Next(50, 229);
        p6.ID = ConfigProduct.NextProductNumber;
        p6.InStuck = rand.Next(0, 300);
        lstP.Add(p6);

        Product p7 = new Product();
        p7.Category = "Theoretical";
        p7.Name = "How to improve your self-confidance";
        p7.Price = rand.Next(50, 229);
        p7.ID = ConfigProduct.NextProductNumber;
        p7.InStuck = rand.Next(0, 300);
        lstP.Add(p7);

        Product p8 = new Product();
        p8.Category = "Theoretical";
        p8.Name = "Loyalty";
        p8.Price = rand.Next(50, 229);
        p8.ID = ConfigProduct.NextProductNumber;
        p8.InStuck = 0;
        lstP.Add(p8);

        Product p9 = new Product();
        p9.Category = "History";
        p9.Name = "World War 2";
        p9.Price = rand.Next(50, 229);
        p9.ID = ConfigProduct.NextProductNumber;
        p9.InStuck = rand.Next(0, 300);
        lstP.Add(p9);

        Product p10 = new Product();
        p10.Category = "History";
        p10.Name = "The History of Israel";
        p10.Price = rand.Next(50, 229);
        p10.ID = ConfigProduct.NextProductNumber;
        p10.InStuck = rand.Next(0, 300);
        lstP.Add(p10);

        Product p11 = new Product();
        p11.Category = "Romans";
        p11.Name = "Harry Potter 3";
        p11.Price = rand.Next(50, 229);
        p11.ID = ConfigProduct.NextProductNumber;
        p11.InStuck = rand.Next(0, 300);
        lstP.Add(p11);

        //string[] categories = { "Children", "Holy", "Theoretical", "Romans", "History" };
        //string[] ChildrenBook = { "Kipa aduma", "Aladin", "to the sea", "Dora", "I love mama" };
        //string[] HolyBooks = { "bereshit", "shmot", "talmud bavly", "the holydays", "rambam" };
        //string[] TheoryBook = { "how To grow", "loyalty", "all about labor", "Am I seck?", "How to improve your self-confidance" };
        //string[] HistoryBooks = { "world war 2", "Bibi", "the History of Israel","Natsizem","white book" };
        //string[] AdultBooks = { "Harry Potter 1", "Harry Potter 2", "Harry Potter 3", "Harry Potter 4", "Harry Potter 5" };
        //for (int i =0;i<20;i++)
        //{
        //Product p = new Product();
        // int k =rand.Next(5); 
        // p.Category= categories[k];
        //switch (k)
        //{
        //case 0:
        //p.Name = ChildrenBook[rand.Next(5)];
        //break;
        //case 1:
        //p.Name = HolyBooks[rand.Next(5)];
        //break;
        //case 2:
        //p.Name = TheoryBook[rand.Next(5)];
        //break;
        //case 3:
        //p.Name = HistoryBooks[rand.Next(5)];
        //break;
        //case 4:
        //p.Name = AdultBooks[rand.Next(5)];
        // break;
        //}
        //float price = rand.Next(50, 229);   
        //p.Price = price;
        //p.ID = Config.NextOrderNumber;
        //if (p.Name == "Harry Potter 3" || p.Name == "Harry Potter 2")
        //p.InStuck = 0;
        //else
        //p.InStuck = rand.Next(0, 20);
        //lstP.Add(p);
        //}
    }
    public void createOrder()//creating a new Order
    {
        string[] names= {"Shirel", "Tamar", "Shana","Samuel", "Shely", "David","Golda","Miryam","Maayan",
                               "TehiLa","Hadar","Avraham","Noa","Rebecca","Roni","Noam","Lital","Andi","Tara","Lola",
                               "Tal","Ishay","Sara","Naomie","Nina","Michael","Ari","Refael","Dan","Julia","Shay","Josh",
                               "Natlie","Boaz","Lea","Avigail","rachel","joe","Shira","Halel","Shlomo","Omer","Aviv","Or"}; //data source of names

        string[] costomerAdress = {"Rananna","Jerusalem","Paris","Madrid","Torento","Avivim","New York","Tel Aviv","Lod",
                                   "Lisbon","Berlin","Metola","Eilat","Netivot","Ashdod","Ashkelon","Natanya","Tokyo",
                                   "Mexico City","Havanna","Lima","Beer Shaeva","Omer","Tzfat","Nazeret","Tiberiad","Raba",
                                   "Pretoria","Sidny","Givataim","Ariel","Ramat Gan","Ramat Hasharon","Petah Tikva","Yerocham"}; //data source of adress

        for (int i = 0; i < 21; i++)
        {
            Order order = new();
            order.ID = Config.NextOrderNumber;
            order.CostumerName = names[rand.Next(0, 43)];
            order.CostumerAdress = names[rand.Next(0, 43)];
            order.CostumerEmail = order.CostumerName + "@gmail.com";
            Random s_rand = new Random();
            order.OrderDate = DateTime.Now - new TimeSpan(s_rand.NextInt64(10L * 1000L * 1000L * 3600L * 24L * 100L));
            order.ShipDate = DateTime.Now - new TimeSpan(s_rand.NextInt64(10L * 1000L * 1000L * 3600L * 24L * 100L));
            order.DeliveryDate = DateTime.Now - new TimeSpan(s_rand.NextInt64(10L * 1000L * 1000L * 3600L * 24L * 100L));
            if(i<=16)
            {
                order.DeliveryDate= DateTime.Now - new TimeSpan(s_rand.NextInt64(10L * 1000L * 1000L * 3600L * 24L * 200L));
            }
            if(i<=8)
            {
                order.DeliveryDate = null;
            }
            lstO.Add(order);
        }
    }
    public void createOrderItem()
    {
        for (int i = 0; i < 21; i++)
        {
            int num= ConfigOrderItem1.NextOrderNumber;
            for (int j = 0; j < rand.Next(4); j++)
            {
                OrderItem orderItem = new OrderItem();
                orderItem.ID = ConfigOrderItem2.NextOrderNumber;
                orderItem.OrderID = num;
                orderItem.Amount= rand.Next(10);
                orderItem.ProductID = rand.Next(1000, 1011);
                foreach(Product temp in lstP)
                {
                    if (temp.ID == orderItem.ProductID)
                        orderItem.Price= temp.Price;    
                }
            
            }    
            
        }
    }

    private void s_Initialize()
    {
        createProduct();
        createOrder();
        createOrderItem();
    }
    internal static class Config
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
