using System;
using DO;
using DalApi;

namespace Dal;
internal class DataSource
{
    public static readonly Random rand= new Random();
    private DataSource() => s_Initialize();
    internal static DataSource? s_instance { get; }=new DataSource();

    internal List<Product?> lstP= new List<Product?>();
    internal List<Order?> lstO= new List<Order?>();
    internal List<OrderItem?> lstOI= new List<OrderItem?>();
    public void createProduct()
    {
        string[] categories = { "Children", "Holy", "Theoretical", "Romans", "History" };
        string[] ChildrenBook = { "Kipa aduma", "Aladin", "to the see", "Dora", "I love mama" };
        string[] HolyBooks = { "bereshit", "shmot", "talmud bavly", "the holy day", "rambam" };
        string[] TheoryBook = { "how To grow", "loyalty", "all about labor", "Am I seck?", "How to improve your self-confidance" };
        string[] HistoryBooks = { "world war 2", "Bibi", "the History of Israel","Natsizem","white book" };
        string[] AdultBooks = { "Harry Potter 1", "Harry Potter 2", "Harry Potter 3", "Harry Potter 4", "Harry Potter 5" };
       
        for (int i =0;i>20;i++)
        {
            Product p = new Product();
            int k =rand.Next(5);
            p.Category= categories[k];

            switch (k)
            {
                case 0:
                    p.Name = ChildrenBook[rand.Next(5)];
                    break;
                case 1:
                    p.Name = HolyBooks[rand.Next(5)];
                    break;
                case 2:
                    p.Name = TheoryBook[rand.Next(5)];
                    break;
                case 3:
                    p.Name = HistoryBooks[rand.Next(5)];
                    break;
                case 4:
                    p.Name = AdultBooks[rand.Next(5)];
                    break;
            }
            float price = rand.Next(50, 229);   
            p.Price = price;
            p.ID = Config.NextOrderNumber;
            if (p.Name == "Harry Potter 3" || p.Name == "Harry Potter 2")
                p.InStuck = 0;
           else
                p.InStuck = rand.Next(0, 20);
            lstP.Add(p);
        }
        
    }
    public void createOrder()
    {
        Order order = new();
        Random s_rand= new Random();    
        order.OrderDate = DateTime.Now - new TimeSpan(s_rand.NextInt64(10L * 1000L * 1000L * 3600L * 24L * 100L));
    }
    public void createOrderItem()
    {
        
    }

   private void s_Initialize()
    {
        createProduct();
        createOrder();
        createOrderItem();

    }
    internal static class Config
    {
        internal const int s_startOrderNumber = 100000;
        private static int s_nextOrderNumber=s_startOrderNumber;
        internal static int NextOrderNumber { get => ++s_nextOrderNumber; }
    }


}
