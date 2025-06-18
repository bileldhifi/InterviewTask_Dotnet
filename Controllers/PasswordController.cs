using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InterviewTask_Dotnet.Models;
using InterviewTask_Dotnet.Repositories;

namespace InterviewTask_Dotnet.Controllers
{

[ApiController]
    [Route("api/[controller]")]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordRepository _repository;

        public PasswordController(IPasswordRepository repository)
        {
            _repository = repository;
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
    }
}