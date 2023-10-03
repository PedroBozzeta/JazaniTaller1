﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JazaniT1.Api.Controllers.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasureUnitController : ControllerBase
    {
        // GET: api/<MeasureUnitController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MeasureUnitController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MeasureUnitController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MeasureUnitController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MeasureUnitController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
