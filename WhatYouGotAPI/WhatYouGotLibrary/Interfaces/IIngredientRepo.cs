using System;
using System.Collections.Generic;
using System.Text;
using WhatYouGotLibrary.Models;

namespace WhatYouGotLibrary.Interfaces
{
    public interface IIngredientRepo
    {
        IEnumerable<Ingredient> GetIngredients();

        Ingredient GetIngredientById(int id);

        void UpdateIngredient(Ingredient ingredient);

        void SaveChanges();

        void AddIngredient(Ingredient ingredient);

        void DeleteIngredientById(int id);

        bool IngredientExists(int id);
    }
}
