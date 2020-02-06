using System;
using System.Collections.Generic;
using System.Text;
using WhatYouGot.Library.Models;
using Xunit;

namespace WhatYouGot.Test.Library.Models
{
    public class AccountTest
    {
        private readonly Account _account = new Account();

        [Fact]
        public void Id_NonEmptyValue_StoresCorrectly()
        {
            int randomIntValue = 1;
            _account.Id = randomIntValue;
            Assert.Equal(randomIntValue, _account.Id);
        }

        [Fact]
        public void Username_NonEmptyValue_StoresCorrectly()
        {
            string randomStringValue = "foodlover";
            _account.Username = randomStringValue;
            Assert.Equal(randomStringValue, _account.Username);
        }

        [Fact]
        public void Passphrase_NonEmptyValue_StoresCorrectly()
        {
            string randomStringValue = "password";
            _account.Passphrase = randomStringValue;
            Assert.Equal(randomStringValue, _account.Passphrase);
        }

        [Fact]
        public void FirstName_NonEmptyValue_StoresCorrectly()
        {
            string randomStringValue = "Rodney";
            _account.FirstName = randomStringValue;
            Assert.Equal(randomStringValue, _account.FirstName);
        }

        [Fact]
        public void LastName_NonEmptyValue_StoresCorrectly()
        {
            string randomStringValue = "Canlas";
            _account.LastName = randomStringValue;
            Assert.Equal(randomStringValue, _account.LastName);
        }

        [Fact]
        public void Email_NonEmptyValue_StoresCorrectly()
        {
            string randomStringValue = "abc@gmail.com";
            _account.Email = randomStringValue;
            Assert.Equal(randomStringValue, _account.Email);
        }
    }
}
