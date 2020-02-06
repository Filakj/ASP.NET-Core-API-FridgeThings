using System;
using System.Collections.Generic;

namespace WhatYouGot.DataAccess.Entities
{
    public partial class Favorite
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RecipeId { get; set; }
    }
}
