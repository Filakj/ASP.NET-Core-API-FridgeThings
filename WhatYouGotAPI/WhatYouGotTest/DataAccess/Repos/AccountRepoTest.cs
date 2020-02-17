using System;
using System.Collections.Generic;
using System.Text;
using WhatYouGotDataAccess.Repos;
using WhatYouGotLibrary.Models;

namespace WhatYouGotTest.DataAccess.Repos
{
    public class AccountRepoTest
    {
        private static Account[] _accountMockStore = new Account[]
        {
            new Account
            {
                Id = 1,
                Username = "foodlover",
                Passphrase = "yumdelicious!",
                FirstName = "Rodney",
                LastName = "Canlas",
                Email = "canlas@gmail.com"
            },
            new Account
            {
                Id = 2,
                Username = "creativechef",
                Passphrase = "ilovecooking!",
                FirstName = "Austin",
                LastName = "Nim",
                Email = "nim@gmail.com"
            }
        };

        //private AccountRepo _accountRepo = new AccountRepo(_accountMockStore);
    }
}
