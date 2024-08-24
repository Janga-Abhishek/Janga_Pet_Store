﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace JangaPetStore.Models
{

    public class Cart
    {
        public int CartId { get; set; }
        public string UserId { get; set; }
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
