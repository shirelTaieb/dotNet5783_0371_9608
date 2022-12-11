//using System;
//using System.Security.Cryptography.X509Certificates;
//using DalApi;
//using DO;
//namespace Dal;
//public class Program //main program
//{
//    public static void Main(string[] args)
//    {
//        IDal dalist;
//        //DalProduct product = new DalProduct();
//        //DalOrder order = new DalOrder();
//        //DalOrderItem item = new DalOrderItem();
//        int num = 1;
//        while (num != 0)
//        {
//            Console.WriteLine(@"Hello!
//                Enter your choice:
//                0-exit
//                1-test Order
//                2-test OrderItem
//                3-test Product");
//            string? option = Console.ReadLine();
//            bool b = int.TryParse(option, out num);
//            if (!b)// if the option they choose is incorect
//            {
//                Console.WriteLine("ERROR");// we print error
//                break;
//            }
//            switch (num)// 3 option: 1 2 or 3
//            {
//                case 1:
//                    testOrder(dalist.Order);// they want an operation on the order
//                    break;
//                case 2:
//                    testOrderItem(item);// they want an operation on the order item
//                    break;
//                case 3:
//                    testProduct(product);// they want an operation on the product
//                    break;
//                default:
//                    break;
//            }
//        }
//    }
//    private static void testOrder(order)//all the operation on order
//    {
//        try
//        {
//            Console.WriteLine(@"test order:
//                Enter your choice:
//                a - ADD ORDER
//                b - GET ORDER BY ID
//                c - GET THE ORDERS LIST
//                d - UPDATE ORDER
//                e - DELETE ORDER");//choose wiche operation they want to do
//            string? option = Console.ReadLine();
//            switch (option)
//            {
//                case "a":
//                    Order tmpOrder = new Order();// creat new order
//                    Console.WriteLine("enter the new order ID");// get a new id number
//                    int id;
//                    int.TryParse(Console.ReadLine(), out id);
//                    tmpOrder.ID = id;
//                    Console.WriteLine("enter the costumer name");// get a new id name
//                    tmpOrder.CustomerName = Console.ReadLine();
//                    Console.WriteLine("enter the costumer email");// get a new id email
//                    tmpOrder.CustomerEmail = Console.ReadLine();
//                    Console.WriteLine("enter the costumer adress");// get a new id adress
//                    tmpOrder.CustomerAddress = Console.ReadLine();
//                    order.Add(tmpOrder);
//                    break;
//                case "b":
//                    Console.WriteLine("enter the order ID");
//                    int.TryParse(Console.ReadLine(), out id);
//                    int myId = id;
//                    Console.WriteLine(order.GetById(myId));
//                    break;
//                case "c":
//                    foreach (Order? item in order.GetAll())
//                    {
//                        Console.WriteLine(item);
//                    }
//                    break;
//                case "d":
//                    Order tmpOrder2 = new Order();
//                    Console.WriteLine("enter the order ID");
//                    int.TryParse(Console.ReadLine(), out id);
//                    tmpOrder2.ID = id;
//                    Console.WriteLine(order.GetById(id));
//                    Console.WriteLine("enter the new costumer name");
//                    tmpOrder2.CustomerName = Console.ReadLine();
//                    Console.WriteLine("enter the new costumer email");
//                    tmpOrder2.CustomerEmail = Console.ReadLine();
//                    Console.WriteLine("enter the new costumer adress");
//                    tmpOrder2.CustomerAddress = Console.ReadLine();
//                    order.Update(tmpOrder2);
//                    break;
//                case "e":
//                    Console.WriteLine("enter the product ID");
//                    int.TryParse(Console.ReadLine(), out id);
//                    myId = id;
//                    order.Delete(myId);
//                    break;
//            }
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine(ex);
//        }
//    }
//    private static void testOrderItem(DalOrderItem item)
//    {
//        try
//        {
//            Console.WriteLine(@"test order item:
//                Enter your choice:
//                a - ADD ORDER ITEM
//                b - GET ORDER ITEM
//                c - GET ORDER-ITEMS LIST
//                d - UPDATE ORDER ITEM
//                e - DELETE ORDER ITEM");
//            string? option = Console.ReadLine();
//            switch (option)
//            {
//                case "a":
//                    OrderItem tmpItem = new OrderItem();
//                    Console.WriteLine("enter the new item ID");
//                    int id;
//                    int.TryParse(Console.ReadLine(), out id);
//                    tmpItem.ID = id;
//                    Console.WriteLine("enter the new product ID");
//                    int.TryParse(Console.ReadLine(), out id);
//                    tmpItem.ProductID = id;
//                    Console.WriteLine("enter the new Order ID");
//                    int.TryParse(Console.ReadLine(), out id);
//                    tmpItem.OrderID = id;
//                    Console.WriteLine("enter the new order item price");
//                    double pri;
//                    double.TryParse(Console.ReadLine(), out pri);
//                    tmpItem.Price = pri;
//                    Console.WriteLine("enter the new order item amount");
//                    int.TryParse(Console.ReadLine(), out id);
//                    tmpItem.Amount = id;
//                    item.Add(tmpItem);
//                    break;
//                case "b":
//                    Console.WriteLine("enter the order item ID");
//                    int myId;
//                    int.TryParse(Console.ReadLine(), out myId);
//                    Console.WriteLine(item.GetById(myId));
//                    break;
//                case "c":
//                    foreach (OrderItem oItem in item.GetAll())
//                    {
//                        Console.WriteLine(oItem);
//                    }
//                    break;
//                case "d":
//                    OrderItem tmpItem2 = new OrderItem();
//                    Console.WriteLine("enter the item ID");
//                    int.TryParse(Console.ReadLine(), out id);
//                    tmpItem2.ID = id;
//                    Console.WriteLine(item.GetById(id));
//                    Console.WriteLine("enter the new product ID");
//                    int.TryParse(Console.ReadLine(), out id);
//                    tmpItem2.ProductID = id;
//                    Console.WriteLine("enter the new Order ID");
//                    int.TryParse(Console.ReadLine(), out id);
//                    tmpItem2.OrderID = id;
//                    Console.WriteLine("enter the new order item price");
//                    double pric;
//                    double.TryParse(Console.ReadLine(), out pric);
//                    tmpItem2.Price = pric;

//                    Console.WriteLine("enter the new order item amount");
//                    int.TryParse(Console.ReadLine(), out id);
//                    tmpItem2.Amount = id;
//                    item.Update(tmpItem2);
//                    break;
//                case "e":
//                    Console.WriteLine("enter the product ID");
//                    int.TryParse(Console.ReadLine(), out myId);
//                    item.Delete(myId);
//                    break;
//            }

//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine(ex);
//        }
//    }

//    private static void testProduct(DalProduct product)
//    {
//        try
//        {
//            Console.WriteLine(@"test product:
//                Enter your choice:
//                a - ADD PRODUCT
//                b - GET PRODUCT BY ID
//                c - GET THE PRODUCTS LIST
//                d - UPDATE PRODUCT
//                e - DELETE PRODUCT");
//            string? option = Console.ReadLine();
//            switch (option)
//            {
//                case "a":
//                    Product tmpProduct = new Product();
//                    Console.WriteLine("enter the new product ID");
//                    int id;
//                    int.TryParse(Console.ReadLine(), out id);
//                    tmpProduct.ID = id;
//                    Console.WriteLine("enter the new product name");
//                    tmpProduct.Name = Console.ReadLine();
//                    Console.WriteLine(@"enter the catgory:
//                                        Children-0,
//                                        Holy-1,
//                                        Theoretical-2,
//                                        History-3,
//                                        Romans-4");
//                    int.TryParse(Console.ReadLine(), out id);
//                    int ctg = id;
//                    switch (ctg)
//                    {
//                        case 0:
//                            tmpProduct.Category = "Children";
//                            break;
//                        case 1:
//                            tmpProduct.Category = "Holy";
//                            break;
//                        case 2:
//                            tmpProduct.Category = "Theoretical";
//                            break;
//                        case 3:
//                            tmpProduct.Category = "History";
//                            break;
//                        case 4:
//                            tmpProduct.Category = "Romans";
//                            break;
//                        default:
//                            Console.WriteLine("ERROR");
//                            break;
//                    }
//                    Console.WriteLine("enter the new product price");
//                    double pri;
//                    double.TryParse(Console.ReadLine(), out pri);
//                    tmpProduct.Price = pri;
//                    Console.WriteLine("enter the new product amount");
//                    int.TryParse(Console.ReadLine(), out id);
//                    tmpProduct.InStuck = id;
//                    product.Add(tmpProduct);
//                    break;
//                case "b":
//                    Console.WriteLine("enter the product ID");
//                    int myId;
//                    int.TryParse(Console.ReadLine(), out myId);
//                    Console.WriteLine(product.GetById(myId));
//                    break;
//                case "c":
//                    foreach (Product item in product.GetAll())
//                    {
//                        Console.WriteLine(item);
//                    }

//                        ;/// מדפיסים את הכל
//                    break;
//                case "d":
//                    Product tmpProduct2 = new Product();
//                    Console.WriteLine("enter the product ID");
//                    int.TryParse(Console.ReadLine(), out id);
//                    tmpProduct2.ID = id;
//                    Console.WriteLine(product.GetById(id));
//                    Console.WriteLine("enter the new product name");
//                    tmpProduct2.Name = Console.ReadLine();
//                    Console.WriteLine(@"enter the catgory:
//                                        Children-0,
//                                        Holy-1,
//                                        Theoretical-2,
//                                        History-3,
//                                        Romans-4");
//                    int.TryParse(Console.ReadLine(), out ctg);
//                    switch (ctg)
//                    {
//                        case 0:
//                            tmpProduct2.Category = "Children";
//                            break;
//                        case 1:
//                            tmpProduct2.Category = "Holy";
//                            break;
//                        case 2:
//                            tmpProduct2.Category = "Theoretical";
//                            break;
//                        case 3:
//                            tmpProduct2.Category = "History";
//                            break;
//                        case 4:
//                            tmpProduct2.Category = "Romans";
//                            break;
//                        default:
//                            Console.WriteLine("ERROR");
//                            break;
//                    }
//                    double pric;
//                    Console.WriteLine("enter the new product price");
//                    double.TryParse(Console.ReadLine(), out pric);
//                    tmpProduct2.Price = pric;
//                    Console.WriteLine("enter the new product amount");
//                    int.TryParse(Console.ReadLine(), out id);
//                    tmpProduct2.InStuck = id;
//                    product.Update(tmpProduct2);
//                    break;
//                case "e":
//                    Console.WriteLine("enter the product ID");
//                    int.TryParse(Console.ReadLine(), out myId);
//                    product.Delete(myId);
//                    break;
//            }

//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine(ex);
//        }
//    }


//}