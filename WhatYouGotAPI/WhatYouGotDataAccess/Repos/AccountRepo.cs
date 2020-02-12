using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WhatYouGotDataAccess.Entities;
using WhatYouGotLibrary.Interfaces;

namespace WhatYouGotDataAccess.Repos
{
    public class AccountRepo : IAccountRepo
    {
        private FridgeThingsDBContext _context;

        public AccountRepo(FridgeThingsDBContext context)
        {
            _context = context;
        }

        public bool AccountExists(int id)
        {
            return _context.Account.Any(e => e.Id == id);
        }

        public void AddAccount(WhatYouGotLibrary.Models.Account account)
        {
            Entities.Account newAccount = Mapper.Map(account);
            _context.Add(newAccount);
        }

        public void DeleteAccountById(int id)
        {
            Entities.Account account = _context.Account.Find(id);
            _context.Remove(account);
        }

        public WhatYouGotLibrary.Models.Account GetAccountById(int id)
        {
            Entities.Account account = _context.Account.Find(id);

            return Mapper.Map(account);
        }

        public IEnumerable<WhatYouGotLibrary.Models.Account> GetAccounts()
        {
            IQueryable<Entities.Account> accounts = _context.Account;

            return accounts.Select(Mapper.Map);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateAccount(WhatYouGotLibrary.Models.Account account)
        {
            Entities.Account currentAccount = _context.Account.Find(account.Id);
            Entities.Account newAccount = Mapper.Map(account);

            _context.Entry(currentAccount).CurrentValues.SetValues(newAccount);
        }
    }
}
