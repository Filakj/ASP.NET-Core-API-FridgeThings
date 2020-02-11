using System;
using System.Collections.Generic;

namespace WhatYouGotDataAccess.Entities
{
    public partial class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
}
