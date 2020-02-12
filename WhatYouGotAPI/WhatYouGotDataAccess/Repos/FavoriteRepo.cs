using System;
using System.Collections.Generic;
using System.Text;
using WhatYouGotDataAccess.Entities;
using WhatYouGotLibrary.Interfaces;

namespace WhatYouGotDataAccess.Repos
{
    public class FavoriteRepo : IFavoriteRepo
    {
        private FridgeThingsDBContext _context;

        public FavoriteRepo(FridgeThingsDBContext context)
        {
            _context = context;
        }
    }
}
