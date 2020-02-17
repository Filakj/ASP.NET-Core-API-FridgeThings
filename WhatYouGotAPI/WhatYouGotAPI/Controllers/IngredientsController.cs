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
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly ILogger<IngredientsController> _logger;
        private readonly IIngredientRepo _ingredientRepo;

        public IngredientsController(ILogger<IngredientsController> logger, IIngredientRepo ingredientRepo)
        {
            _logger = logger;
            _ingredientRepo = ingredientRepo;
        }

        // GET: api/Ingredients
        [HttpGet]
        public IEnumerable<Ingredient> GetIngredient()
        {
            IEnumerable<Ingredient> ingredients = _ingredientRepo.GetIngredients();

            if (ingredients != null)
            {
                _logger.LogInformation("Getting all ingredients.");
                return ingredients.ToList();
            }
            _logger.LogWarning("Attempted to get ingredients but no ingredients were available.");
            return null;

        }

        // GET: api/Ingredients/5
        [HttpGet("{id}")]
        public IActionResult GetIngredient(int id)
        {
            if (!IngredientExists(id))
            {
                _logger.LogWarning($"Ingredient with id: {id} does not exist.");
                return NotFound();
            }

            Ingredient ingredient = _ingredientRepo.GetIngredientById(id);

            _logger.LogInformation($"Getting ingredient with id: {id}");
            return Ok(ingredient);
        }

         // GET: api/Ingredients/ByRecipe/5
        [HttpGet("/ByRecipe/{recipeId}")]
        public IEnumerable<Ingredient> GetIngredients(int recipeId)
        {
            IEnumerable<Ingredient> ingredients = _ingredientRepo.GetIngredientsByRecipe(recipeId);

            if (ingredients != null)
            {
                return ingredients.ToList();
            }
            return null;
        }

        // PUT: api/Ingredients/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutIngredient(int id, Ingredient ingredient)
        {
            if (id != ingredient.Id)
            {
                _logger.LogWarning($"Route value id: {id} does not match ingredient id: {ingredient.Id}");
                return BadRequest();
            }

            if (!IngredientExists(id))
            {
                _logger.LogWarning($"Ingredient with id: {id} does not exist.");
                return NotFound();
            }

            _ingredientRepo.UpdateIngredient(ingredient);
            _ingredientRepo.SaveChanges();

            _logger.LogInformation($"Ingredient with id: {id} has been updated.");
            return NoContent();

        }

        // POST: api/Ingredients
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public IActionResult PostIngredient(Ingredient ingredient)
        {
            if (IngredientExists(ingredient.Id))
            {
                _logger.LogWarning($"Ingredient with id: {ingredient.Id} already exists.");
                return Conflict();
            }

            _ingredientRepo.AddIngredient(ingredient);
            _ingredientRepo.SaveChanges();

            _logger.LogInformation($"Ingredient with id: {ingredient.Id} has been added.");
            return CreatedAtAction(nameof(GetIngredient), new { id = ingredient.Id }, ingredient);
        }

        // DELETE: api/Ingredients/5
        [HttpDelete("{id}")]
        public IActionResult DeleteIngredient(int id)
        {
            if (!IngredientExists(id))
            {
                _logger.LogWarning($"Ingredient with id: {id} does not exist.");
                return NotFound();
            }

            _ingredientRepo.DeleteIngredientById(id);
            _ingredientRepo.SaveChanges();

            _logger.LogInformation($"Ingredient with id: {id} has been deleted.");
            return Content($"Ingredient with id: {id} has been deleted.");
        }

        private bool IngredientExists(int id)
        {
            return _ingredientRepo.IngredientExists(id);
        }
    }
}
