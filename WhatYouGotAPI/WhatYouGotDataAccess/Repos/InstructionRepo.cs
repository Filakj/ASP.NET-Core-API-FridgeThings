using System;
using System.Collections.Generic;
using System.Linq;
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

        public void AddInstruction(WhatYouGotLibrary.Models.Instruction instruction)
        {
            Entities.Instruction newInstruction = Mapper.Map(instruction);
            _context.Add(newInstruction);
        }

        public void DeleteInstructionById(int id)
        {
            Entities.Instruction instruction = _context.Instruction.Find(id);
            _context.Remove(instruction);
        }

        public WhatYouGotLibrary.Models.Instruction GetInstructionById(int id)
        {
            Entities.Instruction instruction = _context.Instruction.Find(id);

            return Mapper.Map(instruction);
        }

        public IEnumerable<WhatYouGotLibrary.Models.Instruction> GetInstructions()
        {
            IQueryable<Entities.Instruction> instructions = _context.Instruction;

            return instructions.Select(Mapper.Map);
        }

        public bool InstructionExists(int id)
        {
            return _context.Instruction.Any(e => e.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateInstruction(WhatYouGotLibrary.Models.Instruction instruction)
        {
            Entities.Instruction currentInstruction = _context.Instruction.Find(instruction.Id);
            Entities.Instruction newInstruction = Mapper.Map(instruction);

            _context.Entry(currentInstruction).CurrentValues.SetValues(newInstruction);
        }
    }
}
