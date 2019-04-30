using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollection.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int WeeklyPickupDay { get; set; }
        public int OneTimePickupDay { get; set; }
        public int TempStopStart { get; set; }
        public int TempStopEnd { get; set; }
        public int Bill { get; set; }

        [ForeignKey("Address")]
        [Display(Name = "Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}