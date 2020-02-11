using System;
using System.Collections.Generic;

namespace WhatYouGotDataAccess.Entities
{
    public partial class Ingredient
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string ImageUrl { get; set; }
        public string IngredientName { get; set; }
        public decimal Ammount { get; set; }
        public string Unit { get; set; }
    }
}
