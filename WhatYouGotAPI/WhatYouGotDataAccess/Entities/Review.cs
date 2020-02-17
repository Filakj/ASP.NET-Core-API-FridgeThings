using System;
using System.Collections.Generic;

namespace WhatYouGotDataAccess.Entities
{
    public partial class Review
    {
        public int UserId { get; set; }
        public int RecipeId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
