using System;


namespace WhatYouGot.DataAccess
{
    public static class Mapper
    {
        public static Entities.Account Map(Library.Models.Account account)
        {
            return new Entities.Account
            {
                Id = account.Id,
                Username = account.Username,
                Passphrase = account.Passphrase,
                FirstName = account.FirstName,
                LastName = account.LastName,
                Email = account.Email
            };
        }

        public static Library.Models.Account Map(Entities.Account account)
        {
            return new Library.Models.Account
            {
                Id = account.Id,
                Username = account.Username,
                Passphrase = account.Passphrase,
                FirstName = account.FirstName,
                LastName = account.LastName,
                Email = account.Email
            };
        }

        public static Entities.Favorite Map(Library.Models.Favorite favorite)
        {
            return new Entities.Favorite
            {
                Id = favorite.Id,
                UserId = favorite.UserId,
                RecipeId = favorite.RecipeId
            };
        }

        public static Library.Models.Favorite Map(Entities.Favorite favorite)
        {
            return new Library.Models.Favorite
            {
                Id = favorite.Id,
                UserId = favorite.UserId,
                RecipeId = favorite.RecipeId
            };
        }

        public static Entities.Recipe Map(Library.Models.Recipe recipe)
        {
            return new Entities.Recipe
            {
                Id = recipe.Id,
                Title = recipe.Title
            };
        }

        public static Library.Models.Recipe Map(Entities.Recipe recipe)
        {
            return new Library.Models.Recipe
            {
                Id = recipe.Id,
                Title = recipe.Title
            };
        }

        public static Entities.Review Map(Library.Models.Review review)
        {
            return new Entities.Review
            {
                Id = review.Id,
                UserId = review.UserId,
                RecipeId = review.RecipeId,
                Rating = review.Rating,
                Comment = review.Comment
            };
        }
    }
}
