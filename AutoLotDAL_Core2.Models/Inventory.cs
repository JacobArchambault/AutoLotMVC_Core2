﻿using AutoLotDAL_Core2.Models.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AutoLotDAL_Core2.Models
{
    [Table("Inventory")]
    public record Inventory : EntityBase
    {
        [StringLength(50)]
        public string Make { get; set; }
        [StringLength(50)]
        public string Color { get; set; }
        [StringLength(50), DisplayName("Pet name")]
        public string PetName { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        public override string ToString()
        {
            return $"{PetName ?? "**No Name **"} is a {Color} {Make} with ID {Id}.";
        }
        [NotMapped]
        public string MakeColor => $"{Make} ({Color})";

    }
}