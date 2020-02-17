using System;
using System.Collections.Generic;
using System.Text;
using WhatYouGotLibrary.Models;
using Xunit;

namespace WhatYouGotTest.Library.Models
{
    public class InstructionTest
    {
        private readonly Instruction _instruction = new Instruction();

        [Fact]
        public void Id_NonEmptyValue_StoresCorrectly()
        {
            int randomIntValue = 1;
            _instruction.Id = randomIntValue;
            Assert.Equal(randomIntValue, _instruction.Id);
        }

        [Fact]
        public void RecipeId_NonEmptyValue_StoresCorrectly()
        {
            int randomIntValue = 2;
            _instruction.RecipeId = randomIntValue;
            Assert.Equal(randomIntValue, _instruction.RecipeId);
        }

        [Fact]
        public void StepNumber_NonEmptyValue_StoresCorrectly()
        {
            int randomIntValue = 1;
            _instruction.StepNumber = randomIntValue;
            Assert.Equal(randomIntValue, _instruction.StepNumber);
        }

        [Fact]
        public void StepDescription_NonEmptyValue_StoresCorrectly()
        {
            string randomStringValue = "Heat the pan.";
            _instruction.StepDescription = randomStringValue;
            Assert.Equal(randomStringValue, _instruction.StepDescription);
        }
    }
}
