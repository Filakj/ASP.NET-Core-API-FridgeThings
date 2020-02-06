using System;
using System.Collections.Generic;
using System.Text;

namespace WhatYouGot.Library.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RecipeId { get; set; }
    }
}
