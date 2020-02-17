using System;
using System.Collections.Generic;
using System.Text;
using WhatYouGotLibrary.Models;

namespace WhatYouGotLibrary.Interfaces
{
    public interface IReviewRepo
    {

        IEnumerable<Review> GetReviews();

        Review GetReviewById(int recipeId, int userId);

        void UpdateReview(Review review);

        void SaveChanges();

        void AddReview(Review review);

        void DeleteReviewById(int userId, int recipeId);

        bool ReviewExists(int userId, int recipeId);

    }
}
