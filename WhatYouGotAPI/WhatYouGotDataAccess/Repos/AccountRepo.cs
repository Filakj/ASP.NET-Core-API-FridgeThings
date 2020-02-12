using System;
using System.Collections.Generic;
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
    }
}
