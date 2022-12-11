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
    public class Program
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
                            //else
                            //   // product.getProductInfoCustomer(id);
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
        private static void testCart(BLApi.ICart cart,BO.Cart? myCart)
        {
            myCart = myCart ?? new BO.Cart();
            Console.WriteLine("Enter your name:");
            myCart.CustomerName = Console.ReadLine();
            Console.WriteLine("Enter your address");
            myCart.CustomerAddress = Console.ReadLine();
            Console.WriteLine("Enter your email");
            myCart.CustomerEmail= Console.ReadLine();
            myCart.TotalPrice = 0;
            myCart.Items = new List<BO.OrderItem?>();
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
                            cart?.addProductToCart(myCart, id);
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
                            cart.updatePoductAmount(myCart, id, amount);
                            break;
                        case 3:
                            cart.confirmOrder(myCart);
                            num = 0; //when we confim the order, we exit from the cart
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
                        BO.Cart myCart = new BO.Cart();
                        testCart(bl.Cart!,myCart);// they want an operation on the cart
                        break;
                    default:
                        break;
                }

            }
        }
    }
}


