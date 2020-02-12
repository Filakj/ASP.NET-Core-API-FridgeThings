using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhatYouGotLibrary.Models;
using WhatYouGotLibrary.Interfaces;

namespace WhatYouGotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeRepo _recipeRepo;

        public RecipesController(IRecipeRepo recipeRepo)
        {
            _recipeRepo = recipeRepo;
        }

        // GET: api/Recipes
        [HttpGet]
        public IEnumerable<Recipe> GetRecipe()
        {
            IEnumerable<Recipe> recipes = _recipeRepo.GetRecipes();

            if (recipes != null)
            {
                return recipes.ToList();
            }
            return null;
            
        }

        // GET: api/Recipes/5
        [HttpGet("{id}")]
        public IActionResult GetRecipe(int id)
        {
            if (!RecipeExists(id))
            {
                return NotFound();
            }
            
            Recipe recipe = _recipeRepo.GetRecipeById(id);

            return Ok(recipe);
        }

        // PUT: api/Recipes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutRecipe(int id, Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return BadRequest();
            }

            if (!RecipeExists(id))
            {
                return NotFound();
            }

            _recipeRepo.UpdateRecipe(recipe);
            _recipeRepo.SaveChanges();
            
            return NoContent();

        }

        // POST: api/Recipes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public IActionResult PostRecipe(Recipe recipe)
        {
            if (RecipeExists(recipe.Id))
            {
                return Conflict();
            }

            _recipeRepo.AddRecipe(recipe);
            _recipeRepo.SaveChanges();

            return CreatedAtAction(nameof(GetRecipe), new { id = recipe.Id }, recipe);
        }

        // DELETE: api/Recipes/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRecipe(int id)
        {
            if (!RecipeExists(id))
            {
                return NotFound();
            }

            _recipeRepo.DeleteRecipeById(id);
            _recipeRepo.SaveChanges();

            return Content($"Recipe with id: {id} has been deleted.");
        }

        private bool RecipeExists(int id)
        {
            return _recipeRepo.RecipeExists(id);
        }
    }
}
