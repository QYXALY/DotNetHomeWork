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
            return $"商品为{OrderItem}，共{ItemCnt}个，客户为{OrderCustomer.CustomerName}";
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

        public static void AddOrder(Order order)  //添加订单
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

        public static void ChangeOrder(int id, OrderDetails detail) //修改订单
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

        public static void DelOrder(int id) //删除订单
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
        public static List<Order> FindById(int id)
        {
            var res = from o in OrderList where id == o.Id select o;
            return res.ToList();
        }

        public static List<Order> FindByItem(string name)
        {
            var res = from o in OrderList where name == o.Detail.OrderItem.ItemName select o;
            return res.ToList();
        }

        public static List<Order> FindByCustomer(string name)
        {
            var res = from o in OrderList where name == o.Detail.OrderCustomer.CustomerName select o;
            return res.ToList();
        }

        public static List<Order> FindByCost(double cost)
        {
            var res = from o in OrderList where cost == o.Detail.OrderCost select o;
            return res.ToList();
        }

        public void Sort()
        {
            OrderList.Sort((o1, o2) => o1.Id-o2.Id);
        }
    }



}