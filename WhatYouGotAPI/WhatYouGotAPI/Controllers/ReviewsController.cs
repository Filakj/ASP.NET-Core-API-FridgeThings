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

    /*

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
            if (!ReviewExists(id))
            {
                _logger.LogWarning($"Review with id: {id} does not exist.");
                return NotFound();
            }

            Review review = _reviewRepo.GetReviewById(id);

            _logger.LogInformation($"Getting review with id: {id}");
            return Ok(review);
        }

        // PUT: api/Reviews/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutReview(int id, Review review)
        {
            if (id != review.Id)
            {
                _logger.LogWarning($"Route value id: {id} does not match review id: {review.Id}");
                return BadRequest();
            }

            if (!ReviewExists(id))
            {
                _logger.LogWarning($"Review with id: {id} does not exist.");
                return NotFound();
            }

            _reviewRepo.UpdateReview(review);
            _reviewRepo.SaveChanges();

            _logger.LogInformation($"Review with id: {id} has been updated.");
            return NoContent();

        }

        // POST: api/Reviews
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public IActionResult PostReview(Review review)
        {
            if (ReviewExists(review.Id))
            {
                _logger.LogWarning($"Review with id: {review.Id} already exists.");
                return Conflict();
            }

            _reviewRepo.AddReview(review);
            _reviewRepo.SaveChanges();

            _logger.LogInformation($"Review with id: {review.Id} has been added.");
            return CreatedAtAction(nameof(GetReview), new { id = review.Id }, review);
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public IActionResult DeleteReview(int id)
        {
            if (!ReviewExists(id))
            {
                _logger.LogWarning($"Review with id: {id} does not exist.");
                return NotFound();
            }

            _reviewRepo.DeleteReviewById(id);
            _reviewRepo.SaveChanges();

            _logger.LogInformation($"Review with id: {id} has been deleted.");
            return Content($"Review with id: {id} has been deleted.");
        }

        private bool ReviewExists(int id)
        {
            return _reviewRepo.ReviewExists(id);
        }

    */
    }

