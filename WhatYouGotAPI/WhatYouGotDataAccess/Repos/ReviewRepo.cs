using System;
using System.Collections.Generic;
using System.Text;
using WhatYouGotDataAccess.Entities;
using WhatYouGotLibrary.Interfaces;

namespace WhatYouGotDataAccess.Repos
{
    public class ReviewRepo : IReviewRepo
    {
        private FridgeThingsDBContext _context;

        public ReviewRepo(FridgeThingsDBContext context)
        {
            _context = context;
        }
    }
}
