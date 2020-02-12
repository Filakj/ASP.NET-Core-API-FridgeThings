using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhatYouGotLibrary.Models;
using WhatYouGotLibrary.Interfaces;

namespace WhatYouGotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructionsController : ControllerBase
    {
        private readonly IInstructionRepo _instructionRepo;

        public InstructionsController(IInstructionRepo instructionRepo)
        {
            _instructionRepo = instructionRepo;
        }

        // GET: api/Instructions
        [HttpGet]
        public IEnumerable<Instruction> GetInstruction()
        {
            IEnumerable<Instruction> instructions = _instructionRepo.GetInstructions();

            if (instructions != null)
            {
                return instructions.ToList();
            }
            return null;

        }

        // GET: api/Instructions/5
        [HttpGet("{id}")]
        public IActionResult GetInstruction(int id)
        {
            if (!InstructionExists(id))
            {
                return NotFound();
            }

            Instruction instruction = _instructionRepo.GetInstructionById(id);

            return Ok(instruction);
        }

        // PUT: api/Instructions/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutInstruction(int id, Instruction instruction)
        {
            if (id != instruction.Id)
            {
                return BadRequest();
            }

            if (!InstructionExists(id))
            {
                return NotFound();
            }

            _instructionRepo.UpdateInstruction(instruction);
            _instructionRepo.SaveChanges();

            return NoContent();

        }

        // POST: api/Instructions
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public IActionResult PostInstruction(Instruction instruction)
        {
            if (InstructionExists(instruction.Id))
            {
                return Conflict();
            }

            _instructionRepo.AddInstruction(instruction);
            _instructionRepo.SaveChanges();

            return CreatedAtAction(nameof(GetInstruction), new { id = instruction.Id }, instruction);
        }

        // DELETE: api/Instructions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteInstruction(int id)
        {
            if (!InstructionExists(id))
            {
                return NotFound();
            }

            _instructionRepo.DeleteInstructionById(id);
            _instructionRepo.SaveChanges();

            return Content($"Instruction with id: {id} has been deleted.");
        }

        private bool InstructionExists(int id)
        {
            return _instructionRepo.InstructionExists(id);
        }
    }
}
