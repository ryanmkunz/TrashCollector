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
        
        public DayOfWeek WeeklyPickupDay { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString = "{0:yyyy-MM-dd")]
        public DateTime? OneTimePickupDay { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd")]
        public DateTime TempStopStart { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd")]
        public DateTime TempStopEnd { get; set; }
        
        public double Bill { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }

        [ForeignKey("ApplicationUser")]
        [Display(Name = "UserId")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}