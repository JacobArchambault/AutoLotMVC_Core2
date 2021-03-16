using AutoLotDAL_Core2.Models.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AutoLotDAL_Core2.Models
{
    public record Customer : EntityBase
    {
        [StringLength(50)]
        [DisplayName("First name")]
        public string FirstName { get; set; }
        [StringLength(50)]
        [DisplayName("Last name")]
        public string LastName { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
    }
}