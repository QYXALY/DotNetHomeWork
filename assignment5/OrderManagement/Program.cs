using System;

namespace orderManagement
{
    class Order
    {
        public  int Id { get; set; }
        public OrderDetails? Detail { get; set; }

        public override string ToString()
        {
            return $"订单为ID为{Id},"+Detail.ToString();
        }

        public Order(int id, OrderDetails? detail)
        {
            Id = id;
            Detail = detail;
        }

        public bool Equals(Order order)
        {
            return Id == order.Id;
        }
    }

    class OrderDetails
    {
        public Item? OrderItem { get; set; }  //商品名
        public int ItemCnt { get; set; }       //商品数量
        public Customer? OrderCustomer { get; set; } //客户
        public double OrderCost { get; set; } = 0;   //总价格

        public override string ToString()
        {
            return $"商品为{OrderItem}，共{ItemCnt}个，总价格为{OrderCost},客户为{OrderCustomer.CustomerName}";
        }

        public bool Equals(OrderDetails de)
        {
            return OrderItem==de.OrderItem&& ItemCnt==de.ItemCnt&& OrderCustomer==de.OrderCustomer&&OrderCost==de.OrderCost;
        }

        public OrderDetails(Item? orderItem, int itemCnt, Customer? orderCustomer)
        {
            OrderItem = orderItem;
            ItemCnt = itemCnt;
            OrderCustomer = orderCustomer;
            OrderCost = itemCnt * orderItem.ItemCost;
        }
    }

    class Customer
    {
        public string? CustomerName { get; set; }

        public Customer(string? customerName)
        {
            CustomerName = customerName;
        }

        public override string ToString()
        {
            return $"客户名为{CustomerName}";
        }
    }

    class Item
    {
        public string? ItemName { get; set; }
        public double ItemCost { get; set; }

        public Item(string? itemName, int itemCost)
        {
            ItemName = itemName;
            ItemCost = itemCost;
        }

        public override string ToString()
        {
            return $"商品名为{ItemName},商品价格为{ItemCost}";
        }
    }

     class OrderService
    {
       public static List<Order>? OrderList;

        public void AddOrder(Order order)  //添加订单
        {
            if (OrderList.Contains(order))
            {
                throw new ArgumentException("该订单已存在！");
            }
            else 
            {
                OrderList.Add(order);
            }
        }

        public  void ChangeOrder(int id, OrderDetails detail) //修改订单
        {
            foreach(Order o in OrderList)
            {
                if(o.Id == id)
                {
                    o.Detail = detail;
                    return;
                }
            }
            throw new ArgumentException("修改失败！");
        }

        public  void DelOrder(int id) //删除订单
        {
            foreach (Order o in OrderList)
            {
                if (o.Id == id)
                {
                    OrderList.RemoveAt(OrderList.IndexOf(o));
                    return;
                }
            }
            throw new ArgumentException("删除失败！");
        }

        //四种查找：
        public  List<Order> FindById(int id)
        {
            var res = from o in OrderList where id == o.Id select o;
            return res.ToList();
        }

        public  List<Order> FindByItem(string name)
        {
            var res = from o in OrderList where name == o.Detail.OrderItem.ItemName select o;
            return res.ToList();
        }

        public  List<Order> FindByCustomer(string name)
        {
            var res = from o in OrderList where name == o.Detail.OrderCustomer.CustomerName select o;
            return res.ToList();
        }

        public  List<Order> FindByCost(double cost)
        {
            var res = from o in OrderList where cost == o.Detail.OrderCost select o;
            return res.ToList();
        }

        public void Sort()
        {
            OrderList.Sort((o1, o2) => o1.Id-o2.Id);
        }
    }


    class Program
    {
        static void Main(string[]args)
        {
            Item apple = new Item("apple", 2);
            Item orange = new Item("orange", 3);
            Item banana = new Item("banana", 4);

            Customer Zhang = new Customer("张三");
            Customer Li = new Customer("李四");
            Customer Wang = new Customer("王五");

            OrderDetails detail1 = new OrderDetails(apple, 100, Zhang);
            OrderDetails detail2 = new OrderDetails(banana, 50, Li);

            Order order1 = new Order(1, detail1);
            Order order2 = new Order(2, detail2);

            OrderService orderService = new OrderService();

            orderService.AddOrder(order2);
            orderService.AddOrder(order1);

            orderService.Sort();

        }
    }


}