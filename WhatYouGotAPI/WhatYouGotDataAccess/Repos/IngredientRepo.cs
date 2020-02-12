using System;
using System.Collections.Generic;
using System.Text;
using WhatYouGotDataAccess.Entities;
using WhatYouGotLibrary.Interfaces;

namespace WhatYouGotDataAccess.Repos
{
    public class IngredientRepo : IIngredientRepo
    {
        private FridgeThingsDBContext _context;

        public IngredientRepo(FridgeThingsDBContext context)
        {
            _context = context;
        }
    }
}
