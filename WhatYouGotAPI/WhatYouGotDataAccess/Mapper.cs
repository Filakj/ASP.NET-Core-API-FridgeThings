using System;
using System.Collections.Generic;
using System.Text;

namespace WhatYouGotDataAccess
{
    public static class Mapper
    {
        public static Entities.Account Map(WhatYouGotLibrary.Models.Account account)
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

        public static WhatYouGotLibrary.Models.Account Map(Entities.Account account)
        {
            return new WhatYouGotLibrary.Models.Account
            {
                Id = account.Id,
                Username = account.Username,
                Passphrase = account.Passphrase,
                FirstName = account.FirstName,
                LastName = account.LastName,
                Email = account.Email
            };
        }

        public static Entities.Favorite Map(WhatYouGotLibrary.Models.Favorite favorite)
        {
            return new Entities.Favorite
            {
                Id = favorite.Id,
                UserId = favorite.UserId,
                RecipeId = favorite.RecipeId
            };
        }

        public static WhatYouGotLibrary.Models.Favorite Map(Entities.Favorite favorite)
        {
            return new WhatYouGotLibrary.Models.Favorite
            {
                Id = favorite.Id,
                UserId = favorite.UserId,
                RecipeId = favorite.RecipeId
            };
        }

        public static Entities.Ingredient Map(WhatYouGotLibrary.Models.Ingredient ingredient)
        {
            return new Entities.Ingredient
            {
                Id = ingredient.Id,
                RecipeId = ingredient.RecipeId,
                ImageUrl = ingredient.ImageUrl,
                IngredientName = ingredient.IngredientName,
                Amount = ingredient.Amount,
                Unit = ingredient.Unit
            };
        }

        public static WhatYouGotLibrary.Models.Ingredient Map(Entities.Ingredient ingredient)
        {
            return new WhatYouGotLibrary.Models.Ingredient
            {
                Id = ingredient.Id,
                RecipeId = ingredient.RecipeId,
                ImageUrl = ingredient.ImageUrl,
                IngredientName = ingredient.IngredientName,
                Amount = ingredient.Amount,
                Unit = ingredient.Unit
            };
        }

        public static Entities.Instruction Map(WhatYouGotLibrary.Models.Instruction instruction)
        {
            return new Entities.Instruction
            {
                Id = instruction.Id,
                RecipeId = instruction.RecipeId,
                StepNumber = instruction.StepNumber,
                StepDescription = instruction.StepDescription
            };
        }

        public static WhatYouGotLibrary.Models.Instruction Map(Entities.Instruction instruction)
        {
            return new WhatYouGotLibrary.Models.Instruction
            {
                Id = instruction.Id,
                RecipeId = instruction.RecipeId,
                StepNumber = instruction.StepNumber,
                StepDescription = instruction.StepDescription
            };
        }

        public static Entities.Recipe Map(WhatYouGotLibrary.Models.Recipe recipe)
        {
            return new Entities.Recipe
            {
                Id = recipe.Id,
                Title = recipe.Title,
                ImageUrl = recipe.ImageUrl
            };
        }

        public static WhatYouGotLibrary.Models.Recipe Map(Entities.Recipe recipe)
        {
            return new WhatYouGotLibrary.Models.Recipe
            {
                Id = recipe.Id,
                Title = recipe.Title,
                ImageUrl = recipe.ImageUrl
            };
        }

        public static Entities.Review Map(WhatYouGotLibrary.Models.Review review)
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

        public static WhatYouGotLibrary.Models.Review Map(Entities.Review review)
        {
            return new WhatYouGotLibrary.Models.Review
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
