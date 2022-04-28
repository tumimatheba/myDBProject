using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using students.data;

namespace students.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class studentsController : ControllerBase
    {
        private readonly studentContext context;

        public studentsController(studentContext context) 
        {
            this.context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<student>>> Get() 
        {
            return Ok(await this.context.students.ToListAsync());
        }
    }
  

}