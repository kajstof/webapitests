using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FastShotter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("getmath")]
        public async Task<IEnumerable<string>> GetMath()
        {
            using (SchoolContext context = new SchoolContext())
            {
                IQueryable<Course> mathCourses = context.Courses.Where(x => x.CourseName.EndsWith("Math"));
                return await Task.Run(() => mathCourses.Select(x => $"{x.CourseName}_Ans").ToList());
            }
        }

        [HttpPost("postmath")]
        public async Task<IActionResult> PostMath([FromBody] CourseJson courseName)
        {
            using (SchoolContext context = new SchoolContext())
            {
                var course = new Course() { CourseName = $"{courseName.CourseName} Math"};
                await context.Courses.AddAsync(course);
                await context.SaveChangesAsync();
                return await Task.Run(() => Created($"values/{nameof(GetMath).ToLower()}", course.CourseId));
            }
        }
        
        [HttpPost("postmath1")]
        public async Task<IActionResult> PostMath1([FromBody] CourseJson courseName)
        {
            using (SchoolContext context = new SchoolContext())
            {
                var course = new Course() { CourseName = $"{courseName.CourseName} Math"};
                context.Courses.Add(course);
                context.SaveChanges();
                return Created($"values/{nameof(GetMath).ToLower()}", course.CourseId);
            }
        }
        
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

        [HttpGet("newapiapi/{id}")]
        public async Task<ActionResult<string>> Get3(int id)
        {
            return await Task.Run(() => $"value {id}");
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SomeClassValue value)
        {
            if (!ModelState.IsValid)
            {
                return await Task.Run(() => BadRequest());
            }

            value.Value2 = "New Example Value #2";
            return await Task.Run(() => Created("aaa", value));
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

    public class CourseJson
    {
        public string CourseName { get; set; }
    }
}
