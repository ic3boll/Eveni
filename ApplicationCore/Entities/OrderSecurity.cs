using System;

namespace ApplicationCore.Entities
{
    public class OrderSecurity : BaseEntity
    {
        public string Ip { get; set; }

        public DateTime TimePlaced { get; set; }
    }
}
