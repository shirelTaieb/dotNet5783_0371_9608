using Dal;
using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using BLApi;
using BlImplementation;
using System.Security.Cryptography;
using DO;

namespace BLTest
{
    public class blMain
    {
        private static void testProduct(BLApi.IProduct product)
        {
            try
            {
                int num = 1;
                while (num != 0)
                {
                    string? temp;
                    int id;
                    int stock;
                    bool b;
                    double price;
                    BO.Product pr = new BO.Product();
                    Console.WriteLine(@"test product:
                            Enter your choice:
                            0- EXIT
                            1 - ADD PRODUCT
                            2 - UPDATE PRODUCT
                            3 - DELETE PRODUCT
                            4 - GET PRODUCT INFORMATION
                            5 - GET LIST OF ALL THE PRODUCTS");//choose which operation they want to do
                    string? option = Console.ReadLine();
                    bool op = int.TryParse(option, out num);
                    if (!op)
                    {
                        Console.WriteLine("ERROR");
                        break;
                    }
                    switch (num)
                    {
                        case 1:
                            Console.WriteLine(@"enter product ID:\n");
                            temp = Console.ReadLine();
                            b = int.TryParse(temp, out id);
                            if (!b)
                            {
                                Console.WriteLine(@"ERROR");
                                break;
                            };
                            pr.ID = id;
                            Console.WriteLine(@"enter product Name:\n");
                            temp = Console.ReadLine();
                            pr.Name = temp;
                            Console.WriteLine(@"enter product Price:\n");
                            temp = Console.ReadLine();
                            b = double.TryParse(temp, out price);
                            pr.Price = price;
                            Console.WriteLine(@"enter the catgory:
                                        Children-0,
                                        Holy-1,
                                        Theoretical-2,
                                        History-3,
                                        Romans-4");
                            temp = Console.ReadLine();
                            pr.Category = (BO.Category)int.Parse(temp!);
                            Console.WriteLine(@"enter product stock:\n");
                            temp = Console.ReadLine();
                            b = int.TryParse(temp, out stock);
                            if (!b)
                            {
                                Console.WriteLine(@"ERROR");
                                break;
                            }
                            pr.InStock = stock;
                            product.addNewProduct(pr);
                            break;
                        case 2:
                            Console.WriteLine(@"enter the id of the product you want delete:\n");
                            int delID;
                            temp = Console.ReadLine();
                            delID = int.Parse(temp!);
                            product.deleteProduct(delID);
                            break;
                        case 3:
                            Console.WriteLine(@"enter product ID:\n");
                            temp = Console.ReadLine();
                            b = int.TryParse(temp, out id);
                            if (!b)
                            {
                                Console.WriteLine(@"ERROR");
                                break;
                            }
                            pr.ID = id;
                            Console.WriteLine(@"enter product Name:\n");
                            temp = Console.ReadLine();
                            pr.Name = temp;
                            Console.WriteLine(@"enter product Price:\n");
                            temp = Console.ReadLine();
                            b = double.TryParse(temp, out price);
                            pr.Price = price;
                            Console.WriteLine(@"enter the catgory:
                                        Children-0,
                                        Holy-1,
                                        Theoretical-2,
                                        History-3,
                                        Romans-4");
                            temp = Console.ReadLine();
                            pr.Category = (BO.Category)int.Parse(temp!);
                            Console.WriteLine(@"enter product stock:\n");
                            temp = Console.ReadLine();
                            b = int.TryParse(temp, out stock);
                            if (!b)
                            {
                                Console.WriteLine(@"ERROR");
                                break;
                            }
                            pr.InStock = stock;
                            product!.updateProduct(pr);
                            break;
                        case 4:
                            List<BO.ProductForList?> products = new List<BO.ProductForList?>();
                            products = product.getListOfProduct().ToList();
                            foreach (var item in products)
                                Console.WriteLine(item);
                            break;
                        case 5:
                            Console.WriteLine(@"Enter 1 to manager, 2 for customer\n");
                            temp = Console.ReadLine();
                            b = int.TryParse(temp, out int choose);
                            if (!b)
                            {
                                Console.WriteLine(@"ERROR");
                                break;
                            }
                            Console.WriteLine(@"Enter the id of the wanted product");
                            temp = Console.ReadLine();
                            b = int.TryParse(temp, out id);
                            if (!b || choose != 1 || choose != 2)
                            {
                                Console.WriteLine(@"ERROR");
                                break;
                            }
                            if (choose == 1)
                                product.getProductInfoManager(id);
                            else
                                product.getProductInfoCustomer(id);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private static void testOrder(BLApi.IOrder order)
        {
            try
            {
                string? temp;
                int id;
                bool b;
                int num = 1;
                while (num != 0)
                {
                    
                    BO.Product pr = new BO.Product();
                    Console.WriteLine(@"test product:
                            Enter your choice:
                            0- EXIT
                            1 - GET ORDER LIST
                            2 - UPDATE SENT ORDER
                            3 - UPDATE DELIVERY ORDER
                            4 - GET ORDER INFORMATION
                            5 - ORDER TRACKING");//choose which operation they want to do
                    string? option = Console.ReadLine();
                    bool op = int.TryParse(option, out num);
                    if (!op)
                    {
                        Console.WriteLine("ERROR");
                        break;
                    }
                    switch (num)
                    {
                        case 1:
                            List<BO.OrderForList?> lst=new List<OrderForList?>();
                            lst = order.getOrderList().ToList();
                            foreach (BO.OrderForList? item in lst)
                                Console.WriteLine(item);
                            break;
                        case 2:
                            Console.WriteLine(@"enter id of the order:");
                            temp = Console.ReadLine();
                            b=int.TryParse(temp, out id);
                            if (!b)
                            {
                                Console.WriteLine(@"ERROR");
                                break;
                            }
                            order.updateSentOrder(id);
                            break;
                        case 3:
                            Console.WriteLine(@"enter id of the order:");
                            temp = Console.ReadLine();
                            b = int.TryParse(temp, out id);
                            if (!b)
                            {
                                Console.WriteLine(@"ERROR");
                                break;
                            }
                            order.updateDeliveryOrder(id);
                            break;
                        case 4:
                            Console.WriteLine(@"enter id of the order:");
                            temp = Console.ReadLine();
                            b = int.TryParse(temp, out id);
                            if (!b)
                            {
                                Console.WriteLine(@"ERROR");
                                break;
                            }
                            BO.Order? order1 = new BO.Order();
                            order1= order.getOrderInfo(id);
                            Console.WriteLine(order1);
                            break;
                        case 5:
                            Console.WriteLine(@"enter id of the order:");
                            temp = Console.ReadLine();
                            b = int.TryParse(temp, out id);
                            if (!b)
                            {
                                Console.WriteLine(@"ERROR");
                                break;
                            }
                            BO.OrderTracking ortrack = new BO.OrderTracking();
                            ortrack=order.orderTracking(id);
                            Console.WriteLine(ortrack);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private static void testCart(BLApi.ICart cart)
        {
            try
            {
                string? temp;
                int id;
                bool b;
                int num = 1;
                while (num != 0)
                {

                    BO.Product pr = new BO.Product();
                    Console.WriteLine(@"test product:
                            Enter your choice:
                            0- EXIT
                            1 - ADD PRODUCT TO CART
                            2 - UPDATE PRODUCT AMOUNT
                            3 - CONFIRM ORDER");//choose which operation they want to do
                    string? option = Console.ReadLine();
                    bool op = int.TryParse(option, out num);
                    if (!op)
                    {
                        Console.WriteLine("ERROR");
                        break;
                    }
                    switch (num)
                    {
                        case 1:
                            Console.WriteLine(@"enter id of the product:");
                            temp = Console.ReadLine();
                            b = int.TryParse(temp, out id);
                            if (!b)
                            {
                                Console.WriteLine(@"ERROR");
                                break;
                            }
                            cart?.addProductToCart(cart?????, id);///???????????
                            break;
                        case 2:
                            Console.WriteLine(@"enter id of the product:");
                            temp = Console.ReadLine();
                            b = int.TryParse(temp, out id);
                            if (!b)
                            {
                                Console.WriteLine(@"ERROR");
                                break;
                            }

                            Console.WriteLine(@"enter the new amount of the product:");
                            temp = Console.ReadLine();
                            b = int.TryParse(temp, out int amount);
                            if (!b)
                            {
                                Console.WriteLine(@"ERROR");
                                break;
                            }
                            cart.updatePoductAmount(cart????????, id, amount);///???????????
                            break;
                        case 3:
                            cart.confirmOrder(cart ????);//????????????????
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void Main(string[] args)
        {
            IBl? bl = new Bl();
            int num = 1;
            while (num != 0)
            {
                Console.WriteLine(@"Hello!
                            Enter your choice:
                            0-exit
                            1-test Product
                            2-test Order
                            3-test Cart");
                string? option = Console.ReadLine();
                bool b = int.TryParse(option, out num); // בונוסס
                if (!b)// if the option they choose is incorect
                {
                    Console.WriteLine("ERROR");// we print error
                    break;
                }
                switch (num)// 3 option: 1 2 or 3
                {
                    case 1:
                        testProduct(bl.Product!);// they want an operation on the product
                        break;
                    case 2:
                        testOrder(bl.Order!);// they want an operation on the order
                        break;
                    case 3:
                        testCart(bl.Cart!);// they want an operation on the cart
                        break;
                    default:
                        break;
                }

            }
        }
    }
}

//        private static void testOrder(order)//all the operation on order
//        {
//            try
//            {
//                Console.WriteLine(@"test order:
//                Enter your choice:
//                a - ADD ORDER
//                b - GET ORDER BY ID
//                c - GET THE ORDERS LIST
//                d - UPDATE ORDER
//                e - DELETE ORDER");//choose wiche operation they want to do
//                string? option = Console.ReadLine();
//                switch (option)
//                {
//                    case "a":
//                        Order tmpOrder = new Order();// creat new order
//                        Console.WriteLine("enter the new order ID");// get a new id number
//                        int id;
//                        int.TryParse(Console.ReadLine(), out id);
//                        tmpOrder.ID = id;
//                        Console.WriteLine("enter the costumer name");// get a new id name
//                        tmpOrder.CostumerName = Console.ReadLine();
//                        Console.WriteLine("enter the costumer email");// get a new id email
//                        tmpOrder.CostumerEmail = Console.ReadLine();
//                        Console.WriteLine("enter the costumer adress");// get a new id adress
//                        tmpOrder.CostumerAdress = Console.ReadLine();
//                        order.Add(tmpOrder);
//                        break;
//                    case "b":
//                        Console.WriteLine("enter the order ID");
//                        int.TryParse(Console.ReadLine(), out id);
//                        int myId = id;
//                        Console.WriteLine(order.GetById(myId));
//                        break;
//                    case "c":
//                        foreach (Order? item in order.GetAll())
//                        {
//                            Console.WriteLine(item);
//                        }
//                        break;
//                    case "d":
//                        Order tmpOrder2 = new Order();
//                        Console.WriteLine("enter the order ID");
//                        int.TryParse(Console.ReadLine(), out id);
//                        tmpOrder2.ID = id;
//                        Console.WriteLine(order.GetById(id));
//                        Console.WriteLine("enter the new costumer name");
//                        tmpOrder2.CustomerName = Console.ReadLine();
//                        Console.WriteLine("enter the new costumer email");
//                        tmpOrder2.CustomerEmail = Console.ReadLine();
//                        Console.WriteLine("enter the new costumer adress");
//                        tmpOrder2.CustomerAddress = Console.ReadLine();
//                        order.Update(tmpOrder2);
//                        break;
//                    case "e":
//                        Console.WriteLine("enter the product ID");
//                        int.TryParse(Console.ReadLine(), out id);
//                        myId = id;
//                        order.Delete(myId);
//                        break;
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex);
//            }
//        }
//        private static void testOrderItem(DalOrderItem item)
//        {
//            try
//            {
//                Console.WriteLine(@"test order item:
//                Enter your choice:
//                a - ADD ORDER ITEM
//                b - GET ORDER ITEM
//                c - GET ORDER-ITEMS LIST
//                d - UPDATE ORDER ITEM
//                e - DELETE ORDER ITEM");
//                string? option = Console.ReadLine();
//                switch (option)
//                {
//                    case "a":
//                        OrderItem tmpItem = new OrderItem();
//                        Console.WriteLine("enter the new item ID");
//                        int id;
//                        int.TryParse(Console.ReadLine(), out id);
//                        tmpItem.ID = id;
//                        Console.WriteLine("enter the new product ID");
//                        int.TryParse(Console.ReadLine(), out id);
//                        tmpItem.ProductID = id;
//                        Console.WriteLine("enter the new Order ID");
//                        int.TryParse(Console.ReadLine(), out id);
//                        tmpItem.OrderID = id;
//                        Console.WriteLine("enter the new order item price");
//                        double pri;
//                        double.TryParse(Console.ReadLine(), out pri);
//                        tmpItem.Price = pri;
//                        Console.WriteLine("enter the new order item amount");
//                        int.TryParse(Console.ReadLine(), out id);
//                        tmpItem.Amount = id;
//                        item.Add(tmpItem);
//                        break;
//                    case "b":
//                        Console.WriteLine("enter the order item ID");
//                        int myId;
//                        int.TryParse(Console.ReadLine(), out myId);
//                        Console.WriteLine(item.GetById(myId));
//                        break;
//                    case "c":
//                        foreach (OrderItem oItem in item.GetAll())
//                        {
//                            Console.WriteLine(oItem);
//                        }
//                        break;
//                    case "d":
//                        OrderItem tmpItem2 = new OrderItem();
//                        Console.WriteLine("enter the item ID");
//                        int.TryParse(Console.ReadLine(), out id);
//                        tmpItem2.ID = id;
//                        Console.WriteLine(item.GetById(id));
//                        Console.WriteLine("enter the new product ID");
//                        int.TryParse(Console.ReadLine(), out id);
//                        tmpItem2.ProductID = id;
//                        Console.WriteLine("enter the new Order ID");
//                        int.TryParse(Console.ReadLine(), out id);
//                        tmpItem2.OrderID = id;
//                        Console.WriteLine("enter the new order item price");
//                        double pric;
//                        double.TryParse(Console.ReadLine(), out pric);
//                        tmpItem2.Price = pric;

//                        Console.WriteLine("enter the new order item amount");
//                        int.TryParse(Console.ReadLine(), out id);
//                        tmpItem2.Amount = id;
//                        item.Update(tmpItem2);
//                        break;
//                    case "e":
//                        Console.WriteLine("enter the product ID");
//                        int.TryParse(Console.ReadLine(), out myId);
//                        item.Delete(myId);
//                        break;
//                }

//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex);
//            }
//        }

//        private static void testProduct(DalProduct product)
//        {
//            try
//            {
//                Console.WriteLine(@"test product:
//                Enter your choice:
//                a - ADD PRODUCT
//                b - GET PRODUCT BY ID
//                c - GET THE PRODUCTS LIST
//                d - UPDATE PRODUCT
//                e - DELETE PRODUCT");
//                string? option = Console.ReadLine();
//                switch (option)
//                {
//                    case "a":
//                        Product tmpProduct = new Product();
//                        Console.WriteLine("enter the new product ID");
//                        int id;
//                        int.TryParse(Console.ReadLine(), out id);
//                        tmpProduct.ID = id;
//                        Console.WriteLine("enter the new product name");
//                        tmpProduct.Name = Console.ReadLine();
//                        Console.WriteLine(@"enter the catgory:
//                                        Children-0,
//                                        Holy-1,
//                                        Theoretical-2,
//                                        History-3,
//                                        Romans-4");
//                        int.TryParse(Console.ReadLine(), out id);
//                        int ctg = id;
//                        switch (ctg)
//                        {
//                            case 0:
//                                tmpProduct.Category = "Children";
//                                break;
//                            case 1:
//                                tmpProduct.Category = "Holy";
//                                break;
//                            case 2:
//                                tmpProduct.Category = "Theoretical";
//                                break;
//                            case 3:
//                                tmpProduct.Category = "History";
//                                break;
//                            case 4:
//                                tmpProduct.Category = "Romans";
//                                break;
//                            default:
//                                Console.WriteLine("ERROR");
//                                break;
//                        }
//                        Console.WriteLine("enter the new product price");
//                        double pri;
//                        double.TryParse(Console.ReadLine(), out pri);
//                        tmpProduct.Price = pri;
//                        Console.WriteLine("enter the new product amount");
//                        int.TryParse(Console.ReadLine(), out id);
//                        tmpProduct.InStuck = id;
//                        product.Add(tmpProduct);
//                        break;
//                    case "b":
//                        Console.WriteLine("enter the product ID");
//                        int myId;
//                        int.TryParse(Console.ReadLine(), out myId);
//                        Console.WriteLine(product.GetById(myId));
//                        break;
//                    case "c":
//                        foreach (Product item in product.GetAll())
//                        {
//                            Console.WriteLine(item);
//                        }

//                            ;/// מדפיסים את הכל
//                        break;
//                    case "d":
//                        Product tmpProduct2 = new Product();
//                        Console.WriteLine("enter the product ID");
//                        int.TryParse(Console.ReadLine(), out id);
//                        tmpProduct2.ID = id;
//                        Console.WriteLine(product.GetById(id));
//                        Console.WriteLine("enter the new product name");
//                        tmpProduct2.Name = Console.ReadLine();
//                        Console.WriteLine(@"enter the catgory:
//                                        Children-0,
//                                        Holy-1,
//                                        Theoretical-2,
//                                        History-3,
//                                        Romans-4");
//                        int.TryParse(Console.ReadLine(), out ctg);
//                        switch (ctg)
//                        {
//                            case 0:
//                                tmpProduct2.Category = "Children";
//                                break;
//                            case 1:
//                                tmpProduct2.Category = "Holy";
//                                break;
//                            case 2:
//                                tmpProduct2.Category = "Theoretical";
//                                break;
//                            case 3:
//                                tmpProduct2.Category = "History";
//                                break;
//                            case 4:
//                                tmpProduct2.Category = "Romans";
//                                break;
//                            default:
//                                Console.WriteLine("ERROR");
//                                break;
//                        }
//                        double pric;
//                        Console.WriteLine("enter the new product price");
//                        double.TryParse(Console.ReadLine(), out pric);
//                        tmpProduct2.Price = pric;
//                        Console.WriteLine("enter the new product amount");
//                        int.TryParse(Console.ReadLine(), out id);
//                        tmpProduct2.InStuck = id;
//                        product.Update(tmpProduct2);
//                        break;
//                    case "e":
//                        Console.WriteLine("enter the product ID");
//                        int.TryParse(Console.ReadLine(), out myId);
//                        product.Delete(myId);
//                        break;
//                }

//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex);
//            }
//        }


//    }
//}
