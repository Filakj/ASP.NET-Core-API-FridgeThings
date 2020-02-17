using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WhatYouGotDataAccess.Entities;
using WhatYouGotLibrary.Interfaces;

namespace WhatYouGotDataAccess.Repos
{
    public class ReviewRepo : IReviewRepo
    {
        private FridgeThingsDBContext _context;

        public ReviewRepo(FridgeThingsDBContext context)
        {
            _context = context;
        }

        public void AddReview(WhatYouGotLibrary.Models.Review review)
        {
            Entities.Review newReview = Mapper.Map(review);
            _context.Add(newReview);
        }

        public void DeleteReviewById(int userId, int recipeId)
        {
            IQueryable<Review> reviews = from r in _context.Review
                                         where r.UserId == userId & r.RecipeId == recipeId
                                         select r;

            Entities.Review review = reviews.FirstOrDefault();
            _context.Remove(review);
        }

        public WhatYouGotLibrary.Models.Review GetReviewById(int userId, int recipeId)
        {
            IQueryable<Review> reviews = from r in _context.Review
                                         where r.UserId == userId & r.RecipeId == recipeId
                                         select r;
            Entities.Review review = reviews.FirstOrDefault();

            return Mapper.Map(review);
        }

        public IEnumerable<WhatYouGotLibrary.Models.Review> GetReviews()
        {
            IQueryable<Entities.Review> reviews = _context.Review;

            return reviews.Select(Mapper.Map);
        }

        public bool ReviewExists(int userId, int recipeId)
        {
            return _context.Review.Any(review => review.UserId == userId && review.RecipeId == recipeId);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        
        public void UpdateReview(WhatYouGotLibrary.Models.Review review)
        {
            IQueryable<Review> reviews = from r in _context.Review
                                         where r.UserId == review.UserId & r.RecipeId == review.RecipeId
                                         select r;

            Entities.Review currentReview = reviews.FirstOrDefault();
            Entities.Review newReview = Mapper.Map(review);

            _context.Entry(currentReview).CurrentValues.SetValues(newReview);
        }
        
    }
}
