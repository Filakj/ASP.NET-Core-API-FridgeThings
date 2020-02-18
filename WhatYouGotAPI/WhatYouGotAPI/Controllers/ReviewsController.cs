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
    public class ReviewsController : ControllerBase
    {
        private readonly ILogger<ReviewsController> _logger;
        private readonly IReviewRepo _reviewRepo;

        public ReviewsController(ILogger<ReviewsController> logger, IReviewRepo reviewRepo)
        {
            _logger = logger;
            _reviewRepo = reviewRepo;
        }

        // GET: api/Reviews
        [HttpGet]
        public IEnumerable<Review> GetReview()
        {
            IEnumerable<Review> reviews = _reviewRepo.GetReviews();

            if (reviews != null)
            {
                _logger.LogInformation("Getting all reviews.");
                return reviews.ToList();
            }
            _logger.LogWarning("Attempted to get reviews but no reviews were available.");
            return null;

        }

        // GET: api/Reviews/5
        [HttpGet("{userId}/{recipeId}")]
        public IActionResult GetReview(int userId, int recipeId)
        {
            if (!ReviewExists(userId, recipeId))
            {
                _logger.LogWarning($"Review with user id: {userId} and recipe id: {recipeId} does not exist.");
                return NotFound();
            }

            Review review = _reviewRepo.GetReviewById(userId, recipeId);

            _logger.LogInformation($"Getting review with user id: {userId} and recipe id: {recipeId}.");
            return Ok(review);
        }

        [HttpGet("ReviewsByUserId/{userId}")]
        public IActionResult GetReviewsByUserId(int userId)
        {
            if (!ReviewByUserIdExists(userId))
            {
                _logger.LogWarning($"Review with user id: {userId} does not exist.");
                return NotFound();
            }

            IEnumerable<Review> reviews = _reviewRepo.GetReviewsByUserId(userId);

            _logger.LogInformation($"Getting review with user id: {userId}.");
            return Ok(reviews);
        }

        [HttpGet("ReviewsByRecipeId/{recipeId}")]
        public IActionResult GetReviewsByRecipeId(int recipeId)
        {
            if (!ReviewByRecipeIdExists(recipeId))
            {
                _logger.LogWarning($"Review with user id: {recipeId} does not exist.");
                return NotFound();
            }

            IEnumerable<Review> reviews = _reviewRepo.GetReviewsByRecipeId(recipeId);

            _logger.LogInformation($"Getting review with user id: {recipeId}.");
            return Ok(reviews);
        }

        //PUT: api/Reviews/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{userId}/{recipeId}")]
        public IActionResult PutReview(int userId, int recipeId, Review review)
        {
            if (userId != review.UserId || recipeId != review.RecipeId)
            {
                _logger.LogWarning($"Route values: user id: {userId} and recipe id: {recipeId} does not " +
                    $"match Review user id: {review.UserId} and Review recipe id: {review.RecipeId}");
                return BadRequest();
            }

            if (!ReviewExists(userId, recipeId))
            {
                _logger.LogWarning($"Review with user id: {userId} and recipe id: {recipeId} does not exist.");
                return NotFound();
            }

            _reviewRepo.UpdateReview(review);
            _reviewRepo.SaveChanges();

            _logger.LogInformation($"Review with user id: {userId} and recipe id: {recipeId} has been updated.");
            return NoContent();

        }

        //POST: api/Reviews
        //To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public IActionResult PostReview(Review review)
        {
            if (ReviewExists(review.UserId, review.RecipeId))
            {
                _logger.LogWarning($"Review with user id: {review.UserId} and recipe id: {review.RecipeId} already exists.");
                return Conflict();
            }

            _reviewRepo.AddReview(review);
            _reviewRepo.SaveChanges();

            _logger.LogInformation($"Review with user id: {review.UserId} and recipe id: {review.RecipeId} has been added.");
            return CreatedAtAction(nameof(GetReview), review);
        }

        //DELETE: api/Reviews/5
        [HttpDelete("{userId}/{recipeId}")]
        public IActionResult DeleteReview(int userId, int recipeId)
        {
            if (!ReviewExists(userId, recipeId))
            {
                _logger.LogWarning($"Review with user id: {userId} and recipe id: {recipeId} does not exist.");
                return NotFound();
            }

            _reviewRepo.DeleteReviewById(userId, recipeId);
            _reviewRepo.SaveChanges();

            _logger.LogInformation($"Review with user id: {userId} and recipe id: {recipeId} has been deleted.");
            return Content($"Review with user id: {userId} and recipe id: {recipeId} has been deleted.");
        }

        private bool ReviewExists(int userId, int recipeId)
        {
            return _reviewRepo.ReviewExists(userId, recipeId);
        }

        private bool ReviewByUserIdExists(int userId)
        {
            return _reviewRepo.ReviewByUserIdExists(userId);
        }

        private bool ReviewByRecipeIdExists(int recipeId)
        {
            return _reviewRepo.ReviewByRecipeIdExists(recipeId);
        }

    }
}

