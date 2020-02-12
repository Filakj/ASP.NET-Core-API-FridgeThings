using System;
using System.Collections.Generic;
using System.Text;
using WhatYouGotDataAccess.Entities;
using WhatYouGotLibrary.Interfaces;

namespace WhatYouGotDataAccess.Repos
{
    public class InstructionRepo : IInstructionRepo
    {
        private FridgeThingsDBContext _context;

        public InstructionRepo(FridgeThingsDBContext context)
        {
            _context = context;
        }
    }
}
