using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InterviewTask_Dotnet.Models;
using InterviewTask_Dotnet.Repositories;
using InterviewTask_Dotnet.Services;

namespace InterviewTask_Dotnet.Controllers
{

[ApiController]
    [Route("api/[controller]")]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordRepository _repository;
        private readonly PasswordEncryptionService _encryptionService;


        public PasswordController(IPasswordRepository repository, PasswordEncryptionService encryptionService)
        {
         _repository = repository;
         _encryptionService = encryptionService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _repository.GetAll();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _repository.GetById(id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Add([FromBody] PasswordItem item)
        {
            item.EncryptedPassword = _encryptionService.Encrypt(item.EncryptedPassword);

            _repository.Add(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PasswordItem item)
        {
            var existing = _repository.GetById(id);
            if (existing == null)
                return NotFound();

            item.Id = id;
           item.EncryptedPassword = _encryptionService.Encrypt(item.EncryptedPassword);

            _repository.Update(item);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _repository.GetById(id);
            if (existing == null)
                return NotFound();

            _repository.Delete(id);
            return NoContent();
        }

        [HttpGet("decrypted/{id}")]
        public IActionResult GetDecryptedById(int id)
        {
            var item = _repository.GetById(id);
            if (item == null)
            return NotFound();

            var decryptedPassword = _encryptionService.Decrypt(item.EncryptedPassword);

            var result = new
            {
                item.Id,
                item.Category,
                item.App,
                item.UserName,
                DecryptedPassword = decryptedPassword
            };

            return Ok(result);
        }

    }
}