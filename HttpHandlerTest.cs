using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace HTTP_Task2.Net
{
    public class HttpHandlerTest : IHttpHandler
    {
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context)
        {
            var OrderList = new List<OrderSample>();
            int? customer = null;
            DateTime? dateFrom = null;
            DateTime? dateTo = null;
            int? take = null;
            int? skip = null;
            int tempInt;
            DateTime tempDateTime;
            var result = OrderList;

            if (context.Request.QueryString["customer"] !=null && int.TryParse(context.Request.QueryString["customer"], out tempInt))
            {
                customer = int.Parse(context.Request.QueryString["customer"]); 
            }
            else if (context.Request["customer"] != null && int.TryParse(context.Request["customer"], out tempInt))
            {
                customer = int.Parse(context.Request["customer"]);
            }

            if (context.Request.QueryString["dateFrom"] != null && DateTime.TryParse(context.Request.QueryString["dateFrom"], out tempDateTime))
            {
                dateTo = DateTime.Parse(context.Request.QueryString["dateFrom"]);
            }
            else if (context.Request["dateFrom"] != null && DateTime.TryParse(context.Request["dateFrom"], out tempDateTime))
            {
                dateTo = DateTime.Parse(context.Request["dateFrom"]);
            }

            if (context.Request.QueryString["dateTo"] != null && DateTime.TryParse(context.Request.QueryString["dateTo"], out tempDateTime))
            {
                dateFrom = DateTime.Parse(context.Request.QueryString["dateTo"]);
            }
            else if (context.Request["dateTo"] != null && DateTime.TryParse(context.Request["dateTo"], out tempDateTime))
            {
                dateFrom = DateTime.Parse(context.Request["dateTo"]);
            }

            if (context.Request.QueryString["take"] != null && int.TryParse(context.Request.QueryString["take"], out tempInt))
            {
                take = int.Parse(context.Request.QueryString["take"]);
            }
            else if (context.Request["take"] != null && int.TryParse(context.Request["take"], out tempInt))
            {
                take = int.Parse(context.Request["take"]);
            }

            if (context.Request.QueryString["skip"] != null && int.TryParse(context.Request.QueryString["skip"], out tempInt))
            {
                skip = int.Parse(context.Request.QueryString["skip"]);
            }
            else if (context.Request["skip"] != null && int.TryParse(context.Request["skip"], out tempInt))
            {
                skip = int.Parse(context.Request["skip"]);
            }

            if (customer != null)
            {
                result = result.Where(x => x.CustomerID == customer).ToList();
            }

            if (dateFrom != null)
            {
                result = result.Where(x => x.Date > dateFrom).ToList();
            }

            if (dateTo != null)
            {
                result = result.Where(x => x.Date < dateTo).ToList();
            }

            if (skip != null)
            {
                result = result.Skip(skip.GetValueOrDefault()).ToList();
            }

            if (take != null)
            {
                result = result.Take(take.GetValueOrDefault()).ToList();
            }

            var serializer = new XmlSerializer(typeof(OrderSample));

            using (var writer = new StreamWriter(@"C:\text.xml"))
            {
                serializer.Serialize(writer, result);
            }
        }
    }
}