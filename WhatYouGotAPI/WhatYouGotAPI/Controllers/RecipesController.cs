using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhatYouGotLibrary.Models;
using WhatYouGotLibrary.Interfaces;
using Microsoft.Extensions.Logging;

namespace WhatYouGotAPI.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly ILogger<RecipesController> _logger;
        private readonly IRecipeRepo _recipeRepo;

        public RecipesController(ILogger<RecipesController> logger, IRecipeRepo recipeRepo)
        {
            _logger = logger;
            _recipeRepo = recipeRepo;
        }

        // GET: api/Recipes

        [HttpGet]
        public IEnumerable<Recipe> Get()
        {
            IEnumerable<Recipe> recipes = _recipeRepo.GetRecipes();

            if (recipes != null)
            {
                _logger.LogInformation("Getting all recipes.");
                return recipes.ToList();
            }
            _logger.LogWarning("Attempted to get recipes but no recipes were available.");
            return null;
            
        }

        // GET: api/Recipes/5
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]int id)
        {
            if (!RecipeExists(id))
            {
                _logger.LogWarning($"Recipe with id: {id} does not exist.");
                return NotFound();
            }
            
            Recipe recipe = _recipeRepo.GetRecipeById(id);

            _logger.LogInformation($"Getting recipe with id: {id}");
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
                _logger.LogWarning($"Route value id: {id} does not match recipe id: {recipe.Id}");
                return BadRequest();
            }

            if (!RecipeExists(id))
            {
                _logger.LogWarning($"Recipe with id: {id} does not exist.");
                return NotFound();
            }

            _recipeRepo.UpdateRecipe(recipe);
            _recipeRepo.SaveChanges();

            _logger.LogInformation($"Recipe with id: {id} has been updated.");
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
                _logger.LogWarning($"Recipe with id: {recipe.Id} already exists.");
                return Conflict();
            }

            _recipeRepo.AddRecipe(recipe);
            _recipeRepo.SaveChanges();

            _logger.LogInformation($"Recipe with id: {recipe.Id} has been added.");
            return CreatedAtAction(nameof(Get), new { id = recipe.Id }, recipe);
        }

        // DELETE: api/Recipes/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRecipe(int id)
        {
            if (!RecipeExists(id))
            {
                _logger.LogWarning($"Recipe with id: {id} does not exist.");
                return NotFound();
            }

            _recipeRepo.DeleteRecipeById(id);
            _recipeRepo.SaveChanges();

            _logger.LogInformation($"Recipe with id: {id} has been deleted.");
            return Content($"Recipe with id: {id} has been deleted.");
        }

        private bool RecipeExists(int id)
        {
            return _recipeRepo.RecipeExists(id);
        }
    }
}
