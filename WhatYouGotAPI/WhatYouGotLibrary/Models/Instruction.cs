using System;
using System.Collections.Generic;
using System.Text;

namespace WhatYouGotLibrary.Models
{
    public class Instruction
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int StepNumber { get; set; }
        public string StepDescription { get; set; }
    }
}
