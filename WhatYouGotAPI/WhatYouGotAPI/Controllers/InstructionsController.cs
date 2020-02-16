using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhatYouGotLibrary.Models;
using WhatYouGotLibrary.Interfaces;
using Microsoft.Extensions.Logging;

namespace WhatYouGotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructionsController : ControllerBase
    {
        private readonly ILogger<InstructionsController> _logger;
        private readonly IInstructionRepo _instructionRepo;

        public InstructionsController(ILogger<InstructionsController> logger, IInstructionRepo instructionRepo)
        {
            _logger = logger;
            _instructionRepo = instructionRepo;
        }

        // GET: api/Instructions
        [HttpGet]
        public IEnumerable<Instruction> GetInstruction()
        {
            IEnumerable<Instruction> instructions = _instructionRepo.GetInstructions();

            if (instructions != null)
            {
                _logger.LogInformation("Getting all instructions.");
                return instructions.ToList();
            }

            _logger.LogWarning("Attempted to get instructions but no instructions were available.");
            return null;

        }

        // GET: api/Instructions/5
        [HttpGet("{id}")]
        public IActionResult GetInstruction(int id)
        {
            if (!InstructionExists(id))
            {
                _logger.LogWarning($"Instruction with id: {id} does not exist.");
                return NotFound();
            }

            Instruction instruction = _instructionRepo.GetInstructionById(id);

            _logger.LogInformation($"Getting instruction with id: {id}");
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
                _logger.LogWarning($"Route value id: {id} does not match instruction id: {instruction.Id}");
                return BadRequest();
            }

            if (!InstructionExists(id))
            {
                _logger.LogWarning($"Instruction with id: {id} does not exist.");
                return NotFound();
            }

            _instructionRepo.UpdateInstruction(instruction);
            _instructionRepo.SaveChanges();

            _logger.LogInformation($"Instruction with id: {id} has been updated.");
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
                _logger.LogWarning($"Instruction with id: {instruction.Id} already exists.");
                return Conflict();
            }

            _instructionRepo.AddInstruction(instruction);
            _instructionRepo.SaveChanges();

            _logger.LogInformation($"Instruction with id: {instruction.Id} has been added.");
            return CreatedAtAction(nameof(GetInstruction), new { id = instruction.Id }, instruction);
        }

        // DELETE: api/Instructions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteInstruction(int id)
        {
            if (!InstructionExists(id))
            {
                _logger.LogWarning($"Ingredient with id: {id} does not exist.");
                return NotFound();
            }

            _instructionRepo.DeleteInstructionById(id);
            _instructionRepo.SaveChanges();

            _logger.LogInformation($"Instruction with id: {id} has been deleted.");
            return Content($"Instruction with id: {id} has been deleted.");
        }

        private bool InstructionExists(int id)
        {
            return _instructionRepo.InstructionExists(id);
        }
    }
}
