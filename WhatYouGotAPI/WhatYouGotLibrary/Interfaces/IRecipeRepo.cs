using System;
using System.Collections.Generic;
using System.Text;
using WhatYouGotLibrary.Models;

namespace WhatYouGotLibrary.Interfaces
{
    public interface IRecipeRepo
    {
        IEnumerable<Recipe> GetRecipes();

        Recipe GetRecipeById(int id);

        void UpdateRecipe(Recipe recipe);

        void SaveChanges();

        void AddRecipe(Recipe recipe);

        void DeleteRecipeById(int id);

        bool RecipeExists(int id);
    }
}
