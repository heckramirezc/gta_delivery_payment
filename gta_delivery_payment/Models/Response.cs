using System;
namespace gta_delivery_payment.Models
{
    public class Response
    {
        public Response(int amount)
        {
            this.amount = amount;
        }

        public int amount { get; set; }
    }
}
