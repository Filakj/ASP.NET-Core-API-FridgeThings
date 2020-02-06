using System;
using System.Collections.Generic;
using System.Text;
using WhatYouGot.Library.Models;
using Xunit;

namespace WhatYouGot.Test.Library.Models
{
    public class FavoriteTest
    {
        private readonly Favorite _favorite = new Favorite();

        [Fact]
        public void Id_NonEmptyValue_StoresCorrectly()
        {
            int randomIntValue = 1;
            _favorite.Id = randomIntValue;
            Assert.Equal(randomIntValue, _favorite.Id);
        }

        [Fact]
        public void UserId_NonEmptyValue_StoresCorrectly()
        {
            int randomIntValue = 1;
            _favorite.UserId = randomIntValue;
            Assert.Equal(randomIntValue, _favorite.UserId);
        }

        [Fact]
        public void RecipeId_NonEmptyValue_StoresCorrectly()
        {
            int randomIntValue = 1;
            _favorite.RecipeId = randomIntValue;
            Assert.Equal(randomIntValue, _favorite.RecipeId);
        }
    }
}
