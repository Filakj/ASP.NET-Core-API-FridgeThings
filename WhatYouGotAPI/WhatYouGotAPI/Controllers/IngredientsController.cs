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
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientRepo _ingredientRepo;

        public IngredientsController(IIngredientRepo ingredientRepo)
        {
            _ingredientRepo = ingredientRepo;
        }

        // GET: api/Ingredients
        [HttpGet]
        public IEnumerable<Ingredient> GetIngredient()
        {
            IEnumerable<Ingredient> ingredients = _ingredientRepo.GetIngredients();

            if (ingredients != null)
            {
                return ingredients.ToList();
            }
            return null;

        }

        // GET: api/Ingredients/5
        [HttpGet("{id}")]
        public IActionResult GetIngredient(int id)
        {
            if (!IngredientExists(id))
            {
                return NotFound();
            }

            Ingredient ingredient = _ingredientRepo.GetIngredientById(id);

            return Ok(ingredient);
        }

        // PUT: api/Ingredients/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutIngredient(int id, Ingredient ingredient)
        {
            if (id != ingredient.Id)
            {
                return BadRequest();
            }

            if (!IngredientExists(id))
            {
                return NotFound();
            }

            _ingredientRepo.UpdateIngredient(ingredient);
            _ingredientRepo.SaveChanges();

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
                return Conflict();
            }

            _ingredientRepo.AddIngredient(ingredient);
            _ingredientRepo.SaveChanges();

            return CreatedAtAction(nameof(GetIngredient), new { id = ingredient.Id }, ingredient);
        }

        // DELETE: api/Ingredients/5
        [HttpDelete("{id}")]
        public IActionResult DeleteIngredient(int id)
        {
            if (!IngredientExists(id))
            {
                return NotFound();
            }

            _ingredientRepo.DeleteIngredientById(id);
            _ingredientRepo.SaveChanges();

            return Content($"Ingredient with id: {id} has been deleted.");
        }

        private bool IngredientExists(int id)
        {
            return _ingredientRepo.IngredientExists(id);
        }
    }
}
