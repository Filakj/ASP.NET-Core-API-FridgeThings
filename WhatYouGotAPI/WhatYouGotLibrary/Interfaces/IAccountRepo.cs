using System;
using System.Collections.Generic;
using System.Text;
using WhatYouGotLibrary.Models;

namespace WhatYouGotLibrary.Interfaces
{
    public interface IAccountRepo
    {
        IEnumerable<Account> GetAccounts();

        Account GetAccountById(int id);

        void UpdateAccount(Account account);

        void SaveChanges();

        void AddAccount(Account account);

        void DeleteAccountById(int id);

        bool AccountExists(int id);
    }
}
