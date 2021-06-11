using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class Order_Detail : BaseEntity
    {
        //ID
        //Name
        //Last Name
        //Telephone
        //Email

        //Address-City
        //Address-Street
        //Address-Additional Information


        //CookieID
        public Order_Detail()
        {
            this.Orders = new HashSet<Order>();
        }
        public string Name { get; set; }

        public string LastName { get; set; }

        public int Phone { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string Comment { get; set; }

        public string CookieId { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
