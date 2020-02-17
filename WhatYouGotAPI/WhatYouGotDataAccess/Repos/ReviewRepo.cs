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

        public void DeleteReviewById(int id)
        {
            Entities.Review review = _context.Review.Find(id);
            _context.Remove(review);
        }

        public WhatYouGotLibrary.Models.Review GetReviewById(int id)
        {
            Entities.Review review = _context.Review.Find(id);

            return Mapper.Map(review);
        }

        public IEnumerable<WhatYouGotLibrary.Models.Review> GetReviews()
        {
            IQueryable<Entities.Review> reviews = _context.Review;

            return reviews.Select(Mapper.Map);
        }

        /*
        public bool ReviewExists(int id)
        {
            return _context.Review.Any(e => e.Id == id);
        }
        */

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        /*
        public void UpdateReview(WhatYouGotLibrary.Models.Review review)
        {
            Entities.Review currentReview = _context.Review.Find(review.Id);
            Entities.Review newReview = Mapper.Map(review);

            _context.Entry(currentReview).CurrentValues.SetValues(newReview);
        }
        */
    }
}
