using System;
using System.Collections.Generic;
using System.Text;
using WhatYouGotLibrary.Models;
using Xunit;

namespace WhatYouGotTest.Library.Models
{
    public class RecipeTest
    {
        private readonly Recipe _recipe = new Recipe();

        [Fact]
        public void Id_NonEmptyValue_StoresCorrectly()
        {
            int randomIntValue = 1;
            _recipe.Id = randomIntValue;
            Assert.Equal(randomIntValue, _recipe.Id);
        }

        [Fact]
        public void Title_NonEmptyValue_StoresCorrectly()
        {
            string randomStringValue = "Chicken Sandwich";
            _recipe.Title = randomStringValue;
            Assert.Equal(randomStringValue, _recipe.Title);
        }
    }
}
