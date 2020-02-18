using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WhatYouGotLibrary.Interfaces;
using WhatYouGotLibrary.Models;

namespace WhatYouGotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly ILogger<FavoritesController> _logger;
        private readonly IFavoriteRepo _favoriteRepo;

        public FavoritesController(ILogger<FavoritesController> logger, IFavoriteRepo favoriteRepo)
        {
            _logger = logger;
            _favoriteRepo = favoriteRepo;
        }

        // GET: api/Recipes
        [HttpGet]
        public IEnumerable<Favorite> GetFavorite()
        {
            IEnumerable<Favorite> favorites = _favoriteRepo.GetFavorites();

            if (favorites != null)
            {
                _logger.LogInformation("Getting all favorites.");
                return favorites.ToList();
            }
            _logger.LogWarning("Attempted to get favorites but no favorites were available.");
            return null;

        }

        // GET: api/Favorites/5
        [HttpGet("{id}")]
        public IActionResult GetFavorite(int id)
        {
            if (!FavoriteExists(id))
            {
                _logger.LogWarning($"Favorite with id: {id} does not exist.");
                return NotFound();
            }

            Favorite favorite = _favoriteRepo.GetFavoriteById(id);

            _logger.LogInformation($"Getting favorite with id: {id}");
            return Ok(favorite);
        }

        [HttpGet("FavoritesByUserId/{userId}")]
        public IActionResult GetFavoritesByUserId(int userId)
        {
            if (!FavoriteByUserIdExists(userId))
            {
                _logger.LogWarning($"Favorite with user id: {userId} does not exist.");
                return NotFound();
            }

            IEnumerable<Favorite> favorites = _favoriteRepo.GetFavoritesByUserId(userId);

            _logger.LogInformation($"Getting favorites with user id: {userId}");
            return Ok(favorites);
        }


        // PUT: api/Favorites/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutFavorite(int id, Favorite favorite)
        {
            if (id != favorite.Id)
            {
                _logger.LogWarning($"Route value id: {id} does not match favorite id: {favorite.Id}");
                return BadRequest();
            }

            if (!FavoriteExists(id))
            {
                _logger.LogWarning($"Favorite with id: {id} does not exist.");
                return NotFound();
            }

            _favoriteRepo.UpdateFavorite(favorite);
            _favoriteRepo.SaveChanges();

            _logger.LogInformation($"Favorite with id: {id} has been updated.");
            return NoContent();

        }

        // POST: api/Favorites
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public IActionResult PostFavorite(Favorite favorite)
        {
            if (FavoriteExists(favorite.Id))
            {
                _logger.LogWarning($"Favorite with id: {favorite.Id} already exists.");
                return Conflict();
            }

            _favoriteRepo.AddFavorite(favorite);
            _favoriteRepo.SaveChanges();

            _logger.LogInformation($"Favorite with id: {favorite.Id} has been added.");
            return CreatedAtAction(nameof(GetFavorite), new { id = favorite.Id }, favorite);
        }

        // DELETE: api/Favorites/5
        [HttpDelete("{id}")]
        public IActionResult DeleteFavorite(int id)
        {
            if (!FavoriteExists(id))
            {
                _logger.LogWarning($"Favorite with id: {id} does not exist.");
                return NotFound();
            }

            _favoriteRepo.DeleteFavoriteById(id);
            _favoriteRepo.SaveChanges();

            _logger.LogInformation($"Favorite with id: {id} has been deleted.");
            return Content($"Favorite with id: {id} has been deleted.");
        }

        //DELETE: api/Reviews/5
        [HttpDelete("{userId}/{recipeId}")]
        public IActionResult DeleteReview(int userId, int recipeId)
        {
            if (!FavoriteExistsByUserIdAndRecipeId(userId, recipeId))
            {
                _logger.LogWarning($"Favorite with user id: {userId} and recipe id: {recipeId} does not exist.");
                return NotFound();
            }

            _favoriteRepo.DeleteFavoriteById(userId, recipeId);
            _favoriteRepo.SaveChanges();

            _logger.LogInformation($"Favorite with user id: {userId} and recipe id: {recipeId} has been deleted.");
            return Content($"Favorite with user id: {userId} and recipe id: {recipeId} has been deleted.");
        }

        private bool FavoriteExists(int id)
        {
            return _favoriteRepo.FavoriteExists(id);
        }

        private bool FavoriteByUserIdExists(int userId)
        {
            return _favoriteRepo.FavoriteByUserIdExists(userId);
        }

        private bool FavoriteExistsByUserIdAndRecipeId(int userId, int recipeId)
        {
            return _favoriteRepo.FavoriteByUserIdAndRecipeIdExists(userId, recipeId);
        }
    }
}
