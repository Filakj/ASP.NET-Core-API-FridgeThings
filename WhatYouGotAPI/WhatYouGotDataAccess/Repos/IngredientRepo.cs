using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WhatYouGotDataAccess.Entities;
using WhatYouGotLibrary.Interfaces;

namespace WhatYouGotDataAccess.Repos
{
    public class IngredientRepo : IIngredientRepo
    {
        private FridgeThingsDBContext _context;

        public IngredientRepo(FridgeThingsDBContext context)
        {
            _context = context;
        }

        public void AddIngredient(WhatYouGotLibrary.Models.Ingredient ingredient)
        {
            Entities.Ingredient newIngredient = Mapper.Map(ingredient);
            _context.Add(newIngredient);
        }

        public void DeleteIngredientById(int id)
        {
            Entities.Ingredient ingredient = _context.Ingredient.Find(id);
            _context.Remove(ingredient);
        }

        public WhatYouGotLibrary.Models.Ingredient GetIngredientById(int id)
        {
            Entities.Ingredient ingredient = _context.Ingredient.Find(id);

            return Mapper.Map(ingredient);
        }

        public IEnumerable<WhatYouGotLibrary.Models.Ingredient> GetIngredients()
        {
            IQueryable<Entities.Ingredient> ingredients = _context.Ingredient;

            return ingredients.Select(Mapper.Map);
        }

        public bool IngredientExists(int id)
        {
            return _context.Ingredient.Any(e => e.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateIngredient(WhatYouGotLibrary.Models.Ingredient ingredient)
        {
            Entities.Ingredient currentIngredient = _context.Ingredient.Find(ingredient.Id);
            Entities.Ingredient newIngredient = Mapper.Map(ingredient);

            _context.Entry(currentIngredient).CurrentValues.SetValues(newIngredient);
        }
    }
}
