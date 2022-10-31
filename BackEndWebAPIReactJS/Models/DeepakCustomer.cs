using System;
using System.Collections.Generic;

#nullable disable

namespace BackEndWebAPIReactJS.Models
{
    public partial class DeepakCustomer
    {
        public DeepakCustomer()
        {
            DeepakLandlords = new HashSet<DeepakLandlord>();
        }

        public int Customer_Id { get; set; }
        public string Customer_Site { get; set; }
        public string Customer_Region { get; set; }
        public string Customer_Market { get; set; }

        public virtual ICollection<DeepakLandlord> DeepakLandlords { get; set; }
    }
}
