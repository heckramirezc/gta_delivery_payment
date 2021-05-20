using System;
namespace gta_delivery_payment.Models
{
    public class Response
    {
        public Response() { }
        public Response(int count)
        {
            this.count = count;
        }

        public int count { get; set; }
    }
}
