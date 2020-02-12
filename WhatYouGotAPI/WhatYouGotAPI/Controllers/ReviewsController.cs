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
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewRepo _reviewRepo;

        public ReviewsController(IReviewRepo reviewRepo)
        {
            _reviewRepo = reviewRepo;
        }

        // GET: api/Reviews
        [HttpGet]
        public IEnumerable<Review> GetReview()
        {
            IEnumerable<Review> reviews = _reviewRepo.GetReviews();

            if (reviews != null)
            {
                return reviews.ToList();
            }
            return null;

        }

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public IActionResult GetReview(int id)
        {
            if (!ReviewExists(id))
            {
                return NotFound();
            }

            Review review = _reviewRepo.GetReviewById(id);

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
                return BadRequest();
            }

            if (!ReviewExists(id))
            {
                return NotFound();
            }

            _reviewRepo.UpdateReview(review);
            _reviewRepo.SaveChanges();

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
                return Conflict();
            }

            _reviewRepo.AddReview(review);
            _reviewRepo.SaveChanges();

            return CreatedAtAction(nameof(GetReview), new { id = review.Id }, review);
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public IActionResult DeleteReview(int id)
        {
            if (!ReviewExists(id))
            {
                return NotFound();
            }

            _reviewRepo.DeleteReviewById(id);
            _reviewRepo.SaveChanges();

            return Content($"Review with id: {id} has been deleted.");
        }

        private bool ReviewExists(int id)
        {
            return _reviewRepo.ReviewExists(id);
        }
    }
}
