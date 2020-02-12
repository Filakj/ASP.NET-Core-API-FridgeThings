using System;
using System.Collections.Generic;
using System.Text;
using WhatYouGotLibrary.Models;

namespace WhatYouGotLibrary.Interfaces
{
    public interface IInstructionRepo
    {
        IEnumerable<Instruction> GetInstructions();

        Instruction GetInstructionById(int id);

        void UpdateInstruction(Instruction instruction);

        void SaveChanges();

        void AddInstruction(Instruction instruction);

        void DeleteInstructionById(int id);

        bool InstructionExists(int id);
    }
}
