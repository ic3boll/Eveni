using System;

namespace ApplicationCore.Entities
{
    public class OrderSecurity : BaseEntity
    {
        public int Ip { get; set; }

        public DateTime TimePlaced { get; set; }
    }
}
