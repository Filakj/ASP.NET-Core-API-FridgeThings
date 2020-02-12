using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WhatYouGotDataAccess.Entities;
using WhatYouGotLibrary.Interfaces;
using WhatYouGotLibrary;

namespace WhatYouGotDataAccess.Repos
{
    public class RecipeRepo : IRecipeRepo
    {
        private FridgeThingsDBContext _context;

        public RecipeRepo(FridgeThingsDBContext context)
        {
            _context = context;
        }

        public void AddRecipe(WhatYouGotLibrary.Models.Recipe recipe)
        {
            Entities.Recipe newRecipe = Mapper.Map(recipe);
            _context.Add(newRecipe);
        }

        public void DeleteRecipeById(int id)
        {
            Entities.Recipe recipe = _context.Recipe.Find(id);
            _context.Remove(recipe);
        }

        public WhatYouGotLibrary.Models.Recipe GetRecipeById(int id)
        {
            Entities.Recipe recipe = _context.Recipe.Find(id);

            return Mapper.Map(recipe);
        }

        public IEnumerable<WhatYouGotLibrary.Models.Recipe> GetRecipes()
        {
            IQueryable<Entities.Recipe> recipes = _context.Recipe;

            return recipes.Select(Mapper.Map);
        }

        public bool RecipeExists(int id)
        {
            return _context.Recipe.Any(e => e.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateRecipe(WhatYouGotLibrary.Models.Recipe recipe)
        {
            Entities.Recipe currentRecipe = _context.Recipe.Find(recipe.Id);
            Entities.Recipe newRecipe = Mapper.Map(recipe);

            _context.Entry(currentRecipe).CurrentValues.SetValues(newRecipe);
        }
    }
}
