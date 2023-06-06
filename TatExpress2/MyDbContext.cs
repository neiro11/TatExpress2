using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TatExpress2.Models;

namespace TatExpress2
{

    public class MyDbContext
    {
        private readonly SQLiteConnection conn;
        //CRUD for tables \/
                                                                                                                        //       /\       //
                                                                                                                        //      /  \      //
                                                                                                                        //     /    \     //
                                                                                                                        //    /______\    //
                                                                                                                        //   /|      |\   //
                                                                                                                        //  / | صبر  | \  //
                                                                                                                        // /  |      |  \ //
                                                                                                                        ///   |______|   \//
                                                                                                                        //|   |      |   |//
                                                                                                                        //|   |      |   |//
                                                                                                                        //|___|______|___|//


        public MyDbContext(string path)
        {
            conn = new SQLiteConnection(path);
            conn.CreateTable<Product>();
            conn.CreateTable<User>();
            conn.CreateTable<Shoppping_cart>();
            conn.CreateTable<Shop_cart_Prod>();
            conn.CreateTable<Desire>();
            conn.CreateTable<Desire_prod>();
            conn.CreateTable<Store>();
            conn.CreateTable<Vender>();
            conn.CreateTable<Order>();
            conn.CreateTable<Status>();
            conn.CreateTable<Prod_order>();
            conn.CreateTable<Vender>();
            conn.CreateTable<PP_owner>();
            conn.CreateTable<PP_order>();
            conn.CreateTable<Employee>();




        }
        //⠄⠄⠄⠄⠄⠄⠄⢀⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
        //⠄⠄⠄⠄⠄⠄⠄⡏⣆⡀⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
        //⠄⠄⠄⠄⠄⠄⠄⠁⢹⣿⡿⠲⡀⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
        //⠄⠄⠄⣤⣤⣤⣤⣤⠈⠉⠄⠄⠃⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
        //⠄⠄⠄⠻⠿⢿⣿⣿⠄⠄⠄⠄⢸⡀⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
        //⠄⠄⠄⢀⣴⣿⡿⠋⠄⠄⠄⠄⠈⣧⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
        //⠄⠄⠄⢿⣿⣧⣄⠄⠄⢠⡀⠄⠄⠿⡇⠄⠄⠄⠄⠄⠄⠄⠄⠄
        //⠄⠄⠄⠄⠈⢻⣿⣷⠄⠄⢱⠄⠄⢠⣿⠄⠄⠄⠄⠄⠄⠄⠄⠄
        //⠄⠄⠄⣿⣿⣿⣿⣿⠄⠄⢸⡇⠄⢸⢸⡀⠄⠄⠄⠄⠄⠄⠄⠄
        //⠄⠄⠄⢀⣤⣤⣤⣤⠄⠄⢸⠇⠄⢸⣼⡇⠄⠄⠄⠄⠄⠄⠄⠄
        //⠄⠄⠄⣿⣿⠿⠿⠿⠄⠄⡜⠄⠄⠈⣿⣿⠄⠄⠄⠄⠄⠄⠄⠄
        //⠄⠄⠄⣿⣿⠄⠄⠄⠄⠊⢠⠄⠄⠄⣿⣿⠄⠄⠄⠄⠄⠄⠄⠄
        //⠄⠄⠄⣿⣿⣀⣀⣀⠄⠆⢸⠄⠄⠄⣿⠟⠄⠄⠄⠄⠄⠄⠄⠄
        //⠄⠄⠄⠻⣿⣿⣿⣿⠄⠇⢸⠄⠄⠄⢻⠄⠄⠄⠄⠄⠄⠄⠄⠄
        //⠄⠄⠄⣤⡄⣠⣤⣤⠄⠄⢸⠄⠄⠄⢸⡀⠄⠄⠄⠄⠄⠄⠄⠄
        //⠄⠄⠄⣿⡇⣿⡟⣿⠄⠄⢸⠄⠄⠄⢟⡳⡀⠄⠄⠄⠄⠄⠄⠄
        //⠄⠄⠄⣿⡇⣿⡇⣿⠄⠄⢸⠄⠄⠈⡾⠷⡕⣄⠄⠄⠄⠄⠄⠄
        //⠄⠄⠄⣿⣿⣿⡇⣿⠄⠄⢸⠄⠄⠄⡇⠄⠉⢮⢦⠄⠄⠄⠄⠄
        //⠄⠄⠄⠙⠛⠛⠃⠛⠄⠄⢸⠄⠄⠄⡇⠄⠄⠄⠑⡑⡄⠄⠄⠄
        //⠄⠄⠄⠄⠄⠄⠄⣿⠄⠄⢸⠄⠄⠄⡇⠄⠄⠄⠄⠈⢞⡆⠄⠄
        //⠄⠄⠄⣤⣤⣤⣤⣿⠄⠄⢸⠄⠄⠄⡇⠄⠄⠄⠄⠄⢸⡇⠄⠄
        //⠄⠄⠄⠿⠿⠿⠿⣿⠄⠄⢸⠄⠄⠄⡇⠄⠄⠄⠄⠄⢸⡇⠄⠄
        //⠄⠄⠄⠄⠄⠄⠄⣿⠄⠄⢸⠄⠄⠄⡇⠄⠄⠄⠄⠄⢸⡇⠄⠄
        //⠄⠄⠄⣠⣤⣤⣤⣍⠄⠄⢸⠄⠄⠄⡇⠄⠄⠄⠄⠄⢸⡇⠄⠄
        //⠄⠄⠄⠿⢿⣿⠿⣿⠄⠄⢸⠄⡆⠄⡇⠄⠄⣀⣀⡀⠼⡇⠄⠄
        //⠄⠄⠄⠄⢸⣿⠄⣿⠄⠄⢸⠄⡁⠄⠉⠉⠉⣀⣀⠤⣤⡇⠄⠄
        //⠄⠄⠄⣀⣸⣿⣀⣿⠄⠄⢸⠄⠄⢠⡞⠉⠁⠄⢀⣴⣿⡇⠄⠄
        //⠄⠄⠄⢿⣿⣿⣿⡿⠄⠄⢸⠄⠄⢸⠃⠄⠄⣰⣿⣿⡿⡇⠄⠄
        //⠄⠄⠄⣤⣤⣤⣤⣤⠄⠄⢸⠄⠄⢸⠄⣠⣾⣿⣿⡿⢁⠇⠄⠄
        //⠄⠄⠄⠿⠿⠿⣿⣿⠄⢠⢸⠄⠄⢸⣿⣿⣿⣿⡟⠄⡞⠄⠄⠄
        //⠄⠄⠄⠄⣠⣾⣿⠟⠄⠄⢹⡀⠄⢘⣿⣿⣿⠟⠄⡜⠄⠄⠄⠄
        //⠄⠄⠄⣾⣿⣿⣥⣤⠄⠄⢸⡇⠄⠈⣿⣿⠋⠄⡼⠄⠄⠄⠄⠄
        //⠄⠄⠄⠿⠿⠿⠿⠿⠄⠄⢸⡇⠄⠄⣿⠁⠄⡼⠄⠄⠄⠄⠄⠄
        //⠄⠄⠄⣠⣶⣶⣶⣦⠄⠄⡸⠁⠄⠄⠁⠄⡼⠁⠄⠄⠄⠄⠄⠄
        //⠄⠄⠄⣿⣿⠛⠛⣿⠄⠔⠁⠄⠄⠄⠄⡼⠁⠄⠄⠄⠄⠄⠄⠄
        //⠄⠄⠄⣿⣿⣶⡆⣿⠄⠄⠄⠄⠄⠄⢸⣳⠄⠄⠄⠄⠄⠄⠄⠄
        //⠄⠄⠄⣿⣿⣿⡇⣿⠄⠄⠄⠄⠄⢀⡟⣿⠄⠄⠄⠄⠄⠄⠄⠄
        //⠄⠄⠄⠘⠛⠛⠃⠛⠄⠄⠄⠄⠄⢸⠃⢻⠄⠄⠄⠄⠄⠄⠄⠄
        //⠄⠄⠄⠄⠄⠄⠄⠄⠄⣠⣤⣤⡀⡌⠄⣸⠄⠄⠄⠄⠄⠄⠄⠄
        //⠄⠄⠄⠄⠄⠄⠄⢰⡠⠛⠛⠛⠁⠄⠄⠉⠄⠄⠄⠄⠄⠄⠄⠄
        //⠄⠄⠄⠄⠄⠄⠄⠈⠁⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄                                                                                      
        //Product
        public List<Product> GetProducts()
        {
            return conn.Table<Product>().ToList();
        }
        public int SaveProduct(Product product)
        {
            return conn.Update(product);
        }
        public int AddProduct(Product user)
        {
            return conn.Insert(user);
        }
        //User
        public List<User> GetUsers()
        {
            return conn.Table<User>().ToList();
        }
        public int SaveUser(User user)
        {
            return conn.Update(user);
        }
        public int AddUser(User user)
        {
            return conn.Insert(user);
        }
        //Shoppping_cart
        public List<Shoppping_cart> GetShoppping_cart()
        {
            return conn.Table<Shoppping_cart>().ToList();
        }
        public int SaveShoppping_cart(Shoppping_cart shoppping_Cart)
        {
            return conn.Insert(shoppping_Cart);
        }
        public int AddShoppping_cart(Shoppping_cart shoppping_Cart)
        {
            return conn.Insert(shoppping_Cart);
        }
        //Shop_cart_prod
        public List<Shop_cart_Prod> GetShop_cart_prod()
        {
            return conn.Table<Shop_cart_Prod>().ToList();
        }
        public int SaveShop_cart_prod(Shop_cart_Prod shop_Cart_Prod)
        {
            return conn.Update(shop_Cart_Prod);
        }
        public int AddShop_cart_prod(Shop_cart_Prod Shop_cart_prod)
        {
            return conn.Insert(Shop_cart_prod);
        }
        public int RemoveShop_cart_prod(Shop_cart_Prod Shop_cart_prod)
        {
            return conn.Delete(Shop_cart_prod);
        }
        //Desire
        public List<Desire> GetDesire()
        {
            return conn.Table<Desire>().ToList();
        }
        public int SaveDesire(Desire desire)
        {
            return conn.Insert(desire);
        }
        public int AddDesire(Desire desire)
        {
            return conn.Insert(desire);
        }
        //Desire_prod
        public List<Desire_prod> GetDesire_prod()
        {
            return conn.Table<Desire_prod>().ToList();
        }
        public int SaveDesire_prod(Desire_prod desire_prod)
        {
            return conn.Insert(desire_prod);
        }
        public int AddDesire_prod(Desire_prod desire_prod)
        {
            return conn.Insert(desire_prod);
        }
        //Store
        public List<Store> GetStore()
        {
            return conn.Table<Store>().ToList();
        }
        public int SaveStore(Store store)
        {
            return conn.Update(store);
        }
        public int AddStore(Store store)
        {
            return conn.Insert(store);
        }

        //Vender
        public List<Vender> GetVender()
        {
            return conn.Table<Vender>().ToList();
        }
        public int SaveVender(Vender vender)
        {
            return conn.Update(vender);
        }
        public int AddVender(Vender vender)
        {
            return conn.Insert(vender);
        }
        //Order
        public List<Order> GetOrder()
        {
            return conn.Table<Order>().ToList();
        }
        public int SaveOrder(Order order)
        {
            return conn.Update(order);
        }
        public int AddOrder(Order order)
        {
            return conn.Insert(order);
        }
        //Prod_order
        public List<Prod_order> GetProd_order()
        {
            return conn.Table<Prod_order>().ToList();
        }
        public int SaveProd_order(Prod_order vender)
        {
            return conn.Insert(vender);
        }
        public int AddProd_order(Prod_order vender)
        {
            return conn.Insert(vender);
        }
        //Status
        public List<Status> GetStatus()
        {
            return conn.Table<Status>().ToList();
        }
        public int SaveStatus(Status vender)
        {
            return conn.Insert(vender);
        }
        public int AddStatus(Status vender)
        {
            return conn.Insert(vender);
        }
        //PP_owner
        public List<PP_owner> GetPP_owner()
        {
            return conn.Table<PP_owner>().ToList();
        }
        public int SavePP_owner(PP_owner vender)
        {
            return conn.Update(vender);
        }
        public int AddPP_owner(PP_owner vender)
        {
            return conn.Insert(vender);
        }
        //Employee
        public List<Employee> GetEmployee()
        {
            return conn.Table<Employee>().ToList();
        }
        public int SaveEmployee(Employee vender)
        {
            return conn.Update(vender);
        }
        public int AddEmployee(Employee vender)
        {
            return conn.Insert(vender);
        } 
        //Pick_point
        public List<Pick_point> GetPick_point()
        {
            return conn.Table<Pick_point>().ToList();
        }
        //PP_order
        public List<PP_order> GetPP_order()
        {
            return conn.Table<PP_order>().ToList();
        }
        public int SavePP_order(PP_order vender)
        {
            return conn.Update(vender);
        }
        public int AddPP_order(PP_order vender)
        {
            return conn.Insert(vender);
        }
        //
    }


}

