using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WhatYouGotLibrary.Interfaces;
using WhatYouGotLibrary.Models;

namespace WhatYouGotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ILogger<AccountsController> _logger;
        private readonly IAccountRepo _accountRepo;

        public AccountsController(ILogger<AccountsController> logger, IAccountRepo accountRepo)
        {
            _logger = logger;
            _accountRepo = accountRepo;
        }

        // GET: api/Recipes
        [HttpGet]
        public IEnumerable<Account> GetAccount()
        {
            IEnumerable<Account> accounts = _accountRepo.GetAccounts();

            if (accounts != null)
            {
                _logger.LogInformation("Getting all accounts.");
                return accounts.ToList();
            }
            _logger.LogWarning("Attempted to get accounts but no accounts were available.");
            return null;

        }

        // GET: api/Recipes/5
        [HttpGet("{id}")]
        public IActionResult GetAccount(int id)
        {
            if (!AccountExists(id))
            {
                _logger.LogWarning($"Account with id: {id} does not exist.");
                return NotFound();
            }

            Account account = _accountRepo.GetAccountById(id);

            _logger.LogInformation($"Getting account with id: {id}");
            return Ok(account);
        }

        // PUT: api/Recipes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutAccount(int id, Account account)
        {
            if (id != account.Id)
            {
                _logger.LogWarning($"Route value id: {id} does not match account id: {account.Id}");
                return BadRequest();
            }

            if (!AccountExists(id))
            {
                _logger.LogWarning($"Account with id: {id} does not exist.");
                return NotFound();
            }

            _accountRepo.UpdateAccount(account);
            _accountRepo.SaveChanges();

            _logger.LogInformation($"Account with id: {id} has been updated.");
            return NoContent();

        }

        // POST: api/Recipes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public IActionResult PostAccount(Account account)
        {
            if (AccountExists(account.Id))
            {
                _logger.LogWarning($"Account with id: {account.Id} already exists.");
                return Conflict();
            }

            _accountRepo.AddAccount(account);
            _accountRepo.SaveChanges();

            _logger.LogInformation($"Account with id: {account.Id} has been added.");
            return CreatedAtAction(nameof(GetAccount), new { id = account.Id }, account);
        }

        // DELETE: api/Recipes/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAccount(int id)
        {
            if (!AccountExists(id))
            {
                _logger.LogWarning($"Account with id: {id} does not exist.");
                return NotFound();
            }

            _accountRepo.DeleteAccountById(id);
            _accountRepo.SaveChanges();

            _logger.LogInformation($"Account with id: {id} has been deleted.");
            return Content($"Account with id: {id} has been deleted.");
        }

        private bool AccountExists(int id)
        {
            return _accountRepo.AccountExists(id);
        }
    }
}
