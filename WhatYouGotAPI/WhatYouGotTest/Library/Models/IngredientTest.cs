using System;
using System.Collections.Generic;
using System.Text;
using WhatYouGotLibrary.Models;
using Xunit;

namespace WhatYouGotTest.Library.Models
{
    public class IngredientTest
    {
        private readonly Ingredient _ingredient = new Ingredient();

        [Fact]
        public void Id_NonEmptyValue_StoresCorrectly()
        {
            int randomIntValue = 1;
            _ingredient.Id = randomIntValue;
            Assert.Equal(randomIntValue, _ingredient.Id);
        }

        [Fact]
        public void RecipeId_NonEmptyValue_StoresCorrectly()
        {
            int randomIntValue = 2;
            _ingredient.RecipeId = randomIntValue;
            Assert.Equal(randomIntValue, _ingredient.RecipeId);
        }

        [Fact]
        public void ImageUrl_NonEmptyValue_StoresCorrectly()
        {
            string randomStringValue = "random.com";
            _ingredient.ImageUrl = randomStringValue;
            Assert.Equal(randomStringValue, _ingredient.ImageUrl);
        }

        [Fact]
        public void IngredientName_NonEmptyValue_StoresCorrectly()
        {
            string randomStringValue = "chicken";
            _ingredient.IngredientName = randomStringValue;
            Assert.Equal(randomStringValue, _ingredient.IngredientName);
        }

        [Fact]
        public void Amount_NonEmptyValue_StoresCorrectly()
        {
            decimal randomDecimalValue = Convert.ToDecimal(2.5);
            _ingredient.Amount = randomDecimalValue;
            Assert.Equal(randomDecimalValue, _ingredient.Amount);
        }

        [Fact]
        public void Unit_NonEmptyValue_StoresCorrectly()
        {
            string randomStringValue = "lbs";
            _ingredient.Unit = randomStringValue;
            Assert.Equal(randomStringValue, _ingredient.Unit);
        }
    }
}
