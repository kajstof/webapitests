using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FastShotter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            return await Task.Run(() => new string[] { "value1", "value2" });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            return await Task.Run(() => $"value {id}");
        }

        [HttpGet("newapi/{id:int}")]
        public ActionResult<string> Get2(int id)
        {
            return "hahaha";
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SomeClassValue value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            value.Value2 = "New Example Value #2";
            return Created("aaa", value);
        }
        
        // POST api/values
//        [HttpPost]
//        public async Task<IActionResult> Post([FromBody] SomeClassValue value)
//        {
//            if (!ModelState.IsValid)
//            {
//                return await Task.Run(() => BadRequest());
//            }
//
//            value.Value2 = "New Example Value #2";
//            return await Task.Run(() => Created("aaa", value));
//        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class SomeClassValue
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string Value2 { get; set; }
    }
}
