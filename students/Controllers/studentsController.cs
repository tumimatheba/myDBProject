using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


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

        [HttpGet()]

        public async Task<ActionResult<List<student>>> Get() 
        {
            
            return Ok(await this.context.students.ToListAsync());
        }
      

        [HttpGet("{id}")]
        public async Task<ActionResult<student>> Get(int id)
        {
            var singleStudent = await this.context.students.FindAsync(id);
            if (singleStudent == null)
                return BadRequest("Student not found.");
            return Ok(singleStudent);
        }

  
        [HttpGet("/count")]
        public async Task<ActionResult<student>> GetByName(string FirstName)
        {

            return Ok(await this.context.students.CountAsync());
        }   
            
     


        [HttpPost]
        public async Task<ActionResult<List<student>>> AddAsingleStudent(student singleStudent)
        {
            context.students.Add(singleStudent);
            await context.SaveChangesAsync();

            return Ok(await context.students.ToListAsync());
        }

        
        [HttpPut]
        public async Task<ActionResult<List<student>>> UpdateStudent(student request)
        {
            var dbStudent = await context.students.FindAsync(request.Id);
            if (dbStudent == null)
                return BadRequest("Student not found.");

           
            dbStudent.FirstName = request.FirstName;
            dbStudent.LastName = request.LastName;
            dbStudent.course = request.course;

            await context.SaveChangesAsync();

            return Ok(await context.students.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<student>>> Delete(int id)
        {
            var dbStudent = await context.students.FindAsync(id);
            if (dbStudent == null)
                return BadRequest("student not found.");

            context.students.Remove(dbStudent);
            await context.SaveChangesAsync();

            return Ok(await context.students.ToListAsync());
        }

    }
  

}