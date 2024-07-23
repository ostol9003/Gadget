﻿using System.ComponentModel.DataAnnotations;

namespace Gadget.Data.Data.Shop
{
    public class Producers
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}