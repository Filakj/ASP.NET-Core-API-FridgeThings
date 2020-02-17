using System;
using System.Collections.Generic;
using System.Text;
using WhatYouGotLibrary.Models;
using Xunit;

namespace WhatYouGotTest.Library.Models
{
    public class ReviewTest
    {
        private readonly Review _review = new Review();

        [Fact]
        public void Id_NonEmptyValue_StoresCorrectly()
        {
            int randomIntValue = 1;
            _review.Id = randomIntValue;
            Assert.Equal(randomIntValue, _review.Id);
        }

        [Fact]
        public void UserId_NonEmptyValue_StoresCorrectly()
        {
            int randomIntValue = 1;
            _review.UserId = randomIntValue;
            Assert.Equal(randomIntValue, _review.UserId);
        }

        [Fact]
        public void RecipeId_NonEmptyValue_StoresCorrectly()
        {
            int randomIntValue = 1;
            _review.RecipeId = randomIntValue;
            Assert.Equal(randomIntValue, _review.RecipeId);
        }

        [Fact]
        public void Rating_NonEmptyValue_StoresCorrectly()
        {
            int randomIntValue = 1;
            _review.Rating = randomIntValue;
            Assert.Equal(randomIntValue, _review.Rating);
        }

        [Fact]
        public void Comment_NonEmptyValue_StoresCorrectly()
        {
            string randomStringValue = "Wow! Delicious!";
            _review.Comment = randomStringValue;
            Assert.Equal(randomStringValue, _review.Comment);
        }
    }
}
