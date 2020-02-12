using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhatYouGotLibrary.Interfaces;
using WhatYouGotLibrary.Models;

namespace WhatYouGotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoriteRepo _favoriteRepo;

        public FavoritesController(IFavoriteRepo favoriteRepo)
        {
            _favoriteRepo = favoriteRepo;
        }

        // GET: api/Recipes
        [HttpGet]
        public IEnumerable<Favorite> GetFavorite()
        {
            IEnumerable<Favorite> favorites = _favoriteRepo.GetFavorites();

            if (favorites != null)
            {
                return favorites.ToList();
            }
            return null;

        }

        // GET: api/Recipes/5
        [HttpGet("{id}")]
        public IActionResult GetFavorite(int id)
        {
            if (!FavoriteExists(id))
            {
                return NotFound();
            }

            Favorite favorite = _favoriteRepo.GetFavoriteById(id);

            return Ok(favorite);
        }

        // PUT: api/Recipes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutFavorite(int id, Favorite favorite)
        {
            if (id != favorite.Id)
            {
                return BadRequest();
            }

            if (!FavoriteExists(id))
            {
                return NotFound();
            }

            _favoriteRepo.UpdateFavorite(favorite);
            _favoriteRepo.SaveChanges();

            return NoContent();

        }

        // POST: api/Recipes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public IActionResult PostFavorite(Favorite favorite)
        {
            if (FavoriteExists(favorite.Id))
            {
                return Conflict();
            }

            _favoriteRepo.AddFavorite(favorite);
            _favoriteRepo.SaveChanges();

            return CreatedAtAction(nameof(GetFavorite), new { id = favorite.Id }, favorite);
        }

        // DELETE: api/Recipes/5
        [HttpDelete("{id}")]
        public IActionResult DeleteFavorite(int id)
        {
            if (!FavoriteExists(id))
            {
                return NotFound();
            }

            _favoriteRepo.DeleteFavoriteById(id);
            _favoriteRepo.SaveChanges();

            return Content($"Favorite with id: {id} has been deleted.");
        }

        private bool FavoriteExists(int id)
        {
            return _favoriteRepo.FavoriteExists(id);
        }
    }
}
