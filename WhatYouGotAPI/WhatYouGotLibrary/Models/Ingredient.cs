using System;
using System.Collections.Generic;
using System.Text;

namespace WhatYouGotLibrary.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string ImageUrl { get; set; }
        public string IngredientName { get; set; }
        public decimal? Amount { get; set; }
        public string Unit { get; set; }
    }
}
