using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTTP_Task2.Net
{
    public class OrderSample
    {
        public int CustomerID { get; set; }
        public DateTime Date { get; set; }
        public string CustomerName { get; set; }
        public int OrderPrice { get; set; }
        public string OrderDescription { get; set; }
        public string PhoneNumber { get; set; }
        
        public OrderSample(int customerId, DateTime date, string customerName, int orderPrice, string orderDescription, string phoneNumber)
        {
            CustomerID = customerId;
            Date = date;
            CustomerName = customerName;
            OrderPrice = orderPrice;
            OrderDescription = orderDescription;
            PhoneNumber = phoneNumber;
        }
        public static List<OrderSample> GenerateOrderSamples()
        {
            var orderSampleList = new List<OrderSample>();
            for (int i = 0; i < 10; i++)
            {
                orderSampleList.Add(new OrderSample(i, DateTime.Now, i.ToString(), i, i.ToString(), i.ToString()));
            }
            return orderSampleList;
        }

    }
}